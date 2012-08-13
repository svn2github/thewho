using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;

namespace TheCode.Common
{
    /// <summary>
    /// 模版帮助类
    /// </summary>
    public class Tempate
    {
        #region 主标签

        private static string Star = "${"; //标签的起始
        private static string End = "}$"; //标签的结束

        private static string NameSpace = "${NameSpace}$"; //命名空间
        private static string DatabaseName = "${DatabaseName}$"; //数据库名称
        private static string TableName = "${TableName}$"; //表名

        private static string Model_NameSpace = "${Model_NameSpace}$"; //模型层命名空间
        private static string DAL_NameSpace = "${DAL_NameSpace}$"; //数据层命名空间
        private static string BLL_NameSpace = "${BLL_NameSpace}$"; //逻辑层命名空间

        private static string Model_ClassName = "${Model_ClassName}$"; //模型层表的类名
        private static string DAL_ClassName = "${DAL_ClassName}$"; //数据层表的类名
        private static string BLL_ClassName = "${BLL_ClassName}$"; //逻辑层表的类名

        private static string PK_Name = "${PK_Name}$"; //主键名称
        private static string PK_Type = "${PK_Type}$"; //主键类型

        private static string Identity_Name = "${Identity_Name}$"; //自增长名称
        private static string Identity_Type = "${Identity_Type}$"; //自增长类型

        #endregion

        #region 字段标签

        private static string ColumnName_Template = "${ColumnName}$"; //字段名
        private static string IsPk_Template = "${IsPk}$"; //是否主键
        private static string IsIdentity_Template = "${IsIdentity}$"; //是否自增长
        private static string IsNull_Template = "${IsNull}$"; //是否可为空
        private static string DefaultValue_Template = "${DefaultValue}$"; //默认值
        private static string ColumnType_Template = "${ColumnType}$"; //字段类型 如:Int32
        private static string ConvertStr_Template = "${ConvertStr}$"; //字段Obj的转型方法 如:Convert.ToInt32({0})
        private static string ColumnByte_Template = "${ColumnByte}$"; //字节
        private static string ColumnLength_Template = "${ColumnLength}$"; //长度
        private static string ColumnRemark_Template = "${ColumnRemark}$"; //备注

        #endregion

        #region 循环标签

        private static string ForStar = "${ForStar}$"; //循环开始标签 一般用作循环字段  ":"后面带的参数
        private static string ForEnd = "${ForEnd}$"; //循环结束标签

        /*
            第一个是需要循环的数据源 (ForParmData必填)
            "ALL" 为所有字段
            "ALL_NOT_PK" 为除了主键字段外的所有字段
            "ALL_NOT_ID" 为除了自增长字段外的所有字段
            "ALL_NOT_PK_ID" 为除了主键字段,自增长字段外的所有字段

            第二个是需要在每次循环末尾加上的字符 (ForParmLast 选填) 如 ${For:"ALL",","}$
            ps:在选定了最末位补全字符 请在循环体中也加入，如：
            
            ${ForStar[ALL][,]}$new SqlParameter("@${ColumnName}$",obj.${ColumnName}$), <-- 此处也是要加的
		    ${ForEnd}$

         */

        #endregion

        #region 属性标签

        private static string ParmStar = "["; //属性标签的起始
        private static string ParmEnd = "]";  //属性标签的结束

        #endregion

        #region 模版路径变量

        private static string model_template = ConfigurationSettings.AppSettings["Model_Template"].ToString();//"../../Template/Model.js";
        private static string dal_template = ConfigurationSettings.AppSettings["DAL_Template"].ToString();//"../../Template/DAL.js";
        private static string bll_template = ConfigurationSettings.AppSettings["BLL_Template"].ToString();//"../../Template/BLL.js";

        #endregion

        #region 类名和文件后缀

        private static string model_suffix = ConfigurationSettings.AppSettings["Model_Suffix"].ToString();
        private static string dal_suffix = ConfigurationSettings.AppSettings["DAL_Suffix"].ToString();
        private static string bll_suffix = ConfigurationSettings.AppSettings["BLL_Suffix"].ToString();

        #endregion

        #region 正则

        //判断是否有标签 如果没有任何标签 那就不必要进行下面的操作(IsMatch)
        private Regex regIsTempate = new Regex(@"[\$][\{].*?[\}][\$]", RegexOptions.IgnoreCase);

        //循环标签正则(筛选出数组 Matches)
        private Regex regForArray = new Regex(@"[\$][\{]ForStar.*?[\}][\$].*?[\$][\{]ForEnd[\}][\$]", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        //循环标签的Star全文正则(筛选出ForStar全文 Matches)
        private Regex regForStar = new Regex(@"[\$][\{]ForStar.*?[\}][\$]", RegexOptions.IgnoreCase);

        //循环标签的参数正则(筛选出设定的参数属性 Matches )
        private Regex regForParm = new Regex(@"[\[].*?[\]]", RegexOptions.IgnoreCase);

        //转型字符串原始类型属性 ConvertTo 如 ${ConvertTo(dr["xxx"])}$
        private Regex regConvertTo = new Regex(@"[\$][\{]ConvertTo[\[].*?[\]][\}][\$]");

        public void SS(string str)
        {
            bool s = regIsTempate.IsMatch(str);
        }

        #endregion


        //循环的集合
        private MatchCollection forArray;
        //循环的参数集合
        private MatchCollection forParmArray;

        private int createType;
        private string createPath, nameSpace, databaseName, tableName;
        private string modelNameSpace, dalNameSpace, bllNameSpace;
        private List<TheCode.Model.Column> columnList = new List<TheCode.Model.Column>();
        private string tempateStr, columnStr, forStar, forParmData, forParmLast, forParmLine;
        private string ALL, ALL_NOT_PK, ALL_NOT_ID, ALL_NOT_PK_ID, lastChar;

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

        /// <summary>
        /// 启动模版引擎来解析代码
        /// </summary>
        public void Create()
        {
            //临时变量
            string tempsuffix = "";

            //第一步 读取模版的内容
            switch (createType)
            {
                case 1:
                    tempateStr = TheCode.Common.IO.ReadFile(model_template);
                    tempsuffix = model_suffix;
                    break;
                case 2:
                    tempateStr = TheCode.Common.IO.ReadFile(dal_template);
                    tempsuffix = dal_suffix;
                    break;
                case 3:
                    tempateStr = TheCode.Common.IO.ReadFile(bll_template);
                    tempsuffix = bll_suffix;
                    break;
            }

            //第二步 判断模版代码是否有模版标签需要解析
            if (regIsTempate.IsMatch(tempateStr))
            {
                //第三步 替换掉模版主标签
                tempateStr = ReplaceMain(tempateStr);

                //第四步 判断模版代码中是否有循环标签
                if (regForArray.IsMatch(tempateStr))
                {
                    tempateStr = ReplaceFor(tempateStr);
                }
            }

            //第五步 创建文件
            TheCode.Common.IO.WriteFile(@createPath, tableName + tempsuffix, tempateStr);

        }

        /// <summary>
        /// 替换主标签
        /// </summary>
        /// <param name="str">模版代码</param>
        /// <returns></returns>
        private string ReplaceMain(string str)
        {
            str = str.Replace(NameSpace, nameSpace);
            str = str.Replace(DatabaseName, databaseName);
            str = str.Replace(TableName, tableName);

            TheCode.Model.Column cl = GetPKColumn();
            if (cl != null)
            {
                str = str.Replace(PK_Name, cl.ColumnName);
                str = str.Replace(PK_Type, cl.ColumnType);
            }
            str = str.Replace(Model_NameSpace, modelNameSpace);
            str = str.Replace(DAL_NameSpace, dalNameSpace);
            str = str.Replace(BLL_NameSpace, bllNameSpace);

            str = str.Replace(Model_ClassName, tableName + model_suffix);
            str = str.Replace(DAL_ClassName, tableName + dal_suffix);
            str = str.Replace(BLL_ClassName, tableName + bll_suffix);

            return str;
        }

        /// <summary>
        /// 替换循环标签
        /// </summary>
        /// <param name="str">模版代码</param>
        /// <returns></returns>
        private string ReplaceFor(string str)
        {
            forArray = regForArray.Matches(tempateStr);
            for (int i = 0; i < forArray.Count; i++)
            {
                columnStr = forArray[i].Value.TrimEnd();
                forStar = regForStar.Matches(columnStr)[0].Value;

                forParmArray = regForParm.Matches(forStar);

                //forParmType = forParmArray.Count > 0 ? ReplacePram(forParmArray[0].Value) : null;
                forParmData = forParmArray.Count > 0 ? ReplacePram(forParmArray[0].Value) : null;
                forParmLast = forParmArray.Count > 1 ? ReplacePram(forParmArray[1].Value) : null;
                //forParmLine = forParmArray.Count > 2 ? ReplacePram(forParmArray[2].Value) : null;


                //数据源
                List<TheCode.Model.Column> list = new List<TheCode.Model.Column>(); 
                if (forParmData == "ALL") //全部字段
                {
                    list = columnList;
                }
                else if (forParmData == "ALL_NOT_PK")//除主键
                {
                    list = GetNotPkColumnList();
                    //list.Remove(GetPKColumn());
                }
                else if (forParmData == "ALL_NOT_ID")//除自增长ID 一般用这个
                {
                    list = GetNotIDColumnList();
                    //list.Remove(GetIDColumn());
                }
                else if (forParmData == "ALL_NOT_PK_ID")//除主键 除自增长ID
                {
                    list = GetNotPKIDColumnList();
                   // list.Remove(GetPKColumn());
                    //list.Remove(GetIDColumn());
                }

                //最后一个字段
                lastChar = null;
                if (forParmLast != "null" && !string.IsNullOrEmpty(forParmLast))
                {
                    lastChar = forParmLast;
                }

                //去掉循环的标签
                columnStr = columnStr.Replace(forStar, "");
                columnStr = columnStr.Replace(ForEnd, "");

                //临时变量
                string temp = "";
                for (int j = 0; j < list.Count; j++)
                {
                    temp += ReplaceColumn(columnStr, list[j], lastChar, true);
                }
                if (!string.IsNullOrEmpty(temp))
                {
                    columnStr = lastChar == null ? temp : temp.Remove(temp.LastIndexOf(lastChar));
                }

                
                //columnStr = ReplacePram(columnStr);

                str = str.Replace(forArray[i].Value, columnStr);
            }
            return str;
        }


        /// <summary>
        /// 替换属性标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ReplacePram(string str)
        {
            str = str.Replace(ParmStar, "");
            str = str.Replace(ParmEnd, "");
            return str;
        }

        /// <summary>
        /// 替换字段标签
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <param name="lastChar"></param>
        /// <param name="isline"></param>
        /// <returns></returns>
        private string ReplaceColumn(string str, TheCode.Model.Column c, string lastChar, bool isLine)
        {

            str = str.Replace(NameSpace, nameSpace);
            str = str.Replace(DatabaseName, databaseName);
            str = str.Replace(TableName, tableName);
            str = str.Replace(ColumnName_Template, c.ColumnName);

            //转型
            if (regConvertTo.IsMatch(str))
	        {
                string temp = regConvertTo.Matches(str)[0].Value;
        		str = str.Replace(temp, String.Format(c.ConvertStr,temp.Replace("${ConvertTo[","").Replace("]}$","")));
	        }

            str = str.Replace(IsPk_Template, c.IsPk == "1" ? "[主键] " : "");
            str = str.Replace(IsIdentity_Template, c.IsIdentity == "1" ? "[自增长] " : "");
            str = str.Replace(IsNull_Template, c.IsNull == "1" ? "[可为空] " : "");
            str = str.Replace(DefaultValue_Template, c.DefaultValue != "" ? "[默认值：" + c.DefaultValue.Replace("(", "").Replace(")", "") + "] " : "");
            str = str.Replace(ColumnType_Template, c.ColumnType);
            str = str.Replace(ColumnByte_Template, c.ColumnByte);
            str = str.Replace(ColumnLength_Template, c.ColumnLength);
            str = str.Replace(ColumnRemark_Template, c.ColumnRemark != "" ? "[备注：" + c.ColumnRemark + "] " : "");
            
            //添加最后一个字符
            //if (!string.IsNullOrEmpty(lastChar))
            //{
            //    str = str + Convert.ToString(lastChar);
            //}
           
            return str;
        }

        /// <summary>
        /// 获取这个表的主键
        /// </summary>
        /// <param name="columnList">表的字段集合</param>
        /// <returns></returns>
        private TheCode.Model.Column GetPKColumn()
        {
            TheCode.Model.Column cl = null;
            foreach (TheCode.Model.Column item in columnList)
            {
                //如果找到了主键 直接用主键
                if (item.IsPk == "1")
                {
                    return item;
                }
                //else if (item.IsIdentity == "1")//如果没有 就用自增长
                //{
                //    cl = new TheCode.Model.Column();
                //    if (cl == null) //如果有多个自增长 就用第一个
                //    {
                //        cl = item;
                //    }
                //}
            }
            return cl;
        }

        /// <summary>
        /// 获取 排除这个表的主键后的集合
        /// </summary>
        /// <returns></returns>
        private List<TheCode.Model.Column> GetNotPkColumnList()
        {
            List<TheCode.Model.Column> list = new List<TheCode.Model.Column>();
            foreach (TheCode.Model.Column item in columnList)
            {
                if (item.IsPk != "1")
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取这个表的自增长字段
        /// </summary>
        /// <param name="columnList">表的字段集合</param>
        /// <returns></returns>
        private TheCode.Model.Column GetIDColumn()
        {
            TheCode.Model.Column cl = null;
            foreach (TheCode.Model.Column item in columnList)
            {
                if (item.IsIdentity == "1")
                {
                    return item;
                    //cl = new TheCode.Model.Column();
                    //if (cl == null) //如果有多个自增长 就用第一个
                    //{
                    //    cl = item;
                    //}
                }
            }
            return cl;
        }

        /// <summary>
        /// 获取 排除这个表的自增长ID后的集合
        /// </summary>
        /// <returns></returns>
        private List<TheCode.Model.Column> GetNotIDColumnList()
        {
            List<TheCode.Model.Column> list = new List<TheCode.Model.Column>();
            foreach (TheCode.Model.Column item in columnList)
            {
                if (item.IsIdentity != "1")
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取 排除这个表的主键,自增长ID后的集合
        /// </summary>
        /// <returns></returns>
        private List<TheCode.Model.Column> GetNotPKIDColumnList()
        {
            List<TheCode.Model.Column> list = new List<TheCode.Model.Column>();
            foreach (TheCode.Model.Column item in columnList)
            {
                if (item.IsIdentity != "1" && item.IsPk != "1")
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 驼峰命名法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string CamelCase(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                if (str.Length > 1)
                {
                    str = str.Substring(0, 1).ToLower() + str.Substring(1, str.Length);
                }
                str = str.ToLower();
            }
            return str;
        }
    }
}
