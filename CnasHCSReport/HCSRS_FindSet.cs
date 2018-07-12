using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Collections;
using CnasUI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_FindSet : TemplateForm
    {
        public SortedList sl_user = new SortedList();
        public SortedList sl_sterilizer = new SortedList();
        public SortedList sl_customer = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList sl_storage = new SortedList();
        public SortedList sl_procedure = new SortedList();


        public HCSRS_FindSet(SortedList sterilizer_batch)
        {
            InitializeComponent();
            this.btnPrintList.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printList", EnumImageType.PNG);
            this.but_select.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "recall", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            if (sterilizer_batch==null) return;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-set-incycle_wf'");//获得区域接受编号，如：decon为2020
            string strwork = arrayDR[0]["value_code"].ToString();
            strwork = strwork.Remove(strwork.LastIndexOf(','));
            string[] datalist = strwork.Split(',');//取得decon区接收的编号和打包区接收的编号。
            for (int i = 0; i < datalist.Length; i++)
            {

                SortedList sttemp01 = new SortedList();
                sttemp01.Clear();
                sttemp01.Add(1, datalist[i]);
                // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-procedure-sec003", sttemp01);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec003", sttemp01);
                cb_cycle.Items.Add(getdt.Rows[0]["pd_code"].ToString() + ":" + getdt.Rows[0]["pd_name"].ToString());
            }
            SortedList sltmp = new SortedList();
            sltmp.Add(1, CnasBaseData.SystemID);

            DataTable Sterilizer = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-device-sec001", sltmp);
            if (Sterilizer != null)
            {
                int ii = Sterilizer.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (Sterilizer.Rows[i]["ca_name"].ToString() != null && Sterilizer.Rows[i]["bar_code"].ToString() != null)
                    {
                        sl_sterilizer.Add(Sterilizer.Rows[i]["bar_code"].ToString(), Sterilizer.Rows[i]["ca_name"].ToString());
                    }
                }
            }
            if (sterilizer_batch.Count == 0) return;
            tb_batch.Text = sterilizer_batch["s_batch"]==null&&sterilizer_batch.ContainsKey("s_batch")?string.Empty:sterilizer_batch["s_batch"].ToString();
			tb_stername.Text = sterilizer_batch["s_name"] == null && sterilizer_batch.ContainsKey("s_name") ? string.Empty : sterilizer_batch["s_name"].ToString();
			tb_sterbar.Text = sterilizer_batch["s_name"] == null 
				?string.Empty : sl_sterilizer.GetKey(sl_sterilizer.IndexOfValue(sterilizer_batch["s_name"].ToString())).ToString();
            DataTable Customer = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);
            if (Customer != null)
            {
                int kk = Customer.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Customer.Rows[i]["bar_code"].ToString() != null && Customer.Rows[i]["cu_name"].ToString() != null)
                    {
                        sl_customer.Add(Customer.Rows[i]["bar_code"].ToString(), Customer.Rows[i]["cu_name"].ToString());
                    }
                }
            }

            DataTable Storage = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec001", null);
            if (Storage != null)
            {
                int kk = Storage.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Storage.Rows[i]["id"].ToString() != null && Storage.Rows[i]["s_name"].ToString() != null)
                    {
                        sl_storage.Add(Storage.Rows[i]["id"].ToString(), Storage.Rows[i]["s_name"].ToString());
                    }
                }
            }


            DataTable Costcenter = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);
            if (Costcenter != null)
            {
                int kk = Costcenter.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (Costcenter.Rows[i]["bar_code"].ToString() != null && Costcenter.Rows[i]["ca_name"].ToString() != null)
                    {
                        sl_costcenter.Add(Costcenter.Rows[i]["bar_code"].ToString(), Costcenter.Rows[i]["ca_name"].ToString());
                    }
                }
            }

            DataTable User = reCnasRemotCall.RemotInterface.SelectData("HCS-userdata-sec002", sltmp);
            if (User != null)
            {
                int kk = User.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (User.Rows[i]["id"].ToString() != null && User.Rows[i]["user_name"].ToString() != null)
                    {
                        sl_user.Add(User.Rows[i]["id"].ToString(), User.Rows[i]["user_name"].ToString());
                    }
                }
            }

            DataTable procedure = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec001", sltmp);
            if (procedure != null)
            {
                int kk = procedure.Rows.Count;
                if (kk <= 0) return;
                for (int i = 0; i < kk; i++)
                {
                    if (procedure.Rows[i]["pd_code"].ToString() != null && procedure.Rows[i]["pd_name"].ToString() != null)
                    {
                        sl_procedure.Add(procedure.Rows[i]["pd_code"].ToString(), procedure.Rows[i]["pd_name"].ToString());
                    }
                }
            }
            loaddata(sterilizer_batch);
        }
        public void loaddata(SortedList sterilizer_batch)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList slttmp = new SortedList();
            SortedList slttmp01 = new SortedList();
            slttmp.Add(1, sterilizer_batch["s_name"] == null ? 0:sl_sterilizer.GetKey(sl_sterilizer.IndexOfValue(sterilizer_batch["s_name"].ToString())));
			slttmp.Add(2, sterilizer_batch["s_batch"] == null && sterilizer_batch.ContainsKey("s_batch") ? string.Empty : sterilizer_batch["s_batch"].ToString());
          
            //string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec011", slttmp);
            DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec011", slttmp);
            if (getdt01 != null)
            {
                dgv_02.Rows.Clear();
                //getdt01.RowCount=getdt01.Rows.Count
                for (int i = 0; i < getdt01.Rows.Count; i++)
                {
                    int dgvIndex = dgv_02.Rows.AddNew().Index;
                    //dgv_02.Rows[i].Cells["s_select"].Value = false;
                    if (getdt01.Columns.Contains("ster") && !string.IsNullOrEmpty(getdt01.Rows[i]["ster"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_sterilizer"].Value = sl_sterilizer[getdt01.Rows[i]["ster"].ToString()];
                    if (getdt01.Columns.Contains("deruns") && !string.IsNullOrEmpty(getdt01.Rows[i]["deruns"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_batch"].Value = getdt01.Rows[i]["deruns"];
                    if (getdt01.Columns.Contains("setname") && !string.IsNullOrEmpty(getdt01.Rows[i]["setname"].ToString())) dgv_02.Rows[dgvIndex].Cells["base_set"].Value = getdt01.Rows[i]["setname"];
                    if (getdt01.Columns.Contains("id") && !string.IsNullOrEmpty(getdt01.Rows[i]["id"].ToString())) dgv_02.Rows[dgvIndex].Cells["id"].Value = getdt01.Rows[i]["id"];

                    if (getdt01.Columns.Contains("cfm_userid") && !string.IsNullOrEmpty(getdt01.Rows[i]["cfm_userid"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_assessor"].Value = sl_user[getdt01.Rows[i]["cfm_userid"].ToString()];
                    if (getdt01.Columns.Contains("wf_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["wf_code"].ToString()))
                    {
                        dgv_02.Rows[dgvIndex].Cells["s_cycle"].Value = sl_procedure[getdt01.Rows[i]["wf_code"].ToString()];
                        dgv_02.Rows[dgvIndex].Cells["wf_code"].Value = getdt01.Rows[i]["wf_code"].ToString();
                    }
                    if (getdt01.Columns.Contains("cost_center") && !string.IsNullOrEmpty(getdt01.Rows[i]["cost_center"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[getdt01.Rows[i]["cost_center"].ToString()];
                    if (getdt01.Columns.Contains("customer_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["customer_code"] .ToString())) dgv_02.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[getdt01.Rows[i]["customer_code"].ToString()];
                    if (getdt01.Columns.Contains("storage_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["storage_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_storage"].Value = sl_storage[getdt01.Rows[i]["storage_id"].ToString()];
                    if (getdt01.Columns.Contains("user_id") && !string.IsNullOrEmpty(getdt01.Rows[i]["user_id"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_packuser"].Value = sl_user[getdt01.Rows[i]["user_id"].ToString()];
                    if (getdt01.Columns.Contains("ca_expiration") && !string.IsNullOrEmpty(getdt01.Rows[i]["ca_expiration"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_expiration"].Value = getdt01.Rows[i]["ca_expiration"];
                    if (getdt01.Columns.Contains("set_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["set_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["set_barcode"].Value = getdt01.Rows[i]["set_code"];
                    if (getdt01.Columns.Contains("BCU_code") && !string.IsNullOrEmpty(getdt01.Rows[i]["BCU_code"].ToString())) dgv_02.Rows[dgvIndex].Cells["s_bcu"].Value = getdt01.Rows[i]["BCU_code"];
                }
            }
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            SortedList param01 = new SortedList();
            SortedList param02 = new SortedList();
			SortedList param03 = new SortedList();
			SortedList param04 = new SortedList();
            SortedList sqlParameters = new SortedList();
            if(dgv_02.Rows.Count==0)
            {
                MessageBox.Show("没有需要召回的包", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_cycle.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillralla", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确定要召回该批次的包？", "是否召回", MessageBoxButtons.YesNo) == DialogResult.No) return;


            for (int i = 0; i < dgv_02.Rows.Count; i++)
            {
                string barCode = dgv_02.Rows[i].Cells["set_barcode"].Value.ToString();
                SortedList updateWorkSet = new SortedList();
                SortedList insertWorkSet = new SortedList();
                SortedList insertReCall = new SortedList();
				SortedList updateStorage = new SortedList();

                updateWorkSet.Add(1, barCode);
                updateWorkSet.Add(2, dgv_02.Rows[i].Cells["s_bcu"].Value.ToString());
                updateWorkSet.Add(3, dgv_02.Rows[i].Cells["wf_code"].Value.ToString());
                param01.Add((param01.Count + 1), updateWorkSet);

                if (!BarCodeHelper.IsTempSet(barCode))
                {
                    insertWorkSet.Add(1, dgv_02.Rows[i].Cells["id"].Value.ToString());
                    insertWorkSet.Add(2, barCode);
                    insertWorkSet.Add(3, dgv_02.Rows[i].Cells["base_set"].Value.ToString());
                    insertWorkSet.Add(4, cb_cycle.Text.Substring(0, 4));
                    param02.Add((param02.Count + 1), insertWorkSet);
                }

                insertReCall.Add(1, dgv_02.Rows[i].Cells["base_set"].Value.ToString());
                insertReCall.Add(2, barCode);
                insertReCall.Add(3, tb_sterbar.Text);
                insertReCall.Add(4, tb_batch.Text);
                param03.Add((param03.Count + 1), insertReCall);

				updateStorage.Add(1, barCode);
				param04.Add((param04.Count + 1), updateStorage);
            }

            sqlParameters.Add(1, param01);
            sqlParameters.Add(2, param02);
			sqlParameters.Add(3, param03);
			sqlParameters.Add(4, param04);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            string recsql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add010", sqlParameters);
            int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add010", sqlParameters);
            if (recint <= -1) return;


              MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "召回包" }),
                  "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
              this.Close();
          
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void cb_cycle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
          
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='common'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim(); 
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();


            RadPrintHelper.Print_DataGridView(this.dgv_02, pringxml);
        }

    }
}

