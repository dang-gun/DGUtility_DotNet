using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGUtility.ModelToOutFiles.Global.Attributes;

/// <summary>
/// 열거형 추가 처리 속성
/// </summary>
/// <remarks>
/// 타입 스크립트와 같이 필요에 따라 const를 붙여야 할지 말아야 할지를 결정해야 할때
/// 이 속성으로 처리한다.
/// </remarks>
[System.AttributeUsage(System.AttributeTargets.Enum)]
public class EnumTypeAttribute : System.Attribute
{
    /// <summary>
    /// 타입스크립트로 변환하는 경우 const를 붙이지 말지 여부.
    /// </summary>
    /// <remarks>
    /// true이면 붙이지 않는다.
    /// </remarks>
    public bool TypeScript_EnumNoConstIs;

    /// <summary>
    /// const를 붙이지 않는다.
    /// </summary>
    public EnumTypeAttribute()
    {
        this.TypeScript_EnumNoConstIs = true;
    }
}

/// <summary>
/// EnumTypeAttribute가 있는지 확인해준다
/// </summary>
public sealed class EnumTypeAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static readonly EnumTypeAttributeCheck statcSingleton
        = new EnumTypeAttributeCheck();

    /// <summary>
    /// static으로만 접근 가능
    /// </summary>
    private EnumTypeAttributeCheck() { }

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static EnumTypeAttributeCheck Instance
    {
        get { return statcSingleton; }
    }

    /// <summary>
    /// EnumTypeAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public EnumTypeAttribute? Check(Type type)
    {
        EnumTypeAttribute? etReturn =
            type.GetCustomAttributes(typeof(EnumTypeAttribute), false)
                    .Cast<EnumTypeAttribute>()
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
        EnumTypeAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            bReturn = true;
        }

        return bReturn;
    }
}
