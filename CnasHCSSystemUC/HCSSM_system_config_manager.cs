using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using Telerik.WinControls.UI;
using System.Collections;

namespace Cnas.wns.CnasHCSSystemUC
{
	public partial class HCSSM_system_config_manager : UserControl
	{
		public string AppID = string.Empty;
		private List<string> _saveList = new List<string>();
		private bool _isManagerConfigable = true;

		/// <summary>
		/// 
		/// </summary>
		public bool  IsManagerConfigable
		{
			get
			{
				return _isManagerConfigable;
			}
			set
			{
				if (value != _isManagerConfigable)
					_isManagerConfigable = value;
			}
		}

		public HCSSM_system_config_manager()
		{
			InitializeComponent();
			this.Font = new Font("宋体", 9);
		}

		private void InitializeView()
		{
			UseSetWithBiology.Visible = IsManagerConfigable;
			IsShowRFIDDialog.Visible = IsManagerConfigable;
			CheckedSetInstrument.Visible = IsManagerConfigable;
			SendSetWithBiology.Visible = IsManagerConfigable;
			setInCSSDTimeLbl.Visible = IsManagerConfigable;
			SetInCSSDTime.Visible = IsManagerConfigable;
			timeLbl.Visible = IsManagerConfigable;
		}

		private void OnSaveBtnClick(object sender, EventArgs e)
		{
			SortedList sqlParameters = new SortedList();
			
			SortedList configList = SaveConfigList();
			sqlParameters.Add(1, configList);
			SavePrintList(ref sqlParameters);
			try
			{
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS-config-data-up001", sqlParameters);
				int result = remoteCall.RemotInterface.UPDataList("HCS-config-data-up001", sqlParameters);
				if (result > 0)
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("UpdateSystemOK", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception)
			{
			}
		}

		private void OnPrintSettingBtnClick(object sender, EventArgs e)
		{
			Button printBtn = sender as Button;
			if (printBtn != null)
			{
				string printType = printBtn.Name.Substring(printBtn.Name.IndexOf("_") + 1);
				PrintDialog dialog = new PrintDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					string textBoxName = string.Format("printTxt_{0}", printType);
					RadTextBox configControl = CnasUtilityTools.FindControl<RadTextBox>(this, textBoxName);
					if (configControl != null)
					{
					   configControl.Text = dialog.PrinterSettings.PrinterName;
					}
				}

			}
		}

		private void OnDialogLoaded(object sender, EventArgs e)
		{
			InitializeButtionImage();
			InitializeView();
			InitializeSettings();
			InitializePrinter();
		}

		public void InitializeButtionImage()
		{
			if (AppID.StartsWith("1"))
			{
				saveBtn.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSave32", EnumImageType.PNG);
			}
			else
			{
				saveBtn.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "save", EnumImageType.PNG);
			}
		}

		private void InitializeSettings()
		{
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, "HCS-system-settings");
			CnasRemotCall remoteCall = new CnasRemotCall();
			string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-config-data-sec001", condition);
			DataTable data = remoteCall.RemotInterface.SelectData("HCS-config-data-sec001", condition);

			if (data != null)
			{
				foreach (DataRow config in data.Rows)
				{
					string keyCode = Convert.ToString(config["key_code"]);
					string valueCode = Convert.ToString(config["value_code"]);
					string otherCode = Convert.ToString(config["other_code"]);
					_saveList.Add(keyCode);
					Control configControl = CnasUtilityTools.FindControl<Control>(this, keyCode);
					if (configControl!= null)
					{
						if (configControl is RadTextBox)
						{
							RadTextBox control = configControl as RadTextBox;
							control.Text = valueCode;
						}
						else if (configControl is CheckBox)
						{
							CheckBox control = configControl as CheckBox;
							control.Checked = valueCode == "1";
						}
					}
				}
			}
		}

		private void InitializePrinter()
		{
			try
			{
				SortedList condition = new SortedList();
				condition.Add(1, CnasBaseData.MacAddress);
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-config-data-sec002", condition);
				DataTable data = remoteCall.RemotInterface.SelectData("HCS-config-data-sec002", condition);
				if (data != null)
				{
					foreach (DataRow row in data.Rows)
					{
						string printType = Convert.ToString(row["print_type"]);
						string printName = Convert.ToString(row["print_name"]);
						string computerName = Convert.ToString(row["computer_name"]);
						string id = Convert.ToString(row["id"]);
						string controlName = string.Format("printTxt_{0}", printType);
						RadTextBox configControl = CnasUtilityTools.FindControl<RadTextBox>(this, controlName);
						if (configControl != null)
						{
							configControl.Text = printName;
							configControl.Tag = id;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private SortedList SaveConfigList()
		{
			SortedList updateList = new SortedList();
			foreach (string config in _saveList)
			{
				Control configControl = CnasUtilityTools.FindControl<Control>(this, config);
				if (configControl!= null)
				{
					SortedList updateData = new SortedList();
					if (configControl is RadTextBox)
					{
						RadTextBox control = configControl as RadTextBox;
						updateData.Add(1, control.Text);
					}
					else if (configControl is CheckBox)
					{
						CheckBox control = configControl as CheckBox;
						updateData.Add(1, control.Checked ? "1" : "0");
					}
					if (!updateData.ContainsKey(1))
						updateData.Add(1, "0");
					updateData.Add(2, config);
					updateList.Add(updateList.Count + 1, updateData);
				}
			}

			return updateList;
		}

		private void SavePrintList(ref SortedList sqlParameters)
		{
			SortedList printList = new SortedList();
			SortedList updatePrintList = new SortedList();
			sqlParameters.Add(2, printList);
			sqlParameters.Add(3, updatePrintList);
			try 
			{
				foreach (Control configControl in printPanel.Controls)
				{
					if (configControl is RadTextBox)
					{
						SortedList updateData = new SortedList();
						RadTextBox control = configControl as RadTextBox;
						if (!string.IsNullOrEmpty(control.Text))
						{
							if (string.IsNullOrEmpty(Convert.ToString(control.Tag)))
							{
								printList.Add(printList.Count + 1, updateData);
							}
							else
							{
								updatePrintList.Add(updatePrintList.Count + 1, updateData);
							}

							updateData.Add(1, control.Text);
							string printType = control.Name.Substring(control.Name.IndexOf("_") + 1);
							updateData.Add(2, printType);
							updateData.Add(3, CnasBaseData.MacAddress);
						}
					}
				}
			}
			catch (Exception)
			{
				
			}
		}

		private void OnKeyPressEvent(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

	}
}
