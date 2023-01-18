namespace DigitalLab.Mqtt;

/// <summary>
/// MQTT 参数选项
/// </summary>
public class DglMqttOptions
{
    public string? Server { get; set; }

    public int? Port { get; set; }

    public string? ClientId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    /// <summary>
    /// 超时时间，单位秒
    /// </summary>
    public int Timeout { get; set; } = 5;
}
