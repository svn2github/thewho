using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// Function（模型层）
    /// </summary>
    public class Function
    {	
        
        private Int32 _FunctionID;
        /// <summary>
        /// [主键] [自增长] [备注：功能ID/主键/自增长] 
        /// </summary>
        public Int32 FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }
        
        private String _FunctionName;
        /// <summary>
        /// [备注：功能名称] 
        /// </summary>
        public String FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
        }
        
        private String _FunctionUrl;
        /// <summary>
        /// [备注：功能页面地址] 
        /// </summary>
        public String FunctionUrl
        {
            get { return _FunctionUrl; }
            set { _FunctionUrl = value; }
        }
        
        private System.Byte _FunctionType;
        /// <summary>
        /// [备注：功能类型/0为处理页面(不在导航显示),1为展示页面(在导航显示),2为文件夹] 
        /// </summary>
        public System.Byte FunctionType
        {
            get { return _FunctionType; }
            set { _FunctionType = value; }
        }
        
        private Int32 _ParentID;
        /// <summary>
        /// [备注：功能上级ID/顶级功能为0] 
        /// </summary>
        public Int32 ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        
        private System.DateTime _AddTime;
        /// <summary>
        /// [默认值：getdate] [备注：功能创建时间] 
        /// </summary>
        public System.DateTime AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }
        
        private System.Byte _Status;
        /// <summary>
        /// [备注：功能状态/0为未启用, 1为启用(默认),2为停用] 
        /// </summary>
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
    }
}
