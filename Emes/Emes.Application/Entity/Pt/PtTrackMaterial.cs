namespace Emes.Application.Entity;

/// <summary>
/// 关键物料追溯信息。
/// </summary>
[SugarTable("pt_track_material", "关键物料追溯信息表")]
[SugarIndex("index_pt_track_material_sn", nameof(SN), OrderByType.Asc)]
[SugarIndex("index_pt_track_material_barcode", nameof(Barcode), OrderByType.Asc)]
public sealed class PtTrackMaterial : BizEntityBaseId
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
    /// <para>每个 SN 绑定状态的 Barcorde 是唯一的。</para>
    /// </summary>
    [SugarColumn(ColumnDescription = "Barcode", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Barcode { get; set; }

    /// <summary>
    /// 物料绑定状态
    /// </summary>
    [SugarColumn(ColumnDescription = "物料绑定状态")]
    public BindingEnum BindingStatus { get; set; } = BindingEnum.Bind;

    /// <summary>
    /// 扫码时间
    /// </summary>
    [SugarColumn(ColumnDescription = "扫码时间")]
    public DateTime CreateTime { get; set; }
}
