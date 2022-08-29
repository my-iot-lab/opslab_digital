namespace Admin.NET.Application.Entity;

/// <summary>
/// 警报记录
/// </summary>
[SugarTable("ops_alarm_record", "警报记录表")]
public class AlarmRecord : BizEntityBaseId
{
    /// <summary>
    /// 产线
    /// </summary>
    [SugarColumn(ColumnDescription = "产线", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Line { get; set; }

    /// <summary>
    /// 工站
    /// </summary>
    [SugarColumn(ColumnDescription = "工站", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Station { get; set; }

    /// <summary>
    /// 分类
    /// </summary>
    [SugarColumn(ColumnDescription = "分类", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Category { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 64)]
    [MaxLength(64)]
    public string? Descirption { get; set; }

    /// <summary>
    /// 警报时间
    /// </summary>
    [SugarColumn(ColumnDescription = "警报时间")]
    public DateTime CreatedAt { get; set; }
}
