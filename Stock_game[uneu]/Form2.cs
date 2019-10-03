using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_game_uneu_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Interval = 15000; //주가 갱신 타이머 시간 초기화 
            timer1.Start(); //주가 갱신 타이머 시작
        }
        private Point mousePoint;
        int TIME = 16;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        public void 갱신()
        {
            listView1.Items.Clear();
            string[] row = { "LG 그룹", Class1.주식.LG.ToString() + "달러", Class1.재산.LG.ToString(), (Class1.주식.LG * 100).ToString() + "달러", Class1.부도.LG };
            string[] row2 = { "금호", Class1.주식.금호.ToString() + "달러", Class1.재산.금호.ToString(), (Class1.주식.금호 * 100).ToString() + "달러", Class1.부도.금호 };
            string[] row3 = { "뉴코아", Class1.주식.뉴코아.ToString() + "달러", Class1.재산.뉴코아.ToString(), (Class1.주식.뉴코아 * 100).ToString() + "달러", Class1.부도.뉴코아 };
            string[] row4 = { "대림", Class1.주식.대림.ToString() + "달러", Class1.재산.대림.ToString(), (Class1.주식.대림 * 100).ToString() + "달러", Class1.부도.대림 };
            string[] row5 = { "대우", Class1.주식.대우.ToString() + "달러", Class1.재산.대우.ToString(), (Class1.주식.대우 * 100).ToString() + "달러", Class1.부도.대우 };
            string[] row6 = { "두산", Class1.주식.두산.ToString() + "달러", Class1.재산.두산.ToString(), (Class1.주식.두산 * 100).ToString() + "달러", Class1.부도.두산 };
            string[] row7 = { "미도파", Class1.주식.미도파.ToString() + "달러", Class1.재산.미도파.ToString(), (Class1.주식.미도파 * 100).ToString() + "달러", Class1.부도.미도파 };
            string[] row8 = { "삼미", Class1.주식.삼미.ToString() + "달러", Class1.재산.삼미.ToString(), (Class1.주식.삼미 * 100).ToString() + "달러", Class1.부도.삼미 };
            string[] row9 = { "삼성", Class1.주식.삼성.ToString() + "달러", Class1.재산.삼성.ToString(), (Class1.주식.삼성 * 100).ToString() + "달러", Class1.부도.삼성 };
            string[] row10 = { "섬양", Class1.주식.섬양.ToString() + "달러", Class1.재산.섬양.ToString(), (Class1.주식.섬양 * 100).ToString() + "달러", Class1.부도.섬양 };
            string[] row11 = { "쌍용", Class1.주식.쌍용.ToString() + "달러", Class1.재산.쌍용.ToString(), (Class1.주식.쌍용 * 100).ToString() + "달러", Class1.부도.쌍용 };
            string[] row12 = { "한진", Class1.주식.한진.ToString() + "달러", Class1.재산.한진.ToString(), (Class1.주식.한진 * 100).ToString() + "달러", Class1.부도.한진 };
            string[] row13 = { "현대", Class1.주식.현대.ToString() + "달러", Class1.재산.현대.ToString(), (Class1.주식.현대 * 100).ToString() + "달러", Class1.부도.현대 };
            var a = new ListViewItem(row);
            var a2 = new ListViewItem(row2);
            var a3 = new ListViewItem(row3);
            var a4 = new ListViewItem(row4);
            var a5 = new ListViewItem(row5);
            var a6 = new ListViewItem(row6);
            var a7 = new ListViewItem(row7);
            var a8 = new ListViewItem(row8);
            var a9 = new ListViewItem(row9);
            var a10 = new ListViewItem(row10);
            var a11 = new ListViewItem(row11);
            var a12 = new ListViewItem(row12);
            var a13 = new ListViewItem(row13);
            listView1.Items.Add(a);
            listView1.Items.Add(a2);
            listView1.Items.Add(a3);
            listView1.Items.Add(a4);
            listView1.Items.Add(a5);
            listView1.Items.Add(a6);
            listView1.Items.Add(a7);
            listView1.Items.Add(a8);
            listView1.Items.Add(a9);
            listView1.Items.Add(a10);
            listView1.Items.Add(a11);
            listView1.Items.Add(a12);
            listView1.Items.Add(a13); //모든 주식 정보를 LISTVIEW에 추가
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            갱신();
        }

            private void button1_Click(object sender, EventArgs e)
        {
            갱신();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer2.Interval = 1000; //타이머 시간 정하기
            timer2.Start(); //타이머 시작
            label3.Text = "돈:" + Class1.재산.돈 + "$"; //돈 표시
            this.TopMost = true; //topmost true;
            갱신();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Class1.매도.회사이름 = e.Item.ToString(); //회사이름 인식
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Class1.매도.회사이름 != "" || Class1.매도.회사이름 != null)
            {
                //선택한 회사가 있다면
                Form4 form4 = new Form4();
                form4.Show();
            }
            else
            {
                //선택한 회사가 없다면
                MessageBox.Show("매수 및 매도할 주식을 클릭해주세요.","CAS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = "돈:" + Class1.재산.돈 + "$"; //돈 표시
            if (TIME == 0)
                TIME = 15;
            else
                TIME -= 1;
            label4.Text = "주가 변동 까지 남은 시간: " + TIME.ToString() + "초"; //주가 변동 까지 남은 시간 갱신
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
