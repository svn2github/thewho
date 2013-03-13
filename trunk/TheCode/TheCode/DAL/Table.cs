using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TheCode.DAL
{
    public class Table
    {
        public string SQL_SELECT = "select [name] as TableName from sys.tables";
        public string SQL_SELECT_PK = "select column_name as pk from information_schema.key_column_usage where constraint_name like 'pk%' and table_name = '{0}'"; //主键
        public string SQL_SELECT_FK = "select column_name as pk from information_schema.key_column_usage where constraint_name like 'fk%' and table_name = '{0}'"; //外键
        public string PkName = "";
        public TheCode.Model.Table GetObj(SqlDataReader dr)
        {
            TheCode.Model.Table obj = new TheCode.Model.Table();
            obj.TableName = dr["TableName"].ToString();
            return obj;
        }

        public List<TheCode.Model.Table> GetList(string connStr, string DatabaseName)
        {
            List<TheCode.Model.Table> list = new List<TheCode.Model.Table>();
            //SqlParameter[] _parms = new SqlParameter[]{
            //    new SqlParameter("@DatabaseName",DatabaseName)
            //};
            SQL_SELECT = "use " + DatabaseName + " " + SQL_SELECT;
            using (SqlDataReader dr = TheCode.Common.SqlHelper.ExecuteReader(connStr, CommandType.Text, SQL_SELECT, null))
            {
                while (dr.Read())
                {
                    list.Add(GetObj(dr));
                }
            }
            return list;
        }

        public string GetPk(string connStr, string TableName)
        {
            SQL_SELECT_PK = String.Format(SQL_SELECT_PK,TableName);
            PkName = TheCode.Common.SqlHelper.ExecuteScalar(connStr, CommandType.Text, SQL_SELECT, null).ToString();
            return PkName;
        }
    }
}
