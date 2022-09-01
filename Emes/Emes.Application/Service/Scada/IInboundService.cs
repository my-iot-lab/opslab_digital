namespace Emes.Application.Service;

/// <summary>
/// SCADA 进站服务
/// </summary>
public interface IInboundService
{
    /// <summary>
    /// 处理产品进站数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task<ApiResult> HandleAsync(ApiData data);
}
