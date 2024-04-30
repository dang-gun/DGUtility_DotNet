using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameLoopProc
{
	/// <summary>
	/// 
	/// </summary>
	public class GameLoopStopwatch
	{
        #region 외부에 노출할 이벤트
        /// <summary>
        /// 비어있는 이벤트 대리자
        /// </summary>
        public delegate void EmptyDelegate();


        /// <summary>
        /// 루프중 업데이트때 한번 호출되는 이벤트
        /// </summary>
        public event EmptyDelegate? OnUpdate;
        /// <summary>
        /// 루프중 업데이트때 한번 호출되는 이벤트 호출
        /// </summary>
        private void OnUpdateCall()
        {

            if (null != this.OnUpdate)
            {
                this.OnUpdate();
            }
        }

        /// <summary>
        /// 루프가 정지되었을때 발생하는 이벤트
        /// </summary>
        public event EmptyDelegate? OnStopCompleted;
        /// <summary>
        /// 루프가 정지되었을때 발생하는 이벤트 호출
        /// </summary>
        private void OnStopCompletedCall()
        {

            if (null != this.OnStopCompleted)
            {
                this.OnStopCompleted();
            }
        }
        #endregion

        /// <summary>
        /// 루프가 진행중인지 여부
        /// </summary>
        public bool LoopIs { get; private set; }

		/// <summary>
		/// 초당 최대 프레임 수
		/// <para>1초에 몇번 update가 호출되는지 값이다.<br />
		/// 이 값은 최대치이고 컴퓨터의 상태에 따라 이값보다 낮게 동작 할수 있다.</para>
		/// </summary>
		public int FPS
		{
			get
			{
				return this.m_FPS;
			}

			set
			{
				this.m_FPS = value;
				//스톱워치는 정밀도가 높아 한 틱의 단위가 *10000 이다.
				this.FrameTick = (1000 * 10000) / this.m_FPS;
			}
		}
		/// <summary>
		/// 초당 최대 프레임 수(원본)
		/// </summary>
		private int m_FPS = 60;

		/// <summary>
		/// 한번 Update를 호출하는 데 필요한 최소 시간(ms)
		/// <para>루프가 최소 이 시간 안에는 발생하지 않는다.<br />
		/// 컴퓨터의 상황에 따라 </para>
		/// </summary>
		public int FrameTick { get; private set; } = 166666;
        //public int FrameTick { get; private set; } = 33;



        /// <summary>
        /// Stopwatch 기반 게임루프
        /// </summary>
        public GameLoopStopwatch(int nFps)
		{
			this.FPS = nFps;
		}

		/// <summary>
		/// 루프를 시작한다.
		/// </summary>
		public async Task Start()
		{
			this.LoopIs = true;

			long nLastTime = 0;

			Stopwatch sw = new Stopwatch();
			sw.Start();

			await Task.Run(() =>
			{
				while (true == this.LoopIs)
				{
					//현제 틱
					long nTicksNow = sw.ElapsedTicks;
					
					//마지막 틱 + 프레임 만큼 시간이 지났는지 확인
					if (nTicksNow > nLastTime + this.FrameTick)
					{

						Debug.WriteLine(string.Format("Now {0}, {1} "
										, nTicksNow
										, nTicksNow - (nLastTime + this.FrameTick)));

						nLastTime = nTicksNow;
						//업데이트 알림
						this.OnUpdateCall();
					}
				}

				sw.Stop();
				//종료를 알림
				this.OnStopCompletedCall();
			});
		}


		/// <summary>
		/// 루프를 정지시킨다.
		/// 이미 진행된 루프는 계속 진행이 되기 때문에 정지를 시켜도 Update가 올수 있다.<br />
		/// 정확한 종료 시점은 StopCompleted로 확인해야 한다.
		/// </summary>
		public void Stop()
		{
			this.LoopIs = false;
		}

	}
}
