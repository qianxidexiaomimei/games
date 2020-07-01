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

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;                                    //开始运行游戏
            if (this.开始ToolStripMenuItem.Text == "开始")            //如果标题为“开始”
            {
                this.开始ToolStripMenuItem.Text = "重新开始";         //改为“重新开始”
            }
            else
            {                                               
                map.ReSetSnake(this.CreateGraphics());                //重新开始游戏
                map.score = 0;
            }
            暂停ToolStripMenuItem.Enabled = true;                    //暂停/继续菜单可用
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (暂停ToolStripMenuItem.Text == "暂停")                //如果菜单原标题为“暂停”
            {
                this.timer1.Enabled = false;                         //停止游戏
                暂停ToolStripMenuItem.Text = "继续";                 //菜单标题改为“继续”
            }
            else
            {                                                       
                this.timer1.Enabled = true;                         //继续游戏
                暂停ToolStripMenuItem.Text = "暂停";                //菜单标题改为“暂停”
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
