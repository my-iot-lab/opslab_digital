namespace Emes.Application.Service;

public sealed class MaterialService : IMaterialService, ITransient
{
    public MaterialService()
    {

    }

    public async Task<ApiResult> HandleCriticalMaterialAsync(ApiData data)
    {
        await Task.Delay(100);

        var barcode = data.GetValue<string>(PlcVariableTag.PLC_Critical_Material_Barcode);
        var index = data.GetValue<int>(PlcVariableTag.PLC_Critical_Material_Index);
        if (string.IsNullOrWhiteSpace(barcode))
        {
            return ApiResult.Error();
        }

        try
        {
            // 1. 校验物料是否是重复使用
            // 2. 校验 BOM

            return ApiResult.Ok();
        }
        catch (Exception ex)
        {
            return ApiResult.Error(ex.Message);
        }
    }

    public Task<ApiResult> HandleBactchMaterialAsync(ApiData data)
    {
        return Task.FromResult(ApiResult.Ok());
    }
}
