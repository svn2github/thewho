using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// UserReg_BLL（逻辑层）
    /// </summary>
    public class UserReg_BLL
    {
        private UserReg_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public UserReg_BLL()
        { 
            _dal = new  UserReg_DAL();
        }
        
        /// <summary>
	    /// 新增UserReg对象
	    /// </summary>
	    /// <param name="UserReg">需要新增的对象</param>
	    /// <returns>新插入数据的ID</returns>
 	    public Int32 AddUserReg(UserReg obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改UserReg对象
	    /// </summary>
	    /// <param name="UserReg">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetUserReg(UserReg obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除UserReg对象
	    /// </summary>
	    /// <param name="ID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeleteUserReg(Int32 ID)
	    {			
		    if(ID > 0)
		    {
		        return _dal.Delete(ID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取UserReg对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserReg GetUserReg(Int32 ID)
        {
            if(ID > 0)
		    {
		        return _dal.SelectObj(ID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取UserReg对象集合（全部）
        /// </summary>
        /// <returns></returns>
        public List<UserReg> GetList()
        {
            return _dal.SelectList();
        }
        
        /// <summary>
        /// 获取UserReg对象集合（分页 按ID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<UserReg> GetList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
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

