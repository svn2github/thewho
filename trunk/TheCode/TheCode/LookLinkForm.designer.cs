namespace TheCode
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
            this.btn_Copy = new System.Windows.Forms.Button();
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
            this.txt_Link.Size = new System.Drawing.Size(676, 46);
            this.txt_Link.TabIndex = 0;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Copy.Location = new System.Drawing.Point(678, 0);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(86, 46);
            this.btn_Copy.TabIndex = 1;
            this.btn_Copy.Text = "复制";
            this.btn_Copy.UseVisualStyleBackColor = true;
            // 
            // LookLinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 46);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.txt_Link);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
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
        private System.Windows.Forms.Button btn_Copy;
    }
}