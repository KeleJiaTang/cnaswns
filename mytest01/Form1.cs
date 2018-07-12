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
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2();
            ff.ShowDialog();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            
            //MetroMessageBox.Show(this, "Do you like this metro message box?", "Metro Title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }
    }
}
