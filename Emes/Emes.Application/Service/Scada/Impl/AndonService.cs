namespace Emes.Application.Service;

public sealed class AndonService : IAndonService, ITransient
{
    public Task HandleAsync(ApiData data)
    {
        return Task.CompletedTask;
    }
}
