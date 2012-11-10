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
        private string userName, password;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtusername"]) && !string.IsNullOrEmpty(Request.Form["txtpassword"]))
	        {
                userName = Request.Form["txtusername"];
                password = Request.Form["txtpassword"];
	        }
        }
    }
}
