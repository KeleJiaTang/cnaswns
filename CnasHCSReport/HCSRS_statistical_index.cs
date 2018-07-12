using CnasUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_statistical_index : TemplateForm
    {
        /// <summary>
        /// 表头代码
        /// </summary>
        string StrHeader = "";
        /// <summary>
        /// 表头名称
        /// </summary>
        string StrFormName = "";
        public HCSRS_statistical_index(DataTable ContentsShow, string Header, string FormName)
        {
            InitializeComponent();
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--指标结果";
            but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
            but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            dgv_01.DataSource = ContentsShow;
            StrHeader = Header;
            StrFormName = FormName;
            //if (dgv_01.Rows.Count > 0 && dgv_01.ColumnCount > 0)
            //	dgv_01.Rows[0].Cells[0].Value = "所选时间段";

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code=" + "'" + StrHeader + "'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();

            RadPrintHelper.Print_DataGridView(dgv_01, pringxml);
            return;
        }

        private void but_import_Click(object sender, EventArgs e)
        {
            ExcelHelper.ImprotDataToExcel(this.dgv_01, StrFormName);
        }
    }
}
