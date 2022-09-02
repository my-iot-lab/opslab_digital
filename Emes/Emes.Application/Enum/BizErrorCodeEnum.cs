namespace Emes.Application;

/// <summary>
/// 业务错误代码
/// </summary>
public enum BizErrorCodeEnum
{
    /// <summary>
    /// 数据已存在
    /// </summary>
    [ErrorCodeItemMetadata("数据已存在")]
    E1000,

    /// <summary>
    /// 没有找到要更新的数据
    /// </summary>
    [ErrorCodeItemMetadata("没有找到要更新的数据")]
    E1001,

    /// <summary>
    /// Id不能为空
    /// </summary>
    [ErrorCodeItemMetadata("Id不能为空")]
    E1002,
}
