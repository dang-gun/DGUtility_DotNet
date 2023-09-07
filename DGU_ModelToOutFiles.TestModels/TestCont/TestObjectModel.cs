using DGU_ModelToOutFiles.TestModels.TestCont.Children;

namespace DGU_ModelToOutFiles.TestModels.TestCont;

/// <summary>
/// 개체 테스트용 모델
/// </summary>
public class TestObjectModel
{
    /// <summary>
    /// 개체 테스트 1
    /// </summary>
    public TestGeneralTypeModel Call { get; set; } = new TestGeneralTypeModel();

    /// <summary>
    /// 개체 테스트 2
    /// </summary>
    public TestOutputNoPartModel? Result { get; set; }

    /// <summary>
    /// 리스트 개체 테스트
    /// </summary>
    public List<ChildrenModel>? List { get; set; }
}
