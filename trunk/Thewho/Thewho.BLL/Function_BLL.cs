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
	    /// 新增Function
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
	    /// 修改Function
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
	    /// 删除Function
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
        /// 获取Function
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
        /// 获取Function集合
        /// </summary>
        /// <returns></returns>
        public List<Function> GetList()
        {
            return _dal.SelectList();
        }
    }
}

