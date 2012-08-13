using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// UserCookie_BLL（逻辑层）
    /// </summary>
    public class UserCookie_BLL
    {
        private UserCookie_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public UserCookie_BLL()
        { 
            _dal = new  UserCookie_DAL();
        }
        
        /// <summary>
	    /// 新增UserCookie
	    /// </summary>
	    /// <param name="UserCookie">需要新增的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public Int64 AddUserCookie(UserCookie obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改UserCookie
	    /// </summary>
	    /// <param name="UserCookie">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetUserCookie(UserCookie obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除UserCookie
	    /// </summary>
	    /// <param name="ID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeleteUserCookie(Int64 ID)
	    {			
		    if(ID > 0)
		    {
		        return _dal.Delete(ID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取UserCookie
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserCookie GetUserCookie(Int64 ID)
        {
            if(ID > 0)
		    {
		        return _dal.SelectObj(ID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取UserCookie集合
        /// </summary>
        /// <returns></returns>
        public List<UserCookie> GetList()
        {
            return _dal.SelectList();
        }
    }
}

