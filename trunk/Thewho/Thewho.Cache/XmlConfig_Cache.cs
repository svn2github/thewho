using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Thewho.Common;
using System.Web.Caching;

namespace Thewho.Cache
{
    public class XmlConfig_Cache
    {
        public const string XML = "/Xml/";
        public const string C_XML = Thewho.Const.Cache.TYPE_CONFIG + XML; //目前字符为C/Xml Xml文档缓存为：C/Xml/Site  Xml文档节点缓存为：C/Xml/Site/Site/CurrentUser/Status

        #region Xml文档缓存
        /// <summary>
        /// 新增Xml文档缓存
        /// </summary>
        /// <param name="xmlName">Xml文档名</param>
        /// <param name="xmlPath">Xml文档路径，用户缓存移除依赖</param>
        /// <param name="obj">Xml文档对象</param>
        public static void InsertXml(String xmlName, String xmlPath, XmlDocument obj)
	    {
            CacheDependency cd = new CacheDependency(@xmlPath);//Xml文件依赖
            CacheHelper<XmlDocument>.Insert(C_XML + xmlName, obj, cd);//永不过期
	    }

        /// <summary>
        /// 移除Xml文档缓存
        /// </summary>
        /// <param name="xmlName">Xml文档名</param>
        public static void DeleteXml(String xmlName)
	    {
            CacheHelper<XmlDocument>.Remove(C_XML + xmlName);
	    }

        /// <summary>
        /// 获取Xml文档缓存
        /// </summary>
        /// <param name="xmlName">Xml文档名</param>
        public static XmlDocument GetXml(String xmlName)
        {
            return CacheHelper<XmlDocument>.Get(C_XML + xmlName);
        }

        /// <summary>
        /// 判断Xml文档缓存是否存在
        /// </summary>
        /// <param name="xmlName">Xml文档名</param>
        public static bool IsExistXml(String xmlName)
        {
            return CacheHelper<XmlDocument>.IsExist(C_XML + xmlName);
        }
        #endregion

        #region Xml文档节点缓存
        /// <summary>
        /// 新增Xml文档节点缓存
        /// </summary>
        /// <param name="key">Xml文档节点字符串，如：/Site/CurrentUser/Status</param>
        /// <param name="value">Xml文档节点的值</param>
        /// <param name="xmlName">Xml文档名</param>
        public static void Insert(String key, String value, String xmlName)
        {
            CacheDependency cd = new CacheDependency(null, new string[] { C_XML + xmlName });//以Xml文档缓存为缓存依赖
            CacheHelper<String>.Insert(C_XML + xmlName + key, value, cd);//永不过期
        }

        /// <summary>
        /// 移除Xml文档节点缓存
        /// </summary>
        /// <param name="key">Xml文档节点字符串，如：/Site/CurrentUser/Status</param>
        /// <param name="xmlName">Xml文档名</param>
        public static void Delete(String key, String xmlName)
        {
            CacheHelper<String>.Remove(C_XML + xmlName + key);
        }

        /// <summary>
        /// 获取Xml文档节点缓存
        /// </summary>
        /// <param name="key">Xml文档节点字符串，如：/Site/CurrentUser/Status</param>
        /// <param name="xmlName">Xml文档名</param>
        public static String Get(String key, String xmlName)
        {
            return CacheHelper<String>.Get(C_XML + xmlName + key);
        }

        /// <summary>
        /// 判断Xml文档节点缓存是否存在
        /// </summary>
        /// <param name="key">Xml文档节点字符串，如：/Site/CurrentUser/Status</param>
        /// <param name="xmlName">Xml文档名</param>
        public static bool IsExist(String key, String xmlName)
        {
            return CacheHelper<String>.IsExist(C_XML + xmlName + key);
        }
        #endregion
    }
}
