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
using Thewho.Config;
using System.Xml;
using Thewho.BLL;
using System.Collections.Generic;

namespace Thewho.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public Function_BLL _fun = new Function_BLL();
        public List<Thewho.Model.Function> list = new List<Thewho.Model.Function>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Thewho.Config.XMLConfig.GetItem("Site","/Site/CurrentUser/Status"));
            int i = 0;
            list = _fun.GetList(1,2, out i);
            
            //权限? 查询时应该是 先查最高级别的用户组 一级一级查下来 最后到用户
        }
    }
}
