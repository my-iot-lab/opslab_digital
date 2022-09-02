namespace Emes.Application.Service;

public class AppDictTypeInput : BaseIdInput
{
}

/// <summary>
/// 字典类型分页
/// </summary>
public class AppPageDictTypeInput : BasePageInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Code { get; set; }
}

public class AppAddDictTypeInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

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

public class AppUpdateDictTypeInput : BaseIdInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

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

public class AppDeleteDictTypeInput : BaseIdInput
{
}

public class AppGetDataDictTypeInput
{
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "字典类型编码不能为空")]
    [NotNull]
    public string? Code { get; set; }
}

public class AppChangeStatusDictTypeInput : BaseIdInput
{
    /// <summary>
    /// 状态
    /// </summary>
    public int Status { get; set; }
}