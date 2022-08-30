namespace Emes.Application.Entity;

/// <summary>
/// 产品进站明细信息
/// </summary>
[SugarTable("pt_inbound_item", "产品进站信息表")]
public class PtInboundItem : BizEntityBaseId
{
    /// <summary>
    /// 产品进站信息 Id。
    /// </summary>
    [SugarColumn(ColumnDescription = "产品进站信息Id")]
    public long InboundId { get; set; }

    /// <summary>
    /// 产品进站信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public PtInbound? Inbound { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    [SugarColumn(ColumnDescription = "标签", Length = 32)]
    [Required, MaxLength(32)]
    [NotNull]
    public string? Tag { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    [Required, MaxLength(64)]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    [SugarColumn(ColumnDescription = "值", Length = 1024)]
    [Required, MaxLength(1024)]
    [NotNull]
    public string? Value { get; set; }

    /// <summary>
    /// 值是否是数组
    /// </summary>
    [SugarColumn(ColumnDescription = "值是否是数组")]
    public bool IsArray { get; set; }
}
