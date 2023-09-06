
using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.JsonCont;


/// <summary>
/// JSON 출력 테스트용 모델
/// </summary>
[ModelOutputJson]
public class JsonTestModel
{
    /// <summary>
    /// 문자열 출력
    /// </summary>
    public readonly string TestJsonString = "D1-1001";

    /// <summary>
    /// 숫자 출력
    /// </summary>
    public readonly int TestJsonInt = 10;

}