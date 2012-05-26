using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thewho.Model
{
    /// <summary>
    /// Function
    /// </summary>
    public class Function
    {

        private Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
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


        private Int32 _FID;
        /// <summary>
        /// [默认值：0] [备注：功能上级ID/顶级功能为0(默认)] 
        /// </summary>
        public Int32 FID
        {
            get { return _FID; }
            set { _FID = value; }
        }


        private String _Remark;
        /// <summary>
        /// [备注：功能备注] 
        /// </summary>
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }


        private System.Byte _FunctionType;
        /// <summary>
        /// [备注：功能类型/0为处理页面(不在导航显示),1为展示页面(在导航显示)] 
        /// </summary>
        public System.Byte FunctionType
        {
            get { return _FunctionType; }
            set { _FunctionType = value; }
        }


        private System.DateTime _AddTime;
        /// <summary>
        /// [备注：功能创建时间] 
        /// </summary>
        public System.DateTime AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }


        private System.Byte _Status;
        /// <summary>
        /// [默认值：1] [备注：功能状态/0为未启用, 1为启用(默认),-1为停用] 
        /// </summary>
        public System.Byte Status
        {
            get { return _Status; }
            set { _Status = value; }
        }


    }
}
