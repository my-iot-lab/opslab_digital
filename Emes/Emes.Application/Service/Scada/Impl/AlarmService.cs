namespace Emes.Application.Service;

public sealed class AlarmService : IAlarmService, ITransient
{
    public AlarmService()
    {
    }

    public async Task<ApiResult> HandleAsync(ApiData data)
    {
        await Task.Delay(100); // test

        if (data.Values.Length == 0)
        {
            return ApiResult.Ok();
        }

        var alarmValues = data.Values[0].GetValue<bool[]>(); // 警报数据
        try
        {
            for (int i = 0; i < alarmValues!.Length; i++)
            {
                if (alarmValues[i])
                {
                    // DoSomething...
                }
            }
        }
        catch (Exception ex)
        {
            return ApiResult.Error(ex.Message);
        }

        return ApiResult.Ok();
    }
}
