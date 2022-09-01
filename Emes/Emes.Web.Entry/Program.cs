using Serilog;

Serve.Run(RunOptions.Default.ConfigureBuilder(builder =>
{
    // Ìí¼Ó Serilog ÈÕÖ¾
    builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
}));
