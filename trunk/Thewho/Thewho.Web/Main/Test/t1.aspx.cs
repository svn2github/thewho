using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace Thewho.Web.Main.Test
{
    public partial class t1 : Thewho.Web.Base.Aspx
    {
        public string cacheStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                cacheStr = Thewho.Common.CacheHelper<string>.Get("str");
            //} 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Thewho.Common.CacheHelper<string>.Insert("str", TextBox1.Text.Trim(), 30, "");
            
        }
    }
}
