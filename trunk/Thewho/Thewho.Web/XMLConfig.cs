using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Thewho.Cache;
using System.Data;

namespace Thewho.Config
{
    public sealed class XMLConfig
    {
        public static byte LOGIN_STATUS = Convert.ToByte(GetItem("Site", "/Site/CurrentUser/Status"));

        /// <summary>
        /// 获取Xml文档中节点的值
        /// </summary>
        /// <param name="xmlName">Xml文档名，不需要爱带.xml后缀，如：Site</param>
        /// <param name="nodeName">节点需要带“/”斜杠，从根节点开始，直到最终需要取值的节点，如：/Site/CurrentUser/Status</param>
        /// <returns></returns>
        public static string GetItem(string xmlName, string nodeName)
        {
            if (XmlConfig_Cache.IsExist(nodeName, xmlName))
            {
                return XmlConfig_Cache.Get(nodeName, xmlName);
            }
            XmlDocument xml = GetXml(xmlName);
            string value = Thewho.Common.XmlHelper.Read(xml, nodeName);
            XmlConfig_Cache.Insert(nodeName, value, xmlName);
            return value;
        }

        /// <summary>
        /// 获取Xml文档
        /// </summary>
        /// <param name="xmlName">Xml文档名，不需要带.xml后缀，如：Site</param>
        /// <returns></returns>
        public static XmlDocument GetXml(string xmlName)
        {
            if (XmlConfig_Cache.IsExistXml(xmlName))
            {
                return XmlConfig_Cache.GetXml(xmlName);
            }
            string xmlPath = WebConfig.SITEPATH + @"\Configs\" + xmlName + ".xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            XmlConfig_Cache.InsertXml(xmlName, xmlPath, xml);
            return xml;
        }
    }
}
