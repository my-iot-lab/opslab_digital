namespace Emes.Application.Service;

/// <summary>
/// 物料输入
/// </summary>
public class ItemInput : BaseIdInput
{
    /// <summary>
    /// 产品/物料代码
    /// </summary>
    [Required(ErrorMessage = "物料代码不能为空")]
    [NotNull]
    public string? Code { get; set; }

    /// <summary>
    /// 产品/物料名称
    /// </summary>
    [Required(ErrorMessage = "物料名称不能为空")]
    [NotNull]
    public string? Name { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    public string? Spec { get; set; }

    /// <summary>
    /// 物料属性。
    /// </summary>
    public MaterialAttrEnum Attr { get; set; }

    /// <summary>
    /// 计量单位
    /// </summary>
    public string? Unit { get; set; }

    /// <summary>
    /// 条码规则，多个以逗号分隔。
    /// </summary>
    [Required(ErrorMessage = "条码规则不能为空")]
    [NotNull]
    public string? BarcodeRule { get; set; }

    /// <summary>
    /// 保质期
    /// </summary>
    public int? Expiration { get; set; }
}

public class PageItemInput : BasePageInput
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public MaterialAttrEnum? Attr { get; set; }
}

public sealed class AddItemInput : ItemInput
{

}

public sealed class UpdateItemInput : ItemInput
{

}

public sealed class DeleteItemInput : BaseIdInput
{

}
