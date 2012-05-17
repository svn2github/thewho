using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ${Model_NameSpace}$

namespace ${DAL_NameSpace}$
{
    /// <summary>
    /// ${DAL_ClassName}$
    /// </summary>
    public class ${DAL_ClassName}$
    {
        #region 常量
		// 声明静态变量 
		${ForStar[ALL]}$private const string _PARA_${ColumnName}$ = "@${ColumnName}$";
		${ForEnd}$

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO ${TableName}$ ${ForStar[ALL_NOT_PK_ID][,]}$[${ColumnName}$]${ForEnd}$ VALUES(${ForStar[ALL_NOT_PK_ID][,]}$@${ColumnName}$${ForEnd}$) ";        private const string _SQL_DELETE = "DELETE FROM ${TableName}$ WHERE [${PK_Name}$] = @${PK_Name}$";        private const string _SQL_UPDATE = "UPDATE ${TableName}$ SET ${ForStar[ALL_NOT_PK_ID][,]}$[${ColumnName}$] = @${ColumnName}$${ForEnd}$ WHERE [${PK_Name}$] = @${PK_Name}$";        private const string _SQL_SELECT = "SELECT ${TableName}$ SET ${ForStar[ALL][,]}$[${ColumnName}$]${ForEnd}$ FROM ${TableName}$";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public ${DAL_ClassName}$()
        { 
        }

        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="${Model_NameSpace}$.${TableName}$">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public object Insert(${Model_NameSpace}$.${TableName}$ obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        ${ForStar[ALL][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$)
		        ${ForEnd}$
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT, _param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID。
	    /// </summary>
	    /// <param name="${Model_NameSpace}$.${TableName}$">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public object InsertRetID(${Model_NameSpace}$.${TableName}$ obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        ${ForStar[ALL][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$)
		        ${ForEnd}$
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT + "; SELECT SCOPE_IDENTITY()", _param);
	    }
	    
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="${Model_NameSpace}$.${TableName}$">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public int Update(${Model_NameSpace}$.${TableName}$ obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        ${ForStar[ALL][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$)
		        ${ForEnd}$
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_UPDATE, _param);	
	    }
	    
	    /// <summary>
	    /// 删除一条新数据。
	    /// </summary>
	    /// <param name="${PK_Name}$">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public int Delete(${PK_Type}$ ${PK_Name}$)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@${PK_Name}$",${PK_Name}$) 
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_DELETE, _param);	
	    }
	    
	    


        /// <summary>
        /// 根据${PK_Name}$获取${Model_NameSpace}$对象
        /// </summary>
        /// <param name="${PK_Name}$"></param>
        /// <returns></returns>
        public ${Model_NameSpace}$.${TableName}$ SelectObj(${PK_Type}$ ${PK_Name}$)
        {
            ${Model_NameSpace}$.${TableName}$ obj = null;
            SqlParameter[] _param={		
			    new SqlParameter(_PARA_${PK_Name}$,${PK_Name}$)
			};	
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString,CommandType.Text,_SQL_SELECT,_param))
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        obj = ToModel(dr);
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 获取$TableName的所有数据
        /// </summary>
        /// <returns></returns>
        public List<${Model_NameSpace}$.${TableName}$> SelectList()
        {
            List<${Model_NameSpace}$.${TableName}$> list = null;
            ${Model_NameSpace}$.${TableName}$ obj = null;
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, null))
            {
                if (dr.HasRows)
                {
                    list = new List<${Model_NameSpace}$.${TableName}$>();
                    if (dr.Read())
                    {
                        obj = ToModel(dr);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取$TableName的分页数据
        /// </summary>
        /// <param name="PageIndex">页码（第一页传“1”以此类推）</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="OrderID">排序ID</param>
        /// <param name="OrderType">排序类型（desc，asc）</param>
        /// <param name="StrWhere">条件（如“ 1 = 1 and 2 = 2”）</param>
        /// <param name="RecordCount">返回数据总条数（用于计算页数）</param>
        /// <returns></returns>
        public List<${Model_NameSpace}$.${TableName}$> SelectList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            return PagingList(PageIndex, PageSize, OrderID, OrderType, StrWhere, out RecordCount);
        }
        
        #region 转换方法
        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public ${Model_NameSpace}$.${TableName}$ ToModel(IDataReader dr)
        {
            ${Model_NameSpace}$.${TableName}$ model = new ${Model_NameSpace}$.${TableName}$();
		    ${ForStar[ALL]}$model.${ColumnName}$ = ${ConvertTo[dr["${ColumnName}$"]]}$;
		    ${ForEnd}$
            return model;
        }
        #endregion
        
        #region 分页方法
        /// <summary>
        /// $DAL_ClassName 公用分页方法
        /// </summary>
        /// <param name="PageIndex">页码（第一页传“1”以此类推）</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="OrderID">排序ID</param>
        /// <param name="OrderType">排序类型（desc，asc）</param>
        /// <param name="StrWhere">条件（如“ 1 = 1 and 2 = 2”）</param>
        /// <param name="RecordCount">返回数据总条数（用于计算页数）</param>
        /// <returns>作文集合</returns>
        public List<${Model_NameSpace}$.${TableName}$> PagingList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            RecordCount = 0;
            List<${Model_NameSpace}$.${TableName}$> list = new List<${Model_NameSpace}$.${TableName}$>();
            using (SqlDataReader dr = Common.SqlHelper.Paging(Common.SqlHelper.ConnectionString, PageIndex,PageSize, "${TableName}$", "${PK_Name}$", "DESC", StrWhere, out RecordCount))
            {
                try
                {
                    while (dr.Read())
                    {
                        list.Add(ToModel(dr));
                    }
                }
                catch
                {
                    dr.Close();
                }
            }
            return list;
        }
        #endregion
    }
}
