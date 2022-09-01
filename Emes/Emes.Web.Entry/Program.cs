using Serilog;

Serve.Run(RunOptions.Default.ConfigureBuilder(builder =>
{
    // ��� Serilog ��־
    builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
}));
