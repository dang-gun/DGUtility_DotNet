
namespace DGU_ModelToOutFiles.Global;

/// <summary>
/// 출력 언어 타입
/// </summary>
public enum OutputLanguageType
{
    /// <summary>
    /// 설정안함
    /// </summary>
    /// <remarks>
    /// 오류로 사용됨
    /// </remarks>
    None = 0,

    /// <summary>
    /// 타입스크립트
    /// </summary>
    TypeScript,

    /// <summary>
    /// 테스트용(사용 안함)
    /// </summary>
    Test,
}
