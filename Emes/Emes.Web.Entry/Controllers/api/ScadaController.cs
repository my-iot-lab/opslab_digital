using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Emes.Application.Service;
using Emes.Application;
using Emes.Application.Utils;

namespace Emes.Web.Entry.Controllers;

/// <summary>
/// SCADA 
/// </summary>
[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class ScadaController : ControllerBase
{
    private readonly IAlarmService _alarmService;
    private readonly IAndonService _andonService;
    private readonly INoticeService _noticeService;
    private readonly IInboundService _inboundService;
    private readonly IArchiveService _archiveService;
    private readonly IMaterialService _materialService;
    private readonly ICustomService _customService;

    public ScadaController(
        IAlarmService alarmService,
        IAndonService andonService,
        INoticeService noticeService,
        IInboundService inboundService,
        IArchiveService archiveService,
        IMaterialService materialService,
        ICustomService customService)
    {
        _alarmService = alarmService;
        _andonService = andonService;
        _noticeService = noticeService;
        _inboundService = inboundService;
        _archiveService = archiveService;
        _materialService = materialService;
        _customService = customService;
    }

    /// <summary>
    /// 警报
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Alarm([FromBody] ApiData data)
    {
        ReBuild(data);

        await _alarmService.HandleAsync(data);
        return Ok();
    }

    /// <summary>
    /// 安灯
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Andon([FromBody] ApiData data)
    {
        ReBuild(data);

         await _andonService.HandleAsync(data);
        return Ok();
    }

    /// <summary>
    /// 通知
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Notice([FromBody] ApiData data)
    {
        ReBuild(data);

        await _noticeService.HandleAsync(data);
        return Ok();
    }

    /// <summary>
    /// 进站
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Inbound([FromBody] ApiData data)
    {
        ReBuild(data);

        var ret = await _inboundService.HandleAsync(data);
        return Ok(ret);
    }

    /// <summary>
    /// 出站
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Archive([FromBody] ApiData data)
    {
        ReBuild(data);

        var ret = await _archiveService.HandleAsync(data);
        return Ok(ret);
    }

    /// <summary>
    /// 扫关键物料
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> MaterialCritical([FromBody] ApiData data)
    {
        ReBuild(data);

        var ret = await _materialService.HandleCriticalMaterialAsync(data);
        return Ok(ret);
    }

    /// <summary>
    /// 扫批次料
    /// </summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> MaterialBatch([FromBody] ApiData data)
    {
        ReBuild(data);

        var ret = await _materialService.HandleBactchMaterialAsync(data);
        return Ok(ret);
    }

    /// <summary>
    /// 自定义的触发点。
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Custom([FromBody] ApiData data)
    {
        ReBuild(data);

        var ret = await _customService.HandleAsync(data);
        return Ok(ret);
    }

    #region privates

    private static void ReBuild(ApiData data)
    {
        for (int i = 0; i < data.Values.Length; i++)
        {
            var value0 = data.Values[i];
            var data0 = value0.Value;

            // 这里只需要区分 bool、int、double 和 string 类型，因为存储只需用这四种类型即可。
            value0.Value = value0.VarType switch
            {
                VariableType.Bit => value0.Length > 0 ? Object2ValueHelper.ToArray<bool>(data0) : Object2ValueHelper.To<bool>(data0),
                VariableType.Byte
                    or VariableType.Word
                    or VariableType.DWord
                    or VariableType.Int
                    or VariableType.DInt => value0.Length > 0 ? Object2ValueHelper.ToArray<int>(data0) : Object2ValueHelper.To<int>(data0),
                VariableType.Real
                    or VariableType.LReal => value0.Length > 0 ? Object2ValueHelper.ToArray<double>(data0) : Object2ValueHelper.To<double>(data0),
                VariableType.String
                    or VariableType.S7String
                    or VariableType.S7WString => Object2ValueHelper.To<string>(data0),
                _ => throw new NotImplementedException(),
            };
        }
    }

    #endregion
}
