using System.Text;


namespace DGUtility.FileAssist.FileCopy;

/// <summary>
/// 파일 복사 경로 모델
/// </summary>
public class FileCopyDirModel
{
    /// <summary>
    /// 파일의 이름(확장자 포함)
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 원본 파일 위치(이름 제외)
    /// </summary>
    public string OriginalPath { get; set; } = string.Empty;
    /// <summary>
    /// 원본 파일의 전체 경로
    /// </summary>
    public string OriginalFullDir
    {
        get
        {
            return Path.Combine(OriginalPath, Name);
        }
    }

    /// <summary>
    /// 파일을 저장할 위치(이름 제외)
    /// </summary>
    public string TargetPath { get; set; } = string.Empty;
    /// <summary>
    /// 파일을 저장할 위치의 전체 경로
    /// </summary>
    public string TargetDirFull
    {
        get
        {
            return Path.Combine(TargetPath, Name);
        }
    }

}
