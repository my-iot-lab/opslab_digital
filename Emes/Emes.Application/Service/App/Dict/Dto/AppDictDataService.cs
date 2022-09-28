namespace Emes.Application.Service;

/// <summary>
/// 业务字典值服务
/// </summary>
[ApiDescriptionSettings(Order = 191)]
[AllowAnonymous]
public sealed class AppDictDataService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<AppDictData> _appDictDataRep;

    public AppDictDataService(SqlSugarRepository<AppDictData> appDictDataRep)
    {
        _appDictDataRep = appDictDataRep;
    }

    /// <summary>
    /// 获取字典值分页列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("/appDictData/page")]
    public async Task<SqlSugarPagedList<AppDictData>> GetDictDataPage([FromQuery] AppPageDictDataInput input)
    {
        return await _appDictDataRep.AsQueryable()
            .Where(u => u.DictTypeId == input.DictTypeId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code), u => u.Code!.Contains(input.Code!))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Value), u => u.Code!.Contains(input.Value!))
            .OrderBy(u => u.Order)
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 获取字典值列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/appDictData/list")]
    public async Task<List<AppDictData>> GetDictDataList([FromQuery] AppGetDataDictDataInput input)
    {
        return await GetDictDataListByDictTypeId(input.DictTypeId);
    }

    /// <summary>
    /// 增加字典值
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictData/add")]
    public async Task AddDictData(AppAddDictDataInput input)
    {
        var isExist = await _appDictDataRep.IsAnyAsync(u => (u.Code == input.Code || u.Value == input.Value) && u.DictTypeId == input.DictTypeId);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D3003);

        await _appDictDataRep.InsertAsync(input.Adapt<AppDictData>());
    }

    /// <summary>
    /// 更新字典值
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictData/update")]
    public async Task UpdateDictData(AppUpdateDictDataInput input)
    {
        var isExist = await _appDictDataRep.IsAnyAsync(u => u.Id == input.Id);
        if (!isExist) 
            throw Oops.Oh(ErrorCodeEnum.D3004);

        isExist = await _appDictDataRep.IsAnyAsync(u => (u.Value == input.Value || u.Code == input.Code) && u.DictTypeId == input.DictTypeId && u.Id != input.Id);
        if (isExist) 
            throw Oops.Oh(ErrorCodeEnum.D3003);

        await _appDictDataRep.UpdateAsync(input.Adapt<AppDictData>());
    }

    /// <summary>
    /// 获取字典值详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("/appDictData/detail")]
    public async Task<AppDictData> GetDictData([FromQuery] AppDictDataInput input)
    {
        return await _appDictDataRep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 删除字典值
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictData/delete")]
    public async Task DeleteDictData(AppDeleteDictDataInput input)
    {
        var dictData = await _appDictDataRep.GetFirstAsync(u => u.Id == input.Id);
        if (dictData == null)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _appDictDataRep.DeleteAsync(dictData);
    }

    /// <summary>
    /// 修改字典值状态
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("/appDictData/changeStatus")]
    public async Task ChangeDictDataStatus(AppChageStatusDictDataInput input)
    {
        var dictData = await _appDictDataRep.GetFirstAsync(u => u.Id == input.Id);
        if (dictData == null)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        if (!Enum.IsDefined(typeof(StatusEnum), input.Status))
            throw Oops.Oh(ErrorCodeEnum.D3005);

        dictData.Status = (StatusEnum)input.Status;
        await _appDictDataRep.UpdateAsync(dictData);
    }

    /// <summary>
    /// 根据字典类型Id获取字典值集合
    /// </summary>
    /// <param name="dictTypeId"></param>
    /// <returns></returns>
    [NonAction]
    public async Task<List<AppDictData>> GetDictDataListByDictTypeId(long dictTypeId)
    {
        return await _appDictDataRep.AsQueryable()
            .Where(u => u.DictTypeId == dictTypeId)
            .OrderBy(u => u.Order).ToListAsync();
    }

    /// <summary>
    /// 根据字典唯一编码获取下拉框集合
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [HttpGet("/appDictData/DictDataDropdown/{code}")]
    public async Task<dynamic> GetDictDataDropdown(string code)
    {
        return await _appDictDataRep.Context.Queryable<AppDictType, AppDictData>((a, b) =>
            new JoinQueryInfos(JoinType.Left, a.Id == b.DictTypeId))
            .Where(a => a.Code == code)
            .Where((a, b) => a.Status == StatusEnum.Enable && b.Status == StatusEnum.Enable)
            .Select((a, b) => new
            {
                Label = b.Value,
                Value = b.Code
            }).ToListAsync();
    }

    /// <summary>
    /// 根据条件查询字典获取下拉框集合
    /// </summary>
    /// <param name="input">查询参数</param>
    /// <returns></returns>
    [HttpGet("/appDictData/queryDictDataDropdown")]
    public async Task<dynamic> QueryDictDataDropdown([FromQuery] AppQueryDictDataInput input)
    {
        return await _appDictDataRep.Context.Queryable<AppDictType, AppDictData>((a, b) =>
            new JoinQueryInfos(JoinType.Left, a.Id == b.DictTypeId))
            .Where((a, b) => a.Code == input.Code)
            .WhereIF(input.Status.HasValue, (a, b) => b.Status == (StatusEnum)input.Status!.Value)
            .Select((a, b) => new
            {
                Label = b.Value,
                Value = b.Code
            }).ToListAsync();
    }
}
