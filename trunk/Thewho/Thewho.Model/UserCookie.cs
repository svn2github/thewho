using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserCookie
    /// </summary>
    public class UserCookie
    {	
        //[主键] 
        private Int32 _UID;
        public Int32 UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        //
        private String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        //
        private String _Password;
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        //
        private String _Salt;
        public String Salt
        {
            get { return _Salt; }
            set { _Salt = value; }
        }
        //
        private System.DateTime _OutTime;
        public System.DateTime OutTime
        {
            get { return _OutTime; }
            set { _OutTime = value; }
        }
        
    }
}
