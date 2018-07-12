using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using Cnas.wns.CnasBaseInterface;
using System.Reflection;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;


/*
注意事项：
 * 1、全部数据输入检验在：HCSSM_scanbarcode
 * 2、全部数据传入CnasHCSWorkflowInterface，然后得出下一步流程，或者处理错误结果。
*/


namespace Cnas.wns.CnasHCSWorkspacePacking
{
    public partial class HCSSM_workspace_packing : MetroForm
    {
        private DataTable dtpdpart = new DataTable();//HCS-pdparameter-sec04 当前流程的参数集合
        private DataTable dtapppd = new DataTable();//当前工作台的流程
        private DataTable dtpartvalue = new DataTable();//所有参数的值集合
        private DataTable dtallorder = new DataTable();//当前工作台的所有包

        private SortedList sl_allpd = new SortedList();

        private string App_ID = "1010", App_pd = "";



        CnasHCSWorkflowInterface CnasHCSWorkflowInterface01;
        public HCSSM_workspace_packing()
        {
            InitializeComponent();
            loadclass();


            //HCS-pdbasepar-sec02：获取当前工作台下所有流程的参数
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            dtpdpart = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparameter-sec04", null);
            dtpartvalue = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec03", null);

            //HCS-apppd-sec001
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, App_ID);
            dtapppd = reCnasRemotCall.RemotInterface.SelectData("HCS-apppd-sec002", sttemp02);
            if (dtapppd != null)
            {
                for (int i = 0; i < dtapppd.Rows.Count; i++)
                {
                    App_pd = App_pd + ",'" + dtapppd.Rows[i]["pd_code"].ToString() + "'";
                    //App_pd = App_pd + "," + dtapppd.Rows[i]["pd_code"].ToString() ;
                    sl_allpd.Add(dtapppd.Rows[i]["pd_code"].ToString(), dtapppd.Rows[i]["pd_name"].ToString());
                }
                App_pd = App_pd.Substring(1);
            }


            load_workorder("0");

        }

        private void loadclass()
        {
            object result = null;
            Type typeofControl = null;
            Assembly tempAssembly;
            tempAssembly = Assembly.LoadFrom("CnasWorkflowArithmetic.dll");
            typeofControl = tempAssembly.GetType("Cnas.wns.CnasWorkflowArithmetic.WorkflowArithmeticClass");
            result = Activator.CreateInstance(typeofControl);
            CnasHCSWorkflowInterface01 = (CnasHCSWorkflowInterface)result;


        }


        private void load_workorder(string ordertype)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, App_pd);
            //string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec001", sttemp01);
            dtallorder = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec001", sttemp01);
            dgv_01.Rows.Clear();
            if (dtallorder == null) return;
            dgv_01.RowCount = dtallorder.Rows.Count;
            for (int i = 0; i < dtallorder.Rows.Count; i++)
            {
                if (dtallorder.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = dtallorder.Rows[i]["id"].ToString();
                if (dtallorder.Rows[i]["set_code"] != null) dgv_01.Rows[i].Cells["set_code"].Value = dtallorder.Rows[i]["set_code"].ToString();
                if (dtallorder.Rows[i]["wf_code"] != null)
                {
                    string strwfcode = dtallorder.Rows[i]["wf_code"].ToString();
                    dgv_01.Rows[i].Cells["wf_code"].Value = strwfcode + "：" + sl_allpd[strwfcode].ToString();
                }
                if (dtallorder.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = dtallorder.Rows[i]["ca_name"].ToString();
                if (dtallorder.Rows[i]["run_times"] != null) dgv_01.Rows[i].Cells["run_times"].Value = dtallorder.Rows[i]["run_times"].ToString();
                if (dtallorder.Rows[i]["status"] != null) dgv_01.Rows[i].Cells["status"].Value = dtallorder.Rows[i]["status"].ToString();
                if (dtallorder.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = dtallorder.Rows[i]["cre_date"].ToString();
                if (dtallorder.Rows[i]["remark"] != null) dgv_01.Rows[i].Cells["remark"].Value = dtallorder.Rows[i]["remark"].ToString();
            }
        }

        private void tb_barcode_Leave(object sender, EventArgs e)
        {
            if (mcb_customer.Focused == false && mcb_cost.Focused == false && mcb_ordertype.Focused == false)
            {
                tb_barcode.Focus();
            }

        }

        private void gp_top_SizeChanged(object sender, EventArgs e)
        {
            // mtb_cssd.Size = new System.Drawing.Size(gp_top.Width - mtb_cssd.Location.X-5, mtb_cssd.Height);

        }

        private void cmt_main_UserMonitoButtonSelect(object sender, EventArgs e, string infodata)
        {

        }

        private void mett_01_Click(object sender, EventArgs e)
        {
            HCSSM_scanbarcode HCSSM_scanbarcode01 = new HCSSM_scanbarcode(CnasHCSWorkflowInterface01, "BCB0000002390", dtpdpart, dtapppd, dtpartvalue);
            HCSSM_scanbarcode01.ShowDialog();
            load_workorder("");

        }

        private void HCSSM_workspace_decon_Load(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }

        private void HCSSM_workspace_decon_Activated(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }


        private void mcb_customer_Leave(object sender, EventArgs e)
        {
            if (mcb_cost.Focused == false && mcb_ordertype.Focused == false)
            {
                tb_barcode.Focus();
            }
        }

        private void mcb_cost_Leave(object sender, EventArgs e)
        {
            if (mcb_customer.Focused == false && mcb_ordertype.Focused == false)
            {
                tb_barcode.Focus();
            }
        }

        private void mcb_ordertype_Leave(object sender, EventArgs e)
        {
            if (mcb_customer.Focused == false && mcb_cost.Focused == false)
            {
                tb_barcode.Focus();
            }
        }

        private void tb_barcode_TextChanged(object sender, EventArgs e)
        {
            tb_seach.Text = tb_barcode.Text;

            if (tb_seach.Text.Length == 13 && tb_seach.Text.Substring(0, 2) == "BC")
            {

                //search
                string str_tmp = tb_seach.Text.Substring(0, 3);
                if (str_tmp == "BCB")
                {
                    searchdata(tb_seach.Text);
                }
                //barcode
                tb_barcode.Text = "";

            }
        }

        private void tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {

                //search
                string str_tmp = "";
                if (tb_seach.Text.Length == 13) str_tmp = tb_seach.Text.Substring(0, 3);
                if (str_tmp == "BCB")
                {
                    searchdata(tb_seach.Text);
                }

                //barcode
                tb_barcode.Text = "";

            }
        }

        private void searchdata(string indata)
        {
            //Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, indata, "信息提示");
            HCSSM_scanbarcode HCSSM_scanbarcode01 = new HCSSM_scanbarcode(CnasHCSWorkflowInterface01, indata, dtpdpart, dtapppd, dtpartvalue);
            HCSSM_scanbarcode01.ShowDialog();
            load_workorder("");

        }

        private void mcb_customer_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == 13 || ((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || ((int)e.KeyChar >= (int)'A' && (int)e.KeyChar <= (int)'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                tb_barcode.Focus();
                tb_barcode.Text = e.KeyChar.ToString();
                tb_barcode.SelectionStart = tb_barcode.Text.Length;
            }
        }

        private void mcb_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 || ((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || ((int)e.KeyChar >= (int)'A' && (int)e.KeyChar <= (int)'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                tb_barcode.Focus();
                tb_barcode.Text = e.KeyChar.ToString();
                tb_barcode.SelectionStart = tb_barcode.Text.Length;
            }
        }

        private void mcb_ordertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 || ((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || ((int)e.KeyChar >= (int)'A' && (int)e.KeyChar <= (int)'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                tb_barcode.Focus();
                tb_barcode.Text = e.KeyChar.ToString();
                tb_barcode.SelectionStart = tb_barcode.Text.Length;
            }
        }

        private void HCSSM_workspace_decon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsm_print_Click(object sender, EventArgs e)
        {
			try
			{
				if (dgv_01.CurrentRow == null)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("selectPrintData", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//获得当前选择行数据
				string barCode = dgv_01.CurrentRow.Cells["set_code"].Value != null ?
					dgv_01.CurrentRow.Cells["set_code"].Value.ToString() : string.Empty;
				string codeName = dgv_01.CurrentRow.Cells["ca_name"].Value != null ?
					dgv_01.CurrentRow.Cells["ca_name"].Value.ToString() : string.Empty;

				if (!string.IsNullOrEmpty(barCode))
				{
					SortedList parameters = new SortedList();
					parameters.Add("BarcodeValue", barCode);
					parameters.Add("Value", codeName);

					string printResult = BarCodeHelper.PrintBarCode(barCode, parameters);
					if (!string.IsNullOrEmpty(printResult))
						MessageBox.Show(printResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("invalidatecode", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }
    }
}
