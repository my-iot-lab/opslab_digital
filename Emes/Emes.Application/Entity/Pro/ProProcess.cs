namespace Emes.Application.Entity;

/// <summary>
/// 生产工序
/// </summary>
[SugarTable("pro_process", "生产工序表")]
public sealed class ProProcess : BizEntityBase
{
    /// <summary>
    /// 工序编码
    /// </summary>
    [SugarColumn(ColumnDescription = "工序编码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 工序名称
    /// </summary>
    [SugarColumn(ColumnDescription = "工序名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 255)]
    [MaxLength(255)]
    public string? Remark { get; set; }

    /// <summary>
    /// 工序状态
    /// </summary>
    [SugarColumn(ColumnDescription = "工序名称")]
    public StatusEnum Status { get; set; } = StatusEnum.Enable;

    /// <summary>
    /// 工序参数集合
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(ProProcessParameter.ProcessId))]
    public List<ProProcessParameter>? ProcessParameters { get; set; }
}
