namespace Emes.Application.Entity;

/// <summary>
/// 工艺参数信息
/// </summary>
[SugarTable("pro_process_param", "工艺参数表")]
public class ProProcessParameter : BizEntityBase
{
    /// <summary>
    /// 工序 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工序 Id")]
    public long ProcessId { get; set; }

    /// <summary>
    /// 工序
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(ProcessId))]
    public ProProcess? Process { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    [SugarColumn(ColumnDescription = "标签", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Tag { get; set; }

    /// <summary>
    /// 参数名称，对于数组可重复。
    /// </summary>
    [SugarColumn(ColumnDescription = "参数名称", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 序号，对于数组有序号。
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Seq { get; set; }

    /// <summary>
    /// 数据类型
    /// </summary>
    [SugarColumn(ColumnDescription = "数据类型")]
    public int DataType { get; set; }

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
