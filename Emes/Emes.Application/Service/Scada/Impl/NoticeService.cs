namespace Emes.Application.Service;

public sealed class NoticeService : INoticeService, ITransient
{
    public NoticeService()
    {

    }

    public Task<ApiResult> HandleAsync(ApiData data)
    {
        return Task.FromResult(ApiResult.Ok());
    }
}
