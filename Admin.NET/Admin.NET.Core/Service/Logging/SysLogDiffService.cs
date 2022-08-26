﻿namespace Admin.NET.Core.Service;

/// <summary>
/// 差异日志服务
/// </summary>
[ApiDescriptionSettings(Name = "差异日志", Order = 180)]
public class SysLogDiffService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysLogDiff> _sysLogDiffRep;

    public SysLogDiffService(SqlSugarRepository<SysLogDiff> sysLogDiffRep)
    {
        _sysLogDiffRep = sysLogDiffRep;
    }

    /// <summary>
    /// 获取差异日志分页列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/sysLogDiff/page")]
    [SuppressMonitor]
    public async Task<SqlSugarPagedList<SysLogDiff>> GetLogDiffPage([FromQuery] PageLogInput input)
    {
        return await _sysLogDiffRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.StartTime.ToString()) && !string.IsNullOrWhiteSpace(input.EndTime.ToString()),
                        u => u.CreateTime >= input.StartTime && u.CreateTime <= input.EndTime)
            .OrderBy(u => u.CreateTime, SqlSugar.OrderByType.Desc)
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 清空差异日志
    /// </summary>
    /// <returns></returns>
    [HttpPost("/sysLogDiff/clear")]
    public async Task<bool> ClearLogDiff()
    {
        return await _sysLogDiffRep.DeleteAsync(u => u.Id > 0);
    }
}