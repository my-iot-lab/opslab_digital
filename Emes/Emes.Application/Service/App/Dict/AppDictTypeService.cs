namespace Emes.Application.Service;

/// <summary>
/// 业务字典类型服务
/// </summary>
[ApiDescriptionSettings(Order = 192)]
public sealed class AppDictTypeService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<AppDictType> _appDictTypeRep;
    private readonly AppDictDataService _appDictDataService;

    public AppDictTypeService(SqlSugarRepository<AppDictType> appDictTypeRep,
       AppDictDataService appDictDataService)
    {
        _appDictTypeRep = appDictTypeRep;
        _appDictDataService = appDictDataService;
    }

    /// <summary>
    /// 获取字典类型分页列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/appDictType/page")]
    public async Task<SqlSugarPagedList<AppDictType>> GetDictTypePage([FromQuery] AppPageDictTypeInput input)
    {
        return await _appDictTypeRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code), u => u.Code!.Contains(input.Code!))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name!.Contains(input.Name!))
            .OrderBy(u => u.Order)
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/appDictType/list")]
    public async Task<List<AppDictType>> GetDictTypeList()
    {
        return await _appDictTypeRep.AsQueryable().OrderBy(u => u.Order).ToListAsync();
    }

    /// <summary>
    /// 获取字典类型-值列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("/appDictType/dataList")]
    [AllowAnonymous]
    public async Task<List<AppDictData>> GetDictTypeDataList([FromQuery] AppGetDataDictTypeInput input)
    {
        var dictType = await _appDictTypeRep.GetFirstAsync(u => u.Code == input.Code);
        if (dictType == null)
            throw Oops.Oh(ErrorCodeEnum.D3000);
        return await _appDictDataService.GetDictDataListByDictTypeId(dictType.Id);
    }

    /// <summary>
    /// 添加字典类型
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictType/add")]
    public async Task AddDictType(AppAddDictTypeInput input)
    {
        var isExist = await _appDictTypeRep.IsAnyAsync(u => u.Name == input.Name || u.Code == input.Code);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D3001);

        await _appDictTypeRep.InsertAsync(input.Adapt<AppDictType>());
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictType/update"),]
    public async Task UpdateDictType(AppUpdateDictTypeInput input)
    {
        var isExist = await _appDictTypeRep.IsAnyAsync(u => u.Id == input.Id);
        if (!isExist)
            throw Oops.Oh(ErrorCodeEnum.D3000);

        isExist = await _appDictTypeRep.IsAnyAsync(u => (u.Name == input.Name || u.Code == input.Code) && u.Id != input.Id);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D3001);

        await _appDictTypeRep.UpdateAsync(input.Adapt<AppDictType>());
    }

    /// <summary>
    /// 获取字典类型详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("/appDictType/detail")]
    public async Task<AppDictType> GetDictType([FromQuery] AppDictTypeInput input)
    {
        return await _appDictTypeRep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictType/delete")]
    public async Task DeleteDictType(AppDeleteDictTypeInput input)
    {
        var dictType = await _appDictTypeRep.GetFirstAsync(u => u.Id == input.Id);
        if (dictType == null)
            throw Oops.Oh(ErrorCodeEnum.D3000);

        await _appDictTypeRep.DeleteAsync(dictType);
    }

    /// <summary>
    /// 修改字典类型状态
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictType/changeStatus")]
    public async Task ChangeDictTypeStatus(AppChangeStatusDictTypeInput input)
    {
        var dictType = await _appDictTypeRep.GetFirstAsync(u => u.Id == input.Id);
        if (dictType == null)
            throw Oops.Oh(ErrorCodeEnum.D3000);

        if (!Enum.IsDefined(typeof(StatusEnum), input.Status))
            throw Oops.Oh(ErrorCodeEnum.D3005);

        dictType.Status = (StatusEnum)input.Status;
        await _appDictTypeRep.UpdateAsync(dictType);
    }
}
