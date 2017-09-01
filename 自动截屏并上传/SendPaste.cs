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
    public partial class SendPaste : Form
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
            }
        }
    }
}
