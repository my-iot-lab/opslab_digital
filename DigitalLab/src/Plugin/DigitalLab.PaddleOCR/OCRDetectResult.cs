using PaddleOCRSharp;

namespace DigitalLab.PaddleOCR;

/// <summary>
/// OCR识别结果。
/// </summary>
public class OCRDetectResult
{
    /// <summary>
    /// 文本块列表
    /// </summary>
    [NotNull]
    public List<DetectTextBlock>? TextBlocks { get; set; }

    /// <summary>
    /// 识别结果文本，会将识别出的所有数据拼接为字符串。
    /// </summary>
    [NotNull]
    public string? Text { get; set; }

    internal static OCRDetectResult From(OCRResult oCRResult)
    {
        OCRDetectResult result = new()
        {
            Text = oCRResult.Text,
            TextBlocks = oCRResult.TextBlocks.Select(s => new DetectTextBlock
            {
                BoxPoints = s.BoxPoints,
                Text= s.Text,
                Score= s.Score,
            }).ToList(),
        };

        return result;
    }

    public override string ToString()
    {
        return Text;
    }
}

/// <summary>
/// 识别的文本块
/// </summary>
public class DetectTextBlock : TextBlock
{
}