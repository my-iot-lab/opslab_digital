using MQTTnet;
using MQTTnet.Client;

namespace DigitalLab.Mqtt;

public sealed class MqttClientService : IMqttClientService
{
    private readonly IMqttClientHandler _mqttClientHandler;
    private readonly IMqttClient _mqttClient;
    private readonly MqttClientOptions _options;
    private readonly ILogger _logger;

    public MqttClientService(
        IMqttClientHandler mqttClientHandler,
        MqttClientOptions options,
        ILogger<MqttClientService> logger)
    {
        _mqttClientHandler = mqttClientHandler;
        _options = options;
        _logger = logger;

        _mqttClient = new MqttFactory().CreateMqttClient();
        _mqttClient.ConnectedAsync += HandleConnectedAsync;
        _mqttClient.DisconnectedAsync += HandleDisconnectedAsync;
        _mqttClient.ApplicationMessageReceivedAsync += HandleApplicationMessageReceivedAsync;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // 若要设置链接超时时长，可使用如下方式：
        //var timeoutToken = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        //using var cts = CancellationTokenSource.CreateLinkedTokenSource(timeoutToken.Token, cancellationToken);
        //await _mqttClient.ConnectAsync(_options, cts.Token);

        var connectResult = await _mqttClient.ConnectAsync(_options, cancellationToken);
        if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
        {
            await SubscribeAsync(cancellationToken);
        }

        // Reconnect_Using_Timer: https://github.com/dotnet/MQTTnet/blob/master/Samples/Client/Client_Connection_Samples.cs
        // 
        _ = Task.Run(async () =>
         {
             // // User proper cancellation and no while(true).
             while (!cancellationToken.IsCancellationRequested)
             {
                 try
                 {
                     // This code will also do the very first connect! So no call to _ConnectAsync_ is required in the first place.
                     if (!await _mqttClient.TryPingAsync())
                     {
                         // Subscribe to topics when session is clean etc.
                         _logger.LogWarning("[MqttClientService] MQTT 客户端已断开连接。");

                         var connectResult = await _mqttClient.ConnectAsync(_mqttClient.Options, cancellationToken);
                         if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
                         {
                             await SubscribeAsync(cancellationToken);
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     // Handle the exception properly (logging etc.).
                     _logger.LogError(ex, "[MqttClientService] MQTT 客户端连接失败。");
                 }
                 finally
                 {
                     // Check the connection state every 5 seconds and perform a reconnect if required.
                     await Task.Delay(TimeSpan.FromSeconds(5));
                 }
             }
         }, cancellationToken);
    }

    private async Task SubscribeAsync(CancellationToken cancellationToken = default)
    {
        // 订阅主题，注：必须在连接到服务器后才能订阅，否则会抛出异常。
        MqttClientSubscribeOptionsBuilder mqttSubscribeOptionsBuilder = new();
        foreach (var topic in _mqttClientHandler.GetTopics())
        {
            mqttSubscribeOptionsBuilder.WithTopicFilter(topic);
        }

        await _mqttClient.SubscribeAsync(mqttSubscribeOptionsBuilder.Build(), cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            MqttClientDisconnectOptions disconnectOption = new()
            {
                Reason = MqttClientDisconnectReason.NormalDisconnection,
                ReasonString = "Normal Diconnection",
            };
            await _mqttClient.DisconnectAsync(disconnectOption, cancellationToken);
            return;
        }

        await _mqttClient.DisconnectAsync();
    }

    private async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
    {
        await _mqttClientHandler.HandleApplicationMessageReceivedAsync(eventArgs);
    }

    private async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
    {
        await _mqttClientHandler.HandleConnectedAsync(eventArgs);
    }

    private async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
    {
        await _mqttClientHandler.HandleDisconnectedAsync(eventArgs);
    }
}
