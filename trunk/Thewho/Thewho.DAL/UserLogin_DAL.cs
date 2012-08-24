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
    /// UserLogin_DAL（数据层）
    /// </summary>
    public class UserLogin_DAL
    {
        #region 常量
        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO [UserLogin] ([UserID],[Email],[LoginTime],[HostName],[HostAddress],[Remark],[Result]) VALUES(@UserID,@Email,@LoginTime,@HostName,@HostAddress,@Remark,@Result)";
        private const string _SQL_INSERT_RETURNID = "INSERT INTO [UserLogin] [UserID],[Email],[LoginTime],[HostName],[HostAddress],[Remark],[Result] VALUES(@UserID,@Email,@LoginTime,@HostName,@HostAddress,@Remark,@Result); SELECT SCOPE_IDENTITY()";
        private const string _SQL_DELETE = "DELETE FROM [UserLogin] {0}";
        private const string _SQL_UPDATE = "UPDATE [UserLogin] SET [UserID] = @UserID,[Email] = @Email,[LoginTime] = @LoginTime,[HostName] = @HostName,[HostAddress] = @HostAddress,[Remark] = @Remark,[Result] = @Result {0}";
        private const string _SQL_SELECT = "SELECT [ID],[UserID],[Email],[LoginTime],[HostName],[HostAddress],[Remark],[Result] FROM [UserLogin] {0}";
        private const string _SQL_SELECT_LIST = "SELECT [ID],[UserID],[Email],[LoginTime],[HostName],[HostAddress],[Remark],[Result] FROM [UserLogin] {0}";
        //SQL语句 - 分页
        private const string _SQL_SELECT_PAGING = "SELECT [ID],[UserID],[Email],[LoginTime],[HostName],[HostAddress],[Remark],[Result] FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS ROWNUM,[ID],[UserID],[Email],[LoginTime],[HostName],[HostAddress],[Remark],[Result] FROM [UserLogin] {1}) AS T WHERE ROWNUM BETWEEN (@PageIndex-1) * @PageSize + 1 AND (@PageIndex * @PageSize)"; 
        private const string _SQL_SELECT_COUNT = "SELECT COUNT([ID]) FROM [UserLogin] {0}"; 
        #endregion
        
        #region 插入数据
        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="UserLogin">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Insert(UserLogin obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@UserID",obj.UserID),
		        new SqlParameter("@Email",obj.Email),
		        new SqlParameter("@LoginTime",obj.LoginTime),
		        new SqlParameter("@HostName",obj.HostName),
		        new SqlParameter("@HostAddress",obj.HostAddress),
		        new SqlParameter("@Remark",obj.Remark),
		        new SqlParameter("@Result",obj.Result)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, _SQL_INSERT, CommandType.Text, param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID
	    /// </summary>
	    /// <param name="UserLogin">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public Object InsertReturnID(UserLogin obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@UserID",obj.UserID),
		        new SqlParameter("@Email",obj.Email),
		        new SqlParameter("@LoginTime",obj.LoginTime),
		        new SqlParameter("@HostName",obj.HostName),
		        new SqlParameter("@HostAddress",obj.HostAddress),
		        new SqlParameter("@Remark",obj.Remark),
		        new SqlParameter("@Result",obj.Result)
		    };			
    		
		    return SqlHelper.ExecuteScalar(SqlHelper.connectionString, _SQL_INSERT_RETURNID, CommandType.Text, param);
	    }
	    #endregion
	    
	    #region 更新数据
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="UserLogin">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Update(UserLogin obj)
	    {			
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [ID] = @ID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@ID",obj.ID),
		        new SqlParameter("@UserID",obj.UserID),
		        new SqlParameter("@Email",obj.Email),
		        new SqlParameter("@LoginTime",obj.LoginTime),
		        new SqlParameter("@HostName",obj.HostName),
		        new SqlParameter("@HostAddress",obj.HostAddress),
		        new SqlParameter("@Remark",obj.Remark),
		        new SqlParameter("@Result",obj.Result)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
	    #endregion
	    
	    #region 删除数据
	    /// <summary>
	    /// 删除一条数据。
	    /// </summary>
	    /// <param name="ID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete(Int64 ID)
	    {			
	        //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [ID] = @ID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@ID",ID)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
        #endregion
        
        #region 查询单条数据
        /// <summary>
        /// 根据ID获取UserLogin表的一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserLogin SelectObj(Int64 ID)
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT, "WHERE [ID] = @ID");
            //SqlParameter参数数组
            SqlParameter[] param = new SqlParameter[]{		
			    new SqlParameter("@ID",ID)
			};
			
            return ToObject(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, param));
        }
        #endregion
	    
	    #region 查询数据集合
        /// <summary>
        /// 获取UserLogin表的数据（全部）
        /// </summary>
        /// <returns></returns>
        public List<UserLogin> SelectList()
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT_LIST, String.Empty);
        
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, null));
        }
        
        /// <summary>
        /// 获取UserLogin表的数据（分页 按ID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<UserLogin> SelectList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
        {
            String orderStr = "@ID DESC";
            //分页基本参数的参数数组
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@ID","[ID]")
            };

            return Paging(pageIndex, pageSize, orderStr, null, parms, out recordCount);
        }
        #endregion
        
        #region 分页方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 获取UserLogin表的分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderStr">ORDER排序字符串</param>
        /// <param name="whereStr">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        private List<UserLogin> Paging(Int32 pageIndex, Int32 pageSize, String orderStr, String whereStr, SqlParameter[] whereParms, out Int32 recordCount)
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
        /// 根据WHERE条件 计算UserLogin表的数据总数
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
        /// 将SqlDataReader对象转换成UserLogin对象
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private UserLogin ToObject(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserLogin model = new UserLogin();
		                model.ID = Convert.ToInt64(dr["ID"]);
		                model.UserID = Convert.ToInt32(dr["UserID"]);
		                model.Email = dr["Email"].ToString();
		                model.LoginTime = Convert.ToDateTime(dr["LoginTime"]);
		                model.HostName = dr["HostName"].ToString();
		                model.HostAddress = dr["HostAddress"].ToString();
		                model.Remark = dr["Remark"].ToString();
		                model.Result = Convert.ToByte(dr["Result"]);
		                
		                return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 将SqlDataReader对象转换成UserLogin对象集合
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private List<UserLogin> ToList(SqlDataReader dr)
        {
            List<UserLogin> list = null;
            using (dr)
            {
                if (dr.HasRows)
                {
                    list = new List<UserLogin>();
                    while (dr.Read())
                    {
                        UserLogin model = new UserLogin();
		                model.ID = Convert.ToInt64(dr["ID"]);
		                model.UserID = Convert.ToInt32(dr["UserID"]);
		                model.Email = dr["Email"].ToString();
		                model.LoginTime = Convert.ToDateTime(dr["LoginTime"]);
		                model.HostName = dr["HostName"].ToString();
		                model.HostAddress = dr["HostAddress"].ToString();
		                model.Remark = dr["Remark"].ToString();
		                model.Result = Convert.ToByte(dr["Result"]);
		                
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
