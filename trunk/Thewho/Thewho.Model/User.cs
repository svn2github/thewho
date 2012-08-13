using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// User（模型层）
    /// </summary>
    public class User
    {	
        
        private Int32 _UserID;
        /// <summary>
        /// [主键] [自增长] [备注：用户ID/主键/自增长] 
        /// </summary>
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        
        private String _Name;
        /// <summary>
        /// [备注：用户姓名] 
        /// </summary>
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        private String _Email;
        /// <summary>
        /// [备注：用户Email/唯一/登录用] 
        /// </summary>
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        private Int32 _GroupID;
        /// <summary>
        /// [备注：用户组ID] 
        /// </summary>
        public Int32 GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        
        private String _Salt;
        /// <summary>
        /// [备注：用户盐值/随机8位/固定] 
        /// </summary>
        public String Salt
        {
            get { return _Salt; }
            set { _Salt = value; }
        }
        
        private String _Password;
        /// <summary>
        /// [备注：用户密码/32位密文] 
        /// </summary>
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        
        private System.Byte _Status;
        /// <summary>
        /// [默认值：0] [备注：用户状态/0为未启用,1为启用(默认),2为停用] 
        /// </summary>
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
