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
    /// Permission_DAL
    /// </summary>
    public class Permission_DAL
    {
        #region 常量
		// 声明静态变量 
		private const string _PARA_ID = "@ID";
		private const string _PARA_UID = "@UID";
		private const string _PARA_FunctionID = "@FunctionID";
		private const string _PARA_Type = "@Type";
		private const string _PARA_Addtime = "@Addtime";
		private const string _PARA_Status = "@Status";
		

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO Permission [UID],[FunctionID],[Type],[Addtime],[Status] VALUES(@UID,@FunctionID,@Type,@Addtime,@Status) ";        private const string _SQL_DELETE = "DELETE FROM Permission WHERE [ID] = @ID";        private const string _SQL_UPDATE = "UPDATE Permission SET [UID] = @UID,[FunctionID] = @FunctionID,[Type] = @Type,[Addtime] = @Addtime,[Status] = @Status WHERE [ID] = @ID";        private const string _SQL_SELECT = "SELECT Permission SET [UID],[FunctionID],[Type],[Addtime],[Status] FROM Permission";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public Permission_DAL()
        { 
        }

        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="Thewho.Model.Permission">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public object Insert(Thewho.Model.Permission obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",obj.UID)
		        ,new SqlParameter("@FunctionID",obj.FunctionID)
		        ,new SqlParameter("@Type",obj.Type)
		        ,new SqlParameter("@Addtime",obj.Addtime)
		        ,new SqlParameter("@Status",obj.Status)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT, _param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID。
	    /// </summary>
	    /// <param name="Thewho.Model.Permission">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public object InsertRetID(Thewho.Model.Permission obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",obj.UID)
		        ,new SqlParameter("@FunctionID",obj.FunctionID)
		        ,new SqlParameter("@Type",obj.Type)
		        ,new SqlParameter("@Addtime",obj.Addtime)
		        ,new SqlParameter("@Status",obj.Status)
		        
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT + "; SELECT SCOPE_IDENTITY()", _param);
	    }
	    
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="Thewho.Model.Permission">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public int Update(Thewho.Model.Permission obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@UID",obj.UID)
		        ,new SqlParameter("@FunctionID",obj.FunctionID)
		        ,new SqlParameter("@Type",obj.Type)
		        ,new SqlParameter("@Addtime",obj.Addtime)
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
        public Thewho.Model.Permission SelectObj(Int32 ID)
        {
            Thewho.Model.Permission obj = null;
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
        public List<Thewho.Model.Permission> SelectList()
        {
            List<Thewho.Model.Permission> list = null;
            Thewho.Model.Permission obj = null;
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, null))
            {
                if (dr.HasRows)
                {
                    list = new List<Thewho.Model.Permission>();
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
        public List<Thewho.Model.Permission> SelectList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            return PagingList(PageIndex, PageSize, OrderID, OrderType, StrWhere, out RecordCount);
        }
        
        #region 转换方法
        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Thewho.Model.Permission ToModel(IDataReader dr)
        {
            Thewho.Model.Permission model = new Thewho.Model.Permission();
		    model.UID = Convert.ToInt32(dr["UID"]);
		    model.FunctionID = Convert.ToInt32(dr["FunctionID"]);
		    model.Type = Convert.ToByte(dr["Type"]);
		    model.Addtime = Convert.ToDateTime(dr["Addtime"]);
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
        public List<Thewho.Model.Permission> PagingList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            RecordCount = 0;
            List<Thewho.Model.Permission> list = new List<Thewho.Model.Permission>();
            using (SqlDataReader dr = Common.SqlHelper.Paging(Common.SqlHelper.ConnectionString, PageIndex,PageSize, "Permission", "ID", "DESC", StrWhere, out RecordCount))
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

