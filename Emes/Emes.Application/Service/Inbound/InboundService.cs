namespace Emes.Application.Service;

/// <summary>
/// 进站服务
/// </summary>
[ApiDescriptionSettings(Order = 200)]
[AllowAnonymous]
public class InboundService : IDynamicApiController, ITransient
{
}
