namespace DGU_ConsoleAssist;

/// <summary>
/// 콘솔에 메뉴를 표시하고 선택 인터페이스를 표시 및 동작시키는 기능
/// </summary>
public class ConsoleMenuAssist
{
    /// <summary>
    /// 메뉴가 표시되기전 표시될 메시지
    /// </summary>
    public string? WelcomeMessage { get; set; } = string.Empty;

    /// <summary>
    /// 메뉴 리스트
    /// </summary>
    public List<MenuModel> MenuList { get; set; } = new List<MenuModel>();

    /// <summary>
    /// 메뉴 끝내기용 모델
    /// </summary>
    /// <remarks>
    /// Action은 무시되므로 넣을 필요가 없다.
    /// </remarks>
    public MenuModel? MenuEnd { get; set; }

    /// <summary>
    /// 메뉴가 표시되고 나서 표될 질문 메시지
    /// </summary>
    public string? QuestionMessage { get; set; } = string.Empty;

    

    /// <summary>
    /// 설정된 메뉴를 출력하고 키 입력을 대기한다.
    /// </summary>
    /// <param name="bOneMenu">메뉴를 한번만 표시할지 여부</param>
    public void ShowKeyWait(bool bOneMenu)
    {
        if(true == bOneMenu)
        {//메뉴를 한번만 출력한다.
            this.ShowMenu();
        }


        //입력된 값
        string? sReadString = string.Empty;

        //메뉴를 유지시킬지 여부
        bool bMenuMaintain = true;

        do
        {
            if (false == bOneMenu)
            {//메뉴를 계속 출력한다.
                this.ShowMenu();
            }

            //입력된 명령어 읽기
            sReadString = Console.ReadLine();

            if(null != sReadString)
            {
                //메뉴를 유지시킬지 여부가 리턴된다.
                bMenuMaintain = this.MatchMenu(sReadString);
            }

            
        } while (true == bMenuMaintain);
    }

    /// <summary>
    /// 메뉴를 표시한다.
    /// </summary>
    private void ShowMenu()
    {
        //한줄 띄기
        Console.WriteLine("");

        if(null != this.WelcomeMessage)
        {
            Console.WriteLine(this.WelcomeMessage);
        }
        
        for (int i = 0; i < this.MenuList.Count; ++i)
        {
            MenuModel item = this.MenuList[i];

            if(null == item.Index
                && null == item.MatchString)
            {//인덱스와 매치스트링이 null이다.

                //한줄 띄기
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine(
                    string.Format(item.TextFormat
                                    , item.Index
                                    , item.MatchString));
            }   
        }

        //끝내기 메뉴 표시
        if(null != this.MenuEnd)
        {
            if (null == this.MenuEnd.Index
                && null == this.MenuEnd.MatchString)
            {//인덱스와 매치스트링이 null이다.

            }
            else
            {
                Console.WriteLine(
                    string.Format(this.MenuEnd.TextFormat
                                    , this.MenuEnd.Index
                                    , this.MenuEnd.MatchString));
            }
        }


        if (null != this.QuestionMessage)
        {
            Console.Write(this.QuestionMessage);
        }
        
    }

    /// <summary>
    /// 읽어들인 문자열로 매칭되는 메뉴를 찾아 실행시킨다.
    /// </summary>
    /// <param name="sReadString"></param>
    /// <returns>메뉴를 유지 시킬지 여부</returns>
    private bool MatchMenu(string sReadString)
    {
        //소문자로 변환
        string sReadString_Lower = sReadString.ToLower();

        MenuModel? menuSelect = null;
        int nMatch = 0;

        if (null != this.MenuEnd)
        {//종료 명령이 있고

            if ((null != this.MenuEnd.MatchString
                    && this.MenuEnd.MatchString.ToLower() == sReadString_Lower)
                || (null != this.MenuEnd.Index
                    && true == int.TryParse(sReadString, out nMatch)
                    && this.MenuEnd.Index == nMatch))
            {//종료 명령 매칭되거나
                //지정된 숫자와 매칭됨

                menuSelect = this.MenuEnd;
                menuSelect.Action = (MenuModel menuThis) =>
                {
                    return false;
                };
            }
        }

        if (null == menuSelect)
        {//종료 명령어가 아니다.
            
            //리스트 검색
            menuSelect
                = this.MenuList
                        .Where(w => w.MatchString != null
                                && w.MatchString.ToLower() == sReadString_Lower)
                        .FirstOrDefault();

            if (null == menuSelect)
            {//검색결과가 없다.

                if (true == int.TryParse(sReadString, out nMatch))
                {//숫자로 변환 가능

                    //리스트 다시 검색
                    menuSelect
                        = this.MenuList
                                .Where(w => w.Index != null
                                        && w.Index == nMatch)
                                .FirstOrDefault();
                }
            }//end if(null == menuSelect)
        }


        bool bReturn = true;
        if (null != menuSelect)
        {//명령어가 있다.

            if(null != menuSelect.Action)
            {//액션이 있다.

                bReturn = menuSelect.Action(menuSelect);
            }
        }
        

        return bReturn;
    }


}
