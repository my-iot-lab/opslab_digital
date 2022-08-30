namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品对应的工艺路线信息
/// </summary>
[SugarTable("ops_product_process_route", "产品对应的工艺路线表")]
public class ProProductProcessRouting : BizEntityBase
{
    /// <summary>
    /// 产品 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产品 Id")]
    public long ProductId { get; set; }

    /// <summary>
    /// 产品信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public MdItem? Product { get; set; }

    /// <summary>
    /// 工艺路线 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工艺路线 Id")]
    public long ProcessRoutingId { get; set; }

    /// <summary>
    /// 工艺路线
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public ProProcessRouting? ProcessRouting { get; set; }

    /// <summary>
    /// 程序配方号（PLC 程序配方）。
    /// </summary>
    [SugarColumn(ColumnDescription = "程序配方号")]
    public int Formula { get; set; }
}
