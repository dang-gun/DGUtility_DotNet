using DGUtility.DirectoryAssist;
using System.Text;


namespace DGUtility.FileAssist.FileSave;

/// <summary>
/// 파일 저장 관련
/// </summary>
public class FileSaveAssist
{
    /// <summary>
    /// 디렉터리 체크 관련
    /// </summary>
    private DirectoryCheckAssist DirCheckAssist = new DirectoryCheckAssist();

    /// <summary>
    /// 경로에 디랙토리와 파일을 생성하고 내용을 저장한다.
    /// </summary>
    /// <param name="sFullFilePath"></param>
    /// <param name="sContents">문자열로된 내용</param>
    public void FileSave(string sFullFilePath, string sContents)
    {
        //디랙토리 생성 체크
        DirectoryCheckType typeDCT
            = DirCheckAssist.DirectoryCheckAndCreate(sFullFilePath);

        using (StreamWriter stream = new(sFullFilePath, false, Encoding.UTF8))
        {
            //파일 저장
            stream.Write(sContents);
        }//end using stream
    }

    /// <summary>
    /// 경로에 디랙토리와 파일을 생성하고 내용을 저장한다.
    /// </summary>
    /// <param name="sFullFilePath"></param>
    /// <param name="byteContents">바이너리 내용</param>
    public void FileSave(string sFullFilePath, byte[] byteContents)
    {
        //디랙토리 생성 체크
        DirectoryCheckType typeDCT
            = DirCheckAssist.DirectoryCheckAndCreate(sFullFilePath);

        using (BinaryWriter Writer = new(File.OpenWrite(sFullFilePath)))
        {
            try
            {
                //파일 저장
                Writer.Write(byteContents);
                Writer.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception($"FileSaveAssist > FileSave : {ex.Message}");
            }
            finally 
            {
                
                Writer.Close();
            }
        }//end using Writer
    }
}
