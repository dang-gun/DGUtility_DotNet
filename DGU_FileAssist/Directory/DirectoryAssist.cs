using DGUtility.FileAssist.FileSave;
using System.Text;


namespace DGUtility.DirectoryAssist;

/// <summary>
/// 디렉터리 체크 관련
/// </summary>
public class DirectoryCheckAssist
{
    /// <summary>
    /// 파일 전체 경로를 가지고 디랙토리가 있는지 확인하고 없으면 생성한다.
    /// </summary>
    /// <param name="sFullFilePath">디랙토리 전체 경로</param>
    /// <returns></returns>
	public DirectoryCheckType DirectoryCheckAndCreate(string sFullFilePath)
    {
        DirectoryCheckType typeReturn = DirectoryCheckType.None;

        string? sDirectoryPath = Path.GetDirectoryName(sFullFilePath);
        if (sDirectoryPath != null)
        {
            if (true == Directory.Exists(sDirectoryPath))
            {//디랙토리가 이미 있다.
                typeReturn = DirectoryCheckType.AlreadyExists;
            }
            else
            {//디랙토리가 없다.

                try
                {
                    //디랙토리 생성
                    Directory.CreateDirectory(sDirectoryPath);
                    typeReturn = DirectoryCheckType.CreateSuccess;
                }
                catch (Exception ex)
                {
                    typeReturn = DirectoryCheckType.CreateFail;
                    throw new Exception($"DirectoryCheckAssist > DirectoryCheckAndCreate : {ex.Message}");
                }
            }
        }


        return typeReturn;
    }
}
