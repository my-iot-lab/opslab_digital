namespace Emes.Application.Entity;

/// <summary>
/// 能耗记录
/// </summary>
[SugarTable("ops_energy_record", "能耗记录表")]
public class EnergyRecord : BizEntityBaseId
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
    /// 能耗值
    /// </summary>
    [SugarColumn(ColumnDescription = "能耗值", Length = 12, DecimalDigits = 2)]
    public decimal Value { get; set; }

    /// <summary>
    /// 记录时间
    /// </summary>
    [SugarColumn(ColumnDescription = "记录时间")]
    public DateTime CreatedAt { get; set; }
}
