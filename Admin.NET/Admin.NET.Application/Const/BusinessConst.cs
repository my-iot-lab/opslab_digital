namespace Admin.NET.Application.Const;

/// <summary>
/// 业务数据常量
/// </summary>
public sealed class BusinessConst
{
    /// <summary>
    /// API分组名称
    /// </summary>
    public const string GroupName = "我的业务";

    /// <summary>
    /// 数据库标识
    /// </summary>
    public const string ConfigId = "Business";

    /// <summary>
    /// API分组名称--主数据。
    /// </summary>
    public const string MasterModule = "主数据";

    /// <summary>
    /// API分组名称--工艺管理。
    /// </summary>
    public const string ProcessModule = "工艺管理";

    /// <summary>
    /// API分组名称--生产管理。
    /// 包含 工单派发、生产进度追踪等。
    /// </summary>
    public const string ProductionModule = "生产管理";

    /// <summary>
    /// API分组名称--质量管理。
    /// <para>包含 等。</para>
    /// </summary>
    public const string QualityModule = "质量管理";

    /// <summary>
    /// API分组名称--设备管理。
    /// <para>包含 设备维护、异常时间管理等。</para>
    /// </summary>
    public const string EquipmentModule = "设备管理";

    /// <summary>
    /// API分组名称--SOP 管理。
    /// <para>包含 工艺文档配置、产线终端显示等。</para>
    /// </summary>
    public const string SOPModule = "SOP 管理";

    /// <summary>
    /// API分组名称--安灯管理。
    /// <para>包含 安灯预警、异常类型、生产异常上报、物料异常上报等。</para>
    /// </summary>
    public const string AndonModule = "安灯管理";

    /// <summary>
    /// API分组名称--其他。
    /// </summary>
    public const string OthersModule = "其他";
}
