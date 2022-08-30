namespace Admin.NET.Application.Entity;

/// <summary>
/// 生产排产
/// </summary>
[SugarTable("pro_schedule", "生产排产表")]
public sealed class ProSchedule : BizEntityBase
{
    /// <summary>
    /// 工单Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工单Id")]
    public long WoId { get; set; }

    /// <summary>
    /// 工单信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public ProWo? Wo { get; set; }

    /// <summary>
    /// 顺序号
    /// </summary>
    [SugarColumn(ColumnDescription = "顺序号")]
    public int Seq { get; set; }
}
