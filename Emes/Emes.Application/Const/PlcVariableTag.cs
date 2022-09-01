namespace Emes.Application;

/// <summary>
/// 程序常用变量地址。
/// </summary>
public sealed class PlcVariableTag
{
    /// <summary>
    /// 进站 SN
    /// </summary>
    public const string PLC_Inbound_SN = nameof(PLC_Inbound_SN);

    /// <summary>
    /// 程序配方号
    /// </summary>
    public const string PLC_Inbound_Formula = nameof(PLC_Inbound_Formula);

    /// <summary>
    /// 进站托盘码
    /// </summary>
    public const string PLC_Inbound_Pallet = nameof(PLC_Inbound_Pallet);

    /// <summary>
    /// 出站/存档 SN
    /// </summary>
    public const string PLC_Archive_SN = nameof(PLC_Archive_SN);

    /// <summary>
    /// 出站/存档结果
    /// </summary>
    public const string PLC_Archive_Pass = nameof(PLC_Archive_Pass);

    /// <summary>
    /// 出站/存档 CT
    /// </summary>
    public const string PLC_Archive_Cycletime = nameof(PLC_Archive_Cycletime);

    /// <summary>
    /// 出站/存档操作人
    /// </summary>
    public const string PLC_Archive_Operator = nameof(PLC_Archive_Operator);

    /// <summary>
    /// 出站/存档班次
    /// </summary>
    public const string PLC_Archive_Shift = nameof(PLC_Archive_Shift);

    /// <summary>
    /// 出站/存档托盘
    /// </summary>
    public const string PLC_Archive_Pallet = nameof(PLC_Archive_Pallet);

    /// <summary>
    /// 扫码关键物料 Barcode
    /// </summary>
    public const string PLC_Critical_Material_Barcode = nameof(PLC_Critical_Material_Barcode);

    /// <summary>
    /// 扫码关键物料序号
    /// </summary>
    public const string PLC_Critical_Material_Index = nameof(PLC_Critical_Material_Index);
}
