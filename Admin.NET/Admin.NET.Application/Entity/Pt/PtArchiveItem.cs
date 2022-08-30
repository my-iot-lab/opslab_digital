namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品数据出站/存档明细信息
/// </summary>
[SugarTable("pt_archive_item", "产品数据出站存档明细信息表")]
public class PtArchiveItem : BizEntityBaseId
{
    /// <summary>
    /// 产品数据存档信息 Id。
    /// </summary>
    [SugarColumn(ColumnDescription = "产品数据存档信息Id")]
    public long ArchiveId { get; set; }

    /// <summary>
    /// 产品数据存档信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public PtArchive? Archive { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    [SugarColumn(ColumnDescription = "标签", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Tag { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    [SugarColumn(ColumnDescription = "值", Length = 1024)]
    [Required, MaxLength(1024)]
    [NotNull]
    public string? Value { get; set; }

    /// <summary>
    /// 值是否是数组
    /// </summary>
    [SugarColumn(ColumnDescription = "值是否是数组")]
    public bool IsArray { get; set; }

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
