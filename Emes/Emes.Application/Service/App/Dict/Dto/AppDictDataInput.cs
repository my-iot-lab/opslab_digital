namespace Emes.Application.Service;

public class AppDictDataInput : BaseIdInput
{
}

public class AppGetDataDictDataInput
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    [Required(ErrorMessage = "字典类型Id不能为空"), DataValidation(ValidationTypes.Numeric)]
    public long DictTypeId { get; set; }
}

/// <summary>
/// 字典值分页
/// </summary>
public class AppPageDictDataInput : BasePageInput
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public long DictTypeId { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Code { get; set; }
}

public class AppAddDictDataInput
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public long DictTypeId { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int Status { get; set; }
}

public class AppUpdateDictDataInput : BaseIdInput
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public long DictTypeId { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int Status { get; set; }
}

public class AppDeleteDictDataInput : BaseIdInput
{
}

public class AppChageStatusDictDataInput : BaseIdInput
{
    /// <summary>
    /// 状态
    /// </summary>
    public int Status { get; set; }
}

public class AppQueryDictDataInput
{
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "字典唯一编码不能为空")]
    public string? Code { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int? Status { get; set; }
}