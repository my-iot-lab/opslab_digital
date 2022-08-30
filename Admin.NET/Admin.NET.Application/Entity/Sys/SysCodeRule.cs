namespace Admin.NET.Application.Entity;

/// <summary>
/// 编码生成规则表
/// </summary>
[SugarTable("sys_code_rule", "编码生成规则表")]
public sealed class SysCodeRule : BizEntityBase
{
    /// <summary>
    /// 规则编码
    /// </summary>
    [SugarColumn(ColumnDescription = "规则编码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 规则名称
    /// </summary>
    [SugarColumn(ColumnDescription = "规则名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 规则描述
    /// </summary>
    [SugarColumn(ColumnDescription = "规则描述", Length = 255)]
    [MaxLength(255)]
    public string? Desc { get; set; }

    /// <summary>
    /// 最大长度
    /// </summary>
    [SugarColumn(ColumnDescription = "最大长度")]
    public int? MaxLength { get; set; }

    /// <summary>
    /// 是否补齐
    /// </summary>
    [SugarColumn(ColumnDescription = "是否补齐")]
    public bool IsPadded { get; set; }

    /// <summary>
    /// 补齐字符
    /// </summary>
    [SugarColumn(ColumnDescription = "补齐字符", Length = 1)]
    [MaxLength(1)]
    public string? PaddedChar { get; set; }

    /// <summary>
    /// 补齐方式, L=>左边补齐; R=>右边补齐
    /// </summary>
    [SugarColumn(ColumnDescription = "补齐方式", Length = 1)]
    [MaxLength(1)]
    public string? PaddedMethod { get; set; } = "L";

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; } = StatusEnum.Enable;
}
