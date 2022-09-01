using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emes.Web.Entry.Controllers;

/// <summary>
/// 健康检查
/// </summary>
[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class HealthController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return Ok();
    }
}
