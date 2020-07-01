using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Snake_1._0.Interface;

namespace Snake_1._0
{
    public class Map : IShow
    { 
        private static int unit = 15;                            //定义静态单位长度
        private int length = 30 * unit;                          //地图长度
        private int width = 25 * unit;                  
        private Point dot;                                       //地图左上角位置
        public int score;                                        //游戏分数
        private Snake s;                                         //蛇对象
        private Food food1;                                      //食物对象

       

        public Snake S                                           
        {
            get { return s; }
        }

        public void Display(Graphics g)                           //显示地图方法，参数为图形对象
        {
            Pen p = new Pen(Color.Black);                         //创建黑色的笔
            g.DrawRectangle(p, dot.X, dot.Y, length, width);      //画长、宽分别为length和width的矩形
            s.Display(g);
            food1.Display(g);                                   
            if (CheckFood(g))                                     //检查食物是否被吃，若被吃
            {
                score = score + 10;                               //分数加
                this.displaynewfood(g);                           //显示新食物
                s.Growth();                                       //蛇自动增长
                s.Display(g);                                     //显示蛇
            }
            else
            {
                s.Go(g);                                          //蛇前行
                s.Display(g);                                     //显示蛇
            }
        }

        public void UnDisplay(Graphics g)
        {
            throw new NotImplementedException();                 //啥都不做，调试异常
        }

        public void displaynewfood(Graphics g)                   //显示新食物方法
        {
            food1.UnDisplay(g);                                  //消除原来食物
            food1 = randomfood();                                //产生随机食物
            food1.Display(g);                                    //显示新食物
        }

        public void ReSetSnake(Graphics g)                       //重新设置蛇方法
        {
            s.UnDisplay(g);                                      //消除以前蛇
            s.Reset(dot, 10);                                    //重设置蛇
        }

        public bool CheckSnake()                               //检查蛇是否撞墙
        {
            if ((dot.X < s.getHeadPoint.X && s.getHeadPoint.X < (dot.X + length) - 15) &&
                (dot.Y < s.getHeadPoint.Y && s.getHeadPoint.Y < (dot.Y + width) - 15) && !s.getHitSelf)
            {
                return false;
            }
            else
            {
                return true;
            }
        }    
    }
}
