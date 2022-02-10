using System;

namespace DGU.EnumToClass
{
	/// <summary>
	/// 열거형 멤버의 정보를 검색하기 쉽게 저장하는 모델
	/// </summary>
	public class EnumMemberModel
	{

		/// <summary>
		/// 지정된 열겨헝 멤버
		/// </summary>
		public Enum Type { get; private set; }
		/// <summary>
		/// 지정된 열겨헝 멤버의 이름
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// 지정된 열거헝 멤버의 인덱스
		/// </summary>
		public int Index { get; private set; }
		/// <summary>
		/// 숫서(고유번호)
		/// <para>열거형맴버가 리스트로 변환될때 순서<br />
		/// 열거형 맴버의 인덱스는 중복이 가능해서 그걸 구분하기위한 고유번호로도 사용된다.
		/// </para>
		/// </summary>
		public int Number { get; private set; }

		/// <summary>
		/// 사용할 열거형 멤버를 오브젝트(object)형태로 처리합니다.
		/// </summary>
		/// <param name="objData"></param>
		public EnumMemberModel(object objData)
		{
			SetData(objData as Enum);
		}
		/// <summary>
		/// 사용할 열거형 멤버를 오브젝트(object)형태로 처리합니다.
		/// </summary>
		/// <param name="objData"></param>
		/// <param name="nNumber"></param>
		public EnumMemberModel(object objData, int nNumber)
		{
			SetData(objData as Enum, nNumber);
		}

		/// <summary>
		/// 사용할 열거형 멤버를 지정합니다.
		/// </summary>
		/// <param name="typeData"></param>
		public EnumMemberModel(Enum typeData)
		{
			SetData(typeData);
		}
		/// <summary>
		/// 사용할 열거형 멤버를 지정합니다.
		/// </summary>
		/// <param name="typeData"></param>
		/// <param name="nNumber"></param>
		public EnumMemberModel(Enum typeData, int nNumber)
		{
			SetData(typeData, nNumber);
		}

		/// <summary>
		/// 사용할 열거형 멤버를 지정하고 순서를 0으로 초기화 한다.
		/// </summary>
		/// <param name="typeData"></param>
		public void SetData(Enum typeData)
		{
			this.SetData(typeData, 0);
		}
		/// <summary>
		/// 필요한 데이터를 기록 합니다.
		/// </summary>
		/// <param name="typeData"></param>
		/// <param name="nNumber"></param>
		private void SetData(Enum typeData, int nNumber)
		{
			this.Type = typeData;
			this.Index = this.Type.GetHashCode();
			this.Name = this.Type.ToString();

			this.Number = nNumber;
		}
	}
}
