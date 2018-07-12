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
    public partial class HCSCM_set_information : TemplateForm
    {
        private string Selectid = "";//被选择的id、、
        private string bar_code = "";//基本包barcode
        private SortedList sl_type_01 = new SortedList();
        private SortedList sl_type_02 = new SortedList();
        private SortedList sl_type_03 = new SortedList();
        public HCSCM_set_information(SortedList SLdata,bool vbutton)
        {
            InitializeComponent();
            this.but_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--基本包信息";
            ////表格栏底色
            //dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            ////dgv表格各字段居中
            //this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if(vbutton)
            {
                but_print.Visible = false;
            }
            DataRow[] arrayDR = null;
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-sterilizer-program-sec001", null);//灭菌程序
            if (getdt != null)
            {
                arrayDR = getdt.Select();
                sl_type_01.Add("0", "无灭菌程序");
              
                foreach (DataRow dr in arrayDR)
                {
                    sl_type_01.Add(dr["id"].ToString().Trim(), dr["pr_name"].ToString().Trim());
                }
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-washing-program-sec001", null);//清洗程序
            if (getdt != null)
            {
                arrayDR = getdt.Select();
                sl_type_02.Add("0", "无清洗程序");
                
                foreach (DataRow dr in arrayDR)
                {
                    sl_type_02.Add(dr["id"].ToString().Trim(), dr["pr_name"].ToString().Trim());
                    
                }
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                arrayDR = getdt.Select();
                foreach (DataRow dr in arrayDR)
                {
                    sl_type_03.Add(dr["bar_code"].ToString().Trim(), dr["cu_name"].ToString().Trim());
                }
            }

            Selectid = SLdata["id"].ToString();
            bar_code = SLdata["bar_code"].ToString();
            tb_name.Text = SLdata["ca_name"].ToString();
           tb_moddata.Text=SLdata["mod_date"].ToString();
		   tb_creperson.Text = SLdata["cre_person"] == null ? string.Empty : SLdata["cre_person"].ToString();
		   tb_modperson.Text = SLdata["mod_person"] == null ? string.Empty : SLdata["mod_person"].ToString();
            tb_complexity.Text = SLdata["ca_complexity"].ToString();
            tb_customer.Text = sl_type_03[SLdata["customer_code"].ToString()].ToString();
            //cb_cost_center.Text = SLdata["cost_center"].ToString();

            //cb_material.Text = sl_type_02[SLdata["ca_material"].ToString()].ToString();
            //tb_number.Text = SLdata["put_type"].ToString() + ":" + sl_type_05[SLdata["put_type"].ToString()].ToString();
            tb_credata.Text = SLdata["cre_date"].ToString();
            tb_sterilizer.Text = sl_type_01[SLdata["sterilizer_type"].ToString()].ToString();
            tb_washing.Text = sl_type_02[SLdata["washing_type"].ToString()].ToString();
         
            dgv_01.Rows.Clear();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Selectid);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-instrument-sec002", sttemp01);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, CnasBaseData.SystemID);
            DataTable getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttemp02);
            if (getdt != null && getdt02 != null)
            {

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                int sum = 0;
                for (int i = 0; i < ii; i++)
                {
					if (getdt.Columns.Contains("instrument_id") && getdt.Rows[i]["instrument_id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["instrument_id"].ToString();
					if (getdt.Columns.Contains("COUNT(instrument_id)") && getdt.Rows[i]["COUNT(instrument_id)"] != null) dgv_01.Rows[i].Cells["number"].Value = getdt.Rows[i]["COUNT(instrument_id)"].ToString();



                    DataRow secDR = getdt02.Select("id=" + getdt.Rows[i]["instrument_id"].ToString())[0];


                    if (getdt02.Columns.Contains("ca_name") && secDR["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = secDR["ca_name"].ToString();
                    //if (getdt.Rows[i]["customer_code"] != null) dgv_02.Rows[i].Cells["customer_code"].Value = getdt.Rows[i]["customer_code"].ToString();
                    sum += int.Parse(getdt.Rows[i]["COUNT(instrument_id)"].ToString());
                }
                this.tb_number.Text =sum.ToString();
                if(dgv_01.Rows.Count>0)
				{
					dgv_01.CurrentRow = dgv_01.Rows[0];
				}
            }
           
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void but_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_print_Click(object sender, EventArgs e)
        {

            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("宋体", 20, FontStyle.Bold);//标题字体            

           // Font fntTxt = new Font("宋体", 30, FontStyle.Regular);//正文文字            

            Brush brush = new SolidBrush(Color.Black);//画刷            

           // Pen pen = new Pen(Color.Black);           //线条颜色            

            Point po = new Point(100, 100);

            try
            {

                //e.Graphics.DrawString(GetPrintSW().ToString(), titleFont, brush, po);   //DrawString方式进行打印。         

            }

            catch (Exception ex)
            {

                MessageBox.Show(this, "打印出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void but_print_Click_1(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='packlist'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(this.dgv_01, pringxml);
            return;
        }
    }
}
