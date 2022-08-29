namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品进站信息
/// </summary>
[SugarTable("ops_inbound", "产品进站信息表")]
public class Inbound : BizEntityBaseId
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
    /// 工单
    /// </summary>
    [SugarColumn(ColumnDescription = "工单", Length = 64)]
    [MaxLength(64)]
    public string? WO { get; set; }

    /// <summary>
    /// SN
    /// </summary>
    [SugarColumn(ColumnDescription = "SN", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? SN { get; set; }

    /// <summary>
    /// 程序配方号
    /// </summary>
    [SugarColumn(ColumnDescription = "程序配方号")]
    public int Formual { get; set; }

    /// <summary>
    /// 进站时间
    /// </summary>
    [SugarColumn(ColumnDescription = "进站时间")]
    public DateTime CreatedAt { get; set; }
}
