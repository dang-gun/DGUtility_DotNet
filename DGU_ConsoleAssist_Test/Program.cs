using DGU_ConsoleAssist;

namespace DGU_ConsoleAssist_Test;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Dang Gun Utility!");
        Console.WriteLine("☆☆☆ Console Assist(DGU_ConsoleAssist) ☆☆☆");

        //메뉴 추가에 사용될 카운트
        int nAddCount = 100000;

        ConsoleMenuAssist newCA = new ConsoleMenuAssist();
        newCA.WelcomeMessage = $"Console Assist 테스트 메뉴를 선택해 주세요. {Environment.NewLine}"
                                + $"메뉴 번호나 대괄호([])안의 명령어를 입력하면 동작합니다.";
        
        newCA.MenuList.Add(new MenuModel());

        newCA.MenuList.Add(new MenuModel() 
        {
            Index = 1,
            TextFormat = "{0}. [{1}] 텍스트 출력",
            Action = (MenuModel menuThis) => 
            {
                Console.WriteLine($"'{menuThis.MatchString}({menuThis.Index})'를 선택 했습니다.");
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel()
        {
            Index = 2,
            MatchString = "Add",
            TextFormat = "{0}. [{1}] 메뉴 추가",
            Action = (MenuModel menuThis) =>
            {
                string sResult = MenuAdd(newCA.MenuList, ++nAddCount);
                Console.WriteLine($"'{sResult}'를 메뉴에 추가하였습니다.");
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel()
        {
            Index = 3,
            MatchString = "Remove",
            TextFormat = "{0}. [{1}] 메뉴 제거",
            Action = (MenuModel menuThis) =>
            {
                string sResult = MenuRemove(newCA.MenuList);
                Console.WriteLine($"'{sResult}'를 메뉴에서 제거하였습니다.");
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel());

        newCA.MenuEnd = new MenuModel() {
            MatchString = "Exit",
            TextFormat = "[{1}] 종료",
        };


        //
        newCA.QuestionMessage = "메뉴 번호나 명령을 입력해 주세요. : ";

        //메뉴 표시
        newCA.ShowKeyWait(false);



        //지정된 키가 눌릴때까지 대기
        ConsoleExitAssist newExit
            = new ConsoleExitAssist("------ '{0}'을 눌러 프로그램 종료 ------"
                                    , ConsoleKey.R);

        newExit.ExitWait();
    }

    /// <summary>
    /// 메뉴 추가
    /// </summary>
    /// <param name="MenuList"></param>
    /// <param name="nAddIndex"></param>
    /// <returns>추가된 메뉴 텍스트</returns>
    private static string MenuAdd(List<MenuModel> MenuList, int nAddIndex)
    {
        string sReturn = $"Add{nAddIndex}({nAddIndex})";

        Console.WriteLine($"'{sReturn}'가 추가되었습니다.");

        MenuList.Add(
            new MenuModel() 
            { 
                Index = nAddIndex,
                MatchString = $"Add{nAddIndex}",
                TextFormat = "{0}. [{1}] 추가된 메뉴",
                Action = (MenuModel menuThis) =>
                {
                    Console.WriteLine($"추가된 '{sReturn}'입니다.");
                    return true;
                }
            });

        return sReturn;
    }

    /// <summary>
    /// 맨 마지막 메뉴를 제거한다.
    /// </summary>
    /// <param name="MenuList"></param>
    /// <returns>제거된 메뉴 이름</returns>
    private static string MenuRemove(List<MenuModel> MenuList)
    {
        //맨 마지막 개체 추출
        MenuModel menuLast = MenuList.Last();

        //추출된 개체 이름 백업
        string sReturn = $"Remove {menuLast.MatchString}({menuLast.Index})";

        //맨 마지막 개체 제거
        MenuList.RemoveAt(MenuList.Count - 1);

        return sReturn;
    }
}
