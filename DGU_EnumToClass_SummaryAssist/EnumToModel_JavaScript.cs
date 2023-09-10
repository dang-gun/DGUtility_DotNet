using DGUtility.ProjectXml;
using System.Text;


namespace DGUtility.EnumToClass;

/// <summary>
/// 열거형의 멤버를 분해하여 배열형태로 관리 해주는 클래스.
/// 자바스크립트 생성에 사용
/// </summary>
public class EnumToModel_JavaScript: EnumToModel
{
	public EnumToModel_JavaScript(ProjectXmlAssist projectXmlAssist)
		: base(projectXmlAssist)
	{

	}

    public EnumToModel_JavaScript(Enum typeData)
        : base(typeData)
    {

    }

    public EnumToModel_JavaScript(Enum typeData, ProjectXmlAssist projectXmlAssist)
        : base(typeData, projectXmlAssist)
    {

    }


    /// <summary>
	/// 자바스크립트에서 사용하는 열거형 타입으로 선언하는 코드를 생성한다.
	/// </summary>
	/// <returns></returns>
	public string ToJavaScriptVarString()
    {
        return base.ToScriptString(
                "var {0} = " + Environment.NewLine
                        + "{{" + Environment.NewLine
                , @"    {0}: {1}," + Environment.NewLine
                , "}}"
            );
    }
}
