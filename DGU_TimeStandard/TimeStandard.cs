namespace DGUtility.TimeStandard;

/// <summary>
/// 시간 기준 유틸리티
/// </summary>
/// <remarks>
/// 0시를 기준으로 하루를 잡는것이라면 이 유틸을 사용하지 않아도 된다.<br />
/// 하루의 시작이 0시가 아니라면 (예> 9시)라면 8:59까지는 전날 날짜를 표시해야한다.<br />
/// 이럴때 날짜를 계산해주는 유틸이다.
/// </remarks>
public class TimeStandard
{
    /// <summary>
    /// 하루가 시작의 기준 시간
    /// </summary>
    public TimeSpan LoopTickCountResetTime { get; private set; }

    /// <summary>
    /// 기준 시간이 지나면 다음날 취급할지 여부
    /// </summary>
    /// <remarks>
    /// true : 기준 시간이 지나면 다음날로 취급한다.
    /// <para>false : 기준 시간 지나기 전까지는 전날로 취급한다.</para>
    /// </remarks>
    public bool NextDay { get; private set; } = false;


    /// <summary>
    /// 기준 시간 생성
    /// </summary>
    /// <param name="bNextDay">기준 시간이 지나면 다음날 취급할지 여부</param>
    public TimeStandard(bool bNextDay = false)
    {
        this.Reset(TimeSpan.Parse("00:00:00"), bNextDay);
    }

    /// <summary>
    /// 기준 시간을 지정하여 기준 시간 생성.
    /// </summary>
    /// <param name="timeLoopTickResetTime">하루가 시작의 기준 시간
    /// <para>DateTime를 사용하는 경우 : DateTime.TimeOfDay</para>
    /// <para>문자열을 사용하는 경우 : TimeSpan.Parse("00:00:00")</para></param>
    /// <param name="bNextDay">기준 시간이 지나면 다음날 취급할지 여부</param>
    public TimeStandard(TimeSpan timeLoopTickResetTime, bool bNextDay = false)
    {
        this.Reset(timeLoopTickResetTime, bNextDay);
    }

    /// <summary>
    /// 기준 정보를 다시 저장한다.
    /// </summary>
    /// <param name="timeLoopTickResetTime">하루가 시작의 기준 시간</param>
    /// <param name="bNextDay">기준 시간이 지나면 다음날 취급할지 여부</param>
    public void Reset(TimeSpan timeLoopTickResetTime, bool bNextDay = false)
    {
        //정보 저장
        this.LoopTickCountResetTime = timeLoopTickResetTime;
        this.NextDay = bNextDay;
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

        if(false == this.NextDay)
        {//전날 취급

            //대상의 오늘 간격받기
            if (dtTarget.TimeOfDay < this.LoopTickCountResetTime)
            {//대상의 오늘 간격이 LoopTickCountResetTime보다 작다.

                //전날로 취급해야 한다.
                dtReturn = dtReturn.AddDays(-1);
            }
        }
        else
        {//다음날 취급

            //대상의 오늘 간격받기
            if (dtTarget.TimeOfDay > this.LoopTickCountResetTime)
            {//대상의 오늘 간격이 LoopTickCountResetTime보다 크다.

                //다음날로 취급해야 한다.
                dtReturn = dtReturn.AddDays(1);
            }
        }
        

        return dtReturn.Date;
    }
}