using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// UserLogin_BLL（逻辑层）
    /// </summary>
    public class UserLogin_BLL
    {
        private UserLogin_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public UserLogin_BLL()
        { 
            _dal = new  UserLogin_DAL();
        }
        
        /// <summary>
	    /// 新增UserLogin
	    /// </summary>
	    /// <param name="UserLogin">需要新增的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public Int64 AddUserLogin(UserLogin obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改UserLogin
	    /// </summary>
	    /// <param name="UserLogin">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetUserLogin(UserLogin obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除UserLogin
	    /// </summary>
	    /// <param name="ID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeleteUserLogin(Int64 ID)
	    {			
		    if(ID > 0)
		    {
		        return _dal.Delete(ID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取UserLogin
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserLogin GetUserLogin(Int64 ID)
        {
            if(ID > 0)
		    {
		        return _dal.SelectObj(ID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取UserLogin集合
        /// </summary>
        /// <returns></returns>
        public List<UserLogin> GetList()
        {
            return _dal.SelectList();
        }
    }
}

