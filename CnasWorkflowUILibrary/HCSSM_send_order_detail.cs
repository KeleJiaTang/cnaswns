using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
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
	public partial class HCSSM_send_order_detail : MetroForm
	{
		private string _sendCode;
		private string _sendBatch; 

		public HCSSM_send_order_detail(string sendCode, string sendBatch)
		{
			InitializeComponent();
			this._sendBatch = sendBatch;
			this._sendCode = sendCode;
			InitializeButtonImage();
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitializeButtonImage()
		{
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			printBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
		}

		private DataTable GetOverViewList()
		{
			DataTable data = null;
			try
			{
				SortedList condition = new SortedList();
				condition.Add(1, _sendCode);
				condition.Add(2, _sendBatch);

				CnasRemotCall remoteCall = new CnasRemotCall();
#if DEBUG
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-specialset-sendinfo-sec002", condition);
#endif
				data = remoteCall.RemotInterface.SelectData("HCS-specialset-sendinfo-sec002", condition);
			}
			catch (Exception)
			{
			}

			return data;
		}

		public void InitializeDetailInfo(DataTable data)
		{
			try
			{
				if (data != null && data.Rows.Count > 0)
				{
					DataRow row = data.Rows[0];
					if (!(row["order_code"] is DBNull)) orderCodeTxt.Text = Convert.ToString(row["order_code"]);
					if (!(row["order_name"] is DBNull)) orderNameTxt.Text = Convert.ToString(row["order_name"]);
					if (!(row["send_code"] is DBNull)) sendCodeTxt.Text = Convert.ToString(row["send_code"]);
					if (!(row["cre_date"] is DBNull)) sendTimeTxt.Text = Convert.ToDateTime(row["cre_date"]).ToString("yyyy-MM-dd HH:mm");
					if (!(row["cu_name"] is DBNull)) customerTxt.Text = Convert.ToString(row["cu_name"]);
					if (!(row["u_uname"] is DBNull)) locationTxt.Text = Convert.ToString(row["u_uname"]);
				}
			}
			catch (Exception)
			{
				
				throw;
			}
		}

		public void RefreshSendInfoGrid(DataTable data)
		{
			try
			{
				sendInfoPreview.Rows.Clear();
				if (data != null)
				{
					foreach (DataRow row in data.Rows)
					{
						string bccCode = Convert.ToString(row["bcc_code"]);
						if (string.IsNullOrEmpty(bccCode))
						{
							int rowIndex = sendInfoPreview.Rows.Add();
							sendInfoPreview.Rows[rowIndex].Cells["thingIdCol"].Value = sendInfoPreview.Rows.Count;
							sendInfoPreview.Rows[rowIndex].Cells["thingNameCol"].Value = row["ca_name"];
							sendInfoPreview.Rows[rowIndex].Cells["thingNumCol"].Value = row["send_num"];
							sendInfoPreview.Rows[rowIndex].Cells["thingRemarkCol"].Value = row["remark"];
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public void RefreshDetailGrid()
		{
			try
			{
				SortedList condition = new SortedList();
				condition.Add(1, _sendCode);
				condition.Add(2, _sendBatch);
				condition.Add(3, CnasBaseData.SystemID);

				CnasRemotCall remoteCall = new CnasRemotCall();
#if DEBUG
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-senddetai-sec001", condition);
#endif
				DataTable data = remoteCall.RemotInterface.SelectData("HCS-senddetai-sec001", condition);
				if (data != null)
				{
					foreach (DataRow row in data.Rows)
					{
						int rowIndex = detailGrid.Rows.Add();
						detailGrid.Rows[rowIndex].Cells["idCol"].Value = sendInfoPreview.Rows.Count;
						detailGrid.Rows[rowIndex].Cells["bcuCodeCol"].Value = row["BCU_code"];
						detailGrid.Rows[rowIndex].Cells["setNameCol"].Value = row["ca_name"];
						DateTime startDate = Convert.ToDateTime(row["start_date"]);
						int expireDate = Convert.ToInt32(row["ca_expiration"]);
						detailGrid.Rows[rowIndex].Cells["startDateCol"].Value = startDate;
						detailGrid.Rows[rowIndex].Cells["endDateCol"].Value = startDate.AddDays(expireDate);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void OnFormLoaded(object sender, EventArgs e)
		{
			DataTable data = GetOverViewList();
			InitializeDetailInfo(data);
			RefreshSendInfoGrid(data);
			RefreshDetailGrid();
		}


		private void OnPrintBtnClick(object sender, EventArgs e)
		{
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code='Invoice'");
			if (arrayDR02.Length > 0)
			{
				string pringxml = Convert.ToString(arrayDR02[0]["other_code"]).Trim();
				if (dataGridTab.SelectedIndex == 0)
				{
					PrintHelper.Instance.Print_DataGridView(sendInfoPreview, pringxml, sendCodeTxt.Text, new string[] { customerTxt.Text.Trim(), locationTxt.Text.Trim() });
				}
				else
				{
					PrintHelper.Instance.Print_DataGridView(detailGrid, pringxml, string.Empty, new string[] { customerTxt.Text.Trim(), locationTxt.Text.Trim() });
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnCloseBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
