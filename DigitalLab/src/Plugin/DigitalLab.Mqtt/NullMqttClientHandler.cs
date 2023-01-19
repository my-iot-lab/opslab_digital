using MQTTnet.Client;

namespace DigitalLab.Mqtt;

internal sealed class NullMqttClientHandler : IMqttClientHandler
{
    public string[] GetTopics() => Array.Empty<string>();

    public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
    {
        return Task.CompletedTask;
    }

    public Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
    {
        return Task.CompletedTask;
    }

    public Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
    {
        return Task.CompletedTask;
    }
}
