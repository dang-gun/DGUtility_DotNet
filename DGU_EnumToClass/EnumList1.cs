using System;
using System.Collections.Generic;
using System.Linq;

namespace DGU.EnumToClass
{
	/// <summary>
	/// 열거형의 멤버를 분해하여 배열형태로 관리 해주는 클래스.
	/// <para>맴버의 값에 중복이 있다면 이 클래스를 사용할 수 없다.</para>
	/// </summary>
	public class EnumList1
	{
		/// <summary>
		/// 지정된 열거형
		/// </summary>
		public Enum EnumType { get; private set; }

		/// <summary>
		/// 분해한 열거형 멤버 데이터
		/// </summary>
		public EnumMemberModel[] EnumMember { get; private set; }

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
		/// 빈 개체를 생성함.
		/// </summary>
		public EnumList1()
		{
		}
		/// <summary>
		/// 지정한 열거형 맴버를 분해하여 개체를 생성함.
		/// </summary>
		/// <param name="typeData"></param>
		public EnumList1(Enum typeData)
		{
			this.EnumToClass(typeData);
		}

		/// <summary>
		/// 지정한 열거형 맴버를 분해하여 저장함
		/// </summary>
		/// <param name="typeData"></param>
		public void EnumToClass(Enum typeData)
		{
			//원본 저장
			this.EnumType = typeData;

			Type aaa = this.EnumType.GetType();

			//들어온 열거형을 리스트로 변환한다.
			Array arrayTemp = Enum.GetValues(this.EnumType.GetType());
			//이름 리스트와 벨류리스트의 순서가 같으리라는 보장이 없다.
			//string[] listName = Enum.GetNames(this.EnumType.GetType());


			//맴버 갯수만큼 공간을 만들고
			this.EnumMember = new EnumMemberModel[arrayTemp.Length];

			//각 맴버를 입력한다.
			for (int i = 0; i < arrayTemp.Length; ++i)
			{
				//맴버의 값이 같은 경우 이름과 값이 매칭이 안될 수 있다.
				//그래서 벨류리스트와 네임리스트를 각각 만들어서 수작업으로 매칭시킨다.
				//this.EnumMember[i] 
				//	= new EnumMemberModel(
				//		(Enum)arrayTemp.GetValue(i)
				//		, arrayTemp.GetValue(i).GetHashCode()
				//		, listName[i]
				//		, i);

				this.EnumMember[i]
					= new EnumMemberModel(arrayTemp.GetValue(i), i);
			}
		}

		/// <summary>
		/// 멤버중 지정한 이름이 있는지 찾습니다.
		/// </summary>
		/// <param name="sName"></param>
		/// <returns></returns>
		public EnumMemberModel FindEnumMember(string sName)
		{
			EnumMemberModel emReturn = null;
			List<EnumMemberModel> listEM = new List<EnumMemberModel>();

			//검색한다.
			listEM = this.EnumMember.Where(member => member.Name == sName).ToList();

			if (0 < listEM.Count)
			{   //검색된 데이터가 있다면
				//맨 첫번째 값을 저장
				emReturn = listEM[0];
			}

			return emReturn;
		}

		/// <summary>
		/// 멤버중 지정한 순서가 있는지 찾습니다.
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public EnumMemberModel FindEnumMember(int nNumber)
		{
			EnumMemberModel emReturn = null;
			List<EnumMemberModel> listEM = new List<EnumMemberModel>();

			//검색한다.
			listEM = this.EnumMember.Where(member => member.Number == nNumber).ToList();

			if (0 < listEM.Count)
			{   //검색된 데이터가 있다면
				//맨 첫번째 값을 저장
				emReturn = listEM[0];
			}

			return emReturn;
		}
	}
}

