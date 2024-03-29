﻿using System.Text;


namespace DGUtility.ModelToFrontend;

/// <summary>
/// 최종 출력을 위해 텍스트를 정리해둔 모델
/// </summary>
public class ModelToTextModel
{
    /// <summary>
    /// 임포트 영역
    /// </summary>
    /// <remarks>
    /// C#은 using 영역
    /// </remarks>
    public StringBuilder Import = new StringBuilder();
    /// <summary>
    /// 임포트 영역 추가 영역
    /// </summary>
    public List<string> ImportAdd = new List<string>();


    /// <summary>
    /// 머리 주석
    /// </summary>
    public StringBuilder HeadSummary = new StringBuilder();
    /// <summary>
    /// 머리 이름
    /// </summary>
    public StringBuilder HeadName = new StringBuilder();

    /// <summary>
    /// 요소
    /// </summary>
    public List<ModelToTextItemModel> ItemList = new List<ModelToTextItemModel>();

    /// <summary>
    /// 바닥
    /// </summary>
    public StringBuilder Footer = new StringBuilder();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder sbReturn = new StringBuilder();

        if(string.Empty != this.Import.ToString()
                                    .Replace(Environment.NewLine, string.Empty))
        {//값이 있다.(줄 바꿈문자는 무시)

            //값이 있을때만 출력
            sbReturn.AppendLine(this.Import.ToString());

            //빈줄 하나 추가
            sbReturn.AppendLine();
        }
        
        foreach(string sItem in this.ImportAdd)
        {
            sbReturn.AppendLine(sItem);
        }
        

        if(0 < this.ImportAdd.Count)
        {//this.ImportAdd가 있다.

            //빈줄 하나 추가
            sbReturn.AppendLine();
        }
        

        sbReturn.Append(this.HeadSummary);
        sbReturn.Append(this.HeadName);

        foreach(ModelToTextItemModel item in this.ItemList)
        {
            sbReturn.Append(item.Summary);
            sbReturn.Append(item.Item);
        }

        sbReturn.Append(this.Footer);

        return sbReturn.ToString();
    }
}

/// <summary>
/// 최종 출력을 위해 텍스트를 정리해둔 모델의 아이템
/// </summary>
public class ModelToTextItemModel
{
    /// <summary>
    /// 주석
    /// </summary>
    public StringBuilder Summary = new StringBuilder();

    /// <summary>
    /// 요소 선언
    /// </summary>
    public StringBuilder Item = new StringBuilder();
}

/// <summary>
/// Import 출력에 넣을 개체
/// </summary>
public class ModelToTextImportModel
{
    /// <summary>
    /// 선언된 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// 이름까지 포함된 출력된 물리 경로(확장자는 제외)
    /// </summary>
    public string OutPhysicalFullPath { get; set; } = string.Empty;
}