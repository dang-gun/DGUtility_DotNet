using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGU_Random
{
    /// <summary>
    /// 겹치지 않는 숫자 리스트 생성 유틸
    /// </summary>
    public class NonOverlapNumber
    {
        /// <summary>
        /// 지정된 
        /// </summary>
        /// <param name="nStart">숫자의 시작범위</param>
        /// <param name="nEnd">숫자의 끝범위</param>
        /// <param name="nCount">추출할 개수</param>
        /// <returns></returns>
        public int[] Renew(
            int nStart
            , int nEnd
            , int nCount)
        {
            //랜덤 개체
            Random rand = new Random();

            //추출된 숫자를 저장하는 배열
            int[] arrResult = new int[nCount];

            //추출할 원본 생성
            int[] listOri = Enumerable.Range(nStart, nEnd).ToArray();

            //추출한 인덱스
            int idxGetCount = 0;

            //추출할 범위
            int nRandRange = nEnd - nStart;

            for (int i = 0; i < nEnd; i++)
            {
                //숫자 추출
                idxGetCount = DGU_Random_Global.rand.Next(nRandRange);
                //추출한 숫자 저장
                arrResult[i] = listOri[idxGetCount];
                //추출한 자리에 마지막 숫자를 이동시키고
                //추출할 범위를 한칸 줄인다.
                listOri[idxGetCount] = listOri[--nRandRange];
            }

            return arrResult;
        }


    }
}
