using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.SaveFolderCont;

/// <summary>
/// 저장할 폴더 앞경로 변경
/// </summary>
[SaveRelativePath("..", "FolderBefore")]
public class FolderBeforeModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int { get; set; }
}
