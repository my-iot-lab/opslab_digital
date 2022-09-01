using Microsoft.AspNetCore.SignalR;
using Furion.InstantMessaging;
using Emes.Application.Service;

namespace Emes.Application.Hubs;

/// <summary>
/// SCADA 集成器
/// </summary>
[MapHub("/hubs/scadahub")]
public class ScadaHub : Hub<IScadaClient>
{
    private readonly IHubContext<ScadaHub, IScadaClient> _scadaHubContext;

    public ScadaHub(IHubContext<ScadaHub, IScadaClient> scadaHubContext)
    {
        _scadaHubContext = scadaHubContext;
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    /// <summary>
    /// 客户端发送测试信息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public async Task SendMessage(string msg)
    {
        await _scadaHubContext.Clients.All.ReceiveMessage(msg);
    }

    /// <summary>
    /// 客户端发送测试信息
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Task SendMessage2(ApiData obj)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 客户端发送警报信息。
    /// </summary>
    /// <returns></returns>
    public Task SendAlarm(ApiData data)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 客户端发送安灯信息。
    /// </summary>
    /// <returns></returns>
    public Task SendHandleAndon(ApiData data)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 客户端发送通知信息。
    /// </summary>
    /// <returns></returns>
    public Task SendNotice(ApiData data)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 客户端发送进站信息。
    /// </summary>
    /// <returns></returns>
    public async Task SendInbound(ApiData data)
    {
        await _scadaHubContext.Clients.All.ReceiveInbound(new ApiResult());
    }

    /// <summary>
    /// 客户端发送存档信息。
    /// </summary>
    /// <returns></returns>
    public async Task SendArchive(ApiData data)
    {
        await _scadaHubContext.Clients.All.ReceiveArchive(new ApiResult());
    }

    /// <summary>
    /// 客户端发送扫入的关键物料数据。
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public async Task SendCriticalMaterial(ApiData data)
    {
        await _scadaHubContext.Clients.All.ReceiveCriticalMaterial(new ApiResult());
    }

    /// <summary>
    /// 处理扫入的批次料数据。
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public async Task SendBactchMaterial(ApiData data)
    {
        await _scadaHubContext.Clients.All.ReceiveBactchMaterial(new ApiResult());
    }

    /// <summary>
    /// 客户端发送自定义数据。
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public async Task SendCustom(ApiData data)
    {
        await _scadaHubContext.Clients.All.ReceiveCustom(new ApiResult());
    }
}
