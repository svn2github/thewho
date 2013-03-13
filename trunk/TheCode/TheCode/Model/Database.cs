using System;
using System.Collections.Generic;
using System.Text;

namespace TheCode.Model
{
    /// <summary>
    /// 数据库 模型层
    /// </summary>
    public class Database
    {
        private string _databaseName;

        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }
    }
}
