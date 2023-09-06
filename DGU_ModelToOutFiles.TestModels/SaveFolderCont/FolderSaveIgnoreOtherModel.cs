using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.SaveFolderCont;

/// <summary>
/// 저장할 폴더 앞경로 변경, 다른 경로엔 저장안함
/// </summary>
[SaveRelativePath("..", "FolderSaveIgnoreOtherModel")]
[SaveIgnoreOtherPath]
public class FolderSaveIgnoreOtherModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int3 { get; set; }
}
