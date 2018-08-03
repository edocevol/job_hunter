using MetroFramework.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QCloud.CosApi.Api;
using QCloud.CosApi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动截屏并上传
{
    public partial class 主界面 : MetroForm
    {
        private Thread threadupdate;

        public Form1 kaoshi;
        public 主界面()
        {
            InitializeComponent();
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (kaoshi == null)
            {
                kaoshi = new Form1(this);
            }
            kaoshi.Show();
            this.WindowState = FormWindowState.Normal;
            kaoshi.Activate();
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
            System.Diagnostics.Process.Start("http://job.wanqing520.cn/help/client_bw.html");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://job.wanqing520.cn/help/client_bw.html");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            string res = Interaction.InputBox("提示信息", "输入清理日志管理权限", "admin", -1, -1);
            if (res != null && res.Equals("admin10086"))
            {
                metroProgressBar1.Value = 0;
                Thread myThread = new Thread(DoData);
                myThread.IsBackground = true;
                myThread.Start(); //线程开始 
            }
            else
            {
                MessageBox.Show("it is none of your bussiness");
            }

        }
        private delegate void DoDataDelegate(object number);
        /// <summary>  
        /// 进行循环  
        /// </summary>  
        /// <param name="number"></param>  
        private void DoData(object number)
        {
            if (metroProgressBar1.InvokeRequired)
            {
                DoDataDelegate d = DoData;
                metroProgressBar1.Invoke(d, number);
            }
            else
            {
                try
                {
                    bool tsop = false;
                    int total_count = 0;
                    while (!tsop)
                    {
                        var foldListParasDic = new Dictionary<string, string>();
                        foldListParasDic.Add(CosParameters.PARA_NUM, "1000");
                        var cos = new CosCloud(AppSettings.APP_ID, AppSettings.SECRET_ID, AppSettings.SECRET_KEY);
                        //result = cos.DeleteFolder();
                        var result = cos.GetFolderList(AppSettings.BUCKET_NAME, "job_hunters", foldListParasDic);
                        var obj = (JObject)JsonConvert.DeserializeObject(result);
                        var code = (int)obj["code"];
                        if (code == 0)
                        {
                            string data = obj["data"].ToString();//获取message属性(字段)的值  
                            JObject infos = JObject.Parse(data);//把message转化为JObject对象  
                            JArray ja = JArray.Parse(infos["infos"].ToString());//把规格转化为数组对象  
                            int ja_length = ja.Count();//获取数组的长度  
                            metroProgressBar1.Maximum = ja_length;
                            for (int i = 0; i < ja_length; i++)
                            {
                                string url = ja[i]["source_url"].ToString();
                                cos.DeleteFile(AppSettings.BUCKET_NAME, "job_hunters" + url.Substring(url.IndexOf("/" + 1)));
                                metroProgressBar1.Value += 1;
                            }
                            total_count += ja_length;
                            if (ja_length == 0)
                            {
                                tsop = true;
                            }
                        }
                    }
                    MessageBox.Show("清理了" + total_count + "个文件");
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void 主界面_Load(object sender, EventArgs e)
        {
            //update();
        }

        private void 主界面_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void update()
        {
            string pageHtml;
            try
            {

                WebClient MyWebClient = new WebClient();

                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于对向Internet资源的请求进行身份验证的网络凭据。

                Byte[] pageData = MyWebClient.DownloadData("http://job.wanqing520.cn/download/index.md"); //从指定网站下载数据
                pageHtml = Encoding.UTF8.GetString(pageData);

                int index = pageHtml.IndexOf("~");//确定~符号的位置，以便获取版本号
                String ver;

                ver = pageHtml.Substring(index + 1, 7);//获取版本号，例如1.2.1
                if (ver != Application.ProductVersion)//有新版本
                {
                    if (DialogResult.Yes == MessageBox.Show(pageHtml, "有新版本 " + ver + " 是否更新？", MessageBoxButtons.YesNo)) { System.Diagnostics.Process.Start("http://job.wanqing520.cn/download/job-helper.zip"); }//有更新时打开链接
                }

            }
            catch (WebException webEx)
            {

                Console.WriteLine(webEx.Message.ToString());

            }
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (kaoshi == null)
            {
                kaoshi = new Form1(this);
            }
            kaoshi.Show();
            this.WindowState = FormWindowState.Normal;
            kaoshi.Activate();
        }

        private void 打开主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
                this.metroContextMenu1.Items[0].Text = "打开主界面";
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.metroContextMenu1.Items[0].Text = "隐藏主界面";
            }
        }

        private void 主界面_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.metroContextMenu1.Items[0].Text = "打开主界面";
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 启动考试端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kaoshi == null)
            {
                kaoshi = new Form1(this);
            }
            kaoshi.WindowState = FormWindowState.Normal;
            kaoshi.Show();
            kaoshi.Activate();
        }

        private void 主界面_Leave(object sender, EventArgs e)
        {
            //this.Hide();
            //this.metroContextMenu1.Items[0].Text = "打开主界面";
        }

        private void 主界面_Deactivate(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void 启动助考端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Client()).Show();
        }

        private void 启动网页端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://job.wanqing520.cn/help/client_bw.html");
        }

        private void 查看本地图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath + @"\job_hunter\" );
        }
    }
}
