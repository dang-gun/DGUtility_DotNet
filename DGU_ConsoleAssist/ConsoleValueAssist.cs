using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGU_ConsoleAssist;

/// <summary>
/// 입력값을 기다리는 인터페이스를 표시하고 받은 입력값을 전달해주는 기능
/// </summary>
public class ConsoleValueAssist
{
    /// <summary>
    /// 화면에 표시할 메시지
    /// </summary>
    public string InputValueMessage { get; set; } = string.Empty;

    /// <summary>
    /// 메뉴가 표시되고 나서 표될 질문 메시지
    /// </summary>
    public string? QuestionMessage { get; set; } = string.Empty;

    /// <summary>
    /// 메뉴가 선택됐을 때 동작
    /// <para>string : 입력된 데이터 </para>
    /// <para>return bool : 메시지를 다시 표시하고 입력을 다시 받을지 여부(false면 나감) </para>
    /// </summary>
    public Func<string, bool> Action { get; set; } = (sReadString) => { return false; };

    public ConsoleValueAssist() { }

    public ConsoleValueAssist(
        string sInputValueMessage
        , Func<string, bool>? action) 
    { 
        this.InputValueMessage = sInputValueMessage;
        if (action != null )
        {
            this.Action = action;
        }
    }

    public void InputValueWait()
    {
        //입력된 값
        string? sReadString = string.Empty;

        //입력을 다시 받을지 여부
        bool bInputAgain = false;

        do
        {
            //설정된 메시지 출력
            Console.WriteLine(this.InputValueMessage);

            if(string.Empty != this.QuestionMessage)
            {
                Console.Write(this.QuestionMessage);
            }
            

            //입력된 명령어 읽기
            sReadString = Console.ReadLine();

            if (null != sReadString)
            {
                //메뉴를 유지시킬지 여부가 리턴된다.
                bInputAgain = this.Action(sReadString);
            }


        } while (true == bInputAgain);
    }
}
