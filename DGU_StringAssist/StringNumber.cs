using System;

namespace DGU.StringAssist
{
	/// <summary>
	/// 문자열로된 숫자를 처리하기위한 지원 기능
	/// </summary>
	public static class StringNumber
	{
		/// <summary>
		/// 입력된 문자열이 숫자로 변환 가능한지 여부를 판단한다.
		/// <para>null 이거나 빈 문자열은 false가 리턴된다.</para>
		/// </summary>
		/// <param name="value">판단할 문자열</param>
		/// <returns></returns>
		public static bool IsNumeric(string value)
		{
			if ((null == value)
				|| (true == string.IsNullOrEmpty(value))
				|| ("" == value))
			{
				//널이다
				return false;
			}

			int nIndex = 0;

			foreach (char itemChar in value)
			{
				if (false == Char.IsNumber(itemChar))
				{//숫자가 아니다.
				 //부호 판단
				 //인덱스가 0일때 '-'는 부호가 될수 있으므로 숫자로 판단한다.
					if ((0 == nIndex)
						&& ('-' != itemChar))
					{//인덱스가 0일때
					 //'-'가 아니다.
						return false;
					}
					else
					{//'-'이다.
					 //인엑스가 0일때 '-'이면 마이너스(-) 부호가 가능하므로
					 //숫자로 판단한다.
					}
				}

				++nIndex;
			}
			return true;
		}

		/// <summary>
		/// 문자열을 숫자로 바꾼다.
		/// <para>숫자로 바꿀수 없는 문자열은 0이 리턴된다.</para>
		/// </summary>
		/// <param name="sData">바꿀 데이터</param>
		/// <returns>변환된 숫자.</returns>
		public static int StringToInt(string sData)
		{
			int nReturn = 0;
			if (false == IsNumeric(sData))
			{
				nReturn = 0;
			}
			else
			{
				nReturn = Convert.ToInt32(sData);
			}

			return nReturn;
		}
	}
}
