
using DGU_ModelToOutFiles.TestModels.TestCont;
using DGUtility.ModelToOutFiles.Global.Attributes;

namespace DGU_ModelToOutFiles.TestModels.ExceptionCont;


/// <summary>
/// 익명함수가 존제하는 경우 출력하지 않는다.
/// </summary>
public class AnonymousFunction
{
    /// <summary>
    /// 익명함수 사용
    /// </summary>
    public AnonymousFunction()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < 10; ++i)
        {
            list.Add(i);
        }

        long[] Items
            = list.Where(w => w > 5)
                    .Select(s => Convert.ToInt64(s))
                    .ToArray();
    }
}
