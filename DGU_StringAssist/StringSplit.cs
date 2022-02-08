using System;

namespace DGU.StringAssist
{
	/// <summary>
	/// 문자열 자르기 관련 기능
	/// </summary>
	public static class StringSplit
	{
		/// <summary>
		/// 문자열을 지정된 길이만큼 여러번 잘라 배열로 만든다.
		/// </summary>
		/// <param name="sData"></param>
		/// <param name="nCutLength">자를 길이</param>
		/// <returns></returns>
		public static string[] NLengthArray(
			string sData
			, int nCutLength)
		{

			//리턴할 문자열 배열
			//sData.Length / nCutLength 만큼 칸을 만들고
			//나머지가 있으면 한칸 더 만든다. 
			string[] stringReturn 
				= new string[sData.Length / nCutLength
							+ (sData.Length % nCutLength == 0 ? 0 : 1)];

			for (int i = 0; i < stringReturn.Length; i++)
			{

				//시작 위치 = 인덱스 * 자를 길이
				int nStart = i * nCutLength;
				//자를 양
				int nCutLengthMax = nCutLength;
				if (sData.Length < nStart + nCutLengthMax)
				{//시작위치 + 자를양이 전체 문자열 길이보다 길다.

					//남은 자를양 = 문자열 길이 - 시작위치
					nCutLengthMax = sData.Length - nStart;
				}
				
				//자른만큼 복사
				stringReturn[i] = sData.Substring(nStart, nCutLengthMax);
			}

			return stringReturn;
		}
	}
}
