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
			Test1_a = 1,
			Test1_b = 2,
			Test1_c = 3,
			Test1_d = 4,
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

		/// <summary>
		/// 테스트용 열거형3(중복된 값 처리)
		/// </summary>
		enum Test3
		{
			Test1_a = 1,
			Test1_b = 1,
			Test1_c = 0,
			Test1_d = 0,
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
			EnumList1 newEnum = new EnumList1(typeData);

			SetListView(newEnum.EnumMember);
		}

		private void btnTest3_Click(object sender, EventArgs e)
		{
			//열거형 지정
			EnumList2<Test3> newEnum = new EnumList2<Test3>();

			SetListView(newEnum.EnumMember);
		}

		private void SetListView(EnumMemberModel[] arrEM)
		{
			//컨트롤을 지우고
			listView1.Clear();

			//리스트뷰 바인드 시작
			listView1.BeginUpdate();
			//뷰모드
			listView1.View = View.Details;

			//열거형으로 컬럼 생성
			for (int i = 0; i < arrEM.Length; ++i)
			{
				listView1.Columns.Add(arrEM[i].Name);
			}

			//아이템 추가
			string[] sData = new string[arrEM.Length];
			for (int i = 0; i < arrEM.Length; ++i)
			{
				sData[i] = arrEM[i].Index.ToString();
			}
			listView1.Items.Add(new ListViewItem(sData));

			//리스트뷰 바인드 완료
			listView1.EndUpdate();
		}
	}
}
