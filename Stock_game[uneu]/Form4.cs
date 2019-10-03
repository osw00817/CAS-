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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int 수량;
        int 주식가격;
        int 최대;
        string 매수OR매도;
        private void Form4_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //topmost true;
            폼시작(); //회사 이름 확인 및 정보 가져오기;
            checkBox2.Checked = true; //매수 모드;
            trackBar1.Maximum = (100 - 수량); //trackbar 매수 모드;
            timer1.Interval = 1000; //주가 변동을 대비한 타이머
            timer1.Start();
        }
        private Point mousePoint;
        private void button1_Click(object sender, EventArgs e)
        {
            갱신();
            if (checkBox1.Checked != true)
            {
                //매수 모드이면 매수;
                매수();
            }
            else
            {
                //매도 모드이면 매도
                매도();
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                //매수모드를 선택할시
                checkBox1.Checked = false; //매도모드 꺼짐
                trackBar1.Maximum = 100 - 수량;
                label6.Text = "매수할 주_수량: " + trackBar1.Value.ToString() + "주";
                button1.Text = "매수하기";
                매수OR매도 = "매수할 주_수량:";
                비용계산();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                trackBar1.Maximum = 수량;
                label6.Text = "매도할 주_수량: " + trackBar1.Value.ToString() + "주";
                button1.Text = "매도하기";
                매수OR매도 = "매도할 주_수량:";
                비용계산();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = 매수OR매도 + this.trackBar1.Value.ToString() + "주";
            비용계산();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            갱신();
        }



        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            최대 = 100 - 수량;
            checkBox2.Checked = true;
            for (int i = 0; i < 최대; i++)
            {
                if (Class1.재산.돈 < 주식가격 * i)
                {
                    if (i >= 최대)
                    {
                        trackBar1.Value = 최대;
                    }
                    else
                    {
                        trackBar1.Value = i - 1;
                    }
                    break;
                }
                else
                {
                    trackBar1.Value = 최대;
                }
            }
            비용계산();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            trackBar1.Value = 수량;
            비용계산();
        }
        void 매수()
        {
            switch (Class1.매도.회사이름)
            {
                case "ListViewItem: {현대}":
                    {
                        주식가격 = Class1.주식.현대;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.현대 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {삼성}":
                    {
                        주식가격 = Class1.주식.삼성;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.삼성 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {LG}":
                    {
                        주식가격 = Class1.주식.LG;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.LG += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: { 대우}":
                    {
                        주식가격 = Class1.주식.대우;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.대우 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {쌍용}":
                    {
                        주식가격 = Class1.주식.쌍용;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.쌍용 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {미도파}":
                    {
                        주식가격 = Class1.주식.미도파;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.미도파 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {금호}":
                    {
                        주식가격 = Class1.주식.금호;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.금호 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {한진}":
                    {
                        주식가격 = Class1.주식.한진;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.한진 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {섬양}":
                    {
                        주식가격 = Class1.주식.섬양;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.섬양 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {두산}":
                    {
                        주식가격 = Class1.주식.두산;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.두산 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {대림}":
                    {
                        주식가격 = Class1.주식.대림;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.대림 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case "ListViewItem: {뉴코아}":
                    {
                        주식가격 = Class1.주식.뉴코아;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.뉴코아 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                default:
                    {
                        주식가격 = Class1.주식.삼미;
                        if (Class1.재산.돈 >= 주식가격 * trackBar1.Value)
                        {
                            Class1.재산.돈 = Class1.재산.돈 - 주식가격 * trackBar1.Value;
                            Class1.재산.삼미 += trackBar1.Value;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("돈이 부족합니다.(중간에 주가가 변경되었을수도 있습니다.)", "CAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }

        void 매도()
        {
            switch (Class1.매도.회사이름)
            {
                case "ListViewItem: {현대}":
                    {
                        주식가격 = Class1.주식.현대;
                        Class1.재산.현대 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {삼성}":
                    {
                        주식가격 = Class1.주식.삼성;
                        Class1.재산.삼성 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {LG}":
                    {
                        주식가격 = Class1.주식.LG;
                        Class1.재산.LG -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: { 대우}":
                    {
                        주식가격 = Class1.주식.대우;
                        Class1.재산.대우 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {쌍용}":
                    {
                        주식가격 = Class1.주식.쌍용;
                        Class1.재산.쌍용 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {미도파}":
                    {
                        주식가격 = Class1.주식.미도파;
                        Class1.재산.미도파 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {금호}":
                    {
                        주식가격 = Class1.주식.금호;
                        Class1.재산.금호 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {한진}":
                    {
                        주식가격 = Class1.주식.한진;
                        Class1.재산.한진 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {섬양}":
                    {
                        주식가격 = Class1.주식.섬양;
                        Class1.재산.섬양 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {두산}":
                    {
                        주식가격 = Class1.주식.두산;
                        Class1.재산.두산 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {대림}":
                    {
                        주식가격 = Class1.주식.대림;
                        Class1.재산.대림 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                case "ListViewItem: {뉴코아}":
                    {
                        주식가격 = Class1.주식.뉴코아;
                        Class1.재산.뉴코아 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
                default:
                    {
                        주식가격 = Class1.주식.삼미;
                        Class1.재산.삼미 -= trackBar1.Value;
                        Class1.재산.돈 += 주식가격 * trackBar1.Value;
                        break;
                    }
            }
            this.Hide();
        }
        void 갱신()
        {
            switch (Class1.매도.회사이름)
            {
                case "ListViewItem: {현대}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.현대.ToString() + "달러";
                        label4.Text = "발행총액:" + (Class1.주식.현대 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.현대.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {삼성}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.삼성.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.삼성 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.삼성.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {LG}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.LG.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.LG * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.LG.ToString() + "주";
                        break;
                    }
                case "ListViewItem: { 대우}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.대우.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.대우 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.대우.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {쌍용}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.쌍용.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.쌍용 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.쌍용.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {미도파}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.미도파.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.미도파 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.미도파.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {금호}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.금호.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.금호 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.금호.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {한진}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.한진.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.한진 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.한진.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {섬양}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.섬양.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.섬양 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.섬양.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {두산}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.두산.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.두산 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.두산.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {대림}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.대림.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.대림 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.대림.ToString() + "주";
                        break;
                    }
                case "ListViewItem: {뉴코아}":
                    {
                        label3.Text = "발행총액:" + Class1.주식.뉴코아.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.뉴코아 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.뉴코아.ToString() + "주";
                        break;
                    }
                default:
                    {
                        label3.Text = "발행총액:" + Class1.주식.삼미.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.삼미 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.삼미.ToString() + "주";
                        break;
                    }
            }
        }
        void 비용계산()
        {
            label6.Text = 매수OR매도 + this.trackBar1.Value.ToString() + "주";
            if (checkBox1.Checked != true)
            {
                label7.Text = "비용:" + "-" + (this.trackBar1.Value * 주식가격).ToString() + "달러";
            }
            else
            {
                label7.Text = "비용:" + "+" + (this.trackBar1.Value * 주식가격).ToString() + "달러";
            }
        }
        void 폼시작()
        {
            switch (Class1.매도.회사이름)
            {
                case "ListViewItem: {현대}":
                    {
                        label2.Text = "현대";
                        label3.Text = "발행총액:" + Class1.주식.현대.ToString() + "달러";
                        label4.Text = "발행총액:" + (Class1.주식.현대 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.현대.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.현대;
                        주식가격 = Class1.주식.현대;
                        break;
                    }
                case "ListViewItem: {삼성}":
                    {
                        label2.Text = "삼성";
                        label3.Text = "발행총액:" + Class1.주식.삼성.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.삼성 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.삼성.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.삼성;
                        주식가격 = Class1.주식.삼성;
                        break;
                    }
                case "ListViewItem: {LG}":
                    {
                        label2.Text = "LG";
                        label3.Text = "발행총액:" + Class1.주식.LG.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.LG * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.LG.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.LG;
                        주식가격 = Class1.주식.LG;
                        break;
                    }
                case "ListViewItem: { 대우}":
                    {
                        label2.Text = "대우";
                        label3.Text = "발행총액:" + Class1.주식.대우.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.대우 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.대우.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.대우;
                        주식가격 = Class1.주식.대우;
                        break;
                    }
                case "ListViewItem: {쌍용}":
                    {
                        label2.Text = "쌍용";
                        label3.Text = "발행총액:" + Class1.주식.쌍용.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.쌍용 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.쌍용.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.쌍용;
                        주식가격 = Class1.주식.쌍용;
                        break;
                    }
                case "ListViewItem: {미도파}":
                    {
                        label2.Text = "미도파";
                        label3.Text = "발행총액:" + Class1.주식.미도파.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.미도파 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.미도파.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.미도파;
                        주식가격 = Class1.주식.미도파;
                        break;
                    }
                case "ListViewItem: {금호}":
                    {
                        label2.Text = "금호";
                        label3.Text = "발행총액:" + Class1.주식.금호.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.금호 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.금호.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.금호;
                        주식가격 = Class1.주식.금호;
                        break;
                    }
                case "ListViewItem: {한진}":
                    {
                        label2.Text = "한진";
                        label3.Text = "발행총액:" + Class1.주식.한진.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.한진 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.한진.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.한진;
                        주식가격 = Class1.주식.한진;
                        break;
                    }
                case "ListViewItem: {섬양}":
                    {
                        label2.Text = "섬양";
                        label3.Text = "발행총액:" + Class1.주식.섬양.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.섬양 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.섬양.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.섬양;
                        주식가격 = Class1.주식.섬양;
                        break;
                    }
                case "ListViewItem: {두산}":
                    {
                        label2.Text = "두산";
                        label3.Text = "발행총액:" + Class1.주식.두산.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.두산 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.두산.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.두산;
                        주식가격 = Class1.주식.두산;
                        break;
                    }
                case "ListViewItem: {대림}":
                    {
                        label2.Text = "대림";
                        label3.Text = "발행총액:" + Class1.주식.대림.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.대림 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.대림.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.대림;
                        주식가격 = Class1.주식.대림;
                        break;
                    }
                case "ListViewItem: {뉴코아}":
                    {
                        label2.Text = "뉴코아";
                        label3.Text = "발행총액:" + Class1.주식.뉴코아.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.뉴코아 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.뉴코아.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.뉴코아;
                        주식가격 = Class1.주식.뉴코아;
                        break;
                    }
                default:
                    {
                        label2.Text = "삼미";
                        label3.Text = "발행총액:" + Class1.주식.삼미.ToString() + "달러";
                        label4.Text = "총액:" + (Class1.주식.삼미 * 100).ToString() + "달러";
                        label5.Text = "보유_주:" + Class1.재산.삼미.ToString() + "주";
                        label6.Text = "매수할 주_수량: 0주";
                        label7.Text = "비용:0달러";
                        수량 = Class1.재산.삼미;
                        주식가격 = Class1.주식.삼미;
                        break;
                    }
            }
        }
    }
}
