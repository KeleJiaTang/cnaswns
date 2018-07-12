using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasBaseUC
{
    public partial class ControlMonitoring : UserControl
    {
        public delegate void MonitoButtonSelect(object sender, EventArgs e, string infodata);
        [Browsable(true), Description("单击监控事件按钮时，发生动作。"), Category("操作")]
        public event MonitoButtonSelect UserMonitoButtonSelect;
        public ControlMonitoring()
        {
            InitializeComponent();
			N1_number.BackColor = Color.FromArgb(236,84,81);
			N1_info.BackColor = Color.FromArgb(236, 84, 81);
			N2_number.BackColor = Color.FromArgb(243, 164, 61);
			N2_info.BackColor = Color.FromArgb(243, 164, 61);
			N3_number.BackColor = Color.FromArgb(35, 186, 155);
			N3_info.BackColor = Color.FromArgb(35, 186, 155);
			N4_number.BackColor = Color.FromArgb(172, 71, 173);
			N4_info.BackColor = Color.FromArgb(172, 71, 173);
			N5_number.BackColor = Color.FromArgb(131, 104, 247);
			N5_info.BackColor = Color.FromArgb(131, 104, 247);
			this.ForeColor = N1_number.ForeColor;
			this.ForeColor = N2_number.ForeColor;
			this.ForeColor = N3_number.ForeColor;
			this.ForeColor = N4_number.ForeColor;
			this.ForeColor = N5_number.ForeColor;
			this.ForeColor = N1_info.ForeColor;
			this.ForeColor = N2_info.ForeColor;
			this.ForeColor = N3_info.ForeColor;
			this.ForeColor = N4_info.ForeColor;
			this.ForeColor = N5_info.ForeColor;
        }

        private void N1_number_Click(object sender, EventArgs e)
        {
            Setselectdata(sender,e);
			Button button  = sender as Button;
			if (button != null)
			{
				Graphics graphics = this.CreateGraphics();
				SizeF size = graphics.MeasureString(button.Text, button.Font);
				if (size.Width + 6 > button.Width)
					button.Width = (int)size.Width + 6;
			}
        }

        private void Setselectdata(object obj_rbin, EventArgs e)
        {
            Button obj_rb = (Button)obj_rbin;
            string strinfo = obj_rb.Name.Substring(0,2);
            UserMonitoButtonSelect(obj_rb, e, strinfo);
        }
    }
}
