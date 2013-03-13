using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TheCode.Common
{
    /// <summary>
    /// 文件读写类
    /// </summary>
    public class IO
    {
        //读出文件内容字符串
        public static string ReadFile(string path)
        {
            return File.ReadAllText(System.IO.Path.GetFullPath(path));
        }
        //创建或者覆盖文件内容
        public static void WriteFile(string path, string fileName, string content)
        {
            //如果文件夹不存在
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            StreamWriter sw = File.CreateText(path + "\\" + fileName);
            //System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding(false);
            //StreamWriter sw = new StreamWriter(path + "\\" + fileName, false, utf8);


            //sw.Write(content);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
            

            //File.AppendAllText(path + "\\" + fileName, content, UTF8Encoding.UTF8);
        }
        //删除文件
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
        //设置文件为隐藏
        public static void SetFileHidden(string path)
        {
            File.SetAttributes(path, System.IO.FileAttributes.Hidden);
        }
        
    }
}
