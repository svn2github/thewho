using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TheCode.Common
{
    /// <summary>
    /// 文件读写类
    /// </summary>
    public class IO
    {
        public static string ReadFile(string path)
        {
            return File.ReadAllText(System.IO.Path.GetFullPath(path));
        }
        public static void WriteFile(string path, string fileName, string content)
        {
            //如果文件夹不存在
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path); 
            }
            StreamWriter sw = File.CreateText(path + "\\" + fileName + ".cs");
            //sw.Write(content);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close(); 
            //File.AppendAllText(path + "\\" + fileName + ".cs", content, UTF8Encoding.UTF8);
        }

    }
}
