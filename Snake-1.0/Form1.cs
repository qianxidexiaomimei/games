using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake_1._0
{
    public partial class Form1 : Form
    {
        private Map map;                                              //地图对象
        private int grade;                                            //游戏级别
        private bool ren_speed = false;                               //玩家设置速度  
        public Form1()
        {
            InitializeComponent();
            this.map = new Map(new Point(50,50));                   //地图左上角坐标为（50，50）
            this.BackColor = Color.AliceBlue; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置控件样式为双缓冲，减少闪烁的问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.BackgroundImage = bmp;
            Graphics g = Graphics.FromImage(bmp);
            map.Display(g);                                         //地图显示
            label2.Text = "分数:" + map.score.ToString();           //显示
            grade = map.score / 50 + 1;                             //计算级别
            label1.Text = "等级:" + grade.ToString();               //显示级别
            int newspeed = 200 - grade * 50;                        //重新计算设置速度
            if (ren_speed == true)
            {
                timer1.Interval = newspeed;                         
            }
            if (map.score >= 400)                                   //如果分数为400
            {
                timer1.Enabled = false;                             //结束游戏
                MessageBox.Show("恭喜你通关了");                    
            }
            if (map.CheckSnake())                                   //判断蛇是否死亡
            {
                timer1.Enabled = false;                             //结束游戏
                MessageBox.Show("蛇已死亡，游戏结束 !!!");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int k, d = 0;
            k = e.KeyValue;
            if (k == 37)              //左
                d = 3;
            else if (k == 40)         //下
                d = 2;
            else if (k == 38)         //上
                d = 0;
            else if (k == 39)         //右
                d = 1;
            map.S.TurnDirection(d);
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("上下右左键为控制蛇的方向键");
            timer1.Enabled = true;
        }

        private void 加速ToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            timer1.Interval = 200;     
        }

        private void 减速ToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            timer1.Interval = 650;    
        }

        private void 正常ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }

        private void 更换账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 m = new Form2();
            m.ShowDialog();
        }

    }
}
