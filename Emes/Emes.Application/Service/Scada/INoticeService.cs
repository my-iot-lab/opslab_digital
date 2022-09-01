namespace Emes.Application.Service;

/// <summary>
/// SCADA 通知服务
/// </summary>
public interface INoticeService
{
    /// <summary>
    /// 处理通知数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task HandleAsync(ApiData data);
}
