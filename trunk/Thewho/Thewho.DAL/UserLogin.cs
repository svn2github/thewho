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
    /// UserLogin_DAL
    /// </summary>
    public class UserLogin_DAL
    {
        #region 常量
		// 声明静态变量 
		private const string _PARA_ID = "@ID";
		private const string _PARA_UID = "@UID";
		private const string _PARA_Email = "@Email";
		private const string _PARA_LoginTime = "@LoginTime";
		private const string _PARA_LoginIp = "@LoginIp";
		private const string _PARA_Result = "@Result";
		

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO UserLogin [UID],[Email],[LoginTime],[LoginIp],[Result] VALUES(@UID,@Email,@LoginTime,@LoginIp,@Result) ";        private const string _SQL_DELETE = "DELETE FROM UserLogin WHERE [ID] = @ID";        private const string _SQL_UPDATE = "UPDATE UserLogin SET [UID] = @UID,[Email] = @Email,[LoginTime] = @LoginTime,[LoginIp] = @LoginIp,[Result] = @Result WHERE [ID] = @ID";        private const string _SQL_SELECT = "SELECT UserLogin SET [UID],[Email],[LoginTime],[LoginIp],[Result] FROM UserLogin";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserLogin_DAL()
        { 
        }

        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="Thewho.Model.UserLogin">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public object Insert(Thewho.Model.UserLogin obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",obj.UID)
		        ,new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@LoginTime",obj.LoginTime)
		        ,new SqlParameter("@LoginIp",obj.LoginIp)
		        ,new SqlParameter("@Result",obj.Result)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT, _param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID。
	    /// </summary>
	    /// <param name="Thewho.Model.UserLogin">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public object InsertRetID(Thewho.Model.UserLogin obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",obj.UID)
		        ,new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@LoginTime",obj.LoginTime)
		        ,new SqlParameter("@LoginIp",obj.LoginIp)
		        ,new SqlParameter("@Result",obj.Result)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT + "; SELECT SCOPE_IDENTITY()", _param);
	    }
	    
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="Thewho.Model.UserLogin">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public int Update(Thewho.Model.UserLogin obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",obj.UID)
		        ,new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@LoginTime",obj.LoginTime)
		        ,new SqlParameter("@LoginIp",obj.LoginIp)
		        ,new SqlParameter("@Result",obj.Result)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_UPDATE, _param);	
	    }
	    
	    /// <summary>
	    /// 删除一条新数据。
	    /// </summary>
	    /// <param name="ID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public int Delete(Int32 ID)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@ID",ID) 
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_DELETE, _param);	
	    }
	    
	    


        /// <summary>
        /// 根据ID获取Thewho.Model对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Thewho.Model.UserLogin SelectObj(Int32 ID)
        {
            Thewho.Model.UserLogin obj = null;
            SqlParameter[] _param={		
			    new SqlParameter(_PARA_ID,ID)
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
        public List<Thewho.Model.UserLogin> SelectList()
        {
            List<Thewho.Model.UserLogin> list = null;
            Thewho.Model.UserLogin obj = null;
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, null))
            {
                if (dr.HasRows)
                {
                    list = new List<Thewho.Model.UserLogin>();
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
        public List<Thewho.Model.UserLogin> SelectList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            return PagingList(PageIndex, PageSize, OrderID, OrderType, StrWhere, out RecordCount);
        }
        
        #region 转换方法
        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Thewho.Model.UserLogin ToModel(IDataReader dr)
        {
            Thewho.Model.UserLogin model = new Thewho.Model.UserLogin();
		    model.UID = Convert.ToInt32(dr["UID"]);
		    model.Email = dr["Email"].ToString();
		    model.LoginTime = Convert.ToDateTime(dr["LoginTime"]);
		    model.LoginIp = dr["LoginIp"].ToString();
		    model.Result = Convert.ToByte(dr["Result"]);
		    
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
        public List<Thewho.Model.UserLogin> PagingList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            RecordCount = 0;
            List<Thewho.Model.UserLogin> list = new List<Thewho.Model.UserLogin>();
            using (SqlDataReader dr = Common.SqlHelper.Paging(Common.SqlHelper.ConnectionString, PageIndex,PageSize, "UserLogin", "ID", "DESC", StrWhere, out RecordCount))
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

