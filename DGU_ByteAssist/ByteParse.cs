using DGU.StringAssist;
using System;
using System.Linq;

namespace DGU.DGU_ByteAssist
{
	/// <summary>
	/// 문자열을 바이트로 변환하기위한 지원.
	/// <see href="https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ByteAssist">DGUtility_DotNet/DGU_ByteAssist/</see>/>
	/// </summary>
	public class ByteParse
	{
		/// <summary>
		/// 예외 처리용에러를 내고 싶다면 이것을 true로 바꿔준다.
		/// </summary>
		public static bool ExceptionOn = false;


		/// <summary>
		/// 문자열인데 바이트 배열  정보인 경우(예> "00-01-06-33")
		/// '-'를 기준으로 자르고 'byteOut'의 크기에 맞게 변환한다.<br />
		/// '0x'로 시작하면 '0x'를 제거하고 핵사 데이터 처리를 한다.(2칸씩 자름)
		/// <para>들어있는 비트정보와 'byteOut'의 크기가 다르면 변환이 잘못되거나
		/// 오류가 날수 있다.</para>
		/// </summary>
		/// <param name="sByteString">변환할 문자열</param>
		/// <param name="byteOut">출력에 사용할 바이트 배열</param>
		/// <returns>변환 성공 여부</returns>
		public static bool ByteArrayStringToByte(
			string sByteString
			, ref byte[] byteOut )
		{
			//변환 성공 여부
			bool bReturn = true;

			try
			{
				string[] sCutData;

				if (0 < sByteString.IndexOf("0x"))
				{//0x로 시작하는 핵사 데이터다.

					//'0x'를 제거하고
					string sTemp = sByteString.Replace("0x", "");
					//2칸(1바이트) 씩 자른다.
					sCutData = StringSplit.NLengthArray(sTemp, 2);
				}
				else if (0 < sByteString.IndexOf("-"))
				{
					//'-'으로 자르기
					sCutData = sByteString.Split('-');
				}
				else
				{//구분자가 없다.
					//2칸(1바이트) 씩 자른다.
					sCutData = StringSplit.NLengthArray(sByteString, 2);
				}

				
				//한칸씩 변환
				//문자열과 출력용 배열의 최소 크기만큼만 복사함
				for (int i = 0;
						(i < sCutData.Length) && (i < byteOut.Length);
						++i)
				{
					string itemCut = sCutData[i];
					
					ByteStringToByte(itemCut, ref byteOut[i]);
				}
			}
			catch
			{
				bReturn = false;

				if (true == ExceptionOn)
				{//예외 호출
					throw;
				}
			}

			return bReturn;
		}


		/// <summary>
		/// 문자열인데 바이트 핵사(hex) 정보를(예> "06"=6, "AC"=172, "0x12") 
		/// 바이트(한칸)로 변환한다.
		/// <para>들어있는 정보를 바이트 핵사 정보가 아니면 에러 난다.</para>
		/// <para>'0x00' 형태의 핵사 데이터는 '0x'를 제거하고 변환한다.</para>
		/// </summary>
		/// <param name="sByteString">변환할 문자열</param>
		/// <param name="byteOut">출력에 사용할 바이트 배열</param>
		/// <returns>변환 성공 여부</returns>
		public static bool ByteStringToByte(
			string sByteString
			, ref byte byteOut)
		{
			//변환 성공 여부
			bool bReturn = true;

			try
			{
				//'0x' 제거 하고
				//NumberStyles.HexNumber 스타일로 변환한다.
				byteOut
					= byte.Parse(
						sByteString.Replace("0x", "")
						, System.Globalization.NumberStyles.HexNumber);
			}
			catch 
			{
				bReturn = false;

				if (true == ExceptionOn)
				{//예외 호출
					throw;
				}
			}

			return bReturn;
		}

		/// <summary>
		/// 바이트를 1칸짜리 바이트 배열로 바꿔준다.
		/// </summary>
		/// <param name="byteData"></param>
		/// <returns></returns>
		public static byte[] ByteToByteArray(byte byteData)
		{
			byte[] byteReturn = new byte[1];
			byteReturn[0] = byteData;
			return byteReturn;
		}

		#region 지정한 크기보다 작은 바이트 배열이 넘어올때 사용하는 함수 모음

		/// <summary>
		/// 들어온 바이트 배열을 2바이트 배열로 바꾼다.
		/// <para>'byteData'의 크기가 2보다 크면 2칸 만큼의 데이터만 전달된다.</para>
		/// <para>지정한 크기보다 작은 바이트 배열이 넘어올때만 사용한다.</para>
		/// </summary>
		/// <param name="byteData"></param>
		/// <returns></returns>
		public static byte[] ByteTo2ByteArray(byte[] byteData)
		{
			return ByteToNByteArray(2, byteData);
		}

		/// <summary>
		/// 들어온 바이트 배열을 4바이트 배열로 바꾼다.
		/// <para>'byteData'의 크기가 4보다 크면 4칸 만큼의 데이터만 전달된다.</para>
		/// <para>지정한 크기보다 작은 바이트 배열이 넘어올때만 사용한다.</para>
		/// </summary>
		/// <param name="byteData"></param>
		/// <returns></returns>
		public static byte[] ByteTo4ByteArray(byte[] byteData)
		{
			return ByteToNByteArray(4, byteData);
		}

		/// <summary>
		/// 들어온 바이트 배열을 8바이트 배열로 바꾼다.
		/// <para>'byteData'의 크기가 8보다 크면 8칸 만큼의 데이터만 전달된다.</para>
		/// <para>지정한 크기보다 작은 바이트 배열이 넘어올때만 사용한다.</para>
		/// </summary>
		/// <param name="byteData"></param>
		/// <returns></returns>
		public static byte[] ByteTo8ByteArray(byte[] byteData)
		{
			return ByteToNByteArray(8, byteData);
		}

		/// <summary>
		/// 들어온 바이트 배열을 16바이트 배열로 바꾼다.
		/// <para>'byteData'의 크기가 16보다 크면 16칸 만큼의 데이터만 전달된다.</para>
		/// <para>지정한 크기보다 작은 바이트 배열이 넘어올때만 사용한다.</para>
		/// </summary>
		/// <param name="byteData"></param>
		/// <returns></returns>
		public static byte[] ByteTo16ByteArray(byte[] byteData)
		{
			return ByteToNByteArray(16, byteData);
		}

		/// <summary>
		/// 들어온 바이트 배열을 N칸 바이트 배열로 바꾼다.
		/// <para>'byteData'의 크기가 N보다 크면 N칸 만큼의 데이터만 전달된다.</para>
		/// <para>지정한 크기보다 작은 바이트 배열이 넘어올때만 사용한다.</para>
		/// </summary>
		/// <param name="nLength">만들 바이트 길이 N</param>
		/// <param name="byteData"></param>
		/// <returns></returns>
		public static byte[] ByteToNByteArray(int nLength, byte[] byteData)
		{
			byte[] byteReturn = new byte[nLength];

			int nLengthMax = byteData.Length;
			if (nLength < nLengthMax)
			{
				nLengthMax = nLength;
			}

			Array.Copy(byteData, byteReturn, nLengthMax);
			return byteReturn;
		}
		#endregion

	}
}
