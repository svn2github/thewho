using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// Permission（模型层）
    /// </summary>
    public class Permission
    {	
        
        private Int32 _PermissionID;
        /// <summary>
        /// [主键] [自增长] [备注：权限ID/主键/自增长] 
        /// </summary>
        public Int32 PermissionID
        {
            get { return _PermissionID; }
            set { _PermissionID = value; }
        }
        
        private Int32 _JoinID;
        /// <summary>
        /// [备注：拥有权限的对象ID/可以是用户对象,也可以是用户组对象] 
        /// </summary>
        public Int32 JoinID
        {
            get { return _JoinID; }
            set { _JoinID = value; }
        }
        
        private System.Byte _JoinType;
        /// <summary>
        /// [默认值：1] [备注：拥有权限的对象类型/1是用户,2是用户组] 
        /// </summary>
        public System.Byte JoinType
        {
            get { return _JoinType; }
            set { _JoinType = value; }
        }
        
        private Int32 _FunctionID;
        /// <summary>
        /// [备注：功能ID] 
        /// </summary>
        public Int32 FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }
        
        private System.Byte _PermissionType;
        /// <summary>
        /// [默认值：1] [备注：权限类型/0是屏蔽拥有该功能权限 1是拥有权限] 
        /// </summary>
        public System.Byte PermissionType
        {
            get { return _PermissionType; }
            set { _PermissionType = value; }
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
        /// [备注：权限状态/0为未启用,1为启用(默认),2为停用] 
        /// </summary>
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
