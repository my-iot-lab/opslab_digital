using DbType = SqlSugar.DbType;

namespace Emes.Core.Util;

/// <summary>
/// 代码生成帮助类
/// </summary>
public static class CodeGenUtil
{
    // 根据数据库类型来处理对应的数据字段类型
    public static string ConvertDataType(string dataType)
    {
        var dbType = App.GetOptions<DbConnectionOptions>().ConnectionConfigs[0].DbType;
        return dbType switch
        {
            DbType.PostgreSQL => ConvertDataType_PostgreSQL(dataType),
            _ => ConvertDataType_Default(dataType),
        };
    }

    //PostgreSQL数据类型对应的字段类型
    public static string ConvertDataType_PostgreSQL(string dataType)
    {
        return dataType switch
        {
            "int2" or "smallint" => "Int16",
            "int4" or "integer" => "int",
            "int8" or "bigint" => "long",
            "float4" or "real" => "float",
            "float8" or "double precision" => "double",
            "numeric" or "decimal" or "path" or "point" or "polygon" or "interval" or "lseg" or "macaddr" or "money" => "decimal",
            "boolean" or "bool" or "box" or "bytea" => "bool",
            "varchar" or "character varying" or "geometry" or "name" or "text" or "char" or "character" 
                or "cidr" or "circle" or "tsquery" or "tsvector" or "txid_snapshot" or "xml" or "json" => "string",
            "uuid" => "Guid",
            "timestamp" or "timestamp with time zone" or "timestamptz" or "timestamp without time zone" 
                or "date" or "time" or "time with time zone" or "timetz" or "time without time zone" => "DateTime",
            "bit" or "bit varying" => "byte[]",
            "varbit" => "byte",
            "public.geometry" or "inet" => "object",
            _ => "object",
        };
    }

    public static string ConvertDataType_Default(string dataType)
    {
        return dataType switch
        {
            "text" or "varchar" or "char" or "nvarchar" or "nchar" or "timestamp" => "string",
            "int" => "int",
            "smallint" => "Int16",
            "tinyint" => "byte",
            "bigint" or "integer" => "long",
            "bit" => "bool",
            "money" or "smallmoney" or "numeric" or "decimal" => "decimal",
            "real" => "Single",
            "datetime" or "smalldatetime" => "DateTime",
            "float" => "double",
            "image" or "binary" or "varbinary" => "byte[]",
            "uniqueidentifier" => "Guid",
            _ => "object",
        };
    }

    /// <summary>
    /// 数据类型转显示类型
    /// </summary>
    /// <param name="dataType"></param>
    /// <returns></returns>
    public static string DataTypeToEff(string dataType)
    {
        if (string.IsNullOrEmpty(dataType)) 
            return "";

        return dataType switch
        {
            "string" => "Input",
            "int" => "InputNumber",
            "long" => "Input",
            "float" => "Input",
            "double" => "Input",
            "decimal" => "Input",
            "bool" => "Switch",
            "Guid" => "Input",
            "DateTime" => "DatePicker",
            _ => "Input",
        };
    }

    // 是否通用字段
    public static bool IsCommonColumn(string columnName)
    {
        var columnList = new string[]
        {
            "CreateTime", "UpdateTime", "CreateUserId", "UpdateUserId", "IsDelete"
        };
        return columnList.Contains(columnName);
    }
}