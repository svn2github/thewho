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
	    /// 新增Permission对象
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
	    /// 修改Permission对象
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
	    /// 删除Permission对象
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
        /// 获取Permission对象
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
        /// 获取Permission对象集合（全部）
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetList()
        {
            return _dal.SelectList();
        }
        
        /// <summary>
        /// 获取Permission对象集合（分页 按PermissionID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<Permission> GetList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
        {
            if(pageIndex > 0 && pageSize > 0)
		    {
                return _dal.SelectList(pageIndex, pageSize, out recordCount);
            }
            recordCount = 0;
            return null;
        }
    }
}

