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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private Point mousePoint;
        int TIME = 16;
        private void Form3_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            timer1.Interval = 1000;
            timer1.Start();
        } 
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TIME == 0)
                TIME = 15;
            else
                TIME -= 1;
            label4.Text = "주가 변동 까지 남은 시간: " + TIME.ToString() + "초"; //주가 변동 까지 남은 시간 갱신
        }
    }
}
