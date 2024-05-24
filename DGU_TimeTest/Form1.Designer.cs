namespace DGU_TimeTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            labTimeScheduler_DayNow = new Label();
            labTimeScheduler_ViewTime = new Label();
            labTimeScheduler_StandardTime = new Label();
            label7 = new Label();
            label8 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            labTimeStandard_DayNow = new Label();
            label4 = new Label();
            labTimeStandard_ViewTime = new Label();
            label6 = new Label();
            labTimeStandard_StandardTime = new Label();
            label11 = new Label();
            timeStandardTime = new DateTimePicker();
            label1 = new Label();
            btnStandardTimeApply = new Button();
            btnViewTimeApply = new Button();
            label2 = new Label();
            timeViewTime = new DateTimePicker();
            checkRealTime = new CheckBox();
            groupBox3 = new GroupBox();
            labTimeScheduler_DayNow_NextDate = new Label();
            labTimeScheduler_ViewTime_NextDate = new Label();
            labTimeScheduler_StandardTime_NextDate = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            groupBox4 = new GroupBox();
            labTimeStandard_DayNow_NextDate = new Label();
            label16 = new Label();
            labTimeStandard_ViewTime_NextDate = new Label();
            label18 = new Label();
            labTimeStandard_StandardTime_NextDate = new Label();
            label20 = new Label();
            groupBox5 = new GroupBox();
            lab30Min = new Label();
            lab1Min = new Label();
            label17 = new Label();
            label10 = new Label();
            lab30Sec = new Label();
            label5 = new Label();
            lab1Hour = new Label();
            lab10Sec = new Label();
            label15 = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labTimeScheduler_DayNow);
            groupBox1.Controls.Add(labTimeScheduler_ViewTime);
            groupBox1.Controls.Add(labTimeScheduler_StandardTime);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 111);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "DGU TimeScheduler";
            // 
            // labTimeScheduler_DayNow
            // 
            labTimeScheduler_DayNow.Location = new Point(106, 74);
            labTimeScheduler_DayNow.Name = "labTimeScheduler_DayNow";
            labTimeScheduler_DayNow.Size = new Size(76, 23);
            labTimeScheduler_DayNow.TabIndex = 4;
            labTimeScheduler_DayNow.Text = "1900-00-00";
            labTimeScheduler_DayNow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labTimeScheduler_ViewTime
            // 
            labTimeScheduler_ViewTime.Location = new Point(106, 42);
            labTimeScheduler_ViewTime.Name = "labTimeScheduler_ViewTime";
            labTimeScheduler_ViewTime.Size = new Size(76, 23);
            labTimeScheduler_ViewTime.TabIndex = 4;
            labTimeScheduler_ViewTime.Text = "00:00:00";
            labTimeScheduler_ViewTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labTimeScheduler_StandardTime
            // 
            labTimeScheduler_StandardTime.Location = new Point(106, 19);
            labTimeScheduler_StandardTime.Name = "labTimeScheduler_StandardTime";
            labTimeScheduler_StandardTime.Size = new Size(76, 23);
            labTimeScheduler_StandardTime.TabIndex = 4;
            labTimeScheduler_StandardTime.Text = "00:00:00";
            labTimeScheduler_StandardTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Location = new Point(6, 74);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 4;
            label7.Text = "Day Now : ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Location = new Point(6, 42);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 4;
            label8.Text = "View Time : ";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Standard Time : ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labTimeStandard_DayNow);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(labTimeStandard_ViewTime);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(labTimeStandard_StandardTime);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(15, 263);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 105);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "DGU TimeStandard";
            // 
            // labTimeStandard_DayNow
            // 
            labTimeStandard_DayNow.Location = new Point(106, 74);
            labTimeStandard_DayNow.Name = "labTimeStandard_DayNow";
            labTimeStandard_DayNow.Size = new Size(76, 23);
            labTimeStandard_DayNow.TabIndex = 4;
            labTimeStandard_DayNow.Text = "1900-00-00";
            labTimeStandard_DayNow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 4;
            label4.Text = "Standard Time : ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labTimeStandard_ViewTime
            // 
            labTimeStandard_ViewTime.Location = new Point(106, 42);
            labTimeStandard_ViewTime.Name = "labTimeStandard_ViewTime";
            labTimeStandard_ViewTime.Size = new Size(76, 23);
            labTimeStandard_ViewTime.TabIndex = 4;
            labTimeStandard_ViewTime.Text = "00:00:00";
            labTimeStandard_ViewTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Location = new Point(6, 42);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 4;
            label6.Text = "View Time : ";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labTimeStandard_StandardTime
            // 
            labTimeStandard_StandardTime.Location = new Point(106, 19);
            labTimeStandard_StandardTime.Name = "labTimeStandard_StandardTime";
            labTimeStandard_StandardTime.Size = new Size(76, 23);
            labTimeStandard_StandardTime.TabIndex = 4;
            labTimeStandard_StandardTime.Text = "00:00:00";
            labTimeStandard_StandardTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Location = new Point(6, 74);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 4;
            label11.Text = "Day Now : ";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeStandardTime
            // 
            timeStandardTime.Format = DateTimePickerFormat.Time;
            timeStandardTime.Location = new Point(118, 9);
            timeStandardTime.Name = "timeStandardTime";
            timeStandardTime.ShowUpDown = true;
            timeStandardTime.Size = new Size(76, 23);
            timeStandardTime.TabIndex = 2;
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 3;
            label1.Text = "Standard Time : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnStandardTimeApply
            // 
            btnStandardTimeApply.Location = new Point(200, 9);
            btnStandardTimeApply.Name = "btnStandardTimeApply";
            btnStandardTimeApply.Size = new Size(75, 23);
            btnStandardTimeApply.TabIndex = 4;
            btnStandardTimeApply.Text = "Apply";
            btnStandardTimeApply.UseVisualStyleBackColor = true;
            btnStandardTimeApply.Click += btnStandardTimeApply_Click;
            // 
            // btnViewTimeApply
            // 
            btnViewTimeApply.Location = new Point(203, 237);
            btnViewTimeApply.Name = "btnViewTimeApply";
            btnViewTimeApply.Size = new Size(75, 23);
            btnViewTimeApply.TabIndex = 7;
            btnViewTimeApply.Text = "Apply";
            btnViewTimeApply.UseVisualStyleBackColor = true;
            btnViewTimeApply.Click += btnViewTimeApply_Click;
            // 
            // label2
            // 
            label2.Location = new Point(15, 237);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            label2.Text = "View Time : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeViewTime
            // 
            timeViewTime.Format = DateTimePickerFormat.Time;
            timeViewTime.Location = new Point(121, 237);
            timeViewTime.Name = "timeViewTime";
            timeViewTime.ShowUpDown = true;
            timeViewTime.Size = new Size(76, 23);
            timeViewTime.TabIndex = 5;
            // 
            // checkRealTime
            // 
            checkRealTime.AutoSize = true;
            checkRealTime.Location = new Point(284, 237);
            checkRealTime.Name = "checkRealTime";
            checkRealTime.Size = new Size(78, 19);
            checkRealTime.TabIndex = 8;
            checkRealTime.Text = "Real Time";
            checkRealTime.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(labTimeScheduler_DayNow_NextDate);
            groupBox3.Controls.Add(labTimeScheduler_ViewTime_NextDate);
            groupBox3.Controls.Add(labTimeScheduler_StandardTime_NextDate);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Location = new Point(218, 38);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 111);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "DGU TimeScheduler - Next Date";
            // 
            // labTimeScheduler_DayNow_NextDate
            // 
            labTimeScheduler_DayNow_NextDate.Location = new Point(106, 74);
            labTimeScheduler_DayNow_NextDate.Name = "labTimeScheduler_DayNow_NextDate";
            labTimeScheduler_DayNow_NextDate.Size = new Size(76, 23);
            labTimeScheduler_DayNow_NextDate.TabIndex = 4;
            labTimeScheduler_DayNow_NextDate.Text = "1900-00-00";
            labTimeScheduler_DayNow_NextDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labTimeScheduler_ViewTime_NextDate
            // 
            labTimeScheduler_ViewTime_NextDate.Location = new Point(106, 42);
            labTimeScheduler_ViewTime_NextDate.Name = "labTimeScheduler_ViewTime_NextDate";
            labTimeScheduler_ViewTime_NextDate.Size = new Size(76, 23);
            labTimeScheduler_ViewTime_NextDate.TabIndex = 4;
            labTimeScheduler_ViewTime_NextDate.Text = "00:00:00";
            labTimeScheduler_ViewTime_NextDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labTimeScheduler_StandardTime_NextDate
            // 
            labTimeScheduler_StandardTime_NextDate.Location = new Point(106, 19);
            labTimeScheduler_StandardTime_NextDate.Name = "labTimeScheduler_StandardTime_NextDate";
            labTimeScheduler_StandardTime_NextDate.Size = new Size(76, 23);
            labTimeScheduler_StandardTime_NextDate.TabIndex = 4;
            labTimeScheduler_StandardTime_NextDate.Text = "00:00:00";
            labTimeScheduler_StandardTime_NextDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Location = new Point(6, 74);
            label12.Name = "label12";
            label12.Size = new Size(100, 23);
            label12.TabIndex = 4;
            label12.Text = "Day Now : ";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Location = new Point(6, 42);
            label13.Name = "label13";
            label13.Size = new Size(100, 23);
            label13.TabIndex = 4;
            label13.Text = "View Time : ";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Location = new Point(6, 19);
            label14.Name = "label14";
            label14.Size = new Size(100, 23);
            label14.TabIndex = 4;
            label14.Text = "Standard Time : ";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(labTimeStandard_DayNow_NextDate);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(labTimeStandard_ViewTime_NextDate);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(labTimeStandard_StandardTime_NextDate);
            groupBox4.Controls.Add(label20);
            groupBox4.Location = new Point(221, 263);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 105);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "DGU TimeStandard - Next Date";
            // 
            // labTimeStandard_DayNow_NextDate
            // 
            labTimeStandard_DayNow_NextDate.Location = new Point(106, 74);
            labTimeStandard_DayNow_NextDate.Name = "labTimeStandard_DayNow_NextDate";
            labTimeStandard_DayNow_NextDate.Size = new Size(76, 23);
            labTimeStandard_DayNow_NextDate.TabIndex = 4;
            labTimeStandard_DayNow_NextDate.Text = "1900-00-00";
            labTimeStandard_DayNow_NextDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.Location = new Point(6, 19);
            label16.Name = "label16";
            label16.Size = new Size(100, 23);
            label16.TabIndex = 4;
            label16.Text = "Standard Time : ";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labTimeStandard_ViewTime_NextDate
            // 
            labTimeStandard_ViewTime_NextDate.Location = new Point(106, 42);
            labTimeStandard_ViewTime_NextDate.Name = "labTimeStandard_ViewTime_NextDate";
            labTimeStandard_ViewTime_NextDate.Size = new Size(76, 23);
            labTimeStandard_ViewTime_NextDate.TabIndex = 4;
            labTimeStandard_ViewTime_NextDate.Text = "00:00:00";
            labTimeStandard_ViewTime_NextDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.Location = new Point(6, 42);
            label18.Name = "label18";
            label18.Size = new Size(100, 23);
            label18.TabIndex = 4;
            label18.Text = "View Time : ";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labTimeStandard_StandardTime_NextDate
            // 
            labTimeStandard_StandardTime_NextDate.Location = new Point(106, 19);
            labTimeStandard_StandardTime_NextDate.Name = "labTimeStandard_StandardTime_NextDate";
            labTimeStandard_StandardTime_NextDate.Size = new Size(76, 23);
            labTimeStandard_StandardTime_NextDate.TabIndex = 4;
            labTimeStandard_StandardTime_NextDate.Text = "00:00:00";
            labTimeStandard_StandardTime_NextDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            label20.Location = new Point(6, 74);
            label20.Name = "label20";
            label20.Size = new Size(100, 23);
            label20.TabIndex = 4;
            label20.Text = "Day Now : ";
            label20.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lab30Min);
            groupBox5.Controls.Add(lab1Min);
            groupBox5.Controls.Add(label17);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(lab30Sec);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(lab1Hour);
            groupBox5.Controls.Add(lab10Sec);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(label9);
            groupBox5.Location = new Point(12, 155);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(406, 73);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "DGU TimeScheduler Event";
            // 
            // lab30Min
            // 
            lab30Min.Location = new Point(204, 42);
            lab30Min.Name = "lab30Min";
            lab30Min.Size = new Size(70, 23);
            lab30Min.TabIndex = 5;
            lab30Min.Text = "0";
            lab30Min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab1Min
            // 
            lab1Min.Location = new Point(204, 19);
            lab1Min.Name = "lab1Min";
            lab1Min.Size = new Size(70, 23);
            lab1Min.TabIndex = 5;
            lab1Min.Text = "0";
            lab1Min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.Location = new Point(148, 42);
            label17.Name = "label17";
            label17.Size = new Size(60, 23);
            label17.TabIndex = 6;
            label17.Text = "30 min : ";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Location = new Point(148, 19);
            label10.Name = "label10";
            label10.Size = new Size(60, 23);
            label10.TabIndex = 6;
            label10.Text = "1 min : ";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lab30Sec
            // 
            lab30Sec.Location = new Point(72, 42);
            lab30Sec.Name = "lab30Sec";
            lab30Sec.Size = new Size(70, 23);
            lab30Sec.TabIndex = 5;
            lab30Sec.Text = "0";
            lab30Sec.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(6, 42);
            label5.Name = "label5";
            label5.Size = new Size(60, 23);
            label5.TabIndex = 6;
            label5.Text = "30 sec : ";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lab1Hour
            // 
            lab1Hour.Location = new Point(330, 19);
            lab1Hour.Name = "lab1Hour";
            lab1Hour.Size = new Size(70, 23);
            lab1Hour.TabIndex = 5;
            lab1Hour.Text = "0";
            lab1Hour.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab10Sec
            // 
            lab10Sec.Location = new Point(72, 19);
            lab10Sec.Name = "lab10Sec";
            lab10Sec.Size = new Size(70, 23);
            lab10Sec.TabIndex = 5;
            lab10Sec.Text = "0";
            lab10Sec.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.Location = new Point(272, 19);
            label15.Name = "label15";
            label15.Size = new Size(60, 23);
            label15.TabIndex = 6;
            label15.Text = "1 hour : ";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(60, 23);
            label9.TabIndex = 6;
            label9.Text = "10 sec : ";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 377);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(checkRealTime);
            Controls.Add(btnViewTimeApply);
            Controls.Add(label2);
            Controls.Add(timeViewTime);
            Controls.Add(btnStandardTimeApply);
            Controls.Add(label1);
            Controls.Add(timeStandardTime);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DateTimePicker timeStandardTime;
        private Label label1;
        private Button btnStandardTimeApply;
        private Button btnViewTimeApply;
        private Label label2;
        private DateTimePicker timeViewTime;
        private Label labTimeScheduler_StandardTime;
        private Label label3;
        private Label labTimeScheduler_DayNow;
        private Label labTimeScheduler_ViewTime;
        private Label label7;
        private Label label8;
        private Label labTimeStandard_DayNow;
        private Label label4;
        private Label labTimeStandard_ViewTime;
        private Label label6;
        private Label labTimeStandard_StandardTime;
        private Label label11;
        private CheckBox checkRealTime;
        private GroupBox groupBox3;
        private Label labTimeScheduler_DayNow_NextDate;
        private Label labTimeScheduler_ViewTime_NextDate;
        private Label labTimeScheduler_StandardTime_NextDate;
        private Label label12;
        private Label label13;
        private Label label14;
        private GroupBox groupBox4;
        private Label labTimeStandard_DayNow_NextDate;
        private Label label16;
        private Label labTimeStandard_ViewTime_NextDate;
        private Label label18;
        private Label labTimeStandard_StandardTime_NextDate;
        private Label label20;
        private GroupBox groupBox5;
        private Label lab10Sec;
        private Label label9;
        private Label lab30Sec;
        private Label label5;
        private Label lab1Min;
        private Label label10;
        private Label lab1Hour;
        private Label label15;
        private Label lab30Min;
        private Label label17;
    }
}