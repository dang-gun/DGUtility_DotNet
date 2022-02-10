namespace DGU_EnumToClass_Test
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
			this.btnTest1 = new System.Windows.Forms.Button();
			this.btnTest2 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.btnTest3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnTest1
			// 
			this.btnTest1.Location = new System.Drawing.Point(12, 12);
			this.btnTest1.Name = "btnTest1";
			this.btnTest1.Size = new System.Drawing.Size(75, 23);
			this.btnTest1.TabIndex = 0;
			this.btnTest1.Text = "Test1";
			this.btnTest1.UseVisualStyleBackColor = true;
			this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
			// 
			// btnTest2
			// 
			this.btnTest2.Location = new System.Drawing.Point(93, 12);
			this.btnTest2.Name = "btnTest2";
			this.btnTest2.Size = new System.Drawing.Size(75, 23);
			this.btnTest2.TabIndex = 1;
			this.btnTest2.Text = "Test2";
			this.btnTest2.UseVisualStyleBackColor = true;
			this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
			// 
			// listView1
			// 
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(12, 41);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(306, 285);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// btnTest3
			// 
			this.btnTest3.Location = new System.Drawing.Point(174, 12);
			this.btnTest3.Name = "btnTest3";
			this.btnTest3.Size = new System.Drawing.Size(75, 23);
			this.btnTest3.TabIndex = 3;
			this.btnTest3.Text = "Test3";
			this.btnTest3.UseVisualStyleBackColor = true;
			this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(327, 340);
			this.Controls.Add(this.btnTest3);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.btnTest2);
			this.Controls.Add(this.btnTest1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnTest1;
		private System.Windows.Forms.Button btnTest2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnTest3;
	}
}
