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
        public SendPaste()
        {
            InitializeComponent();
        }

        private void 确认发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = this.richTextBox1.Text;
            if (code != "" && code != null) {
                RedisCacheHelper.AddItemToSet("paste_" + AppSettings.JOB_NAME, code);
                MetroMessageBox.Show(this, "答案以专属通道发送", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 50);
            }
        }
    }
}
