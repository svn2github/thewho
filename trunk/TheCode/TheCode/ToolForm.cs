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
    public partial class ToolForm : Form
    {
        public ToolForm()
        {
            InitializeComponent();
        }

        private void ToolForm_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.niTheCode.Visible = true;//展示出notifyicon控件
        }

        private void niTheCode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }
    }
}
