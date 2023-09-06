using System;

namespace DGUtility.ModelToOutFiles.Global.Attributes;

/// <summary>
/// 파일 출력시 이 개체는 제외한다.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class 
    | AttributeTargets.Enum)]
public class ModelOutputJsonAttribute : Attribute
{
    /// <summary>
    /// 다른 프로젝트로 변환하는 경우 이 개체를 제외할지 여부
    /// </summary>
    /// <remarks>
    /// true이면 출력하지 않는다.
    /// </remarks>
    public bool OutputNoIs;

    public ModelOutputJsonAttribute()
    {
        this.OutputNoIs = true;
    }
}

/// <summary>
/// EnumTypeAttribute가 있는지 확인하고 있으면 개체를 리턴해주는 클래스
/// </summary>
public class ModelOutputJsonAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static ModelOutputJsonAttributeCheck? statcSingleton;

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static ModelOutputJsonAttributeCheck Instance()
    {
        if (null == statcSingleton)
        {
            statcSingleton = new ModelOutputJsonAttributeCheck();
        }

        return statcSingleton;
    }

    /// <summary>
    /// ModelOutputJsonAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public ModelOutputJsonAttribute? Check(Type type)
    {
        ModelOutputJsonAttribute? etReturn =
            type.GetCustomAttributes(typeof(ModelOutputJsonAttribute), false)
                    .Cast<ModelOutputJsonAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }

    /// <summary>
    /// EnumTypeAttribute의 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool Value(Type type)
    {
        bool bReturn = false;
        ModelOutputJsonAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            bReturn = true;
        }

        return bReturn;
    }
}
