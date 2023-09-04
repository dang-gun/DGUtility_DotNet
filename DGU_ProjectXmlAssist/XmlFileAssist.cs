using DGUtility.FileAssist.FileCopy;

namespace DGUtility.XmlFileAssist;

/// <summary>
/// XML 파일 지원
/// </summary>
public class XmlFileAssist
{
    /// <summary>
    /// 프로젝트 루트 경로
    /// </summary>
    public string ProjectRootPath { get; set; }

    /// <summary>
    /// 출력 폴더 상대 경로
    /// </summary>
    public string OutputFolder_RelativePath { get; set; }

    /// <summary>
    /// 읽어들일 xml 파일 리스트
    /// </summary>
    public List<FileCopyDir_OutListModel> listProjectXmlDir { get; set; }
        = new List<FileCopyDir_OutListModel>();


    /// <summary>
    /// 읽어들인 xml 파일 
    /// </summary>
    /// <remarks>
    /// XmlFilePathReload()로 리스트를 읽어야 내용물이 채워진다.
    /// </remarks>
    public string[] XmlFilePathList { get; private set; } = new string[0];

    /// <summary>
    /// 출력 폴더 전체 경로
    /// </summary>
    public string OutputFolder_FullPath
    {
        get
        {
            return Path.Combine(ProjectRootPath, OutputFolder_RelativePath);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sProjectRootPath"></param>
    /// <param name="sOutputFolder_RelativePath"></param>
    public XmlFileAssist(
        string sProjectRootPath
        , string sOutputFolder_RelativePath)
    {
        this.ProjectRootPath = sProjectRootPath;
        this.OutputFolder_RelativePath = sOutputFolder_RelativePath;
    }

    /// <summary>
    /// 읽어들일 XML 파일을 리스트에 등록한다.
    /// </summary>
    /// <param name="sName">복사할 대상의 이름(확장자 포함)</param>
    /// <param name="sOriginalPath">ProjectRootPath 기준 상대 주소</param>
    public void XmlFilesAdd(
        string sName
        , string sOriginalPath)
    {
        this.listProjectXmlDir
                .Add(new FileCopyDir_OutListModel()
                {
                    Name = sName
                    , OriginalPath = Path.GetFullPath(sOriginalPath, ProjectRootPath)
                    , TargetPath = this.OutputFolder_FullPath
                });
    }

    /// <summary>
    /// XML 파일 복사
    /// </summary>
    public void XmlFilesCopy()
    {
        
        Console.WriteLine("====== XML Files copy ======");

        //파일 복사 *****************************
        foreach (FileCopyDir_OutListModel item in listProjectXmlDir)
        {
            string sOriginalFullDir = item.OriginalFullDir;

            if (true == File.Exists(sOriginalFullDir))
            {//원본 파일이 있다.

                //대상 위치에 복사
                File.Copy(sOriginalFullDir, item.TargetDirFull, true);
                Console.WriteLine($"file copy {sOriginalFullDir}, {item.TargetDirFull}");
            }
        }
    }//end XmlFilesCopy()


    /// <summary>
    /// 로컬에 있는 xml 파일리스트를 다시 읽어들인다.
    /// </summary>
    /// <remarks>
    /// 보통은 한번만 읽으면 되지만 파일리스트가 빈번하게 변경된다면 자주 읽어야 할 수 있다.
    /// </remarks>
    public void XmlFilePathReload()
    {
        DirectoryInfo dir = new DirectoryInfo(OutputFolder_FullPath);
        List<string> listFilePath = new List<string>();

        foreach (FileInfo fileItem in dir.GetFiles())
        {
            listFilePath.Add(fileItem.FullName);
        }

        this.XmlFilePathList = listFilePath.ToArray();
    }
}
