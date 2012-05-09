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

namespace Thewho.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        public string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thewho.Cache.Base<string>.Insert(DateTime.Now.Minute.ToString(), DateTime.Now.Minute.ToString(), 1, "1");
            //Thewho.Cache.Base<string>.GetList();
            //if (Request.QueryString.Count > 0)
            //{
                Response.Write(Session["UserID"]);
                //HttpCookie hc = Request.Cookies["LoginCookie"];
                //if (hc != null)
                //{
                //    Response.Write(hc.Values["UserName"]);
                //}
                //DateTime dt = new DateTime(2007, 01, 31, 10, 36, 07);
                //Response.Write(new Thewho.Common.Time().ToTimeStr(dt));

                //foreach (System.Collections.Specialized.NameValueCollection item in Request.QueryString)
                //{
                //    if (Request.QueryString.c)
                //    {
                        
                //    }
                //}
                //Response.Pics("哈哈");
                //Response.Redirect("Login.aspx");
                //for (int i = 0; i < Request.QueryString.Count; i++)
                //{
                //    if (i != 0)
                //    {
                //        url += "&" + Request.QueryString.AllKeys[i] + "=" + Request.QueryString[i].ToString();
                //    }
                //    else
                //    {
                //        url += "?" + Request.QueryString.AllKeys[i] + "=" + Request.QueryString[i].ToString();
                //    }
                    
                //}
            //}
            
        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    Response.Write("<script>setTimeout('alert(123);location.href = \"http://www.baidu.com/\";',2000);</script>");
        //}
        //protected void Page_Disposed(object sender, EventArgs e)
        //{
        //    Response.Write("<script>alert('2');</script>");
        //}
        
        
    }
}
