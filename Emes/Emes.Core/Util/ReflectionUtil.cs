namespace Emes.Core;

/// <summary>
/// 反射工具类
/// </summary>
public static class ReflectionUtil
{
    /// <summary>
    /// 获取字段特性
    /// </summary>
    /// <param name="field"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetDescriptionValue<T>(this FieldInfo field) where T : Attribute
    {
        // 获取字段的指定特性，不包含继承中的特性
        return field.GetCustomAttribute<T>(false);
    }
}