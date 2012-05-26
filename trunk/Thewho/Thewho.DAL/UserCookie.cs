using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Thewho.Model

namespace Thewho.DAL
{
    /// <summary>
    /// UserCookie_DAL
    /// </summary>
    public class UserCookie_DAL
    {
        #region 常量
		// 声明静态变量 
		private const string _PARA_UID = "@UID";
		private const string _PARA_Email = "@Email";
		private const string _PARA_Password = "@Password";
		private const string _PARA_Salt = "@Salt";
		private const string _PARA_OutTime = "@OutTime";
		

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO UserCookie [Email],[Password],[Salt],[OutTime] VALUES(@Email,@Password,@Salt,@OutTime) ";        private const string _SQL_DELETE = "DELETE FROM UserCookie WHERE [UID] = @UID";        private const string _SQL_UPDATE = "UPDATE UserCookie SET [Email] = @Email,[Password] = @Password,[Salt] = @Salt,[OutTime] = @OutTime WHERE [UID] = @UID";        private const string _SQL_SELECT = "SELECT UserCookie SET [Email],[Password],[Salt],[OutTime] FROM UserCookie";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserCookie_DAL()
        { 
        }

        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="Thewho.Model.UserCookie">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public object Insert(Thewho.Model.UserCookie obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@Password",obj.Password)
		        ,new SqlParameter("@Salt",obj.Salt)
		        ,new SqlParameter("@OutTime",obj.OutTime)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT, _param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID。
	    /// </summary>
	    /// <param name="Thewho.Model.UserCookie">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public object InsertRetID(Thewho.Model.UserCookie obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@Password",obj.Password)
		        ,new SqlParameter("@Salt",obj.Salt)
		        ,new SqlParameter("@OutTime",obj.OutTime)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT + "; SELECT SCOPE_IDENTITY()", _param);
	    }
	    
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="Thewho.Model.UserCookie">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public int Update(Thewho.Model.UserCookie obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@Password",obj.Password)
		        ,new SqlParameter("@Salt",obj.Salt)
		        ,new SqlParameter("@OutTime",obj.OutTime)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_UPDATE, _param);	
	    }
	    
	    /// <summary>
	    /// 删除一条新数据。
	    /// </summary>
	    /// <param name="UID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public int Delete(Int32 UID)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",UID) 
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_DELETE, _param);	
	    }
	    
	    


        /// <summary>
        /// 根据UID获取Thewho.Model对象
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public Thewho.Model.UserCookie SelectObj(Int32 UID)
        {
            Thewho.Model.UserCookie obj = null;
            SqlParameter[] _param={		
			    new SqlParameter(_PARA_UID,UID)
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
        public List<Thewho.Model.UserCookie> SelectList()
        {
            List<Thewho.Model.UserCookie> list = null;
            Thewho.Model.UserCookie obj = null;
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, null))
            {
                if (dr.HasRows)
                {
                    list = new List<Thewho.Model.UserCookie>();
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
        public List<Thewho.Model.UserCookie> SelectList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            return PagingList(PageIndex, PageSize, OrderID, OrderType, StrWhere, out RecordCount);
        }
        
        #region 转换方法
        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Thewho.Model.UserCookie ToModel(IDataReader dr)
        {
            Thewho.Model.UserCookie model = new Thewho.Model.UserCookie();
		    model.Email = dr["Email"].ToString();
		    model.Password = dr["Password"].ToString();
		    model.Salt = dr["Salt"].ToString();
		    model.OutTime = Convert.ToDateTime(dr["OutTime"]);
		    
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
        public List<Thewho.Model.UserCookie> PagingList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            RecordCount = 0;
            List<Thewho.Model.UserCookie> list = new List<Thewho.Model.UserCookie>();
            using (SqlDataReader dr = Common.SqlHelper.Paging(Common.SqlHelper.ConnectionString, PageIndex,PageSize, "UserCookie", "UID", "DESC", StrWhere, out RecordCount))
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

