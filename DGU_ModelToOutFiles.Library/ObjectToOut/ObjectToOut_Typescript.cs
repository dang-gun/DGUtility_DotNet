using System.Text;

using DGUtility.FileAssist.FileSave;
using DGUtility.EnumToClass;
using DGUtility.ModelToFrontend;
using DGUtility.ProjectXml;
using DGUtility.ModelToOutFiles.Global.Attributes;
using DGU_ModelToOutFiles.Global;

namespace DGUtility.ModelToOutFiles.Library.ObjectToOut;



/// <summary>
/// 타입 스크립트로 내보낸다
/// </summary>
public class ObjectToOut_Typescript : ObjectToOutBase, ObjectToOutInterface
{
    

    /// <summary>
    /// 임포트시 앞에 붙을 루트
    /// </summary>
    private string ImportRootDir = string.Empty;


    /// <summary>
    /// 개체 리스트를 타입스크립트 파일로 출력하기위한 클래스
    /// </summary>
    /// <param name="listOutputPath">출력할 물리 경로(폴더)</param>
    /// <param name="ProjectXml">주석이 들어 있는 XML 개체</param>
    /// <param name="sImportRootDir">임포트시 앞에 붙을 루트 지정</param>
    public ObjectToOut_Typescript(
        List<string> listOutputPath
        , ProjectXmlAssist ProjectXml
        , string sImportRootDir)
        : base(listOutputPath, ProjectXml)
    {
        this.ImportRootDir = sImportRootDir;
    }

    /// <summary>
    /// 타입스크립트로 저장한다.
    /// </summary>
    public override void ToTargetSave()
    {
        Console.WriteLine();

        Console.WriteLine("====== Model to Out TypeScript ======");
        Console.WriteLine("Output path : ");

        //지정된 경로로 확인
        for (int nOutputPath = 0; nOutputPath < base.OutputPathList.Count; ++nOutputPath)
        {
            Console.WriteLine(base.OutputPathList[nOutputPath]);
        }
        Console.WriteLine();



        FileSaveAssist fileSave = new FileSaveAssist();

        //처리할 클래스 리스트
        List<ObjectOutModel> listObject
            = NsToClass.ClassList;

        string sTemp = string.Empty;
        //열거형을 모델로 바꾸기위한 개체
        //EnumToModel etmBP_Temp = new EnumToModel(ProjectXml);
        EnumToModel_TypeScript etmBP_Temp = new EnumToModel_TypeScript(ProjectXml);

        //모델을 타입스크립트로 출력하기 위한 개체
        ModelToTs tsModel_Temp = new ModelToTs(ProjectXml);
        tsModel_Temp.OnDebug -= base.DebugCall;
        tsModel_Temp.OnDebug += base.DebugCall;
        //임포트시 앞에 붙을 루트 지정
        tsModel_Temp.ImportRootDir = ImportRootDir;
        //임포트시 다른 참조가 필요하면 호출되는 콜백
        tsModel_Temp.ImportSearchCallback
            = (sNamespace)
            =>
            {
                return listObject
                        .Where(w => w.ClassNameFull == sNamespace)
                        .Select(s =>
                            new ModelToTextImportModel()
                            {
                                Name = s.ClassName
                                , OutPhysicalFullPath
                                    = this.PathToImportPath(s)
                            })
                        .ToList();

            };


        //모델을 json으로 출력하기위한 개체
        ModelToJson jsonModel_Temp = new ModelToJson(this.ProjectXml);

        //출력할때 사용할 확장자
        string sExtension = ".ts";


        for (int i = 0; i < listObject.Count; ++i)
        {
            ObjectOutModel itemOOM = listObject[i];

            if (null != itemOOM.Instance)
            {
                //경로 생성
                itemOOM.OutPhysicalPath_Create();

                //쓴 변수 초기화
                sTemp = string.Empty;

                //찾아낸 타입에 출력 타입에 따른
                switch (itemOOM.ObjectOutType)
                {
                    case ObjectOutType.Json:
                        jsonModel_Temp.Data_Set(itemOOM.Instance);
                        sTemp = jsonModel_Temp.ToJsonString();
                        sExtension = ".json";
                        break;
                    case ObjectOutType.Json_Enum:
                        break;

                    case ObjectOutType.Class:
                        //타입스크립트(인터페이스)로 변환
                        tsModel_Temp.TypeData_Set(itemOOM.Instance);
                        sTemp = tsModel_Temp.ToTypeScriptInterfaceString(itemOOM.ImportAdd);
                        sExtension = ".ts";
                        break;

                    case ObjectOutType.Enum:
                        etmBP_Temp.TypeData_Set((Enum)itemOOM.Instance);
                        sTemp = etmBP_Temp.ToTypeScriptEnumString(true);
                        sExtension = ".ts";
                        break;
                    case ObjectOutType.Enum_ConstNo:
                        etmBP_Temp.TypeData_Set((Enum)itemOOM.Instance);
                        sTemp = etmBP_Temp.ToTypeScriptEnumString(false);
                        sExtension = ".ts";
                        break;

                    default:
                        sExtension = string.Empty;
                        break;
                }

                if (string.Empty != sTemp)
                {//생성된 문자열이 있다.

                    //지정된 경로로 파일 출력
                    for (int j = 0; j < base.OutputPathList.Count; ++j)
                    {
                        string sOutputPathItem = base.OutputPathList[j];

                        if (false == itemOOM.SaveIgnoreOtherPathIs)
                        {//속성외 경로도 허용

                            //전체 설정 출력 경로로 출력
                            fileSave
                                .FileSave(Path.Combine(sOutputPathItem
                                                        , itemOOM.OutPhysicalFullPath) + sExtension
                                    , sTemp + itemOOM.LastText);
                        }
                        
                        if(string.Empty != itemOOM.SaveAbsolutePath)
                        {//절대 경로 강제 지정

                            //지정된 경로에 출력
                            fileSave
                                .FileSave(Path.Combine(itemOOM.SaveAbsolutePath
                                                        , itemOOM.ClassName) + sExtension
                                    , sTemp + itemOOM.LastText);
                        }
                        else
                        {
                            //절대 경로 강제 지정일때는 상대경로 수정 속성은 무시된다.

                            if (string.Empty != itemOOM.SaveRelativePath)
                            {//상대 경로 앞쪽 경로 변경
                                
                                fileSave
                                    .FileSave(Path.Combine(
                                                Path.GetFullPath(
                                                    itemOOM.SaveRelativePath
                                                    , Path.Combine(sOutputPathItem
                                                                    , itemOOM.OutPhysicalPath))
                                                , itemOOM.ClassName)+ ".ts"
                                        , sTemp + itemOOM.LastText);
                            }
                        }
                    }//end for j
                }
                
            }

        }//end for i


    }

    /// <summary>
    /// 파일 경로 리스트를 임포트 패스로 변경해준다.
    /// </summary>
    /// <param name="oomData"></param>
    /// <returns></returns>
    private string PathToImportPath(ObjectOutModel oomData)
    {
        StringBuilder sbReturn = new StringBuilder();


        //임의로 지정된 임포트 경로가 있는지 확인한다.
        string sImportPath
            = ImportPathSetAttributeCheck.Instance
                .Value(oomData.MyType!, OutputLanguageType.TypeScript);

        if (string.Empty == sImportPath
            || false == oomData.SaveIgnoreOtherPathIs)
        {//임의로 지정된 임포트가 없다.
            //속성에 지정된 경로 말고 무시하는 속성이 없다.

            
            //기본 경로
            for (int i = 0; i < oomData.OutPhysicalPathList.Count; ++i)
            {

                string sItem = oomData.OutPhysicalPathList[i];

                if (0 != i)
                {
                    //맨앞에는 구분자를 추가하지 않는다.
                    //구분자 추가
                    sbReturn.Append("/");
                }

                sbReturn.Append(sItem);
            }

            sbReturn.Append($"/{oomData.ClassName}");

        }
        else if (string.Empty != sImportPath)
        {//임의 경로가 있다.

            sbReturn.Append(sImportPath);
            sbReturn.Append($"/{oomData.ClassName}");
        }




        return sbReturn.ToString();
    }

}
