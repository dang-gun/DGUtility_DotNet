﻿using DGUtility.ProjectXml;
using System.Text;


namespace DGUtility.EnumToClass;

/// <summary>
/// 열거형의 멤버를 분해하여 배열형태로 관리 해주는 클래스.
/// </summary>
///<remarks>
///EnumList1를 상속받아 동작할 수 있도록 수정해야 한다.
///</remarks>
public class EnumToModel
{
	/// <summary>
	/// 지정된 열거형
	/// </summary>
	public Enum? EnumType { get; private set; } = null;
	
	/// <summary>
	/// 지정된 열거형의 이름
	/// </summary>
	public string EnumName { get { return this.EnumType!.GetType().Name; } }
	/// <summary>
	/// 지정된 열거형의 네임스페이스
	/// </summary>
	public string EnumNamespace { get { return this.EnumType!.GetType().Namespace!; } }

	/// <summary>
	/// 분해한 열거형 멤버 데이터
	/// </summary>
	public EnumMemberModel[] EnumMember { get; private set; } = new EnumMemberModel[0];

	/// <summary>
	/// 지정된 열거형의 멤버 갯수
	/// </summary>
	public int Count
	{
		get
		{
			return this.EnumMember.Length;
		}
	}


	/// <summary>
	/// 사용할 프로젝트Xml
	/// </summary>
	public ProjectXmlAssist ProjectXml { get; set; }
		= new ProjectXmlAssist();

	/// <summary>
	/// 프로젝트 xml만 지정하여 초기화한다.
	/// </summary>
	/// <param name="projectXmlAssist"></param>
	public EnumToModel(ProjectXmlAssist projectXmlAssist)
	{
		this.ProjectXml = projectXmlAssist;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="typeData"></param>
	public EnumToModel(Enum typeData)
	{
		//원본 저장
		this.EnumType = typeData;
        this.Reset(typeData, null);
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="typeData"></param>
	/// <param name="projectXmlAssist"></param>
	public EnumToModel(Enum typeData, ProjectXmlAssist projectXmlAssist)
    {
        this.Reset(typeData, projectXmlAssist);
	}

	/// <summary>
	/// 사용할 타입을 설정한다.
	/// </summary>
	/// <remarks>
	/// ProjectXml은 가지고 있는 것을 쓴다.
	/// </remarks>
	/// <param name="typeData"></param>
	public void TypeData_Set(Enum typeData)
	{
		this.Reset(typeData, this.ProjectXml);
	}

	/// <summary>
	/// typeData와 projectXmlAssist를 저장하고 typeData의 맴버를 분해한다.
	/// </summary>
	/// <param name="typeData"></param>
	/// <param name="projectXmlAssist"></param>
	private void Reset(Enum typeData, ProjectXmlAssist? projectXmlAssist)
	{
		//원본 저장
		this.EnumType = typeData;
		if (null == projectXmlAssist)
		{
			this.ProjectXml = new ProjectXmlAssist();
		}
		else
		{
			this.ProjectXml = projectXmlAssist;
		}
		

		//들어온 열거형을 리스트로 변환한다.
		Array arrayTemp = Enum.GetValues(this.EnumType.GetType());

		//맴버 갯수만큼 공간을 만들고
		this.EnumMember = new EnumMemberModel[arrayTemp.Length];

		//각 맴버를 입력한다.
		for (int i = 0; i < arrayTemp.Length; ++i)
		{
			this.EnumMember[i] = new EnumMemberModel(arrayTemp.GetValue(i)!);
		}
	}

	/// <summary>
	/// 멤버중 지정한 이름이 있는지 찾습니다.
	/// </summary>
	/// <param name="sName"></param>
	/// <returns></returns>
	public EnumMemberModel? FindEnumMember(string sName)
	{
        EnumMemberModel? emReturn = null;
		List<EnumMemberModel> listEM = new List<EnumMemberModel>();

		//검색한다.
		listEM = this.EnumMember.Where(member => member.Name == sName).ToList();

		if (0 < listEM.Count)
		{	//검색된 데이터가 있다면
			//맨 첫번째 값을 저장
			emReturn = listEM[0];
		}

		return emReturn;
	}

	/// <summary>
	/// 지정된 ProjectXml리스트에서 주석정보를 찾는다.
	/// </summary>
	/// <param name="sTarget"></param>
	/// <returns></returns>
	public string ProjectXml_SummaryGet(string sTarget)
	{
		string sReturn = string.Empty;
		sReturn = this.ProjectXml.SummaryGet(sTarget);

		return sReturn;
	}


	/// <summary>
	/// 스크립트 형태의 문자열을 생성한다.
	/// </summary>
	/// <param name="sHead">첫 줄 열기로 사용할 문자열 포맷</param>
	/// <param name="sItemBody">아이템 바디로 사용할 문자열 포맷</param>
	/// <param name="sFooter">마지막 줄 닫기로 사용할 문자열 포맷</param>
	/// <returns></returns>
	public string ToScriptString(
		string sHead
		, string sItemBody
		, string sFooter)
	{
		StringBuilder sbReturn = new StringBuilder();



		//머리 만들기*********
		//주석 검색어 만들기 - 타입명
		string sT = string.Format("T:{0}.{1}"
										, this.EnumNamespace
										, this.EnumName);
		//주석 검색어 만들기 - 요소 명
		string sF = string.Format("F:{0}.{1}"
										, this.EnumNamespace
										, this.EnumName);

		//머리 주석
		if (null != this.ProjectXml)
		{
			string sHeadSummary
				= this.ProjectXml_SummaryGet(sT);

			if (string.Empty != sHeadSummary)
			{//주석 내용이 있다.
				sbReturn.Append(string.Format("/** {0} */" + Environment.NewLine
												, sHeadSummary));
			}
		}

		//머리 이름
		sbReturn.Append(string.Format(sHead
										, this.EnumName));

		for (int i = 0; i < this.Count; ++i)
		{
            EnumMemberModel itemEM = this.EnumMember[i];

			//검색어 완성 시키기
			string sF_Name = sF + "." + itemEM.Name;

			//주석
			if (null != this.ProjectXml)
			{
				string sSummary
					= this.ProjectXml_SummaryGet(sF_Name);

				if (string.Empty != sSummary)
				{//주석 내용이 있다.
					sbReturn.Append(string.Format(@"    /** {0} */" + Environment.NewLine
													, sSummary));
				}
			}

			//요소 추가
			sbReturn.Append(
				string.Format(sItemBody , itemEM.Name, itemEM.Index));
		}

		//꼬리 만들기
		sbReturn.Append(string.Format(sFooter, this.EnumName));

		return sbReturn.ToString();
	}
}
