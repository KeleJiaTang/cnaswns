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
    public partial class HCSCM_department_equipment_manager_output : TemplateForm
    {
        private string Selectid = "";//id
        private string baseID = "";//base_id
        string costCenterID = "";
        int sel_type = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slindata"></param>
        /// <param name="type">1是出/入库，2是盘点</param>
        public HCSCM_department_equipment_manager_output(SortedList slindata, int type)
        {
            InitializeComponent();
            #region Button图标

            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);

            #endregion
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--手动盘点";

            #region 加载内容
            sel_type = type;
            Selectid = slindata["id"].ToString();
            tb_name.Text = slindata["in_name"].ToString();
            baseID = slindata["base_id"].ToString();
            tb_customer.Text = slindata["in_customer"].ToString();
            tb_costcenter.Text = slindata["in_costcenter"].ToString();
            costCenterID = slindata["in_costcenterID"].ToString();
            tb_stroageNum.Text = slindata["current_count"].ToString();
            if (type == 2)
            {
                lb_stroageNum.Text = "盘点数量";
                groupBox1.Visible = false;
            }


            #endregion
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if (sel_type == 1)
            {
                #region 出库
                SortedList conditionAll = new SortedList();
                if (tb_outputNum.Text.Trim() == "")
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("FillOutTheNumberOfTheLibrary", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    //填写出库数量
                }
                if (tb_outputNum.Text.Trim() == "0")
                {
                    //出库数量不能为0
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("NotLibraryNumForZero", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int surplusNum = int.Parse(tb_stroageNum.Text) - int.Parse(tb_outputNum.Text);
                if (rb_storage.Checked==true)//入库
                {
                     surplusNum =  int.Parse(tb_outputNum.Text)+int.Parse(tb_stroageNum.Text) ;
                     
                }
                if (surplusNum < 0)
                {
                    //出库数量过大
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("LibraryNumTooBig", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #region 出库修改信息
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, surplusNum);
                sltmp.Add(2, CnasBaseData.UserID);
                sltmp.Add(3, Selectid);
                sltmp01.Add(1, sltmp);
                //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-costcenter-detail-up004", sltmp01, null);

                #endregion

                #region  出库日志
                SortedList sltmpOut = new SortedList();
                SortedList conditionStorageInput = new SortedList();
                sltmpOut.Add(1, baseID);
                sltmpOut.Add(2, costCenterID);
                if (rb_storage.Checked == true)//入库
                {
                    sltmpOut.Add(3, 1);
                }
                else
                {
                    sltmpOut.Add(3, 2);
                }
                sltmpOut.Add(4, int.Parse(tb_outputNum.Text));
                sltmpOut.Add(5, CnasBaseData.UserID);
                conditionStorageInput.Add(1, sltmpOut);
                #endregion
                conditionAll.Add(1, sltmp01);
                conditionAll.Add(2, conditionStorageInput);
                //string tes = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-instrument-costcenter-detail-up004", conditionAll);
                int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-costcenter-detail-up004", conditionAll);
                if (result > -1)
                {
                    //出库成功
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("OutputSuccessful", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                #endregion

               

            }
            else
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp.Add(1, int.Parse(tb_outputNum.Text));
                sltmp.Add(2, Selectid);//价格
                sltmp01.Add(1, sltmp);
                string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-costcenter-detail-up005", sltmp01, null);
                int result = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-costcenter-detail-up005", sltmp01, null);
                if (result > -1)
                {
                    //盘点成功
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("checkNum", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }


        }

        private void tb_outputNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;//经过判断为数字，可以输入
            }
        }

        private void rb_storage_CheckedChanged(object sender, EventArgs e)
        {
            lb_stroageNum.Text = "入库数量：";
        }
    }
}
