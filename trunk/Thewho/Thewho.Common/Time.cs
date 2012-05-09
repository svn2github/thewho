using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Common
{
    /// <summary>
    /// 日期时间 帮助类
    /// </summary>
    public class Time
    {

        #region Unix时间戳
        /// <summary>
        /// 将Unix时间戳 转换成 DateTime时间
        /// </summary>
        /// <param name="unix">Unix时间戳</param>
        /// <returns></returns>
        public DateTime ToDateTime(Int32 unix)
        {
            DateTime time = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            Int64 unixNumber = Convert.ToInt64((unix.ToString() + "0000000"));
            TimeSpan toNow = new TimeSpan(unixNumber);
            return time.Add(toNow);
        }

        /// <summary>
        /// 将DateTime时间 转换成 Unix时间戳
        /// </summary>
        /// <param name="time">DataTime时间</param>
        /// <returns></returns>
        public Int32 ToUnix(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return Convert.ToInt32((time - startTime).TotalSeconds);
        }
        #endregion

        public String ToTimeStr(DateTime time)
        {
            TimeSpan ts = DateTime.Now - time;
            int secondNumber = Convert.ToInt32(ts.TotalSeconds);
            string s = "";
            if (ts.TotalSeconds < 60) //小于一分钟
            {
                s = Convert.ToInt32(ts.TotalSeconds) + "秒钟";  
            }
            else if (secondNumber >= 60 && secondNumber < 3600)//大于一分钟
            {
                s = Convert.ToInt32(ts.TotalMinutes) + "分钟";  
            }
            else if (secondNumber >= 3600 && secondNumber < 84600)//大于一小时
            {
                s = Convert.ToInt32(ts.TotalHours) + "小时";  
            }
            else if (secondNumber >= 84600 && secondNumber < 604800)//大于一天
            {
                s = Convert.ToInt32(ts.TotalDays) + "天";  
            }
            else if (secondNumber >= 604800 && secondNumber < 2592000)//大于一周
            {
                s = (Convert.ToInt32(ts.TotalDays) / 7) + "周";  
            }
            else if (secondNumber >= 2592000 && secondNumber < 31104000)//大于一月
            {
                s = (Convert.ToInt32(ts.TotalDays) / 30) + "个月";  
            }
            else if (secondNumber >= 31104000)//大于一年
            {
                s = (Convert.ToInt32(ts.TotalDays) / 365) + "年";  
            }
            else//直接复制时间的ToString字符串
            {

            }
            return s + "前";
        }
    }
}
