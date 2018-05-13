using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace 自动截屏并上传
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bCreatedNew;
            Mutex m = new Mutex(false, "Product_Index_Cntvs", out bCreatedNew);
            if (bCreatedNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new 主界面());
            }
            else {

                MessageBox.Show("同时只能有一个程序在运行");
            }
        }
    }
}
