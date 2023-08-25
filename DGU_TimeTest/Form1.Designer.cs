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
            groupBox2 = new GroupBox();
            timeStandardTime = new DateTimePicker();
            label1 = new Label();
            btnStandardTimeApply = new Button();
            btnViewTimeApply = new Button();
            label2 = new Label();
            timeViewTime = new DateTimePicker();
            label3 = new Label();
            labTimeScheduler_StandardTime = new Label();
            label7 = new Label();
            label8 = new Label();
            labTimeScheduler_ViewTime = new Label();
            labTimeScheduler_DayNow = new Label();
            label4 = new Label();
            label6 = new Label();
            label11 = new Label();
            labTimeStandard_StandardTime = new Label();
            labTimeStandard_ViewTime = new Label();
            labTimeStandard_DayNow = new Label();
            checkRealTime = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            groupBox1.Location = new Point(12, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(193, 111);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "DGU TimeScheduler";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labTimeStandard_DayNow);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(labTimeStandard_ViewTime);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(labTimeStandard_StandardTime);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(12, 221);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(193, 105);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "DGU TimeStandard";
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
            // 
            // btnViewTimeApply
            // 
            btnViewTimeApply.Location = new Point(200, 38);
            btnViewTimeApply.Name = "btnViewTimeApply";
            btnViewTimeApply.Size = new Size(75, 23);
            btnViewTimeApply.TabIndex = 7;
            btnViewTimeApply.Text = "Apply";
            btnViewTimeApply.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            label2.Text = "View Time : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeViewTime
            // 
            timeViewTime.Format = DateTimePickerFormat.Time;
            timeViewTime.Location = new Point(118, 38);
            timeViewTime.Name = "timeViewTime";
            timeViewTime.ShowUpDown = true;
            timeViewTime.Size = new Size(76, 23);
            timeViewTime.TabIndex = 5;
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
            // labTimeScheduler_ViewTime
            // 
            labTimeScheduler_ViewTime.Location = new Point(106, 42);
            labTimeScheduler_ViewTime.Name = "labTimeScheduler_ViewTime";
            labTimeScheduler_ViewTime.Size = new Size(76, 23);
            labTimeScheduler_ViewTime.TabIndex = 4;
            labTimeScheduler_ViewTime.Text = "00:00:00";
            labTimeScheduler_ViewTime.TextAlign = ContentAlignment.MiddleCenter;
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
            // label4
            // 
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 4;
            label4.Text = "Standard Time : ";
            label4.TextAlign = ContentAlignment.MiddleRight;
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
            // label11
            // 
            label11.Location = new Point(6, 74);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 4;
            label11.Text = "Day Now : ";
            label11.TextAlign = ContentAlignment.MiddleRight;
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
            // labTimeStandard_ViewTime
            // 
            labTimeStandard_ViewTime.Location = new Point(106, 42);
            labTimeStandard_ViewTime.Name = "labTimeStandard_ViewTime";
            labTimeStandard_ViewTime.Size = new Size(76, 23);
            labTimeStandard_ViewTime.TabIndex = 4;
            labTimeStandard_ViewTime.Text = "00:00:00";
            labTimeStandard_ViewTime.TextAlign = ContentAlignment.MiddleCenter;
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
            // checkRealTime
            // 
            checkRealTime.AutoSize = true;
            checkRealTime.Location = new Point(197, 67);
            checkRealTime.Name = "checkRealTime";
            checkRealTime.Size = new Size(78, 19);
            checkRealTime.TabIndex = 8;
            checkRealTime.Text = "Real Time";
            checkRealTime.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 354);
            Controls.Add(checkRealTime);
            Controls.Add(btnViewTimeApply);
            Controls.Add(label2);
            Controls.Add(timeViewTime);
            Controls.Add(btnStandardTimeApply);
            Controls.Add(label1);
            Controls.Add(timeStandardTime);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
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
    }
}