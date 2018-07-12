using Cnas.wns.CnasBaseClassClient;
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
    public partial class HCSCM_set_manager_cre_set : Form
    {
        private DataRow[] arrayDR = null;//用于传输数据,最后存放的是基本包信息
        SortedList Sl_type_01 = new SortedList();//存储成本中心
        SortedList Sl_type_02 = new SortedList();//存储所属顾客
        public HCSCM_set_manager_cre_set(string selectname, string strbarcode)
        {
            InitializeComponent();
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建实体包";
            //表格栏底色
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //dgv表格各字段居中
            this.dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tb_name.Text = selectname;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec003", null);//成本中心
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii;i++)
                {
                    if(getdt.Rows[i]["bar_code"].ToString()!=null&&getdt.Rows[i]["ca_name"].ToString().Trim()!=null)
                    {
                        Sl_type_01.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                    }
                }
            }
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//顾客
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii;i++)
                {
                    if(getdt.Rows[i]["bar_code"].ToString()!=null&&getdt.Rows[i]["cu_name"].ToString().Trim()!=null)
                    {
                        Sl_type_02.Add(getdt.Rows[i]["bar_code"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
                    }
                }
            }
            SortedList sttemp01 = new SortedList();
            
            sttemp01.Add(1, CnasBaseData.SystemID);
            string str = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-base-sec001", sttemp01);
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttemp01);//基本包信息
            if(getdt!=null)
            {
                arrayDR = getdt.Select("bar_code="+"'"+strbarcode+"'");
            }

            Loaddata(strbarcode);
        }
        private void Loaddata(string base_code)
        {

            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1,base_code);
            DataTable getdt02 = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec002", sttemp01);//实体包数量
            sttemp01.Add(2, CnasBaseData.SystemID);
         //   string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-set-sec001", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec001", sttemp01);
            
            if (getdt != null&&getdt02!=null)
            {

                tb_inum.Text = getdt02.Rows[0]["COUNT(base_setcode)"].ToString();

                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["ca_name"] != null) dgv_01.Rows[i].Cells["ca_name"].Value = getdt.Rows[i]["ca_name"].ToString();
                    if (getdt.Rows[i]["customer_code"] != null) dgv_01.Rows[i].Cells["customer_code"].Value = Sl_type_02[getdt.Rows[i]["customer_code"].ToString()].ToString();//值是bar_code
                    if (getdt.Rows[i]["cost_center"] != null) dgv_01.Rows[i].Cells["cost_center"].Value = Sl_type_01[getdt.Rows[i]["cost_center"].ToString()].ToString();
                    if (getdt.Rows[i]["bar_code"] != null) dgv_01.Rows[i].Cells["bar_code"].Value = getdt.Rows[i]["bar_code"].ToString();
                    if (getdt.Rows[i]["cre_date"] != null) dgv_01.Rows[i].Cells["cre_date"].Value = getdt.Rows[i]["cre_date"].ToString();
                    if (getdt.Rows[i]["mod_date"] != null) dgv_01.Rows[i].Cells["mod_date"].Value = getdt.Rows[i]["mod_date"].ToString();
                    if (getdt.Rows[i]["base_setcode"] != null) dgv_01.Rows[i].Cells["base_setcode"].Value = getdt.Rows[i]["base_setcode"].ToString();
                    
                }

            }
            dgv_01.Rows[0].Selected = true;
        }
        private void but_new_Click(object sender, EventArgs e)
        {
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, tb_name.Text.Trim());//名字
            sltmp.Add(2, arrayDR[0]["bar_code"].ToString());//基本包条码base_setcode
            sltmp.Add(3, arrayDR[0]["cost_center"].ToString());//成本中心
            sltmp.Add(4, arrayDR[0]["customer_code"].ToString());//顾客

            sltmp.Add(5, CnasBaseData.SystemID);
            sltmp01.Add(1, sltmp);
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-add001", sltmp01, null);
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-add001", sltmp01, null);
            if(recint<=0)
            {
                MessageBox.Show("添加失败。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Loaddata(arrayDR[0]["bar_code"].ToString());
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
