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
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_plasticenvelop_device_procedure : TemplateForm
    {
        private DataTable dtall = new DataTable();
        private DataTable dtselect = new DataTable();
        private SortedList sl_gpapp = new SortedList();
        private SortedList sl_allapp = new SortedList();
        private string select_id = "";//机器ID
        private DataRow[] arrayDR = null;//用于传输数据
        //系统名称
        string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();

        public HCSCM_plasticenvelop_device_procedure(SortedList slselect)
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.but_addall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allRight", EnumImageType.PNG);
            this.but_addone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "rightShift", EnumImageType.PNG);
            this.but_reall.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "allLeft", EnumImageType.PNG);
            this.but_reone.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "leftShift", EnumImageType.PNG);
            this.but_save.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "savePicture", EnumImageType.PNG);
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = styStemName + "--塑封流程";
            this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            this.tb_department.Text = slselect["ca_name"].ToString();
            select_id = slselect["id"].ToString();
          
           
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();

            dtall = reCnasRemotCall.RemotInterface.SelectData("HCS-plasticenvelop-program-sec001", null);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, slselect["id"].ToString());
          //  string a = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-plasticenvelop-deviceprogram-sec001", sttemp02);
            dtselect = reCnasRemotCall.RemotInterface.SelectData("HCS-plasticenvelop-deviceprogram-sec001", sttemp02);
           
            
            if (dtall != null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string str_id = "", str_app_name = "";
                    if (dtall.Columns.Contains("id") && dtall.Rows[i]["id"] != null) str_id = dtall.Rows[i]["id"].ToString();
                    if (dtall.Columns.Contains("pr_name") && dtall.Rows[i]["pr_name"] != null) str_app_name = dtall.Rows[i]["pr_name"].ToString();

                    GridViewRowInfo drtemp01 = null;
                    //drtemp01.Cells.Add(new DataGridViewCheckBoxCell());//选择
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//id                     
                    //drtemp01.Cells.Add(new DataGridViewTextBoxCell());//名字
                    //drtemp01.SetValues(false, str_id, str_app_name);
                    if (dtselect == null)
                    {
                        drtemp01 = dgv_01.Rows.AddNew();
                        sl_allapp.Add(str_id, str_app_name);

                    }
                    else
                    {
                        DataRow[] arrayDRsec = dtselect.Select("p_id=" + str_id);
                        if (arrayDRsec.Length > 0)
                        {
                            drtemp01 = dgv_02.Rows.AddNew();
                            sl_gpapp.Add(str_id, str_app_name);
                        }
                        else
                        {
                            drtemp01 = dgv_01.Rows.AddNew();
                            sl_allapp.Add(str_id, str_app_name);
                        }
                    }
                    if (drtemp01 != null)
                    {
                        drtemp01.Cells[0].Value = str_id;
                        drtemp01.Cells[1].Value = str_app_name;
                    }

                    drtemp01.Tag = dtall.Rows[i];
                    
                }
            }

        }
        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_addall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, true);
        }

        private void but_addone_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, true);
        }

        private void but_reone_Click(object sender, EventArgs e)
        {

            CnasUtilityTools.MoveData(dgv_01, dgv_02, true, false);
        }

        private void but_reall_Click(object sender, EventArgs e)
        {
            CnasUtilityTools.MoveData(dgv_01, dgv_02, false, false);
        }

       

       

     

       

        private void but_save_Click(object sender, EventArgs e)
        {
            if (dgv_02.Rows.Count > 0)
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp02 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, select_id);
                sltmp01.Add(1, sltmp_01);
                for (int i = 0; i < dgv_02.Rows.Count; i++)
                {
                    SortedList sltmp_02 = new SortedList();
                    sltmp_02.Add(1, select_id);
                    sltmp_02.Add(2, dgv_02.Rows[i].Cells["id"].Value);
                    sltmp02.Add(i + 1, sltmp_02);
                }
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                //string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-sterilizer-deviceprogram-add001", sltmp01, sltmp02);
                int recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-plasticenvelop-deviceprogram-add001", sltmp01, sltmp02);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "塑封机关联程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                SortedList sltmp01 = new SortedList();
                SortedList sltmp_01 = new SortedList();
                sltmp_01.Add(1, select_id);
                sltmp01.Add(1, sltmp_01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                // string recsql = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-sterilizer-deviceprogram-del001", sltmp01, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-plasticenvelop-deviceprogram-del001", sltmp01, null);
                if (recint > -1)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "塑封机关联程序" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

		private void dgv_01_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_addone_Click(null, null);
		}

		private void dgv_02_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			but_reone_Click(null, null);
		}
    }
}
