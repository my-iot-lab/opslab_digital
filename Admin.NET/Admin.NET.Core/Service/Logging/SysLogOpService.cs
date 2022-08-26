﻿namespace Admin.NET.Core.Service;

/// <summary>
/// 系统操作日志服务
/// </summary>
[ApiDescriptionSettings(Name = "操作日志", Order = 179)]
public class SysLogOpService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysLogOp> _sysLogOpRep;

    public SysLogOpService(SqlSugarRepository<SysLogOp> sysLogOpRep)
    {
        _sysLogOpRep = sysLogOpRep;
    }

    /// <summary>
    /// 获取操作日志分页列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/sysLogOp/page")]
    [SuppressMonitor]
    public async Task<SqlSugarPagedList<SysLogOp>> GetLogOpPage([FromQuery] PageLogInput input)
    {
        return await _sysLogOpRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.StartTime.ToString()) && !string.IsNullOrWhiteSpace(input.EndTime.ToString()),
                        u => u.CreateTime >= input.StartTime && u.CreateTime <= input.EndTime)
            .OrderBy(u => u.CreateTime, SqlSugar.OrderByType.Desc)
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 清空操作日志
    /// </summary>
    /// <returns></returns>
    [HttpPost("/sysLogOp/clear")]
    public async Task<bool> ClearLogOp()
    {
        return await _sysLogOpRep.DeleteAsync(u => u.Id > 0);
    }
}