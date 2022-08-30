namespace Admin.NET.Application.Entity;

/// <summary>
/// 计量单位
/// </summary>
[SugarTable("md_unit_measure", "计量单位")]
public sealed class MdUnitMeasure : BizEntityBase
{
    /// <summary>
    /// 单位代码
    /// </summary>
    [SugarColumn(ColumnDescription = "单位代码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 单位名称
    /// </summary>
    [SugarColumn(ColumnDescription = "单位名称", Length = 64)]
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
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; } = StatusEnum.Enable;
}
