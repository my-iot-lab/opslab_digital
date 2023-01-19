namespace DigitalLab.Mqtt;

/// <summary>
/// MQTT 客户端参数设定。
/// </summary>
public class MqttClientSettings
{
    /// <summary>
    /// 服务器主机，可以是域名或 IP 地址。
    /// </summary>
    [NotNull]
    public string? Host { set; get; }

    /// <summary>
    /// Broker 端口，null 表示用默认端口。
    /// </summary>
    public int? Port { set; get; }

    /// <summary>
    /// 客户端Id，可用来标识客户端。
    /// </summary>
    /// <remarks>客户端 Id 必须唯一，默认框架内部用 GUID 设置。</remarks>
    public string? ClientId { get; set; }

    public string? UserName { set; get; }

    public string? Password { set; get; }
}
