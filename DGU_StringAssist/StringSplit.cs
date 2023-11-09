using System;

namespace DGU.StringAssist
{
	/// <summary>
	/// 문자열 자르기 관련 기능
	/// </summary>
	public class StringSplit
	{
		/// <summary>
		/// 문자열을 지정된 길이만큼 여러번 잘라 배열로 만든다.
		/// </summary>
		/// <param name="sData"></param>
		/// <param name="nCutLength">자를 길이</param>
		/// <returns></returns>
		public string[] NLengthArray(
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


        /// <summary>
        /// 왼쪽 부터 지정된 길이만큼 잘라서 리턴한다.
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/a/7574615/6725889
        /// </remarks>
        /// <param name="value"></param>
        /// <param name="nMaxLength">출력할 길이
        /// <para>value가 nMaxLength보다 짧으면 value가 그대로 출력됨</para></param>
        /// <returns></returns>
        public string Left(string value, int nMaxLength)
        {
            string sReturn = value;

            if (false == string.IsNullOrEmpty(value)
                && 0 < nMaxLength)
            {//빈값이 아니고
             //입력된 길이가 0보다 크다.


                //출력할 길이가 정상이다.
                if (value.Length <= nMaxLength)
                {//value가 지정된 길이 이하다

                    //전체 출력
                }
                else
                {
                    //아니면 잘라준다.
                    sReturn = value.Substring(0, nMaxLength);
                }
            }

            return sReturn;
        }

    }//end class
}//end namespace
