namespace DGU_ConsoleAssist;

/// <summary>
/// 메뉴로 사용될 모델
/// </summary>
/// <remarks>
/// 매치 우선 순위는 주석에 있다.(null이면 매치에서 무시됨)
/// </remarks>
public class MenuModel
{
    /// <summary>
    /// 화면에 표시할 고유번호(우선 순위 : 2)
    /// <para>Index와 MatchString이 둘다 null이면 한줄 띄어 준다.</para>
    /// </summary>
    /// <remarks>
    /// 인덱스가 겹치면 맨 처음 발견된 인덱스가 우선순위가 된다.
    /// </remarks>
    public int? Index { get; set; }

    /// <summary>
    /// 매칭에 사용될 문자열(우선 순위 : 1)
    /// <para>Index와 MatchString이 둘다 null이면 한줄 띄어 준다.</para>
    /// </summary>
    /// <remarks>
    /// 비교할때는 대소문자를 가리지 않는다.
    /// <para>매치스트링이 겹치면 맨 처음 발견된 인덱스가 우선순위가 된다.</para>
    /// </remarks>
    public string? MatchString { get; set; }

    /// <summary>
    /// 표시될 텍스트
    /// </summary>
    /// <remarks>
    /// .NET String.Format 형식으로 넣는다.
    /// <para>{0}에 this.MatchString가 표시된다.</para>
    /// </remarks>
    public string TextFormat { get; set; } = string.Empty;

    /// <summary>
    /// 메뉴가 선택됐을 때 동작
    /// <para>MenuModel : 이 개체(this) </para>
    /// <para>return bool : 메뉴를 유지 시킬지 여부(false 이면 메뉴에서 나감) </para>
    /// </summary>
    public Func<MenuModel, bool>? Action { get; set; }
}
