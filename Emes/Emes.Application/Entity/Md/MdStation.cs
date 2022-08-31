namespace Emes.Application.Entity;

/// <summary>
/// 工站信息
/// </summary>
[SugarTable("md_station", "工站信息表")]
public class MdStation : BizEntityBase
{
    /// <summary>
    /// 产线 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产线 Id")]
    public long LineId { get; set; }

    /// <summary>
    /// 产线
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(LineId))]
    public MdLine? Line { get; set; }

    /// <summary>
    /// 工站编码
    /// </summary>
    [SugarColumn(ColumnDescription = "工站编码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 工站名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 工站类型
    /// </summary>
    [SugarColumn(ColumnDescription = "类型")]
    public StationTypeEnum Type { get; set; } = StationTypeEnum.Assembly;

    /// <summary>
    /// 工站运行状态
    /// </summary>
    [SugarColumn(ColumnDescription = "运行状态")]
    public RunningStatusEnum RunningStatus { get; set; }

    /// <summary>
    /// 工站状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; } = StatusEnum.Enable;
}
