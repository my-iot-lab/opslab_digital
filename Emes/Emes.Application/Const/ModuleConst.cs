namespace Emes.Application;

/// <summary>
/// 模块定义常量。
/// </summary>
public sealed class ModuleConst
{
    /// <summary>
    /// API分组名称--主数据。
    /// 包含 物料信息 等。
    /// </summary>
    public const string Master = "主数据";

    /// <summary>
    /// API分组名称--工艺管理。
    /// </summary>
    public const string Process = "工艺管理";

    /// <summary>
    /// API分组名称--生产管理。
    /// 包含 工单派发、生产进度追踪等。
    /// </summary>
    public const string Production = "生产管理";

    /// <summary>
    /// API分组名称--质量管理。
    /// <para>包含 等。</para>
    /// </summary>
    public const string Quality = "质量管理";

    /// <summary>
    /// API分组名称--设备管理。
    /// <para>包含 设备维护、设备点检等。</para>
    /// </summary>
    public const string Equipment = "设备管理";

    /// <summary>
    /// API分组名称--SOP 管理。
    /// <para>包含 工艺文档配置、产线终端显示等。</para>
    /// </summary>
    public const string SOP = "SOP 管理";

    /// <summary>
    /// API分组名称--安灯管理。
    /// <para>包含 安灯预警、异常类型、生产异常上报、物料异常上报等。</para>
    /// </summary>
    public const string Andon = "安灯管理";

    /// <summary>
    /// API分组名称--其他。
    /// </summary>
    public const string Others = "其他";
}
