using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MetroFramework.Forms;
using MetroFramework;
using 助攻小助手;
using System.IO;

namespace 自动截屏并上传
{
    public partial class Form1 : MetroForm
    {

        public string setID = "job_hunter";
        public string setPhone = "job_hunter";
        private System.Timers.Timer pTimer;
        private System.Timers.Timer pTimer2;
        private static int num = 0;
        private static HashSet<string> keys = new HashSet<string>();
        private 主界面 parentForm = null;
        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, UInt32 dwRop);

        public Form1(主界面 parent1)
        {
            parentForm = parent1;
            InitializeComponent();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();//如果你不想截取的图象中有此应用程序
            Thread.Sleep(1000);

            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);//获得当前屏幕的大小  

            Graphics g = this.CreateGraphics();

            //创建一个以当前屏幕为模板的图象   
            Image myimage = new Bitmap(rect.Width, rect.Height, g);

            //第二种得到全屏坐标的方法
            // Image myimage = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height,g);

            //创建以屏幕大小为标准的位图  
            Graphics gg = Graphics.FromImage(myimage);
            gg.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            myimage.Save(Application.StartupPath + @"\bob.jpg", ImageFormat.Jpeg);//以JPG文件格式来保存   
            this.Show();
        }

        private void 定时执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = Interaction.InputBox("输入客户端数目", "提示信息", null, -1, -1);
            string phone = Interaction.InputBox("请输入手机号（必填)", "提示信息", null, -1, -1);
            if (res == null || phone == null || res == "" || phone == "")
            {
                MetroMessageBox.Show(this, "信息不全，无法开始");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[1]+\d{10}"))
            {
                MetroMessageBox.Show(this, "手机号不合法，无法开始");
                return;
            }
            try
            {
                AppSettings.CLIENT_NUM = int.Parse(res);
                setPhone = phone;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "客户端数量为不能超过10或者小于1的数字");
                return;
            }
            if (AppSettings.CLIENT_NUM > 10 || AppSettings.CLIENT_NUM < 1)
            {
                MetroMessageBox.Show(this, "不能超过10或者小于1");
                return;
            }
            keys.Clear();
            //开始创建多少个队列
            List<String> jobclinets = new List<String>();
            for (int i = 0; i < AppSettings.CLIENT_NUM; i++)
            {
                string key = AppSettings.MD5Encrypt64(AppSettings.JOB_NAME + DateTime.Now.ToFileTime());
                RedisCacheHelper.AddItemToList("client_all_key", key);
                keys.Add(key);
                richTextBox1.Text += key + "手机号:" + phone + Environment.NewLine; ;
                jobclinets.Add("job://" + DES.EncryptDES(key + "#" + phone, AppSettings.DES_KEY));
            }
            richTextBox1.Text += "下面的job://可以更快速的启动客户端..." + Environment.NewLine;
            foreach (string jobc in jobclinets)
            {
                richTextBox1.Text += jobc + Environment.NewLine;
            }
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\job_hunter\" + DateTime.Now.ToShortDateString().ToString()))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\job_hunter\" + DateTime.Now.ToShortDateString().ToString());
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "程序当前所在文件夹不支持创建文件夹，请已管理员身份运行或者移动到其他驱动器", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            MetroMessageBox.Show(this, "密钥已经生成并显示出来，需要同时复制APPID和手机号并合理分配给其他客户端用户", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pTimer = new System.Timers.Timer(AppSettings.TIME_OUT);//每隔5秒执行一次，没用winfrom自带的
            pTimer.Elapsed += pTimer_Elapsed;//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;//这个不太懂，有待研究
            label3.Text = "sending......";
            label2.Text = "屏幕已经开始截取...";
            接收输入ToolStripMenuItem_Click(sender, e);

        }



        private void pTimer_Elapsed_Paste(object sender, System.Timers.ElapsedEventArgs e)
        {
            string code = RedisCacheHelper.PopItemFromSet("paste_" + setPhone);
            if (code != null && code != "")
            {
                if (code.StartsWith("KB4100"))
                {
                    this.parentForm.notifyIcon1.ShowBalloonTip(2000, "正在下载补丁", code, ToolTipIcon.None);
                }
                else
                {
                    if (this.InvokeRequired)
                    {
                        updatePaste ur = new updatePaste(updatePaster);
                        this.Invoke(ur, code);
                    }
                    else
                    {
                        Clipboard.SetDataObject(code);
                    }
                }

            }
        }
        private void pTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);//获得当前屏幕的大小  
            Graphics g = this.CreateGraphics();
            //创建一个以当前屏幕为模板的图象   
            Image myimage = new Bitmap(rect.Width, rect.Height, g);

            //第二种得到全屏坐标的方法
            // Image myimage = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height,g);

            //创建以屏幕大小为标准的位图  
            Graphics gg = Graphics.FromImage(myimage);
            gg.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            string filePath = Application.StartupPath + @"\job_hunter\" + DateTime.Now.ToShortDateString().ToString() + @"\" + DateTime.Now.ToFileTime() + ".png";
            myimage.Save(filePath, ImageFormat.Png);//以JPG文件格式来保存
            string remotePath = ImageSG.uploadImage(filePath);
            if (remotePath != null)
            {
                foreach (string key in keys)
                {
                    RedisCacheHelper.AddItemToSet(key, remotePath);
                }
                if (this.InvokeRequired)
                {
                    updateLabel ur = new updateLabel(updateText);
                    this.Invoke(ur, ++num);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppSettings.loadConfig();
        }



        private void 启动客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void 关闭接收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTimer != null)
            {
                pTimer.Stop();
                num = 0;
                MetroMessageBox.Show(this, "已经停止截图", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label3.Text = "stoped......";
                label2.Text = "屏幕已经停止截取!!!";
            }
        }

        public delegate void updateLabel(int num);
        public void updateText(int num)
        {
            this.label1.Text = num.ToString().PadLeft(6, '0');
            return;
        }

        public delegate void updatePaste(string code);
        public void updatePaster(string code)
        {
            Clipboard.SetDataObject(code);
        }

        private void 接收输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (接收输入ToolStripMenuItem.Text == "接收输入")
            {
                pTimer2 = new System.Timers.Timer(AppSettings.COPY_FREQ);//每隔5秒执行一次，没用winfrom自带的
                pTimer2.Elapsed += pTimer_Elapsed_Paste;//委托，要执行的方法
                pTimer2.AutoReset = true;//获取该定时器自动执行
                pTimer2.Enabled = true;//这个一定要写，要不然定时器不会执行的
                MetroMessageBox.Show(this, "已经开始接收专属通道的代码或简答题答案", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                接收输入ToolStripMenuItem.Text = "停止接收";
            }
            else
            {
                pTimer2.Stop();
                pTimer2.Close();
                MetroMessageBox.Show(this, "已关闭答案接收", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                接收输入ToolStripMenuItem.Text = "接收输入";
            }

        }

        private void 清理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parentForm.Activate();
            this.parentForm.Show();
            this.parentForm.WindowState = FormWindowState.Normal;
            this.parentForm.kaoshi = null;
        }
    }
}
