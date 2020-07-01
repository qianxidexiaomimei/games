using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake_1._0.Interface
{
    public interface IShow
    {
        /// <summary>
        /// 显示方法
        /// </summary>
        /// <param name="g"></param>
        void Display(Graphics g);

        /// <summary>
        /// 消除方法
        /// </summary>
        /// <param name="g"></param>
        void UnDisplay(Graphics g);
    }
}
