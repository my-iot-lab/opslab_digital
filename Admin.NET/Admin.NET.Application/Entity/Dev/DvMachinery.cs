namespace Admin.NET.Application.Entity;

[SugarTable("dv_machinery", "设备表")]
public class DvMachinery : BizEntityBase
{
    /// <summary>
    /// 设备编码
    /// </summary>
    [SugarColumn(ColumnDescription = "设备编码", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    [SugarColumn(ColumnDescription = "设备名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 品牌
    /// </summary>
    [SugarColumn(ColumnDescription = "品牌", Length = 255)]
    [MaxLength(255)]
    public string? Brand { get; set; }

    /// <summary>
    /// 规格
    /// </summary>
    [SugarColumn(ColumnDescription = "规格", Length = 255)]
    [MaxLength(255)]
    public string? Spec { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    [SugarColumn(ColumnDescription = "设备状态", Length = 32)]
    [MaxLength(32)]
    public string? Status { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 255)]
    [MaxLength(255)]
    public string? Remark { get; set; }
}
