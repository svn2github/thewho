using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.Common;
using System.Web.Caching;

namespace Thewho.Cache
{
    public class User_Cache
    {
        public const string USER = "/User/";
        public const string M_USER = Thewho.Const.Cache.TYPE_MODEL + USER; //最终字符串 M/User/123 如此

        public const int USER_EXPIRES = Thewho.Const.Cache.TIME_MINUTE * 1;//缓存有效期 6个小时
        public const CacheItemPriority USER_PRIORITY = CacheItemPriority.Default; //缓存优先级 Default

        public static void Insert(Int32 UserID, User obj)
	    {
            CacheDependency cd = null;//new CacheDependency(@"F:\Project\trunk\Thewho\Thewho.Web\Configs\players.xml");
            CacheHelper<User>.Insert(M_USER + UserID, obj, cd, USER_EXPIRES, CacheItemPriority.Default);
	    }

        public static void Delete(Int32 UserID)
	    {			
		    CacheHelper<User>.Remove(M_USER + UserID);
	    }

        public static User Get(Int32 UserID)
        {
            return CacheHelper<User>.Get(M_USER + UserID);
        }

        public static bool IsExist(Int32 UserID)
        {
            return CacheHelper<User>.IsExist(M_USER + UserID);
        }
    }
}
