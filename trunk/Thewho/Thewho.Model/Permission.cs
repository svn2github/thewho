using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// Permission
    /// </summary>
    public class Permission
    {	
        //[主键] [自增长] [备注：权限ID/主键/自增长] 
        private Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //[备注：用户UID] 
        private Int32 _UID;
        public Int32 UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        //[备注：功能ID] 
        private Int32 _FunctionID;
        public Int32 FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }
        //[备注：权限类型] 
        private System.Byte _Type;
        public System.Byte Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        //[备注：权限创建时间] 
        private System.DateTime _Addtime;
        public System.DateTime Addtime
        {
            get { return _Addtime; }
            set { _Addtime = value; }
        }
        //[默认值：1] [备注：权限状态/0为未启用,1为启用(默认),-1为停用] 
        private System.Byte _Status;
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
