using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using Cnas.wns.CnasBaseClassClient;
using CnasUI;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_set_storage : TemplateForm
    {
        SortedList sl_type01 = new SortedList();
        DataTable DTlocation = new DataTable();
        
        SortedList sl_uselocation = new SortedList();
        public SortedList StoragePlace = new SortedList();
        public HCSCM_set_storage()
        {
            InitializeComponent();
            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_select.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "Choice", EnumImageType.PNG);
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            #region 按钮图片加载

            this.but_new.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "new", EnumImageType.PNG);
            

            #endregion
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"] + "--选择存储点";
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            //获取存储点类型
            DataRow[] type = CnasBaseData.SystemBaseData.Select("type_code='HCS-storage-type'");
            foreach (DataRow dr in type)
            {
                sl_type01.Add(dr["key_code"].ToString().Trim(), dr["value_code"].ToString().Trim());
            }
            //获取使用地点数据
            DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
            if (DTlocation != null)
            {
                int ii = DTlocation.Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
                    {
                        sl_uselocation.Add(DTlocation.Rows[i]["id"].ToString(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
                    }
                }
            }
            Loaddata();
        }
        private void Loaddata()
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sl_type = new SortedList();
            sl_type.Add(1, 1);
          //  string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec004", sl_type);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec004", sl_type);
            if (getdt != null && getdt.Rows.Count>0)
            {
                int ii = getdt.Rows.Count;
                if (ii <= 0) return;
                dgv_01.RowCount = ii;
                for (int i = 0; i < ii; i++)
                {
                    if (getdt.Columns.Contains("s_type") && getdt.Rows[i]["s_type"] != null) dgv_01.Rows[i].Cells["s_type"].Value = sl_type01[getdt.Rows[i]["s_type"].ToString()].ToString();
					if (getdt.Columns.Contains("id") && getdt.Rows[i]["id"] != null) dgv_01.Rows[i].Cells["id"].Value = getdt.Rows[i]["id"].ToString();
					if (getdt.Columns.Contains("s_barcode") && getdt.Rows[i]["s_barcode"] != null) dgv_01.Rows[i].Cells["s_barcode"].Value = getdt.Rows[i]["s_barcode"].ToString();
					if (getdt.Columns.Contains("s_name") && getdt.Rows[i]["s_name"] != null) dgv_01.Rows[i].Cells["s_name"].Value = getdt.Rows[i]["s_name"].ToString();
					if (getdt.Columns.Contains("s_uselocation") && getdt.Rows[i]["s_uselocation"] != null) dgv_01.Rows[i].Cells["s_location"].Value = sl_uselocation[getdt.Rows[i]["s_uselocation"].ToString()].ToString();

                }
				dgv_01.CurrentRow = dgv_01.Rows[0];
            }
            
        }
           
        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void but_new_Click(object sender, EventArgs e)
        {
            HCSCM_storage_manage_new hcsm = new HCSCM_storage_manage_new(null);
            hcsm.ShowDialog();
            Loaddata();
            if (dgv_01.Rows.Count > 0)
            {
                dgv_01.CurrentRow = dgv_01.Rows[dgv_01.RowCount - 1];
            }
        }

        private void but_select_Click(object sender, EventArgs e)
        {
            if (dgv_01.SelectedRows != null && dgv_01.SelectedRows.Count > 0 && dgv_01.SelectedRows[0] != null)
            {
                StoragePlace.Add("s_name", dgv_01.SelectedRows[0].Cells["s_name"].Value.ToString());
                StoragePlace.Add("id", dgv_01.SelectedRows[0].Cells["id"].Value.ToString());
                this.Close();
            }
        }

		private void dgv_01_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			but_select_Click(null, null);
		}
    }
}
