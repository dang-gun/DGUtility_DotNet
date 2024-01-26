
namespace DGU_ConsoleAssist;

/// <summary>
/// 콘솔 종료 지원
/// </summary>
public class ConsoleExitAssist
{
    /// <summary>
    /// 종료 대기 메시지 포멧
    /// </summary>
    /// <remarks>
    /// .NET String.Format 형식으로 넣는다.
    /// <para>{0}에 지정된 키가 표시된다.</para>
    /// </remarks>
    public string ExitWaitMessageFormat { get; set; } = string.Empty;

    /// <summary>
    /// 해당 키를 누르면 종료된다.
    /// <para>null이면 모든 키</para>
    /// </summary>
    public ConsoleKey? Key { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sExitWaitMessage"></param>
    /// <param name="keySelect"></param>
    public ConsoleExitAssist(
        string sExitWaitMessage
        , ConsoleKey? keySelect)
    {
        this.ExitWaitMessageFormat = sExitWaitMessage;
        this.Key = keySelect;
    }

    /// <summary>
    /// 키가 눌릴때까지 대기한다.
    /// <para>지정된 키가 눌리면 대기가 풀린다.</para>
    /// </summary>
    public void ExitWait()
    {
        string sExitMsg = string.Empty;

        if ( null == this.Key)
        {
            sExitMsg = this.ExitWaitMessageFormat;
        }
        else
        {
            sExitMsg = string.Format(this.ExitWaitMessageFormat, this.Key.Value);
        }

        Console.WriteLine(sExitMsg);


        //입력된 키
        ConsoleKeyInfo keyinfoThis;

        do
        {
            keyinfoThis = Console.ReadKey();

            //this.KeyInfo가 null이면 모든 키 이다.
            //this.KeyInfo가 null이 아니라면 지정된 키와 다른지 확인한다.
        } while (this.Key != null 
                && keyinfoThis.Key != this.Key);
    }
}
