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

namespace Cnas.wns.CnasHCSWorkspaceSterilization
{
    public partial class HCSSM_parameters_select : MetroForm
    {
        /// <summary>
        /// 返回类型2的参数和参数值
        /// </summary>
        public SortedList SL_returnparametersvalue = new SortedList();
        public SortedList SL_returnparametersinfo = new SortedList();

        public int Int_rec = -1;
        public string Next_PDcode = "";
        /// <summary>
        /// 参数所有值集合
        /// </summary>
        private DataTable dtpartvalue = new DataTable();
        /// <summary>
        /// 流程参数配置表
        /// </summary>
        private DataTable dtpartvalueconfig = new DataTable();

        //private int cyc_count = 0, run_times=0;
        private string str_parname = "", str_next_code = "", str_wfid = "";

        public HCSSM_parameters_select(string strwfid, SortedList sl_par02, DataTable dtpartvaluedata)
        {
            InitializeComponent();
            //SL_returnparametersvalue = sl_par02;
            str_wfid = strwfid;
            dtpartvalue = dtpartvaluedata;
            //cyc_count = SL_returnparametersvalue.Count;

            //HCS-pdparametervalue-sec04
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, strwfid);
            //string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-pdparametervalue-sec04", sttemp01);
            dtpartvalueconfig = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec04", sttemp01);
            if (dtpartvalueconfig == null)
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
                this.Close();
            }
            else
            {
                //开始第一个参数选择
                mlab_next.Text = dtpartvalueconfig.Rows[0]["par_description"].ToString();
                string str_01 = dtpartvalueconfig.Rows[0]["par_code"].ToString();
                str_next_code = dtpartvalueconfig.Rows[0]["next_code"].ToString();
                str_parname = dtpartvalueconfig.Rows[0]["par_name"].ToString();
                DataRow[] arrayDR = dtpartvalue.Select("par_code='" + str_01 + "'");
                mcb_result.Items.Clear();
                foreach (DataRow dr in arrayDR)
                {
                    mcb_result.Items.Add(dr["v_value"].ToString() + "：" + dr["v_name"].ToString());
                }
            }
        }

        private void select_data(string inparcodedata)
        {
            DataRow[] arrayDR01 = dtpartvalueconfig.Select("par_code='" + inparcodedata + "'");
            if (arrayDR01.Length < 1)
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
                this.Close();
            }
            else
            {
                mlab_next.Text = arrayDR01[0]["par_description"].ToString();
                string str_01 = arrayDR01[0]["par_code"].ToString();
                str_next_code = arrayDR01[0]["next_code"].ToString();
                str_parname = arrayDR01[0]["par_name"].ToString();

                DataRow[] arrayDR = dtpartvalue.Select("par_code='" + str_01 + "'");
                mcb_result.Items.Clear();
                foreach (DataRow dr in arrayDR)
                {
                    mcb_result.Items.Add(dr["v_value"].ToString() + "：" + dr["v_name"].ToString());
                }
            }
        }

        private void mett_03_Click(object sender, EventArgs e)
        {
            string[] strarr = mcb_result.Text.Split('：');
            SL_returnparametersvalue.Add(str_parname, strarr[0]);
            SL_returnparametersinfo.Add(str_parname, tex_remark.Text.Trim());

            if (str_next_code.Trim() == "" || str_next_code.Substring(0, 1) == "P")
            {
                //参数配置完成，直接提交结果
                if (str_next_code.Trim() != "") Next_PDcode = str_next_code.Substring(1);
                Int_rec = 0;
                this.Close();

            }
            else if (str_next_code.Substring(0, 1) == "A")
            {
                //连续配置参数和信息
                tex_remark.Text = "";
                select_data(str_next_code.Substring(1));

            }
            else
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
                this.Close();
            }
        }

        private void mett_01_Click(object sender, EventArgs e)
        {
            Next_PDcode = "";
            SL_returnparametersinfo.Clear();
            SL_returnparametersvalue.Clear();
            //开始第一个参数选择
            mlab_next.Text = dtpartvalueconfig.Rows[0]["par_description"].ToString();
            string str_01 = dtpartvalueconfig.Rows[0]["par_code"].ToString();
            str_next_code = dtpartvalueconfig.Rows[0]["next_code"].ToString();
            str_parname = dtpartvalueconfig.Rows[0]["par_name"].ToString();
            DataRow[] arrayDR = dtpartvalue.Select("par_code='" + str_01 + "'");
            mcb_result.Items.Clear();
            foreach (DataRow dr in arrayDR)
            {
                mcb_result.Items.Add(dr["v_value"].ToString() + "：" + dr["v_name"].ToString());
            }
        }

        private void mett_02_Click(object sender, EventArgs e)
        {
            Int_rec = -1;//不提交选择
            this.Close();
        }
    }
}
