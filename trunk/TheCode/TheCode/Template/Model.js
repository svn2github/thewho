using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ${NameSpace}$
{
    /// <summary>
    /// ${Model_ClassName}$（模型层）
    /// </summary>
    public class ${Model_ClassName}$
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
/* 本类由 TheCode v1.2 自动生成 */