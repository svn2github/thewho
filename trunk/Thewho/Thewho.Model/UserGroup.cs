using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// UserGroup
    /// </summary>
    public class UserGroup
    {	
        //[主键] [自增长] 
        private Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //[备注：用户组名] 
        private String _GroupName;
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        //[默认值：0] [备注：用户组上级组ID/顶级组为0(默认)] 
        private Int32 _FID;
        public Int32 FID
        {
            get { return _FID; }
            set { _FID = value; }
        }
        //[备注：创建时间] 
        private System.DateTime _AddTime;
        public System.DateTime AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }
        //[默认值：1] [备注：用户组状态/0为未启用,1为启用(默认),-1为停用] 
        private System.Byte _Status;
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
