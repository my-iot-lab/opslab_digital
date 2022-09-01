namespace Emes.Application.Service;

public sealed class CustomService : ICustomService, ITransient
{
    public CustomService()
    {
    }

    public Task<ApiResult> HandleAsync(ApiData data)
    {
        return Task.FromResult(ApiResult.Ok());
    }
}
