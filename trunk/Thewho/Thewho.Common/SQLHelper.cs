using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Thewho.Common
{
    public sealed class SqlHelper
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["Thewho"].ConnectionString;
        //public static readonly string connectionString = ConfigurationManager.ConnectionStrings["Thewho"].ConnectionString;

        #region ExecuteNonQuery
        /// <summary>
        /// 执行指定的SQL语句/存储过程 返回影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandText">需要执行的SQL语句或者存储过程名称</param>
        /// <param name="commandType">命令类型/SQL语句，存储过程或者其他</param>
        /// <param name="commandParameters">SqlParameters参数数组/可为null</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType, SqlParameter[] commandParameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = CreateCommand(sqlConn, commandText, commandType, null, commandParameters);
                int r = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return r;
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行指定的SQL语句/存储过程 返回SqlDataReader读取器
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandText">需要执行的SQL语句或者存储过程名称</param>
        /// <param name="commandType">命令类型/SQL语句，存储过程或者其他</param>
        /// <param name="commandParameters">SqlParameters参数数组/可为null</param>
        /// <returns>SqlDataReader读取器</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType, SqlParameter[] commandParameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = CreateCommand(sqlConn, commandText, commandType, null, commandParameters);
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return dr;
            }
        }

        /// <summary>
        /// 执行指定的SQL语句/存储过程 返回SqlDataReader读取器
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandText">需要执行的SQL语句或者存储过程名称</param>
        /// <param name="commandType">命令类型/SQL语句，存储过程或者其他</param>
        /// <param name="commandParameters1">第一组SqlParameters参数数组/可为null</param>
        /// <param name="commandParameters2">第二组SqlParameters参数数组/可为null</param>
        /// <returns>SqlDataReader读取器</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType, SqlParameter[] commandParameters1, SqlParameter[] commandParameters2)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = CreateCommand(sqlConn, commandText, commandType, null, commandParameters1, commandParameters2);
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return dr;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行指定的SQL语句/存储过程 返回结果集中的第一行第一列
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandText">需要执行的SQL语句或者存储过程名称</param>
        /// <param name="commandType">命令类型/SQL语句，存储过程或者其他</param>
        /// <param name="commandParameters">SqlParameters参数数组/可为null</param>
        /// <returns>结果集中的第一行第一列</returns>
        public static object ExecuteScalar(string connectionString, string commandText, CommandType commandType, SqlParameter[] commandParameters)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = CreateCommand(sqlConn, commandText, commandType, null, commandParameters);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj;
            }
        }
        #endregion

        #region 创建SqlCommand对象
        /// <summary>
        /// 创建SqlCommand对象
        /// </summary>
        /// <param name="sqlConn">SqlConnection连接对象</param>
        /// <param name="commandText">需要执行的SQL语句或者存储过程名称</param>
        /// <param name="commandType">命令类型/SQL语句，存储过程或者其他</param>
        /// <param name="transaction">事务/可为null</param>
        /// <param name="commandParameters">SqlParameters参数数组/可为null</param>
        /// <returns>SqlCommand对象</returns>
        public static SqlCommand CreateCommand(SqlConnection sqlConn, string commandText, CommandType commandType, SqlTransaction transaction, SqlParameter[] commandParameters)
        {
            if (sqlConn.State != ConnectionState.Open)
            {
                sqlConn.Open();
            }

            SqlCommand cmd = new SqlCommand ();
            cmd.Connection = sqlConn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (transaction != null)
            {
                cmd.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                foreach (SqlParameter item in commandParameters)
                {
                    cmd.Parameters.Add(item);
                }
            }
            
            return cmd;
        }

        /// <summary>
        /// 创建SqlCommand对象
        /// </summary>
        /// <param name="sqlConn">SqlConnection连接对象</param>
        /// <param name="commandText">需要执行的SQL语句或者存储过程名称</param>
        /// <param name="commandType">命令类型/SQL语句，存储过程或者其他</param>
        /// <param name="transaction">事务/可为null</param>
        /// <param name="commandParameters1">第一组SqlParameters参数数组/可为null</param>
        /// <param name="commandParameters2">第二组SqlParameters参数数组/可为null</param>
        /// <returns>SqlCommand对象</returns>
        public static SqlCommand CreateCommand(SqlConnection sqlConn, string commandText, CommandType commandType, SqlTransaction transaction, SqlParameter[] commandParameters1, SqlParameter[] commandParameters2)
        {
            if (sqlConn.State != ConnectionState.Open)
            {
                sqlConn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (transaction != null)
            {
                cmd.Transaction = transaction;
            }

            if (commandParameters1 != null)//第一组参数数组
            {
                foreach (SqlParameter item in commandParameters1)
                {
                    cmd.Parameters.Add(item);
                }
            }
            if (commandParameters2 != null)//第二组参数数组
            {
                foreach (SqlParameter item in commandParameters2)
                {
                    cmd.Parameters.Add(item);
                }
            }

            return cmd;
        }
        #endregion
    }
}
