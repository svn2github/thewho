using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserGroup（模型层）
    /// </summary>
    public class UserGroup
    {	
        
        private Int32 _GroupID;
        /// <summary>
        /// [主键] [自增长] [备注：用户组ID/主键/自增长] 
        /// </summary>
        public Int32 GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        
        private String _GroupName;
        /// <summary>
        /// [备注：用户组名称] 
        /// </summary>
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        
        private Int32 _ParentID;
        /// <summary>
        /// [默认值：0] [备注：用户组上级组ID/顶级组为0] 
        /// </summary>
        public Int32 ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        
        private System.DateTime _AddTime;
        /// <summary>
        /// [默认值：getdate] [备注：创建时间] 
        /// </summary>
        public System.DateTime AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }
        
        private System.Byte _Status;
        /// <summary>
        /// [备注：用户组状态/0为未启用,1为启用(默认),2为停用] 
        /// </summary>
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
