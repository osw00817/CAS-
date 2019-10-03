using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.Layout;
using System.Windows.Forms.Design;
using System.Windows.Forms.ComponentModel;
using System.IO;
namespace Stock_game_uneu_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Random random = new Random(); //난수 생성기 생성
            InitializeComponent();
            Class1.부도.LG = "잘 운영됨";
            Class1.부도.현대 = "잘 운영됨";
            Class1.부도.금호 = "잘 운영됨";
            Class1.부도.뉴코아 = "잘 운영됨";
            Class1.부도.대림 = "잘 운영됨";
            Class1.부도.대우 = "잘 운영됨";
            Class1.부도.두산 = "잘 운영됨";
            Class1.부도.미도파 = "잘 운영됨";
            Class1.부도.삼미 = "잘 운영됨";
            Class1.부도.삼성 = "잘 운영됨";
            Class1.부도.섬양 = "잘 운영됨";
            Class1.부도.쌍용 = "잘 운영됨";
            Class1.부도.한진 = "잘 운영됨"; //부도 여부 초기화 
            Class1.주식.LG = random.Next(1, 30);
            Class1.주식.금호 = random.Next(10, 30);
            Class1.주식.뉴코아 = random.Next(1, 40);
            Class1.주식.대림 = random.Next(2, 30);
            Class1.주식.대우 = random.Next(10, 30);
            Class1.주식.두산 = random.Next(0, 20);
            Class1.주식.미도파 = random.Next(1, 10);
            Class1.주식.삼미 = random.Next(1, 20);
            Class1.주식.삼성 = random.Next(1, 10);
            Class1.주식.섬양 = random.Next(1, 40); 
            Class1.주식.쌍용 = random.Next(1, 20);
            Class1.주식.한진 = random.Next(1, 10);
            Class1.주식.현대 = random.Next(1, 20); //주가 랜덤 생성
            timer1.Interval = 15000; //주가 갱신 타이머 시간 정하기
            timer1.Start(); //주가 갱신 타이머 시작
        }
        private Point mousePoint;
        Random random = new Random(); //난수 생성기 생성
        int TIME = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddY(0); //그래프 x축에 0 더하기
            chart2.Series[0].Points.AddY(0);
            chart2.Series[1].Points.AddY(0);
            chart2.Series[2].Points.AddY(0);
            chart2.Series[3].Points.AddY(0);
            chart2.Series[4].Points.AddY(0);
            chart2.Series[5].Points.AddY(0);
            chart2.Series[6].Points.AddY(0);
            chart2.Series[7].Points.AddY(0);
            chart2.Series[8].Points.AddY(0);
            chart2.Series[9].Points.AddY(0);
            chart2.Series[10].Points.AddY(0);
            chart2.Series[11].Points.AddY(0);
            chart2.Series[12].Points.AddY(0);
            Class1.재산.돈 = 10; //돈 10$ 할당
            string path = @"save.codeart";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                FileStream fs = File.Open(path, FileMode.Open);
                using (BinaryReader wr = new BinaryReader(fs))
                {
                    Class1.재산.돈 = wr.ReadInt32();
                    Class1.재산.LG = wr.ReadInt32();
                    Class1.재산.금호 = wr.ReadInt32();
                    Class1.재산.뉴코아 = wr.ReadInt32();
                    Class1.재산.대림 = wr.ReadInt32();
                    Class1.재산.대우 = wr.ReadInt32();
                    Class1.재산.두산 = wr.ReadInt32();
                    Class1.재산.미도파 = wr.ReadInt32();
                    Class1.재산.삼미 = wr.ReadInt32();
                    Class1.재산.삼성 = wr.ReadInt32();
                    Class1.재산.섬양 = wr.ReadInt32();
                    Class1.재산.쌍용 = wr.ReadInt32();
                    Class1.재산.한진 = wr.ReadInt32();
                    Class1.재산.현대 = wr.ReadInt32();
                    Class1.부도.LG = wr.ReadString();
                    Class1.부도.금호 = wr.ReadString();
                    Class1.부도.뉴코아 = wr.ReadString();
                    Class1.부도.대림 = wr.ReadString();
                    Class1.부도.대우 = wr.ReadString();
                    Class1.부도.두산 = wr.ReadString();
                    Class1.부도.미도파 = wr.ReadString();
                    Class1.부도.삼미 = wr.ReadString();
                    Class1.부도.삼성 = wr.ReadString();
                    Class1.부도.섬양 = wr.ReadString();
                    Class1.부도.쌍용 = wr.ReadString();
                    Class1.부도.한진 = wr.ReadString();
                    Class1.부도.현대 = wr.ReadString();
                }
            }
            Class1.주식.LG = 주가랜덤(Class1.주식.LG, random.Next(1, 10));
            Class1.주식.금호 = 주가랜덤(Class1.주식.금호, random.Next(1, 10));
            Class1.주식.뉴코아 = 주가랜덤(Class1.주식.뉴코아, random.Next(1, 10));
            Class1.주식.대림 = 주가랜덤(Class1.주식.대림, random.Next(1, 10));
            Class1.주식.대우 = 주가랜덤(Class1.주식.대우, random.Next(1, 10));
            Class1.주식.두산 = 주가랜덤(Class1.주식.두산, random.Next(1, 10));
            Class1.주식.미도파 = 주가랜덤(Class1.주식.미도파, random.Next(1, 10));
            Class1.주식.삼미 = 주가랜덤(Class1.주식.삼미, random.Next(1, 10));
            Class1.주식.삼성 = 주가랜덤(Class1.주식.삼성, random.Next(1, 10));
            Class1.주식.섬양 = 주가랜덤(Class1.주식.섬양, random.Next(1, 10));
            Class1.주식.쌍용 = 주가랜덤(Class1.주식.쌍용, random.Next(1, 10));
            Class1.주식.한진 = 주가랜덤(Class1.주식.한진, random.Next(1, 10));
            Class1.주식.현대 = 주가랜덤(Class1.주식.현대, random.Next(1, 10)); //확률에 따라 주가 정하기
            Class1.주식.전체_주가 = (Class1.주식.LG + Class1.주식.금호 + Class1.주식.뉴코아 + Class1.주식.대림 + Class1.주식.대우 + Class1.주식.두산 + Class1.주식.미도파 + Class1.주식.삼미 + Class1.주식.삼성 + Class1.주식.섬양 + Class1.주식.쌍용 + Class1.주식.한진 + Class1.주식.현대) / 13;
            chart1.Series[0].Points.AddY(Class1.주식.전체_주가); //주가 평균 구하기 및 그래프에 추가
            chart2.Series[0].Points.AddY(Class1.주식.LG);
            chart2.Series[1].Points.AddY(Class1.주식.금호);
            chart2.Series[2].Points.AddY(Class1.주식.뉴코아);
            chart2.Series[3].Points.AddY(Class1.주식.대림);
            chart2.Series[4].Points.AddY(Class1.주식.대우);
            chart2.Series[5].Points.AddY(Class1.주식.두산);
            chart2.Series[6].Points.AddY(Class1.주식.미도파);
            chart2.Series[7].Points.AddY(Class1.주식.삼미);
            chart2.Series[8].Points.AddY(Class1.주식.삼성);
            chart2.Series[9].Points.AddY(Class1.주식.섬양);
            chart2.Series[10].Points.AddY(Class1.주식.쌍용);
            chart2.Series[11].Points.AddY(Class1.주식.한진);
            chart2.Series[12].Points.AddY(Class1.주식.현대);
            Form2 form2 = new Form2();
            form2.Show();
            Form3 form3 = new Form3();
            form3.Show(); //여러 폼 시작
            this.TopMost = true; // topmost 설정
            label3.Text = "돈:" + Class1.재산.돈 + "$"; //돈 표시하기
            timer2.Interval = 1000; //돈 표시 타이머 시간 정하기
            timer2.Start(); //돈 표시 타이머 시작
         
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        public int 주가랜덤(int 대상,int i)
        {
            if (대상 >= 40)  //주가가 40이상이면
            {
                if(i > 4) // 60%의확률로 40이상의 주가를 획득;
                {
                    i = random.Next(대상, 대상 + 10);
                }
                else //40%의 확률로 20이상의 주가를 회득
                {
                    i = random.Next(대상-20, 대상);
                }
            }
            else if (대상 >= 30) //주가가 30이상이라면
            {
                if(i > 3) //70%의 확률로 30이상의 주가를 획득
                {
                    i = random.Next(대상, 대상 + 10);
                }
                else // 30%의 확률로 20이상의 주가를 획득
                {
                    i = random.Next(대상 - 10, 대상);
                }
            }
            else // 주가가 30미만이라면
            {
                if(대상 > 4)  //주가가 4$초과라면 
                {
                    if (i > 1) // 90%의 확률로 
                    {
                        i = random.Next(대상, 대상 + 10); //8달러 이상의 주가를 획득
                    }
                    else
                    {
                        i = random.Next(0 , 30); // 10%의 확률로 부도날 확률 0.3%
                    }
                }
                else // 4$달러 이하라면
                {
                    i = random.Next(0, 10);  //10%의 부도날 확률
                }
            }
            return i;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //주식 부도 확인 및 주식 갱신;
            if(Class1.주식.LG != 0)
            {
                Class1.주식.LG = 주가랜덤(Class1.주식.LG, random.Next(1, 10));
            }
            else
            {
                Class1.부도.LG = "부도";
                // listBox1.Items.Add("LG 부도.. 범정 관리를 신청했지만 거절 당해");
            }
            if (Class1.주식.금호 != 0)
            {
                Class1.주식.금호 = 주가랜덤(Class1.주식.금호, random.Next(1, 10));
            }
            else
            {
                Class1.부도.금호 = "부도";
                //listBox1.Items.Add("금호 부도.. 많은 어음 발행이 문제");
            }
            if (Class1.주식.뉴코아 != 0)
            {
                Class1.주식.뉴코아 = 주가랜덤(Class1.주식.뉴코아, random.Next(1, 10));
            }
            else
            {
                Class1.부도.뉴코아 = "부도";
               // listBox1.Items.Add("뉴코아 부도.. 계속 버텨오다 결국 부도 신청");
            }
            if (Class1.주식.대림 != 0)
            {
                Class1.주식.대림 = 주가랜덤(Class1.주식.대림, random.Next(1, 10));
            }
            else
            {
                Class1.부도.대림 = "부도";
                //listBox1.Items.Add("대림 부도.. 환의 신청 했지만 결국 부도");
            }
            if (Class1.주식.대우 != 0)
            {
                Class1.주식.대우 = 주가랜덤(Class1.주식.대우, random.Next(1, 10));
            }
            else
            {
                Class1.부도.대우 = "부도";
                //listBox1.Items.Add("대우 부도.. 계속 버텼지만 결국 부도");
            }
            if (Class1.주식.두산 != 0)
            {
                Class1.주식.두산 = 주가랜덤(Class1.주식.두산, random.Next(1, 10));
            }
            else
            {
                Class1.부도.두산 = "부도";
                //listBox1.Items.Add("두산 부도.. 역대 최고의 적자를 기록");
            }
            if (Class1.주식.미도파 != 0)
            {
                Class1.주식.미도파 = 주가랜덤(Class1.주식.미도파, random.Next(1, 10));
            }
            else
            {
                Class1.부도.미도파 = "부도";
            }
            if (Class1.주식.삼미 != 0)
            {
                Class1.주식.삼미 = 주가랜덤(Class1.주식.삼미, random.Next(1, 10));
            }
            else
            {
                Class1.부도.삼미 = "부도";
                //listBox1.Items.Add("삼미 부도.. 몇년 동안 적자 결국 부도");
            }
            if (Class1.주식.삼성 != 0)
            {
                Class1.주식.삼성 = 주가랜덤(Class1.주식.삼성, random.Next(1, 10));
            }
            else
            {
                Class1.부도.삼성 = "부도";
               // listBox1.Items.Add("삼성 부도.. 내일이나 모래 법정 관리 신청 할것으로 보여");
            }
            if (Class1.주식.섬양 != 0)
            {
                Class1.주식.섬양 = 주가랜덤(Class1.주식.섬양, random.Next(1, 10));
            }
            else
            {
                Class1.부도.섬양 = "부도";
              //  listBox1.Items.Add("섬양 부도..내일 화의 신청할 것으로 발표");
            }
            if (Class1.주식.쌍용 != 0)
            {
                Class1.주식.쌍용 = 주가랜덤(Class1.주식.쌍용, random.Next(1, 10));
            }
            else
            {
                Class1.부도.쌍용 = "부도";
           //     listBox1.Items.Add("쌍용 부도 인정");
            }
            if (Class1.주식.한진 != 0)
            {
                Class1.주식.한진 = 주가랜덤(Class1.주식.한진, random.Next(1, 10));
            }
            else
            {
                Class1.부도.한진 = "부도";
           //     listBox1.Items.Add("한진 계속 사원 감축 하다 결국 부도");
            }
            if (Class1.주식.현대 != 0)
            {
                Class1.주식.현대 = 주가랜덤(Class1.주식.현대, random.Next(1, 10));
            }
            else
            {
                Class1.부도.현대 = "부도";
             //   listBox1.Items.Add("현대가 오늘 오전 부도 발표");
            }
            Class1.주식.전체_주가 = (Class1.주식.LG + Class1.주식.금호 + Class1.주식.뉴코아 + Class1.주식.대림 + Class1.주식.대우 + Class1.주식.두산 + Class1.주식.미도파 + Class1.주식.삼미 + Class1.주식.삼성 + Class1.주식.섬양 + Class1.주식.쌍용 + Class1.주식.한진 + Class1.주식.현대) / 13;
            chart1.Series[0].Points.AddY(Class1.주식.전체_주가); //주가 평균 및 그래프에 추가
            chart2.Series[0].Points.AddY(Class1.주식.LG);
            chart2.Series[1].Points.AddY(Class1.주식.금호);
            chart2.Series[2].Points.AddY(Class1.주식.뉴코아);
            chart2.Series[3].Points.AddY(Class1.주식.대림);
            chart2.Series[4].Points.AddY(Class1.주식.대우);
            chart2.Series[5].Points.AddY(Class1.주식.두산);
            chart2.Series[6].Points.AddY(Class1.주식.미도파);
            chart2.Series[7].Points.AddY(Class1.주식.삼미);
            chart2.Series[8].Points.AddY(Class1.주식.삼성);
            chart2.Series[9].Points.AddY(Class1.주식.섬양);
            chart2.Series[10].Points.AddY(Class1.주식.쌍용);
            chart2.Series[11].Points.AddY(Class1.주식.한진);
            chart2.Series[12].Points.AddY(Class1.주식.현대);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = "돈:" + Class1.재산.돈 + "$"; //돈 갱신

            if(TIME == 0)
                TIME = 15;
           else
                TIME -= 1;
            label4.Text = "주가 변동 까지 남은 시간: " + TIME.ToString() + "초"; //주가 변동 까지 남은 시간 갱신
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"save.codeart";
            FileStream fs = File.Open(path, FileMode.Create);
            using (BinaryWriter wr = new BinaryWriter(fs))
            {
                wr.Write(Class1.재산.돈);
                wr.Write(Class1.재산.LG);
                wr.Write(Class1.재산.금호);
                wr.Write(Class1.재산.뉴코아);
                wr.Write(Class1.재산.대림);
                wr.Write(Class1.재산.대우);
                wr.Write(Class1.재산.두산);
                wr.Write(Class1.재산.미도파);
                wr.Write(Class1.재산.삼미);
                wr.Write(Class1.재산.삼성);
                wr.Write(Class1.재산.섬양);
                wr.Write(Class1.재산.쌍용);
                wr.Write(Class1.재산.한진);
                wr.Write(Class1.재산.현대);
                wr.Write(Class1.부도.LG);
                wr.Write(Class1.부도.금호);
                wr.Write(Class1.부도.뉴코아);
                wr.Write(Class1.부도.대림);
                wr.Write(Class1.부도.대우);
                wr.Write(Class1.부도.두산);
                wr.Write(Class1.부도.미도파);
                wr.Write(Class1.부도.삼미);
                wr.Write(Class1.부도.삼성);
                wr.Write(Class1.부도.섬양);
                wr.Write(Class1.부도.쌍용);
                wr.Write(Class1.부도.한진);
                wr.Write(Class1.부도.현대);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
