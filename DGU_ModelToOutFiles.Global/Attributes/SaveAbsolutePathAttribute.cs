using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGUtility.ModelToOutFiles.Global.Attributes;


/// <summary>
/// 저장할 전채 경로를 지정한다.
/// </summary>
/// <remarks>
/// 상대 경로가 아닌 절대 경로를 지정해야 한다.
/// 이 속성이 지정되면 SaveRelativePathAttribute는 무시된다.
/// </remarks>
[System.AttributeUsage(System.AttributeTargets.Class)]
public class SaveAbsolutePathAttribute : System.Attribute
{
    /// <summary>
    /// 들어온 경로를 변환한 값
    /// </summary>
    public string PathBefore;

    /// <summary>
    /// 저장할 전채 경로를 지정한다.
    /// </summary>
    /// <remarks>
    /// 상대 경로가 아닌 절대 경로를 지정해야 한다.
    /// 이 속성이 지정되면 SaveRelativePathAttribute는 무시된다.
    /// </remarks>
    /// <param name="PathList"></param>
    public SaveAbsolutePathAttribute(params string[] PathList)
    {
        this.PathBefore = Path.Combine(PathList);
    }
}

/// <summary>
/// SaveAbsolutePathAttribute가 있는지 확인하고 있으면 개체를 리턴해주는 클래스
/// </summary>
public class SaveAbsolutePathAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static SaveAbsolutePathAttributeCheck? statcSingleton;

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static SaveAbsolutePathAttributeCheck Instance()
    {
        if (null == statcSingleton)
        {
            statcSingleton = new SaveAbsolutePathAttributeCheck();
        }

        return statcSingleton;
    }

    /// <summary>
    /// SaveAbsolutePathAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public SaveAbsolutePathAttribute? Check(Type type)
    {
        SaveAbsolutePathAttribute? etReturn =
            type.GetCustomAttributes(typeof(SaveAbsolutePathAttribute), false)
                    .Cast<SaveAbsolutePathAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }


    /// <summary>
    /// SaveAbsolutePathAttribute의 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public string Value(Type type)
    {
        string sReturn = string.Empty;
        SaveAbsolutePathAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            sReturn = fsfTemp.PathBefore;
        }

        return sReturn;
    }

}