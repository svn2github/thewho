using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SrcToReplace
{
    public class MyItem
    {
        public MyItem(string Text, string Value)
        {
            this.Text = Text;
            this.Value = Value;
        }
        public MyItem()
        {
            this.Text = "http://www.xuex123.com";
            this.Value = "http://www.xuex123.com";
        }
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public override bool Equals(System.Object obj)
        {
            if (this.GetType().Equals(obj.GetType()))
            {
                MyItem that = (MyItem)obj;
                return (this.Text.Equals(that.Value));
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode(); ;
        }
    }
}
