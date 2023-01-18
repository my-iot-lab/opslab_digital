using MQTTnet;
using MQTTnet.Client;

namespace DigitalLab.Mqtt;

/// <summary>
/// MQTT 客户端
/// </summary>
public sealed class DglMqttClient : IDisposable
{
	private readonly IMqttClient _mqttClient;
    private readonly DglMqttOptions _mqttOptions;

    /// <summary>
    /// 连接到服务器后的触发事件。
    /// </summary>
    public Func<MqttClientConnectedEventArgs, Task>? OnConnectedAsync;

    /// <summary>
    /// 断开连接后触的发事件。
    /// </summary>
    public Func<MqttClientDisconnectedEventArgs, Task>? OnDisconnectedAsync;

    /// <summary>
    /// 应用收到消息后的触发事件。
    /// </summary>
    public Func<MqttApplicationMessageReceivedEventArgs, Task>? OnApplicationMessageReceivedAsync;

    public DglMqttClient(DglMqttOptions mqttOptions)
	{
        _mqttOptions = mqttOptions;

        MqttFactory factory = new();
        _mqttClient = factory.CreateMqttClient();
    }

    /// <summary>
    /// 链接服务器
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        var mqttClientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer(_mqttOptions.Server, _mqttOptions.Port)
            .WithClientId(_mqttOptions.ClientId)
            .WithCredentials(_mqttOptions.Username, _mqttOptions.Password)
            .Build();

        if (OnConnectedAsync != null)
        {
            _mqttClient.ConnectedAsync += OnConnectedAsync;
        }
        if (OnDisconnectedAsync != null)
        {
            _mqttClient.DisconnectedAsync += OnDisconnectedAsync;
        }
        if (OnApplicationMessageReceivedAsync != null)
        {
            _mqttClient.ApplicationMessageReceivedAsync += OnApplicationMessageReceivedAsync;
        }

        try
        {
            if (_mqttOptions.Timeout > 0)
            {
                // 设置链接超时时长
                using var timeoutToken = new CancellationTokenSource(TimeSpan.FromSeconds(_mqttOptions.Timeout));
                var cts = CancellationTokenSource.CreateLinkedTokenSource(timeoutToken.Token, cancellationToken);
                await _mqttClient.ConnectAsync(mqttClientOptions, cts.Token);
            }
            else
            {
                await _mqttClient.ConnectAsync(mqttClientOptions, cancellationToken); // Socket 设置的超时时长
            }
        }
        catch (OperationCanceledException)
        {
            // log Timeout while connecting.
        }
    }

    /// <summary>
    /// 订阅
    /// </summary>
    /// <param name="topics">要订阅的Topic集合</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task SubscribeAsync(string[] topics, CancellationToken cancellationToken = default)
    {
        MqttClientSubscribeOptionsBuilder mqttSubscribeOptionsBuilder = new();
        foreach (var topic in topics)
        {
            mqttSubscribeOptionsBuilder.WithTopicFilter(topic);
        }

        await _mqttClient.SubscribeAsync(mqttSubscribeOptionsBuilder.Build(), cancellationToken);
    }

    /// <summary>
    /// 发布数据
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task PublishAsync(string topic, string message, CancellationToken cancellationToken = default)
    {
        var mqttMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(message)
            .Build();
        await _mqttClient.PublishAsync(mqttMessage, cancellationToken);
    }

    public async Task DisconnectAsync()
    {
        await _mqttClient.DisconnectAsync(MqttClientDisconnectReason.NormalDisconnection);
    }

    public void Dispose()
    {
        // Calling _Dispose_ or use of a _using_ statement will close the transport connection
        // without sending a DISCONNECT packet to the server.
        _mqttClient?.Dispose();
    }
}
