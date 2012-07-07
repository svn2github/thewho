namespace TheCode
{
    partial class ToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolForm));
            this.niTheCode = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnHtml = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // niTheCode
            // 
            this.niTheCode.Icon = ((System.Drawing.Icon)(resources.GetObject("niTheCode.Icon")));
            this.niTheCode.Text = "TheCode";
            this.niTheCode.Visible = true;
            this.niTheCode.Click += new System.EventHandler(this.niTheCode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(0, 0);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(234, 44);
            this.btnEncode.TabIndex = 0;
            this.btnEncode.Text = "编码和加密";
            this.btnEncode.UseVisualStyleBackColor = true;
            // 
            // btnHtml
            // 
            this.btnHtml.Location = new System.Drawing.Point(0, 43);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(234, 44);
            this.btnHtml.TabIndex = 1;
            this.btnHtml.Text = "HTML字符串";
            this.btnHtml.UseVisualStyleBackColor = true;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(0, 86);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(234, 44);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "批量替换字符串";
            this.btnReplace.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(0, 130);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(234, 44);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建文件";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(234, 364);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnHtml);
            this.Controls.Add(this.btnEncode);
            this.Name = "ToolForm";
            this.Text = "ToolForm";
            this.MinimumSizeChanged += new System.EventHandler(this.ToolForm_MinimumSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.NotifyIcon niTheCode;


    }
}