using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;

namespace TheCode.Common
{
    /// <summary>
    /// 模版帮助类
    /// </summary>
    public class Tempate
    {
        #region 主标签
        private static string NameSpace_Template = "$NameSpace";
        private static string DatabaseName_Template = "$DatabaseName";
        private static string TableName_Template = "$TableName";

        private static string ModelNameSpace_Template = "$ModelNameSpace";
        private static string DalNameSpace_Template = "$DalSpace";
        private static string BllNameSpace_Template = "$BllNameSpace";

        private static string PK_ColumnName_Template = "$PK_ColumnName";
        private static string PK_ColumnType_Template = "$PK_ColumnType";

        #endregion

        #region 循环标签
        private static string Star_Template = "$Star";
        private static string End_Template = "$End";
        private static string LastChar_Template = "[#LastChar=";
        private static string ConvertTo_Template = "$ConvertTo[#";

        private static string Attr_Star_Template = "[#";
        private static string Attr_End_Template = "#]";
        #endregion

        #region 字段标签
        private static string ColumnName_Template = "$ColumnName";
        private static string IsPk_Template = "$IsPk";
        private static string IsIdentity_Template = "$IsIdentity";
        private static string IsNull_Template = "$IsNull";
        private static string DefaultValue_Template = "$DefaultValue";
        private static string ColumnType_Template = "$ColumnType";
        private static string ConvertStr_Template = "$ConvertStr";
        private static string ColumnByte_Template = "$ColumnByte";
        private static string ColumnLength_Template = "$ColumnLength";
        private static string ColumnRemark_Template = "$ColumnRemark";
        #endregion

        #region 模版路径变量
        private static string model_template = ConfigurationSettings.AppSettings["Model_Template"].ToString();//"../../Template/Model.js";
        private static string dal_template = ConfigurationSettings.AppSettings["DAL_Template"].ToString();//"../../Template/DAL.js";
        private static string bll_template = ConfigurationSettings.AppSettings["BLL_Template"].ToString();//"../../Template/BLL.js";
        #endregion

        private int createType;
        private string createPath, nameSpace, databaseName, tableName;
        private string modelNameSpace, dalNameSpace, bllNameSpace;
        private List<TheCode.Model.Column> columnList = new List<TheCode.Model.Column>();
        private string tempateStr, columnStr, lastChar, convertStr;
        private string[] attrArray;

         

        //筛选循环标签正则                                                         //单行                   //不区分大小写
        private Regex regArray = new Regex(@"[$]Star.*?[$]End", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

        //是否拥有最后字符属性 LastChar 如 $Star[LastChar=xxx]
        private Regex regLastChar = new Regex(@"\[\#LastChar=.*?\#\]");

        //转型字符串原始类型属性 ConvertTo 如 $Star[LastChar=xxx]
        private Regex regConvertTo = new Regex(@"[$]ConvertTo\[\#.*?\=.*?\#\]");

        //循环集合
        private MatchCollection matchArray; 
        //private MatchCollection matchLastCharArray;

        /// <summary>
        /// 模版帮助类 构造方法
        /// </summary>
        /// <param name="createType">生成类型 （模型层 | 数据层 | 逻辑层）</param>
        /// <param name="createPath">生成路径</param>
        /// <param name="nameSpace">命名空间(当前)</param>
        /// <param name="databaseName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnList">表的字段集合</param>
        /// <param name="modelNameSpace">模型层命名空间</param>
        /// <param name="dalNameSpace">数据层命名空间</param>
        /// <param name="bllNameSpace">逻辑层命名空间</param>
        public Tempate(int createType, string createPath, string nameSpace, string databaseName, string tableName, List<TheCode.Model.Column> columnList,
            string modelNameSpace, string dalNameSpace, string bllNameSpace
            )
        {
            this.createType = createType;
            this.createPath = createPath;
            this.nameSpace = nameSpace;
            this.databaseName = databaseName;
            this.tableName = tableName;
            this.columnList = columnList;

            this.modelNameSpace = modelNameSpace;
            this.dalNameSpace = dalNameSpace;
            this.bllNameSpace = bllNameSpace;
        }

        public void create()
        {
            //第一步 读取模版的内容
            switch (createType)
            {
                case 1:
                    tempateStr = TheCode.Common.IO.ReadFile(model_template);
                    break;
                case 2:
                    tempateStr = TheCode.Common.IO.ReadFile(dal_template);
                    break;
                case 3:
                    tempateStr = TheCode.Common.IO.ReadFile(bll_template);
                    break;
            }
            tempateStr = replaceMain(tempateStr);

            //绑定循环
            if (regArray.IsMatch(tempateStr))
            {
                matchArray = regArray.Matches(tempateStr);
                for (int i = 0; i < matchArray.Count; i++)
                {
                    columnStr = matchArray[i].Value;

                    for (int j = 0; j < columnList.Count; j++)
                    {
                        if (j == 0 && j != columnList.Count -1)
                        {
                            columnStr = replaceColumn(matchArray[i].Value,false,columnList[j]);
                            columnStr = replaceFor(columnStr);
                        }
                        else if (j == columnList.Count - 1) //只有最后一个字段才去除逗号
                        {
                            columnStr += replaceColumn(matchArray[i].Value, true, columnList[j]);
                            columnStr = replaceFor(columnStr);
                        }
                        else
                        {
                            columnStr += replaceColumn(matchArray[i].Value, false, columnList[j]);
                            columnStr = replaceFor(columnStr);
                        }
                    }
                    tempateStr = tempateStr.Replace(matchArray[i].Value, columnStr);
                }
            }
            TheCode.Common.IO.WriteFile(@createPath, tableName, tempateStr);
        }

        private string columnArray(string str)
        {
            string[] sAyyay = str.Replace("$Star", "@").Split('@');
            string[] eAyyay = str.Replace("$End", "@").Split('@');

            //这里需要优化…… 判断Star和End出现的次数
            int starNum = sAyyay.Length - 1;
            int endNum = eAyyay.Length - 1;

            if (starNum == endNum)
            {
                return "yes";
            }
            else
            {
                return "循环标签未结尾或者未开始";
            }
        }

        /// <summary>
        /// 替换主标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string replaceMain(string str)
        {
            str = str.Replace(NameSpace_Template, nameSpace);
            str = str.Replace(DatabaseName_Template, databaseName);
            str = str.Replace(TableName_Template, tableName);

            TheCode.Model.Column cl = GetPk();
            if (cl != null)
            {
                str = str.Replace(PK_ColumnName_Template, cl.ColumnName);
                str = str.Replace(PK_ColumnType_Template, cl.ColumnType);
            }
            str = str.Replace(ModelNameSpace_Template, modelNameSpace);
            str = str.Replace(DalNameSpace_Template, dalNameSpace);
            str = str.Replace(BllNameSpace_Template, bllNameSpace);
            
            return str;
        }

        /// <summary>
        /// 替换循环标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string replaceFor(string str)
        {
            str = str.Replace(Star_Template, "");
            str = str.Replace(End_Template, "");
            //if (regLastChar.IsMatch(str))
            //{
            //    lastChar = regLastChar.Matches(str)[0].Value;
            //    str = str.Replace(lastChar, "");
            //    lastChar = lastChar.Replace(LastChar_Star_Template, "");
            //    lastChar = lastChar.Replace(LastChar_End_Template, "");
            //    str += lastChar;

            //    //switch (lastNo)
            //    //{
            //    //    case 1:
            //    //        //str = str.Substring(lastChar.Length, str.Length -1);
            //    //        str = str.Replace(lastChar, "");
            //    //        break;
            //    //    case -1:
            //    //        str = str.Substring(0, str.Length - lastChar.Length);
            //    //        break;
            //    //    default:
            //    //        break;
            //    //}
            //}
            return str;
        }

        /// <summary>
        /// 替换字段标签
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private string replaceColumn(string str, bool isLast, TheCode.Model.Column c)
        {
            lastChar = string.Empty;
            convertStr = string.Empty;

            #region 循环字段间隔字符串 最后一个字符的处理
            if (regLastChar.IsMatch(str))
            {
                lastChar = regLastChar.Matches(str)[0].Value;
                str = str.Replace(lastChar, "");
                lastChar = lastChar.Replace(LastChar_Template, "");
                lastChar = lastChar.Replace(Attr_End_Template, "");
            }
            #endregion


            str = str.Replace(NameSpace_Template, nameSpace);
            str = str.Replace(DatabaseName_Template, databaseName);
            str = str.Replace(TableName_Template, tableName);
            str = str.Replace(ColumnName_Template, c.ColumnName);

            #region 转型
            if (regConvertTo.IsMatch(str))
            {
                str = str.Replace(ConvertStr_Template, c.ConvertStr);
                convertStr = regConvertTo.Matches(str)[0].Value;
                convertStr = convertStr.Replace(ConvertTo_Template, "");
                convertStr = convertStr.Replace(Attr_End_Template, "");

                //第一个为转型的字符串 第二个为原始类型
                attrArray = convertStr.Split('=');
                convertStr = String.Format(attrArray[0], attrArray[1]);

                str = str.Replace(regConvertTo.Matches(str)[0].Value, convertStr);
            }
            else
            {
                convertStr = "(" + c.ColumnType + ")" + c.ColumnName;
                str = str.Replace(ConvertStr_Template, convertStr);
            }
            #endregion

            str = str.Replace(IsPk_Template, c.IsPk == "1" ? "[主键] " :"");
            str = str.Replace(IsIdentity_Template, c.IsIdentity == "1" ? "[自增长] " : "");
            str = str.Replace(IsNull_Template, c.IsNull == "1" ? "[可为空] " : "");
            str = str.Replace(DefaultValue_Template, c.DefaultValue != "" ? "[默认值：" + c.DefaultValue.Replace("(", "").Replace(")", "") + "] " : "");
            str = str.Replace(ColumnType_Template, c.ColumnType);
            str = str.Replace(ColumnByte_Template, c.ColumnByte);
            str = str.Replace(ColumnLength_Template, c.ColumnLength);
            str = str.Replace(ColumnRemark_Template, c.ColumnRemark != "" ? "[备注：" + c.ColumnRemark + "] " : "");

            //最后一个循环则不加LastChar
            if (isLast)
            {
                //str = str.Replace(ColumnName_Template, c.ColumnName);
            }
            else
            {
                str += lastChar;
            }

            return str;
        }

        /// <summary>
        /// 获取这个表的主键
        /// </summary>
        /// <param name="columnList">表的字段集合</param>
        /// <returns></returns>
        private TheCode.Model.Column GetPk()
        {
            TheCode.Model.Column cl = null;
            foreach (TheCode.Model.Column item in columnList)
            {
                //如果找到了主键 直接用主键
                if (item.IsPk == "1")
                {
                    return item;
                }//如果没有 就用自增长
                else if (item.IsIdentity == "1")
                {
                    cl = new TheCode.Model.Column();
                    if (cl == null) //如果有多个自镇长 就用第一个
                    {
                        cl = item;
                    }
                }
            }
            return cl;
        }
    }
}
