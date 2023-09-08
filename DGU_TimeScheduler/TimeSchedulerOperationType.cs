using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGUtility.TimeScheduler;

/// <summary>
/// 시간 스케줄러 동작 타입
/// </summary>
public enum TimeSchedulerOperationType
{
    /// <summary>
    /// 상태 없음
    /// </summary>
    None = 0,

    /// <summary>
    /// 정지
    /// </summary>
    Stop,
    /// <summary>
    /// 동작중
    /// </summary>
    Start,

    /// <summary>
    /// 일시 정지
    /// </summary>
    Pause,
}
