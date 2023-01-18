using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Web.Entry.Controllers;

[AllowAnonymous]
public class TestController : Controller
{
    private readonly IWebHostEnvironment _env;

    public TestController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet]
    public IActionResult Env()
    {
        return Ok(_env.EnvironmentName);
    }
}
