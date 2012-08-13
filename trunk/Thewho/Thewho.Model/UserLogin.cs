using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserLogin（模型层）
    /// </summary>
    public class UserLogin
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
        /// [备注：用户ID/如果登录的Email没对应任何用户数据, 此处为0] 
        /// </summary>
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        
        private String _Email;
        /// <summary>
        /// [备注：登录的Email] 
        /// </summary>
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        private System.DateTime _LoginTime;
        /// <summary>
        /// [默认值：getdate] [备注：登录时间] 
        /// </summary>
        public System.DateTime LoginTime
        {
            get { return _LoginTime; }
            set { _LoginTime = value; }
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
        
        private String _Remark;
        /// <summary>
        /// [可为空] [备注：备注/记录成功信息,异常或失败原因] 
        /// </summary>
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        
        private System.Byte _Result;
        /// <summary>
        /// [备注：登录结果/0为失败(默认),1为成功,2为异常] 
        /// </summary>
        public System.Byte Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        
    }
}
