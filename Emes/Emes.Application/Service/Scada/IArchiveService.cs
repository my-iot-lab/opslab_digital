namespace Emes.Application.Service;

/// <summary>
/// SCADA 出站/存档服务
/// </summary>
public interface IArchiveService
{
    /// <summary>
    /// 处理产品出站数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task<ApiResult> HandleAsync(ApiData data);
}
