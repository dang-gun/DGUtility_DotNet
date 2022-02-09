using System;
using System.Collections.Generic;

namespace DGU.DGU_ByteAssist
{
	/// <summary>
	/// byte 배열을 처리하기위한 유틸리티
	/// <para>Buffer.BlockCopy는 인덱스 기반, Array.Copy는 참조 기반이다.</para>
	/// <para>성능은 Array.Copy가 약간 더 빠르다.</para>
	/// <seealso href="http://stackoverflow.com/questions/1389821/array-copy-vs-buffer-blockcopy">Array.Copy vs Buffer.BlockCopy</seealso>
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

			//return byteA;
		}

		/// <summary>
		/// 데이터의 앞을 지정한 크기 만큼 지운다.
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
		/// 바이트 배열을 byteSplit잘라 리턴한다.
		/// <see href="https://www.codeproject.com/Answers/511256/Howplustoplussplitplusbyteplusarray#answer3">How to split byte array</see>
		/// </summary>
		/// <param name="byteOriginal"></param>
		/// <param name="byteSplit"></param>
		/// <returns></returns>
		public static List<byte[]> Split(byte[] byteOriginal, byte[] byteSplit)
		{
			List<byte[]> listReturn = new List<byte[]>();

			foreach (var packet in Packetize(byteOriginal))
			{
				List<byte> listOneLine = new List<byte>();

				foreach (byte b in packet)
				{
					Console.Write("{0:x2} ", b);
					listOneLine.Add(b);
				}
				listReturn.Add(listOneLine.ToArray());
			}

			return listReturn;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		private static IEnumerable<byte[]> Packetize(IEnumerable<byte> stream)
		{
			var buffer = new List<byte>();
			foreach (byte b in stream)
			{
				buffer.Add(b);
				if (b == 0x1E || b == 0x1F || b == 0x07)
				{
					buffer.Remove(b);
					yield return buffer.ToArray();
					buffer.Clear();
				}
			}
			if (buffer.Count > 0)
				yield return buffer.ToArray();
		}
	}
}
