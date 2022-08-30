namespace Emes.Core;

/// <summary>
/// 系统租户表种子数据
/// </summary>
public class SysTenantSeedData : ISqlSugarEntitySeedData<SysTenant>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysTenant> HasData()
    {
        return new[]
        {
            new SysTenant{ Id=142307070918780, Name="租户1", AdminName="admin1", Host="www.dilon.vip", Email="", Phone="15800000000", Connection="", Remark="租户1", CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
            new SysTenant{ Id=142307070918781, Name="租户2", AdminName="admin2", Host="www.dilon.top", Email="", Phone="15800000000", Connection="", Remark="租户2", CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
        };
    }
}