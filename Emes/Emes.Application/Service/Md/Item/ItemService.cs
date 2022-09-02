namespace Emes.Application.Service;

/// <summary>
/// 物料信息服务。
/// </summary>
[ApiDescriptionSettings(Order = 192)]
[Route("md/item")]
public sealed class ItemService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<MdItem> _itemRep;

    public ItemService(SqlSugarRepository<MdItem> itemRep)
	{
        _itemRep = itemRep;
    }

    /// <summary>
    /// 获取产品/物料
    /// </summary>
    /// <returns></returns>
    public async Task<MdItem> GetItem(long id)
    {
        return await _itemRep.GetFirstAsync(u => u.Id == id);
    }

    /// <summary>
    /// 获取产品/物料分页列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("page")]
    public async Task<SqlSugarPagedList<MdItem>> GetUserPage([FromQuery] PageItemInput input)
    {
        return await _itemRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code), u => u.Code.Contains(input.Code!))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name!))
            .WhereIF(input.Attr != null, u => u.Attr == input.Attr)
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 新增产品/物料
    /// </summary>
    /// <returns></returns>
    public async Task AddItem(AddItemInput input)
    {
        var isExist = await _itemRep.IsAnyAsync(u => u.Code == input.Code);
        if (isExist) 
            throw Oops.Oh(BizErrorCodeEnum.E1000);

        var user = input.Adapt<MdItem>();
        await _itemRep.InsertAsync(user);
    }

    /// <summary>
    /// 更新产品/物料
    /// </summary>
    /// <returns></returns>
    public async Task UpdateItem(UpdateItemInput input)
    {
        var isExist = await _itemRep.IsAnyAsync(u => u.Code == input.Code && u.Id != input.Id);
        if (isExist)
            throw Oops.Oh(BizErrorCodeEnum.E1000);

        await _itemRep.AsUpdateable(input.Adapt<MdItem>()).IgnoreColumns(true)
                .IgnoreColumns(u => new { u.Code, u.Attr }).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除产品/物料
    /// </summary>
    /// <returns></returns>
    public async Task DeleteItem(DeleteItemInput input)
    {
        var item = await _itemRep.GetFirstAsync(u => u.Id == input.Id);
        if (item == null)
            throw Oops.Oh(BizErrorCodeEnum.E1001);

        await _itemRep.DeleteAsync(item);
    }
}
