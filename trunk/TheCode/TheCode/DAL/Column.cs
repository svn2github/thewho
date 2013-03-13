using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TheCode.DAL
{
    public class Column
    {
        public string SQL_SELECT = @"use {0} select 
        [ColumnName]=a.Name, 
        [TableName]=c.Name, 
        [IsPk]=case when exists(select 1 from sys.objects x join sys.indexes y on x.Type=N'PK' and x.Name=y.Name 
                            join sysindexkeys z on z.ID=a.Object_id and z.indid=y.index_id and z.Colid=a.Column_id)
                        then '1' else '0' end, 
        [IsIdentity]   = case when COLUMNPROPERTY(  a.object_id,a.name,'IsIdentity')=1 then '1' else '0' end,
        [IsNull]=case when a.is_nullable=1 then '1' else '0' end, 
        [DefaultValue]=isnull(d.text,''), 
        [ColumnType]=b.Name, 
        [ColumnByte]=case when a.[max_length]=-1 and b.Name!='xml' then 'max/2G' 
                when b.Name='xml' then '2^31-1字节/2G'
                else rtrim(a.[max_length]) end, 
        [ColumnLength]=case when ColumnProperty(a.object_id,a.Name,'Precision')=-1 then '2^31-1'
                    else rtrim(ColumnProperty(a.object_id,a.Name,'Precision')) end, 
        [ColumnRemark]=isnull(e.[value],'')
        from 
            sys.columns a
        left join
            sys.types b on a.user_type_id=b.user_type_id
        inner join
            sys.objects c on a.object_id=c.object_id and c.Type='U'
        left join
            syscomments d on a.default_object_id=d.ID
        left join
            sys.extended_properties e on e.major_id=c.object_id and e.minor_id=a.Column_id and e.class=1 
        left join
            sys.extended_properties f on f.major_id=c.object_id and f.minor_id=0 and f.class=1
          where c.Name = @TableName";
        //order by 1";

        public TheCode.Model.Column GetObj(SqlDataReader dr)
        {
            TheCode.Model.Column obj = new TheCode.Model.Column();
            obj.ColumnName = dr["ColumnName"].ToString();
            obj.TableName = dr["TableName"].ToString();
            obj.IsPk = dr["IsPk"].ToString();
            obj.IsIdentity = dr["IsIdentity"].ToString();
            obj.IsNull = dr["IsNull"].ToString() ; //可为空
            obj.DefaultValue = dr["DefaultValue"].ToString();
            obj.ColumnType = ToCSharpType(dr["ColumnType"].ToString());
            if (obj.IsNull == "1")//可为空的话 定义类型时需要加上?
            {
                if (obj.ColumnType == "Int16" || obj.ColumnType == "Int32" || obj.ColumnType == "Int64" ||
                    obj.ColumnType == "Uint16" || obj.ColumnType == "Uint32" || obj.ColumnType == "Uint64" || 
                    obj.ColumnType == "Boolean" || obj.ColumnType == "Byte" || obj.ColumnType == "SByte"
                    )//并且是值类型
                {
                    obj.ColumnType = obj.ColumnType+"?";
                }
            }
            obj.ConvertStr = ToConvert(dr["ColumnType"].ToString());
            obj.ColumnByte = dr["ColumnByte"].ToString();
            obj.ColumnLength = dr["ColumnLength"].ToString();
            obj.ColumnRemark = dr["ColumnRemark"].ToString();
            return obj;
        }

        public List<TheCode.Model.Column> GetList(string connStr,string DatabaseName, string TableName)
        {
            List<TheCode.Model.Column> list = new List<TheCode.Model.Column>();
            SqlParameter[] _parms = new SqlParameter[]{
                new SqlParameter("@TableName",TableName)
            };
            SQL_SELECT = string.Format(SQL_SELECT, DatabaseName);
            using (SqlDataReader dr = TheCode.Common.SqlHelper.ExecuteReader(connStr, CommandType.Text, SQL_SELECT, _parms))
            {
                while (dr.Read())
                {
                    list.Add(GetObj(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 数据库中与C#中的数据类型对照
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToCSharpType(string type)
        {
            string reval = string.Empty;
            switch (type.ToLower())
            {
                case "int":
                    reval = "Int32";
                    break;
                case "text":
                    reval = "String";
                    break;
                case "bigint":
                    reval = "Int64";
                    break;
                case "binary":
                    reval = "Byte[]";
                    break;
                case "bit":
                    reval = "Boolean";
                    break;
                case "char":
                    reval = "String";
                    break;
                case "datetime":
                    reval = "DateTime";
                    break;
                case "decimal":
                    reval = "Decimal";
                    break;
                case "float":
                    reval = "Double";
                    break;
                case "image":
                    reval = "Byte[]";
                    break;
                case "money":
                    reval = "Decimal";
                    break;
                case "nchar":
                    reval = "String";
                    break;
                case "ntext":
                    reval = "String";
                    break;
                case "numeric":
                    reval = "Decimal";
                    break;
                case "nvarchar":
                    reval = "String";
                    break;
                case "real":
                    reval = "Single";
                    break;
                case "smalldatetime":
                    reval = "DateTime";
                    break;
                case "smallint":
                    reval = "Int16";
                    break;
                case "smallmoney":
                    reval = "Decimal";
                    break;
                case "timestamp":
                    reval = "DateTime";
                    break;
                case "tinyint":
                    reval = "Byte";
                    break;
                case "uniqueidentifier":
                    reval = "Guid";
                    break;
                case "varbinary":
                    reval = "Byte[]";
                    break;
                case "varchar":
                    reval = "String";
                    break;
                case "Variant":
                    reval = "Object";
                    break;
                case "uint16":
                    reval = "Uint16";
                    break;
                case "uint32":
                    reval = "Uint32";
                    break;
                case "uint64":
                    reval = "Uint64";
                    break;
                default:
                    reval = "String";
                    break;
            }
            return reval;

            //switch (dr["ColumnType"].ToString())
            //{
            //    case "varbinary":
            //        obj.ColumnType = "binary";//SqlBinary 
            //        break;
            //    case "bit":
            //        obj.ColumnType = "boolean";//SqlBoolean 
            //        break;
            //    case "tinyint":
            //        obj.ColumnType = "byte";//SqlByte 
            //        break;
            //    case "varbinary":
            //        obj.ColumnType = "byte[]";
            //        break;
            //    case "smalldatetime":
            //        obj.ColumnType = "datetime";//SqlDateTime 
            //        break;
            //    case "datetime":
            //        obj.ColumnType = "datetime";//SqlDateTime 
            //        break;
            //    case "numeric":
            //        obj.ColumnType = "decimal";//SqlDecimal¹ 
            //        break;
            //    case "float":
            //        obj.ColumnType = "double";//float,SqlDouble 
            //        break;
            //    case "uniqueidentifier":
            //        obj.ColumnType = "guid";//SqlGuid 
            //        break;
            //    case "image":
            //        obj.ColumnType = "image";
            //        break;
            //    case "smallint":
            //        obj.ColumnType = "int16";//SqlInt16 
            //        break;
            //    case "uint16":
            //        obj.ColumnType = "Uint16";
            //        break;
            //    case "int":
            //        obj.ColumnType = "int32";//SqlInt32
            //        break;
            //    case "uint32":
            //        obj.ColumnType = "Uint32";
            //        break;
            //    case "bigint":
            //        obj.ColumnType = "int64";//SqlInt64 
            //        break;
            //    case "uint64":
            //        obj.ColumnType = "Uint64";
            //        break;
            //    case "money":
            //        obj.ColumnType = "SqlMoney";//float,double
            //        break;
            //    case "real":
            //        obj.ColumnType = "single";//SqlSingle
            //        break;
            //    case "nvarchar":
            //        obj.ColumnType = "string";//SqlString
            //        break;
            //    case "varchar":
            //        obj.ColumnType = "string";
            //        break;
            //    case "uint64":
            //        obj.ColumnType = "Uint64";
            //        break;
            //    default:
            //        break;
            //}
        }

        /// <summary>
        /// 数据库中与C#中的数据类型转换方法字符串
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToConvert(string type)
        {
            string reval = string.Empty;
            switch (type.ToLower())
            {
                case "int":
                    reval = "Convert.ToInt32({0})";
                    break;
                case "text":
                    reval = "{0}.ToString()";
                    break;
                case "bigint":
                    reval = "Convert.ToInt64({0})";
                    break;
                case "binary":
                    reval = "System.Byte[]";
                    break;
                case "bit":
                    reval = "Convert.ToBoolean({0})";
                    break;
                case "char":
                    reval = "{0}.ToString()";
                    break;
                case "datetime":
                    reval = "Convert.ToDateTime({0})";
                    break;
                case "decimal":
                    reval = "Convert.ToDecimal({0})";
                    break;
                case "float":
                    reval = "Convert.ToDouble({0})";
                    break;
                case "image":
                    reval = "System.Byte[]";
                    break;
                case "money":
                    reval = "Convert.ToDecimal({0})";
                    break;
                case "nchar":
                    reval = "{0}.ToString()";
                    break;
                case "ntext":
                    reval = "{0}.ToString()";
                    break;
                case "numeric":
                    reval = "Convert.ToDecimal({0})";
                    break;
                case "nvarchar":
                    reval = "{0}.ToString()";
                    break;
                case "real":
                    reval = "Convert.ToSingle({0})";
                    break;
                case "smalldatetime":
                    reval = "Convert.ToDateTime({0})";
                    break;
                case "smallint":
                    reval = "Convert.ToInt16({0})";
                    break;
                case "smallmoney":
                    reval = "Convert.ToDecimal({0})";
                    break;
                case "timestamp":
                    reval = "Convert.ToDateTime({0})";
                    break;
                case "tinyint":
                    reval = "Convert.ToByte({0})";
                    break;
                case "uniqueidentifier":
                    reval = "System.Guid";
                    break;
                case "varbinary":
                    reval = "System.Byte[]";
                    break;
                case "varchar":
                    reval = "{0}.ToString()";
                    break;
                case "Variant":
                    reval = "(object)$ColumnName";
                    break;
                case "uint16":
                    reval = "Convert.ToUint16({0})";
                    break;
                case "uint32":
                    reval = "Convert.ToUInt32({0})";
                    break;
                case "uint64":
                    reval = "Convert.ToUInt64({0})";
                    break;
                default:
                    reval = "{0}.ToString()";
                    break;
            }
            return reval;
        } 
    }
}
