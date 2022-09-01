namespace Emes.Application.Entity;

/// <summary>
/// 工艺参数信息
/// </summary>
[SugarTable("proc_process_param", "工艺参数表")]
public class ProcProcessParameter : BizEntityBase
{
    /// <summary>
    /// 工序 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工序Id")]
    public long ProcessId { get; set; }

    /// <summary>
    /// 工序
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(ProcessId))]
    public ProcProcess? Process { get; set; }

    /// <summary>
    /// 标签。
    /// <para>若源于 PLC，需与 PLC Tag 一致。对于数组可重复。</para>
    /// </summary>
    [SugarColumn(ColumnDescription = "标签", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Tag { get; set; }

    /// <summary>
    /// 参数名称。
    /// <para>对于数组可重复。</para>
    /// </summary>
    [SugarColumn(ColumnDescription = "参数名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 序号。
    /// <para>仅用于值为数组的标签，大于 0 表示为数组。</para>
    /// </summary>
    [SugarColumn(ColumnDescription = "序号")]
    public int Seq { get; set; }

    /// <summary>
    /// 数据类型
    /// </summary>
    [SugarColumn(ColumnDescription = "数据类型")]
    public VariableType DataType { get; set; }

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
