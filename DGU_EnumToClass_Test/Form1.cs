using DGU.EnumToClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGU_EnumToClass_Test
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// 테스트용 열거형1
		/// </summary>
		enum Test1
		{
			Test1_a = 0,
			Test1_b = 0,
			Test1_c = 0,
		}

		/// <summary>
		/// 테스트용 열거형2
		/// </summary>
		enum Test2
		{
			Test2_a = 5,
			Test2_b,
			Test2_c,
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void btnTest1_Click(object sender, EventArgs e)
		{
			SetListView(new Test1());
		}

		private void btnTest2_Click(object sender, EventArgs e)
		{
			SetListView(new Test2());
		}

		private void SetListView(Enum typeData)
		{
			//열거형 지정
			EnumList newEnum = new EnumList(typeData);

			//컨트롤을 지우고
			listView1.Clear();


			//리스트뷰 바인드 시작
			listView1.BeginUpdate();
			//뷰모드
			listView1.View = View.Details;

			//열거형으로 컬럼 생성
			for (int i = 0; i < newEnum.Count; ++i)
			{
				listView1.Columns.Add(newEnum.EnumMember[i].Name);
			}

			//아이템 추가
			string[] sData = new string[newEnum.Count];
			for (int i = 0; i < newEnum.Count; ++i)
			{
				sData[i] = newEnum.EnumMember[i].Index.ToString();
			}
			listView1.Items.Add(new ListViewItem(sData));

			//리스트뷰 바인드 완료
			listView1.EndUpdate();
		}
	}
}
