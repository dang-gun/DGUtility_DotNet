using DGUtility.TimeScheduler;
using DGUtility.TimeStandard;

namespace DGU_TimeTest;

public partial class Form1 : Form
{
    private TimeScheduler TS;
    private TimeScheduler TS_ND;

    private TimeStandard TStd;
    private TimeStandard TStd_ND;

    public Form1()
    {
        InitializeComponent();

        //UI�� �ð� �޾ƿ���
        DateTime dtSelect = timeStandardTime.Value;

        this.TS = new TimeScheduler(dtSelect.TimeOfDay);
        this.TS.On1Second += TS_On1Second;
        this.TS.Start();
        
        
        this.TS_ND = new TimeScheduler(dtSelect.TimeOfDay, true);
        this.TS_ND.On1Second += TS_ND_On1Second;
        this.TS_ND.Start();




        this.TStd = new TimeStandard(dtSelect.TimeOfDay);
        this.TStd_ND = new TimeStandard(dtSelect.TimeOfDay, true);
    }

    

    private void TS_On1Second()
    {
        this.CrossThread_Winfom(() => {
            this.labTimeScheduler_StandardTime.Text
                = this.TS.LoopTickCountResetTime.ToString(@"hh\:mm\:ss");

            this.labTimeScheduler_ViewTime.Text
                = DateTime.Now.ToString(@"HH\:mm\:ss");

            this.labTimeScheduler_DayNow.Text
                = this.TS.TodayStandard.ToString(@"yyyy-MM-dd");
        });
    }

    private void TS_ND_On1Second()
    {
        this.CrossThread_Winfom(() => {
            this.labTimeScheduler_StandardTime_NextDate.Text
                = this.TS_ND.LoopTickCountResetTime.ToString(@"hh\:mm\:ss");

            this.labTimeScheduler_ViewTime_NextDate.Text
                = DateTime.Now.ToString(@"HH\:mm\:ss");

            this.labTimeScheduler_DayNow_NextDate.Text
                = this.TS_ND.TodayStandard.ToString(@"yyyy-MM-dd");
        });
    }

    private void btnStandardTimeApply_Click(object sender, EventArgs e)
    {
        //UI�� �ð� �޾ƿ���
        DateTime dtSelect = timeStandardTime.Value; 

        this.TS.Reset(dtSelect.TimeOfDay);
        this.TS_ND.Reset(dtSelect.TimeOfDay, true);

        this.TStd.Reset(dtSelect.TimeOfDay);
        this.TStd_ND.Reset(dtSelect.TimeOfDay, true);
    }

    private void btnViewTimeApply_Click(object sender, EventArgs e)
    {
        this.DisplayData(timeViewTime.Value);
    }


    /// <summary>
    /// ������ �ִ� ������ ȭ�鿡 ǥ���Ѵ�.
    /// </summary>
    private void DisplayData(DateTime dtNow)
    {
        this.CrossThread_Winfom(() => {
            this.labTimeScheduler_StandardTime.Text
                = this.TS.LoopTickCountResetTime.ToString(@"hh\:mm\:ss");


            this.labTimeScheduler_StandardTime_NextDate.Text
                = this.TS_ND.LoopTickCountResetTime.ToString(@"hh\:mm\:ss");




            this.labTimeStandard_StandardTime.Text
                = this.TStd.LoopTickCountResetTime.ToString(@"hh\:mm\:ss");
            this.labTimeStandard_ViewTime.Text
                = dtNow.ToString(@"HH\:mm\:ss");
            this.labTimeStandard_DayNow.Text
                = this.TStd.DateToStandard(dtNow).ToString(@"yyyy-MM-dd");


            this.labTimeStandard_StandardTime_NextDate.Text
                = this.TStd_ND.LoopTickCountResetTime.ToString(@"hh\:mm\:ss");
            this.labTimeStandard_ViewTime_NextDate.Text
                = dtNow.ToString(@"HH\:mm\:ss");
            this.labTimeStandard_DayNow_NextDate.Text
                = this.TStd_ND.DateToStandard(dtNow).ToString(@"yyyy-MM-dd");
        });
    }

    /// <summary>
    /// ũ�ν� ������ üũ�� �ϰ� ��Ȳ�� �°� ó���Ѵ�.
    /// </summary>
    /// <param name="action"></param>
    private void CrossThread_Winfom(Action action)
    {
        if (true == this.InvokeRequired)
        {//�ٸ� �������.
            this.Invoke(new Action(
                delegate ()
                {
                    action();
                }));
        }
        else
        {//���� �������.
            action();
        }
    }
}