using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGUtility.ModelToOutFiles.Global.Attributes;


/// <summary>
/// 상대 경로를 지정한다.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Class)]
public class SaveRelativePathAttribute : System.Attribute
{
    /// <summary>
    /// 들어온 경로를 변환한 값
    /// </summary>
    public string PathBefore;

    /// <summary>
    /// 상대 경로를 지정한다.
    /// </summary>
    /// <param name="PathList"></param>
    public SaveRelativePathAttribute(params string[] PathList)
    {
        this.PathBefore = Path.Combine(PathList);
    }
}

/// <summary>
/// SaveRelativePathAttribute가 있는지 확인하고 있으면 개체를 리턴해주는 클래스
/// </summary>
public class SaveRelativePathAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static SaveRelativePathAttributeCheck? statcSingleton;

    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static SaveRelativePathAttributeCheck Instance()
    {
        if (null == statcSingleton)
        {
            statcSingleton = new SaveRelativePathAttributeCheck();
        }

        return statcSingleton;
    }

    /// <summary>
    /// SaveRelativePathAttribute가 있는지 체크한다.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public SaveRelativePathAttribute? Check(Type type)
    {
        SaveRelativePathAttribute? etReturn =
            type.GetCustomAttributes(typeof(SaveRelativePathAttribute), false)
                    .Cast<SaveRelativePathAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }

    /// <summary>
    /// SaveRelativePathAttribute의 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public string Value(Type type)
    {
        string sReturn = string.Empty;
        SaveRelativePathAttribute? fsfTemp
            = this.Check(type);

        if (null != fsfTemp)
        {
            sReturn = fsfTemp.PathBefore;
        }

        return sReturn;
    }
}