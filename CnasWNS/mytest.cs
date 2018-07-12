using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cnas.wns.CnasBaseClassClient;
//using Cnas.wns.CnasHCSSystemUC;

namespace Cnas.wns
{
    public partial class mytest : Form
    {
        public mytest()
        {
            InitializeComponent();
            //HCSSM_user_group hcstmp = new HCSSM_user_group();
            //hcstmp.Dock = DockStyle.Fill;
            //tp_01.Controls.Add(hcstmp);
        }

        private void mytest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tp_01_Click(object sender, EventArgs e)
        {

        }
    }
}
