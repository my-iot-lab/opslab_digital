namespace Emes.Application.Entity;

/// <summary>
/// 产线信息
/// </summary>
[SugarTable("md_line", "产线信息表")]
public sealed class MdLine : BizEntityBase
{
    /// <summary>
    /// 工站编码
    /// </summary>
    [SugarColumn(ColumnDescription = "产线编码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 工站名称
    /// </summary>
    [SugarColumn(ColumnDescription = "产线名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 产线状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; } = StatusEnum.Enable;

    /// <summary>
    /// 工站集合
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(MdStation.LineId))]
    public List<MdStation>? Stations { get; set; }
}
