namespace Emes.Application.Service;

public sealed class AlarmService : IAlarmService, ITransient
{
    public AlarmService()
    {
    }

    public Task HandleAsync(ApiData data)
    {
        if (data.Values.Length == 0)
        {
            return Task.CompletedTask;
        }

        var alarmValues = data.Values[0].GetValue<bool[]>(); // 警报数据
        for (int i = 0; i < alarmValues!.Length; i++)
        {
            if (alarmValues[i])
            {
                // DoSomething...
            }
        }

        return Task.CompletedTask;
    }
}
