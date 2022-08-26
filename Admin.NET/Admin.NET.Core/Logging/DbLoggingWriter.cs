namespace Admin.NET.Core;

/// <summary>
/// 数据库日志写入器
/// </summary>
public class DbLoggingWriter : IDatabaseLoggingWriter
{
    private readonly SqlSugarRepository<SysLogOp> _sysLogOpRep; // 操作日志
    private readonly SqlSugarRepository<SysLogEx> _sysLogExRep; // 异常日志

    public DbLoggingWriter(SqlSugarRepository<SysLogOp> sysLogOpRep,
        SqlSugarRepository<SysLogEx> sysLogExRep)
    {
        _sysLogOpRep = sysLogOpRep;
        _sysLogExRep = sysLogExRep;
    }

    public void Write(LogMessage logMsg, bool flush)
    {
        if (logMsg.LogLevel == Microsoft.Extensions.Logging.LogLevel.Information)
        {
            _sysLogOpRep.Insert(new SysLogOp
            {
                LogName = logMsg.LogName,
                LogLevel = logMsg.LogLevel.ToString(),
                EventId = JSON.Serialize(logMsg.EventId),
                Message = logMsg.Message,
                Exception = logMsg.Exception == null ? "" : JSON.Serialize(logMsg.Exception),
            });

            return;
        }

        if (logMsg.LogLevel is Microsoft.Extensions.Logging.LogLevel.Warning
            or Microsoft.Extensions.Logging.LogLevel.Error
            or Microsoft.Extensions.Logging.LogLevel.Critical)
        {
            _sysLogExRep.Insert(new SysLogEx
            {
                LogName = logMsg.LogName,
                LogLevel = logMsg.LogLevel.ToString(),
                EventId = JSON.Serialize(logMsg.EventId),
                Message = logMsg.Message,
                Exception = logMsg.Exception == null ? "" : JSON.Serialize(logMsg.Exception),
            });
        }
    }
}