using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ${NameSpace}$
{
    /// <summary>
    /// ${TableName}$（模型层）
    /// </summary>
    public class ${TableName}$
    {	
        ${ForStar:[ALL]}$
        private ${ColumnType}$ _${ColumnName}$;
        /// <summary>
        /// ${IsPk}$${IsIdentity}$${IsNull}$${DefaultValue}$${ColumnRemark}$
        /// </summary>
        public ${ColumnType}$ ${ColumnName}$
        {
            get { return _${ColumnName}$; }
            set { _${ColumnName}$ = value; }
        }
        ${ForEnd}$
    }
}