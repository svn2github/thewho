using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCode.Model
{
    /// <summary>
    /// 表 模型层
    /// </summary>
    public class Table
    {
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
    }
}
