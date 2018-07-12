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
	public partial class HCSSM_statistics_quality : BaseForm
	{
		/// <summary>
		/// 区域 
		/// </summary>
		public string AreaNum;
		/// <summary>
		/// 区域对应原因编码
		/// </summary>
		private string AreaCodeValue;
		/// <summary>
		/// 传进来的条码值
		/// </summary>
		public SortedList BarCodeList;
		/// <summary>
		/// 记录包集合
		/// </summary>
		private DataTable _tablePackage;
		/// <summary>
		/// 记录机器集合
		/// </summary>
		private DataTable _tableMachine;
		/// <summary>
		/// 原因列表
		/// </summary>
		private Dictionary<string, string> _dicReason;
		/// <summary>
		/// 类型对应的原因列表
		/// </summary>
		private Dictionary<string, string> _typeDicReason;
		/// <summary>
		/// 临时code
		/// </summary>
		private string _tempBarCode;
		/// <summary>
		/// 临时表
		/// </summary>
		private DataTable _tempTableInstrument;
		/// <summary>
		/// 初始化win
		/// </summary>
		public HCSSM_statistics_quality()
		{
			//包--器械
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));

		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			DisplayReason(AreaNum);
			SetComboboxesItems();
			if (!string.IsNullOrEmpty(PdCode))
			{
				areaCbx.SelectedValue = PdCode.Substring(0,1);
				areaCbx.Enabled = false;
			}
		}

		public override void InitializeButtonImage()
		{
			inSearchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			btnSearch.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch32", EnumImageType.PNG);
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);

			btnMovePRight.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRight32", EnumImageType.PNG);
			btnMovePLeft.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mLeft32", EnumImageType.PNG);

			btnMoveIRight.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRight32", EnumImageType.PNG);
			btnMoveILeft.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mLeft32", EnumImageType.PNG);

			btnMoveMRight.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRight32", EnumImageType.PNG);
			btnMoveMLeft.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mLeft32", EnumImageType.PNG);
		}


		/// <summary>
		/// 设置ComboBox的选项
		/// </summary>
		private void SetComboboxesItems()
		{
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS_workapace_type' or type_code = 'HCS-detection-type'");
			Dictionary<string,string> tempDic=new Dictionary<string,string>();
			if (data != null && data.Length > 0)
			{
				string selectPriorty = string.Empty;
				foreach (DataRow item in data)
				{
					if (item["type_code"] != null)
					{
						KeyValuePair<string, string> comboboxItem = new KeyValuePair<string, string>(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());

						if (item["type_code"].ToString() == "HCS_workapace_type")
						{
							if (item["key_code"].ToString() != "1")
							areaCbx.Items.Add(comboboxItem);
						}
						else if (item["type_code"].ToString() == "HCS-detection-type")
						{
							tempDic.Add(comboboxItem.Key,comboboxItem.Value);
						}
					}
				}
				areaCbx.SelectedIndex = SetAreaCbxSelectItem();
				areaCbx.Enabled = false;
				if(tempDic.Count>0&&!string.IsNullOrEmpty(AreaCodeValue))
				{
					string[] codeValue = AreaCodeValue.Split(',');
					foreach (KeyValuePair<string, string> comboboxItem in tempDic)
					{
						bool isFlag = false;
						for (int i = 0; i < codeValue.Count();i++ )
						{
							if(!string.IsNullOrEmpty(codeValue[i])&&codeValue[i].Substring(0,1).Equals(comboboxItem.Key))
							{
								isFlag = true;	
							}
						}
						if(isFlag)
							cbbType.Items.Add(comboboxItem);
					}
					if (cbbType.Items.Count > 0)
					{
						cbbType.SelectedIndex = 0;
					}
				}
				
			}
		}

		/// <summary>
		/// 设置区域值
		/// </summary>
		private int SetAreaCbxSelectItem()
		{
			if(areaCbx.Items.Count>0)
			{
				for(int i=0;i<areaCbx.Items.Count;i++)
				{
					KeyValuePair<string, string> obj=(KeyValuePair<string, string>)areaCbx.Items[i];
					if(obj.Key==AreaNum)
					{
						return i;
					}
				}
			}
			return 0;
		}

		/// <summary>
		/// type配置原因
		/// </summary>
		/// <param name="type"></param>
		private void DisplayReason(string type)
		{
			SortedList condition = new SortedList();
			condition.Add(1, "HCS-qualitydetection-area");
			condition.Add(2, type);
			string testAreaSql = RemoteClient.RemotInterface.CheckSelectData("HCS-qualitydetection-area-sec001", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-qualitydetection-area-sec001", condition);
			if(data!=null&&data.Rows.Count==1)
			{
				AreaCodeValue = Convert.ToString(data.Rows[0]["value_code"]);
				if (!string.IsNullOrEmpty(AreaCodeValue))
				{
					condition = new SortedList();
					condition.Add(1, "HCS-quality-detection-type");
					condition.Add(2, AreaCodeValue);
					string testReasonSql = RemoteClient.RemotInterface.CheckSelectData("HCS-qualitydetection-area-sec001", condition);
					DataTable dataReason = RemoteClient.RemotInterface.SelectData("HCS-qualitydetection-area-sec001", condition);
					if(dataReason!=null&&dataReason.Rows.Count>0)
					{
						_dicReason = new Dictionary<string, string>();
						for(int i =0;i<dataReason.Rows.Count;i++)
						{
							string keyCodeReason = Convert.ToString(dataReason.Rows[i]["key_code"]);
							string valueCodeReason = Convert.ToString(dataReason.Rows[i]["value_code"]);
							if(!string.IsNullOrEmpty(keyCodeReason))
							{
								_dicReason.Add(keyCodeReason, valueCodeReason);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// type改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			InitDgvData(((KeyValuePair<string,string>)cbbType.SelectedItem).Key);
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			string selectValue = ((KeyValuePair<string, string>)cbbType.SelectedItem).Key;
			int entitytype=2;
			int num = 1; //数量
			int type = 1;//类型
			int id=1;//实体id
			int location_id = 2;//区域id
			string remark = string.Empty;
			SortedList paramlist;
			SortedList condition = new SortedList();
			Int32.TryParse(selectValue, out entitytype);
			Int32.TryParse(AreaNum, out location_id);
			if (entitytype == 2)
			{
				for(int i=0;i<indgv_Package.Rows.Count;i++)
				{
					paramlist = new SortedList();
					DataGridViewRow row = indgv_Package.Rows[i];
					Int32.TryParse(Convert.ToString(row.Cells["inpreason"].Value),out type);
					remark = Convert.ToString(row.Cells["inpremark"].Value);
					bool isNum=Int32.TryParse(Convert.ToString(row.Cells["inpbar_count"].Value),out num);
					Int32.TryParse(Convert.ToString(row.Cells["inpid"].Value),out id);
					paramlist.Add(1, type);
					paramlist.Add(2, num);
					paramlist.Add(3, id);
					paramlist.Add(4, entitytype);
					paramlist.Add(5, location_id);
					paramlist.Add(6, remark);
					condition.Add(i, paramlist);
				}
			}
			else if (entitytype == 3)
			{
				for (int i = 0; i < indgv_Machine.Rows.Count; i++)
				{
					paramlist = new SortedList();
					DataGridViewRow row = indgv_Machine.Rows[i];
					Int32.TryParse(Convert.ToString(row.Cells["inmreason"].Value), out type);
					remark = Convert.ToString(row.Cells["inmremark"].Value);
					Int32.TryParse(Convert.ToString(row.Cells["inmbar_count"].Value), out num);
					Int32.TryParse(Convert.ToString(row.Cells["inmid"].Value), out id);
					paramlist.Add(1, type);
					paramlist.Add(2, num);
					paramlist.Add(3, id);
					paramlist.Add(4, entitytype);
					paramlist.Add(5, location_id);
					paramlist.Add(6, remark);
					condition.Add(i, paramlist);
				}
			}
			else if (entitytype == 1)
			{
				for (int i = 0; i < indgv_Instruments.Rows.Count; i++)
				{
					paramlist = new SortedList();
					DataGridViewRow row = indgv_Instruments.Rows[i];
					Int32.TryParse(Convert.ToString(row.Cells["inireason"].Value), out type);
					remark = Convert.ToString(row.Cells["iniremark"].Value);
					bool isNum=Int32.TryParse(Convert.ToString(row.Cells["inibar_count"].Value).Trim(), out num);
					Int32.TryParse(Convert.ToString(row.Cells["iniid"].Value), out id);
					paramlist.Add(1, type);
					paramlist.Add(2, num);
					paramlist.Add(3, id);
					paramlist.Add(4, entitytype);
					paramlist.Add(5, location_id);
					paramlist.Add(6, remark);
					condition.Add(i, paramlist);
					if(!isNum)
					{
						MessageBox.Show("器械的数量：请填写数字");
						return;
					}
				}
			}
			string testSql = RemoteClient.RemotInterface.CheckUPData(1,"HCS-qualitydetection-area-up001", condition,null);
			int testResult = RemoteClient.RemotInterface.UPData(1,"HCS-qualitydetection-area-up001", condition,null);
			if(testResult>0)
			{
				//添加成功
			}
			Close();
		}


		/// <summary>
		/// 关闭窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 查询事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			string packBarcode = txtBatchCode.Text;
			string packBarName = txtBarName.Text;
			if(_tablePackage!=null&&_tablePackage.Rows.Count>0)
			{
				dgv_Package.Rows.Clear();
				for(int i=0;i<_tablePackage.Rows.Count;i++)
				{
					DataRow row = _tablePackage.Rows[i];
					if(string.IsNullOrEmpty(packBarcode)&&!string.IsNullOrEmpty(packBarName))
					{
						if (row["ca_name"] != null && row["ca_name"].ToString().Contains(packBarName))
						{
							AddDgv_Package(row);
						}

					}
					else if(!string.IsNullOrEmpty(packBarcode)&&string.IsNullOrEmpty(packBarName))
					{
						if (row["bar_code"] != null && row["bar_code"].ToString().Contains(packBarcode))
						{
							AddDgv_Package(row);
						}
					}
					else if(!string.IsNullOrEmpty(packBarcode)&&!string.IsNullOrEmpty(packBarName))
					{
						if (row["bar_code"] != null && row["bar_code"].ToString().Contains(packBarcode)&&row["ca_name"] != null && row["ca_name"].ToString().Contains(packBarName))
						{
							AddDgv_Package(row);
						}
					}
					else
					{
						AddDgv_Package(row);
					}
				}
			}
		}

		/// <summary>
		/// 填充dgv_Package
		/// </summary>
		/// <param name="dt"></param>
		private void SetDataDgv_Package(DataTable dt)
		{
			dgv_Package.Rows.Clear();
			if (dt != null && dt.Rows.Count > 0)
			{
				dgv_Package.RowCount = dt.Rows.Count;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					DataRow row = dt.Rows[i] as DataRow;
					if (row["id"] != null) dgv_Package.Rows[i].Cells["pid"].Value = Convert.ToString(row["id"]);
					if (row["bar_code"] != null) dgv_Package.Rows[i].Cells["pbar_code"].Value = Convert.ToString(row["bar_code"]);
					if (row["ca_name"] != null) dgv_Package.Rows[i].Cells["pbar_name"].Value = Convert.ToString(row["ca_name"]);
					if (row["base_set_id"] != null) dgv_Package.Rows[i].Cells["pbase_set_id"].Value = Convert.ToString(row["base_set_id"]);
				}
				OnSelectSetSelectionChanged(dgv_Package, null);
			}
		}
		/// <summary>
		/// 填充dgv_Machine
		/// </summary>
		/// <param name="dt"></param>
		private void SetDataDgv_Machine(DataTable dt)
		{
			if (dt != null && dt.Rows.Count > 0)
			{
				dgv_Machine.RowCount = dt.Rows.Count;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					DataRow row = dt.Rows[i] as DataRow;
					if (row["id"] != null) dgv_Machine.Rows[i].Cells["mid"].Value = Convert.ToString(row["id"]);
					if (row["bar_code"] != null) dgv_Machine.Rows[i].Cells["mbar_code"].Value = Convert.ToString(row["bar_code"]);
					if (row["ca_name"] != null) dgv_Machine.Rows[i].Cells["mbar_name"].Value = Convert.ToString(row["ca_name"]);
				}
			}
		}

		/// <summary>
		/// 填充dgv_Instruments
		/// </summary>
		/// <param name="dt"></param>
		private void SetDataDgv_Instruments(DataTable dt)
		{
			if (dt != null && dt.Rows.Count > 0)
			{
				dgv_Instruments.RowCount = dt.Rows.Count;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					DataRow row = dt.Rows[i] as DataRow;
					if (row["id"] != null) dgv_Instruments.Rows[i].Cells["iid"].Value = Convert.ToString(row["id"]);
					if (row["ca_name"] != null) dgv_Instruments.Rows[i].Cells["ibar_code"].Value = Convert.ToString(row["ca_name"]);
					if (row["costc_name"] != null) dgv_Instruments.Rows[i].Cells["ibar_name"].Value = Convert.ToString(row["costc_name"]);
				}
			}
		}

		/// <summary>
		/// 初始化data
		/// </summary>
		/// <param name="type"></param>
		private void InitDgvData(string type)
		{
			setPanel.Visible = type != "3" ? true : false;
			setBarCodeLbl.Visible = type != "3" ? true : false;
			indgv_Package.Visible = type != "3" ? true : false;
			buttonSetPanel.Visible = type != "3" ? true : false;
			txtBatchCode.Visible = type != "3" ? true : false;
			setNameLbl.Visible = type != "3" ? true : false;
			txtBarName.Visible = type != "3" ? true : false;
			btnSearch.Visible = type != "3" ? true : false;
			
			mainPanel.SetRowSpan(setPanel, type == "2" ? 4 : 1);

			instrumentPanel.Visible = type == "1"? true: false;
			lbInstrumentsName.Visible = type == "1" ? true : false;
			txtInstrumentName.Visible = type == "1" ? true : false;
			lbCostCenter.Visible = type == "1" ? true : false;
			txtCostcenter.Visible = type == "1" ? true : false;
			inSearchBtn.Visible = type == "1" ? true : false;
			buttonSetPanel.Visible = type == "2" ? true : false;
			indgv_Package.Visible = type == "2" ? true : false;
			dgv_Package.MultiSelect = type == "2" ? true : false;
			mainPanel.SetRowSpan(instrumentPanel, type == "1" ? 2 : 1);

			devicePanel.Visible = type=="3" ? true : false;
			mainPanel.SetRow(devicePanel, type == "3" ? 2 : 6);
			mainPanel.SetRowSpan(devicePanel, type == "3" ? 5 : 1);

			_typeDicReason = GetTypeReasonDic(type);

			if(type=="2")
			{
				if (_tablePackage == null || (_tablePackage!=null&& _tablePackage.Rows.Count == 0))
				{
					string barcodeStr = GetbarcodeListStr(BarCodeList);

					SortedList package1 = new SortedList();
					package1.Add(1, string.IsNullOrEmpty(barcodeStr) ? "" : string.Format(" where bar_code in ({0})", barcodeStr));
					string testReasonSql = RemoteClient.RemotInterface.CheckSelectData("HCS-qualitydetection-area-sec003", package1);
					_tablePackage = RemoteClient.RemotInterface.SelectData("HCS-qualitydetection-area-sec003", package1);
				}
				if(_tablePackage!=null&&_tablePackage.Rows.Count>0)
				{
					SetDataDgv_Package(_tablePackage);
				}
				SetComboBoxReason(indgv_Package, "inpreason");
			}
			else if (type == "3")
			{
				if (_tableMachine == null)
				{
					SortedList condition_Machine = new SortedList();
					condition_Machine.Add(1, CnasBaseData.SystemID);
					string testReasonSql = RemoteClient.RemotInterface.CheckSelectData("HCS-qualitydetection-area-sec002",condition_Machine);
					_tableMachine = RemoteClient.RemotInterface.SelectData("HCS-qualitydetection-area-sec002", condition_Machine);
				}
				if (_tableMachine != null)
				{
					SetDataDgv_Machine(_tableMachine);
				}

				SetComboBoxReason(indgv_Machine, "inmreason");
			}
			else if(type=="1")
			{
				if (_tablePackage == null || (_tablePackage != null && _tablePackage.Rows.Count == 0))
				{
					string barcodeStr = GetbarcodeListStr(BarCodeList);

					SortedList package1 = new SortedList();
					package1.Add(1, string.IsNullOrEmpty(barcodeStr) ? "" : string.Format(" where bar_code in ({0})", barcodeStr));
					string testReasonSql = RemoteClient.RemotInterface.CheckSelectData("HCS-qualitydetection-area-sec003", package1);
					_tablePackage = RemoteClient.RemotInterface.SelectData("HCS-qualitydetection-area-sec003", package1);
				}
				if (_tablePackage != null && _tablePackage.Rows.Count > 0)
				{
					SetDataDgv_Package(_tablePackage);
				}

				SetComboBoxReason(indgv_Instruments, "inireason");
			}
		}


		/// <summary>
		/// 得到相对应类型的原因
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private Dictionary<string, string> GetTypeReasonDic(string type)
		{
			Dictionary<string,string> tempTypeReason=new Dictionary<string,string>();
			if (_dicReason != null && _dicReason.Count > 0)
			{
				foreach (KeyValuePair<string, string> item in _dicReason)
				{
					if (item.Key.Substring(0, 1).Equals(type))
						tempTypeReason.Add(item.Key, item.Value);
				}
			}
			return tempTypeReason;
		}

		/// <summary>
		/// 设置原因
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="colName"></param>
		private void SetComboBoxReason(DataGridView grid,string colName)
		{
			if (_typeDicReason != null && _typeDicReason.Count > 0)
			{
				BindingSource bs = new BindingSource();
				bs.DataSource = _typeDicReason;
				DataGridViewComboBoxColumn cmbox = grid.Columns[colName] as DataGridViewComboBoxColumn;
				if (cmbox != null)
				{
					cmbox.DataSource = bs;
					cmbox.DisplayMember = "Value";
					cmbox.ValueMember = "Key";
				}
			}
		}

		/// <summary>
		/// 包往右移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMovePright_Click(object sender, EventArgs e)
		{
			if (dgv_Package.SelectedRows.Count == 1)
			{
				DataGridViewRow row = dgv_Package.SelectedRows[0];
				dgv_Package.Rows.Remove(row);
				indgv_Package.Rows.Add(row);
				row.Cells["inpbar_count"].Value = "1";
				row.Cells["inpreason"].Value = _typeDicReason.First().Key;
			}
		}
	    /// <summary>
	    /// 包往左移
	    /// </summary>
	    /// <param name="sender"></param>
	    /// <param name="e"></param>
		private void btnMovePleft_Click(object sender, EventArgs e)
		{
			if (indgv_Package.SelectedRows.Count == 1)
			{
				DataGridViewRow row = indgv_Package.SelectedRows[0];
				int addIndex=dgv_Package.Rows.Add();
				DataGridViewRow tempRow = dgv_Package.Rows[addIndex];
				tempRow.Cells["pid"].Value = row.Cells["inpid"].Value;
				tempRow.Cells["pbar_code"].Value = row.Cells["inpbar_code"].Value;
				tempRow.Cells["pbar_name"].Value = row.Cells["inpbar_name"].Value;
				indgv_Package.Rows.Remove(row);
			}
		}

		/// <summary>
		/// 拼接barcode
		/// </summary>
		/// <param name="barcodeList"></param>
		/// <returns></returns>
		private string GetbarcodeListStr(SortedList barcodeList)
		{
			string tempStr = string.Empty;
			if (barcodeList != null)
			{
				for (int i = 0; i < barcodeList.Count; i++)
				{
					string tempBarcode = Convert.ToString(barcodeList.GetByIndex(i));
					if (!string.IsNullOrEmpty(tempBarcode))
					{
						tempStr += string.Format("'{0}',", tempBarcode);
					}
				}
				if (tempStr.Length > 1)
					tempStr = tempStr.TrimEnd(',');
			}
			return tempStr;
		}

		/// <summary>
		/// 器械往右移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMoveIright_Click(object sender, EventArgs e)
		{

			if (dgv_Instruments.SelectedRows.Count == 1)
			{
				DataGridViewRow row = dgv_Instruments.SelectedRows[0];
				dgv_Instruments.Rows.Remove(row);
				indgv_Instruments.Rows.Add(row);
				row.Cells["inibar_count"].Value = "1";
				row.Cells["inireason"].Value = _typeDicReason.First().Key;
			}
		}

		/// <summary>
		/// 器械往左移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMoveIleft_Click(object sender, EventArgs e)
		{
			if (indgv_Instruments.SelectedRows.Count == 1)
			{
				DataGridViewRow row = indgv_Instruments.SelectedRows[0];
				int addIndex = dgv_Instruments.Rows.Add();
				DataGridViewRow tempRow = dgv_Instruments.Rows[addIndex];
				tempRow.Cells["iid"].Value = row.Cells["iniid"].Value;
				tempRow.Cells["ibar_code"].Value = row.Cells["inibar_code"].Value;
				tempRow.Cells["ibar_name"].Value = row.Cells["inibar_name"].Value;
				indgv_Instruments.Rows.Remove(row);
			}
		}
		/// <summary>
		/// 机器往右移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMoveMright_Click(object sender, EventArgs e)
		{
			if (dgv_Machine.SelectedRows.Count == 1)
			{
				DataGridViewRow row = dgv_Machine.SelectedRows[0];
				dgv_Machine.Rows.Remove(row);
				indgv_Machine.Rows.Add(row);
				row.Cells["inmbar_count"].Value = "1";
				row.Cells["inmreason"].Value = _typeDicReason.First().Key;
			}
		}

		/// <summary>
		/// 机器往左移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMoveMleft_Click(object sender, EventArgs e)
		{
			if (indgv_Machine.SelectedRows.Count == 1)
			{
				DataGridViewRow row = indgv_Machine.SelectedRows[0];
				int addIndex = dgv_Machine.Rows.Add();
				DataGridViewRow tempRow = dgv_Machine.Rows[addIndex];
				tempRow.Cells["mid"].Value = row.Cells["inmid"].Value;
				tempRow.Cells["mbar_code"].Value = row.Cells["inmbar_code"].Value;
				tempRow.Cells["mbar_name"].Value = row.Cells["inmbar_name"].Value;
				indgv_Machine.Rows.Remove(row);
			}
		}

		/// <summary>
		/// 添加新行包
		/// </summary>
		private void AddDgv_Package(DataRow row)
		{
			int Index = dgv_Package.Rows.Add();
			if (row["id"] != null) dgv_Package.Rows[Index].Cells["pid"].Value = Convert.ToString(row["id"]);
			if (row["bar_code"] != null) dgv_Package.Rows[Index].Cells["pbar_code"].Value = Convert.ToString(row["bar_code"]);
			if (row["ca_name"] != null) dgv_Package.Rows[Index].Cells["pbar_name"].Value = Convert.ToString(row["ca_name"]);
		}

		///添加新行器械
		private void AddDgv_Instruments(DataRow row)
		{
			int Index = dgv_Instruments.Rows.Add();
			if (row["id"] != null) dgv_Instruments.Rows[Index].Cells["iid"].Value = Convert.ToString(row["id"]);
			if (row["ca_name"] != null) dgv_Instruments.Rows[Index].Cells["ibar_code"].Value = Convert.ToString(row["ca_name"]);
			if (row["costc_name"] != null) dgv_Instruments.Rows[Index].Cells["ibar_name"].Value = Convert.ToString(row["costc_name"]);
		}


		/// <summary>
		/// 器械查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void inSearchBtn_Click(object sender, EventArgs e)
		{
			if(_tempTableInstrument!=null&&_tempTableInstrument.Rows.Count>0)
			{
				string instrumentName = txtInstrumentName.Text;
				string costcenterName = txtCostcenter.Text;
				if (_tempTableInstrument != null && _tempTableInstrument.Rows.Count > 0)
				{
					dgv_Instruments.Rows.Clear();
					for (int i = 0; i < _tempTableInstrument.Rows.Count; i++)
					{
						DataRow row = _tempTableInstrument.Rows[i];
						if (string.IsNullOrEmpty(instrumentName) && !string.IsNullOrEmpty(costcenterName))
						{
							if (row["costc_name"] != null && row["costc_name"].ToString().Contains(costcenterName))
							{
								AddDgv_Instruments(row);
							}

						}
						else if (!string.IsNullOrEmpty(instrumentName) && string.IsNullOrEmpty(costcenterName))
						{
							if (row["ca_name"] != null && row["ca_name"].ToString().Contains(instrumentName))
							{
								AddDgv_Instruments(row);
							}
						}
						else if (!string.IsNullOrEmpty(instrumentName) && !string.IsNullOrEmpty(costcenterName))
						{
							if (row["ca_name"] != null && row["ca_name"].ToString().Contains(instrumentName) && row["costc_name"] != null && row["costc_name"].ToString().Contains(costcenterName))
							{
								AddDgv_Instruments(row);
							}
						}
						else
						{
							AddDgv_Instruments(row);
						}
					}
				}
			}
		}

		private void OnSelectSetSelectionChanged(object sender, EventArgs e)
		{
			string selectValue = ((KeyValuePair<string, string>)cbbType.SelectedItem).Key;
			if (selectValue.Equals("1"))
			{
				if (dgv_Package.SelectedRows.Count == 1)
				{
					DataGridViewRow row = dgv_Package.SelectedRows[0];
					string tempBarCode = Convert.ToString(row.Cells["pbar_code"].Value);
					string tempBarCodeId = Convert.ToString(row.Cells["pbase_set_id"].Value);

					if (!string.IsNullOrEmpty(tempBarCode) && !string.IsNullOrEmpty(tempBarCodeId))
					{
						if (_tempBarCode != tempBarCode)
						{
							_tempBarCode = tempBarCode;
							int baseBarCodeId = 1;
							Int32.TryParse(tempBarCodeId, out baseBarCodeId);
							bool isBCCS = BarCodeHelper.IsSpecialSet(tempBarCode);
							string sql = isBCCS ? "HCS-instrument-info-sec002" : "HCS-instrument-info-sec001";

							SortedList condition = new SortedList();
							condition.Add(1, CnasBaseData.SystemID);//CnasBaseData.SystemID
							condition.Add(2, isBCCS ? tempBarCode : baseBarCodeId.ToString());
							string testSql = RemoteClient.RemotInterface.CheckSelectData(sql, condition);
							DataTable getInstrumentdt = RemoteClient.RemotInterface.SelectData(sql, condition);
							if (getInstrumentdt != null)
							{
								_tempTableInstrument = getInstrumentdt;
								SetDataDgv_Instruments(getInstrumentdt);
							}
							else
							{
								MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindInstrument", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							SetComboBoxReason(indgv_Instruments, "inireason");
						}
					}
				}
			}
		}
	}
}
