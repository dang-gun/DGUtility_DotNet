using System;
using System.Net;

namespace DGU.NetworkAssist
{
	/// <summary>
	/// IP처리 관련 유틸리티
	/// </summary>
	public class IpAddresses
	{
		#region 외부에 연결할 이벤트
		/// <summary>
		/// 'IpAddresses'의 에러 타입
		/// </summary>
		public enum ErrorType
		{
			/// <summary>
			/// 지정된 호스트네임에서 IP를 찾을 수 없다.
			/// </summary>
			NotFindIP,
			/// <summary>
			/// 지정된 호스트네임에 2개 이상의 IP가 있다.
			/// </summary>
			MoreIP,
		}

		/// <summary>
		/// 'IpAddresses'개체 처리시 발생하는 에러 대리자
		/// </summary>
		public delegate void ErrorDelegate(ErrorType typeError);
		/// <summary>
		/// 처리중에 에러가 발생하면 발생함.
		/// </summary>
		public event ErrorDelegate OnError;
		/// <summary>
		/// 'IpAddresses'개체의 에러발생을 외부에 알림
		/// </summary>
		/// <param name="typeError"></param>
		private void OnOnError_Call(ErrorType typeError)
		{
			if (null != this.OnError)
			{
				this.OnError(typeError);
			}
		}

		#endregion

		public IPEndPoint StringToEndPoint(string sHostName, int nPort)
		{
			IPAddress[] addresses = new IPAddress[1];

			if (true == IPAddress.TryParse(sHostName, out addresses[0]))
			{//유효한 아이피이다.
			}
			else
			{//유효하지 않은 아이피이다.
			 //호스트 네임인지 확인한다.
				addresses = Dns.GetHostAddresses(sHostName);


				if (addresses.Length == 0)
				{//호스트네임에서 IP를 찾을 수 없다.
					this.OnOnError_Call(ErrorType.NotFindIP);
					addresses[0] = null;
				}
				else if (addresses.Length > 1)
				{//지정된 호스트에 IP가 여러개다.
					this.OnOnError_Call(ErrorType.MoreIP);
					addresses[0] = null;
				}
			}

			return new IPEndPoint(addresses[0], nPort);
		}
	}
}
