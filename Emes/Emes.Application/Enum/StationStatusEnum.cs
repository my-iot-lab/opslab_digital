namespace Emes.Application;

/// <summary>
/// 运行状态枚举
/// </summary>
public enum RunningStatusEnum
{
    /// <summary>
    /// 运行中
    /// </summary>
    [Description("运行中")]
    Running = 1,

    /// <summary>
    /// 空闲
    /// </summary>
    [Description("空闲")]
    Idle = 2,

    /// <summary>
    /// 已离线
    /// </summary>
    [Description("已离线")]
    Down = 3,
}
