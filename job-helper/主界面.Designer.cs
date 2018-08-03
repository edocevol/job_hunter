namespace 自动截屏并上传
{
    partial class 主界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(主界面));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.打开主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动考试端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动助考端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动网页端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看本地图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton1.BackgroundImage")));
            this.metroButton1.Location = new System.Drawing.Point(128, 118);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(205, 195);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroButton1.TabIndex = 0;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton2.BackgroundImage")));
            this.metroButton2.Location = new System.Drawing.Point(489, 118);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(205, 195);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(541, 341);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(101, 15);
            this.metroRadioButton1.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroRadioButton1.TabIndex = 2;
            this.metroRadioButton1.Text = "助考者客户端";
            this.metroRadioButton1.UseSelectable = true;
            this.metroRadioButton1.CheckedChanged += new System.EventHandler(this.metroRadioButton1_CheckedChanged_1);
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(180, 341);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(101, 15);
            this.metroRadioButton2.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroRadioButton2.TabIndex = 3;
            this.metroRadioButton2.Text = "考试者客户端";
            this.metroRadioButton2.UseSelectable = true;
            this.metroRadioButton2.CheckedChanged += new System.EventHandler(this.metroRadioButton2_CheckedChanged);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(684, 393);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(102, 49);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroButton4.TabIndex = 5;
            this.metroButton4.Text = "清理图片信息";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(43, 393);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(634, 49);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroProgressBar1.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.metroContextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "job-helper";
            this.notifyIcon1.Visible = true;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开主界面ToolStripMenuItem,
            this.启动考试端ToolStripMenuItem,
            this.启动助考端ToolStripMenuItem,
            this.启动网页端ToolStripMenuItem,
            this.查看本地图片ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(137, 136);
            // 
            // 打开主界面ToolStripMenuItem
            // 
            this.打开主界面ToolStripMenuItem.Image = global::助考小助手.Properties.Resources.控制台首页;
            this.打开主界面ToolStripMenuItem.Name = "打开主界面ToolStripMenuItem";
            this.打开主界面ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开主界面ToolStripMenuItem.Text = "打开主界面";
            this.打开主界面ToolStripMenuItem.Click += new System.EventHandler(this.打开主界面ToolStripMenuItem_Click);
            // 
            // 启动考试端ToolStripMenuItem
            // 
            this.启动考试端ToolStripMenuItem.Image = global::助考小助手.Properties.Resources.考试分析;
            this.启动考试端ToolStripMenuItem.Name = "启动考试端ToolStripMenuItem";
            this.启动考试端ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.启动考试端ToolStripMenuItem.Text = "启动考试端";
            this.启动考试端ToolStripMenuItem.Click += new System.EventHandler(this.启动考试端ToolStripMenuItem_Click);
            // 
            // 启动助考端ToolStripMenuItem
            // 
            this.启动助考端ToolStripMenuItem.Image = global::助考小助手.Properties.Resources.管理监测;
            this.启动助考端ToolStripMenuItem.Name = "启动助考端ToolStripMenuItem";
            this.启动助考端ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.启动助考端ToolStripMenuItem.Text = "启动助考端";
            this.启动助考端ToolStripMenuItem.Click += new System.EventHandler(this.启动助考端ToolStripMenuItem_Click);
            // 
            // 启动网页端ToolStripMenuItem
            // 
            this.启动网页端ToolStripMenuItem.Image = global::助考小助手.Properties.Resources.浏览器;
            this.启动网页端ToolStripMenuItem.Name = "启动网页端ToolStripMenuItem";
            this.启动网页端ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.启动网页端ToolStripMenuItem.Text = "启动网页端";
            this.启动网页端ToolStripMenuItem.Click += new System.EventHandler(this.启动网页端ToolStripMenuItem_Click);
            // 
            // 查看本地图片ToolStripMenuItem
            // 
            this.查看本地图片ToolStripMenuItem.Name = "查看本地图片ToolStripMenuItem";
            this.查看本地图片ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.查看本地图片ToolStripMenuItem.Text = "图片文件夹";
            this.查看本地图片ToolStripMenuItem.Click += new System.EventHandler(this.查看本地图片ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // metroLink1
            // 
            this.metroLink1.ForeColor = System.Drawing.Color.Green;
            this.metroLink1.Location = new System.Drawing.Point(1, 523);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(142, 23);
            this.metroLink1.TabIndex = 6;
            this.metroLink1.Text = "发布日期：20180622";
            this.metroLink1.UseSelectable = true;
            // 
            // 主界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 547);
            this.ContextMenuStrip = this.metroContextMenu1;
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroRadioButton2);
            this.Controls.Add(this.metroRadioButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "主界面";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "助考小能手";
            this.Deactivate += new System.EventHandler(this.主界面_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.主界面_FormClosing);
            this.Load += new System.EventHandler(this.主界面_Load);
            this.SizeChanged += new System.EventHandler(this.主界面_SizeChanged);
            this.Leave += new System.EventHandler(this.主界面_Leave);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem 打开主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动考试端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动助考端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动网页端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看本地图片ToolStripMenuItem;
        private MetroFramework.Controls.MetroLink metroLink1;
    }
}