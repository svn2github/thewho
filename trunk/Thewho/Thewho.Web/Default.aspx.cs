using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.Caching;

namespace Thewho.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        private static CacheDependency mydepen;
        public DataSet myds = new DataSet();//创建XML数据源
        protected void Page_Load(object sender, EventArgs e)
        {
            string iy = Request.QueryString["iy"];
            if (!Page.IsPostBack)
            {

                //if (Cache["Players"] != null)//判断缓存是否存在
                //{
                //    myds = (DataSet)Cache["Players"];
                //}
                //else
                //{
                //    myds.ReadXml(this.MapPath(Request.ApplicationPath + @"/Configs/players.xml"));//数据源来自文件players.xml
                //    if (Cache["Players"] == null)//判断缓存是否存在
                //    {
                //        mydepen = new CacheDependency(this.MapPath(Request.ApplicationPath + @"/Configs/players.xml"));//创建缓存依赖
                //        //添加缓存项
                //        Cache.Add("Players", myds, mydepen, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
                //    }
                //}
            }

            string Request_QueryString = Request.QueryString.ToString();
            if (Request.QueryString["page"] != null)
            {
                Request_QueryString = Request_QueryString.Replace("page=" + Request.QueryString["page"] + "&", "");
            }
        }
        
        
    }
}
