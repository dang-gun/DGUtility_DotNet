using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.SaveFolderCont;

/// <summary>
/// 임포트 패스 수정 테스트
/// </summary>
[SaveIgnoreOtherPath]
[SaveRelativePath("..", "FolderBefore")]
[ImportPathSet(ImportPathSetType.TypeScript, "FolderBefore")]
[ImportPathSet(ImportPathSetType.Test, "FolderBefore2")]
public class ChangeImportPathModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int6 { get; set; }
}
