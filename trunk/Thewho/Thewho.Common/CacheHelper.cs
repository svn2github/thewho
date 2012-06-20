using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;

namespace Thewho.Common
{
    /// <summary>
    /// 缓存操作基类
    /// </summary>
    public class CacheHelper<T>
    {
        private static readonly System.Web.Caching.Cache _cache = HttpRuntime.Cache; //缓存实例

        /// <summary>
        /// 构造方法
        /// </summary>
        public CacheHelper()
        { 
            
        }

        /// <summary>
        /// 创建/修改Cache (当指定键的Cache已经存在时, 将覆盖/修改)
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="expires">有效期/秒数</param>
        /// <param name="priority">优先级</param>
        public static void Insert(String key, Object value, Int32 expires, String priority)
        {
            TimeSpan ts = TimeSpan.FromSeconds(expires);
            DateTime absoluteExpiration = DateTime.MaxValue;

            _cache.Insert(key, value, null, absoluteExpiration, ts);
        }

        public static void Add(String key, Object value, Int32 expires, String priority)
        { 
            
        }

        public static bool Remove(String key)
        {
            if (IsExist(key))
            {
                _cache.Remove(key);
                return true;
            }
            return false; //不存在 ? 或者失败
        }

        /// <summary>
        /// 根据Cache键获得缓存对象的Cache值
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <returns></returns>
        public static T Get(String key)
        {
            if (_cache[key] != null)
            {
                return (T)_cache[key];
            }
            return default(T);
        }

        /// <summary>
        /// 根据Cache键判断是否存在该缓存对象
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <returns>是否存在</returns>
        public static bool IsExist(String key)
        {
            if (_cache[key] != null)
	        {
        		 return true;
	        }
            return false;
        }


        ///// <summary>
        ///// 获得所有的缓存对象集合
        ///// </summary>
        ///// <returns></returns>
        //public static IDictionaryEnumerator GetList()
        //{
        //    IDictionaryEnumerator enumerator = null;
        //    if (_cache.Count > 0)
        //    {
        //        enumerator = _cache.GetEnumerator();
        //    }
        //    return enumerator;
        //}

        /// <summary>
        /// 获得所有的缓存对象集合
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string,string> GetList()
        {
            Dictionary<string, string> list = null;
            if (_cache.Count > 0)
            {
                IDictionaryEnumerator enumerator = _cache.GetEnumerator();
                if (enumerator != null)
                {
                    list = new Dictionary<string, string>();
                    while (enumerator.MoveNext())
                    {
                        list.Add(Convert.ToString(enumerator.Key), Convert.ToString(enumerator.Value));
                    }
                }
            }
            return list;
        }
    }
}
