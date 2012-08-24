using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Thewho.Common;
using Thewho.Model;

namespace Thewho.DAL
{
    /// <summary>
    /// Permission_DAL（数据层）
    /// </summary>
    public class Permission_DAL
    {
        #region 常量
        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO [Permission] ([JoinID],[JoinType],[FunctionID],[PermissionType],[AddTime],[Status]) VALUES(@JoinID,@JoinType,@FunctionID,@PermissionType,@AddTime,@Status)";
        private const string _SQL_INSERT_RETURNID = "INSERT INTO [Permission] [JoinID],[JoinType],[FunctionID],[PermissionType],[AddTime],[Status] VALUES(@JoinID,@JoinType,@FunctionID,@PermissionType,@AddTime,@Status); SELECT SCOPE_IDENTITY()";
        private const string _SQL_DELETE = "DELETE FROM [Permission] {0}";
        private const string _SQL_UPDATE = "UPDATE [Permission] SET [JoinID] = @JoinID,[JoinType] = @JoinType,[FunctionID] = @FunctionID,[PermissionType] = @PermissionType,[AddTime] = @AddTime,[Status] = @Status {0}";
        private const string _SQL_SELECT = "SELECT [PermissionID],[JoinID],[JoinType],[FunctionID],[PermissionType],[AddTime],[Status] FROM [Permission] {0}";
        private const string _SQL_SELECT_LIST = "SELECT [PermissionID],[JoinID],[JoinType],[FunctionID],[PermissionType],[AddTime],[Status] FROM [Permission] {0}";
        //SQL语句 - 分页
        private const string _SQL_SELECT_PAGING = "SELECT [PermissionID],[JoinID],[JoinType],[FunctionID],[PermissionType],[AddTime],[Status] FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS ROWNUM,[PermissionID],[JoinID],[JoinType],[FunctionID],[PermissionType],[AddTime],[Status] FROM [Permission] {1}) AS T WHERE ROWNUM BETWEEN (@PageIndex-1) * @PageSize + 1 AND (@PageIndex * @PageSize)"; 
        private const string _SQL_SELECT_COUNT = "SELECT COUNT([PermissionID]) FROM [Permission] {0}"; 
        #endregion
        
        #region 插入数据
        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="Permission">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Insert(Permission obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@JoinID",obj.JoinID),
		        new SqlParameter("@JoinType",obj.JoinType),
		        new SqlParameter("@FunctionID",obj.FunctionID),
		        new SqlParameter("@PermissionType",obj.PermissionType),
		        new SqlParameter("@AddTime",obj.AddTime),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, _SQL_INSERT, CommandType.Text, param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回PermissionID
	    /// </summary>
	    /// <param name="Permission">需要插入的对象</param>
	    /// <returns>新插入数据的PermissionID</returns>
 	    public Object InsertReturnID(Permission obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@JoinID",obj.JoinID),
		        new SqlParameter("@JoinType",obj.JoinType),
		        new SqlParameter("@FunctionID",obj.FunctionID),
		        new SqlParameter("@PermissionType",obj.PermissionType),
		        new SqlParameter("@AddTime",obj.AddTime),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteScalar(SqlHelper.connectionString, _SQL_INSERT_RETURNID, CommandType.Text, param);
	    }
	    #endregion
	    
	    #region 更新数据
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="Permission">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Update(Permission obj)
	    {			
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [PermissionID] = @PermissionID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@PermissionID",obj.PermissionID),
		        new SqlParameter("@JoinID",obj.JoinID),
		        new SqlParameter("@JoinType",obj.JoinType),
		        new SqlParameter("@FunctionID",obj.FunctionID),
		        new SqlParameter("@PermissionType",obj.PermissionType),
		        new SqlParameter("@AddTime",obj.AddTime),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
	    #endregion
	    
	    #region 删除数据
	    /// <summary>
	    /// 删除一条数据。
	    /// </summary>
	    /// <param name="PermissionID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete(Int32 PermissionID)
	    {			
	        //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [PermissionID] = @PermissionID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@PermissionID",PermissionID)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
        #endregion
        
        #region 查询单条数据
        /// <summary>
        /// 根据PermissionID获取Permission表的一条数据
        /// </summary>
        /// <param name="PermissionID"></param>
        /// <returns></returns>
        public Permission SelectObj(Int32 PermissionID)
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT, "WHERE [PermissionID] = @PermissionID");
            //SqlParameter参数数组
            SqlParameter[] param = new SqlParameter[]{		
			    new SqlParameter("@PermissionID",PermissionID)
			};
			
            return ToObject(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, param));
        }
        #endregion
	    
	    #region 查询数据集合
        /// <summary>
        /// 获取Permission表的数据（全部）
        /// </summary>
        /// <returns></returns>
        public List<Permission> SelectList()
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT_LIST, String.Empty);
        
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, null));
        }
        
        /// <summary>
        /// 获取Permission表的数据（分页 按PermissionID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<Permission> SelectList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
        {
            String orderStr = "@PermissionID DESC";
            //分页基本参数的参数数组
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@PermissionID","[PermissionID]")
            };

            return Paging(pageIndex, pageSize, orderStr, null, parms, out recordCount);
        }
        #endregion
        
        #region 分页方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 获取Permission表的分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderStr">ORDER排序字符串</param>
        /// <param name="whereStr">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        private List<Permission> Paging(Int32 pageIndex, Int32 pageSize, String orderStr, String whereStr, SqlParameter[] whereParms, out Int32 recordCount)
        {
            //将ORDER条件和WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT_PAGING, orderStr, whereStr);
            //分页基本参数的参数数组
            SqlParameter[] pagingParms = new SqlParameter[]{
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize)
            };
            
            //获取总数
            recordCount = Count(whereStr, whereParms);
            
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, pagingParms, whereParms));
        }
        
        /// <summary>
        /// 根据WHERE条件 计算Permission表的数据总数
        /// </summary>
        /// <param name="whereStr">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <returns>数据总数</returns>
        private Int32 Count(String whereStr, SqlParameter[] whereParms)
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT_COUNT, whereStr);
            
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.connectionString, sqlStr, CommandType.Text, whereParms));
        }
        #endregion
        
        #region 转换方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 将SqlDataReader对象转换成Permission对象
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private Permission ToObject(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Permission model = new Permission();
		                model.PermissionID = Convert.ToInt32(dr["PermissionID"]);
		                model.JoinID = Convert.ToInt32(dr["JoinID"]);
		                model.JoinType = Convert.ToByte(dr["JoinType"]);
		                model.FunctionID = Convert.ToInt32(dr["FunctionID"]);
		                model.PermissionType = Convert.ToByte(dr["PermissionType"]);
		                model.AddTime = Convert.ToDateTime(dr["AddTime"]);
		                model.Status = Convert.ToByte(dr["Status"]);
		                
		                return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 将SqlDataReader对象转换成Permission对象集合
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private List<Permission> ToList(SqlDataReader dr)
        {
            List<Permission> list = null;
            using (dr)
            {
                if (dr.HasRows)
                {
                    list = new List<Permission>();
                    while (dr.Read())
                    {
                        Permission model = new Permission();
		                model.PermissionID = Convert.ToInt32(dr["PermissionID"]);
		                model.JoinID = Convert.ToInt32(dr["JoinID"]);
		                model.JoinType = Convert.ToByte(dr["JoinType"]);
		                model.FunctionID = Convert.ToInt32(dr["FunctionID"]);
		                model.PermissionType = Convert.ToByte(dr["PermissionType"]);
		                model.AddTime = Convert.ToDateTime(dr["AddTime"]);
		                model.Status = Convert.ToByte(dr["Status"]);
		                
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
