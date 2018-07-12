using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using Cnas.wns.CnasBaseInterface;
using System.Reflection;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasWorkflowUILibrary
{
    public partial class HCSWF_parameters_info : MetroForm
    {
        public string Info_Data = "";
		public HCSWF_parameters_info()
        {
            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
        }

        private void tex_remark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 && tex_remark.Text.Trim().Length>0)
            {
                Info_Data = tex_remark.Text.Trim();
                this.Close();
            }
        }
    }
}
