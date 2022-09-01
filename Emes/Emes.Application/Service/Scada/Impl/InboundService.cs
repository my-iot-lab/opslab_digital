using Microsoft.Extensions.Logging;

namespace Emes.Application.Service;

public sealed class InboundService : IInboundService, ITransient
{
    private readonly SqlSugarRepository<PtInbound> _inboundRepo;
    private readonly ILogger _logger;

    public InboundService(SqlSugarRepository<PtInbound> inboundRepo,
        ILogger<InboundService> logger)
    {
        _inboundRepo = inboundRepo;
        _logger = logger;
    }

    public async Task<ApiResult> HandleAsync(ApiData data)
    {
        await Task.Delay(100);

        var sn = data.GetValue<string>(PlcVariableTag.PLC_Inbound_SN);
        var formula = data.GetValue<int>(PlcVariableTag.PLC_Inbound_Formula);
        var pallet = data.GetValue<string>(PlcVariableTag.PLC_Inbound_Pallet);
        if (string.IsNullOrWhiteSpace(sn))
        {
            return ApiResult.Error(ErrorCode.ErrEmptyOfSN);
        }
        if (formula == 0)
        {
            return ApiResult.Error(ErrorCode.ErrEmptyOfFormula);
        }

        try
        { 

            return ApiResult.Ok();
        }
        catch (Exception ex)
        {
            return ApiResult.Error(ex.Message);
        }
    }
}
