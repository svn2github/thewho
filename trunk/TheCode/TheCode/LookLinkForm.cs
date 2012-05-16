using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheCode
{
    public partial class LookLinkForm : Form
    {
        public string link = "";
        public LookLinkForm()
        {
            InitializeComponent();
            Form_Init(link);
        }
        public LookLinkForm(string link)
        {
            InitializeComponent();
            this.link = link;
            Form_Init(link);
        }

        //窗体初始化方法
        public void Form_Init(string link)
        {
            //窗口居中
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2), this.Width, this.Height, BoundsSpecified.Location);
            txt_Link.Text = link;
        }
    }
}
