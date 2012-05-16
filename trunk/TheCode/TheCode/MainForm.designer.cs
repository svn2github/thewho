namespace TheCode
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.com_Database = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fbd_main = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_DAL_Path = new System.Windows.Forms.Button();
            this.txt_DAL_Namespace = new System.Windows.Forms.TextBox();
            this.txt_DAL_Path = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Server = new System.Windows.Forms.TextBox();
            this.txt_User = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.com_Type = new System.Windows.Forms.ComboBox();
            this.btn_Conn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_LookLink = new System.Windows.Forms.LinkLabel();
            this.lb_Hide_ConnStr = new System.Windows.Forms.Label();
            this.lb_Status = new System.Windows.Forms.Label();
            this.btn_Again = new System.Windows.Forms.Button();
            this.Model = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ck_DAL = new System.Windows.Forms.CheckBox();
            this.lk_DAL = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ck_BLL = new System.Windows.Forms.CheckBox();
            this.lk_BLL = new System.Windows.Forms.LinkLabel();
            this.txt_BLL_Path = new System.Windows.Forms.TextBox();
            this.txt_BLL_Namespace = new System.Windows.Forms.TextBox();
            this.btn_BLL_Path = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Model_Path = new System.Windows.Forms.TextBox();
            this.ck_Model = new System.Windows.Forms.CheckBox();
            this.lk_Model = new System.Windows.Forms.LinkLabel();
            this.txt_Model_Namespace = new System.Windows.Forms.TextBox();
            this.btn_Model_Path = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.lb_createNum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Model.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // com_Database
            // 
            this.com_Database.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.com_Database, "com_Database");
            this.com_Database.FormattingEnabled = true;
            this.com_Database.Name = "com_Database";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Name = "label7";
            // 
            // btn_DAL_Path
            // 
            resources.ApplyResources(this.btn_DAL_Path, "btn_DAL_Path");
            this.btn_DAL_Path.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_DAL_Path.Name = "btn_DAL_Path";
            this.btn_DAL_Path.UseVisualStyleBackColor = true;
            this.btn_DAL_Path.Click += new System.EventHandler(this.btn_DAL_Path_Click);
            // 
            // txt_DAL_Namespace
            // 
            resources.ApplyResources(this.txt_DAL_Namespace, "txt_DAL_Namespace");
            this.txt_DAL_Namespace.Name = "txt_DAL_Namespace";
            // 
            // txt_DAL_Path
            // 
            resources.ApplyResources(this.txt_DAL_Path, "txt_DAL_Path");
            this.txt_DAL_Path.Name = "txt_DAL_Path";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Name = "label11";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Name = "label4";
            // 
            // txt_Server
            // 
            resources.ApplyResources(this.txt_Server, "txt_Server");
            this.txt_Server.Name = "txt_Server";
            // 
            // txt_User
            // 
            resources.ApplyResources(this.txt_User, "txt_User");
            this.txt_User.Name = "txt_User";
            // 
            // txt_Password
            // 
            resources.ApplyResources(this.txt_Password, "txt_Password");
            this.txt_Password.Name = "txt_Password";
            // 
            // com_Type
            // 
            this.com_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.com_Type, "com_Type");
            this.com_Type.FormattingEnabled = true;
            this.com_Type.Items.AddRange(new object[] {
            resources.GetString("com_Type.Items"),
            resources.GetString("com_Type.Items1")});
            this.com_Type.Name = "com_Type";
            this.com_Type.SelectedIndexChanged += new System.EventHandler(this.com_Type_SelectedIndexChanged);
            // 
            // btn_Conn
            // 
            resources.ApplyResources(this.btn_Conn, "btn_Conn");
            this.btn_Conn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Conn.Name = "btn_Conn";
            this.btn_Conn.UseVisualStyleBackColor = true;
            this.btn_Conn.Click += new System.EventHandler(this.btn_Conn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lb_LookLink);
            this.groupBox1.Controls.Add(this.lb_Hide_ConnStr);
            this.groupBox1.Controls.Add(this.lb_Status);
            this.groupBox1.Controls.Add(this.com_Type);
            this.groupBox1.Controls.Add(this.txt_Password);
            this.groupBox1.Controls.Add(this.txt_User);
            this.groupBox1.Controls.Add(this.txt_Server);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_Conn);
            this.groupBox1.Controls.Add(this.btn_Again);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lb_LookLink
            // 
            this.lb_LookLink.ActiveLinkColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.lb_LookLink, "lb_LookLink");
            this.lb_LookLink.BackColor = System.Drawing.SystemColors.Control;
            this.lb_LookLink.DisabledLinkColor = System.Drawing.SystemColors.WindowFrame;
            this.lb_LookLink.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_LookLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_LookLink.Name = "lb_LookLink";
            this.lb_LookLink.TabStop = true;
            this.lb_LookLink.Tag = "";
            this.lb_LookLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_LookLink_LinkClicked);
            // 
            // lb_Hide_ConnStr
            // 
            resources.ApplyResources(this.lb_Hide_ConnStr, "lb_Hide_ConnStr");
            this.lb_Hide_ConnStr.Name = "lb_Hide_ConnStr";
            // 
            // lb_Status
            // 
            resources.ApplyResources(this.lb_Status, "lb_Status");
            this.lb_Status.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_Status.Name = "lb_Status";
            // 
            // btn_Again
            // 
            resources.ApplyResources(this.btn_Again, "btn_Again");
            this.btn_Again.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Again.Name = "btn_Again";
            this.btn_Again.UseVisualStyleBackColor = true;
            this.btn_Again.Click += new System.EventHandler(this.btn_Again_Click);
            // 
            // Model
            // 
            this.Model.Controls.Add(this.com_Database);
            this.Model.Controls.Add(this.label7);
            resources.ApplyResources(this.Model, "Model");
            this.Model.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Model.Name = "Model";
            this.Model.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_DAL_Path);
            this.groupBox3.Controls.Add(this.ck_DAL);
            this.groupBox3.Controls.Add(this.lk_DAL);
            this.groupBox3.Controls.Add(this.txt_DAL_Namespace);
            this.groupBox3.Controls.Add(this.btn_DAL_Path);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // ck_DAL
            // 
            resources.ApplyResources(this.ck_DAL, "ck_DAL");
            this.ck_DAL.Name = "ck_DAL";
            this.ck_DAL.UseVisualStyleBackColor = true;
            this.ck_DAL.Click += new System.EventHandler(this.ck_DAL_Click);
            // 
            // lk_DAL
            // 
            this.lk_DAL.ActiveLinkColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.lk_DAL, "lk_DAL");
            this.lk_DAL.BackColor = System.Drawing.SystemColors.Control;
            this.lk_DAL.DisabledLinkColor = System.Drawing.SystemColors.WindowFrame;
            this.lk_DAL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lk_DAL.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lk_DAL.Name = "lk_DAL";
            this.lk_DAL.TabStop = true;
            this.lk_DAL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_DAL_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ck_BLL);
            this.groupBox4.Controls.Add(this.lk_BLL);
            this.groupBox4.Controls.Add(this.txt_BLL_Path);
            this.groupBox4.Controls.Add(this.txt_BLL_Namespace);
            this.groupBox4.Controls.Add(this.btn_BLL_Path);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // ck_BLL
            // 
            resources.ApplyResources(this.ck_BLL, "ck_BLL");
            this.ck_BLL.Name = "ck_BLL";
            this.ck_BLL.UseVisualStyleBackColor = true;
            this.ck_BLL.Click += new System.EventHandler(this.ck_BLL_Click);
            // 
            // lk_BLL
            // 
            this.lk_BLL.ActiveLinkColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.lk_BLL, "lk_BLL");
            this.lk_BLL.BackColor = System.Drawing.SystemColors.Control;
            this.lk_BLL.DisabledLinkColor = System.Drawing.SystemColors.WindowFrame;
            this.lk_BLL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lk_BLL.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lk_BLL.Name = "lk_BLL";
            this.lk_BLL.TabStop = true;
            this.lk_BLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_BLL_LinkClicked);
            // 
            // txt_BLL_Path
            // 
            resources.ApplyResources(this.txt_BLL_Path, "txt_BLL_Path");
            this.txt_BLL_Path.Name = "txt_BLL_Path";
            // 
            // txt_BLL_Namespace
            // 
            resources.ApplyResources(this.txt_BLL_Namespace, "txt_BLL_Namespace");
            this.txt_BLL_Namespace.Name = "txt_BLL_Namespace";
            // 
            // btn_BLL_Path
            // 
            resources.ApplyResources(this.btn_BLL_Path, "btn_BLL_Path");
            this.btn_BLL_Path.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_BLL_Path.Name = "btn_BLL_Path";
            this.btn_BLL_Path.UseVisualStyleBackColor = true;
            this.btn_BLL_Path.Click += new System.EventHandler(this.btn_BLL_Path_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Name = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.txt_Model_Path);
            this.groupBox2.Controls.Add(this.ck_Model);
            this.groupBox2.Controls.Add(this.lk_Model);
            this.groupBox2.Controls.Add(this.txt_Model_Namespace);
            this.groupBox2.Controls.Add(this.btn_Model_Path);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txt_Model_Path
            // 
            resources.ApplyResources(this.txt_Model_Path, "txt_Model_Path");
            this.txt_Model_Path.Name = "txt_Model_Path";
            // 
            // ck_Model
            // 
            resources.ApplyResources(this.ck_Model, "ck_Model");
            this.ck_Model.Name = "ck_Model";
            this.ck_Model.UseVisualStyleBackColor = true;
            this.ck_Model.Click += new System.EventHandler(this.ck_Model_Click);
            // 
            // lk_Model
            // 
            this.lk_Model.ActiveLinkColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.lk_Model, "lk_Model");
            this.lk_Model.BackColor = System.Drawing.SystemColors.Control;
            this.lk_Model.DisabledLinkColor = System.Drawing.SystemColors.WindowFrame;
            this.lk_Model.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lk_Model.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lk_Model.Name = "lk_Model";
            this.lk_Model.TabStop = true;
            this.lk_Model.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_Model_LinkClicked);
            // 
            // txt_Model_Namespace
            // 
            resources.ApplyResources(this.txt_Model_Namespace, "txt_Model_Namespace");
            this.txt_Model_Namespace.Name = "txt_Model_Namespace";
            // 
            // btn_Model_Path
            // 
            resources.ApplyResources(this.btn_Model_Path, "btn_Model_Path");
            this.btn_Model_Path.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Model_Path.Name = "btn_Model_Path";
            this.btn_Model_Path.UseVisualStyleBackColor = true;
            this.btn_Model_Path.Click += new System.EventHandler(this.btn_Model_Path_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Name = "label9";
            // 
            // btn_Start
            // 
            resources.ApplyResources(this.btn_Start, "btn_Start");
            this.btn_Start.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.pb_progress, "pb_progress");
            this.pb_progress.MarqueeAnimationSpeed = 1;
            this.pb_progress.Name = "pb_progress";
            // 
            // lb_createNum
            // 
            resources.ApplyResources(this.lb_createNum, "lb_createNum");
            this.lb_createNum.Name = "lb_createNum";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lb_createNum);
            this.Controls.Add(this.pb_progress);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Model.ResumeLayout(false);
            this.Model.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox com_Database;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FolderBrowserDialog fbd_main;
        private System.Windows.Forms.TextBox txt_DAL_Namespace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_DAL_Path;
        private System.Windows.Forms.TextBox txt_DAL_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Server;
        private System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.ComboBox com_Type;
        private System.Windows.Forms.Button btn_Conn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Model;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_BLL_Path;
        private System.Windows.Forms.Button btn_BLL_Path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_Model_Namespace;
        private System.Windows.Forms.Button btn_Model_Path;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lk_Model;
        private System.Windows.Forms.LinkLabel lk_DAL;
        private System.Windows.Forms.LinkLabel lk_BLL;
        private System.Windows.Forms.CheckBox ck_DAL;
        private System.Windows.Forms.CheckBox ck_BLL;
        private System.Windows.Forms.CheckBox ck_Model;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Button btn_Again;
        private System.Windows.Forms.Label lb_Hide_ConnStr;
        private System.Windows.Forms.TextBox txt_Model_Path;
        private System.Windows.Forms.Label lb_createNum;
        private System.Windows.Forms.TextBox txt_BLL_Namespace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lb_LookLink;
    }
}

