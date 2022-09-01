namespace Emes.Application.Entity;

/// <summary>
/// SN 物料追溯信息，包含关键物料和批次料。
/// </summary>
[SugarTable("pt_sn_material", "物料追溯信息表")]
[SugarIndex("index_pt_sn_material_sn", nameof(SN), OrderByType.Asc)]
[SugarIndex("index_pt_sn_material_barcode", nameof(Barcode), OrderByType.Asc)]
public sealed class PtSnMaterial : BizEntityBase
{
    /// <summary>
    /// SN
    /// </summary>
    [SugarColumn(ColumnDescription = "SN", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? SN { get; set; }

    /// <summary>
    /// Barcode
    /// </summary>
    [SugarColumn(ColumnDescription = "Barcode", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Barcode { get; set; }

    /// <summary>
    /// 物料属性。
    /// </summary>
    [SugarColumn(ColumnDescription = "产品物料属性")]
    public MaterialAttrEnum Attr { get; set; }

    /// <summary>
    /// 物料绑定状态
    /// </summary>
    [SugarColumn(ColumnDescription = "物料绑定状态")]
    public BindingEnum BindingStatus { get; set; } = BindingEnum.Bind;
}
