namespace Emes.Application.Service;

/// <summary>
/// SCADA 警报服务
/// </summary>
public interface IAlarmService
{
    /// <summary>
    /// 处理警报数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task<ApiResult> HandleAsync(ApiData data);
}
