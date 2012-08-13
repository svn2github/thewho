using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Thewho.Common;
using ${Model_NameSpace}$;

namespace ${DAL_NameSpace}$
{
    /// <summary>
    /// ${DAL_ClassName}$（数据层）
    /// </summary>
    public class ${DAL_ClassName}$
    {
        #region 常量
        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO [${TableName}$] (${ForStar[ALL_NOT_ID][,]}$[${ColumnName}$],${ForEnd}$) VALUES(${ForStar[ALL_NOT_ID][,]}$@${ColumnName}$,${ForEnd}$)";
        private const string _SQL_INSERT_RETURNID = "INSERT INTO [${TableName}$] ${ForStar[ALL_NOT_ID][,]}$[${ColumnName}$],${ForEnd}$ VALUES(${ForStar[ALL_NOT_ID][,]}$@${ColumnName}$,${ForEnd}$); SELECT SCOPE_IDENTITY()";
        private const string _SQL_DELETE = "DELETE FROM [${TableName}$] {0}";
        private const string _SQL_UPDATE = "UPDATE [${TableName}$] SET ${ForStar[ALL_NOT_ID][,]}$[${ColumnName}$] = @${ColumnName}$,${ForEnd}$ {0}";
        private const string _SQL_SELECT = "SELECT ${ForStar[ALL][,]}$[${ColumnName}$],${ForEnd}$ FROM [${TableName}$] {0}";
        private const string _SQL_SELECT_LIST = "SELECT ${ForStar[ALL][,]}$[${ColumnName}$],${ForEnd}$ FROM [${TableName}$] {0}";
        //SQL语句 - 分页
        private const string _SQL_SELECT_PAGING = "SELECT ${ForStar[ALL][,]}$[${ColumnName}$],${ForEnd}$ FROM (SELECT ROW_NUMBER() OVER(ORDER BY @OrderID @OrderType) AS ROWNUM,${ForStar[ALL][,]}$[${ColumnName}$],${ForEnd}$ FROM ${TableName}$ {0}) AS T WHERE ROWNUM BETWEEN (@PageIndex-1) * @PageSize + 1 AND (@PageIndex * @PageSize)"; 
        private const string _SQL_SELECT_COUNT = "SELECT COUNT([${PK_Name}$]) FROM ${TableName}$ {0}"; 
        #endregion
        
        #region 变量
        //最终SQL语句
        private string str; 
        #endregion
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public ${DAL_ClassName}$()
        { 
        }
        
        #region 插入数据
        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="${Model_ClassName}$">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Insert(${Model_ClassName}$ obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        ${ForStar[ALL_NOT_ID][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$),
		        ${ForEnd}$
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, _SQL_INSERT, CommandType.Text, param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回${PK_Name}$
	    /// </summary>
	    /// <param name="${Model_ClassName}$">需要插入的对象</param>
	    /// <returns>新插入数据的${PK_Name}$</returns>
 	    public Object InsertReturnID(${Model_ClassName}$ obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        ${ForStar[ALL_NOT_ID][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$),
		        ${ForEnd}$
		    };			
    		
		    return SqlHelper.ExecuteScalar(SqlHelper.connectionString, _SQL_INSERT_RETURNID, CommandType.Text, param);
	    }
	    #endregion
	    
	    #region 更新数据
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="${Model_ClassName}$">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Update(${Model_ClassName}$ obj)
	    {			
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_UPDATE, "WHERE [${PK_Name}$] = @${PK_Name}$");
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        ${ForStar[ALL][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$),
		        ${ForEnd}$
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, str, CommandType.Text, param);	
	    }
	    #endregion
	    
	    #region 删除数据
	    /// <summary>
	    /// 删除一条数据。
	    /// </summary>
	    /// <param name="${PK_Name}$">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete(${PK_Type}$ ${PK_Name}$)
	    {			
	        //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_UPDATE, "WHERE [${PK_Name}$] = @${PK_Name}$");
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        new SqlParameter("@${PK_Name}$",${PK_Name}$)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, str, CommandType.Text, param);	
	    }
        #endregion
        
        #region 查询单条数据
        /// <summary>
        /// 根据${PK_Name}$获取${TableName}$表的一条数据
        /// </summary>
        /// <param name="${PK_Name}$"></param>
        /// <returns></returns>
        public ${Model_ClassName}$ SelectObj(${PK_Type}$ ${PK_Name}$)
        {
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_SELECT, "WHERE [${PK_Name}$] = @${PK_Name}$");
            //SqlParameter参数数组
            SqlParameter[] param={		
			    new SqlParameter("@${PK_Name}$",${PK_Name}$)
			};	
            return ToObject(SqlHelper.ExecuteReader(SqlHelper.connectionString, str, CommandType.Text, param));
        }
        #endregion
	    
	    #region 查询数据集合
        /// <summary>
        /// 获取${TableName}$表的所有数据
        /// </summary>
        /// <returns></returns>
        public List<${Model_ClassName}$> SelectList()
        {
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_SELECT_LIST, String.Empty);
        
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, str, CommandType.Text, null));
        }
        #endregion
        
        #region 分页方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 获取${TableName}$表的分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderID">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="strWhere">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        private List<${Model_ClassName}$> Paging(int pageIndex, int pageSize, string orderID, string orderType, string whereStr, SqlParameter[] whereParms, out int recordCount)
        {
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_SELECT_PAGING, whereStr);
            //分页基本参数的参数数组
            SqlParameter[] baseParms = new SqlParameter[]{
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@OrderID",orderID),
                new SqlParameter("@OrderType",orderType)
            };
            
            //获取总数
            recordCount = Count(whereStr, whereParms);
            
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, str, CommandType.Text, baseParms, whereParms));
        }
        
        /// <summary>
        /// 根据WHERE条件 计算${TableName}$表的数据总数
        /// </summary>
        /// <param name="strWhere">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <returns>数据总数</returns>
        private Int32 Count(string whereStr, SqlParameter[] whereParms)
        {
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_SELECT_COUNT, whereStr);
            
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.connectionString, str, CommandType.Text, whereParms));
        }
        #endregion
        
        #region 转换方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 将SqlDataReader对象转换成${Model_ClassName}$对象
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private ${Model_ClassName}$ ToObject(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        ${Model_ClassName}$ model = new ${Model_ClassName}$();
		                ${ForStar[ALL]}$model.${ColumnName}$ = ${ConvertTo[dr["${ColumnName}$"]]}$;
		                ${ForEnd}$
		                return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 将SqlDataReader对象转换成${Model_ClassName}$对象集合
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private List<${Model_ClassName}$> ToList(SqlDataReader dr)
        {
            List<${Model_ClassName}$> list = null;
            using (dr)
            {
                if (dr.HasRows)
                {
                    list = new List<${Model_ClassName}$>();
                    if (dr.Read())
                    {
                        ${Model_ClassName}$ model = new ${Model_ClassName}$();
		                ${ForStar[ALL]}$model.${ColumnName}$ = ${ConvertTo[dr["${ColumnName}$"]]}$;
		                ${ForEnd}$
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        #endregion
    }
}