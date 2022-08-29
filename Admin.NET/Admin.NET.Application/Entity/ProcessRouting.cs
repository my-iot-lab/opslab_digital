namespace Admin.NET.Application.Entity;

/// <summary>
/// 工艺路线信息。
/// <para>注：此次工序采用工站代替。</para>
/// </summary>
[SugarTable("ops_process_routing", "工艺路线表")]
public class ProcessRouting : BizEntityBase
{
    /// <summary>
    /// 产品信息Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产品信息Id")]
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
    /// 当前工序 Id
    /// </summary>
    [SugarColumn(ColumnDescription = "当前工序 Id")]
    public long CurrentId { get; set; }

    /// <summary>
    /// 当前工序
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public StationInfo? Current { get; set; }

    /// <summary>
    /// 下一工序 Id，Null 表示当前为最终工序。
    /// </summary>
    [SugarColumn(ColumnDescription = "下一工序 Id")]
    public long? NextId { get; set; }

    /// <summary>
    /// 下一工序
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public StationInfo? Next { get; set; }
}
