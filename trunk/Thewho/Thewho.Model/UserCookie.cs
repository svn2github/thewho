using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserCookie（模型层）
    /// </summary>
    public class UserCookie
    {	
        
        private Int64 _ID;
        /// <summary>
        /// [主键] [自增长] [备注：ID/主键/自增长] 
        /// </summary>
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        
        private Int32 _UserID;
        /// <summary>
        /// [备注：用户ID] 
        /// </summary>
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        
        private String _HostName;
        /// <summary>
        /// [备注：用户的计算机名] 
        /// </summary>
        public String HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }
        
        private String _HostAddress;
        /// <summary>
        /// [备注：IP地址] 
        /// </summary>
        public String HostAddress
        {
            get { return _HostAddress; }
            set { _HostAddress = value; }
        }
        
        private String _Password;
        /// <summary>
        /// [备注：登录状态密文/32位密文] 
        /// </summary>
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        
        private System.DateTime _AddTime;
        /// <summary>
        /// [默认值：getdate] [备注：Cookie数据生成的时间] 
        /// </summary>
        public System.DateTime AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }
        
    }
}
