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
        //public Function_BLL _fun = new Function_BLL();
        //public List<Thewho.Model.Function> list = new List<Thewho.Model.Function>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Thewho.Config.XMLConfig.GetItem("Site","/Site/CurrentUser/Status"));
            //int i = 0;
            //list = _fun.GetList(1,2, out i);
            
            //权限? 查询时应该是 先查最高级别的用户组 一级一级查下来 最后到用户

            //Say s1 = new Say(ZhHello);
            //s1 += EnHello;

            //Response.Write(SayHello("jim", s1));


            haizi hz = new haizi();
            hz.lookEvent += new baba().look;
            Response.Write(hz.chifan());
            hz.lookEvent += new mama().look;
            Response.Write(hz.chifan());
        }


        public class haizi
        {
            private int number;
            public delegate string LookFun(int number);
            public event LookFun lookEvent;        //声明事件

            public string chifan()
            {
                string s = "开始吃饭：<br/>";
                for (int i = 0; i <= 10; i++)
                {
                    number = i;
                    s += "第" + i + "碗<br/>";
                    if (number >= 5)
                    {
                        if (lookEvent != null)
                        {
                            s += lookEvent(number);
                        }
                    }
                }
                return s;
            }
        }

        public class baba
        {
            public string look(int number)
            {
                return "<b>多吃点,你才吃了" + number + "碗.</b><br/>";
            }
        }

        public class mama
        {
            public string look(int number)
            {
                return "<b>慢点吃点,你都吃了" + number + "碗了.</b><br/>";
            }
        }







        //定义委托
        public delegate string Say(string name);

        public string SayHello(string name, Say fun)
        {
           

            string r = "";
            //r += EnHello(name);
            //r += ZhHello(name);
            //r = fun(name);
            r = fun(name);
            return r;
        }

        //英文
        public string EnHello(string name)
        {
            return "hello " + name + "!<br/>";
        }
        //中文
        public string ZhHello(string name)
        {
            return "你好 " + name + "!<br/>";
        }

    }

}
