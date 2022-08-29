namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品信息主数据
/// </summary>
[SugarTable("ops_master_product", "产品信息表")]
public class Product : BizEntityBase
{
    /// <summary>
    /// 产品代码
    /// </summary>
    [SugarColumn(ColumnDescription = "产品代码", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    [SugarColumn(ColumnDescription = "产品名称", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 程序配方号
    /// </summary>
    [SugarColumn(ColumnDescription = "程序配方号")]
    public int Formula { get; set; }
}
