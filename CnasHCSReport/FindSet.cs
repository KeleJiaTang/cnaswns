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
    public partial class FindSet : TemplateForm
    {
        public SortedList sl_user = new SortedList();
        public SortedList sl_sterilizer = new SortedList();
        public SortedList sl_customer = new SortedList();
        public SortedList sl_costcenter = new SortedList();
        public SortedList sl_storage = new SortedList();
        public SortedList sl_procedure = new SortedList();
        
        
        public FindSet(SortedList sterilizer_batch)
        {
            InitializeComponent();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-set-incycle_wf'");//获得区域接受编号，如：decon为2020
            string strwork = arrayDR[0]["value_code"].ToString();
            strwork = strwork.Remove(strwork.LastIndexOf(','));
            string[] datalist = strwork.Split(',');//取得decon区接收的编号和打包区接收的编号。
            for(int i=0;i<datalist.Length;i++)
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

            tb_batch.Text = sterilizer_batch["s_batch"].ToString();
            tb_stername.Text = sterilizer_batch["s_name"].ToString();
            tb_sterbar.Text = sl_sterilizer.GetKey(sl_sterilizer.IndexOfValue(sterilizer_batch["s_name"].ToString())).ToString();
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
            slttmp.Add(1, sl_sterilizer.GetKey(sl_sterilizer.IndexOfValue(sterilizer_batch["s_name"].ToString())));
            slttmp.Add(2, sterilizer_batch["s_batch"].ToString());
            string gg = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec011", slttmp);
            DataTable getdt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec011", slttmp);
            if (getdt01 != null)
            {
                dgv_02.Rows.Clear();

                for (int i = 0; i < getdt01.Rows.Count; i++)
                {
                    int dgvIndex = dgv_02.Rows.Add();
                    dgv_02.Rows[i].Cells["s_select"].Value = false;
                    if (getdt01.Rows[i]["container_code"] != null) dgv_02.Rows[dgvIndex].Cells["s_sterilizer"].Value = sl_sterilizer[getdt01.Rows[i]["container_code"].ToString()];
                    if (getdt01.Rows[i]["device_runtimes"] != null) dgv_02.Rows[dgvIndex].Cells["s_batch"].Value = getdt01.Rows[i]["device_runtimes"];
                    if (getdt01.Rows[i]["set_name"] != null) dgv_02.Rows[dgvIndex].Cells["base_set"].Value = getdt01.Rows[i]["set_name"];
                    if (getdt01.Rows[i]["id"] != null) dgv_02.Rows[dgvIndex].Cells["id"].Value = getdt01.Rows[i]["id"];
                    if (getdt01.Rows[i]["cfm_userid"] != null) dgv_02.Rows[dgvIndex].Cells["s_assessor"].Value = sl_user[getdt01.Rows[i]["cfm_userid"].ToString()];
                    if (getdt01.Rows[i]["wf_code"] != null) dgv_02.Rows[dgvIndex].Cells["s_cycle"].Value = sl_procedure[getdt01.Rows[i]["wf_code"].ToString()];
                    if (getdt01.Rows[i]["cost_center"] != null) dgv_02.Rows[dgvIndex].Cells["s_costcenter"].Value = sl_costcenter[getdt01.Rows[i]["cost_center"].ToString()];
                    if (getdt01.Rows[i]["customer_code"] != null) dgv_02.Rows[dgvIndex].Cells["s_customer"].Value = sl_customer[getdt01.Rows[i]["customer_code"].ToString()];
                    if (getdt01.Rows[i]["storage_id_02"] != null) dgv_02.Rows[dgvIndex].Cells["s_storage"].Value = sl_storage[getdt01.Rows[i]["storage_id_02"].ToString()];
                    if (getdt01.Rows[i]["user_id"] != null) dgv_02.Rows[dgvIndex].Cells["s_packuser"].Value = sl_user[getdt01.Rows[i]["user_id"].ToString()];
                    if (getdt01.Rows[i]["ca_expiration"] != null) dgv_02.Rows[dgvIndex].Cells["s_expiration"].Value = getdt01.Rows[i]["ca_expiration"];
                    if (getdt01.Rows[i]["set_code"] != null) dgv_02.Rows[dgvIndex].Cells["set_barcode"].Value = getdt01.Rows[i]["set_code"];

                }
            }
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            
            SortedList slttmp_01 = new SortedList();
            SortedList slttmp01 = new SortedList();
            SortedList slttmp_02 = new SortedList();
            SortedList slttmp02 = new SortedList();
            if (dgv_02.CurrentRow == null)
            {
                MessageBox.Show(PromptMessageXmlHelper.GetPromptMessage("norecall", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cb_cycle.Text == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.GetPromptMessage("fillralla", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < dgv_02.Rows.Count; i++)
            {
                if ((bool)dgv_02.Rows[i].Cells["s_select"].Value != true) return;
                {
                   


                    slttmp_01.Add(1, dgv_02.Rows[i].Cells["set_barcode"].Value.ToString());
                    slttmp_01.Add(2, tb_sterbar.Text);
                    slttmp_01.Add(3, tb_batch.Text);
                    slttmp01.Add(1, slttmp_01);

                    slttmp_02.Add(1,dgv_02.Rows[i].Cells["id"].Value.ToString());
                    slttmp_02.Add(2, dgv_02.Rows[i].Cells["set_barcode"].Value.ToString());
                    slttmp_02.Add(3, dgv_02.Rows[i].Cells["base_set"].Value.ToString());
                    slttmp_02.Add(4, cb_cycle.Text.Substring(0, 4));
                    slttmp02.Add(1, slttmp_02);


                }
            }
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-procedure_relation-add001", sltmp01, sltmp02);
            //Todo Long: 召回时使用流程的接口去召回。
            int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-workset-add010", slttmp01, slttmp02);
            if(recint>-1)
            {
                MessageBox.Show(PromptMessageXmlHelper.GetPromptMessage("successful", EnumPromptMessage.warning,new string[]{"召回包"}), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
                if (dgv_02.Rows.Count == 0) return;
                for(int i=0;i<dgv_02.Rows.Count;i++)
                {
                    if (cb_sel.Checked == true)
                    {
                        dgv_02.Rows[i].Cells["s_select"].Value=true;
                    }
                    else{
                        dgv_02.Rows[i].Cells["s_select"].Value=false;
                    }
                }
            }

        private void cb_cycle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }

    }

