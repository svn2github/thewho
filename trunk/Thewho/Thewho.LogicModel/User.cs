using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Thewho.LogicModel
{
    /// <summary>
    /// 当前登录用户
    /// </summary>
    public class User
    {
        private Int32 _UID;

        public Int32 UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        private Thewho.Model.UserInfo _UserInfo;

        public Thewho.Model.UserInfo UserInfo
        {
            get { return _UserInfo; }
            set { _UserInfo = value; }
        }

        private Thewho.Model.UserReg _UserReg;

        public Thewho.Model.UserReg UserReg
        {
            get { return _UserReg; }
            set { _UserReg = value; }
        }

        private Thewho.Model.UserGroup _UserGroup;

        public Thewho.Model.UserGroup UserGroup
        {
            get { return _UserGroup; }
            set { _UserGroup = value; }
        }

        private Thewho.Model.UserLogin _UserLogin;

        public Thewho.Model.UserLogin UserLogin
        {
            get { return _UserLogin; }
            set { _UserLogin = value; }
        }

        private Thewho.Model.UserCookie _UserCookie;

        public Thewho.Model.UserCookie UserCookie
        {
            get { return _UserCookie; }
            set { _UserCookie = value; }
        }
    }
}
