using DGU.DGU_ByteAssist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGU_ByteAssist_Test
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			ByteParse.ExceptionOn = true;
		}

		private void btnConverting_Click(object sender, EventArgs e)
		{
			byte[] byteOut = new byte[4];

			ByteParse.ByteArrayStringToByte(
				this.txtByteArrayString.Text
				, ref byteOut);

			txtOutput.Text
				= BitConverter.ToString(byteOut);

			this.OutIntUi(byteOut);
		}

		private void btnConverting_ByteString_Click(object sender, EventArgs e)
		{
			byte byteOut = new byte();

			ByteParse.ByteStringToByte(
				this.txtByteString1.Text
				, ref byteOut);

			byte[] byte2 = new byte[1];
			byte2[0] = byteOut;
			txtOutput.Text
				= BitConverter.ToString(byte2);

			this.OutIntUi(byte2);
		}

		private void btnConverting_ByteString2_Click(object sender, EventArgs e)
		{
			byte byteOut = new byte();

			ByteParse.ByteStringToByte(
				this.txtByteString2.Text
				, ref byteOut);

			byte[] byte2 = new byte[1];
			byte2[0] = byteOut;
			txtOutput.Text
				= BitConverter.ToString(byte2);

			this.OutIntUi(byte2);
		}

		private void OutIntUi(byte[] byteData)
		{
			StringBuilder sbOut = new StringBuilder();

			foreach (byte itemByte in byteData)
			{
				//byte[] aaa = ByteParse.ByteToByteArray(itemByte);
				sbOut.Append(((int)itemByte) + " ");
			}

			txtOutput.Text = sbOut.ToString();


			StringBuilder sbOut2 = new StringBuilder();

			byte[] byteData2 = ByteParse.ByteTo4ByteArray(byteData);
			if (4 > byteData.Length)
			{
				byteData2 = ByteParse.ByteTo4ByteArray(byteData);
			}
			else
			{
				byteData2 = byteData;
			}
			
			txtOutputFull.Text
				= BitConverter.ToInt32(byteData2, 0)
					.ToString();

		}
	}
}
