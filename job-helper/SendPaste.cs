using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 自动截屏并上传
{
    public partial class SendPaste : MetroForm
    {
        private string phone;
        public SendPaste(string phone)
        {
            InitializeComponent();
            this.phone = phone;
            this.Text = "给" + phone + "发送答案";
        }

        private void 确认发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = this.richTextBox1.Text;
            if (code != "" && code != null) {
                RedisCacheHelper.AddItemToSet("paste_" + phone, code);
                MetroMessageBox.Show(this, "答案以专属通道发送", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SendPaste_Load(object sender, EventArgs e)
        {
            AppSettings.loadConfig();
        }
    }
}
