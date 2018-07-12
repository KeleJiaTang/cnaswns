using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	/// <summary>
	/// 编辑窗口
	/// </summary>
	public partial class HCSSM_statistics_edit : BaseForm
	{
		/// <summary>
		/// 原因dic(All)
		/// </summary>
		public Dictionary<string, string> ReasonDic;
		/// <summary>
		/// 要修改的数据行
		/// </summary>
		public DataGridViewRow ViewDataRow;
		/// <summary>
		/// 初始化
		/// </summary>
		public HCSSM_statistics_edit()
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public override void InitializeButtonImage()
		{
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
		}

		public override void InitalizeControl()
		{
			if (ViewDataRow != null && ReasonDic != null && ReasonDic.Count > 0)
			{
				txtAreaName.Text = Convert.ToString(ViewDataRow.Cells["location_idText"].Value);
				txtTypeName.Text = Convert.ToString(ViewDataRow.Cells["entity_typeText"].Value);
				txtItemName.Text = Convert.ToString(ViewDataRow.Cells["ca_name"].Value);
				txtItemCount.Text = Convert.ToString(ViewDataRow.Cells["num"].Value);
				BindingSource bs = new BindingSource();
				bs.DataSource = ReasonDic;
				cbbReason.DataSource = bs;
				cbbReason.DisplayMember = "Value";
				cbbReason.ValueMember = "Key";
				cbbReason.SelectedValue = Convert.ToString(ViewDataRow.Cells["type"].Value);
				txtRemark.Text = Convert.ToString(ViewDataRow.Cells["remark"].Value);
				if(!txtTypeName.Text.Equals("器械"))
				{
					txtItemCount.Enabled = false;
				}
				else
				{
					txtItemCount.Enabled = true;
				}
			}
		}

		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			int id = 0;//对应id
			string idStr = Convert.ToString(ViewDataRow.Cells["id"].Value);
			Int32.TryParse(idStr, out id);
			int num = 1;
			string numStr = txtItemCount.Text.Trim();
			string remark = txtRemark.Text.Trim();
			int reasonCode = 0;
			KeyValuePair<string,string> item=(KeyValuePair<string,string>)cbbReason.SelectedItem;
			string reasonStr=item.Key;
			Int32.TryParse(reasonStr, out reasonCode);
			bool isNum=Int32.TryParse(numStr,out num);
			if(!isNum)
			{
				MessageBox.Show("器械的数量：请填写数字");
				return;
			}
			SortedList paramlist = new SortedList();
			SortedList condition = new SortedList();
			condition.Add(1, reasonCode);
			condition.Add(2, num);
			condition.Add(3, remark);
			condition.Add(4, id);
			paramlist.Add(1, condition);
			CnasRemotCall remoteClient =new CnasRemotCall();
			string testUpSql = remoteClient.RemotInterface.CheckUPData(1, "HCS-qualitydetection-area-up003", paramlist, null);
			int result = remoteClient.RemotInterface.UPData(1, "HCS-qualitydetection-area-up003", paramlist, null);
			if(result>0)
			{
				ViewDataRow.Cells["typeText"].Value = item.Value;
				ViewDataRow.Cells["type"].Value = reasonCode;
				ViewDataRow.Cells["num"].Value = num;
				ViewDataRow.Cells["remark"].Value = remark;
			}
			Close();
		}
	}
}
