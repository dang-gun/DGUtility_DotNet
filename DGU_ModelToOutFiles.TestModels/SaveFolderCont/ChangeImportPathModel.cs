using DGU_ModelToOutFiles.Global;
using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.SaveFolderCont;

/// <summary>
/// 임포트 패스 수정 테스트
/// </summary>
[SaveIgnoreOtherPath]
[SaveRelativePath("..", "FolderBefore")]
[ImportPathSet(OutputLanguageType.TypeScript, "FolderBefore")]
[ImportPathSet(OutputLanguageType.Test, "FolderBefore2")]
public class ChangeImportPathModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int6 { get; set; }
}
