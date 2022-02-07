﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DGU.EnumToClass
{
	/// <summary>
	/// 열거형의 멤버를 분해하여 배열형태로 관리 해주는 클래스.
	/// </summary>
	public class EnumList
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
		public EnumList()
		{
		}
		/// <summary>
		/// 지정한 열거형 맴버를 분해하여 개체를 생성함.
		/// </summary>
		/// <param name="typeData"></param>
		public EnumList(Enum typeData)
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

			//들어온 열거형을 리스트로 변환한다.
			Array arrayTemp = Enum.GetValues(this.EnumType.GetType());

			//맴버 갯수만큼 공간을 만들고
			this.EnumMember = new EnumMemberModel[arrayTemp.Length];

			//각 맴버를 입력한다.
			for (int i = 0; i < arrayTemp.Length; ++i)
			{
				this.EnumMember[i] = new EnumMemberModel(arrayTemp.GetValue(i));
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
			{	//검색된 데이터가 있다면
				//맨 첫번째 값을 저장
				emReturn = listEM[0];
			}

			return emReturn;
		}
	}
}