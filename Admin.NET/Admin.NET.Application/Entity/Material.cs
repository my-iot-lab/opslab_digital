namespace Admin.NET.Application.Entity;

/// <summary>
/// 物料信息主数据
/// </summary>
[SugarTable("ops_master_material", "物料信息表")]
public class Material : BizEntityBase
{
    /// <summary>
    /// 物料代码
    /// </summary>
    [SugarColumn(ColumnDescription = "物料代码", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 物料名称
    /// </summary>
    [SugarColumn(ColumnDescription = "物料名称", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    [SugarColumn(ColumnDescription = "规格型号", Length = 32)]
    [MaxLength(32)]
    public string? Model { get; set; }

    /// <summary>
    /// 物料属性，如 成品、半成品、原材料
    /// </summary>
    [SugarColumn(ColumnDescription = "物料属性")]
    public MaterialAttrEnum Attr { get; set; }

    /// <summary>
    /// 计量单位
    /// </summary>
    [SugarColumn(ColumnDescription = "计量单位", Length = 16)]
    [MaxLength(16)]
    public string? Unit { get; set; }

    /// <summary>
    /// 条码规则，多种以逗号分隔
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
