using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// UserGroup_BLL（逻辑层）
    /// </summary>
    public class UserGroup_BLL
    {
        private UserGroup_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public UserGroup_BLL()
        { 
            _dal = new  UserGroup_DAL();
        }
        
        /// <summary>
	    /// 新增UserGroup
	    /// </summary>
	    /// <param name="UserGroup">需要新增的对象</param>
	    /// <returns>新插入数据的GroupID</returns>
 	    public Int32 AddUserGroup(UserGroup obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改UserGroup
	    /// </summary>
	    /// <param name="UserGroup">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetUserGroup(UserGroup obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除UserGroup
	    /// </summary>
	    /// <param name="GroupID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeleteUserGroup(Int32 GroupID)
	    {			
		    if(GroupID > 0)
		    {
		        return _dal.Delete(GroupID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取UserGroup
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public UserGroup GetUserGroup(Int32 GroupID)
        {
            if(GroupID > 0)
		    {
		        return _dal.SelectObj(GroupID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取UserGroup集合
        /// </summary>
        /// <returns></returns>
        public List<UserGroup> GetList()
        {
            return _dal.SelectList();
        }
    }
}

