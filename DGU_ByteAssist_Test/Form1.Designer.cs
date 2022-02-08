namespace DGU_ByteAssist_Test
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
			this.txtByteArrayString = new System.Windows.Forms.TextBox();
			this.btnConverting = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.txtByteString1 = new System.Windows.Forms.TextBox();
			this.btnConverting_ByteString1 = new System.Windows.Forms.Button();
			this.btnConverting_ByteString2 = new System.Windows.Forms.Button();
			this.txtByteString2 = new System.Windows.Forms.TextBox();
			this.txtOutputFull = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtByteArrayString
			// 
			this.txtByteArrayString.Location = new System.Drawing.Point(142, 12);
			this.txtByteArrayString.Name = "txtByteArrayString";
			this.txtByteArrayString.Size = new System.Drawing.Size(101, 23);
			this.txtByteArrayString.TabIndex = 0;
			this.txtByteArrayString.Text = "00-01-06-AC";
			// 
			// btnConverting
			// 
			this.btnConverting.Location = new System.Drawing.Point(142, 41);
			this.btnConverting.Name = "btnConverting";
			this.btnConverting.Size = new System.Drawing.Size(101, 23);
			this.btnConverting.TabIndex = 1;
			this.btnConverting.Text = "변환";
			this.btnConverting.UseVisualStyleBackColor = true;
			this.btnConverting.Click += new System.EventHandler(this.btnConverting_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(12, 160);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(367, 23);
			this.txtOutput.TabIndex = 2;
			// 
			// txtByteString1
			// 
			this.txtByteString1.Location = new System.Drawing.Point(12, 12);
			this.txtByteString1.Name = "txtByteString1";
			this.txtByteString1.Size = new System.Drawing.Size(101, 23);
			this.txtByteString1.TabIndex = 3;
			this.txtByteString1.Text = "AC";
			// 
			// btnConverting_ByteString1
			// 
			this.btnConverting_ByteString1.Location = new System.Drawing.Point(12, 41);
			this.btnConverting_ByteString1.Name = "btnConverting_ByteString1";
			this.btnConverting_ByteString1.Size = new System.Drawing.Size(101, 23);
			this.btnConverting_ByteString1.TabIndex = 1;
			this.btnConverting_ByteString1.Text = "변환";
			this.btnConverting_ByteString1.UseVisualStyleBackColor = true;
			this.btnConverting_ByteString1.Click += new System.EventHandler(this.btnConverting_ByteString_Click);
			// 
			// btnConverting_ByteString2
			// 
			this.btnConverting_ByteString2.Location = new System.Drawing.Point(12, 113);
			this.btnConverting_ByteString2.Name = "btnConverting_ByteString2";
			this.btnConverting_ByteString2.Size = new System.Drawing.Size(101, 23);
			this.btnConverting_ByteString2.TabIndex = 1;
			this.btnConverting_ByteString2.Text = "변환";
			this.btnConverting_ByteString2.UseVisualStyleBackColor = true;
			this.btnConverting_ByteString2.Click += new System.EventHandler(this.btnConverting_ByteString2_Click);
			// 
			// txtByteString2
			// 
			this.txtByteString2.Location = new System.Drawing.Point(12, 84);
			this.txtByteString2.Name = "txtByteString2";
			this.txtByteString2.Size = new System.Drawing.Size(101, 23);
			this.txtByteString2.TabIndex = 3;
			this.txtByteString2.Text = "0x1206";
			// 
			// txtOutputFull
			// 
			this.txtOutputFull.Location = new System.Drawing.Point(12, 189);
			this.txtOutputFull.Name = "txtOutputFull";
			this.txtOutputFull.Size = new System.Drawing.Size(367, 23);
			this.txtOutputFull.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 450);
			this.Controls.Add(this.txtByteString2);
			this.Controls.Add(this.txtByteString1);
			this.Controls.Add(this.txtOutputFull);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.btnConverting_ByteString2);
			this.Controls.Add(this.btnConverting_ByteString1);
			this.Controls.Add(this.btnConverting);
			this.Controls.Add(this.txtByteArrayString);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtByteArrayString;
		private System.Windows.Forms.Button btnConverting;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.TextBox txtByteString1;
		private System.Windows.Forms.Button btnConverting_ByteString1;
		private System.Windows.Forms.Button btnConverting_ByteString2;
		private System.Windows.Forms.TextBox txtByteString2;
		private System.Windows.Forms.TextBox txtOutputFull;
	}
}
