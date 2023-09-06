using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.SaveFolderCont;

/// <summary>
/// 지정된 경로에 저장
/// </summary>
[SaveAbsolutePath("D:", "OutputFiles")]
public class FolderFullModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int4 { get; set; }
}
