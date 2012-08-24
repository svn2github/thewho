using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thewho.Model;
using Thewho.DAL;

namespace Thewho.BLL
{
    /// <summary>
    /// Function_BLL（逻辑层）
    /// </summary>
    public class Function_BLL
    {
        private Function_DAL _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public Function_BLL()
        { 
            _dal = new  Function_DAL();
        }
        
        /// <summary>
	    /// 新增Function对象
	    /// </summary>
	    /// <param name="Function">需要新增的对象</param>
	    /// <returns>新插入数据的FunctionID</returns>
 	    public Int32 AddFunction(Function obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改Function对象
	    /// </summary>
	    /// <param name="Function">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 SetFunction(Function obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除Function对象
	    /// </summary>
	    /// <param name="FunctionID">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 DeleteFunction(Int32 FunctionID)
	    {			
		    if(FunctionID > 0)
		    {
		        return _dal.Delete(FunctionID);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取Function对象
        /// </summary>
        /// <param name="FunctionID"></param>
        /// <returns></returns>
        public Function GetFunction(Int32 FunctionID)
        {
            if(FunctionID > 0)
		    {
		        return _dal.SelectObj(FunctionID);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取Function对象集合（全部）
        /// </summary>
        /// <returns></returns>
        public List<Function> GetList()
        {
            return _dal.SelectList();
        }
        
        /// <summary>
        /// 获取Function对象集合（分页 按FunctionID降序）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="recordCount">数据总数/输出参数</param>
        /// <returns></returns>
        public List<Function> GetList(Int32 pageIndex, Int32 pageSize, out Int32 recordCount)
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

