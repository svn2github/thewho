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
    /// Function_DAL（数据层）
    /// </summary>
    public class Function_DAL
    {
        #region 常量
        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO [Function] ([FunctionName],[FunctionUrl],[FunctionType],[ParentID],[Sort],[AddTime],[Status]) VALUES(@FunctionName,@FunctionUrl,@FunctionType,@ParentID,@Sort,@AddTime,@Status)";
        private const string _SQL_INSERT_RETURNID = "INSERT INTO [Function] [FunctionName],[FunctionUrl],[FunctionType],[ParentID],[Sort],[AddTime],[Status] VALUES(@FunctionName,@FunctionUrl,@FunctionType,@ParentID,@Sort,@AddTime,@Status); SELECT SCOPE_IDENTITY()";
        private const string _SQL_DELETE = "DELETE FROM [Function] {0}";
        private const string _SQL_UPDATE = "UPDATE [Function] SET [FunctionName] = @FunctionName,[FunctionUrl] = @FunctionUrl,[FunctionType] = @FunctionType,[ParentID] = @ParentID,[Sort] = @Sort,[AddTime] = @AddTime,[Status] = @Status {0}";
        private const string _SQL_SELECT = "SELECT [FunctionID],[FunctionName],[FunctionUrl],[FunctionType],[ParentID],[Sort],[AddTime],[Status] FROM [Function] {0}";
        private const string _SQL_SELECT_LIST = "SELECT [FunctionID],[FunctionName],[FunctionUrl],[FunctionType],[ParentID],[Sort],[AddTime],[Status] FROM [Function] {0}";
        //SQL语句 - 分页
        private const string _SQL_SELECT_PAGING = "SELECT [FunctionID],[FunctionName],[FunctionUrl],[FunctionType],[ParentID],[Sort],[AddTime],[Status] FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS ROWNUM,[FunctionID],[FunctionName],[FunctionUrl],[FunctionType],[ParentID],[Sort],[AddTime],[Status] FROM [Function] {1}) AS T WHERE ROWNUM BETWEEN (@PageIndex-1) * @PageSize + 1 AND (@PageIndex * @PageSize)"; 
        private const string _SQL_SELECT_COUNT = "SELECT COUNT([FunctionID]) FROM [Function] {0}"; 
        #endregion
        
        #region 插入数据
        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="Function">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Insert(Function obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@FunctionName",obj.FunctionName),
		        new SqlParameter("@FunctionUrl",obj.FunctionUrl),
		        new SqlParameter("@FunctionType",obj.FunctionType),
		        new SqlParameter("@ParentID",obj.ParentID),
		        new SqlParameter("@Sort",obj.Sort),
		        new SqlParameter("@AddTime",obj.AddTime),
		        new SqlParameter("@Status",obj.Status)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, _SQL_INSERT, CommandType.Text, param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回FunctionID
	    /// </summary>
	    /// <param name="Function">需要插入的对象</param>
	    /// <returns>新插入数据的FunctionID</returns>
 	    public Object InsertReturnID(Function obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@FunctionName",obj.FunctionName),
		        new SqlParameter("@FunctionUrl",obj.FunctionUrl),
		        new SqlParameter("@FunctionType",obj.FunctionType),
		        new SqlParameter("@ParentID",obj.ParentID),
		        new SqlParameter("@Sort",obj.Sort),
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
	    /// <param name="Function">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Update(Function obj)
	    {			
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [FunctionID] = @FunctionID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@FunctionID",obj.FunctionID),
		        new SqlParameter("@FunctionName",obj.FunctionName),
		        new SqlParameter("@FunctionUrl",obj.FunctionUrl),
		        new SqlParameter("@FunctionType",obj.FunctionType),
		        new SqlParameter("@ParentID",obj.ParentID),
		        new SqlParameter("@Sort",obj.Sort),
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
	    /// <param name="FunctionID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete(Int32 FunctionID)
	    {			
	        //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_UPDATE, "WHERE [FunctionID] = @FunctionID");
		    //声明参数数组并赋值
		    SqlParameter[] param = new SqlParameter[]{
		        new SqlParameter("@FunctionID",FunctionID)
		    };			
    		
		    return SqlHelper.ExecuteNonQuery(SqlHelper.connectionString, sqlStr, CommandType.Text, param);	
	    }
        #endregion
        
        #region 查询单条数据
        /// <summary>
        /// 根据FunctionID获取Function表的一条数据
        /// </summary>
        /// <param name="FunctionID"></param>
        /// <returns></returns>
        public Function SelectObj(Int32 FunctionID)
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT, "WHERE [FunctionID] = @FunctionID");
            //SqlParameter参数数组
            SqlParameter[] param = new SqlParameter[]{		
			    new SqlParameter("@FunctionID",FunctionID)
			};
			
            return ToObject(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, param));
        }
        #endregion
	    
	    #region 查询数据集合
        /// <summary>
        /// 获取Function表的数据（全部）
        /// </summary>
        /// <returns></returns>
        public List<Function> SelectList()
        {
            //将WHERE条件组合进SQL语句
            String sqlStr = String.Format(_SQL_SELECT_LIST, String.Empty);
        
            return ToList(SqlHelper.ExecuteReader(SqlHelper.connectionString, sqlStr, CommandType.Text, null));
        }
        
        /// <summary>
        /// 获取Function表的数据（分页 按FunctionID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<Function> SelectList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
        {
            String orderStr = "@FunctionID DESC";
            //分页基本参数的参数数组
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@FunctionID","[FunctionID]")
            };

            return Paging(pageIndex, pageSize, orderStr, null, parms, out recordCount);
        }
        #endregion
        
        #region 分页方法（私有，仅供该类下的方法来调用）
        /// <summary>
        /// 获取Function表的分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderStr">ORDER排序字符串</param>
        /// <param name="whereStr">WHERE条件字符串</param>
        /// <param name="whereParms">WHERE条件的参数数组</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        private List<Function> Paging(Int32 pageIndex, Int32 pageSize, String orderStr, String whereStr, SqlParameter[] whereParms, out Int32 recordCount)
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
        /// 根据WHERE条件 计算Function表的数据总数
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
        /// 将SqlDataReader对象转换成Function对象
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private Function ToObject(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Function model = new Function();
		                model.FunctionID = Convert.ToInt32(dr["FunctionID"]);
		                model.FunctionName = dr["FunctionName"].ToString();
		                model.FunctionUrl = dr["FunctionUrl"].ToString();
		                model.FunctionType = Convert.ToByte(dr["FunctionType"]);
		                model.ParentID = Convert.ToInt32(dr["ParentID"]);
		                model.Sort = Convert.ToByte(dr["Sort"]);
		                model.AddTime = Convert.ToDateTime(dr["AddTime"]);
		                model.Status = Convert.ToByte(dr["Status"]);
		                
		                return model;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 将SqlDataReader对象转换成Function对象集合
        /// </summary>
        /// <param name="dr">SqlDataReader对象</param>
        /// <returns></returns>
        private List<Function> ToList(SqlDataReader dr)
        {
            List<Function> list = null;
            using (dr)
            {
                if (dr.HasRows)
                {
                    list = new List<Function>();
                    while (dr.Read())
                    {
                        Function model = new Function();
		                model.FunctionID = Convert.ToInt32(dr["FunctionID"]);
		                model.FunctionName = dr["FunctionName"].ToString();
		                model.FunctionUrl = dr["FunctionUrl"].ToString();
		                model.FunctionType = Convert.ToByte(dr["FunctionType"]);
		                model.ParentID = Convert.ToInt32(dr["ParentID"]);
		                model.Sort = Convert.ToByte(dr["Sort"]);
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
