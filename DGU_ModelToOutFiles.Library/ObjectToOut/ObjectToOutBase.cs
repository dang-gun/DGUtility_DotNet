using DGUtility.ProjectXml;

namespace DGUtility.ModelToOutFiles.Library.ObjectToOut;


/// <summary>
/// 디버깅용 이벤트
/// </summary>
/// <remarks>
/// 이벤트에 따른 가지고 있는 개체
/// ModelToTs-Reset-Parent : Type 
/// ModelToTs-Reset-Member : PropertyInfo? 
/// ModelToTs-ToTypeScriptString-ModelMember : string, TypeScriptModelMember 
/// </remarks>
/// <param name="sCommand">발생한 이벤트가 어디서 발생했는지 명령</param>
/// <param name="objModel1">이벤트가 발생될때 가지고 있던 모델1. 발생한 이벤트에 따라 다른 개체가 들어있다.</param>
/// <param name="objModel2">이벤트가 발생될때 가지고 있던 모델2. 발생한 이벤트에 따라 다른 개체가 들어있다.</param>
public delegate void DebugDelegate(
    string sCommand
    , object? objModel1
    , object? objModel2);

public class ObjectToOutBase : ObjectToOutInterface
{
    #region 외부에서 연결할 이벤트
    /// <summary>
	/// 디버깅 메시지 요청이 발생함
	/// </summary>
    public event DebugDelegate? OnDebug;
    /// <summary>
    /// 디버깅 메시지 요청이 이벤트 호출
    /// </summary>
    /// <param name="sCommand">발생한 이벤트가 어디서 발생했는지 명령</param>
    /// <param name="objModel1">전달할 모델1</param>
    /// <param name="objModel2">전달할 모델2</param>
    public void DebugCall(
        string sCommand
        , object? objModel1
        , object? objModel2)
    {
        if (OnDebug != null)
        {
            this.OnDebug(sCommand, objModel1, objModel2);
        }
    }
    #endregion

    /// <summary>
    /// 출력할 위치
    /// </summary>
    public List<string> OutputPathList { get; set; }

    /// <summary>
    /// 주석이 들어 있는 XML 개체
    /// </summary>
    public ProjectXmlAssist ProjectXml { get; set; }

    /// <summary>
    /// 네임스페이스에 소속된 개체를 리스트로 만드는 개체
    /// </summary>
    public NamespaceToClassList NsToClass { get; set; }
        = new NamespaceToClassList();

    /// <summary>
    ///
    /// </summary>
    /// <param name="listOutputPath">출력할 물리 경로(폴더)</param>
    /// <param name="ProjectXml">주석이 들어 있는 XML 개체</param>
    public ObjectToOutBase(
        List<string> listOutputPath
        , ProjectXmlAssist ProjectXml)
    {
        this.OutputPathList = listOutputPath;
        this.ProjectXml = ProjectXml;
    }

    /// <summary>
    /// 지정된 네임스페이스 만 허용하고 저장을 진행한다.
    /// </summary>
    /// <param name="listNamespace"></param>
    public void ToTargetSave(NamespaceTargetModel[] listNamespace)
    {
        for (int i = 0; i < listNamespace.Length; i++)
        {
            NsToClass.ClassListAdd(
                listNamespace[i].AssemblyName
                , listNamespace[i].NamespaceList);
        }//end for i

        ToTargetSave();
    }

    /// <summary>
    /// 가지고있는 허용리스트를 기준으로 저장을 진행한다.
    /// </summary>
    public virtual void ToTargetSave()
    {

    }
}
