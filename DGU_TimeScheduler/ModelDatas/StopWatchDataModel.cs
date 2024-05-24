
namespace DGU_TimeScheduler.ModelDatas;


/// <summary>
/// 간격 이벤트 데이터모델
/// <para>지정된 간격만큼 반복해서 동작할 액션에 대한 데이터모델</para>
/// <para>간격과 액션을 지정한다.</para>
/// </summary>
public class StopWatchDataModel
{
    /// <summary>
    /// 이 개체를 구분하기위한 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 이벤트를 일으킬 간격(s)
    /// <para>TimeScheduler가 실행되는 시점을 0으로 두고 동작한다.</para>
    /// <para>TimeScheduler.TodayStandard가 변경되면 LoopCount가 초기화된다.<br />
    /// 이로인해 반복 간격이 달라질 수 있음을 명심해야 한다.</para>
    /// </summary>
    /// <remarks>
    /// TimeScheduler는 1초에 한번씩 동작한다
    /// <para>1 = 1초</para>
    /// <para>60 = 1분</para>
    /// <para>1800 = 30분</para>
    /// <para>3600 = 1시간</para>
    /// </remarks>
    public int TickCount { get; set; }

    /// <summary>
    /// TickCount에 의해 이벤트 발생 타이밍이 되었을 때 동작할 액션
    /// <para>= (nNowLoopTickCount, nThisTickCount) => { }</para>
    /// <para>nNowLoopTickCount : TimeScheduler가 지금 가지고 있는 LoopTickCount</para>
    /// <para>nThisTickCount : 이벤트를 일으킬 간격. TickCount와 동일하다.</para>
    /// </summary>
    public Action<int, int> Action { get; set; }
        = (nNowLoopTickCount, nThisTickCount) => { };
}
