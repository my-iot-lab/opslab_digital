namespace Emes.Application.Entity;

/// <summary>
/// 班组信息
/// </summary>
[SugarTable("cal_team", "班组信息表")]
public sealed class CalTeam : BizEntityBase
{
    /// <summary>
    /// 班组编号
    /// </summary>
    [SugarColumn(ColumnDescription = "班组编号", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 班组名称
    /// </summary>
    [SugarColumn(ColumnDescription = "班组名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 班组类型
    /// </summary>
    [SugarColumn(ColumnDescription = "班组类型", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? CalendarType { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 255)]
    [MaxLength(255)]
    public string? Remeark { get; set; }
}
