using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace $NameSpace
{
    /// <summary>
    /// $TableName
    /// </summary>
    public class $TableName_DAL
    {
        #region 常量
		// 声明静态变量 
		$Starprivate const string _PARA_$ColumnName = "@$ColumnName";
		$End

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO $TableName $Star[#LastChar=,#][$ColumnName] $End VALUES($Star[#LastChar=,#]@$ColumnName $End) ";        private const string _SQL_DELETE = "DELETE FROM $TableName WHERE [$PK_ColumnName] = @$PK_ColumnName";        private const string _SQL_UPDATE = "UPDATE $TableName SET $Star[#LastChar=,#][$ColumnName] = @$ColumnName $End WHERE [$PK_ColumnName] = @$PK_ColumnName ";        private const string _SQL_SELECT = "SELECT $TableName $Star[#LastChar=,#][$ColumnName] $End FROM $TableName";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public $TableName_DAL()
        { 
        }

        /// <summary>
	    /// 插入一条数据
	    /// </summary>
	    /// <param name="$ModelNameSpace.$TableName">需要插入的对象</param>
	    /// <returns>影响行数</returns>
 	    public object Insert($ModelNameSpace.$TableName obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        $Star[#LastChar=,#]new SqlParameter("@$ColumnName",obj.$ColumnName) 
		        $End
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT, _param);
	    }
        
        /// <summary>
	    /// 插入一条数据并返回ID。
	    /// </summary>
	    /// <param name="$ModelNameSpace.$TableName">需要插入的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public object InsertRetID($ModelNameSpace.$TableName obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        $Star[#LastChar=,#]new SqlParameter("@$ColumnName",obj.$ColumnName) 
		        $End
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteScalar(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_INSERT + "; select SCOPE_IDENTITY()", _param);
	    }
	    
	    /// <summary>
	    /// 更新一条新数据。
	    /// </summary>
	    /// <param name="$ModelNameSpace.$TableName">需要更新的对象</param>
	    /// <returns>影响行数</returns>
 	    public int Update($ModelNameSpace.$TableName obj)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        $Star[#LastChar=,#]new SqlParameter("@$ColumnName",obj.$ColumnName) 
		        $End
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_UPDATE, _param);	
	    }
	    
	    /// <summary>
	    /// 删除一条新数据。
	    /// </summary>
	    /// <param name="$PK_ColumnName">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public int Delete($PK_ColumnType $PK_ColumnName)
	    {			
		    //声明参数数组并赋值
		    SqlParameter[] _param=
		    {
		        new SqlParameter("@$PK_ColumnName",$PK_ColumnName) 
		    };			
    		
		    //返回
		    return  Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.ConnectionString, CommandType.Text,_SQL_DELETE, _param);	
	    }
	    
	    


        /// <summary>
        /// 根据$PK_ColumnName获取$ModelNameSpace对象
        /// </summary>
        /// <param name="$PK_ColumnName"></param>
        /// <returns></returns>
        public $ModelNameSpace.$TableName SelectObj($PK_ColumnType $PK_ColumnName)
        {
            $ModelNameSpace.$TableName obj = null;
            SqlParameter[] _param={		
			    new SqlParameter(_PARA_$PK_ColumnName,$PK_ColumnName)
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
        public List<$ModelNameSpace.$TableName> SelectList()
        {
            List<$ModelNameSpace.$TableName> list = null;
            $ModelNameSpace.$TableName obj = null;
            using (SqlDataReader dr = Common.SqlHelper.ExecuteReader(Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, null))
            {
                if (dr.HasRows)
                {
                    list = new List<$ModelNameSpace.$TableName>();
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
        public List<$ModelNameSpace.$TableName> SelectList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            return PagingList(PageIndex, PageSize, OrderID, OrderType, StrWhere, out RecordCount);
        }
        
        #region 转换方法
        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public $ModelNameSpace.$TableName ToModel(IDataReader dr)
        {
            $ModelNameSpace.$TableName model = new $ModelNameSpace.$TableName();
            model = new $ModelNameSpace.$TableName();
            $Starmodel.$ColumnName = $ConvertTo[#$ConvertStr=dr["$ColumnName"]#];
            $End
            return model;
        }
        #endregion
        
        #region 分页方法
        /// <summary>
        /// $TableName_DAL 公用分页方法
        /// </summary>
        /// <param name="PageIndex">页码（第一页传“1”以此类推）</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="OrderID">排序ID</param>
        /// <param name="OrderType">排序类型（desc，asc）</param>
        /// <param name="StrWhere">条件（如“ 1 = 1 and 2 = 2”）</param>
        /// <param name="RecordCount">返回数据总条数（用于计算页数）</param>
        /// <returns>作文集合</returns>
        public List<$ModelNameSpace.$TableName> PagingList(int PageIndex, int PageSize, string OrderID, string OrderType, string StrWhere, out int RecordCount)
        {
            RecordCount = 0;
            List<$ModelNameSpace.$TableName> list = new List<$ModelNameSpace.$TableName>();
            using (SqlDataReader dr = Common.SqlHelper.Paging(Common.SqlHelper.ConnectionString, PageIndex,PageSize, "$TableName", "$PK_ColumnName", "DESC", StrWhere, out RecordCount))
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
