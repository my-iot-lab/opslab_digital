using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.NET.UnitTest;

public sealed class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        //// ע��Զ�̷���
        //services.AddRemoteRequest();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}