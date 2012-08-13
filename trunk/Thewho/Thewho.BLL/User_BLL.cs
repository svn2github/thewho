using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// User_BLL（逻辑层）
    /// </summary>
    public class User_BLL
    {
        private User_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public User_BLL()
        { 
            _dal = new  User_DAL();
        }
        
        /// <summary>
	    /// 新增User
	    /// </summary>
	    /// <param name="User">需要新增的对象</param>
	    /// <returns>新插入数据的UserID</returns>
 	    public Int32 AddUser(User obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改User
	    /// </summary>
	    /// <param name="User">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetUser(User obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除User
	    /// </summary>
	    /// <param name="UserID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeleteUser(Int32 UserID)
	    {			
		    if(UserID > 0)
		    {
		        return _dal.Delete(UserID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取User
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public User GetUser(Int32 UserID)
        {
            if(UserID > 0)
		    {
		        return _dal.SelectObj(UserID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取User集合
        /// </summary>
        /// <returns></returns>
        public List<User> GetList()
        {
            return _dal.SelectList();
        }
    }
}

