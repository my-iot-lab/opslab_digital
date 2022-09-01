namespace Emes.Application.Entity;

/// <summary>
/// SN 当前过站状态。
/// </summary>
[SugarTable("pt_sn_transit", "SN当前过站状态表")]
[SugarIndex("index_pt_sn_transit_sn", nameof(SN), OrderByType.Asc)]
public sealed class PtSnTransit : BizEntityBaseId
{
    /// <summary>
    /// SN
    /// </summary>
    [SugarColumn(ColumnDescription = "SN", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? SN { get; set; }

    /// <summary>
    /// 工单号
    /// <para>工单可以不存在。</para>
    /// </summary>
    [SugarColumn(ColumnDescription = "工单号", Length = 64)]
    [MaxLength(64)]
    public string? WO { get; set; }

    /// <summary>
    /// 工站 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工站 Id")]
    public long StationId { get; set; }

    /// <summary>
    /// 工站
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(StationId))]
    public MdStation? Station { get; set; }

    /// <summary>
    /// 工站代码
    /// </summary>
    [SugarColumn(ColumnDescription = "工站代码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? StationCode { get; set; }

    /// <summary>
    /// 过站状态
    /// </summary>
    [SugarColumn(ColumnDescription = "过站状态")]
    public PassEnum Pass { get; set; }

    /// <summary>
    /// 记录时间
    /// </summary>
    [SugarColumn(ColumnDescription = "记录时间")]
    public DateTime CreateTime { get; set; }
}
