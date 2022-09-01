namespace Emes.Application.Service;

/// <summary>
/// SCADA 安灯服务。
/// </summary>
public interface IAndonService
{
    /// <summary>
    /// 处理安灯数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    Task HandleAsync(ApiData data);
}
