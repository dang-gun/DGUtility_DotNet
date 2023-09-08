using System.Text;


namespace DGUtility.DirectoryAssist;

/// <summary>
/// 디랙토리 체크 관련
/// </summary>
public enum DirectoryCheckType
{
    /// <summary>
    /// 상태 없음
    /// </summary>
    None = 0,

    /// <summary>
    /// 이미 있음
    /// </summary>
    AlreadyExists,

    /// <summary>
    /// 생성 성공
    /// </summary>
    CreateSuccess,
    /// <summary>
    /// 생성 실패
    /// </summary>
    CreateFail,
}
