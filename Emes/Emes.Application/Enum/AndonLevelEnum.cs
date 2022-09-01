namespace Emes.Application.Enum;

/// <summary>
/// 安灯等级枚举
/// </summary>
public enum AndonLevelEnum
{
    /// <summary>
    /// 警告
    /// </summary>
    [Description("警告")]
    Warn = 1,

    /// <summary>
    /// 异常
    /// </summary>
    [Description("异常")]
    Error,

    /// <summary>
    /// 急停
    /// </summary>
    [Description("急停")]
    Critical,
}
