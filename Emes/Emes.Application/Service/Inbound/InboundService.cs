namespace Emes.Application.Service;

/// <summary>
/// 进站服务
/// </summary>
[ApiDescriptionSettings(ModuleConst.Production, Name = "XXX模块", Order = 200)]
[AllowAnonymous]
public class InboundService : IDynamicApiController, ITransient
{
}
