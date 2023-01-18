using Microsoft.Extensions.Hosting;

namespace DigitalLab.Mqtt;

public sealed class DglMqttHostService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
