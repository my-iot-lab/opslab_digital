using MQTTnet.Client;
using DigitalLab.Mqtt;

namespace DigitalLab;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// 添加要自定义处理 MQTT 客户端对象类型。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddMqttClientHandler<T>(this IServiceCollection services)
        where T : IMqttClientHandler
    {
        services.AddSingleton(typeof(IMqttClientHandler), typeof(T));
        return services;
    }

    /// <summary>
    ///  添加 MQTT 客户端后台服务。
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <param name="node">配置文件节点，默认为 MQTT</param>
    /// <returns></returns>
    public static IServiceCollection AddMqttClientHostedService(this IServiceCollection services, IConfiguration configuration, string node = "MQTT")
    {
        var settings = configuration.GetSection(node).Get<MqttClientSettings>();
        if (settings == null)
        {
            throw new Exception($"MQTT 客户端节点 '{node}' 没有配置");
        }

        services.AddMqttClientHostedService(settings);
        return services;
    }

    /// <summary>
    /// 添加 MQTT 客户端后台服务。
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure">客户端参数配置</param>
    public static IServiceCollection AddMqttClientHostedService(this IServiceCollection services, Action<MqttClientSettings> configure)
    {
        MqttClientSettings settings = new();
        configure(settings);
        services.AddMqttClientHostedService(settings);
        return services;
    }

    /// <summary>
    /// 添加 MQTT 客户端后台服务。
    /// </summary>
    /// <param name="services"></param>
    /// <param name="settings">客户端参数配置</param>
    /// <returns></returns>
    public static IServiceCollection AddMqttClientHostedService(this IServiceCollection services, MqttClientSettings settings)
    {
        services.AddMqttClientServiceWithConfig(optionBuilder =>
        {
            optionBuilder.WithTcpServer(settings.Host, settings.Port);
            if (!string.IsNullOrWhiteSpace(settings.UserName))
            {
                optionBuilder.WithCredentials(settings.UserName, settings.Password);
            }
            if (!string.IsNullOrWhiteSpace(settings.ClientId))
            {
                optionBuilder.WithClientId(settings.ClientId);
            }
        });
        return services;
    }

    private static IServiceCollection AddMqttClientServiceWithConfig(this IServiceCollection services, Action<MqttClientOptionsBuilder> configure)
    {
        services.AddSingleton(_ =>
        {
            MqttClientOptionsBuilder optionBuilder = new();
            configure(optionBuilder);
            return optionBuilder.Build();
        });
        services.AddSingleton<MqttClientService>();
        services.AddHostedService<MqttClientService>();

        return services;
    }
}
