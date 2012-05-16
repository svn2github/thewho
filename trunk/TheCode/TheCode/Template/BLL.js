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
        #region 静态常量


        //参数字段

        //SQL语句
        private const string _SQL_INSERT = "INSERT INTO $TableName $Star[#LastChar=,#] [$ColumnName] $End VALUES($Star[#LastChar=,#] $ColumnName $End) GO";
        private const string _SQL_DELETE = "DELETE FROM $TableName WHERE GO";
        private const string _SQL_UPDATE = "UPDATE $TableName SET $Star[#LastChar=,#] [$ColumnName] = @$ColumnName $End WHERE GO";
        private const string _SQL_SELECT = "SELECT $TableName $Star[#LastChar=,#] [$ColumnName] $End $TableName WHERE $PK_ColumnName = @$PK_ColumnName GO";
        
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public $TableName_DAL()
        { 
        }
        

        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public $ModelNameSpace.UserInfo ToModel(IDataReader dr)
        {
            Thewho.Model.UserInfo model = new Thewho.Model.UserInfo();
            
            model = new Thewho.Model.UserInfo();
            $Star
            model.$ColumnName = $ConvertTo[#$ConvertStr=dr["$ColumnName"]#];
            $End
            return model;
        }


        /// <summary>
        /// 根据ID获取Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="$PK_ColumnName"></param>
        /// <returns></returns>
        public $ModelNameSpace.UserInfo SelectObj($PK_ColumnType $PK_ColumnName)
        {
            Thewho.Model.UserInfo obj = null;

            SqlParameter[] _param={		
			    new SqlParameter(_PARA_ID,$PK_ColumnName)
			};	
            using (SqlDataReader dr = Thewho.Common.SqlHelper.ExecuteReader(Thewho.Common.SqlHelper.ConnectionString,CommandType.Text,_SQL_SELECT,_param))
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

        
        public List<$ModelNameSpace.UserInfo> SelectList()
        {
            List<Thewho.Model.UserInfo> list = null;
            Thewho.Model.UserInfo obj = null;

            SqlParameter[] _param ={		
			    new SqlParameter(_PARA_ID,1)
			};

            using (SqlDataReader dr = Thewho.Common.SqlHelper.ExecuteReader(Thewho.Common.SqlHelper.ConnectionString, CommandType.Text, _SQL_SELECT, _param))
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

        public List<$ModelNameSpace.UserInfo> SelectList(int PageIndex, int PageSize, string strWhere,SqlParameter [] para, out int Count)
        {
            List<Thewho.Model.UserInfo> list = null;
            Thewho.Model.UserInfo obj = null;
            using (SqlDataReader dr = Thewho.Common.SqlHelper.Paging(Thewho.Common.SqlHelper.ConnectionString, PageIndex,PageSize,
                   "UserInfo", "ID", "DESC",strWhere, para,out Count))
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
    }
}