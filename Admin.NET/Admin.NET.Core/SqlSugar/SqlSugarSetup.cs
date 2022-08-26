using System.Reflection;
using DbType = SqlSugar.DbType;

namespace Admin.NET.Core;

public static class SqlSugarSetup
{
    /// <summary>
    /// Sqlsugar 上下文初始化
    /// </summary>
    /// <param name="services"></param>
    public static void AddSqlSugarSetup(this IServiceCollection services)
    {
        var dbOptions = App.GetOptions<DbConnectionOptions>();
        var configureExternalServices = new ConfigureExternalServices
        {
            EntityService = (type, column) => // 修改列可空-1、带?问号 2、String类型若没有Required
            {
                if ((type.PropertyType.IsGenericType && type.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    || (type.PropertyType == typeof(string) && type.GetCustomAttribute<RequiredAttribute>() == null))
                    column.IsNullable = true;
            }
        };
        dbOptions.ConnectionConfigs.ForEach(config =>
        {
            config.ConfigureExternalServices = configureExternalServices;
        });

        SqlSugarScope sqlSugar = new(dbOptions.ConnectionConfigs, db =>
        {
            dbOptions.ConnectionConfigs.ForEach(config =>
            {
                var dbProvider = db.GetConnectionScope((string)config.ConfigId);

                // 设置超时时间
                dbProvider.Ado.CommandTimeOut = 30;

#if DEBUG
                // 打印SQL语句
                dbProvider.Aop.OnLogExecuting = (sql, pars) =>
                {

                    if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                        Console.ForegroundColor = ConsoleColor.White;
                    if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("【" + DateTime.Now + "——执行SQL】\r\n" + UtilMethods.GetSqlString(config.DbType, sql, pars) + "\r\n");
                    App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));

                };

                dbProvider.Aop.OnError = (ex) =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                    Console.WriteLine("【" + DateTime.Now + "——错误SQL】\r\n" + UtilMethods.GetSqlString(config.DbType, ex.Sql, (SugarParameter[])ex.Parametres) + "\r\n");
                    App.PrintToMiniProfiler("SqlSugar", "Error", $"{ex.Message}{Environment.NewLine}{ex.Sql}{pars}{Environment.NewLine}");
                };
#endif

                // 数据审计
                dbProvider.Aop.DataExecuting = (oldValue, entityInfo) =>
                {
                    // 新增操作
                    if (entityInfo.OperationType == DataFilterType.InsertByObject)
                    {
                        // 主键(long类型)且没有值的---赋值雪花Id
                        if (entityInfo.EntityColumnInfo.IsPrimarykey && entityInfo.EntityColumnInfo.PropertyInfo.PropertyType == typeof(long))
                        {
                            var id = entityInfo.EntityColumnInfo.PropertyInfo.GetValue(entityInfo.EntityValue);
                            if (id == null || (long)id == 0)
                                entityInfo.SetValue(Yitter.IdGenerator.YitIdHelper.NextId());
                        }

                        if (entityInfo.PropertyName == "CreateTime")
                            entityInfo.SetValue(DateTime.Now);

                        if (App.User != null)
                        {
                            if (entityInfo.PropertyName == "TenantId")
                            {
                                var tenantId = ((dynamic)entityInfo.EntityValue).TenantId;
                                if (tenantId == null || tenantId == 0)
                                    entityInfo.SetValue(App.User.FindFirst(ClaimConst.TenantId)?.Value);
                            }
                            if (entityInfo.PropertyName == "CreateUserId")
                                entityInfo.SetValue(App.User.FindFirst(ClaimConst.UserId)?.Value);
                            if (entityInfo.PropertyName == "CreateOrgId")
                                entityInfo.SetValue(App.User.FindFirst(ClaimConst.OrgId)?.Value);
                        }
                    }

                    // 更新操作
                    if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                    {
                        if (entityInfo.PropertyName == "UpdateTime")
                            entityInfo.SetValue(DateTime.Now);
                        if (entityInfo.PropertyName == "UpdateUserId")
                            entityInfo.SetValue(App.User?.FindFirst(ClaimConst.UserId)?.Value);
                    }
                };

                // 差异日志
                dbProvider.Aop.OnDiffLogEvent = async u =>
                {
                    if (!dbOptions.EnableDiffLog) 
                        return;

                    var LogDiff = new SysLogDiff
                    {
                        // 操作后记录（字段描述、列名、值、表名、表描述）
                        AfterData = JsonConvert.SerializeObject(u.AfterData),
                        // 操作前记录（字段描述、列名、值、表名、表描述）
                        BeforeData = JsonConvert.SerializeObject(u.BeforeData),
                        // 传进来的对象
                        BusinessData = JsonConvert.SerializeObject(u.BusinessData),
                        // 枚举（insert、update、delete）
                        DiffType = u.DiffType.ToString(),
                        Sql = UtilMethods.GetSqlString(config.DbType, u.Sql, u.Parameters),
                        Parameters = JsonConvert.SerializeObject(u.Parameters),
                        Duration = u.Time == null ? 0 : (long)u.Time.Value.TotalMilliseconds
                    };
                    await db.GetConnectionScope(SqlSugarConst.ConfigId).Insertable(LogDiff).ExecuteCommandAsync();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now + $"\r\n**********差异日志开始**********\r\n{Environment.NewLine}{JsonConvert.SerializeObject(LogDiff)}{Environment.NewLine}**********差异日志结束**********\r\n");
                };

                // 配置实体假删除过滤器
                SetDeletedEntityFilter(dbProvider);
                // 配置实体机构过滤器
                SetOrgEntityFilter(dbProvider);
                // 配置自定义实体过滤器
                SetCustomEntityFilter(dbProvider);
                // 配置租户实体过滤器
                SetTenantEntityFilter(dbProvider);
            });
        });

        // 初始化数据库结构及种子数据
        if (dbOptions.EnableInitTable)
            InitDataBase(sqlSugar, dbOptions);

        services.AddSingleton<ISqlSugarClient>(sqlSugar); // 单例注册
        services.AddScoped(typeof(SqlSugarRepository<>)); // 注册仓储
        services.AddUnitOfWork<SqlSugarUnitOfWork>(); // 注册事务与工作单元
    }

    /// <summary>
    /// 初始化数据库结构
    /// </summary>
    public static void InitDataBase(SqlSugarScope db, DbConnectionOptions dbOptions)
    {
        // 创建数据库
        dbOptions.ConnectionConfigs.ForEach(config =>
        {
            if (config.DbType != DbType.Oracle)
                db.GetConnectionScope(config.ConfigId).DbMaintenance.CreateDatabase();
        });

        // 获取所有实体表
        var entityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
            && u.IsDefined(typeof(SugarTable), false) && !u.IsDefined(typeof(NotTableAttribute), false));
        if (!entityTypes.Any()) 
            return;

        // 初始化库表结构
        foreach (var entityType in entityTypes)
        {
            var tAtt = entityType.GetCustomAttribute<TenantAttribute>();
            var provider = db.GetConnectionScope(tAtt == null ? SqlSugarConst.ConfigId : tAtt.configId); // 没有设置会使用默认数据库标识
            provider.CodeFirst.InitTables(entityType);
        }

        // 获取所有实体种子数据
        var seedDataTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
            && u.GetInterfaces().Any(i => i.HasImplementedRawGeneric(typeof(ISqlSugarEntitySeedData<>))));
        if (!seedDataTypes.Any()) 
            return;

        foreach (var seedType in seedDataTypes)
        {
            var instance = Activator.CreateInstance(seedType);

            var hasDataMethod = seedType.GetMethod("HasData");
            var seedData = ((IEnumerable)hasDataMethod?.Invoke(instance, null))?.Cast<object>();
            if (seedData == null) 
                continue;

            var entityType = seedType.GetInterfaces().First().GetGenericArguments().First();
            var tAtt = entityType.GetCustomAttribute<TenantAttribute>();
            var provider = db.GetConnectionScope(tAtt == null ? SqlSugarConst.ConfigId : tAtt.configId);

            var seedDataTable = seedData.ToList().ToDataTable();
            seedDataTable.TableName = db.EntityMaintenance.GetEntityInfo(entityType).DbTableName;
            if (seedDataTable.Columns.Contains(SqlSugarConst.PrimaryKey))
            {
                var storage = provider.Storageable(seedDataTable).WhereColumns(SqlSugarConst.PrimaryKey).ToStorage();
                // 如果添加一条种子数，sqlsugar 默认以 @param 的方式赋值，如果 PropertyType 为空，则默认数据类型为字符串。插入 pgsql 时候会报错，所以要忽略为空的值添加
                _ = ((InsertableProvider<Dictionary<string, object>>)storage.AsInsertable).IsSingle ?
                    storage.AsInsertable.IgnoreColumns("UpdateTime", "UpdateUserId", "CreateUserId").ExecuteCommand() :
                    storage.AsInsertable.ExecuteCommand();
                storage.AsUpdateable.ExecuteCommand();
            }
            else // 没有主键或者不是预定义的主键(没主键有重复的可能)
            {
                var storage = provider.Storageable(seedDataTable).ToStorage();
                storage.AsInsertable.ExecuteCommand();
            }
        }
    }

    /// <summary>
    /// 配置实体假删除过滤器
    /// </summary>
    public static void SetDeletedEntityFilter(SqlSugarScopeProvider db)
    {
        // 获取所有继承基类数据表集合
        var entityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass && typeof(EntityBase).IsAssignableFrom(u));
        if (!entityTypes.Any()) 
            return;

        foreach (var entityType in entityTypes)
        {
            Expression<Func<EntityBase, bool>> dynamicExpression = u => u.IsDelete == false;
            db.QueryFilter.Add(new TableFilterItem<object>(entityType, dynamicExpression));
        }
    }

    /// <summary>
    /// 配置实体机构过滤器
    /// </summary>
    public static async void SetOrgEntityFilter(SqlSugarScopeProvider db)
    {
        // 获取业务数据表集合
        var dataEntityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass && typeof(DataEntityBase).IsAssignableFrom(u));
        if (!dataEntityTypes.Any()) 
            return;

        var userId = App.User?.FindFirst(ClaimConst.UserId)?.Value;
        if (string.IsNullOrWhiteSpace(userId)) 
            return;

        // 获取用户机构Id集合
        var orgIds = await App.GetService<SysCacheService>().GetOrgIdList(long.Parse(userId));
        if (orgIds == null || orgIds.Count == 0) 
            return;

        foreach (var dataEntityType in dataEntityTypes)
        {
            Expression<Func<DataEntityBase, bool>> dynamicExpression = u => orgIds.Contains((long)u.CreateOrgId);
            db.QueryFilter.Add(new TableFilterItem<object>(dataEntityType, dynamicExpression));
        }
    }

    /// <summary>
    /// 配置自定义实体过滤器
    /// </summary>
    public static void SetCustomEntityFilter(SqlSugarScopeProvider db)
    {
        // 排除超管过滤
        if (App.User?.FindFirst(ClaimConst.SuperAdmin)?.Value == ((int)UserTypeEnum.SuperAdmin).ToString())
            return;

        // 获取继承自定义实体过滤器接口的类集合
        var entityFilterTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
            && u.GetInterfaces().Any(i => i.HasImplementedRawGeneric(typeof(IEntityFilter))));
        if (!entityFilterTypes.Any()) 
            return;

        foreach (var entityFilter in entityFilterTypes)
        {
            var entityFilterMethod = entityFilter.GetMethod("AddEntityFilter");
            if (entityFilterMethod == null)
            {
                continue;
            }

            var instance = Activator.CreateInstance(entityFilter);
            var entityFilters = ((IList)entityFilterMethod.Invoke(instance, null))?.Cast<object>();
            if (entityFilters == null)
            {
                continue;
            }

            foreach (TableFilterItem<object> filter in entityFilters)
            {
                db.QueryFilter.Add(filter);
            }
        }
    }

    /// <summary>
    /// 配置租户实体过滤器
    /// </summary>
    public static void SetTenantEntityFilter(SqlSugarScopeProvider db)
    {
        // 获取租户实体数据表集合
        var dataEntityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass && typeof(EntityTenant).IsAssignableFrom(u));
        if (!dataEntityTypes.Any()) 
            return;

        var tenantId = App.User?.FindFirst(ClaimConst.TenantId)?.Value;
        if (string.IsNullOrWhiteSpace(tenantId)) 
            return;

        foreach (var dataEntityType in dataEntityTypes)
        {
            Expression<Func<EntityTenant, bool>> dynamicExpression = u => u.TenantId == long.Parse(tenantId);
            db.QueryFilter.Add(new TableFilterItem<object>(dataEntityType, dynamicExpression));
        }
    }
}
