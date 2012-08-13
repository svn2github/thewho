using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ${Model_NameSpace}$;
using ${DAL_NameSpace}$;

namespace ${BLL_NameSpace}$
{
    /// <summary>
    /// ${BLL_ClassName}$（逻辑层）
    /// </summary>
    public class ${BLL_ClassName}$
    {
        private ${DAL_ClassName}$ _dal = null;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        public ${BLL_ClassName}$()
        { 
            _dal = new  ${DAL_ClassName}$();
        }
        
        /// <summary>
	    /// 新增${Model_ClassName}$
	    /// </summary>
	    /// <param name="${Model_ClassName}$">需要新增的对象</param>
	    /// <returns>新插入数据的${PK_Name}$</returns>
 	    public ${PK_Type}$ Add${Model_ClassName}$(${Model_ClassName}$ obj)
	    {			
		    if(obj != null)
		    {
		        return Convert.ToInt32(_dal.InsertReturnID(obj));
		    }
		    return -1;
	    }
	    
	    /// <summary>
	    /// 修改${Model_ClassName}$
	    /// </summary>
	    /// <param name="${Model_ClassName}$">需要修改的对象</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Set${Model_ClassName}$(${Model_ClassName}$ obj)
	    {			
		    if(obj != null)
		    {
		        return _dal.Update(obj);
		    }
		    return -1;
	    }

	    /// <summary>
	    /// 删除${Model_ClassName}$
	    /// </summary>
	    /// <param name="${PK_Name}$">对象ID</param>
	    /// <returns>影响行数</returns>
 	    public Int32 Delete${Model_ClassName}$(${PK_Type}$ ${PK_Name}$)
	    {			
		    if(${PK_Name}$ > 0)
		    {
		        return _dal.Delete(${PK_Name}$);
		    }
		    return -1;
	    }

        /// <summary>
        /// 获取${Model_ClassName}$
        /// </summary>
        /// <param name="${PK_Name}$"></param>
        /// <returns></returns>
        public ${Model_ClassName}$ Get${Model_ClassName}$(${PK_Type}$ ${PK_Name}$)
        {
            if(${PK_Name}$ > 0)
		    {
		        return _dal.SelectObj(${PK_Name}$);
		    }
		    return null;
        }
        
        /// <summary>
        /// 获取${Model_ClassName}$集合
        /// </summary>
        /// <returns></returns>
        public List<${Model_ClassName}$> GetList()
        {
            return _dal.SelectList();
        }
    }
}
