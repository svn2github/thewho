using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TheCode.DAL
{
    public class Database
    {
        public string SQL_SELECT = "select [name] as DatabaseName from sys.databases";

        public TheCode.Model.Database GetObj(SqlDataReader dr)
        {
            TheCode.Model.Database obj = new TheCode.Model.Database();
            obj.DatabaseName = dr["DatabaseName"].ToString();
            return obj;
        }

        public List<TheCode.Model.Database> GetList(string connStr)
        {
            List<TheCode.Model.Database> list = new List<TheCode.Model.Database>();
            using (SqlDataReader dr = TheCode.Common.SqlHelper.ExecuteReader(connStr, CommandType.Text, SQL_SELECT, null))
            {
                while (dr.Read())
                {
                    list.Add(GetObj(dr));
                }
            }
            return list;
        }
    }
}
