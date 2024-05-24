using DGU_TimeScheduler.ModelDatas;

namespace DGUtility.TimeScheduler;

/// <summary>
/// 시간 스케줄러.
/// <para>이 스케줄러는 1초에 한번씩 동작한다.</para>
/// </summary>
/// <remarks>
/// 이 라이브러리는 날짜를 처리하는데 목적이 있으므로 1초에 한번씩 동작하도록 구현되어 있다.
/// <para>TimeScheduler.TodayStandard가 변경되면 LoopCount가 초기화된다.<br />
/// 이로인해 반복 간격이 달라질 수 있음을 명심해야 한다.</para>
/// </remarks>
public class TimeScheduler
{
    #region 외부에서 연결할 이벤트
    /// <summary>
    /// 시간 스케줄러 대리자
    /// </summary>
    public delegate void TimeSchedulerDelegate();


    /// <summary>
    /// 날짜 변경 이벤트
    /// </summary>
    /// <remarks>
    /// On1Day와 달리 이 이벤트는 컴퓨터의 날짜가 바뀌면 발생한다.
    /// <para>기준 날짜를 기준으로 변경되는 이벤트는 On1DayStandard를 사용해야 한다.</para>
    /// </remarks>
    public event TimeSchedulerDelegate? On1Day;
    /// <summary>
    /// 날짜 변경을 알림
    /// </summary>
    public void On1DayCall()
    {
        if (On1Day != null)
        {
            On1Day();
        }
    }

    /// <summary>
    /// 하루 마다 발생하는 이벤트.
    /// <para>기준 날짜가 변경되면 발생한다.</para>
    /// </summary>
    public event TimeSchedulerDelegate? On1DayStandard;
    /// <summary>
    /// 하루 이벤트 호출
    /// </summary>
    public void On1DayStandardCall()
    {
        if (On1DayStandard != null)
        {
            On1DayStandard();
        }
    }

    #endregion

    /// <summary>
    /// 사용할 타이머.
    ///<para>이 타이머의 인터벌이 1틱이 된다.</para>
    /// </summary>
    private System.Timers.Timer? m_Timer_1LoopSecond;


    /// <summary>
    /// 지금 동작 상태
    /// </summary>
    public TimeSchedulerOperationType TimeSchedulerOperationType { get; private set; }

    /// <summary>
    /// 누적된 루프 기준 틱카운트.
    /// </summary>
    /// <remarks>
    /// 리셋시간(LoopCountResetTime)을 기준으로 0이된다.
    /// </remarks>
    public int LoopCount { get; private set; }

    /// <summary>
    /// 스케줄러가 가지고 있는 컴퓨터 기준 오늘 날짜.
    /// </summary>
    /// <remarks>
    /// LoopTickCountResetTime과 상관없이 오늘 날짜를 가지고 있는다.<br />
    /// 시간은 가지고 있지 않는다.
    /// </remarks>
    public DateTime Today { get; private set; }
    /// <summary>
    /// 스케줄러가 가지고 있는 오늘 날짜.
    /// </summary>
    /// <remarks>
    /// LoopTickCountResetTime을 기준으로 날짜가 변경된다.<br />
    /// 시간은 가지고 있지 않는다.
    /// </remarks>
    public DateTime TodayStandard { get; private set; }

    /// <summary>
    /// 하루 정보를 리셋하는 기준 시간
    /// </summary>
    /// <remarks>
    /// TodayStandard는 이 시간을 기준으로 날짜가 변경된다.
    /// </remarks>
    public TimeSpan LoopCountResetTime { get; private set; }

    /// <summary>
    /// 기준 시간이 지나면 다음날 취급할지 여부
    /// </summary>
    /// <remarks>
    /// true : 기준 시간이 지나면 다음날로 취급한다.
    /// <para>false : 기준 시간 지나기 전까지는 전날로 취급한다.</para>
    /// </remarks>
    public bool NextDay { get; private set; } = false;

    #region StopWatchList 관련
    /// <summary>
    /// 지정한 간격만큼 반복 실행할 액션 리스트
    /// </summary>
    public List<StopWatchDataModel> StopWatchList 
        = new List<StopWatchDataModel>();

    /// <summary>
    /// 스톱워치리스트에 내용을 추가하고 생성된 데이터모델을 리턴한다.
    /// </summary>
    /// <param name="sName"></param>
    /// <param name="nTickCount"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public StopWatchDataModel StopWatch_Add(
        string sName
        , int nTickCount
        , Action<int, int> action)
    {
        StopWatchDataModel swReturn = new StopWatchDataModel();
        swReturn.Name = sName;
        swReturn.TickCount = nTickCount;
        swReturn.Action = action;

        this.StopWatchList.Add(swReturn);

        return swReturn;
    }

    /// <summary>
    /// 지정된 개채를 스톱워치리스트에서 지웁니다.
    /// </summary>
    /// <param name="swTarget"></param>
    public void StopWatch_Remove(StopWatchDataModel swTarget)
    {
        this.StopWatchList.Remove(swTarget);
    }
    /// <summary>
    /// 지정된 이름의 개체를 찾아 스톱워치리스트에서 지웁니다.
    /// </summary>
    /// <param name="sTargetName"></param>
    public void StopWatch_Remove(string sTargetName)
    {
        this.StopWatchList.RemoveAll(r => r.Name == sTargetName);
    }
    #endregion

    /// <summary>
    /// 시간 스케줄러 생성
    /// </summary>
    /// <param name="bNextDay">기준 시간이 지나면 다음날 취급할지 여부</param>
    public TimeScheduler(bool bNextDay = false)
    {
        this.Reset(TimeSpan.Parse("00:00:00"), bNextDay);
    }

    /// <summary>
    /// 기준 시간을 지정하여 기준 시간 생성.
    /// </summary>
    /// <param name="timeLoopResetTime">하루가 시작의 기준 시간
    /// <para>DateTime를 사용하는 경우 : DateTime.TimeOfDay</para>
    /// <para>문자열을 사용하는 경우 : TimeSpan.Parse("00:00:00")</para></param>
    /// <param name="bNextDay">기준 시간이 지나면 다음날 취급할지 여부</param>
    public TimeScheduler(TimeSpan timeLoopResetTime, bool bNextDay = false)
    {
        this.Reset(timeLoopResetTime, bNextDay);
    }

    /// <summary>
    /// 기준 정보를 다시 저장한다.
    /// </summary>
    /// <param name="timeLoopResetTime">하루가 시작의 기준 시간</param>
    /// <param name="bNextDay">기준 시간이 지나면 다음날 취급할지 여부</param>
    public void Reset(TimeSpan timeLoopResetTime, bool bNextDay = false)
    {
        //정보 저장
        this.LoopCountResetTime = timeLoopResetTime;
        this.NextDay = bNextDay;

        //동작 상태 초기화
        this.TimeSchedulerOperationType = TimeSchedulerOperationType.Stop;

        //오늘 날짜 저장 *************************************
        this.Today = DateTime.Now.Date;

        //1 게임틱 타이머 ***************************************
        this.m_Timer_1LoopSecond = new System.Timers.Timer();
        this.m_Timer_1LoopSecond.Stop();
        //1초 지정
        this.m_Timer_1LoopSecond.Interval = 1000;
        this.m_Timer_1LoopSecond.Elapsed -= M_Timer_1Loop_Elapsed;
        this.m_Timer_1LoopSecond.Elapsed += M_Timer_1Loop_Elapsed;


        //지금 기준날짜 입력 **********************
        DateTime dtNow = DateTime.Now;
        DateTime dtNowDate = dtNow.Date;

        //기준 시간이 됐는지 확인 *****************
        this.DateToStandard_Check(dtNowDate, false);
    }


    /// <summary>
    /// 틱마다 동작할 내용
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void M_Timer_1Loop_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        DateTime dtNow = DateTime.Now;
        DateTime dtNowDate = dtNow.Date;
        //TimeSpan timeNow = dtNow.TimeOfDay;

        //1초 처리 내용
        ++this.LoopCount;

        for (int i = 0; i < this.StopWatchList.Count; ++i)
        {
            StopWatchDataModel item = this.StopWatchList[i];

            
            if (1 == item.TickCount 
                || 0 == (this.LoopCount % item.TickCount))
            {//지정된 시간1초이다.(1초는 계산할 필요가 없으므로 바로 실행)
             //간격에도달함

                item.Action(this.LoopCount, item.TickCount);
            }
        }

        //하루 이벤트
        if (dtNowDate > this.Today)
        {//날짜가 다음 날짜가 됨

            //날짜 리셋
            this.Today = dtNowDate.Date;
            //날짜 변경을 알림
            On1DayCall();
        }

        //기준 시간이 됐는지 확인 *****************
        this.DateToStandard_Check(dtNow, true);
    }

    /// <summary>
    /// 다음날로 넘어갔는지 체크
    /// </summary>
    /// <param name="dtNowDate">지금 날짜</param>
    private void DateToStandard_Check(
        DateTime dtNowDate
        , bool bEvent)
    {
        //DateToStandard로 계산된 날짜
        DateTime dtDate_Next = this.DateToStandard(dtNowDate);

        if (dtDate_Next != this.TodayStandard)
        {//날짜가 바뀜

            //루프카운트 초기화
            this.LoopCount = 0;
            //기준 날짜 변경
            this.TodayStandard = dtDate_Next;

            if(true == bEvent)
            {
                //기준 시간이 변경됐음을 알림
                this.On1DayStandardCall();
            }
        }


        //if ((dtNowDate > this.TodayStandard)
        //    && (timeNow > this.LoopTickCountResetTime))
        //{//날짜가 다음 날짜이고
        // //시간이 지정된 시간 이후다.

        //    //루프카운트 초기화
        //    this.LoopTickCount = 0;
        //    //기준 날짜 변경
        //    this.TodayStandard = dtNowDate.Date;

        //    //기준 시간이 변경됐음을 알림
        //    this.On1DayStandardCall();
        //}
    }


    /// <summary>
    /// 스케줄러 시작
    /// </summary>
    public void Start()
    {
        this.m_Timer_1LoopSecond!.Start();
    }

    /// <summary>
    /// 스케줄러 정지.
    /// 기준 시간과 카운터도 초기화된다.
    /// </summary>
    public void Stop()
    {
        DateTime dtNow = DateTime.Now;
        DateTime dtNowDate = dtNow.Date;

        this.m_Timer_1LoopSecond!.Stop();

        //루프카운트 초기화
        this.LoopCount = 0;
        //날짜 리셋
        this.Today = dtNowDate;
    }

    /// <summary>
    /// 스케줄러 일시 정지
    /// </summary>
    public void Pause()
    {
        this.m_Timer_1LoopSecond!.Stop();
    }



    /// <summary>
    /// 지정된 날짜의 기준 날짜를 리턴한다.
    /// </summary>
    /// <remarks>
    /// 지정된 날짜의 기준 날짜가 전날인지 오늘인지를 계산하여 리턴한다.
    /// <para>NextDay == true : LoopTickCountResetTime가 지났다면 내일 날짜를 준다.</para>
    /// <para>NextDay == false : 지정된 날짜의 시간이 0시이후인데 
    /// LoopTickCountResetTime 시간전이라면 전날 날짜를 주게 된다.</para>
    /// </remarks>
    /// <param name="dtTarget"></param>
    /// <returns>년,월,일 만 리턴됨 </returns>
    public DateTime DateToStandard(DateTime dtTarget)
    {
        DateTime dtReturn = new DateTime(
                            dtTarget.Year
                            , dtTarget.Month
                            , dtTarget.Day);

        if (false == this.NextDay)
        {//전날 취급

            //대상의 오늘 간격받기
            if (dtTarget.TimeOfDay < this.LoopCountResetTime)
            {//대상의 오늘 간격이 LoopTickCountResetTime보다 작다.

                //전날로 취급해야 한다.
                dtReturn = dtReturn.AddDays(-1);
            }
        }
        else
        {//다음날 취급

            //대상의 오늘 간격받기
            if (dtTarget.TimeOfDay > this.LoopCountResetTime)
            {//대상의 오늘 간격이 LoopTickCountResetTime보다 크다.

                //다음날로 취급해야 한다.
                dtReturn = dtReturn.AddDays(1);
            }
        }


        return dtReturn.Date;
    }
}