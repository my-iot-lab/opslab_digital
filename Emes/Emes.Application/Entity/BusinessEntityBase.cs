namespace Emes.Application.Entity;

/// <summary>
/// 业务实体基类 Id，采用 Business 数据库。
/// </summary>
[Tenant(BusinessConst.ConfigId)]
public abstract class BizEntityBaseId : EntityBaseId
{

}

/// <summary>
/// 业务框架实体基类，采用 Business 数据库。
/// </summary>
[Tenant(BusinessConst.ConfigId)]
public abstract class BizEntityBase : EntityBase
{

}

/// <summary>
/// 业务租户实体基类，采用 Business 数据库。
/// </summary>
[Tenant(BusinessConst.ConfigId)]
public abstract class BizEntityTenant : EntityTenant
{

}
