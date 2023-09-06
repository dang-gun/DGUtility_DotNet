using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGUtility.ModelToOutFiles.Global.Attributes;

/// <summary>
/// 변수 형 강제 지정
/// </summary>
/// <remarks>
/// 이 속성을 설정하면 자동으로 판단된 변수형을 사용하지 않고 
/// 이 지정된 변수형으로 출력된다.
/// </remarks>
[System.AttributeUsage(System.AttributeTargets.Property)]
public class VarTypeEnforceAttribute : System.Attribute
{
    /// <summary>
    /// 강제로 지정할 변수형
    /// </summary>
    public string VarTypeEnforce = string.Empty;

    /// <summary>
    /// 강제 지정할 변수형
    /// </summary>
    /// <param name="sVarTypeEnforce"></param>
    public VarTypeEnforceAttribute(string sVarTypeEnforce)
    {
        this.VarTypeEnforce = sVarTypeEnforce;
    }
}

/// <summary>
/// VarTypeEnforceAttribute 있는지 확인하고 있으면 개체를 리턴해주는 클래스
/// </summary>
public class VarTypeEnforceAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static VarTypeEnforceAttributeCheck? statcSingleton;

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static VarTypeEnforceAttributeCheck Instance()
    {
        if (null == statcSingleton)
        {
            statcSingleton = new VarTypeEnforceAttributeCheck();
        }

        return statcSingleton;
    }

    /// <summary>
    /// VarTypeEnforceAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public VarTypeEnforceAttribute? Check(Type type)
    {
        VarTypeEnforceAttribute? etReturn =
            type.GetCustomAttributes(typeof(VarTypeEnforceAttribute), false)
                    .Cast<VarTypeEnforceAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }

    /// <summary>
    /// VarTypeEnforceAttribute의 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool Value(Type type)
    {
        bool bReturn = false;
        VarTypeEnforceAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            bReturn = true;
        }

        return bReturn;
    }
}