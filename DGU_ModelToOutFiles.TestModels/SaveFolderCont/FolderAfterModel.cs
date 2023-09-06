using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.SaveFolderCont;

/// <summary>
/// 저장할 폴더 뒷경로 변경
/// </summary>
[SaveRelativePath("FolderAfter", "Models")]
public class FolderAfterModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int2 { get; set; }
}
