using DGU_ModelToOutFiles.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGUtility.ModelToOutFiles.Global.Attributes;



/// <summary>
/// 다른 곳에서 이 속성이 지정된 참조경로를 요청하면 리턴될 참조경로
/// </summary>
/// <remarks>
/// 이 속성이 지정되면 다른 임포트경로는 모두 무시되고 이 속성으로 설정된 참조 경로만 리턴된다.
/// SaveAbsolutePathAttribute를 사용한다면 이 속성을 이용하는것이 좋다.
/// </remarks>
[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
public class ImportPathSetAttribute : System.Attribute
{
    /// <summary>
    /// 구분용 타입이름
    /// </summary>
    public OutputLanguageType OutputLanguageType;
    /// <summary>
    /// 참조 경로
    /// </summary>
    public string ImportPath;

    /// <summary>
    /// 다른 곳에서 이 속성이 지정된 참조경로를 요청하면 리턴될 참조경로
    /// </summary>
    /// <remarks>
    /// 이 속성이 지정된 참조 경로가 리턴된다.
    /// SaveAbsolutePathAttribute를 사용한다면 이 속성을 이용하는것이 좋다.
    /// 설정된 루트 문자열은 앞에 붙는다.
    /// 하지만 상대 경로는 적용되지 않으므로 루트 이후의 모든 경로를 적어야 한다.
    /// </remarks>
    /// <param name="sTypeName">구분용 타입이름</param>
    /// <param name="sImportPath">참조 경로</param>
    public ImportPathSetAttribute(OutputLanguageType typeOutputLanguage, string sImportPath)
    {
        this.OutputLanguageType = typeOutputLanguage;
        this.ImportPath = sImportPath;
    }
}

/// <summary>
/// ImportPathSetAttribute가 있는지 확인해 준다.
/// </summary>
public sealed class ImportPathSetAttributeCheck
{
    /// <summary>
    /// 사용시 생성되는 개체
    /// </summary>
    private static readonly ImportPathSetAttributeCheck statcSingleton
        = new ImportPathSetAttributeCheck();

    /// <summary>
    /// static으로만 접근 가능
    /// </summary>
    public ImportPathSetAttributeCheck() { }


    /// <summary>
    /// 싱글톤으로 생성된 개체를 리턴한다.
    /// </summary>
    /// <returns></returns>
    public static ImportPathSetAttributeCheck Instance
    {
        get { return statcSingleton; }
    }

    /// <summary>
    /// ImportPathSetAttribute가 있는지 체크한다.
    /// </summary>
    /// <remarks>
    /// 검색된 항목중 맨 처음 것을 출력함
    /// </remarks>
    /// <param name="type"></param>
    /// <returns></returns>
    public ImportPathSetAttribute? Check(Type type)
    {
        ImportPathSetAttribute? etReturn =
            type.GetCustomAttributes(typeof(ImportPathSetAttribute), false)
                    .Cast<ImportPathSetAttribute>()
                    .FirstOrDefault();
        return etReturn;
    }

    /// <summary>
    /// ImportPathSetAttribute가 있는지 체크하면서 
    /// typeImportPathSet가 일치하는 항목중
    /// 제일 처음 아이템을 리턴함
    /// </summary>
    /// <remarks>
    /// 검색된 항목중 맨 처음 것을 출력함
    /// </remarks>
    /// <param name="type"></param>
    /// <returns></returns>
    public ImportPathSetAttribute? Check(Type type, OutputLanguageType typeOutputLanguage)
    {
        ImportPathSetAttribute? etReturn =
            type.GetCustomAttributes(typeof(ImportPathSetAttribute), false)
                    .Cast<ImportPathSetAttribute>()
                    .Where(w=>w.OutputLanguageType == typeOutputLanguage)
                    .FirstOrDefault();
        return etReturn;
    }


    /// <summary>
    /// ImportPathSetAttribute의 타입 값 확인
    /// </summary>
    /// <param name="type"></param>
    /// <param name="typeOutputLanguage"></param>
    /// <returns></returns>
    public string Value(Type type, OutputLanguageType typeOutputLanguage)
    {
        string sReturn = string.Empty;
        ImportPathSetAttribute? fsfTemp
            = this.Check(type, typeOutputLanguage);

        if (null != fsfTemp)
        {
            sReturn = fsfTemp.ImportPath;
        }

        return sReturn;
    }

}