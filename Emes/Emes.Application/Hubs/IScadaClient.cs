using Emes.Application.Service;

namespace Emes.Application.Hubs;

/// <summary>
/// SCADA 客户端
/// </summary>
public interface IScadaClient
{
    /// <summary>
    /// 客户端接收测试信息。
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    Task ReceiveMessage(string msg);

    /// <summary>
    /// 客户端接收进站结果信息。
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    Task ReceiveInbound(ApiResult result);

    /// <summary>
    /// 客户端接收出站存档结果信息。
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    Task ReceiveArchive(ApiResult result);

    /// <summary>
    /// 客户端接收扫关键料结果信息。
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    Task ReceiveCriticalMaterial(ApiResult result);

    /// <summary>
    /// 客户端接收扫批次料结果信息。
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    Task ReceiveBactchMaterial(ApiResult result);

    /// <summary>
    /// 客户端接收自定义结果信息。
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    Task ReceiveCustom(ApiResult result);
}
