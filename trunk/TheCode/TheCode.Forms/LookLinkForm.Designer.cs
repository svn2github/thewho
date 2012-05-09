namespace TheCode.Forms
{
    partial class LookLinkForm
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
            this.txt_Link = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Link
            // 
            this.txt_Link.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Link.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.txt_Link.Location = new System.Drawing.Point(0, 0);
            this.txt_Link.Multiline = true;
            this.txt_Link.Name = "txt_Link";
            this.txt_Link.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_Link.Size = new System.Drawing.Size(779, 25);
            this.txt_Link.TabIndex = 0;
            // 
            // LookLinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 25);
            this.Controls.Add(this.txt_Link);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookLinkForm";
            this.Text = "查看连接字符串";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Link;
    }
}