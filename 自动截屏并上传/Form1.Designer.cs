namespace 自动截屏并上传
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.定时执行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭接收ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.接收输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.定时执行ToolStripMenuItem,
            this.关闭接收ToolStripMenuItem,
            this.启动客户端ToolStripMenuItem,
            this.接收输入ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 定时执行ToolStripMenuItem
            // 
            this.定时执行ToolStripMenuItem.Name = "定时执行ToolStripMenuItem";
            this.定时执行ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.定时执行ToolStripMenuItem.Text = "开始处理";
            this.定时执行ToolStripMenuItem.Click += new System.EventHandler(this.定时执行ToolStripMenuItem_Click);
            // 
            // 关闭接收ToolStripMenuItem
            // 
            this.关闭接收ToolStripMenuItem.Name = "关闭接收ToolStripMenuItem";
            this.关闭接收ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.关闭接收ToolStripMenuItem.Text = "停止处理";
            this.关闭接收ToolStripMenuItem.Click += new System.EventHandler(this.关闭接收ToolStripMenuItem_Click);
            // 
            // 启动客户端ToolStripMenuItem
            // 
            this.启动客户端ToolStripMenuItem.Name = "启动客户端ToolStripMenuItem";
            this.启动客户端ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.启动客户端ToolStripMenuItem.Text = "启动客户端";
            this.启动客户端ToolStripMenuItem.Click += new System.EventHandler(this.启动客户端ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(162, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "00-00";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 112);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(466, 219);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // 接收输入ToolStripMenuItem
            // 
            this.接收输入ToolStripMenuItem.Name = "接收输入ToolStripMenuItem";
            this.接收输入ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.接收输入ToolStripMenuItem.Text = "接收输入";
            this.接收输入ToolStripMenuItem.Click += new System.EventHandler(this.接收输入ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 330);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 定时执行ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 启动客户端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭接收ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 接收输入ToolStripMenuItem;
    }
}

