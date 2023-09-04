using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.TestCont;

/// <summary>
/// 테스트용 결과 모델
/// </summary>
public class TestResultModel
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
