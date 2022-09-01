namespace Emes.Application.Service;

/// <summary>
/// SCADA 扫码服务
/// </summary>
public interface IMaterialService
{
    /// <summary>
    /// 处理扫入的关键物料数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task<ApiResult> HandleCriticalMaterialAsync(ApiData data);

    /// <summary>
    /// 处理扫入的批次料数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task<ApiResult> HandleBactchMaterialAsync(ApiData data);
}
