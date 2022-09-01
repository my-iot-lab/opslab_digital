namespace Emes.Application;

/// <summary>
/// 状态码，需注意自定义状态码不能冲突。
/// <para>【0】 初始状态/成功处理状态；</para>
/// <para>【1】 数据触发状态；</para>
/// <para>【2】 内部异常统一状态；</para>
/// <para>【400~499】 请求数据异常，如数据为空、类型不对等；</para>
/// <para>【500~599】 内部异常，如超时、崩溃等；</para>
/// <para>【1100~1199】 进站详细状态；</para>
/// <para>【1200~1299】 出站详细状态；</para>
/// <para>【1300~1399】 扫码详细状态；</para>
/// <para>【1400~1499】 其他状态。</para>
/// </summary>
public sealed class ErrorCode
{
    private ErrorCode()
    { }

    /// <summary>
    /// 成功
    /// </summary>
    public const int Success = 1;

    /// <summary>
    /// 程序异常
    /// </summary>
    [Description("MES 程序异常")]
    public const int Error = 2;

    /// <summary>
    /// SN 为空错误
    /// </summary>
    [Description("SN 不能为空")]
    public const int ErrEmptyOfSN = 401;

    /// <summary>
    /// 程序配方号不能为空
    /// </summary>
    [Description("程序配方号不能为空")]
    public const int ErrEmptyOfFormula = 402;

    /// <summary>
    /// Barcode 不能为空
    /// </summary>
    [Description("Barcode 不能为空")]
    public const int ErrEmptyOfBarcode = 403;

    /// <summary>
    /// Barcode 索引不能为空
    /// </summary>
    [Description("Pass 索引不能为空")]
    public const int ErrEmptyOfBarcodeIndex = 404;

    /// <summary>
    /// Pass 结果不能为空
    /// </summary>
    [Description("Pass 结果不能为空")]
    public const int ErrEmptyOfPass = 405;

    /// <summary>
    /// 获取描述
    /// </summary>
    /// <param name="code">错误代码</param>
    /// <returns></returns>
    public static string GetDescription(int code)
    {
        var field = typeof(ErrorCode).GetFields().FirstOrDefault(f => f.FieldType == typeof(int) && (int?)f.GetRawConstantValue() == code);
        if (field != null)
        {
            var attr = field.GetCustomAttribute<DescriptionAttribute>();
            if (attr != null)
            {
                return attr.Description;
            }
        }

        return string.Empty;
    }
}
