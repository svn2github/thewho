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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void splitContainer1_MouseUp(object sender, MouseEventArgs e)
        {
            //防止拖拽调整大小后 虚线重新出现
            this.splitContainer1.Panel1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainForm cd = new MainForm();
            foreach (System.Windows.Forms.Control item in cd.Controls)
            {
                this.splitContainer1.Panel2.Controls.Add(item);
            }
             
        }
    }
}
