using System;

namespace DGU.EnumToClass
{
	/// <summary>
	/// 열거형 멤버의 정보를 검색하기 쉽게 저장하는 모델
	/// </summary>
	public class EnumMemberModel
	{

		/// <summary>
		/// 지정된 열거헝 멤버
		/// <para>열거형 맴버중에 같은 값을 가진 맴버가 있다면 이 값은 정확하지 않을 수 있다.</para>
		/// </summary>
		public Enum Type { get; protected set; }
		/// <summary>
		/// 지정된 열겨헝 멤버의 이름
		/// </summary>
		public string Name { get; protected set; }
		/// <summary>
		/// 지정된 열거헝 멤버의 인덱스
		/// </summary>
		public int Index { get; protected set; }
		/// <summary>
		/// 숫서(고유번호)
		/// <para>열거형맴버가 리스트로 변환될때 순서<br />
		/// 열거형 맴버의 인덱스는 중복이 가능해서 그걸 구분하기위한 고유번호로도 사용된다.
		/// </para>
		/// </summary>
		public int Number { get; protected set; }

		/// <summary>
		/// 사용할 열거형 멤버를 오브젝트(object)형태로 처리합니다.
		/// </summary>
		/// <param name="objData">Enum로 변환이 가능한 대상 개체</param>
		public EnumMemberModel(object objData)
		{
			SetData(objData as Enum);
		}
		/// <summary>
		/// 사용할 열거형 멤버를 오브젝트(object)형태로 처리합니다.
		/// </summary>
		/// <param name="objData">Enum로 변환이 가능한 대상 개체</param>
		/// <param name="nNumber">순서 정보</param>
		public EnumMemberModel(object objData, int nNumber)
		{
			SetData(objData as Enum, nNumber);
		}
		/// <summary>
		/// 사용할 열거형 멤버 생성하고 정보를 저장한다.
		/// </summary>
		/// <param name="typeData">이 맴버를 생성할때 사용하는 열거형 맴버</param>
		/// <param name="nIndex">맴버가 가지고 있는 값</param>
		/// <param name="sName">맴버의 이름</param>
		/// <param name="nNumber">순서 정보</param>
		public EnumMemberModel(
			Enum typeData
			, int nIndex
			, string sName
			, int nNumber)
		{
			this.SetData(typeData, nIndex, sName, nNumber);
		}

		/// <summary>
		/// 사용할 열거형 멤버를 지정한다.
		/// </summary>
		/// <param name="typeData">이 맴버를 생성할때 사용하는 열거형 맴버</param>
		public EnumMemberModel(Enum typeData)
		{
			this.SetData(typeData);
		}
		/// <summary>
		/// 사용할 열거형 멤버를 지정한다.
		/// </summary>
		/// <param name="typeData">이 맴버를 생성할때 사용하는 열거형 맴버</param>
		/// <param name="nNumber">순서 정보</param>
		public EnumMemberModel(Enum typeData, int nNumber)
		{
			this.SetData(typeData, nNumber);
		}

		/// <summary>
		/// 사용할 열거형 멤버를 지정하고 순서를 0으로 초기화 한다.
		/// </summary>
		/// <param name="typeData">이 맴버를 생성할때 사용하는 열거형 맴버</param>
		public void SetData(Enum typeData)
		{
			this.SetData(typeData, 0);
		}
		/// <summary>
		/// 필요한 데이터를 기록 한다.
		/// </summary>
		/// <param name="typeData">이 맴버를 생성할때 사용하는 열거형 맴버</param>
		/// <param name="nNumber">순서 정보</param>
		public void SetData(Enum typeData, int nNumber)
		{
			this.Type = typeData;
			this.Index = this.Type.GetHashCode();
			this.Name = this.Type.ToString();

			this.Number = nNumber;
		}

		/// <summary>
		/// 필요한 데이터를 기록 한다.
		/// </summary>
		/// <param name="typeData">이 맴버를 생성할때 사용하는 열거형 맴버</param>
		/// <param name="nIndex">맴버가 가지고 있는 값</param>
		/// <param name="sName">맴버의 이름</param>
		/// <param name="nNumber">순서 정보</param>
		public void SetData(
			Enum typeData
			, int nIndex
			, string sName
			, int nNumber)
		{
			this.Type = typeData;
			this.Index = nIndex;
			this.Name = sName;

			this.Number = nNumber;
		}
	}
}
