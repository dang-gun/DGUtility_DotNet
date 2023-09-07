
using DGU_ModelToOutFiles.TestModels.TestCont;
using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.JsonCont;


/// <summary>
/// 제네릭 테스트
/// </summary>
/// <remarks>
/// 제네릭은 출력하지 않는다.
/// </remarks>
public class GenericTest<T> where T : TestCallModel, new()
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int2 { get; set; }
}
