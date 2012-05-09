using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Thewho.BLL
{
    public class CurrentUser
    {
        
        public int status = 1;
        public int uid = -1; //-1为没有 0为登录失败或者没有
        public CurrentUser()
        {
        }

        /// <summary>
        /// 获取当前用户的登录对象
        /// </summary>
        /// <returns></returns>
        public Thewho.LogicModel.User GetThisUser()
        {
            Thewho.LogicModel.User thisUser = null;
            switch (status)
            {
                case 1://采用Session + Cookie验证
                    uid = GetUserSession();
                    uid = uid > 0 ? uid : GetUserCookie(true);
                    break;
                case 2://采用Session验证
                    uid = GetUserSession();
                    break;
                case 3://采用Cookie验证
                    uid = GetUserCookie(false);
                    break;
                default://无登录状态
                    uid = -1;
                    break;
            }
            if (uid > 0)
            {
                thisUser = new Thewho.LogicModel.User();
                thisUser.UID = uid;
            }
            return thisUser;
        }

        /// <summary>
        /// 设置当前用户为登录对象（新增或更新）
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Thewho.LogicModel.User SetThisUser(int uid)
        {
            Thewho.LogicModel.User thisUser = null;
            switch (status)
            {
                case 1://采用Session + Cookie保存
                    SetUserCookie(uid, true);
                    break;
                case 2://采用Session保存
                    SetUserSession(uid);
                    break;
                case 3://采用Cookie保存
                    SetUserCookie(uid, false);
                    break;
                default://无登录状态
                    uid = -1;
                    break;
            }
            thisUser = new Thewho.LogicModel.User();
            thisUser.UID = uid;
            return thisUser;
        }
        

        #region Session
        /// <summary>
        /// 获取当前用户的Session对象
        /// </summary>
        /// <returns></returns>
        public int GetUserSession()
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            return -1;
        }

        /// <summary>
        /// 设置当前用户的Session对象（新增或更新）
        /// </summary>
        /// <param name="uid">用户uid</param>
        public void SetUserSession(int uid)
        {
            HttpContext.Current.Session["UserID"] = uid;
        }

        /// <summary>
        /// 清除当前用户的Session对象
        /// </summary>
        /// <param name="uid">用户uid</param>
        public void ClearUserSession(int uid)
        {
            HttpContext.Current.Session["UserID"] = null;
        }
        #endregion

        #region Cookie
        /// <summary>
        /// 获取当前用户的Cookie对象
        /// </summary>
        /// <param name="isSetSession">获取到Cookie后 是否设置Session</param>
        /// <returns></returns>
        public int GetUserCookie(bool isSetSession)
        {
            //判断是否存在Cookie 存在即匹配数据库 匹配成功即返回
            if (true)
            {

            }
            return -1;
        }

        /// <summary>
        /// 设置当前用户的Cookie对象（新增或更新）
        /// <param name="uid">用户uid</param>
        /// <param name="isSetSession">设置Cookie后 是否设置Session</param>
        /// </summary>
        public void SetUserCookie(int uid, bool isSetSession)
        {
            //加密

            //存储到数据库


        }

        /// <summary>
        /// 清除当前用户的Cookie对象
        /// </summary>
        /// <param name="uid">用户uid</param>
        /// <param name="isSetSession">清除Cookie后 是否清除Session</param>
        public void ClearUserCookie(int uid, bool isSetSession)
        { 
            
        }
        #endregion
    }
}
