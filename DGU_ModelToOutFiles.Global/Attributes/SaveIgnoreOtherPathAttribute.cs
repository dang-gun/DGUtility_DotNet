using System;

namespace DGUtility.ModelToOutFiles.Global.Attributes;

/// <summary>
/// 속성으로 지정된 경로외에는 모두 무시한다.(저장하지 않는다.)
/// </summary>
/// <remarks>
/// SaveAbsolutePathAttribute
/// SaveRelativePathAttribute
/// </remarks>
[AttributeUsage(AttributeTargets.Class )]
public class SaveIgnoreOtherPathAttribute : Attribute
{
    /// <summary>
    /// 속성으로 지정된 경로외에는 모두 무시한다.(저장하지 않는다.)
    /// </summary>
    /// <remarks>
    /// true이면 다른 경로 무시
    /// </remarks>
    public bool IgnoreOtherIs;

    /// <summary>
    /// 속성으로 지정된 경로외에는 모두 무시한다.(저장하지 않는다.)
    /// </summary>
    /// <remarks>
    /// SaveAbsolutePathAttribute
    /// SaveRelativePathAttribute
    /// </remarks>
    public SaveIgnoreOtherPathAttribute()
    {
        this.IgnoreOtherIs = true;
    }
}

/// <summary>
/// SaveIgnoreOtherPath가 있는지 확인하고 있으면 개체를 리턴해주는 클래스
/// </summary>
public class SaveIgnoreOtherPathAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static SaveIgnoreOtherPathAttributeCheck? statcSingleton;

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static SaveIgnoreOtherPathAttributeCheck Instance()
    {
        if (null == statcSingleton)
        {
            statcSingleton = new SaveIgnoreOtherPathAttributeCheck();
        }

        return statcSingleton;
    }

    /// <summary>
    /// SaveIgnoreOtherPathAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public SaveIgnoreOtherPathAttribute? Check(Type type)
    {
        SaveIgnoreOtherPathAttribute? etReturn =
            type.GetCustomAttributes(typeof(SaveIgnoreOtherPathAttribute), false)
                    .Cast<SaveIgnoreOtherPathAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }

    /// <summary>
    /// SaveIgnoreOtherPathAttribute의 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool Value(Type type)
    {
        bool bReturn = false;
        SaveIgnoreOtherPathAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            bReturn = true;
        }

        return bReturn;
    }
}
