using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cnas.wns.CnasBarcodeLib;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Microsoft.VisualBasic;

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_barcode_manager : UserControl
    {
        string strothercode = "",strkeycode="";
        SortedList sl_bctype = new SortedList();
        public HCSSM_barcode_manager()
        {
            InitializeComponent();

            #region 按钮图片加载

          
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_refresh.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Reset", EnumImageType.PNG);

            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type'");
            foreach (DataRow dr in arrayDR)
            {
                cb_barcode.Items.Add(dr["key_code"].ToString().Trim()+"："+ dr["value_code"].ToString().Trim());
                sl_bctype.Add(dr["key_code"].ToString().Trim(), dr["other_code"].ToString().Trim());
            }
        }

        private void HCSSM_barcode_manager_Load(object sender, EventArgs e)
        {   

        }

        private void cb_barcode_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] strarrpar = this.cb_barcode.Text.Split('：');
            string str_othercode = "";
            strkeycode=strarrpar[0];
            if (sl_bctype[strkeycode] != null)
            {
                str_othercode = sl_bctype[strkeycode].ToString();
            }
            tabp01.Controls.Clear();
            Barcode_design Barcode_design01 = new Barcode_design(str_othercode);
            Barcode_design01.UserXmlUpdate += new Cnas.wns.CnasBarcodeLib.Barcode_design.XmlUpdate(this.barcode_design_UserXmlUpdate);
            Barcode_design01.Dock = DockStyle.Fill;
            tabp01.Controls.Add(Barcode_design01);
        }

        private void barcode_design_UserXmlUpdate(object sender, EventArgs e, string XMLdata)
        {
            strothercode = XMLdata;
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            int recint = -1;
            sltmp01.Add(1, strothercode);
            sltmp01.Add(2, "HCS_barcode_type");
            sltmp01.Add(3, strkeycode);
            sltmp.Add(1, sltmp01);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-userdata-up001", sltmp, null);
            recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-systemdata-up001", sltmp, null);
            if (recint > -1)
            {
                CnasBaseData.SystemBaseData = reCnasRemotCall.RemotInterface.SelectData("HCS-systemdata-sec001", null);
                DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type'");
                sl_bctype.Clear();
                foreach (DataRow dr in arrayDR)
                {                    
                    sl_bctype.Add(dr["key_code"].ToString().Trim(), dr["other_code"].ToString().Trim());
                }
                MessageBox.Show("恭喜你，修改条形码模版成功。");                
            }
        }

        private void but_refresh_Click(object sender, EventArgs e)
        {
            string[] strarrpar = this.cb_barcode.Text.Split('：');            
            strkeycode = strarrpar[0];            
            tabp01.Controls.Clear();
            Barcode_design Barcode_design01 = new Barcode_design("");
            Barcode_design01.UserXmlUpdate += new Cnas.wns.CnasBarcodeLib.Barcode_design.XmlUpdate(this.barcode_design_UserXmlUpdate);
            Barcode_design01.Dock = DockStyle.Fill;
            tabp01.Controls.Add(Barcode_design01);
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            string str_barcode = Interaction.InputBox("请输入条码字符串", "条码打印", "", 400, 300);
            if (str_barcode.Length == 13)
            {
                string str_bcx = str_barcode.Substring(0, 3);
                if(sl_bctype[str_bcx] !=null)
                {
                    
                    SortedList sltmp = new SortedList();
                    sltmp.Add("BarcodeValue", str_barcode);
					string printResult = BarCodeHelper.PrintBarCode(str_barcode, sltmp);
					if (!string.IsNullOrEmpty(printResult))
						MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
