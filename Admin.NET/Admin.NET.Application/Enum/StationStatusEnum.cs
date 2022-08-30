namespace Admin.NET.Application.Enum;

/// <summary>
/// 运行状态枚举
/// </summary>
public enum RunningStatusEnum
{
    [Description("运行中")]
    Running = 1,

    [Description("已离线")]
    Offline = 2,
}
