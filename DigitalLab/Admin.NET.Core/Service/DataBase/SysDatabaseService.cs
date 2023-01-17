﻿namespace Admin.NET.Core.Service;

/// <summary>
/// 系统数据库管理服务
/// </summary>
[ApiDescriptionSettings(Order = 145)]
public class SysDatabaseService : IDynamicApiController, ITransient
{
    private readonly ISqlSugarClient _db;
    private readonly IViewEngine _viewEngine;
    private readonly CodeGenOptions _codeGenOptions;

    public SysDatabaseService(ISqlSugarClient db,
        IViewEngine viewEngine,
        IOptions<CodeGenOptions> codeGenOptions)
    {
        _db = db;
        _viewEngine = viewEngine;
        _codeGenOptions = codeGenOptions.Value;
    }

    /// <summary>
    /// 获取库列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/sysDatabase/list")]
    public List<dynamic> GetDbList()
    {
        return App.GetOptions<DbConnectionOptions>().ConnectionConfigs.Select(u => u.ConfigId).ToList();
    }

    /// <summary>
    /// 获取字段列表
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="configId">ConfigId</param>
    /// <returns></returns>
    [HttpGet("/sysDatabase/columnList")]
    [AllowAnonymous]
    public List<DbColumnOutput> GetColumnList(string tableName, string configId = SqlSugarConst.ConfigId)
    {
        var db = _db.AsTenant().GetConnectionScope(configId);
        if (string.IsNullOrWhiteSpace(tableName))
            return new List<DbColumnOutput>();

        return db.DbMaintenance.GetColumnInfosByTableName(tableName, false).Adapt<List<DbColumnOutput>>();
    }

    /// <summary>
    /// 增加列
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/addColumn")]
    public void AddColumn(DbColumnInput input)
    {
        var column = new DbColumnInfo
        {
            ColumnDescription = input.ColumnDescription,
            DbColumnName = input.DbColumnName,
            IsIdentity = input.IsIdentity == 1,
            IsNullable = input.IsNullable == 1,
            IsPrimarykey = input.IsPrimarykey == 1,
            Length = input.Length,
            DecimalDigits = input.DecimalDigits,
            DataType = input.DataType
        };
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        db.DbMaintenance.AddColumn(input.TableName, column);
        db.DbMaintenance.AddColumnRemark(input.DbColumnName, input.TableName, input.ColumnDescription);
        if (column.IsPrimarykey)
            db.DbMaintenance.AddPrimaryKey(input.TableName, input.DbColumnName);
    }

    /// <summary>
    /// 删除列
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/deleteColumn")]
    public void DeleteColumn(DeleteDbColumnInput input)
    {
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        db.DbMaintenance.DropColumn(input.TableName, input.DbColumnName);
    }

    /// <summary>
    /// 编辑列
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/updateColumn")]
    public void UpdateColumn(UpdateDbColumnInput input)
    {
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        db.DbMaintenance.RenameColumn(input.TableName, input.OldColumnName, input.ColumnName);
        if (db.DbMaintenance.IsAnyColumnRemark(input.ColumnName, input.TableName))
            db.DbMaintenance.DeleteColumnRemark(input.ColumnName, input.TableName);
        db.DbMaintenance.AddColumnRemark(input.ColumnName, input.TableName, string.IsNullOrWhiteSpace(input.Description) ? input.ColumnName : input.Description);
    }

    /// <summary>
    /// 获取表列表
    /// </summary>
    /// <param name="configId">ConfigId</param>
    /// <returns></returns>
    [HttpGet("/sysDatabase/tableList")]
    public List<DbTableInfo> GetTableList(string configId = SqlSugarConst.ConfigId)
    {
        var db = _db.AsTenant().GetConnectionScope(configId);
        return db.DbMaintenance.GetTableInfoList(false);
    }

    /// <summary>
    /// 增加表
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/addTable")]
    public void AddTable(DbTableInput input)
    {
        var columns = new List<DbColumnInfo>();
        if (input.DbColumnInfoList == null || !input.DbColumnInfoList.Any())
            throw Oops.Oh(ErrorCodeEnum.db1000);

        if (input.DbColumnInfoList.GroupBy(q => q.DbColumnName).Any(q => q.Count() > 1))
            throw Oops.Oh(ErrorCodeEnum.db1002);

        var config = App.GetOptions<DbConnectionOptions>().ConnectionConfigs.FirstOrDefault(u => u.ConfigId == input.ConfigId);

        input.DbColumnInfoList.ForEach(m =>
        {
            columns.Add(new DbColumnInfo
            {
                DbColumnName = config.EnableUnderLine ? UtilMethods.ToUnderLine(m.DbColumnName.Trim()) : m.DbColumnName.Trim(),
                DataType = m.DataType,
                Length = m.Length,
                ColumnDescription = m.ColumnDescription,
                IsNullable = m.IsNullable == 1,
                IsIdentity = m.IsIdentity == 1,
                IsPrimarykey = m.IsPrimarykey == 1,
                DecimalDigits = m.DecimalDigits
            });
        });
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        db.DbMaintenance.CreateTable(input.TableName, columns, false);

        if (columns.Any(m => m.IsPrimarykey))
            db.DbMaintenance.AddPrimaryKey(input.TableName, columns.FirstOrDefault(m => m.IsPrimarykey).DbColumnName);

        if (db.CurrentConnectionConfig.DbType == SqlSugar.DbType.Sqlite || db.CurrentConnectionConfig.DbType == SqlSugar.DbType.MySql)
            return;
        db.DbMaintenance.AddTableRemark(input.TableName, input.Description);
        input.DbColumnInfoList.ForEach(m =>
        {
            m.DbColumnName = config.EnableUnderLine ? UtilMethods.ToUnderLine(m.DbColumnName) : m.DbColumnName;
            db.DbMaintenance.AddColumnRemark(m.DbColumnName, input.TableName, string.IsNullOrWhiteSpace(m.ColumnDescription) ? m.DbColumnName : m.ColumnDescription);
        });
    }

    /// <summary>
    /// 删除表
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/deleteTable")]
    public void DeleteTable(DeleteDbTableInput input)
    {
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        db.DbMaintenance.DropTable(input.TableName);
    }

    /// <summary>
    /// 编辑表
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/updateTable")]
    public void UpdateTable(UpdateDbTableInput input)
    {
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        db.DbMaintenance.RenameTable(input.OldTableName, input.TableName);
        if (db.DbMaintenance.IsAnyTableRemark(input.TableName))
            db.DbMaintenance.DeleteTableRemark(input.TableName);
        db.DbMaintenance.AddTableRemark(input.TableName, input.Description);
    }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="input"></param>
    [HttpPost("/sysDatabase/createEntity")]
    public void CreateEntity(CreateEntityInput input)
    {
        input.Position = string.IsNullOrWhiteSpace(input.Position) ? "Admin.NET.Application" : input.Position;
        input.EntityName = (input.EntityName == input.TableName && input.EntityName.Contains('_')) ? CodeGenUtil.CamelColumnName(input.EntityName, null) : input.EntityName;
        string[] dbColumnNames = _codeGenOptions.EntityBaseColumn[input.BaseClassName];

        var templatePath = GetEntityTemplatePath();
        var targetPath = GetEntityTargetPath(input);
        var db = _db.AsTenant().GetConnectionScope(input.ConfigId);
        DbTableInfo dbTableInfo = db.DbMaintenance.GetTableInfoList(false).FirstOrDefault(m => m.Name == input.TableName);
        if (dbTableInfo == null)
            throw Oops.Oh(ErrorCodeEnum.db1001);

        List<DbColumnInfo> dbColumnInfos = db.DbMaintenance.GetColumnInfosByTableName(input.TableName, false);
        dbColumnInfos.ForEach(m =>
        {
            m.DbColumnName = CodeGenUtil.CamelColumnName(m.DbColumnName, dbColumnNames);
            m.DataType = CodeGenUtil.ConvertDataType(m);
        });
        if (_codeGenOptions.BaseEntityNames.Contains(input.BaseClassName, StringComparer.OrdinalIgnoreCase))
            dbColumnInfos = dbColumnInfos.Where(c => !dbColumnNames.Contains(c.DbColumnName, StringComparer.OrdinalIgnoreCase)).ToList();

        var tContent = File.ReadAllText(templatePath);
        var tResult = _viewEngine.RunCompileFromCached(tContent, new
        {
            NameSpace = $"{input.Position}.Entity",
            input.TableName,
            input.EntityName,
            BaseClassName = string.IsNullOrWhiteSpace(input.BaseClassName) ? "" : $" : {input.BaseClassName}",
            input.ConfigId,
            dbTableInfo.Description,
            TableField = dbColumnInfos
        });
        File.WriteAllText(targetPath, tResult, Encoding.UTF8);
    }

    /// <summary>
    /// 获取实体模板文件路径
    /// </summary>
    /// <returns></returns>
    private static string GetEntityTemplatePath()
    {
        var templatePath = App.WebHostEnvironment.WebRootPath + @"\Template\";
        return Path.Combine(templatePath, "Entity.cs.vm");
    }

    /// <summary>
    /// 设置生成实体文件路径
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static string GetEntityTargetPath(CreateEntityInput input)
    {
        var backendPath = Path.Combine(new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.FullName, input.Position, "Entity");
        return Path.Combine(backendPath, input.EntityName + ".cs");
    }
}