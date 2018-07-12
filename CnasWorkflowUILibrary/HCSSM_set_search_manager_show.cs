using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_set_search_manager_show : MetroForm
	{
		
		public HCSSM_set_search_manager_show(string app_ID)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			HCSSM_set_search_manager searchSet=new HCSSM_set_search_manager(app_ID);
			this.Controls.Add(searchSet);
			searchSet.Dock = DockStyle.Fill;
		}
	}
}
