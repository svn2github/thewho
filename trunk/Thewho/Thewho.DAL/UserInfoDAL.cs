using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Thewho.DAL
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoDAL
    {
        #region 静态常量

        //参数字段
        private const string _PARA_ID = "@ID";

        //SQL语句
        private const string _SQL_INSERT = "";
        private const string _SQL_DELETE = "";
        private const string _SQL_UPDATE = "";
        private const string _SQL_SELECT = "";
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserInfoDAL()
        { 
        }


        /// <summary>
        /// 将IDataReader对象转换成Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Thewho.Model.UserInfo ToModel(IDataReader dr)
        {
            Thewho.Model.UserInfo model = new Thewho.Model.UserInfo();
            
            model = new Thewho.Model.UserInfo();
            model.ID = Convert.ToInt32(dr["ID"]);
            model.TrueName = Convert.ToString(dr["TrueName"]);
            model.Email = Convert.ToString(dr["Email"]);
            model.GroupID = Convert.ToInt32(dr["GroupID"]);
            model.Sex = Convert.ToByte(dr["Sex"]);
            model.Birthday = Convert.ToDateTime(dr["Birthday"]);
            model.RegIp = Convert.ToString(dr["RegIp"]);
            model.RegTime = Convert.ToDateTime(dr["RegTime"]);
            model.Status = Convert.ToByte(dr["Status"]);

            return model;
        }


        /// <summary>
        /// 根据ID获取Thewho.Model.UserInfo对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Thewho.Model.UserInfo SelectObj(Int32 ID)
        {
            Thewho.Model.UserInfo obj = null;

            SqlParameter[] _param={		
			    new SqlParameter(_PARA_ID,ID)
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

        
        public List<Thewho.Model.UserInfo> SelectList()
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

        public List<Thewho.Model.UserInfo> SelectList(int PageIndex, int PageSize, string strWhere,SqlParameter [] para, out int Count)
        {
            List<Thewho.Model.UserInfo> list = null;
            Thewho.Model.UserInfo obj = null;
            Count = 0;
            //using (SqlDataReader dr = Thewho.Common.SqlHelper.Paging(Thewho.Common.SqlHelper.ConnectionString, PageIndex,PageSize,
            //       "UserInfo", "ID", "DESC",strWhere, para,out Count))
            //{
            //    if (dr.HasRows)
            //    {
            //        list = new List<Thewho.Model.UserInfo>();
            //        if (dr.Read())
            //        {
            //            obj = ToModel(dr);
            //            list.Add(obj);
            //        }
            //    }
            //}
            return list;
        }
    }
}
