using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Common
{
    /// <summary>
    /// MD5密文 帮助类
    /// </summary>
    public static class Md5
    {
        /// <summary>
        /// 将一个明文字符串 加密成 32位的MD5密文字符串
        /// </summary>
        /// <param name="str">明文字符串</param>
        /// <returns></returns>
        public static String Encrypt32(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }
        /// <summary>
        /// 将一个明文字符串 加密成 16位的MD5密文字符串
        /// </summary>
        /// <param name="str">明文字符串</param>
        /// <returns></returns>
        public static String Encrypt16(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
        }
    }
}
