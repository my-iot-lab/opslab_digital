namespace Admin.NET.Application.Enum;

/// <summary>
/// 工站类型枚举
/// </summary>
public enum StationTypeEnum
{
    /// <summary>
    /// 装配站
    /// </summary>
    [Description("装配")]
    Assembly = 1,

    /// <summary>
    /// 检测站
    /// </summary>
    [Description("检测")]
    Detect = 2,
}
