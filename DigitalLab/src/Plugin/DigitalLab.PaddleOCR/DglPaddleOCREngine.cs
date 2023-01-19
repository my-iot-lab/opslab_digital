using PaddleOCRSharp;

namespace DigitalLab.PaddleOCR;

/// <summary>
/// PaddleOCR 图片文本识别引擎。
/// 具体参数文档见：https://github.com/raoyutian/PaddleOCRSharp/blob/main/doc/UseInCsharp.md。
/// </summary>
/// <remarks>需注册为单例模式以减少出错的可能。</remarks>
public sealed class DglPaddleOCREngine : IDglPaddleOCREngine
{
    private readonly PaddleOCREngine _engine;

	public DglPaddleOCREngine()
	{
        // 使用默认中英文V3模型
        OCRModelConfig? config = null;

        // 使用默认参数
        OCRParameter oCRParameter = new();
        _engine = new(config, oCRParameter);
    }

    public OCRDetectResult DetectText(byte[] imageByte)
    {
        var result = _engine.DetectText(imageByte);
        return OCRDetectResult.From(result);
    }

    public OCRDetectResult DetectText(string imageFilePath)
    {
        var result = _engine.DetectText(imageFilePath);
        return OCRDetectResult.From(result);
    }

    public OCRDetectResult DetectTextBase64(string imageBase64)
    {
        var result = _engine.DetectTextBase64(imageBase64);
        return OCRDetectResult.From(result);
    }
}
