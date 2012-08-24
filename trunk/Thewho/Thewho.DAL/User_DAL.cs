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
    /// User_DAL（数据层）
    /// </summary>
    public class User_DAL
    {
        #region 常量
        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO [User] ([Name],[Email],[GroupID],[Salt],[Password],[Status]) VALUES(@Name,@Email,@GroupID,@Salt,@Password,@Status)";
        private const string _SQL_INSERT_RETURNID = "INSERT INTO [User] [Name],[Email],[GroupID],[Salt],[Password],[Status] VALUES(@Name,@Email,@GroupID,@Salt,@Password,@Status); SELECT SCOPE_IDENTITY()";
        private const string _SQL_DELETE = "DELETE FROM [User] {0}";
        private const string _SQL_UPDATE = "UPDATE [User] SET [Name] = @Name,[Email] = @Email,[GroupID] = @GroupID,[Salt] = @Salt,[Password] = @Password,[Status] = @Status {0}";
        private const string _SQL_SELECT = "SELECT [UserID],[Name],[Email],[GroupID],[Salt],[Password],[Status] FROM [User] {0}";
        private const string _SQL_SELECT_LIST = "SELECT [UserID],[Name],[Email],[GroupID],[Salt],[Password],[Status] FROM [User] {0}";
        //SQL语句 - 分页
        private const string _SQL_SELECT_PAGING = "SELECT [UserID],[Name],[Email],[GroupID],[Salt],[Password],[Status] FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS ROWNUM,[UserID],[Name],[Email],[GroupID],[Salt],[Password],[Status] FROM [User] {1}) AS T WHERE ROWNUM BETWEEN (@PageIndex-1) * @PageSize + 1 AND (@PageIndex * @PageSize)"; 
        private const string _SQL_SELECT_COUNT = "SELECT COUNT([UserID]) FROM [User] {0}"; 
        #endregion
        
        #region 插入数据
        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="User">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Insert(User obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@Name",obj.Name),
		        new SqlParameter("@Email",obj.Email),
		        new SqlParameter("@GroupID",obj.GroupID),
		        new SqlParameter("@Salt",obj.Salt),
		        new SqlParameter("@Password",obj.Password),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, _SQL_INSERT, CommandType.Text, param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回UserID
	    /// </summary>
	    /// <param name="User">需要插入的对象</param>
	    /// <returns>新插入数据的UserID</returns>
 	    public Object InsertReturnID(User obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@Name",obj.Name),
		        new SqlParameter("@Email",obj.Email),
		        new SqlParameter("@GroupID",obj.GroupID),
		        new SqlParameter("@Salt",obj.Salt),
		        new SqlParameter("@Password",obj.Password),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteScalar(SqlHelper.connectionString, _SQL_INSERT_RETURNID, CommandType.Text, param);
	    }
	    #endregion
	    
	    #region 更新数据
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="User">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Update(User obj)
	    {			
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [UserID] = @UserID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@UserID",obj.UserID),
		        new SqlParameter("@Name",obj.Name),
		        new SqlParameter("@Email",obj.Email),
		        new SqlParameter("@GroupID",obj.GroupID),
		        new SqlParameter("@Salt",obj.Salt),
		        new SqlParameter("@Password",obj.Password),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
	    #endregion
	    
	    #region 删除数据
	    /// <summary>
	    /// 删除一条数据。
	    /// </summary>
	    /// <param name="UserID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete(Int32 UserID)
	    {			
	        //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [UserID] = @UserID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@UserID",UserID)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
        #endregion
        
        #region 查询单条数据
        /// <summary>
        /// 根据UserID获取User表的一条数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public User SelectObj(Int32 UserID)
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT, "WHERE [UserID] = @UserID");
            //SqlParameter参数数组
            SqlParameter[] param = new SqlParameter[]{		
			    new SqlParameter("@UserID",UserID)
			};
			
            return ToObject(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, param));
        }
        #endregion
	    
	    #region 查询数据集合
        /// <summary>
        /// 获取User表的数据（全部）
        /// </summary>
        /// <returns></returns>
        public List<User> SelectList()
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT_LIST, String.Empty);
        
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, null));
        }
        
        /// <summary>
        /// 获取User表的数据（分页 按UserID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<User> SelectList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
        {
            String orderStr = "@UserID DESC";
            //分页基本参数的参数数组
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@UserID","[UserID]")
            };

            return Paging(pageIndex, pageSize, orderStr, null, parms, out recordCount);
        }
        #endregion
        
        #region 分页方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 获取User表的分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderStr">ORDER排序字符串</param>
        /// <param name="whereStr">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        private List<User> Paging(Int32 pageIndex, Int32 pageSize, String orderStr, String whereStr, SqlParameter[] whereParms, out Int32 recordCount)
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
        /// 根据WHERE条件 计算User表的数据总数
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
        /// 将SqlDataReader对象转换成User对象
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private User ToObject(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        User model = new User();
		                model.UserID = Convert.ToInt32(dr["UserID"]);
		                model.Name = dr["Name"].ToString();
		                model.Email = dr["Email"].ToString();
		                model.GroupID = Convert.ToInt32(dr["GroupID"]);
		                model.Salt = dr["Salt"].ToString();
		                model.Password = dr["Password"].ToString();
		                model.Status = Convert.ToByte(dr["Status"]);
		                
		                return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 将SqlDataReader对象转换成User对象集合
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private List<User> ToList(SqlDataReader dr)
        {
            List<User> list = null;
            using (dr)
            {
                if (dr.HasRows)
                {
                    list = new List<User>();
                    while (dr.Read())
                    {
                        User model = new User();
		                model.UserID = Convert.ToInt32(dr["UserID"]);
		                model.Name = dr["Name"].ToString();
		                model.Email = dr["Email"].ToString();
		                model.GroupID = Convert.ToInt32(dr["GroupID"]);
		                model.Salt = dr["Salt"].ToString();
		                model.Password = dr["Password"].ToString();
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
