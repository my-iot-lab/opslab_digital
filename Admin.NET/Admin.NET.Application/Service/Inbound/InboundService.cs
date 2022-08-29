using Admin.NET.Application.Const;

namespace Admin.NET.Application.Service;

/// <summary>
/// 进站服务
/// </summary>
[ApiDescriptionSettings(BusinessConst.GroupName, Name = "XXX模块", Order = 200)]
[AllowAnonymous]
public class InboundService : IDynamicApiController, ITransient
{
}
