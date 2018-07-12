using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_dressing_info_manage : Form
    {
        private SortedList sl_DressingType = new SortedList();
        
        private string select_id = "";
        public static String txt = "";//敷料包名称
        private string dre = "";
        public HCSCM_dressing_info_manage(SortedList slselect)
        {
            InitializeComponent();
            //this.Font = new Font(this.Font.FontFamily, 11);

            dre = tb_dre.Text = slselect["ca_name"].ToString();//敷料包名称
            select_id = slselect["id"].ToString();//敷料包ID
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //获取敷料包衣物的类型
            DataRow[] typeDR = CnasBaseData.SystemBaseData.Select("type_code='HCS_dressing_info'");
                 foreach (DataRow dr in typeDR)
            {
                sl_DressingType.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            SortedList sttmp = new SortedList();
            sttmp.Add(1,CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-set-sec001", sttmp);
            int ii = getdt.Rows.Count;
            if (ii <= 0) return;
            for (int i = 0; i < ii;i++ )
                if(getdt.Rows[i]["id"].ToString().Trim()!=null&&getdt.Rows[i]["ca_name"].ToString().Trim()!=null)
                {
                    sl_DressingType.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
                }
            Loaddata(select_id);
            //表格栏底色
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //DGV表格首行字段居中对齐
            dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     
        }
        //根据敷料包的ID来读取该包信息
        private void Loaddata(string dre_id)
        {
            dgv_01.Rows.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp = new SortedList();
            sttmp.Add(1, dre_id);
          //String ggg= reCnasRemotCall.RemotInterface.CheckSelectData("HCS-dressing-info-sec001", sttmp);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-dressing-info-sec001", sttmp);
            if (getdt != null)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
                    if (getdt.Rows[i]["dre_id"] != null) dgv_01.Rows[i].Cells["dre_id"].Value = sl_DressingType[getdt.Rows[i]["dre_id"].ToString()].ToString();
                    if (getdt.Rows[i]["dre_count"] != null) dgv_01.Rows[i].Cells["dre_count"].Value = getdt.Rows[i]["dre_count"].ToString();
                    if (getdt.Rows[i]["dre_type"] != null) dgv_01.Rows[i].Cells["dre_type"].Value = sl_DressingType[getdt.Rows[i]["dre_type"].ToString()].ToString();
                    if (getdt.Rows[i]["ca_remarks"] != null) dgv_01.Rows[i].Cells["ca_remarks"].Value = getdt.Rows[i]["ca_remarks"].ToString();
                    if (getdt.Rows[i]["dre_name"] != null) dgv_01.Rows[i].Cells["dre_name"].Value = getdt.Rows[i]["dre_name"].ToString();
                }
            }
        }

        private void but_new_Click(object sender, EventArgs e)
        {
            txt = tb_dre.Text;
            HCSCM_dressing_new hcsm = new HCSCM_dressing_new(null, select_id, dre);
            //获取一个值，指是否在Windows任务栏中显示窗体。
            hcsm.ShowInTaskbar = false;
            hcsm.ShowDialog();
            Loaddata(select_id);
        }
        //修改
        private void but_edit_Click(object sender, EventArgs e)
        {
             SortedList slindata = new SortedList();
            try
            {
                slindata.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value);
                slindata.Add("dre_id", dgv_01.SelectedRows[0].Cells["dre_id"].Value);
                slindata.Add("dre_name", dgv_01.SelectedRows[0].Cells["dre_name"].Value);
                slindata.Add("dre_count", dgv_01.SelectedRows[0].Cells["dre_count"].Value);
                slindata.Add("dre_type", dgv_01.SelectedRows[0].Cells["dre_type"].Value);
                
                slindata.Add("ca_remarks", dgv_01.SelectedRows[0].Cells["ca_remarks"].Value);

                HCSCM_dressing_new hcsm = new HCSCM_dressing_new(slindata, null, dre);
                hcsm.ShowDialog();
                Loaddata(select_id);
            }
            catch
            {
                MessageBox.Show("请选择敷料包衣物。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata(select_id);
            }
        }

        //删除
        private void but_remove_Click(object sender, EventArgs e)
        {
             try
            {
                if (MessageBox.Show("确定删除编号为： " + dgv_01.SelectedRows[0].Cells["id"].Value.ToString()+"的衣物吗？", ConfigurationManager.AppSettings["SystemName"].ToString()+"--删除敷料包衣物", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SortedList sltmp = new SortedList();
                SortedList sltmp01 = new SortedList();
                sltmp01.Add(1, dgv_01.SelectedRows[0].Cells["id"].Value);
                sltmp.Add(1, sltmp01);
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
               // string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-dressing-info-del001", sltmp, null);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-dressing-info-del001", sltmp, null);
                if (recint > -1)
                {
                    MessageBox.Show("恭喜你，删除敷料包衣物成功。","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Loaddata(select_id);
                }
            }
            catch
            {
                MessageBox.Show("请选择敷料包衣物。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
        private void but_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}