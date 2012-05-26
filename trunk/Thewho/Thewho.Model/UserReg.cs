using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserReg
    /// </summary>
    public class UserReg
    {	
        //[主键] [备注：用户UID] 
        private Int32 _UID;
        public Int32 UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        //[备注：用户Email] 
        private String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        //[备注：用户密码/已加密] 
        private String _Password;
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        //[备注：加密盐值/随机字符串] 
        private String _Salt;
        public String Salt
        {
            get { return _Salt; }
            set { _Salt = value; }
        }
        
    }
}
