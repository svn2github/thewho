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
    /// UserInfo_DAL
    /// </summary>
    public class UserInfo_DAL
    {
        #region 常量
		// 声明静态变量 
		private const string _PARA_ID = "@ID";
		private const string _PARA_Name = "@Name";
		private const string _PARA_Email = "@Email";
		private const string _PARA_GroupID = "@GroupID";
		private const string _PARA_Sex = "@Sex";
		private const string _PARA_Birthday = "@Birthday";
		private const string _PARA_RegIp = "@RegIp";
		private const string _PARA_RegTime = "@RegTime";
		private const string _PARA_Status = "@Status";
		

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO UserInfo [Name],[Email],[GroupID],[Sex],[Birthday],[RegIp],[RegTime],[Status] VALUES(@Name,@Email,@GroupID,@Sex,@Birthday,@RegIp,@RegTime,@Status) ";        private const string _SQL_DELETE = "DELETE FROM UserInfo WHERE [ID] = @ID";        private const string _SQL_UPDATE = "UPDATE UserInfo SET [Name] = @Name,[Email] = @Email,[GroupID] = @GroupID,[Sex] = @Sex,[Birthday] = @Birthday,[RegIp] = @RegIp,[RegTime] = @RegTime,[Status] = @Status WHERE [ID] = @ID";        private const string _SQL_SELECT = "SELECT UserInfo SET [Name],[Email],[GroupID],[Sex],[Birthday],[RegIp],[RegTime],[Status] FROM UserInfo";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserInfo_DAL()
        { 
        }

        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="Thewho.Model.UserInfo">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public object Insert(Thewho.Model.UserInfo obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@Name",obj.Name)
		        ,new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@GroupID",obj.GroupID)
		        ,new SqlParameter("@Sex",obj.Sex)
		        ,new SqlParameter("@Birthday",obj.Birthday)
		        ,new SqlParameter("@RegIp",obj.RegIp)
		        ,new SqlParameter("@RegTime",obj.RegTime)
		        ,new SqlParameter("@Status",obj.Status)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT, _param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID。
	    /// </summary>
	    /// <param name="Thewho.Model.UserInfo">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public object InsertRetID(Thewho.Model.UserInfo obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@Name",obj.Name)
		        ,new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@GroupID",obj.GroupID)
		        ,new SqlParameter("@Sex",obj.Sex)
		        ,new SqlParameter("@Birthday",obj.Birthday)
		        ,new SqlParameter("@RegIp",obj.RegIp)
		        ,new SqlParameter("@RegTime",obj.RegTime)
		        ,new SqlParameter("@Status",obj.Status)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT + "; SELECT SCOPE_IDENTITY()", _param);
	    }
	    
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="Thewho.Model.UserInfo">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public int Update(Thewho.Model.UserInfo obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@Name",obj.Name)
		        ,new SqlParameter("@Email",obj.Email)
		        ,new SqlParameter("@GroupID",obj.GroupID)
		        ,new SqlParameter("@Sex",obj.Sex)
		        ,new SqlParameter("@Birthday",obj.Birthday)
		        ,new SqlParameter("@RegIp",obj.RegIp)
		        ,new SqlParameter("@RegTime",obj.RegTime)
		        ,new SqlParameter("@Status",obj.Status)
		        
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
        public Thewho.Model.UserInfo SelectObj(Int32 ID)
        {
            Thewho.Model.UserInfo obj = null;
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
        public List<Thewho.Model.UserInfo> SelectList()
        {
            List<Thewho.Model.UserInfo> list = null;
            Thewho.Model.UserInfo obj = null;
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, null))
            {
                if (dr.HasRows)
                {
                    list = new List<Thewho.Model.UserInfo>();
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
        public List<Thewho.Model.UserInfo> SelectList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            return PagingList(PageIndex, PageSize, OrderID, OrderType, StrWhere, out RecordCount);
        }
        
        #region 转换方法
        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Thewho.Model.UserInfo ToModel(IDataReader dr)
        {
            Thewho.Model.UserInfo model = new Thewho.Model.UserInfo();
		    model.Name = dr["Name"].ToString();
		    model.Email = dr["Email"].ToString();
		    model.GroupID = Convert.ToInt32(dr["GroupID"]);
		    model.Sex = Convert.ToByte(dr["Sex"]);
		    model.Birthday = Convert.ToDateTime(dr["Birthday"]);
		    model.RegIp = dr["RegIp"].ToString();
		    model.RegTime = Convert.ToDateTime(dr["RegTime"]);
		    model.Status = Convert.ToByte(dr["Status"]);
		    
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
        public List<Thewho.Model.UserInfo> PagingList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            RecordCount = 0;
            List<Thewho.Model.UserInfo> list = new List<Thewho.Model.UserInfo>();
            using (SqlDataReader dr = Common.SqlHelper.Paging(Common.SqlHelper.ConnectionString, PageIndex,PageSize, "UserInfo", "ID", "DESC", StrWhere, out RecordCount))
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

