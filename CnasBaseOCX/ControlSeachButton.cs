using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseUC
{
    public partial class ControlSeachButton: UserControl
    {
        public String SelectData = "";
        public delegate void RadioButtonSelect(object sender, EventArgs e,string infodata);
        [Browsable(true), Description("选择索引单击事件。"), Category("操作")]
        public event RadioButtonSelect UserRadioButtonSelect;
        
        //protected virtual void OnButtonClick(object sender, EventArgs e)
        //{
        //    if (ButtonClick != null) ButtonClick(this, e);
        //}


        public ControlSeachButton()
        {
            InitializeComponent();
        }

        private void Setselectdata(object obj_rbin,EventArgs e)
        {
            RadioButton obj_rb = (RadioButton)obj_rbin;
            string strinfo = obj_rb.Name;
            if (strinfo !="AL")
            {
                strinfo = strinfo.Substring(1);
            }
            else
            {
                strinfo = "";
            }
            UserRadioButtonSelect(obj_rb, e, strinfo);
        }

        private void AA_Click(object sender, EventArgs e)
        {
            Setselectdata(sender,e);
        }

    }
}
