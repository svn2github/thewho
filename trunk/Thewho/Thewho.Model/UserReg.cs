using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserReg（模型层）
    /// </summary>
    public class UserReg
    {	
        
        private Int32 _ID;
        /// <summary>
        /// [主键] [自增长] [备注：ID/主键/自增长] 
        /// </summary>
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        
        private Int32 _UserID;
        /// <summary>
        /// [备注：用户ID/主键] 
        /// </summary>
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        
        private String _HostName;
        /// <summary>
        /// [备注：计算机名称] 
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
        
        private System.DateTime _RegTime;
        /// <summary>
        /// [默认值：getdate] [备注：注册时间] 
        /// </summary>
        public System.DateTime RegTime
        {
            get { return _RegTime; }
            set { _RegTime = value; }
        }
        
    }
}
