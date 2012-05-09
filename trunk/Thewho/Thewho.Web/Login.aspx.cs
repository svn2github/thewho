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

namespace Thewho.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected string userName;
        protected string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtUserName"]) &&
                !string.IsNullOrEmpty(Request.Form["txtPassword"])
                )
            {
                userName = Request.Form["txtUserName"];
                password = Request.Form["txtPassword"];
                if (userName == "admin" && password == "123456")
                {
                    string r = "x2dcr7" + userName;

                    Session["UserID"] = "1";
                    //Session["UserID"] = Thewho.Common.Md5.Encrypt32(r);

                    //Response.Write(Session["User"]);
                    //HttpCookie hc = new HttpCookie("LoginCookie",null);
                    //hc.Expires = DateTime.Now.AddMinutes(1);
                    //hc.Value = Session["User"].ToString();
                    //hc.Values.Add("UserName", Session["User"].ToString());
                    //hc.Values.Add("Password", password);
                    //Response.Cookies.Add(hc);
                    Response.Redirect("Default.aspx");
                    
                }

                //登录帐号
                //存储到数据库的密码为: uid + 盐 + 真实密码

                //Cookie伪码
                //存储到Cookie的伪码为: uid + 盐 + IP

            }
        }
    }
}
