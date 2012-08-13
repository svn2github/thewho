using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Thewho.Config
{
    public static class WebConfig
    {
        public static string SITEPATH = ConfigurationManager.AppSettings["SitePath"].ToString();
    }
}
