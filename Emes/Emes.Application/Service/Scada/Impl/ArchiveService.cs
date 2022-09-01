namespace Emes.Application.Service;

public sealed class ArchiveService : IArchiveService, ITransient
{
    public ArchiveService()
    {
    }

    public async Task<ApiResult> HandleAsync(ApiData data)
    {
        await Task.Delay(100); // test

        var sn = data.GetValue<string>(PlcSymbolTag.PLC_Archive_SN);
        var pass = data.GetValue<int>(PlcSymbolTag.PLC_Archive_Pass);
        var ct = data.GetValue<int>(PlcSymbolTag.PLC_Archive_Cycletime);
        var @operator = data.GetValue<string>(PlcSymbolTag.PLC_Archive_Operator);
        var shift = data.GetValue<int>(PlcSymbolTag.PLC_Archive_Shift);
        var pallet = data.GetValue<string>(PlcSymbolTag.PLC_Archive_Pallet);

        if (string.IsNullOrWhiteSpace(sn))
        {
            return ApiResult.Error();
        }

        // 记录进站信息
        try
        {
            // 按位解析

            // 主数据

            // 明细数据
            foreach (var item in data.Values.Where(s => s.IsAdditional))
            {
               
            }

            // 工站状态统计

            return ApiResult.Ok();
        }
        catch(Exception ex)
        {
            return ApiResult.Error(ex.Message);
        }
    }
}
