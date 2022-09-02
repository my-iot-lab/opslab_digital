namespace Emes.Application.Entity;

/// <summary>
/// 字典数据
/// </summary>
[SugarTable("app_dict_data", "业务字典数据表")]
public class AppDictData : BizEntityBase
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    [SugarColumn(ColumnDescription = "字典类型Id")]
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典类型
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(DictTypeId))]
    public AppDictType? DictType { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    [SugarColumn(ColumnDescription = "值", Length = 128)]
    [Required, MaxLength(128)]
    public string? Value { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [SugarColumn(ColumnDescription = "编码", Length = 64)]
    [Required, MaxLength(64)]
    public string? Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Order { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 128)]
    [MaxLength(128)]
    public string? Remark { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; } = StatusEnum.Enable;
}
