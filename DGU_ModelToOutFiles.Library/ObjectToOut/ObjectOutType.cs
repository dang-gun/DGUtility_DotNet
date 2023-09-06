namespace DGUtility.ModelToOutFiles.Library.ObjectToOut;

/// <summary>
/// 오브젝트 출력 타입
/// </summary>
public enum ObjectOutType
{
    /// <summary>
    /// 상태 없음
    /// </summary>
    None = 0,

    /// <summary>
    /// 클래스
    /// </summary>
    Class,

    /// <summary>
    /// 열거형
    /// </summary>
    Enum,

    /// <summary>
    /// 열거형 - const를 붙이지 않음
    /// </summary>
    Enum_ConstNo,

    /// <summary>
    /// JSON 출력
    /// </summary>
    /// <remarks>
    /// JSON 출력은 문자열 출력이라 별도의 추가처리를 하지 않는다.
    /// </remarks>
    Json,

    /// <summary>
    /// Enum의 값을 그대로 출력할 필요가 있는경우 사용.
    /// Json옵션은 Enum도 문자열로 출력한다.
    /// </summary>
    Json_Enum,
}
