using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace 自动截屏并上传
{
    public partial class Client : Form
    {
        public string setID = "job_hunter";
        private System.Timers.Timer pTimer;
        public Client()
        {
            InitializeComponent();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = Interaction.InputBox("提示信息", "请输入密钥", "", -1, -1);
            if (res == "" || res == null)
            {
                MessageBox.Show("密钥为空");
                return;
            }
            else
            {
                List<String> client_all = RedisCacheHelper.GetAllItemsFromList("client_all_key");
                if (!client_all.Contains(res))
                {
                    MessageBox.Show("密钥不合法");
                    return;
                }
            }
            setID = res;
            pTimer = new System.Timers.Timer(5);//每隔5秒执行一次，没用winfrom自带的
            pTimer.Elapsed += pTimer_Elapsed;//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;
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
            pTimer.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Clipboard.SetDataObject(pictureBox1.Image);
        }

        private void 给主发送粘贴板信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPaste sendPaste = new SendPaste();
            sendPaste.Show();
        }
    }
}
