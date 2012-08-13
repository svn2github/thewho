using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Configuration;


namespace TheCode
{
    public partial class MainForm : Form
    {
        public string connStr, databaseName;
        public string server, type, user, password, checkNum;
        public int count,sum;
        public int tableCount, createNum;
        public TheCode.DAL.Database _database = new TheCode.DAL.Database();
        public TheCode.DAL.Table _table = new TheCode.DAL.Table();
        public TheCode.DAL.Column _column = new TheCode.DAL.Column();

        private static string Model_Namespace = ConfigurationSettings.AppSettings["Model_Namespace"].ToString();
        private static string DAL_Namespace = ConfigurationSettings.AppSettings["DAL_Namespace"].ToString();
        private static string BLL_Namespace = ConfigurationSettings.AppSettings["BLL_Namespace"].ToString();

        private static string Model_Path = ConfigurationSettings.AppSettings["Model_Path"].ToString();
        private static string DAL_Path = ConfigurationSettings.AppSettings["DAL_Path"].ToString();
        private static string BLL_Path = ConfigurationSettings.AppSettings["BLL_Path"].ToString();

        public MainForm()
        {
            InitializeComponent();

            Form_Init();
        }

        #region 方法

        //窗体初始化方法
        public void Form_Init()
        {
            this.Text = "代码生成器 - TheCode v1.1";
            com_Type.SelectedItem = "Windows 身份验证";

            txt_Model_Namespace.Text = Model_Namespace;
            txt_DAL_Namespace.Text = DAL_Namespace;
            txt_BLL_Namespace.Text = BLL_Namespace;

            txt_Model_Path.Text = Model_Path;
            txt_DAL_Path.Text = DAL_Path;
            txt_BLL_Path.Text = BLL_Path;

            //窗口居中
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2), this.Width, this.Height, BoundsSpecified.Location);
        }

        public void StatusShow(string str, bool isTrue)
        {
            if (isTrue)
            {
                lb_Status.ForeColor = Color.Green;
                lb_Status.Text = str;
            }
            else {
                lb_Status.ForeColor = Color.Red;
                lb_Status.Text = str;
            }
        }

        //服务器名称和身份验证方法
        public bool VerifyServer()
        {
            server = txt_Server.Text.Trim();
            type = Convert.ToString(com_Type.SelectedItem);
            if (string.IsNullOrEmpty(server))
            {
                txt_Server.Focus();
                StatusShow("服务器名称不能为空！", false);
                return false;
            }
            if (string.IsNullOrEmpty(type))
            {
                com_Type.Focus();
                StatusShow("请选择身份验证方式！",false);
                return false;
            }
            return true;
        }

        //登录名和密码验证方法
        public bool VerifyUser()
        {
            user = txt_User.Text.Trim();
            password = txt_Password.Text.Trim();
            if (string.IsNullOrEmpty(user))
            {
                txt_User.Focus();
                StatusShow("登录名不能为空！", false);
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                txt_Password.Focus();
                StatusShow("密码不能为空！", false);
                return false;
            }
            return true;
        }


        public void BindDatabase(string connStr)
        {
            List<TheCode.Model.Database> dblist = _database.GetList(connStr);
            if (dblist != null && dblist.Count > 0)
            {   
                com_Database.SelectedIndex = -1;
                com_Database.DataSource = _database.GetList(connStr);
                com_Database.DisplayMember = "DatabaseName";
                com_Database.ValueMember = "DatabaseName";

                lb_Hide_ConnStr.Text = connStr;

                btn_Conn.Visible = false;
                btn_Again.Visible = true;

                Display_Database(true);
                Display_ServerType(false);
                Display_UserPwd(false);
                Display_Model(true);
                Display_DAL(true);
                Display_BLL(true);

                btn_Start.Enabled = true;
            }
            else
            {
                MessageBox.Show("没有可用的数据库！");
            }
        }

        public void Display_ServerType(bool isTrue)
        {
            txt_Server.Enabled = isTrue;
            com_Type.Enabled = isTrue;
        }
        public void Display_UserPwd(bool isTrue)
        {
            txt_User.Enabled = isTrue;
            txt_Password.Enabled = isTrue;
        }
        public void Display_Database(bool isTrue)
        {
            com_Database.Enabled = isTrue;
        }
        public void Display_Model(bool isTrue)
        {
            ck_Model.Enabled = isTrue;
            ck_Model.Checked = isTrue;

            txt_Model_Path.Enabled = isTrue;
            txt_Model_Namespace.Enabled = isTrue;
            btn_Model_Path.Enabled = isTrue;
        }
        public void Display_DAL(bool isTrue)
        {
            ck_DAL.Enabled = isTrue;
            ck_DAL.Checked = isTrue;

            txt_DAL_Path.Enabled = isTrue;
            txt_DAL_Namespace.Enabled = isTrue;
            btn_DAL_Path.Enabled = isTrue;
        }
        public void Display_BLL(bool isTrue)
        {
            ck_BLL.Enabled = isTrue;
            ck_BLL.Checked = isTrue;

            txt_BLL_Path.Enabled = isTrue;
            txt_BLL_Namespace.Enabled = isTrue;
            btn_BLL_Path.Enabled = isTrue;
        }


        #endregion

        private void btn_Conn_Click(object sender, EventArgs e)
        {
            if (VerifyServer())
            {
                server = txt_Server.Text.Trim();
                type = Convert.ToString(com_Type.SelectedItem);
                if (type == "SQL Server 身份验证")//如果是选择SQL
                {
                    if (VerifyUser())
                    {
                        user = txt_User.Text.Trim();
                        password = txt_Password.Text.Trim();
                        connStr = TheCode.Common.Conn.IsConnectionStr(server, type, user, password);
                        if (string.IsNullOrEmpty(connStr))
                        {
                            StatusShow("连接失败！", false);
                        }
                        else
                        {
                            StatusShow("连接成功！", true);
                            lb_LookLink.Tag = connStr;
                            lb_LookLink.Visible = true;
                            BindDatabase(connStr);
                        }
                    }
                }
                else // 如果是Windows
                {
                    connStr = TheCode.Common.Conn.IsConnectionStr(server, type, user, password);
                    if (string.IsNullOrEmpty(connStr))
                    {
                        StatusShow("连接失败！", false);
                    }
                    else
                    {;
                        StatusShow("连接成功！", true); 
                        lb_LookLink.Tag = connStr;
                        lb_LookLink.Visible = true;
                        BindDatabase(connStr);
                    }
                }
            }
        }

        private void com_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = Convert.ToString(com_Type.SelectedItem);
            if (type == "SQL Server 身份验证")
            {
                Display_UserPwd(true);
            }
            else
            {
                Display_UserPwd(false);
            }
        }

        private void btn_Again_Click(object sender, EventArgs e)
        {
            btn_Conn.Visible = true;
            btn_Again.Visible = false;
            txt_Server.Enabled = true;
            type = Convert.ToString(com_Type.SelectedItem);
            com_Type.Enabled = true;
            if (type == "SQL Server 身份验证")
            {
                Display_UserPwd(true);
            }
            Display_Database(false);
            Display_Model(false);
            Display_DAL(false);
            Display_BLL(false);
            StatusShow("", false);

            lb_LookLink.Tag = "";
            lb_LookLink.Visible = false;

            btn_Start.Enabled = false;
        }

        private void ck_Model_Click(object sender, EventArgs e)
        {
            Display_Model(ck_Model.Checked);
            ck_Model.Enabled = true;

            //Display_DAL(ck_Model.Checked);
            //ck_DAL.Enabled = true;

            //Display_BLL(ck_Model.Checked);
            //ck_BLL.Enabled = true;
        }

        private void ck_DAL_Click(object sender, EventArgs e)
        {
            Display_DAL(ck_DAL.Checked);
            ck_DAL.Enabled = true;

            //Display_BLL(ck_DAL.Checked);
            //ck_BLL.Enabled = true;
        }

        private void ck_BLL_Click(object sender, EventArgs e)
        {
            Display_BLL(ck_BLL.Checked);
            ck_BLL.Enabled = true;
        }

        private void btn_Model_Path_Click(object sender, EventArgs e)
        {
            fbd_main.ShowDialog();
            txt_Model_Path.Text = fbd_main.SelectedPath;
        }

        private void btn_DAL_Path_Click(object sender, EventArgs e)
        {
            fbd_main.ShowDialog();
            txt_DAL_Path.Text = fbd_main.SelectedPath;
        }

        private void btn_BLL_Path_Click(object sender, EventArgs e)
        {
            fbd_main.ShowDialog();
            txt_BLL_Path.Text = fbd_main.SelectedPath;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            
            //模型层
            if (ck_Model.Checked)
            {
                if (string.IsNullOrEmpty(txt_Model_Path.Text.Trim()))
                {
                    txt_Model_Path.Focus();
                    MessageBox.Show("Model层生成路径不能为空！");
                    return;
                }
                else if (string.IsNullOrEmpty(txt_Model_Namespace.Text.Trim()))
                {
                    txt_Model_Namespace.Focus();
                    MessageBox.Show("Model层命名空间不能为空！");
                    return;
                }
                else
                {
                    checkNum += "model";
                    count = 1;//只生成模型层为1
                }

            }//数据层
            if (ck_DAL.Checked)
            {
                if (string.IsNullOrEmpty(txt_DAL_Path.Text.Trim()))
                {
                    txt_DAL_Path.Focus();
                    MessageBox.Show("DAL层生成路径不能为空！");
                    return;
                }
                else if (string.IsNullOrEmpty(txt_DAL_Namespace.Text.Trim()))
                {
                    txt_DAL_Namespace.Focus();
                    MessageBox.Show("DAL层命名空间不能为空！");
                    return;
                }
                else
                {
                    checkNum += "dal";
                    count++;//生成模型层和数据层为2
                }

            }//逻辑层
            if (ck_BLL.Checked)
            {
                if (string.IsNullOrEmpty(txt_BLL_Path.Text.Trim()))
                {
                    txt_BLL_Path.Focus();
                    MessageBox.Show("BLL层生成路径不能为空！");
                    return;
                }
                else if (string.IsNullOrEmpty(txt_BLL_Namespace.Text.Trim()))
                {
                    txt_BLL_Namespace.Focus();
                    MessageBox.Show("BLL层命名空间不能为空！");
                    return;
                }
                else
                {
                    checkNum += "bll";
                    //count++;//生成模型层,数据层和逻辑层为3
                }
            }

            if (string.IsNullOrEmpty(checkNum))
            {
                MessageBox.Show("没有可生成的项！");
                return;
            }
            else
            {
                pb_progress.Visible = true;
                connStr = lb_Hide_ConnStr.Text;
                databaseName = Convert.ToString(com_Database.SelectedValue);
                List<TheCode.Model.Table> tableList = _table.GetList(connStr, databaseName);
                sum = 0;
                tableCount = tableList.Count;

                //switch (count)
                //{
                //    case 1:
                //        sum = tableCount * 1;
                //        Create(1, connStr, txt_Model_Path.Text, txt_Model_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text,sum);
                //        break;
                //    case 2:
                //        sum = tableCount * 2;
                //        Create(1, connStr, txt_Model_Path.Text, txt_Model_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                //        Create(2, connStr, txt_DAL_Path.Text, txt_DAL_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                //        break;
                //    case 3:
                //        sum = tableCount * 3;
                //        Create(1, connStr, txt_Model_Path.Text, txt_Model_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                //        Create(2, connStr, txt_DAL_Path.Text, txt_DAL_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                //        Create(3, connStr, txt_BLL_Path.Text, txt_BLL_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                //        break;
                //}
                if (checkNum.IndexOf("model") > -1)
                {
                    sum += tableCount;
                    Create(1, connStr, txt_Model_Path.Text, txt_Model_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                }
                if (checkNum.IndexOf("dal") > -1)
                {
                    sum += tableCount;
                    Create(2, connStr, txt_DAL_Path.Text, txt_DAL_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                }
                if (checkNum.IndexOf("bll") > -1)
                {
                    sum += tableCount;
                    Create(3, connStr, txt_BLL_Path.Text, txt_BLL_Namespace.Text, databaseName, tableList, txt_Model_Namespace.Text, txt_DAL_Namespace.Text, txt_BLL_Namespace.Text, sum);
                }

                pb_progress.Step = sum;

                btn_Conn.Enabled = false;
                com_Database.Enabled = false;
                btn_Again.Enabled = false;

                Display_Model(false);
                Display_DAL(false);
                Display_BLL(false);


                //完成
                if (Convert.ToInt32(lb_createNum.Text) == sum)
                {
                    
                    //MessageBox.Show("" + Convert.ToInt32(lb_createNum.Text).ToString());
                    if (MessageBox.Show("全部生成完成！\n" + "共生成" + Convert.ToInt32(lb_createNum.Text).ToString() + "个文件！", "TheCode", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                   
                }
            }
        }

        public void sss()
        { 
            
        }

        public void Create(int createType, string connStr, string createPath, string nameSpace, string databaseName, List<TheCode.Model.Table> tableList,string modelNameSpace,string dalNameSpace, string bllNameSpace, int sum)
        {
            foreach (TheCode.Model.Table item in tableList)
            {
                List<TheCode.Model.Column> columnList = _column.GetList(connStr, databaseName, item.TableName);
                new TheCode.Common.Tempate(createType, createPath, nameSpace, databaseName, item.TableName, columnList,
                    modelNameSpace, dalNameSpace, bllNameSpace).Create();
                
                pb_progress.PerformStep();

                lb_createNum.Text = (Convert.ToInt32(lb_createNum.Text) + 1).ToString();
            }
            
        }

        
        public class ThreadedExecute
        {
            public int  createType;
            public string connStr,createPath, nameSpace, databaseName;
            public string modelNameSpace, dalNameSpace, bllNameSpace;
            public List<TheCode.Model.Table> tableList;
            public TheCode.DAL.Column _column = new TheCode.DAL.Column();

            public ThreadedExecute(int createType,string connStr, string createPath, string nameSpace, string databaseName, List<TheCode.Model.Table> tableList,string modelNameSpace,string dalNameSpace, string bllNameSpace)
            {
                this.createType = createType;
                this.connStr = connStr;
                this.createPath = createPath;
                this.nameSpace = nameSpace;
                this.databaseName = databaseName;
                this.tableList = tableList;

                this.modelNameSpace = modelNameSpace;
                this.dalNameSpace = dalNameSpace;
                this.bllNameSpace = bllNameSpace;
            }

            public void create()
            {
                foreach (TheCode.Model.Table item in tableList)
                {
                    List<TheCode.Model.Column> columnList = _column.GetList(connStr, databaseName, item.TableName);
                    new TheCode.Common.Tempate3(createType, createPath, nameSpace, databaseName, item.TableName, columnList,
                    modelNameSpace, dalNameSpace, bllNameSpace).create();
                }
            }
        }

        private void lk_Model_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("还没这个功能哦！");
        }

        private void lk_DAL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("还没这个功能哦！");
        }

        private void lk_BLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("还没这个功能哦！");
        }

        private void lb_LookLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string connStr = lb_LookLink.Tag.ToString();
            LookLinkForm llf = new LookLinkForm(connStr);
            llf.Show();
        }
    }
}
