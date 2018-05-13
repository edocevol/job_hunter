namespace 自动截屏并上传
{
    partial class ScreenShot
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
            this.SuspendLayout();
            // 
            // ScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(679, 471);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenShot";
            this.Opacity = 0.4;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕截图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScreenShot_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenShot_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenShot_MouseDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenShot_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenShot_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenShot_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

    }
}