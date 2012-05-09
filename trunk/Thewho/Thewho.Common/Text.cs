using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Common
{
    public class Text
    {
        #region 随机字符

        /// <summary>
        /// 生成一个指定位数的随即字符串 / 字符组为：0-9的数字和a-z(A-Z)的英文字母
        /// </summary>
        /// <param name="strCount">位数</param>
        /// <returns></returns>
        public static String GetRandomStr(int strCount)
        {
           string randomStr = null;
           string framerStr = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
           Random r = new Random();
           for (int i = 0; i < strCount; i++)
           {
               randomStr += framerStr[r.Next(framerStr.Length)];
           }
           return randomStr;
        }

        /// <summary>
        /// 生成一个指定位数的随即字符串 / 字符组可自定义
        /// </summary>
        /// <param name="strCount">位数</param>
        /// <param name="framerStr">自定义备用字符组</param>
        /// <returns></returns>
        public static String GetRandomStr(int strCount, string framerStr)
        {
            string randomStr = null;
            Random r = new Random();
            for (int i = 0; i < strCount; i++)
            {
                randomStr += framerStr[r.Next(framerStr.Length)];
            }
            return randomStr;
        }
        #endregion
    }
}
