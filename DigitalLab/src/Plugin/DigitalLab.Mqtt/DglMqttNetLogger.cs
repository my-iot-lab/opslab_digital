using MQTTnet.Diagnostics;

namespace DigitalLab.Mqtt;

/// <summary>
/// MQTT 日志
/// </summary>
public sealed class DglMqttNetLogger : IMqttNetLogger
{
    public bool IsEnabled => true;

    public void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception)
    {
        
    }
}
