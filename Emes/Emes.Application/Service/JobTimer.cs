using Furion.TaskScheduler;
using Microsoft.Extensions.Logging;

namespace Emes.Application.Service;

/// <summary>
/// 任务调度定时器。
/// </summary>
public class JobTimer : ISpareTimeWorker
{
    private readonly ILogger _logger;

    // 必须为无参的构造函数
    public JobTimer()
    {
        var loggerFactory = App.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger<JobTimer>();
    }

    /// <summary>
    /// 定时器
    /// </summary>
    /// <param name="timer"></param>
    /// <param name="count"></param>
    [SpareTime(5000, "定时器", StartNow = true, ExecuteType = SpareTimeExecuteTypes.Serial)]
    public void CollectDeviceChannel(SpareTimer timer, long count)
    {
        // 创建一个依赖注入的作用域（Scope 注入）
        Scoped.Create((_, scope) =>
        {
            //var db = scope.ServiceProvider.GetService<ISqlSugarClient>();

            //_logger.LogInformation($"【定时器】{DateTime.Now} 执行次数：{count}");
        });
    }
}