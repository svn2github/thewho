using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserLogin
    /// </summary>
    public class UserLogin
    {	
        //[主键] 
        private Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //[备注：登录UID] 
        private Int32 _UID;
        public Int32 UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        //[备注：登录帐号] 
        private String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        //[备注：登录时间] 
        private System.DateTime _LoginTime;
        public System.DateTime LoginTime
        {
            get { return _LoginTime; }
            set { _LoginTime = value; }
        }
        //[备注：登录IP] 
        private String _LoginIp;
        public String LoginIp
        {
            get { return _LoginIp; }
            set { _LoginIp = value; }
        }
        //[默认值：0] [备注：登录结果/0为失败(默认),1为成功] 
        private System.Byte _Result;
        public System.Byte Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        
    }
}
