using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.TestCont;

/// <summary>
/// 부분 출력안함 테스트
/// </summary>
public class TestOutputNoPartModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int { get; set; }

    /// <summary>
    /// 프로퍼티 출력안함 테스트
    /// </summary>
    [ModelOutputNo]
    public string String { get; set; } = string.Empty;

}
