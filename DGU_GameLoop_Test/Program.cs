using DGU_ConsoleAssist;

using GameLoopProc;

namespace DGU_GameLoop_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Dang Gun Utility!");
            Console.WriteLine("☆☆☆ GameLoop Test(DGU_GameLoop) ☆☆☆");

            //입력된 FPS
            int nFps = 0;

            (new ConsoleValueAssist()
            {
                InputValueMessage = "Please enter the frames per second(FPS)",
                QuestionMessage = "Enter value : ",
                Action = (sReadString) =>
                {
                    
                    //입력값을 숫자로 변경
                    int.TryParse(sReadString, out nFps);

                    if(0 >= nFps)
                    {
                        Console.WriteLine("Please enter a number greater than 0.");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }).InputValueWait();

            Console.WriteLine($"Select FPS : {nFps}");
            Console.WriteLine($" ");


            //FPS 기록용 카운터
            int FpsCount = 0;

            //FPS 표시용 타이머
            System.Timers.Timer timerFps = new System.Timers.Timer();
            timerFps.Interval = 1000;
            timerFps.Elapsed += (sender, e) => 
            {
                Console.WriteLine(String.Format("FPS : {0}", FpsCount));
                FpsCount = 0;
            };
            timerFps.Start();


            GameLoopStopwatch GameLoop = new GameLoopStopwatch(nFps);
            GameLoop.OnUpdate += () => { ++FpsCount; };
            GameLoop.Start().Wait();


        }

    }
}
