namespace Admin.NET.Application.Entity;

/// <summary>
/// 编码生成规则组成表
/// </summary>
[SugarTable("sys_code_part", "编码生成规则组成表")]
public sealed class SysCodePart : BizEntityBase
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
    /// 分段序号
    /// </summary>
    [SugarColumn(ColumnDescription = "分段序号")]
    public int Seq { get; set; }

    /// <summary>
    /// 分段类型，INPUTCHAR：输入字符，NOWDATE：当前日期时间，FIXCHAR：固定字符，SERIALNO：流水号。
    /// </summary>
    [SugarColumn(ColumnDescription = "规则名称", Length = 16)]
    [Required, MaxLength(16)]
    [NotNull]
    public string? PartType { get; set; }

    /// <summary>
    /// 分段编号
    /// </summary>
    [SugarColumn(ColumnDescription = "分段编号", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 分段名称
    /// </summary>
    [SugarColumn(ColumnDescription = "分段名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 分段长度
    /// </summary>
    [SugarColumn(ColumnDescription = "分段长度")]
    public int PartLength { get; set; }

    /// <summary>
    /// 输入字符
    /// </summary>
    [SugarColumn(ColumnDescription = "输入字符", Length = 64)]
    [MaxLength(64)]
    public string? InputChar { get; set; }

    /// <summary>
    /// 固定字符
    /// </summary>
    [SugarColumn(ColumnDescription = "固定字符", Length = 64)]
    [MaxLength(64)]
    public string? FixCharacter { get; set; }

    /// <summary>
    /// 流水号起始值
    /// </summary>
    [SugarColumn(ColumnDescription = "流水号起始值")]
    public int? SerialStartNo { get; set; }

    /// <summary>
    /// 流水号步长
    /// </summary>
    [SugarColumn(ColumnDescription = "流水号步长")]
    public int? SerialStep { get; set; }

    /// <summary>
    /// 流水号当前值
    /// </summary>
    [SugarColumn(ColumnDescription = "流水号当前值")]
    public int? SerialNowNo { get; set; }

    /// <summary>
    /// 流水号是否循环
    /// </summary>
    [SugarColumn(ColumnDescription = "流水号是否循环")]
    public bool? IsCycle { get; set; }

    /// <summary>
    /// 循环方式，YEAR：按年，MONTH：按月，DAY：按天，HOUR：按小时，MINITE：按分钟，OTHER：按传入字符变。
    /// </summary>
    [SugarColumn(ColumnDescription = "循环方式", Length = 16)]
    [MaxLength(16)]
    public string? CycleMethod { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 255)]
    [MaxLength(255)]
    public string? Remark { get; set; }
}
