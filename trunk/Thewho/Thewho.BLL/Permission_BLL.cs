using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// Permission_BLL（逻辑层）
    /// </summary>
    public class Permission_BLL
    {
        private Permission_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public Permission_BLL()
        { 
            _dal = new  Permission_DAL();
        }
        
        /// <summary>
	    /// 新增Permission
	    /// </summary>
	    /// <param name="Permission">需要新增的对象</param>
	    /// <returns>新插入数据的PermissionID</returns>
 	    public Int32 AddPermission(Permission obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改Permission
	    /// </summary>
	    /// <param name="Permission">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetPermission(Permission obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除Permission
	    /// </summary>
	    /// <param name="PermissionID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeletePermission(Int32 PermissionID)
	    {			
		    if(PermissionID > 0)
		    {
		        return _dal.Delete(PermissionID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取Permission
        /// </summary>
        /// <param name="PermissionID"></param>
        /// <returns></returns>
        public Permission GetPermission(Int32 PermissionID)
        {
            if(PermissionID > 0)
		    {
		        return _dal.SelectObj(PermissionID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取Permission集合
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetList()
        {
            return _dal.SelectList();
        }
    }
}

