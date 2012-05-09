using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Thewho.Web.Base
{
    /// <summary>
    /// Aspx页面基类(包括内容页)
    /// </summary>
    public class Aspx : System.Web.UI.Page
    {
        public Thewho.BLL.CurrentUser _currentUser = new Thewho.BLL.CurrentUser();
        public Thewho.LogicModel.User thisUser = null;

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
    }
}
