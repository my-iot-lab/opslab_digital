namespace Admin.NET.Application.Entity;

/// <summary>
/// 出站存档明细项数组值明细信息
/// </summary>
[SugarTable("pt_archive_item_line", "出站存档明细项数组值明细信息表")]
public class PtArchiveItemLine : BizEntityBaseId
{
    /// <summary>
    /// 产品数据存档明细明细信息 Id。
    /// </summary>
    [SugarColumn(ColumnDescription = "产品数据存档明细信息Id")]
    public long ArchiveItemId { get; set; }

    /// <summary>
    /// 序号
    /// </summary>
    [SugarColumn(ColumnDescription = "序号")]
    public int Seq { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    [SugarColumn(ColumnDescription = "值", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Value { get; set; }

    /// <summary>
    /// 上限值
    /// </summary>
    [SugarColumn(ColumnDescription = "上限值", Length = 12, DecimalDigits = 2)]
    public decimal? Higher { get; set; }

    /// <summary>
    /// 下限值
    /// </summary>
    [SugarColumn(ColumnDescription = "下限值", Length = 12, DecimalDigits = 2)]
    public decimal? Lower { get; set; }
}
