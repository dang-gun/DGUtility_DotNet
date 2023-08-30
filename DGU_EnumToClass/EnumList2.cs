using System;
using System.Collections.Generic;
using System.Linq;

namespace DGUtility.EnumToClass
{
    /// <summary>
    /// 지정한 열거형을 리스트로 바꾼다.
    /// </summary>
    /// <remarks>
    /// 중복된 값 처리를 위해 변경된 구조.<br />
    /// 중복된 값이 있는 열거형 맴버는 이 클래스로 처리해야 한다.
    /// </remarks>
    /// <typeparam name="T">변환할 열거형</typeparam>
    public class EnumList2<T> where T : Enum
	{
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
		/// 개체를 생성하고 열거형 리스트로 변환 작업을 시작한다.
		/// </summary>
		public EnumList2()
		{
			this.EnumToClass();
		}

		/// <summary>
		/// 지정된 열거형 맴버를 분해하여 리스트로 변환하는 작업을 한다.
		/// </summary>
		private void EnumToClass()
		{
			Type typeEnum = typeof(T);
			//Enum enumAA = (Enum)typeof(T);

			//이름 리스트와 벨류리스트의 순서가 같을 거라는 보장이 없다.
			//그래서 이름 리스트를 기준으로 작업한다.
			string[] listName = Enum.GetNames(typeEnum);

			//맴버 갯수만큼 공간을 만들고
			this.EnumMember = new EnumMemberModel[listName.Length];

			for (int i = 0; i < listName.Length; ++i)
			{
				//맴버의 값이 같은 경우 이름과 값이 매칭이 안될 수 있다.
				//그래서 맴버이름으로 값을 찾아 넣는다.

				//이름으로 값을 찾는다.
				int findValue =  (int)Enum.Parse(typeEnum, listName[i]);

				//중복값이 있을때 값으로 대상을 찾으면 동일한 대상이 나온다는 보장이 없다.
				//열거형은 이름으로 개체를 찾을 방법이 없으니 이 대상이 정확하리라는 보장은 없다.
				Enum enumData = (T)(object)findValue;

				this.EnumMember[i]
					= new EnumMemberModel(
						enumData
						, findValue
						, listName[i]
						, i);
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
	};
}
