using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserInfo
    /// </summary>
    public class UserInfo
    {	
        //[主键] [自增长] [备注：用户UID/主键/自增长] 
        private Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //[备注：用户姓名] 
        private String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        //[备注：用户Email/唯一/登录用] 
        private String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        //[备注：用户组ID] 
        private Int32 _GroupID;
        public Int32 GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        //[默认值：1] [备注：用户性别/0为女, 1为男(默认)] 
        private System.Byte _Sex;
        public System.Byte Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        //[备注：用户出生日期] 
        private System.DateTime _Birthday;
        public System.DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }
        //[备注：用户注册时IP] 
        private String _RegIp;
        public String RegIp
        {
            get { return _RegIp; }
            set { _RegIp = value; }
        }
        //[备注：用户注册时时间] 
        private System.DateTime _RegTime;
        public System.DateTime RegTime
        {
            get { return _RegTime; }
            set { _RegTime = value; }
        }
        //[默认值：1] [备注：用户状态/0为未启用,1为启用(默认),-1为停用] 
        private System.Byte _Status;
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
