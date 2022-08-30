namespace Admin.NET.Application.SeedData;

/// <summary>
/// 字典配置表种子数据
/// </summary>
internal class DictSeedData : ISqlSugarEntitySeedData<DictData>
{
    public IEnumerable<DictData> HasData()
    {
        return new[]
        {
           new DictData(),
        };
    }
}
