using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace SrcToReplace
{
    /// <summary>
    /// Session 的摘要说明。
    /// </summary>
    public class Session : DictionaryBase
    {
        private static Session assion = null;
        /// <summary>
        /// 生成一个实例
        /// </summary>
        private Session()
        {

        }
        /// <summary>
        /// 得到一个单身实例
        /// </summary>
        /// <returns>返回类型为Session</returns>
        public static Session GetSession()
        {
            if (Session.assion == null)
            {
                Session.assion = new Session();
            }
            return Session.assion;
        }
        /// <summary>
        /// 添加新成员
        /// </summary>
        /// <param name="newID">新字成员名字</param>
        /// <param name="newmember">新成员</param>
        public void Add(string newID, Object newmember)
        {
            try
            {
                Dictionary.Add(newID, newmember);
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="memberID"></param>
        public void Remove(string memberID)
        {
            try
            {
                Dictionary.Remove(memberID);
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 本类的索引器
        /// </summary>
        /// <returns>返回Object成员</returns>
        public Object this[string memberID]
        {
            get
            {
                try
                {
                    Object obj = (Object)Dictionary[memberID];
                    Dictionary.Remove(memberID);//销毁
                    return obj;

                }
                catch
                {
                    return null;//如果没有数据则返回null
                }
            }
            set
            {
                try
                {
                    this.Dictionary.Add(memberID, value);
                }
                catch
                {
                    return;
                }
            }
        }
    }

}
