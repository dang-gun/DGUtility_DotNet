using System;

namespace DGUtility.ModelToOutFiles.Global.Attributes;

/// <summary>
/// 파일 출력시 이 개체는 제외한다.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class 
    | AttributeTargets.Enum
    | AttributeTargets.Property)]
public class ModelOutputNoAttribute : Attribute
{
    /// <summary>
    /// 다른 프로젝트로 변환하는 경우 이 개체를 제외할지 여부
    /// </summary>
    /// <remarks>
    /// true이면 출력하지 않는다.
    /// </remarks>
    public bool OutputNoIs;

    public ModelOutputNoAttribute()
    {
        this.OutputNoIs = true;
    }
}

/// <summary>
/// ModelOutputNoAttribute가 있는지 확인해준다.
/// </summary>
public sealed class ModelOutputNoAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static readonly ModelOutputNoAttributeCheck statcSingleton
        = new ModelOutputNoAttributeCheck();

    /// <summary>
    /// static으로만 접근 가능
    /// </summary>
    private ModelOutputNoAttributeCheck() { }

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static ModelOutputNoAttributeCheck Instance
    {
        get { return statcSingleton; }
    }

    /// <summary>
    /// ModelOutputNoAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public ModelOutputNoAttribute? Check(Type type)
    {
        ModelOutputNoAttribute? etReturn =
            type.GetCustomAttributes(typeof(ModelOutputNoAttribute), false)
                    .Cast<ModelOutputNoAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }

    /// <summary>
    /// ModelOutputNoAttribute의 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool Value(Type type)
    {
        bool bReturn = false;
        ModelOutputNoAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            bReturn = fsfTemp.OutputNoIs;
        }

        return bReturn;
    }
}
