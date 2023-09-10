using DGUtility.ProjectXml;
using System.Text;


namespace DGUtility.EnumToClass;

/// <summary>
/// 열거형의 멤버를 분해하여 배열형태로 관리 해주는 클래스.
/// 타입스크립트 생성에 사용
/// </summary>
public class EnumToModel_TypeScript : EnumToModel
{
	public EnumToModel_TypeScript(ProjectXmlAssist projectXmlAssist)
		: base(projectXmlAssist)
	{

	}

    public EnumToModel_TypeScript(Enum typeData)
        : base(typeData)
    {

    }

    public EnumToModel_TypeScript(Enum typeData, ProjectXmlAssist projectXmlAssist)
        : base(typeData, projectXmlAssist)
    {

    }

    /// <summary>
	/// 타입 스크립트에서 사용하는 열거형 타입으로 선언하는 코드를 생성한다.
	/// </summary>
	/// <param name="bConst">
	/// 'const'로 선언할지 여부<br/>
	///  Object.keys와 같이 열거형에 직접 접근하려면 const로 선언하면 안된다.<br/>
	///  대신 const로 선언하면 성능이 향상된다.
	/// </param>
	/// <returns></returns>
	public string ToTypeScriptEnumString(bool bConst)
    {
        string sConst = string.Empty;

        if (true == bConst)
        {
            sConst = "export const enum {0} ";
        }
        else
        {
            sConst = "export enum {0} ";
        }

        return base.ToScriptString(
                sConst + Environment.NewLine
                        + "{{" + Environment.NewLine
                , @"    {0} = {1}," + Environment.NewLine
                , "}}"
            );
    }
}
