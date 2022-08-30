namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品数据出站/存档信息
/// </summary>
[SugarTable("pt_archive", "产品数据出站存档信息表")]
public class PtArchive : BizEntityBaseId
{
    /// <summary>
    /// 产线
    /// </summary>
    [SugarColumn(ColumnDescription = "产线", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Line { get; set; }

    /// <summary>
    /// 工站
    /// </summary>
    [SugarColumn(ColumnDescription = "工站", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Station { get; set; }

    /// <summary>
    /// 物料号
    /// </summary>
    [SugarColumn(ColumnDescription = "物料号", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? ProductCode { get; set; }

    /// <summary>
    /// 工单
    /// </summary>
    [SugarColumn(ColumnDescription = "工单", Length = 64)]
    [MaxLength(64)]
    public string? WO { get; set; }

    /// <summary>
    /// SN
    /// </summary>
    [SugarColumn(ColumnDescription = "SN", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? SN { get; set; }

    /// <summary>
    /// 程序配方号
    /// </summary>
    [SugarColumn(ColumnDescription = "程序配方号")]
    public int Formual { get; set; }

    /// <summary>
    /// 过站状态
    /// </summary>
    [SugarColumn(ColumnDescription = "过站状态")]
    public PassEnum Pass { get; set; }

    /// <summary>
    /// CT 时长
    /// </summary>
    [SugarColumn(ColumnDescription = "CT 时长")]
    public int? Cycletime { get; set; }

    /// <summary>
    /// 操作人
    /// </summary>
    [SugarColumn(ColumnDescription = "操作人", Length = 32)]
    [MaxLength(32)]
    public string? Operator { get; set; }

    /// <summary>
    /// 班次
    /// </summary>
    [SugarColumn(ColumnDescription = "班次", Length = 16)]
    [MaxLength(16)]
    public string? Shift { get; set; }

    /// <summary>
    /// 托盘号
    /// </summary>
    [SugarColumn(ColumnDescription = "托盘号", Length = 32)]
    [MaxLength(32)]
    public string? Pallet { get; set; }

    /// <summary>
    /// 存档时间
    /// </summary>
    [SugarColumn(ColumnDescription = "存档时间")]
    public DateTime CreatedAt { get; set; }
}
