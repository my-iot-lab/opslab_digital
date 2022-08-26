﻿namespace Admin.NET.Core.Service;

/// <summary>
/// 系统职位服务
/// </summary>
[ApiDescriptionSettings(Name = "系统职位", Order = 196)]
public class SysPosService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysPos> _sysPosRep;
    private readonly SysUserExtOrgPosService _sysUserExtOrgPosService;

    public SysPosService(SqlSugarRepository<SysPos> sysPosRep,
        SysUserExtOrgPosService sysUserExtOrgPosService)
    {
        _sysPosRep = sysPosRep;
        _sysUserExtOrgPosService = sysUserExtOrgPosService;
    }

    /// <summary>
    /// 获取职位列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("/sysPos/list")]
    public async Task<List<SysPos>> GetPosList([FromQuery] PosInput input)
    {
        return await _sysPosRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code), u => u.Code.Contains(input.Code))
            .OrderBy(u => u.Order).ToListAsync();
    }

    /// <summary>
    /// 增加职位
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/sysPos/add")]
    public async Task AddPos(AddPosInput input)
    {
        var isExist = await _sysPosRep.IsAnyAsync(u => u.Name == input.Name && u.Code == input.Code);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D6000);

        await _sysPosRep.InsertAsync(input.Adapt<SysPos>());
    }

    /// <summary>
    /// 更新职位
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/sysPos/update")]
    public async Task UpdatePos(UpdatePosInput input)
    {
        var isExist = await _sysPosRep.IsAnyAsync(u => (u.Name == input.Name || u.Code == input.Code) && u.Id != input.Id);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D6000);

        await _sysPosRep.AsUpdateable(input.Adapt<SysPos>()).IgnoreColumns(true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除职位
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/sysPos/delete")]
    public async Task DeletePos(DeletePosInput input)
    {
        // 该职位下是否有用户
        var hasPosEmp = await _sysPosRep.ChangeRepository<SqlSugarRepository<SysUser>>()
            .IsAnyAsync(u => u.PosId == input.Id);
        if (hasPosEmp)
            throw Oops.Oh(ErrorCodeEnum.D6001);

        // 该附属职位下是否有用户
        var hasExtPosEmp = await _sysUserExtOrgPosService.HasExtPosEmp(input.Id);
        if (hasExtPosEmp)
            throw Oops.Oh(ErrorCodeEnum.D6001);

        await _sysPosRep.DeleteAsync(u => u.Id == input.Id);
    }
}