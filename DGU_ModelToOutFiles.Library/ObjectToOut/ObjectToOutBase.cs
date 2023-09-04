using DGUtility.ProjectXml;

namespace DGUtility.ModelToOutFiles.Library.ObjectToOut;

public class ObjectToOutBase : ObjectToOutInterface
{
    /// <summary>
    /// 출력할 위치
    /// </summary>
    public List<string> OutputPath { get; set; }

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
        OutputPath = listOutputPath;
        this.ProjectXml = ProjectXml;
    }

    /// <summary>
    /// 
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

    public virtual void ToTargetSave()
    {

    }
}
