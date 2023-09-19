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
    /// 기준 시간 생성
    /// </summary>
    public TimeStandard()
    {
        this.Reset(TimeSpan.Parse("00:00:00"));
    }

    /// <summary>
    /// 기준 시간을 지정하여 기준 시간 생성.
    /// </summary>
    /// <param name="timeLoopTickResetTime">하루가 시작의 기준 시간</param>
    public TimeStandard(TimeSpan timeLoopTickResetTime)
    {
        this.Reset(timeLoopTickResetTime);
    }

    /// <summary>
    /// 리셋
    /// </summary>
    /// <param name="timeLoopTickResetTime">하루가 시작의 기준 시간</param>
    private void Reset(TimeSpan timeLoopTickResetTime)
    {
        //정보 저장
        this.LoopTickCountResetTime = timeLoopTickResetTime;
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