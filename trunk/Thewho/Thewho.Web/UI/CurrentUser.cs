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
    /// 当前用户登录状态
    /// </summary>
    public class CurrentUser : System.Web.UI.Page
    {
        private byte status = Thewho.Config.XMLConfig.LOGIN_STATUS; //Convert.ToInt32(Thewho.Config.XMLConfig.GetItem("Site", "/Site/CurrentUser/Status"));
        private int userID = -1; //-1为没有 0为登录失败或者没有
        private User_BLL _user = null;
        private UserCookie_BLL _userCookie = null;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CurrentUser()
        {
            _user = new User_BLL();
            _userCookie = new UserCookie_BLL();
        }

        /// <summary>
        /// 获取当前用户的登录对象
        /// </summary>
        /// <returns></returns>
        public User GetCurrentUser()
        {
            User currentUser = null;
            switch (status)
            {
                case 1://采用Session + Cookie验证
                    userID = GetUserSession();
                    userID = userID > 0 ? userID : GetUserCookie();
                    break;
                case 2://采用Session验证
                    userID = GetUserSession();
                    break;
                case 3://采用Cookie验证
                    userID = GetUserCookie();
                    break;
                default://无登录状态
                    userID = -1;
                    break;
            }
            if (userID > 0)
            {
                currentUser = _user.GetUser(userID);
            }
            return currentUser;

            
        }

        /// <summary>
        /// 设置当前用户为登录对象（新增或更新）
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User SetCurrentUser(int userID)
        {
            switch (status)
            {
                case 1://采用Session + Cookie保存
                    SetUserSession(userID);
                    SetUserCookie(userID);
                    break;
                case 2://采用Session保存
                    SetUserSession(userID);
                    break;
                case 3://采用Cookie保存
                    SetUserCookie(userID);
                    break;
                default://无登录状态

                    break;
            }
            return GetCurrentUser();
        }

        /// <summary>
        /// 清除当前用户的登录状态
        /// </summary>
        /// <param name="userID"></param>
        public void ClearCurrentUser(int userID)
        {
            switch (status)
            {
                case 1://清除Session + Cookie
                    ClearUserSession(userID);
                    ClearUserCookie(userID);
                    break;
                case 2://清除Session
                    ClearUserSession(userID);
                    break;
                case 3://清除Cookie
                    ClearUserCookie(userID);
                    break;
                default://无登录状态
                    break;
            }
        }

        #region Session
        /// <summary>
        /// 获取当前用户的Session对象
        /// </summary>
        /// <returns></returns>
        private int GetUserSession()
        {
            if (HttpContext.Current.Session["CurrentUser"] != null)
            {
                return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            return -1;
        }

        /// <summary>
        /// 设置当前用户的Session对象（新增或更新）
        /// </summary>
        /// <param name="userID"></param>
        private void SetUserSession(int userID)
        {
            HttpContext.Current.Session["CurrentUser"] = userID;
        }

        /// <summary>
        /// 清除当前用户的Session对象
        /// </summary>
        /// <param name="userID"></param>
        private void ClearUserSession(int userID)
        {
            HttpContext.Current.Session["CurrentUser"] = null;
        }
        #endregion

        #region Cookie
        /// <summary>
        /// 获取当前用户的Cookie对象
        /// </summary>
        /// <returns></returns>
        private int GetUserCookie()
        {
            //判断是否存在Cookie 存在即匹配数据库 匹配成功即返回
            HttpCookie cookie = Request.Cookies["CurrentUser"];
            if (cookie != null)
            {
                UserCookie uc = _userCookie.GetUserCookie(Convert.ToInt64(cookie.Values.Get("cookieid")));
                int userID = Convert.ToInt32(cookie.Values.Get("userid"));
                string pubKey = cookie.Values.Get("pubKey");
                string priKey = GetPrilicKey(userID, pubKey);//私钥 存入数据库
                string hostName = Request.UserHostName;
                string hostAddress = Request.UserHostAddress;

                //判断最终密文是否相等
                if (uc.Password == priKey)
                {
                    SetCurrentUser(userID);
                }
            }
            return -1;
        }

        /// <summary>
        /// 设置当前用户的Cookie对象（新增或更新）
        /// <param name="userID"></param>
        /// </summary>
        private void SetUserCookie(int userID)
        {
            //加密规则
            string pubKey = GetPublicKey();//公钥 放入cookie
            string priKey = GetPrilicKey(userID, pubKey);//私钥 存入数据库
            string hostName = Request.UserHostName;
            string hostAddress = Request.UserHostAddress;

            //存储到数据库
            Int64 cookieID = 123;//_userCookie.AddUserCookie(userID, hostName, hostAddress, priKey);

            //写入cookie
            HttpCookie cookie = new HttpCookie("CurrentUser");
            cookie.Values.Add("userid", userID.ToString());
            cookie.Values.Add("cookieid", cookieID.ToString());
            cookie.Values.Add("pubKey", pubKey);
            cookie.Expires = new DateTime(1900, 1, 1);
            //cookie.Domain = "";
        }

        /// <summary>
        /// 清除当前用户的Cookie对象
        /// </summary>
        /// <param name="userID"></param>
        private void ClearUserCookie(int userID)
        {
            HttpCookie cookie = new HttpCookie("CurrentUser");
            cookie.Expires = new DateTime(1900, 1, 1);
            Response.Cookies.Add(cookie);
        }
        #endregion

        #region 密钥生成规则
        /// <summary>
        /// 生成公钥
        /// </summary>
        /// <returns></returns>
        private String GetPublicKey()
        {
            return Text.GetRandomStr(16);//公钥 放入cookie
        }

        /// <summary>
        /// 生成私钥
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pubKey">公钥</param>
        /// <returns></returns>
        private String GetPrilicKey(int userID, string pubKey)
        {
            return Md5.Encrypt32(Md5.Encrypt16(pubKey) + userID);//私钥 存入数据库
        }
        #endregion
    }
}
