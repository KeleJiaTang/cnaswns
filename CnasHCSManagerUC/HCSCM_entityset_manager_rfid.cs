using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
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
    public partial class HCSCM_entityset_manager_rfid : TemplateForm
    {
        string Set_id = "";//实体包id
        public HCSCM_entityset_manager_rfid(string id,string setName)
        {
            InitializeComponent();
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_bindingRfid.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "bindingRFID", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--配置RFID";
            Set_id = id;
            tb_setName.Text = setName;
            Loaddata();

        }
        private void Loaddata()
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Set_id);
            DataTable getdt = null;
     //       string showSQL = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-setRfid-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-setRfid-sec001", sttemp01);
            if (getdt != null)
            {
                int sumi = 0;
                int sumr = 0;
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("器械编号") && getdt.Rows[i]["器械编号"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["器械编号"].ToString();
                    if (getdt.Columns.Contains("器械名称") && getdt.Rows[i]["器械名称"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["器械名称"].ToString();
                    if (getdt.Columns.Contains("实体包条码") && getdt.Rows[i]["实体包条码"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["实体包条码"].ToString();
                    if (getdt.Columns.Contains("器械数量") && getdt.Rows[i]["器械数量"] != null) dgv_01.Rows[i].Cells["number"].Value = getdt.Rows[i]["器械数量"].ToString();
                    if (getdt.Columns.Contains("绑定RFID数量") && getdt.Rows[i]["绑定RFID数量"] != null) dgv_01.Rows[i].Cells["binding_number"].Value = getdt.Rows[i]["绑定RFID数量"].ToString();
                    sumi += int.Parse(getdt.Rows[i]["器械数量"].ToString());
                    sumr += int.Parse(getdt.Rows[i]["绑定RFID数量"].ToString());
                }
                tb_setName.Text = getdt.Rows[0]["实体包名称"].ToString();
                tb_iNumber.Text = sumi.ToString();
                tb_rNumber.Text = sumr.ToString();

            }
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[0];
            }
        }
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            if (this.dgv_01.SelectedRows.Count <= 0)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicechange", EnumPromptMessage.warning, new string[] { "绑定RFID", "器械" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SortedList slindata = new SortedList();
            try
            {
                slindata.Add("器械编号", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("器械名称", dgv_01.SelectedRows[0].Cells["ca_name"].Value);
                slindata.Add("实体包条码", dgv_01.SelectedRows[0].Cells["bar_code"].Value);
                slindata.Add("器械数量", dgv_01.SelectedRows[0].Cells["number"].Value);
                slindata.Add("实体包id", Set_id);

                HCSCM_entityset_manager_bindingRfid hcsm = new HCSCM_entityset_manager_bindingRfid(slindata);
                //获取一个值，指是否在Windows任务栏中显示窗体。
                hcsm.ShowInTaskbar = false;
                if (hcsm.IsShow == true)
                {
                    hcsm.ShowDialog();
                }
                
                Loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            but_print_Click(null, null);
        }
    }
}
