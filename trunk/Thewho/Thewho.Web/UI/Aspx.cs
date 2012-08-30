using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;//Session Cookie
using Thewho.Common;
using Thewho.Model;
using Thewho.BLL;

namespace Thewho.Web.Base
{
    /// <summary>
    /// Aspx页面基类(包括内容页)
    /// </summary>
    public class Aspx : System.Web.UI.Page
    {
        private CurrentUser _currentUser = null;
        private Function_BLL _function_bll = null;
        private Permission_BLL _permission_bll = null;
        

        public User currentUser = null;
        public string urlReferrer = "";

        public Aspx()
        {
            _currentUser = new CurrentUser();
            _function_bll = new Function_BLL();
            _permission_bll = new Permission_BLL();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //是否回传
            if (!IsPostBack)
            {
                //if (Request.Url != null)
                //{
                //    Response.Redirect("/Again.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
                //}
                //Response.Redirect("/Again.aspx");
                //thisUser = _currentUser.GetThisUser();
                //if (thisUser == null)
                //{
                //    Response.Redirect("/Default.aspx");
                //}

                currentUser = _currentUser.GetCurrentUser();
                if (currentUser == null) //没有登录
                {
                    Response.Redirect("~/Default.aspx");
                }

            }

            #region 记录
            //Request获取的信息
            //Request.AppRelativeCurrentExecutionFilePath                  ~/SysOption/BillingSetup1.aspx 
            //Request.ApplicationPath                                      /
            //Request.CurrentExecutionFilePath                             /SysOption/BillingSetup1.aspx 
            //Request.FilePath                                             /SysOption/BillingSetup1.aspx 
            //Request.Path                                                 /SysOption/BillingSetup1.aspx 
            //Request.PathInfo                                             什么都没有（待测其他用法）
            //Request.PhysicalApplicationPath                              D:\VssWorkFolder\British_School_MIS\src\WebSite\ 
            //Request.PhysicalPath                                         D:\VssWorkFolder\British_School_MIS\src\WebSite\SysOption\BillingSetup1.aspx 
            //Request.UserHostAddress                                      192.168.1.6
            //Request.UserHostName                                         192.168.1.6
            //Request.Url.ToString()                                       http://192.168.1.6/SysOption/BillingSetup1.aspx?x=d 
            //Request.UrlReferrer                                          空引用或者跳转源页面地址      
            //Request.ServerVariables集合中获取到的相关信息:
            //左列是服务器变量名，右侧是值，值是通过Request.ServerVariables[服务器变量名]获取的
            //APPL_MD_PATH : /LM/W3SVC/894523/Root
            //APPL_PHYSICAL_PATH : D:\VssWorkFolder\British_School_MIS\src\WebSite\
            //INSTANCE_META_PATH : /LM/W3SVC/894523
            //LOCAL_ADDR : 192.168.1.6
            //PATH_INFO : /SysOption/BillingSetup1.aspx
            //PATH_TRANSLATED : D:\VssWorkFolder\British_School_MIS\src\WebSite\SysOption\BillingSetup1.aspx
            //REMOTE_ADDR : 192.168.1.6
            //REMOTE_HOST : 192.168.1.6
            //SCRIPT_NAME : /SysOption/BillingSetup1.aspx
            //SERVER_NAME : 192.168.1.6
            //URL : /SysOption/BillingSetup1.aspx
            #endregion

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //此处处理具体页面加载后的逻辑
            
        }

        /// <summary>
        /// 验证当前用户是否拥有这个页面的权限
        /// </summary>
        private void CheckPermission()
        {
            string thisurl = Request.Url.ToString();
            //查询这个页面所对应的功能 如果这个页面是一个没设置过功能的页面 那就不需要再验证了

            //判断当前用户的权限中是否拥有这个功能

            if (true) //有? 没问题
            {

            }
            else //没有 跳转并提示没权限
            { 
            
            }
        }

        /// <summary>
        /// 重定向到上一个页面
        /// </summary>
        /// <param name="lastUrl">
        /// 手动地址/为保险起见 如果Request.UrlReferrer为空 则会启用这个手动地址
        /// </param>
        public void LastPage(string url)
        {
            if (Request.UrlReferrer != null)
            {
                url = Request.UrlReferrer.AbsoluteUri;
            }
            Response.Redirect(url);

            //Request.QueryString.AllKeys.ToString();

            //上一个页面
            //Request.UrlReferrer.AbsolutePath 绝对页面地址 
            //Request.UrlReferrer.AbsoluteUri 绝对页面地址 + 参数

            //Request.UrlReferrer.PathAndQuery 相对页面地址 + 参数
            //OriginalString 原始地址 等同于绝对页面地址+参数
            //Query 参数


            //当前页面
            //Request.Url.PathAndQuery 相对地址
            //Request.Url.OriginalString 全地址
            //Request.Url.Query 参数 

            //Request.QueryString.AllKeys 参数数组
        }


        /// <summary>
        /// 获得QeryString参数STRING
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetQueryString(string key)
        {
            string value = HttpContext.Current.Request.QueryString[key];
            if (value == null)
            {
                return string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获得QeryString参数INT
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetQueryInt(string key, int defValue)
        {
            string val = HttpContext.Current.Request.QueryString[key];
            if (null == val) { return defValue; }
            int.TryParse(val, out defValue);
            return defValue;
        }


        /// <summary>
        /// 获得QeryString参数DATETIEM
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected DateTime GetQueryDateTime(string key, DateTime defValue)
        {
            string val = HttpContext.Current.Request.QueryString[key];
            if (null == val) { return defValue; }
            DateTime.TryParse(val, out defValue);
            return defValue;
        }

        /// <summary>
        /// 获得Form参数 STRING
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetFormString(string key)
        {
            string val = HttpContext.Current.Request.Form[key];
            if (null == val) return string.Empty;
            return val;
        }

        /// <summary>
        /// 获得Form参数INT
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        protected int GetFormInt(string key, int defValue)
        {
            string val = HttpContext.Current.Request.Form[key];
            if (null == val) { return defValue; }
            int.TryParse(val, out defValue);
            return defValue;
        }

        /// <summary>
        /// 获得Form参数DateTime
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        protected DateTime GetFormDateTime(string key, DateTime defValue)
        {
            string val = HttpContext.Current.Request.Form[key];
            if (null == val) { return defValue; }
            DateTime.TryParse(val, out defValue);
            return defValue;
        }

        /// <summary>
        /// 获得参数，Query和Form通用 STRING
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetString(string key)
        {
            string val = GetQueryString(key);
            if (string.IsNullOrEmpty(val))
            {
                val = GetFormString(key);
            }
            return val;
        }

        /// <summary>
        /// 获得参数，Query和Form通用 INT
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetInt(string key, int defValue)
        {
            int val = GetQueryInt(key, defValue);
            if (val == defValue)
            {
                val = GetFormInt(key, defValue);
            }
            return val;
        }

        /// <summary>
        /// 获得参数，Query和Form通用 DateTime
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected DateTime GetDateTime(string key, DateTime defValue)
        {
            DateTime val = GetQueryDateTime(key, defValue);
            if (val == defValue)
            {
                val = GetFormDateTime(key, defValue);
            }
            return val;
        }


        ///// <summary>
        ///// 根据当前的Querystring过滤特定keyValue值对后形成新的Querystring
        ///// </summary>
        ///// <param name="filterkey">需要过滤掉的key列表，以,分割</param>
        ///// <returns></returns>
        //protected string GetQueryToUrlString(string filterkey)
        //{
        //    filterkey = string.Format(",{0},", filterkey);
        //    string s = string.Empty;
        //    NameValueCollection QueryParams = HttpContext.Current.Request.QueryString;
        //    foreach (string key in QueryParams.AllKeys)
        //    {
        //        if (filterkey.Contains(string.Format(",{0},", key.ToLower()))) continue;
        //        s += string.Format("&amp;{0}={1}", key, HttpContext.Current.Server.UrlEncode(QueryParams[key]));
        //    }
        //    return s.Substring(5);
        //}
    }
}
