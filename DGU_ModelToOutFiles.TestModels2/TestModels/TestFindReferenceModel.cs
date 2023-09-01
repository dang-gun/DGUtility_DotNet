using DGU_ModelToOutFiles.TestModels.TestCont;
using DGU_ModelToOutFiles.TestModels.TestCont.Children;

namespace DGU_ModelToOutFiles.TestModels2.TestModels;

/// <summary>
/// 테스트용 호출 모델
/// </summary>
public class TestFindReferenceModel
{
    /// <summary>
    /// 다른 어셈블리에 있는 참조
    /// </summary>
    public TestCallModel[]? TestArray { get; set; }

    /// <summary>
    /// ICollection처리
    /// </summary>
    public ICollection<TestCallResultModel>? TestICollection { get; set; }

    /// <summary>
    /// 리스트 테스트
    /// </summary>
    public List<TestCallResultModel>? TestList { get; set; }

    /// <summary>
    /// 열거형 테스트
    /// </summary>
    public EnumType? TestEnumType { get; set; }

    /// <summary>
    /// 자식 모델 참조 테스트
    /// </summary>
    public ChildrenModel TestChildrenReference { get; set; } = new ChildrenModel();

}
