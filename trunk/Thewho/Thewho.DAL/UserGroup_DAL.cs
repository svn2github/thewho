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
    /// UserGroup_DAL（数据层）
    /// </summary>
    public class UserGroup_DAL
    {
        #region 常量
        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO [UserGroup] ([GroupName],[ParentID],[AddTime],[Status]) VALUES(@GroupName,@ParentID,@AddTime,@Status)";
        private const string _SQL_INSERT_RETURNID = "INSERT INTO [UserGroup] [GroupName],[ParentID],[AddTime],[Status] VALUES(@GroupName,@ParentID,@AddTime,@Status); SELECT SCOPE_IDENTITY()";
        private const string _SQL_DELETE = "DELETE FROM [UserGroup] {0}";
        private const string _SQL_UPDATE = "UPDATE [UserGroup] SET [GroupName] = @GroupName,[ParentID] = @ParentID,[AddTime] = @AddTime,[Status] = @Status {0}";
        private const string _SQL_SELECT = "SELECT [GroupID],[GroupName],[ParentID],[AddTime],[Status] FROM [UserGroup] {0}";
        private const string _SQL_SELECT_LIST = "SELECT [GroupID],[GroupName],[ParentID],[AddTime],[Status] FROM [UserGroup] {0}";
        //SQL语句 - 分页
        private const string _SQL_SELECT_PAGING = "SELECT [GroupID],[GroupName],[ParentID],[AddTime],[Status] FROM (SELECT ROW_NUMBER() OVER(ORDER BY @OrderID @OrderType) AS ROWNUM,[GroupID],[GroupName],[ParentID],[AddTime],[Status] FROM UserGroup {0}) AS T WHERE ROWNUM BETWEEN (@PageIndex-1) * @PageSize + 1 AND (@PageIndex * @PageSize)"; 
        private const string _SQL_SELECT_COUNT = "SELECT COUNT([GroupID]) FROM UserGroup {0}"; 
        #endregion
        
        #region 变量
        //最终SQL语句
        private string str; 
        #endregion
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public UserGroup_DAL()
        { 
        }
        
        #region 插入数据
        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="UserGroup">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Insert(UserGroup obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        new SqlParameter("@GroupName",obj.GroupName),
		        new SqlParameter("@ParentID",obj.ParentID),
		        new SqlParameter("@AddTime",obj.AddTime),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, _SQL_INSERT, CommandType.Text, param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回GroupID
	    /// </summary>
	    /// <param name="UserGroup">需要插入的对象</param>
	    /// <returns>新插入数据的GroupID</returns>
 	    public Object InsertReturnID(UserGroup obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        new SqlParameter("@GroupName",obj.GroupName),
		        new SqlParameter("@ParentID",obj.ParentID),
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
	    /// <param name="UserGroup">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Update(UserGroup obj)
	    {			
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_UPDATE, "WHERE [GroupID] = @GroupID");
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        new SqlParameter("@GroupID",obj.GroupID),
		        new SqlParameter("@GroupName",obj.GroupName),
		        new SqlParameter("@ParentID",obj.ParentID),
		        new SqlParameter("@AddTime",obj.AddTime),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, str, CommandType.Text, param);	
	    }
	    #endregion
	    
	    #region 删除数据
	    /// <summary>
	    /// 删除一条数据。
	    /// </summary>
	    /// <param name="GroupID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete(Int32 GroupID)
	    {			
	        //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_UPDATE, "WHERE [GroupID] = @GroupID");
		    //声明参数数组并赋值
		    SqlParameter[] param=
		    {
		        new SqlParameter("@GroupID",GroupID)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, str, CommandType.Text, param);	
	    }
        #endregion
        
        #region 查询单条数据
        /// <summary>
        /// 根据GroupID获取UserGroup表的一条数据
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public UserGroup SelectObj(Int32 GroupID)
        {
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_SELECT, "WHERE [GroupID] = @GroupID");
            //SqlParameter参数数组
            SqlParameter[] param={		
			    new SqlParameter("@GroupID",GroupID)
			};	
            return ToObject(SqlHelper.ExecuteReader(SqlHelper.connectionString, str, CommandType.Text, param));
        }
        #endregion
	    
	    #region 查询数据集合
        /// <summary>
        /// 获取UserGroup表的所有数据
        /// </summary>
        /// <returns></returns>
        public List<UserGroup> SelectList()
        {
            //将WHERE条件组合进SQL语句
            str = String.Format(_SQL_SELECT_LIST, String.Empty);
        
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, str, CommandType.Text, null));
        }
        #endregion
        
        #region 分页方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 获取UserGroup表的分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderID">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="strWhere">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        private List<UserGroup> Paging(int pageIndex, int pageSize, string orderID, string orderType, string whereStr, SqlParameter[] whereParms, out int recordCount)
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
        /// 根据WHERE条件 计算UserGroup表的数据总数
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
        /// 将SqlDataReader对象转换成UserGroup对象
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private UserGroup ToObject(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        UserGroup model = new UserGroup();
		                model.GroupID = Convert.ToInt32(dr["GroupID"]);
		                model.GroupName = dr["GroupName"].ToString();
		                model.ParentID = Convert.ToInt32(dr["ParentID"]);
		                model.AddTime = Convert.ToDateTime(dr["AddTime"]);
		                model.Status = Convert.ToByte(dr["Status"]);
		                
		                return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 将SqlDataReader对象转换成UserGroup对象集合
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private List<UserGroup> ToList(SqlDataReader dr)
        {
            List<UserGroup> list = null;
            using (dr)
            {
                if (dr.HasRows)
                {
                    list = new List<UserGroup>();
                    if (dr.Read())
                    {
                        UserGroup model = new UserGroup();
		                model.GroupID = Convert.ToInt32(dr["GroupID"]);
		                model.GroupName = dr["GroupName"].ToString();
		                model.ParentID = Convert.ToInt32(dr["ParentID"]);
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
