namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品BOM信息主数据
/// </summary>
[SugarTable("ops_master_product_bom", "产品BOM信息表")]
public class ProductBom : BizEntityBase
{
    /// <summary>
    /// 产品信息 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产品 Id")]
    public long ProductId { get; set; }

    /// <summary>
    /// 产品信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public Product? Product { get; set; }

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
    /// 物料信息 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "物料信息 Id")]
    public long MaterialId { get; set; }

    /// <summary>
    /// 物料信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public Material? Material { get; set; }

    /// <summary>
    /// 使用数量
    /// </summary>
    [SugarColumn(ColumnDescription = "使用数量")]
    public int Qty { get; set; }

    /// <summary>
    /// 顺序号
    /// </summary>
    [SugarColumn(ColumnDescription = "顺序号")]
    public int Seq { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    [SugarColumn(ColumnDescription = "版本号")]
    public int Version { get; set; }
}
