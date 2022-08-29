namespace Admin.NET.Application.Enum;

/// <summary>
/// 物料属性枚举
/// </summary>
public enum MaterialAttrEnum
{
    /// <summary>
    /// 成品
    /// </summary>
    [Description("成品")]
    FinishedProduct = 1,

    /// <summary>
    /// 半成品
    /// </summary>
    [Description("半成品")]
    SemifinishedProduct = 2,

    /// <summary>
    /// 原材料
    /// </summary>
    [Description("原材料")]
    RawMaterial = 3,
}
