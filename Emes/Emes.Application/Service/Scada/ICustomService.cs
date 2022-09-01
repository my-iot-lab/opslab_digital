namespace Emes.Application.Service;

/// <summary>
/// SCADA 自定义服务
/// </summary>
public interface ICustomService
{
    /// <summary>
    /// 处理自定义数据。
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task<ApiResult> HandleAsync(ApiData data);
}
