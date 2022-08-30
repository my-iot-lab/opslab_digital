namespace Emes.Application.Entity;

/// <summary>
/// 仓库
/// </summary>
[SugarTable("wm_warehouse", "仓库表")]
public class WmWarehouse : BizEntityBase
{
    /// <summary>
    /// 仓库编码
    /// </summary>
    [SugarColumn(ColumnDescription = "仓库编码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 仓库名称
    /// </summary>
    [SugarColumn(ColumnDescription = "仓库名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 位置
    /// </summary>
    [SugarColumn(ColumnDescription = "位置", Length = 128)]
    [MaxLength(128)]
    public string? Location { get; set; }

    /// <summary>
    /// 责任人
    /// </summary>
    [SugarColumn(ColumnDescription = "责任人", Length = 64)]
    [MaxLength(64)]
    public string? Charge { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 255)]
    [MaxLength(255)]
    public string? Remark { get; set; }
}
