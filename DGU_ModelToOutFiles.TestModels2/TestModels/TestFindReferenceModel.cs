using DGU_ModelToOutFiles.TestModels.TestCont;

namespace DGU_ModelToOutFiles.TestModels2.TestModels;

/// <summary>
/// 테스트용 호출 모델
/// </summary>
public class TestFindReferenceModel
{
    /// <summary>
    /// 다른 어셈블리에 있는 참조
    /// </summary>
    public TestCallModel[]? TestCallList { get; set; }

    /// <summary>
    /// ICollection처리
    /// </summary>
    public ICollection<TestCallResultModel>? TestCallResultList { get; set; }

}
