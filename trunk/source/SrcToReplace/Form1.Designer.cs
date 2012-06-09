namespace SrcToReplace
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.startprocess = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lab_showfile = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.findtext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.replacetext = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.opencheckBox = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startprocess
            // 
            this.startprocess.Location = new System.Drawing.Point(64, 340);
            this.startprocess.Name = "startprocess";
            this.startprocess.Size = new System.Drawing.Size(75, 23);
            this.startprocess.TabIndex = 0;
            this.startprocess.Text = "开始";
            this.startprocess.UseVisualStyleBackColor = true;
            this.startprocess.Click += new System.EventHandler(this.startprocess_Click);
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 12;
            this.fileList.Location = new System.Drawing.Point(60, 205);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(493, 112);
            this.fileList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "文件夹路径:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "打开文件夹";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "要查找的文本内容:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "正在扫描:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 12);
            this.label7.TabIndex = 10;
            // 
            // lab_showfile
            // 
            this.lab_showfile.BackColor = System.Drawing.Color.PeachPuff;
            this.lab_showfile.Location = new System.Drawing.Point(187, 150);
            this.lab_showfile.Name = "lab_showfile";
            this.lab_showfile.Size = new System.Drawing.Size(365, 41);
            this.lab_showfile.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "停止";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // findtext
            // 
            this.findtext.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.findtext.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.findtext.Location = new System.Drawing.Point(185, 76);
            this.findtext.Name = "findtext";
            this.findtext.Size = new System.Drawing.Size(365, 21);
            this.findtext.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "label5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "替换成的文本内容:";
            // 
            // replacetext
            // 
            this.replacetext.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.replacetext.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.replacetext.Location = new System.Drawing.Point(185, 108);
            this.replacetext.Name = "replacetext";
            this.replacetext.Size = new System.Drawing.Size(365, 21);
            this.replacetext.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 17;
            // 
            // opencheckBox
            // 
            this.opencheckBox.Location = new System.Drawing.Point(319, 8);
            this.opencheckBox.Name = "opencheckBox";
            this.opencheckBox.Size = new System.Drawing.Size(103, 23);
            this.opencheckBox.TabIndex = 18;
            this.opencheckBox.Text = "选择文件类型";
            this.opencheckBox.UseVisualStyleBackColor = true;
            this.opencheckBox.Click += new System.EventHandler(this.opencheckBox_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(500, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(123, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 21);
            this.label11.TabIndex = 21;
            this.label11.Text = ".css";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(187, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 29);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 410);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.opencheckBox);
            this.Controls.Add(this.replacetext);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.findtext);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lab_showfile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.startprocess);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "文件替换工具";
            this.TransparencyKey = System.Drawing.Color.MediumPurple;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startprocess;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lab_showfile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox findtext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox replacetext;
        private System.Windows.Forms.Label fileinfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button opencheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

