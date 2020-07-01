using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Snake_1._0{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {     
            Application.EnableVisualStyles();  
            Application.SetCompatibleTextRenderingDefault(false);  
            //Application.Run(new Login());  
            Form2 login = new Form2();  
  
            //界面转换  
            login.ShowDialog();  
        
            if (login.DialogResult == DialogResult.OK)  
            {  
                login.Dispose();  
                Application.Run(new Form1());  
            }  
            else if (login.DialogResult == DialogResult.Cancel)  
            {  
                login.Dispose();  
                return;  
            }  
        }  
    }
    public static class user1
    {
        public static int i;
        public static int count = 1;
        public static string user = "111";
    }
}