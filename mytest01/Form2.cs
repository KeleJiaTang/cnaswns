using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace mytest01
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Leave(object sender, EventArgs e)
        {
           //this.Close();
        }

        private void Form2_MouseLeave(object sender, EventArgs e)
        {
            
            //this.Close();
        }
    }
}
