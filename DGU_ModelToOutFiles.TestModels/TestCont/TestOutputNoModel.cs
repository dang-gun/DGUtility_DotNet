using DGU_ModelToOutFiles.Global.Attributes;


namespace DGU_ModelToOutFiles.TestModels.TestCont;

/// <summary>
/// 클래스나 열거형 출력 안함 테스트용 모델
/// </summary>
[ModelOutputNo]
public class TestOutputNoModel
{
    /// <summary>
    /// 숫자
    /// </summary>
    public int Int { get; set; }

    /// <summary>
    /// 문자열
    /// </summary>
    public string String { get; set; } = string.Empty;

    /// <summary>
    /// 날짜
    /// </summary>

    public DateTime? DateTime { get; set; }
}
