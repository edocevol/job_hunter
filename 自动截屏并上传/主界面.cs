using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动截屏并上传
{
    public partial class 主界面 : MetroForm
    {
        public 主界面()
        {
            InitializeComponent();
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            (new Form1()).Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            (new Client()).Show();
        }

        private void metroRadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            (new Client()).Show();
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            (new Client()).Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://job.wanqing520.cn/");
        }
    }
}
