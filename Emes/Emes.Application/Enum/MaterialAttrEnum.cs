namespace Emes.Application.Enum;

/// <summary>
/// 物料属性枚举。
/// </summary>
public enum MaterialAttrEnum
{
    /// <summary>
    /// 成品。
    /// <para>成品表示该物料是某种产品。</para>
    /// </summary>
    [Description("成品")]
    FinishedProduct = 1,

    /// <summary>
    /// 关键物料。
    /// </summary>
    [Description("物料")]
    Critical = 2,

    /// <summary>
    /// 原辅料（批次料）。
    /// </summary>
    [Description("原辅料")]
    Batch = 3,
}
