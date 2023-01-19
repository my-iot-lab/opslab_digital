using DigitalLab.PaddleOCR;

namespace DigitalLab;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// 添加 PaddleOCR 图片文本识别引擎。
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddPaddleOCR(this IServiceCollection services)
    {
        return services.AddSingleton<IDglPaddleOCREngine, DglPaddleOCREngine>();
    }
}
