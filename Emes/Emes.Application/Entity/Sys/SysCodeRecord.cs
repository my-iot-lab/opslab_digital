namespace Emes.Application.Entity;

/// <summary>
/// 编码生成记录表
/// </summary>
[SugarTable("sys_code_record", "编码生成记录表")]
public sealed class SysCodeRecord : BizEntityBase
{
    /// <summary>
    /// 规则ID
    /// </summary>
    [SugarColumn(ColumnDescription = "规则ID")]
    public long RuleId { get; set; }

    /// <summary>
    /// 代码生成规则
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public SysCodeRule? CodeRule { get; set; }

    /// <summary>
    /// 生成日期时间
    /// </summary>
    [SugarColumn(ColumnDescription = "生成日期时间")]
    public DateTime GenDate { get; set; }

    /// <summary>
    /// 最后产生的序号
    /// </summary>
    [SugarColumn(ColumnDescription = "最后产生的序号")]
    public int? GenIndex { get; set; }

    /// <summary>
    /// 最后产生的值
    /// </summary>
    [SugarColumn(ColumnDescription = "最后产生的值", Length = 64)]
    [MaxLength(64)]
    public string? LastResult { get; set; }

    /// <summary>
    /// 最后产生的流水号
    /// </summary>
    [SugarColumn(ColumnDescription = "最后产生的流水号")]
    public int? SerialNo { get; set; }

    /// <summary>
    /// 最后传入的参数
    /// </summary>
    [SugarColumn(ColumnDescription = "最后传入的参数", Length = 64)]
    [MaxLength(64)]
    public string? LastInputChar { get; set; }
}
