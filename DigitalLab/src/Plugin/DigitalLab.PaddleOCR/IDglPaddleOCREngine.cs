namespace DigitalLab.PaddleOCR;

/// <summary>
/// PaddleOCR 引擎。
/// </summary>
public interface IDglPaddleOCREngine
{
    /// <summary>
    /// 识别图片文本
    /// </summary>
    /// <param name="imageByte">图片字节</param>
    /// <returns></returns>
    OCRDetectResult DetectText(byte[] imageByte);

    /// <summary>
    /// 识别图片文本
    /// </summary>
    /// <param name="imageFilePath">图片路径</param>
    /// <returns></returns>
    OCRDetectResult DetectText(string imageFilePath);

    /// <summary>
    /// 识别图片文本
    /// </summary>
    /// <param name="imageBase64">图片内容Base6编码</param>
    /// <returns></returns>
    OCRDetectResult DetectTextBase64(string imageBase64);
}
