namespace Emes.Application.Entity;

/// <summary>
/// 产品BOM关系
/// </summary>
[SugarTable("md_product_bom", "产品BOM关系表")]
public sealed class MdProductBom : BizEntityBase
{
    /// <summary>
    /// 产品信息 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产品Id")]
    public long ProductId { get; set; }

    /// <summary>
    /// 产品信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(ProductId))]
    public MdItem? Product { get; set; }

    /// <summary>
    /// 产线
    /// </summary>
    [SugarColumn(ColumnDescription = "产线", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Line { get; set; }

    /// <summary>
    /// 工站
    /// </summary>
    [SugarColumn(ColumnDescription = "工站", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Station { get; set; }

    /// <summary>
    /// 物料信息 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "物料信息Id")]
    public long MaterialId { get; set; }

    /// <summary>
    /// 物料信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(MaterialId))]
    public MdItem? Material { get; set; }

    /// <summary>
    /// 使用数量
    /// </summary>
    [SugarColumn(ColumnDescription = "使用数量")]
    public int Qty { get; set; }

    /// <summary>
    /// 上料顺序号。
    /// </summary>
    /// <remarks>用在有顺序的扫码上料流程中校验，当数值大于 0 时有效。</remarks>
    [SugarColumn(ColumnDescription = "上料顺序号")]
    public int Seq { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    [SugarColumn(ColumnDescription = "版本号")]
    public int Version { get; set; }
}
