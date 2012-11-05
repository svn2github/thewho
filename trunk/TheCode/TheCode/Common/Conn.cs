using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

//using System.Reflection;
//using System.Collections;

namespace TheCode.Common
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class Conn
    {

        public static string connStringByWindows = "Data Source={0};Initial Catalog=master;Integrated Security=True";
        public static string connStringBySqlserver = "Data Source={0};Initial Catalog=master;User ID={1};Password={2}";

        public static string GetDatabasesStr = "SELECT * FROM SYS.databases";
        public static string GetTablesStr = "SELECT * FROM SYS.TABLES";
        
        /// <summary>
        /// 测试数据库连接字符串
        /// </summary>
        /// <param name="server">服务器名称（本地默认是.）</param>
        /// <param name="verifytype">身份验证方式</param>
        /// <param name="user">登录名</param>
        /// <param name="password">密码</param>
        /// <returns>失败返回null 成功返回string</returns>
        public static string IsConnectionStr(string server,string verify,string user,string password)
        {
            string connString = "";
            if (verify == "Windows 身份验证") //Windows 身份验证
            {
                connString = string.Format(connStringByWindows, server);
            }
            else if (verify == "SQL Server 身份验证")
	        {
                connString = string.Format(connStringBySqlserver, server, user, password);
	        }
            if (GetConnection(connString) != null)
            {
                return connString;
            }
            return null;
        }

        /// <summary>
        /// 创建数据库连接对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection(string connstr)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                conn.Open();
            }
            catch (System.Data.Common.DbException ex)
            {
                conn = null;
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return conn;
        }
    }
}
