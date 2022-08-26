﻿namespace Admin.NET.Core;

/// <summary>
/// 用户管理
/// </summary>
public class UserManager : IUserManager, IScoped
{
    private readonly SqlSugarRepository<SysUser> _sysUserRep;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public long UserId
    {
        get => long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.UserId)?.Value);
    }

    public string UserName
    {
        get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.UserName)?.Value;
    }

    public string RealName
    {
        get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.RealName)?.Value;
    }

    public bool SuperAdmin
    {
        get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.SuperAdmin)?.Value == ((int)UserTypeEnum.SuperAdmin).ToString();
    }

    public string OpenId
    {
        get => _httpContextAccessor.HttpContext.User.FindFirst(ClaimConst.OpenId)?.Value;
    }

    public SysUser User
    {
        get => _sysUserRep.AsQueryable().Includes(t => t.SysOrg).First(u => u.Id == UserId);
    }

    public UserManager(SqlSugarRepository<SysUser> sysUserRep,
        IHttpContextAccessor httpContextAccessor)
    {
        _sysUserRep = sysUserRep;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<SysUser> CheckUserAsync(long userId)
    {
        var user = await _sysUserRep.GetFirstAsync(u => u.Id == userId);
        return user ?? throw Oops.Oh(ErrorCodeEnum.D1002);
    }
}