using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using 助攻小助手;

namespace 自动截屏并上传
{
    public partial class Client : MetroForm
    {
        public string setID = "job_hunter";
        public string setPhone = "job_hunter";
        private System.Timers.Timer pTimer;
        public Client()
        {
            InitializeComponent();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = null, phone = null;
            if (Clipboard.ContainsText())
            {
                string jobc = Clipboard.GetText();
                if (jobc.StartsWith("job://"))
                {
                    jobc = DES.DecryptDES(jobc.Remove(0, 6), AppSettings.DES_KEY);
                    res = jobc.Split('#')[0];
                    phone = jobc.Split('#')[1];
                    MessageBox.Show(this, "已自动读取信息,如果获取不到图片，请用APPID和手机号手动输入");
                    Clipboard.Clear();
                }
                else
                {
                    res = Interaction.InputBox("请输入APPID", "系统提示", null, -1, -1);
                    phone = Interaction.InputBox("请输入手机号（必填)", "提示信息", null, -1, -1);
                }
            }
            else
            {
                res = Interaction.InputBox("请输入APPID", "系统提示", null, -1, -1);
                phone = Interaction.InputBox("请输入手机号（必填)", "提示信息", null, -1, -1);
            }
            if (res == null || phone == null || res == "" || phone == "")
            {
                MetroMessageBox.Show(this, "密钥或手机号为空无法开始，无法开始");
                return;
            }
            else
            {
                List<String> client_all = RedisCacheHelper.GetAllItemsFromList("client_all_key");
                if (!client_all.Contains(res))
                {
                    MetroMessageBox.Show(this, "密钥不合法", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            setID = res;
            setPhone = phone;
            pTimer = new System.Timers.Timer(5);//每隔5秒执行一次，没用winfrom自带的
            pTimer.Elapsed += pTimer_Elapsed;//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Text = "正在给" + setPhone + "助攻中......";
            开始ToolStripMenuItem.Text = "正在助攻中......";
            MetroMessageBox.Show(this, "需要可以获取图片列表则表示无问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string img = RedisCacheHelper.PopItemFromSet(setID);
            if (img != null)
            {
                this.listBox2.Items.Add(img);
            }
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listBox2.IndexFromPoint(e.X, e.Y);
            listBox2.SelectedIndex = index;
            if (listBox2.SelectedIndex != -1)
            {
                string path = listBox2.SelectedItem.ToString();
                loadImg(path);
            }
        }

        //依照比例加载图片
        public void loadImg(string filePath)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //LoadAsync：非同步转入图像  
            try
            {
                pictureBox1.LoadAsync(filePath);
            }
            catch (Exception ex)
            {

            }
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTimer == null)
            {
                return;
            }
            pTimer.Stop();
            MetroMessageBox.Show(this, "已停止给小伙伴助攻", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            开始ToolStripMenuItem.Text = "开始给小伙伴助攻";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            Clipboard.SetDataObject(pictureBox1.Image);
            MetroMessageBox.Show(this, "图片已复制到粘贴板，可以以QQ和微信分享", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void 给主发送粘贴板信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPaste sendPaste = new SendPaste(setPhone);
            sendPaste.Show();
        }

        private void 文字识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SouGouOCR souGouOCR = new SouGouOCR();

            //MessageBox.Show(souGouOCR.SogouOCR(pictureBox1.Image));
            (new Cat()).Show();

        }

        private void 以系统通知发送提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tips = Interaction.InputBox("比如第2题选择4，则输入2-4,则会收到KB41002-4", "发送答案", null, -1, -1);
            if (tips != "" && tips != null)
            {
                tips = "KB4100" + tips;
                RedisCacheHelper.AddItemToSet("paste_" + setPhone, tips);
                MetroMessageBox.Show(this, "答案以专属通道发送", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
