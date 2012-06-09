using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text.RegularExpressions;
namespace SrcToReplace
{
    public class TextBoxRemind
    {
        private string[] array = null;

        private string[] array2 = null;

        public void InitAutoCompleteCustomSource(TextBox textBox)
        {

            
            List<string> listArr = new List<string>();
            XmlReader reader = null;
            XmlDocument msgDoc = null;
            try
            {
                 reader = new XmlTextReader(Application.StartupPath + @"\Replay.xml");
                //实例化方法 
                 msgDoc = new XmlDocument();
                //读取配置文件信息


                try
                {
                    msgDoc.Load(reader);//加载XML文档
                }
                catch (Exception ex)
                {
                    //读取文件异常
                    string ErrorMessage = ex.Message;

                }
                //逐个读取节点以及属性添加到页面
                XmlNodeList pageList = msgDoc.DocumentElement.ChildNodes;
                DiGuiReadXml(pageList, textBox);




            }

            catch
            {

            }
            finally
            {
                reader.Close();


            }
        }




        string[] ReadTxt()
        {
            try
            {
                if (!File.Exists("Remind.txt"))
                    File.Create("Remind.txt");

                return File.ReadAllLines("Remind.txt", Encoding.Default);
            }
            catch
            {
                return null;
            }
        }


        string[] Readxml(TextBox tx)
        {

            string[] str = null;
            List<string> listArr = new List<string>();
            try
            {
                XmlReader reader = new XmlTextReader(Application.StartupPath + @"\Replay.xml");
                //实例化方法 
                XmlDocument msgDoc = new XmlDocument();
                //读取配置文件信息


                try
                {
                    msgDoc.Load(reader);//加载XML文档
                }
                catch (Exception ex)
                {
                    //读取文件异常
                    string ErrorMessage = ex.Message;

                }
                //逐个读取节点以及属性添加到页面
                XmlNodeList pageList = msgDoc.DocumentElement.ChildNodes;
                DiGuiReadXml(pageList,tx);

                reader.Close();
             
                return listArr.ToArray();

            }
            catch
            {
                return null;
            }
        
        }

        public void Remind(string str)
        {
            StreamWriter writer = null;
            try
            {
                if (array != null && !array.Contains(str))
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


        private void DiGuiReadXml(XmlNodeList xmlnodelist, TextBox tx)
        {
        
            List<string> listArr = new List<string>();
            List<string> listArr2 = new List<string>();
            foreach (XmlNode xmlnode in xmlnodelist)
            {
                for (int j = 0; j < xmlnode.Attributes.Count; j++)
                {
                    //找到需要的数据后进行操作
                    if (xmlnode.Attributes[j].Name == "searchtext")
                    {
                       
                         //   MessageBox.Show(xmlnode.Attributes[j].Value);
                        listArr.Add(xmlnode.Attributes[j].Value);
                    }
                    if (xmlnode.Attributes[j].Name == "replacetext")
                    {
                       
                        //    MessageBox.Show(xmlnode.Attributes[j].Value);
                        listArr2.Add(xmlnode.Attributes[j].Value);

                    }
                }
          
              
            }
          

            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            AutoCompleteStringCollection ACSC2 = new AutoCompleteStringCollection();
            array=listArr.ToArray();
             array2=listArr2.ToArray();
             for (int i = 0; i < array.Length; i++)
            {
                ACSC.Add(array[i]);
            }
             for (int i = 0; i < array2.Length; i++)
            {
                ACSC2.Add(array2[i]);
            }
            if (tx.Name == "findtext")
           {
               tx.AutoCompleteCustomSource = ACSC;
           }
            if (tx.Name == "replacetext")
            {
                tx.AutoCompleteCustomSource = ACSC2;
            }


        }
    }
}
