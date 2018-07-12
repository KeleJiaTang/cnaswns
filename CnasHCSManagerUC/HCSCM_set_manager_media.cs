using CnasUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_set_manager_media : TemplateForm
    {
        public HCSCM_set_manager_media()
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--照片管理";
        }

        private void HCSCM_manager_media_Load(object sender, EventArgs e)
        {

        }
    }
}
