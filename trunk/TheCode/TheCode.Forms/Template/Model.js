using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $NameSpace
{
    /// <summary>
    /// $TableName
    /// </summary>
    public class $TableName
    {	
        $Star//$IsPk$IsIdentity$IsNull$DefaultValue$ColumnRemark
        private $ColumnType _$ColumnName;
        public $ColumnType $ColumnName
        {
            get { return _$ColumnName; }
            set { _$ColumnName = value; }
        }
        $End
    }
}