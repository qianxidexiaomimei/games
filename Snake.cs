using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using Snake_1._0.Interface;

namespace Snake_1._0
{
    public class Snake : IShow
    {
        ArrayList blockList;
        private int headNumber;                                       //蛇头序数
        private Point headPoint;                                      //蛇头位置
        private int direction = 1;                                    //0,1,2,3分别代表上、右、下、左

        //public Snake()                                                //构造函数
        //{

        //}


        public Point getHeadPoint                                    //获取蛇头位置
        {
            get { return headPoint; }
        }



        public bool getHitSelf                                       //判断蛇是否碰到自身
        {
            get
            {
                IEnumerator myEnumerator = blockList.GetEnumerator();//定义并实例化枚举接口
                try
                {
                    while (myEnumerator.MoveNext())                  //通过循环遍历蛇的各块
                    {
                        Block b = (Block)myEnumerator.Current;       //读取当前块
                        if (!b.Ishead && b.Origin.Equals(headPoint)) //当前块不是蛇头且与蛇头位置相同
                        {
                            return true;                             //返回true
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }
                return false;                                        //返回false
            }
        }


    }
}
