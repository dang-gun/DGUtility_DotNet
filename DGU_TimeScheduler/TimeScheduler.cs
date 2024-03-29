﻿namespace DGUtility.TimeScheduler;

/// <summary>
/// 시간 스케줄러.
/// 1틱 == 1초
/// </summary>
public class TimeScheduler
{
    #region 외부에서 연결할 이벤트
    /// <summary>
    /// 시간 스케줄러 대리자
    /// </summary>
    public delegate void TimeSchedulerDelegate();

    /// <summary>
    /// 1초 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On1Second;
    /// <summary>
    /// 1초 이벤트 호출
    /// </summary>
    public void Occur1SecondCall()
    {
        if (On1Second != null)
        {
            On1Second();
        }
    }

    /// <summary>
    /// 10초 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On10Second;
    /// <summary>
    /// 10초 이벤트 호출
    /// </summary>
    public void Occur10SecondCall()
    {
        if (On10Second != null)
        {
            On10Second();
        }
    }

    /// <summary>
    /// 30초 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On30Second;
    /// <summary>
    /// 30초 이벤트 호출
    /// </summary>
    public void Occur30SecondCall()
    {
        if (On30Second != null)
        {
            On30Second();
        }
    }

    /// <summary>
    /// 1분 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On1Minute;
    /// <summary>
    /// 1분 이벤트 호출
    /// </summary>
    public void Occur1MinuteCall()
    {
        if (On1Minute != null)
        {
            On1Minute();
        }
    }

    /// <summary>
    /// 10분 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On10Minute;
    /// <summary>
    /// 10분 이벤트 호출
    /// </summary>
    public void Occur10MinuteCall()
    {
        if (On10Minute != null)
        {
            On10Minute();
        }
    }

    /// <summary>
    /// 30분 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On30Minute;
    /// <summary>
    /// 30분 이벤트 호출
    /// </summary>
    public void Occur30MinuteCall()
    {
        if (On30Minute != null)
        {
            On30Minute();
        }
    }

    /// <summary>
    /// 1시간 마다 발생하는 이벤트
    /// </summary>
    public event TimeSchedulerDelegate? On1Hour;
    /// <summary>
    /// 1시간 이벤트 호출
    /// </summary>
    public void Occur1HourCall()
    {
        if (On1Hour != null)
        {
            On1Hour();
        }
    }

    /// <summary>
    /// 날짜 변경 이벤트
    /// </summary>
    /// <remarks>
    /// On1Day와 달리 이 이벤트는 컴퓨터의 날짜가 바뀌면 발생한다.<br />
    /// 기준 날짜를 기준으로 변경되는 이벤트는 On1Day를 사용해야 한다.
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
    /// 기준 날짜가 변경되면 발생한다.
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
    /// 이 타이머의 인터벌이 1틱이 된다.
    /// </summary>
    private System.Timers.Timer? m_Timer_1LoopTick;


    /// <summary>
    /// 지금 동작 상태
    /// </summary>
    public TimeSchedulerOperationType TimeSchedulerOperationType { get; private set; }

    /// <summary>
    /// 1루프틱에 걸리는 시간(Millisecond).
    /// 1000 이하.
    /// </summary>
    /// <remarks>
    /// 디폴트 설정은 1000ms(1초)이다.
    /// </remarks>
    public int LoopTick { get; private set; } = 1000;

    /// <summary>
    /// 누적된 루프 기준 틱카운트.
    /// </summary>
    /// <remarks>
    /// 리셋시간(LoopTickCountResetTime)을 기준으로 0이된다.
    /// </remarks>
    public int LoopTickCount { get; private set; }

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
    public TimeSpan LoopTickCountResetTime { get; private set; }



    /// <summary>
    /// 시간 스케줄러 생성
    /// </summary>
    public TimeScheduler()
    {
        this.Reset(TimeSpan.Parse("00:00:00"));
    }

    /// <summary>
    /// 시간 스케줄러 생성.
    /// </summary>
    /// <param name="timeLoopTickResetTime">루프틱 리셋 기준시간</param>
    public TimeScheduler(TimeSpan timeLoopTickResetTime)
    {
        this.Reset(timeLoopTickResetTime);
    }

    /// <summary>
    /// 리셋
    /// </summary>
    /// <param name="timeLoopTickResetTime">루프틱 리셋 기준시간</param>
    private void Reset(TimeSpan timeLoopTickResetTime)
    {
        //정보 저장
        this.LoopTickCountResetTime = timeLoopTickResetTime;

        //동작 상태 초기화
        this.TimeSchedulerOperationType = TimeSchedulerOperationType.Stop;

        //오늘 날짜 저장 *************************************
        this.Today = DateTime.Now.Date;

        //1 게임틱 타이머 ***************************************
        this.m_Timer_1LoopTick = new System.Timers.Timer();
        this.m_Timer_1LoopTick.Stop();
        //1 게임틱당 시간
        this.m_Timer_1LoopTick.Interval = this.LoopTick;
        this.m_Timer_1LoopTick.Elapsed -= M_Timer_1LoopTick_Elapsed;
        this.m_Timer_1LoopTick.Elapsed += M_Timer_1LoopTick_Elapsed;


        //지금 기준날짜 입력 **********************
        DateTime dtNow = DateTime.Now;
        DateTime dtNowDate = dtNow.Date;
        TimeSpan timeNow = dtNow.TimeOfDay;

        //기준 시간이 됐는지
        if ((dtNowDate > this.TodayStandard)
            && (timeNow > this.LoopTickCountResetTime))
        {//날짜가 다음 날짜이고
         //시간이 지정된 시간 이후다.

            //루프카운트 초기화
            this.LoopTickCount = 0;
            //기준 날짜 변경
            this.TodayStandard = dtNowDate.Date;
        }
        else
        {//기준 시간이 지나지 않았다.

            //기준 날짜에 전날 날짜를 넣어준다.
            this.TodayStandard = dtNowDate.Date.AddDays(-1);
        }
    }


    /// <summary>
    /// 틱마다 동작할 내용
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void M_Timer_1LoopTick_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        DateTime dtNow = DateTime.Now;
        DateTime dtNowDate = dtNow.Date;
        TimeSpan timeNow = dtNow.TimeOfDay;

        //1틱 처리 내용
        ++this.LoopTickCount;


        //1초 이벤트
        this.Occur1SecondCall();

        //10초 이벤트
        if (0 == (this.LoopTickCount % 10))
        {
            this.Occur10SecondCall();
        }

        //30초 이벤트
        if (0 == (this.LoopTickCount % 30))
        {
            this.Occur30SecondCall();
        }

        //1분 이벤트
        if (0 == (this.LoopTickCount % 60))
        {
            this.Occur1MinuteCall();
        }

        //10분 이벤트
        if (0 == (this.LoopTickCount % (60 * 10)))
        {
            this.Occur10MinuteCall();
        }

        //30분 이벤트
        if (0 == (this.LoopTickCount % (60 * 30)))
        {
            this.Occur30MinuteCall();
        }

        //1시간 이벤트
        if (0 == (this.LoopTickCount % (60 * 60)))
        {
            this.Occur1HourCall();
        }

        //하루 이벤트
        if (dtNowDate > this.Today)
        {//날짜가 다음 날짜가 됨

            //날짜 리셋
            this.Today = dtNowDate.Date;
            //날짜 변경을 알림
            On1DayCall();
        }

        //기준 시간이 됐는지
        if ((dtNowDate > this.TodayStandard)
            && (timeNow > this.LoopTickCountResetTime))
        {//날짜가 다음 날짜이고
         //시간이 지정된 시간 이후다.

            //루프카운트 초기화
            this.LoopTickCount = 0;
            //기준 날짜 변경
            this.TodayStandard = dtNowDate.Date;

            //기준 시간이 변경됐음을 알림
            this.On1DayStandardCall();
        }
    }


    /// <summary>
    /// 스케줄러 시작
    /// </summary>
    public void Start()
    {
        this.m_Timer_1LoopTick!.Start();
    }

    /// <summary>
    /// 스케줄러 정지.
    /// 기준 시간과 카운터도 초기화된다.
    /// </summary>
    public void Stop()
    {
        DateTime dtNow = DateTime.Now;
        DateTime dtNowDate = dtNow.Date;

        this.m_Timer_1LoopTick!.Stop();

        //루프카운트 초기화
        this.LoopTickCount = 0;
        //날짜 리셋
        this.Today = dtNowDate;
    }

    /// <summary>
    /// 스케줄러 일시 정지
    /// </summary>
    public void Pause()
    {
        this.m_Timer_1LoopTick!.Stop();
    }



    /// <summary>
    /// 지정된 날짜의 기준 날짜를 리턴한다.
    /// </summary>
    /// <remarks>
    /// 지정된 날짜의 기준 날짜가 전날인지 오늘인지를 계산하여 리턴한다.<br />
    /// 지정된 날짜의 시간이 0시이후인데 
    /// LoopTickCountResetTime 시간전이라면 전날 날짜를 주게 된다.<br />
    /// 시간은 어떻게 처리할지 각자 알아서 해야 한다.
    /// </remarks>
    /// <param name="dtTarget"></param>
    /// <returns>년,월,일 만 리턴됨 </returns>
    public DateTime DateToStandard(DateTime dtTarget)
    {
        DateTime dtReturn = new DateTime(
                            dtTarget.Year
                            , dtTarget.Month
                            , dtTarget.Day);

        //대상의 오늘 간격받기
        if (dtTarget.TimeOfDay < this.LoopTickCountResetTime)
        {//대상의 오늘 간격이 LoopTickCountResetTime보다 작다.

            //전날로 취급해야 한다.
            dtReturn = dtReturn.AddDays(-1);
        }


        return dtReturn.Date;
    }
}