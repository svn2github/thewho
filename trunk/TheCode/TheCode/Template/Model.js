using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ${NameSpace}$
{
    /// <summary>
    /// ${TableName}$
    /// </summary>
    public class ${TableName}$
    {	
    
        private const string _SQL_INSERT = "INSERT INTO ${TableName}$ ${ForStar:[ALL],[,]}$ ${ColumnName}$ ${ForEnd}$ VALUES(${ForStar:[ALL],[,]}$@${ColumnName}$ ${ForEnd}$) ";
         //--------------------------------------------------------------------------------------------------
         //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		         ${ForStar:[ALL],[,]}new SqlParameter("@${ColumnName}$",obj.${ColumnName}$)${ForEnd}$
		    };		
         
         
        //--------------------------------------------------------------------------------------------------
        ${ForStar:[ALL]}$//${IsPk}$${IsIdentity}$${IsNull}$${DefaultValue}$${ColumnRemark}$
        private ${ColumnType}$ _${ColumnName}$;
        public ${ColumnType}$ ${ColumnName}$
        {
            get { return _${ColumnName}$; }
            set { _${ColumnName}$ = value; }
        }
        ${ForEnd}$
    }
}