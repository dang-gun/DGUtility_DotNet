using System;
using System.Collections.Generic;

namespace DGU.DGU_ByteAssist
{
	/// <summary>
	/// byte 배열을 처리하기위한 유틸리티
	/// <see href="https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ByteAssist">DGUtility_DotNet/DGU_ByteAssist/</see>/>
	/// <para>Buffer.BlockCopy는 인덱스 기반, Array.Copy는 참조 기반이다.</para>
	/// <para>성능은 Array.Copy가 약간 더 빠르다.</para>
	/// <see href="http://stackoverflow.com/questions/1389821/array-copy-vs-buffer-blockcopy">Array.Copy vs Buffer.BlockCopy</see>
	/// </summary>
	public static class ByteArray
	{
		/// <summary>
		/// byteA와 byteB를 합친다.
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="byteB"></param>
		/// <returns></returns>
		public static byte[] Combine(byte[] byteA, byte[] byteB)
		{
			byte[] byteReturn = new byte[byteA.Length + byteB.Length];

			//Buffer.BlockCopy(byteA, 0, byteReturn, 0, byteA.Length);
			//Buffer.BlockCopy(byteB, 0, byteReturn, byteA.Length, byteB.Length);

			Array.Copy(byteA, 0, byteReturn, 0, byteA.Length);
			Array.Copy(byteB, 0, byteReturn, byteA.Length, byteB.Length);

			return byteReturn;
		}

		/// <summary>
		/// byteB의 내용을 그대로 byteA로 복사한다.<br />
		/// 입력값의 크기가 다른건 예외처리 하지 않음.
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="byteB"></param>
		/// <returns></returns>
		public static void Copy_All(out byte[] byteA, byte[] byteB)
		{
			byteA = new byte[byteB.Length];
			Array.Copy(byteB, 0, byteA, 0, byteB.Length);
		}

		/// <summary>
		/// byteB의 내용을 그대로 byteA로 복사하는데 byteA 크기 만큼만 복사한다.
		/// (byteA의 크기조절 없음)
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="byteB"></param>
		/// <returns></returns>
		public static void Copy_CutAll(ref byte[] byteA, byte[] byteB)
		{
			int nLength = byteA.Length;
			if (byteA.Length > byteB.Length)
			{
				nLength = byteB.Length;
			}
			

			Array.Copy(byteB, 0, byteA, 0, nLength);
		}

		/// <summary>
		/// 데이터의 앞을 지정한 크기 만큼 지운 새로운 개체를 리턴한다.
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="nLength"></param>
		/// <returns></returns>
		public static byte[] Remove_Left(byte[] byteA, int nLength)
		{
			byte[] byteReturn = new byte[byteA.Length - nLength];
			Array.Copy(byteA, nLength, byteReturn, 0, byteReturn.Length);

			return byteReturn;
		}

		/// <summary>
		/// 데이터의 뒤를 지정한 크기만큼 지운다.
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="nLength"></param>
		/// <returns></returns>
		public static byte[] Remove_Right(byte[] byteA, int nLength)
		{
			byte[] byteReturn = new byte[byteA.Length - nLength];
			Array.Copy(byteA, 0, byteReturn, 0, byteReturn.Length);

			return byteReturn;
		}

		/// <summary>
		/// 빈값이 찾고 찾은 자리에서 부터 오른쪽 내용을 지운다.
		/// </summary>
		/// <param name="byteA"></param>
		/// <returns></returns>
		public static byte[] Remove_Right_Null(byte[] byteA)
		{
			//뒤에서 부터 검색한다.
			int nCount = byteA.Length - 1;

			//빈값이 없을때까지 찾는다.
			while (0 == byteA[nCount])
			{
				--nCount;
			}

			byte[] byteReturn = new byte[nCount + 1];
			Array.Copy(byteA, byteReturn, nCount + 1);

			return byteReturn;
		}

		/// <summary>
		/// 데이터의 왼쪽에서 부터 지정된 위치만큼 잘라서 두 데이터를 리턴한다.
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="nLength"></param>
		/// <returns></returns>
		public static List<byte[]> Cut_Left(byte[] byteA, int nLength)
		{
			List<byte[]> listReturn = new List<byte[]>();

			byte[] byteCut1 = new byte[nLength];
			byte[] byteCut2 = new byte[byteA.Length - nLength];

			Array.Copy(byteA, 0, byteCut1, 0, byteCut1.Length);
			Array.Copy(byteA, nLength, byteCut2, 0, byteCut2.Length);

			listReturn.Add(byteCut1);
			listReturn.Add(byteCut2);

			return listReturn;
		}

		/// <summary>
		/// 왼쪽부터 지정한 길이만큼 데이터를 가지고 온다.
		/// </summary>
		/// <param name="byteA"></param>
		/// <param name="nLength"></param>
		/// <returns></returns>
		public static byte[] Get_Left(byte[] byteA, int nLength)
		{
			byte[] byteCut = new byte[nLength];

			int nLeng = nLength;
			if (byteA.Length <= nLength)
			{//데이터가 입력된 길이보다 작다.

				//데이터 길이만큼만 사용한다.
				nLeng = byteA.Length;
			}

			Array.Copy(byteA, 0, byteCut, 0, nLeng);

			return byteCut;
		}

		/// <summary>
		/// 원본에서 저장할 대상에 크기만큼 복사한후 계산된 위치를 반환한다.
		/// </summary>
		/// <param name="byteOriginal">원본</param>
		/// <param name="byteStorage">저장할 대상</param>
		/// <param name="nOffsetStart">오프셋 시작</param>
		/// <returns>이동이 끝나 다시 계산된 오프셋시작 위치</returns>
		public static int ArrayCopyOffset(
			byte[] byteOriginal
			, byte[] byteStorage
			, int nOffsetStart)
		{
			Array.Copy(byteOriginal, nOffsetStart, byteStorage, 0, byteStorage.Length);

			//오프셋 스타트지점에서 사용한 만큼 더해서 리턴한다.
			return nOffsetStart + byteStorage.Length;
		}

        /// <summary>
        /// 지정된 배열을 지정된 값에 따라 잘라서 리턴한다.
        /// </summary>
        /// <param name="byteOriginal"></param>
        /// <param name="nStartIndex">시작 인덱스</param>
        /// <param name="nCutLength">자를 크기</param>
        /// <returns></returns>
        public static byte[] SubByte(
            byte[] byteOriginal
            , int nStartIndex
            , int nCutLength)
		{
            byte[] arrReturn = new byte[nCutLength];
            Array.Copy(byteOriginal, nStartIndex, arrReturn, 0, nCutLength);
            return arrReturn;
        }

        /// <summary>
        /// 바이트 배열을 byteSplit잘라 리턴한다.
        /// <see href="https://www.codeproject.com/Answers/511256/Howplustoplussplitplusbyteplusarray#answer3">How to split byte array</see>
        /// </summary>
        /// <param name="byteOriginal"></param>
        /// <param name="byteSplit">자를 코드(1자리만 가능)</param>
        /// <returns></returns>
        public static List<byte[]> Split(byte[] byteOriginal, byte byteSplit)
		{
			List<byte[]> listReturn = new List<byte[]>();

			foreach (byte[] packet in Packetize(byteOriginal, byteSplit))
			{//오리지널 크기만큼 비교 시작
				listReturn.Add(packet);
			}

			return listReturn;
		}

		/// <summary>
		/// byteSplit가 나타날때까지의 바이트를 리턴한다.
		/// <para>yield return에 의해 동작하므로 foreach를 써서 리턴받아야 한다.</para>
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="byteSplit"></param>
		/// <returns></returns>
		private static IEnumerable<byte[]> Packetize(
			IEnumerable<byte> stream
			, byte byteSplit)
		{
			var buffer = new List<byte>();
			foreach (byte b in stream)
			{
				buffer.Add(b);
				if (b == byteSplit)
				{//스플릿 문자다.
					
					//스플릿에 사용하는 문자는 제거한다.
					buffer.Remove(b);
					yield return buffer.ToArray();
					buffer.Clear();
				}
			}
			if (buffer.Count > 0)
			{//버퍼에 데이터가 남아 있다.
				//모든 데이터를 다 읽었는데 루프에 데이터가 남아 있다는 것은
				//스플릿을 찾기전에 데이터가 끝났다는 뜻이다.
				//마지막 데이터를 리턴해주고 끝낸다.
				yield return buffer.ToArray();
			}
				
		}
	}
}
