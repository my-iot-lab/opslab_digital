using MQTTnet.Client;

namespace DigitalLab.Mqtt;

/// <summary>
/// MQTT 客户端处理。
/// 自定义业务时，实现此接口即可（会设置为单例模式）。
/// </summary>
public interface IMqttClientHandler
{
    /// <summary>
    /// 获取要订阅的主题集合。
    /// </summary>
    string[] GetTopics();

    /// <summary>
    /// 已连接服务器时处理事件。
    /// </summary>
    /// <param name="eventArgs"></param>
    /// <returns></returns>
    Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs);

    /// <summary>
    /// 收到服务器数据时处理事件。
    /// </summary>
    /// <param name="eventArgs"></param>
    /// <returns></returns>
    Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs);

    /// <summary>
    /// 与服务器断开时处理事件。
    /// </summary>
    /// <param name="eventArgs"></param>
    /// <returns></returns>
    Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs);
}
