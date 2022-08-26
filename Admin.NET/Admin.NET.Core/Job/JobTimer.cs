﻿namespace Admin.NET.Core;

/// <summary>
/// 任务调度
/// </summary>
public class JobTimer : ISpareTimeWorker
{
    /// <summary>
    /// 日志删除定时器
    /// </summary>
    /// <param name="timer"></param>
    /// <param name="count"></param>
    [SpareTime("@midnight", "日志删除定时器", Description = "每天午夜运行一次", DoOnce = false, StartNow = true, ExecuteType = SpareTimeExecuteTypes.Serial)]
    public void ClearLogJob(SpareTimer timer, long count)
    {
        Scoped.Create(async (_, scope) =>
        {
            var services = scope.ServiceProvider;
            var db = services.GetService<ISqlSugarClient>();

            var daysAgo = 30; // 删除30天以前
            await db.Deleteable<SysLogVis>().Where(u => (DateTime)u.CreateTime < DateTime.Now.AddDays(-daysAgo)).ExecuteCommandAsync(); // 删除访问日志
            await db.Deleteable<SysLogOp>().Where(u => (DateTime)u.CreateTime < DateTime.Now.AddDays(-daysAgo)).ExecuteCommandAsync(); // 删除操作日志
            await db.Deleteable<SysLogEx>().Where(u => (DateTime)u.CreateTime < DateTime.Now.AddDays(-daysAgo)).ExecuteCommandAsync(); // 删除异常日志
            await db.Deleteable<SysLogDiff>().Where(u => (DateTime)u.CreateTime < DateTime.Now.AddDays(-daysAgo)).ExecuteCommandAsync(); // 删除差异日志
        });
    }
}