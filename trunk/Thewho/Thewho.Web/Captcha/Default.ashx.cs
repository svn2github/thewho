using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace Thewho.Web.Captcha
{
    /// <summary>
    /// 验证码生成处理程序
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Default : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            context.Response.ClearContent();
            context.Response.ContentType = "image/Gif";
            context.Response.BinaryWrite(Thewho.Common.CaptchaHelper.Create(4,0,80,26,12,"",true,true,"","",0,0).ToArray());
            context.Response.Expires = 0;
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.CacheControl = "no-cache";
            context.Response.End();


        }
        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
