using DGU_ModelToOutFiles.TestModels.TestCont;
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

    /// <summary>
    /// 강제 지정된 임포트 경로를 사용하는 개체
    /// </summary>
    public ChangeImportPathModel? ChangeImportPath { get; set; }

    /// <summary>
    /// 기본 임포트 경로인 개체
    /// </summary>
    public TestCallModel? TestCall { get; set; }
}
