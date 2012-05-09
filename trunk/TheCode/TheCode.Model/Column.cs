using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCode.Model
{
    /// <summary>
    /// 列 模型层
    /// </summary>
    public class Column
    {
        /// <summary>
        /// 列名
        /// </summary>
        private string _columnName;

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// 表名
        /// </summary>
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        /// <summary>
        /// 是否是主键 0 -> false:不是, 1 - > true :是主键
        /// </summary>
        private string _isPk;

        public string IsPk
        {
            get { return _isPk; }
            set { _isPk = value; }
        }

        /// <summary>
        /// 是否是自增长标识 0 -> false:不是, 1 - > true :是主键
        /// </summary>
        private string _isIdentity;

        public string IsIdentity
        {
            get { return _isIdentity; }
            set { _isIdentity = value; }
        }

        /// <summary>
        /// 是否可为空 0 -> false:不可为空, 1 - > true :可为空
        /// </summary>
        private string _isNull;

        public string IsNull
        {
            get { return _isNull; }
            set { _isNull = value; }
        }

        /// <summary>
        /// 默认值
        /// </summary>
        private string _defaultValue;


        public string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        private string _columnType;


        public string ColumnType
        {
            get { return _columnType; }
            set { _columnType = value; }
        }

        /// <summary>
        /// 数据库Obj的转型方法 如 Convert.ToInt32
        /// </summary>
        private string _convertStr;

        public string ConvertStr
        {
            get { return _convertStr; }
            set { _convertStr = value; }
        }

        /// <summary>
        /// 字节
        /// </summary>
        private string _columnByte;

        public string ColumnByte
        {
            get { return _columnByte; }
            set { _columnByte = value; }
        }

        /// <summary>
        /// 长度
        /// </summary>
        private string _columnLength;

        public string ColumnLength
        {
            get { return _columnLength; }
            set { _columnLength = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string _columnRemark;

        public string ColumnRemark
        {
            get { return _columnRemark; }
            set { _columnRemark = value; }
        }
        
    }
}
