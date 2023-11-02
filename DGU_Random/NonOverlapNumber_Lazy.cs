using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGU_Random
{
    /// <summary>
    /// 겹치지 않는 숫자 리스트 생성 유틸 - 지연된 생성
    /// </summary>
    /// <remarks>
    /// 리스트를 요청하면 바로 추출하는 것이 아니라 호출할때마다 생성해 준다.
    /// </remarks>
    public class NonOverlapNumber_Lazy
    {
        /// <summary>
        /// 추출할 원본
        /// </summary>
        /// <remarks>생성에 사용할 숫자 리스트</remarks>
        private List<int> OriginalList { get; set; }

        /// <summary>
        /// 기본 생성
        /// </summary>
        /// <param name="nStart"></param>
        /// <param name="nEnd"></param>
        public NonOverlapNumber_Lazy(
            int nStart
            , int nEnd) 
        {
            //추출할 원본 생성
            this.OriginalList.AddRange(Enumerable.Range(nStart, nEnd).ToArray());
        }

        public int Next()
        {
            //숫자 추출
            int idxGet = DGU_Random_Global.rand.Next(this.OriginalList.Count);
            //해당 자리의 숫자 추출
            int nResult = this.OriginalList[idxGet];

            //리스트에서 해당 자리 제거
            this.OriginalList.RemoveAt(idxGet);


            return nResult;
        }

    }
}
