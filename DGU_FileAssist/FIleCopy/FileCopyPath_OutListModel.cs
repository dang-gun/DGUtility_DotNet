﻿using System.Text;


namespace DGUtility.FileAssist.FileCopy;

/// <summary>
/// 파일 복사 경로 - 출력 리스트 모델
/// </summary>
/// <remarks>
/// 출력하는 경로가 여러개인 경우 이 모델을 사용한다.
/// </remarks>
public class FileCopyPath_OutListModel : FileCopyPathModel
{
    /// <summary>
    /// 파일을 저장할 위치 리스트(이름 제외)
    /// </summary>
    public List<string> TargetPathList { get; set; } = new List<string>();

    /// <summary>
    /// 파일을 저장할 위치 리스트 전체 경로
    /// </summary>
    public List<string> TargetPathListFull
    {
        get
        {
            List<string> listReturn = new List<string>();
            foreach (string item in TargetPathList)
            {
                listReturn.Add(Path.Combine(item, Name));
            }

            return listReturn;
        }
    }

    /// <summary>
    /// 파일을 저장할 위치 리스트(이름 제외) - 별도
    /// </summary>
    /// <remarks>
    /// TargetDirList와 별도로 관리하기위한 리스트<br />
    /// 특수한 경우 분리하기위한 용도로 사용할 수 있다.<br />
    /// 예> 디버깅에서만 출력하는 경로
    /// </remarks>
    public List<string> TargetPathList_Separate { get; set; } = new List<string>();
    /// <summary>
    /// 파일을 저장할 위치 리스트 전체 경로 - 별도
    /// </summary>
    public List<string> TargetPathListFull_Separate
    {
        get
        {
            List<string> listReturn = new List<string>();
            foreach (string item in TargetPathList_Separate)
            {
                listReturn.Add(Path.Combine(item, Name));
            }

            return listReturn;
        }
    }
}
