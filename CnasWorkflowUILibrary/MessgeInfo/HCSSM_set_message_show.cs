using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_set_message_show : MetroForm
	{
		public string SetBarCode { get; set; }

		public UserBase UserBase { get; set; }

		public HCSSM_set_message_show()
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public int GetMessageList(string pdCode)
		{
			int searchResult = 0;
			try
			{
				CnasRemotCall remoteClient = new CnasRemotCall();
				SortedList condition = new SortedList();
				SortedList messageList = new SortedList();
				condition.Add(1, SetBarCode);
				condition.Add(2, pdCode);
				string sqlTest = remoteClient.RemotInterface.CheckSelectData("HCS-set-message-sec001", condition);
				DataTable data = remoteClient.RemotInterface.SelectData("HCS-set-message-sec001", condition);
				if (data != null)
				{
					foreach (DataRow row in data.Rows)
					{
						int rowIndex = messageGrid.Rows.Add();
						if (data.Columns.Contains("id"))
							messageGrid.Rows[rowIndex].Cells["idCol"].Value = row["id"];
						if (data.Columns.Contains("subject"))
							messageGrid.Rows[rowIndex].Cells["subjectCol"].Value = row["subject"];
						if (data.Columns.Contains("me_priorty"))
							messageGrid.Rows[rowIndex].Cells["priortyCol"].Value = row["me_priorty"];
						if (data.Columns.Contains("me_type"))
							messageGrid.Rows[rowIndex].Cells["typeCol"].Value = row["me_type"];
						if (data.Columns.Contains("description"))
							messageGrid.Rows[rowIndex].Cells["descriptionCol"].Value = row["description"];
						if (data.Columns.Contains("start_date"))
							messageGrid.Rows[rowIndex].Cells["startDateCol"].Value = row["start_date"];
						if (data.Columns.Contains("end_date"))
							messageGrid.Rows[rowIndex].Cells["endDateCol"].Value = row["end_date"];
						if (data.Columns.Contains("state"))
						{
							messageGrid.Rows[rowIndex].Cells["stateCol"].Value = row["state"];
							int state = Convert.ToInt32(row["state"]);
							if (state == 2)
								messageGrid.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
						}
					}
					messageGrid.ClearSelection();
					if (data.Rows.Count > 0)
					{
						if (data.Columns.Contains("set_code"))
							setCodeTxt.Text = Convert.ToString(data.Rows[0]["set_code"]);
						if (data.Columns.Contains("ca_name"))
							setNameTxt.Text = Convert.ToString(data.Rows[0]["ca_name"]);
					}

					searchResult = messageGrid.RowCount;
				}
			}
			catch (Exception)
			{
			}
			return searchResult;
		}	

		/// <summary>
		/// 禁用/启用按钮事件
		/// </summary>
		/// <param name="sender">the disable button</param>
		/// <param name="e">the event</param>
		private void disableBtn_Click(object sender, EventArgs e)
		{
			if (messageGrid.SelectedRows.Count > 0)
			{
				int state = Convert.ToInt32(messageGrid.SelectedRows[0].Cells["stateCol"].Value);
				bool isEnable = state == 1;
				int messageId = Convert.ToInt32(messageGrid.SelectedRows[0].Cells["idCol"].Value);
				int result = ModifyMessageState(messageId,(isEnable ? "2" : "1"));
				if (result > 0)
				{
					messageGrid.Rows.Remove(messageGrid.SelectedRows[0]);
					//disableBtn.Text = isEnable ? "启 用 " : "禁 用 ";
					//messageGrid.SelectedRows[0].Cells["stateCol"].Value = isEnable ? 2 : 1;
					//messageGrid.SelectedRows[0].DefaultCellStyle.BackColor = isEnable ? Color.LightGray: Color.White;
					if (messageGrid.Rows.Count == 0)
						this.Close();
				}
			}
		}

		private int ModifyMessageState(int messageId, string state)
		{
			int result = 0;
			try
			{
				CnasRemotCall remoteCall = new CnasRemotCall();
				SortedList sqlParam = new SortedList();
				SortedList itemList = new SortedList();
				sqlParam.Add(1, itemList);
				itemList.Add(1, state);
				itemList.Add(2, UserBase != null ? UserBase.UserID : CnasBaseData.UserBaseInfo.UserID);
				itemList.Add(3, messageId);
				string testSql = remoteCall.RemotInterface.CheckUPData(1, "HCS-set-message-info-show-up001", sqlParam, null);
				result = remoteCall.RemotInterface.UPData(1, "HCS-set-message-info-show-up001", sqlParam, null);
			}
			catch (Exception)
			{
			}
			return result;
		}
		
		/// <summary>
		/// 删除按钮事件
		/// </summary>
		/// <param name="sender">the delete button</param>
		/// <param name="e">the event</param>
		private void deleteBtn_Click(object sender, EventArgs e)
		{
			if (messageGrid.SelectedRows.Count > 0)
			{
				int state = Convert.ToInt32(messageGrid.SelectedRows[0].Cells["stateCol"].Value);
				bool isEnable = state == 1;
				int messageId = Convert.ToInt32(messageGrid.SelectedRows[0].Cells["idCol"].Value);
				int result = ModifyMessageState(messageId,"9");
				if (result > 0)
				{
					messageGrid.Rows.Remove(messageGrid.SelectedRows[0]);
					if (messageGrid.Rows.Count == 0)
						this.Close();
				}
			}
		}

		/// <summary>
		///  关闭按钮事件
		/// </summary>
		/// <param name="sender">the close button</param>
		/// <param name="e">the event</param>
		private void closeBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnMessageListSelectionChanged(object sender, EventArgs e)
		{
			
			if (messageGrid.SelectedRows.Count > 0)
			{
				int state = Convert.ToInt32(messageGrid.SelectedRows[0].Cells["stateCol"].Value);
				disableBtn.Text = state == 2 ? "启 用 ":"禁 用 ";
			}
		}

		private void OnFormLoaded(object sender, EventArgs e)
		{
			InitializeButtonImage();
		}

		private void InitializeButtonImage()
		{
			disableBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mStopWarning32", EnumImageType.PNG);
			deleteBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDelete32", EnumImageType.PNG);
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}
	}
}
