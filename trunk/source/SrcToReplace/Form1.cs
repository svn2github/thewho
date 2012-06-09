using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

namespace SrcToReplace
{


    public partial class Form1 : Form
    {
        private TextBoxRemind remind = null;
        public List<string> slist = null;
        public static Session s;
        public Form1()
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            remind = new TextBoxRemind();
        }
        Thread search_thread = null;
        string file_extend = ".css";
        ToolTip tool_showinfo = new ToolTip();

        void InitTextBoxRemind()
        {
            remind.InitAutoCompleteCustomSource(findtext);
            remind.InitAutoCompleteCustomSource(replacetext);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             InitTextBoxRemind();
         
     string    extend=ReadTxt();
            string uu="";
           if(extend.Length>=1)
           {



               label11.Text = extend;
           }



            label5.Visible = false;
            List<MyItem> items = new List<MyItem>();
       


        }


        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath,Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }

        private void startprocess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(findtext.Text.Trim()))
            {

                MessageBox.Show("您要查找的内容不能为空");
                return;

            }
            if (string.IsNullOrEmpty(replacetext.Text))
            {

                MessageBox.Show("您要替换成的内容不能为空");
                return;

            }
        
            // 把 搜索的文本 和 要替换的成的文本 保存在XML文件中

           // writeXML(replacetext.Text.Trim(),findtext.Text.Trim());



            startprocess.Enabled = true;

            if (search_thread == null)
                search_thread = new Thread(new ThreadStart(startsearch));

            if (search_thread.ThreadState == ThreadState.Stopped)
            {
                search_thread = null;
                search_thread = new Thread(new ThreadStart(startsearch));
            }

            if (!search_thread.IsAlive)
                search_thread.Start();

            startprocess.Enabled = true;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileInfosrc = "";
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

                fileInfosrc = folderBrowserDialog1.SelectedPath;

            }

            label5.Text = fileInfosrc;
            label9.Text = fileInfosrc;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        void startsearch()
        {
            fileList.Items.Clear();
            ScanFiles(label5.Text.Trim());
            MessageBox.Show("搜索替换完成！！！");
        }

        void ScanFiles(string filepath)
        {
               string file_extend = "";
               int k = 0;
               int count = 0;
            if (filepath.Trim().Length > 0)
            {
                try
                {
                    string[] filecollect = Directory.GetFileSystemEntries(filepath);


                    foreach (string file in filecollect)
                    {
                        k++;
                        if (Directory.Exists(file))
                        {
                         
                            ScanFiles(file);
                        }
                        else
                        {
                             count = filecollect.Length;

                            lab_showfile.Text = file;

                            // 查找替换




                            string[] extend = new string[] { ".css" };



                            if (label11.Text != "")
                            {
                                string s = label11.Text;

                                extend = s.Split(',');

                            }
                         
                            foreach (string ss in extend)
                            {
                                file_extend += ss;
                                if (file.EndsWith(ss))
                                {
                                    ReplaceInFile(file, findtext.Text.Trim(), replacetext.Text.Trim());
                                    fileList.Items.Add(file);
                                }

                            }



                        }
                    }

                 
                  
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            else
            {
                MessageBox.Show("路径不能为空！！！");
            }

      
        }

        private void cmb_extension_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb != null && cmb.SelectedIndex >= 0)
            {
                file_extend = cmb.SelectedItem.ToString();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (search_thread != null)
            {
                try
                {
                    if (search_thread.ThreadState == ThreadState.Suspended)
                    {
                        search_thread.Resume();
                        while (search_thread.ThreadState != ThreadState.Running)
                        {

                        }
                    }

                    search_thread.Abort();

                    search_thread.Join();

                    search_thread = null;

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (search_thread != null)
            {
                try
                {
                    if (search_thread.ThreadState == ThreadState.Suspended)
                    {
                        search_thread.Resume();
                        while (search_thread.ThreadState != ThreadState.Running)
                        {

                        
                        }

                    }
                    search_thread.Abort();
                    search_thread.Join();
                    search_thread = null;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

        }


        public void ReadDefaultSkin()
        {



        }
        // public List lb = new List(); //list的初始化
        Form form2 = new Form();
        private void opencheckBox_Click(object sender, EventArgs e)
        {

            //SrcToReplace._1sss ss = new _1sss();
            //ss.Show();
             form2 = new Form();

            form2.Name = "form2";
            form2.Width = 500;
            form2.Height = 200;
            form2.Text = "请选择搜索替换的文件类型";
            CheckedListBox list = new CheckedListBox();
            list.Name = "CheckedListBoxlist";
            string[] extend = new string[] { ".css", ".aspx", ".cs" ,".html",".shtml"};
        
            List<MyItem> items = new List<MyItem>();
            list.Items.Clear();

            for (int i = 0; i < extend.Length; i++)
            {



                MyItem item = new MyItem();


                item.Text = extend[i];
                item.Value = i.ToString();
                items.Add(item);



            }
            MainMenu mm = new MainMenu();
            list.DisplayMember = "Text";        //显示   
            list.ValueMember = "Value";        //值   
            list.DataSource = items;
            list.Name = "CheckBox";
            list.Top = 50;
            list.Left = 50;
            list.HorizontalScrollbar = true;
            list.CheckOnClick = true;
            form2.Controls.Add(list);



            Button bt = new Button();
            bt.Text = "确定添加";
            bt.BackColor = Color.Red;
            bt.Visible = true;
            bt.Enabled = true;
            bt.Width = 70;
            bt.Height = 30;
            bt.Left = 200;
            bt.Top = 100;
            bt.Click += new EventHandler(picStart_Click);
            form2.Controls.Add(bt);
            
            form2.Show();
        }





        void picStart_Click(object sender, EventArgs e)
        {
      

            CheckedListBox cl = (CheckedListBox)form2.Controls[0];
            int j = 0;
  
           

            List<string> list = new List<string>();
            for (int i = 0; i < cl.Items.Count; i++)
            {
                

                if(cl.GetItemChecked(i))
                {
                    j++;
                    cl.SetSelected(i,true);
                    list.Add(cl.Text);
                }

            }

            if (j<= 0)
            {
                MessageBox.Show("请您选择搜索的文件类型！！");
                return;
            }
            DialogResult dr; 
            dr = MessageBox.Show("是否保存当前的选项? ", "提示框 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
            if (dr == DialogResult.Yes)
            {
             //   MessageBox.Show("12312");
                  string ssss="";
                string[] str=list.ToArray();
                if (str.Length >= 2)
                {
                    for (int q = 0; q < list.ToArray().Length - 1; q++)
                    {

                        ssss =ssss+ str[q] + ",";

                    }
                    ssss = ssss + str[str.Length-1];
                }
                else
                { 
                
                ssss=str[0];
                }

              
                label11.Text = ssss;
                // 用 TXT 文件的方式 来保存
                Remind(ssss);
                form2.Close();

            }
            else if(dr==DialogResult.No)
            {
                string ssss="";
                string[] str=list.ToArray();
                if (str.Length >= 2)
                {
                    for (int q = 0; q < list.ToArray().Length - 1; q++)
                    {

                        ssss =ssss+ str[q] + ",";

                    }
                    ssss = ssss + str[str.Length-1];
                }
                else
                { 
                
                ssss=str[0];
                }

              
                label11.Text = ssss;
                form2.Close();
            }

         

          
        }

         void Remind(string str)
        {
            
            StreamWriter writer = null;
            StreamReader reader=null;
            try
            {
             
              
              
               if (File.Exists("Remind.txt"))
                  {
                      writer = new StreamWriter("Remind.txt", true, Encoding.Default);
                      writer.WriteLine(str);
                    
                  
                  }
               
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }
            }
        }

        string ReadTxt()
        {
            string str="";
            try
            {
              
                StreamReader reader = new StreamReader("Remind.txt");

                string[] srr = System.IO.File.ReadAllLines("Remind.txt");
                str = srr[srr.Length - 1];

                reader.Close();
                return str;
            }
            catch
            {
                return null;
            }
        }

        void writeXML(string replacetext,string searchtext)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Replay.xml");
            XmlNode root = xmlDoc.SelectSingleNode("Text");//查找 
            XmlElement xe1 = xmlDoc.CreateElement("itext");//创建一个节点 
           
            xe1.SetAttribute("searchtext", searchtext);
            xe1.SetAttribute("replacetext", replacetext);

            root.AppendChild(xe1);
            

            xmlDoc.Save("Replay.xml");


       }


    }


}


