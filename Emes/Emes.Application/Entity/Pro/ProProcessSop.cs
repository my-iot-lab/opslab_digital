namespace Emes.Application.Entity;

/// <summary>
/// 产品SOP
/// </summary>
[SugarTable("pro_process_sop", "产品SOP表")]
public class ProProcessSop : BizEntityBase
{
    /// <summary>
    /// 产品 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产品 Id")]
    public long ProductId { get; set; }

    /// <summary>
    /// 工序 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工序 Id")]
    public long ProcessId { get; set; }

    /// <summary>
    /// SOP 标题
    /// </summary>
    [SugarColumn(ColumnDescription = "标题", Length = 128)]
    [Required, MaxLength(128)]
    [NotNull]
    public string? Title { get; set; }

    /// <summary>
    /// SOP 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 255)]
    [Required, MaxLength(255)]
    [NotNull]
    public string? Description { get; set; }

    /// <summary>
    /// SOP 资源地址
    /// </summary>
    [SugarColumn(ColumnDescription = "资源地址", Length = 255)]
    [Required, MaxLength(255)]
    [NotNull]
    public string? Url { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Order { get; set; }
}
