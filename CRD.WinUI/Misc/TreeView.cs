using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace CRD.WinUI.Misc
{
    public partial class TreeView : System.Windows.Forms.TreeView
    {
        public TreeView()
            : base()
        {
           
            this.BorderStyle = BorderStyle.FixedSingle;
            this.UpdateStyles();
        }
        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                Shared.ResetBorderColor(m, this);
            }
        }

    }
}
