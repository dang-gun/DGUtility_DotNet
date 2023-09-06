
using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.JsonCont;


/// <summary>
/// JSON 출력 테스트용 모델
/// </summary>
[ModelOutputJson]
public enum JsoneEnumTestModel
{
    /// <summary>
    /// 없음
    /// </summary>
    None = 0,

    /// <summary>
    /// 1이 들어갈 것으로 추정
    /// </summary>
    Test1,

    /// <summary>
    /// 10이 들어감
    /// </summary>
    Test10,
}