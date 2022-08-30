namespace Emes.Core;

/// <summary>
/// 通用工具类
/// </summary>
public static class CommonUtil
{
    /// <summary>
    /// 获取今天日期范围00:00:00 - 23:59:59:999
    /// </summary>
    /// <returns></returns>
    public static List<DateTime> GetTodayTimeList(DateTime time)
    {
        return new List<DateTime>
        {
            Convert.ToDateTime(time.ToString("D").ToString()),
            Convert.ToDateTime(time.AddDays(1).ToString("D").ToString()).AddMilliseconds(-1)
        };
    }

    /// <summary>
    /// 获取今天日期范围00:00:00 - 23:59:59:999
    /// </summary>
    public static (DateTime start, DateTime end) GetTodayTimeRange(DateTime time)
    {
        return (Convert.ToDateTime(time.ToString("D").ToString()), Convert.ToDateTime(time.AddDays(1).ToString("D").ToString()).AddMilliseconds(-1));
    }

    /// <summary>
    /// 获取项目根目录文件内容
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetRootPathFileText(string path)
    {
        return File.ReadAllText(App.WebHostEnvironment.ContentRootPath + path);
    }
}