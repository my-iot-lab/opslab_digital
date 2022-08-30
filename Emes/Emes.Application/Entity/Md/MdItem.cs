namespace Emes.Application.Entity;

/// <summary>
/// 产品/物料信息
/// </summary>
[SugarTable("md_item", "物料产品表")]
public sealed class MdItem : BizEntityBase
{
    /// <summary>
    /// 产品/物料代码
    /// </summary>
    [SugarColumn(ColumnDescription = "产品物料代码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 产品/物料名称
    /// </summary>
    [SugarColumn(ColumnDescription = "产品物料名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    [SugarColumn(ColumnDescription = "规格型号", Length = 128)]
    [MaxLength(128)]
    public string? Spec { get; set; }

    /// <summary>
    /// 物料属性，如 产品、物料。
    /// </summary>
    [SugarColumn(ColumnDescription = "产品物料属性")]
    public MaterialAttrEnum Attr { get; set; }

    /// <summary>
    /// 计量单位
    /// </summary>
    [SugarColumn(ColumnDescription = "计量单位", Length = 16)]
    [MaxLength(16)]
    public string? Unit { get; set; }

    /// <summary>
    /// 条码规则，多个以逗号分隔。
    /// </summary>
    [SugarColumn(ColumnDescription = "条码规则", Length = 512)]
    [Required, MaxLength(512)]
    [NotNull]
    public string? BarcodeRule { get; set; }

    /// <summary>
    /// 保质期
    /// </summary>
    [SugarColumn(ColumnDescription = "保质期")]
    public int? Expiration { get; set; }

    /// <summary>
    /// 版本
    /// </summary>
    [SugarColumn(ColumnDescription = "版本")]
    public int Version { get; set; }
}
