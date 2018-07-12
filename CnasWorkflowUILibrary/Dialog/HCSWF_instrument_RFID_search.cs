using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_instrument_RFID_search : MetroForm
	{
		private bool _isShow = false;
		/// <summary>
		/// 用于缓存数据
		/// </summary>
		public SortedList UpDataConditon=null;
		/// <summary>
		/// rfid获取
		/// </summary>
		private RFIDInterface rfidCode = null;
		/// <summary>
		/// 流程号
		/// </summary>
		public string PdCode=string.Empty;
		/// <summary>
		/// 用户Id
		/// </summary>
		public int userId;
		/// <summary>
		/// BCC
		/// </summary>
		public string _bccCode=string.Empty;
		/// <summary>
		/// BCU
		/// </summary>
		private string _bcuCode=string.Empty;
		/// <summary>
		/// 有效的rfid
		/// </summary>
		private Dictionary<string, string> _uRfid = new Dictionary<string, string>();
		/// <summary>
		/// 新增的rfid
		/// </summary>
		private Dictionary<string, string> _newRfid = new Dictionary<string, string>();
		/// <summary>
		/// 非法的rfid
		/// </summary>
		private Dictionary<string, string> _illegalRfid = new Dictionary<string, string>();
		/// <summary>
		/// 新增有用的rfid
		/// </summary>
		private Dictionary<string, string> _new_uRfid = new Dictionary<string, string>();
		///// <summary>
		///// 实体rfid器械
		///// </summary>
		//private DataTable _rfid_In_Table =null;
		/// <summary>
		/// 先前绑定的rfid
		/// </summary>
		private DataTable _preDataTable = null;
		/// <summary>
		/// 是否新包
		/// </summary>
		private bool _isNewSet = false;

		public bool IsClosed = false;
		/// <summary>
		/// 初始化
		/// </summary>
		public HCSWF_instrument_RFID_search(string setBarCode)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			instrumentGrid.Font = new Font("Segoe UI", 11);
			InitializeButtonImage();
			InitializeBccAndBcu(setBarCode);
		}

		/// <summary>
		/// 初始化BCU以及bcc
		/// </summary>
		/// <param name="setBarCode"></param>
		private void InitializeBccAndBcu(string setBarCode)
		{
			if(setBarCode.Length<13)
			{
				_bccCode = string.Empty;
				_bcuCode = string.Empty;
			}
			else
			{
				int bccIndex = setBarCode.IndexOf("BCC");
				if(bccIndex>=0)
				{
					_bccCode = setBarCode.Substring(bccIndex, 13);
				}
				int bcuIndex = setBarCode.IndexOf("BCU");
				if(bcuIndex>=0)
				{
					_bcuCode = setBarCode.Substring(bcuIndex, 13);
				}
			}
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// button图片
		/// </summary>
		private void InitializeButtonImage()
		{
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			lightBox.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mGrayLight50", EnumImageType.PNG);
		}

		/// <summary>
		/// 获取实体器械
		/// </summary>
		private void InitializeRFID_InTable()
		{
			CnasRemotCall remoteClient = new CnasRemotCall();
			//_rfid_In_Table = remoteClient.RemotInterface.SelectData("HCS-instrument-sec004", null);
			SortedList prebindCondition = new SortedList();
			//prebindCondition.Add(1, 0);
			//prebindCondition.Add(2, _bccCode);
			//string testPreSql = remoteClient.RemotInterface.CheckSelectData("HCS_set_rfid-sec001", prebindCondition);
			//_preDataTable = remoteClient.RemotInterface.SelectData("HCS_set_rfid-sec001", prebindCondition);
			prebindCondition.Add(1, 1);
			prebindCondition.Add(2, _bccCode);
			string testPreSql = remoteClient.RemotInterface.CheckSelectData("HCS-set-rfid-map-sec001", prebindCondition);
			_preDataTable = remoteClient.RemotInterface.SelectData("HCS-set-rfid-map-sec001", prebindCondition);
			//if(_preDataTable!=null&&_preDataTable.Rows.Count>0)
			//{
			//	_isNewSet = false;
			//}
			//else
			//{
			//	_isNewSet = true;
			//}
		}

		/// <summary>
		/// 初始化类
		/// </summary>
		/// <returns></returns>
		private RFIDInterface Loadclass()
		{
			object result = null;
			Type typeofControl = null;
			Assembly tempAssembly;
			string temp_class_name = OrderHelper.GetValueCode("HCS-used-RFID-class-type", "ForUse");
			if (string.IsNullOrEmpty(temp_class_name))
			{
				return null;
			}
			tempAssembly = Assembly.LoadFrom("CnasRFIDManager.dll");
			string class_name = string.Format("Cnas.wns.CnasRFIDManager.{0}", temp_class_name);
			typeofControl = tempAssembly.GetType(class_name);
			if (typeofControl == null)
			{ return null; }
			result = Activator.CreateInstance(typeofControl);
			if (result == null) { return null; }
			return (RFIDInterface)result;
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDialogLoad(object sender, EventArgs e)
		{
			InitializeRFID_InTable();
			InitalizeSetInfo();
			RefreshDataGrid();
			try
			{
				rfidCode = Loadclass();
				if (rfidCode != null)
				{
					rfidCode.GetNoneAddData += AddInstrumentData;
					rfidCode.Connecttion();
				}
				if (rfidCode==null||!rfidCode.IsStartScan)
				{
					this.Invoke(new Action(() => { MessageBox.Show("连接RFID读取器失败"); }));
				}
			}
			catch
			{
				MessageBox.Show("连接RFID读取器失败");
			}
			_isShow = true;
		}

		/// <summary>
		/// 对应基本包ID
		/// </summary>
		private int _baseSetId = 0;

		/// <summary>
		/// 设置包的基本信息
		/// </summary>
		private void InitalizeSetInfo()
		{
			SortedList condition = new SortedList();
			condition.Add(1, "0");
			condition.Add(2, _bccCode);
			CnasRemotCall remoteClient = new CnasRemotCall();
			string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec004", condition);
			DataTable data = remoteClient.RemotInterface.SelectData("HCS-work-set-sec004", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					if (data.Rows[i]["bar_code"] != null)
					{
						setBarCodeTxt.Text = data.Rows[i]["bar_code"].ToString();
						if (data.Rows[i]["ca_name"] != null) setNameTxt.Text = data.Rows[i]["ca_name"].ToString();
						if (data.Rows[i]["location_name"] != null) setUseTxt.Text = data.Rows[i]["location_name"].ToString();
						if (data.Rows[i]["base_set_id"] != null) int.TryParse(data.Rows[i]["base_set_id"].ToString(), out _baseSetId);
						break;
					}
				}
			}
		}


		/// <summary>
		/// 加载grid数据
		/// </summary>
		private void RefreshDataGrid()
		{
			GetCountScanner();
			bool isBCCS = BarCodeHelper.IsSpecialSet(setBarCodeTxt.Text);
			string sql = isBCCS ? "HCS-instrument-info-sec002" : "HCS-instrument-info-sec001";
			CnasRemotCall remoteClient = new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, _baseSetId.ToString());
			string testSql = remoteClient.RemotInterface.CheckSelectData(sql, condition);
			DataTable _dgvDataTable = remoteClient.RemotInterface.SelectData(sql, condition);
			//if(PdCode=="3020")
			//{
			//	isPackagedCol.Visible = true;
			//}
			if(_isNewSet)
			{
				getNumCol.Visible = false;
				//getNumCol.DefaultCellStyle.ForeColor = Color.Red;
				needNumCol.DefaultCellStyle.ForeColor = Color.Red;
			}
			else
			{
				getNumCol.DefaultCellStyle.ForeColor = Color.Red;
				//needNumCol.DefaultCellStyle.ForeColor = Color.Red;
			}
			if (_dgvDataTable != null && _dgvDataTable.Rows.Count > 0)
			{
				foreach (DataRow item in _dgvDataTable.Rows)
				{
					int rowIndex = instrumentGrid.Rows.Add();
					if (item["id"] != null) instrumentGrid.Rows[rowIndex].Cells["idCol"].Value = item["id"];
					if (item["ca_name"] != null) instrumentGrid.Rows[rowIndex].Cells["inNameCol"].Value = item["ca_name"];
					if (item["instrument_type"] != null) instrumentGrid.Rows[rowIndex].Cells["inTypeCol"].Value = item["instrument_type"];
					if (item["instrument_num"] != null) instrumentGrid.Rows[rowIndex].Cells["inNumCol"].Value = item["instrument_num"];
					if (item["costc_name"] != null) instrumentGrid.Rows[rowIndex].Cells["costCNameCol"].Value = item["costc_name"];
					if (item["ca_price"] != null) instrumentGrid.Rows[rowIndex].Cells["inPriceCol"].Value = item["ca_price"];
					if(_preDataTable!=null)
					{
						string tempId=Convert.ToString(item["id"]);
						DataRow[] array =  _preDataTable.Select("instrument_id='" + tempId + "'");
						instrumentGrid.Rows[rowIndex].Cells["needNumCol"].Value =array==null?0:array.Length;
					}
					else
					{
						instrumentGrid.Rows[rowIndex].Cells["needNumCol"].Value = 0;
					}
					instrumentGrid.Rows[rowIndex].Cells["getNumCol"].Value = 0;
				}
			}

		}

		/// <summary>
		/// 初始化新增的rfid
		/// </summary>
		/// <param name="dic"></param>
		private void InitNewRfidDataDic(Dictionary<string,string> dic)
		{
			if(dic!=null&&_uRfid!=null)
			{
				List<string> keys = dic.Keys.ToList();
				for (int i = 0; i < keys.Count; i++)
				{
					if (!_uRfid.ContainsKey(keys[i]) && !_newRfid.ContainsKey(keys[i]))
					{
						_newRfid.Add(keys[i], string.Empty);
					}
				}
			}
		}

		/// <summary>
		/// 灯泡变幻效果
		/// </summary>
		private bool isChanged = false;

		private object lockMyObj = new object();
		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="dic"></param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		private void AddInstrumentData(Dictionary<string, string> dic, RFIDCommand cmd = RFIDCommand.Datas)
		{
			if (cmd != RFIDCommand.Datas) return;
			//lock (lockMyObj)
			//{
				if (dic != null && dic.Count > 0 && _isShow)
				{
					this.BeginInvoke(new Action(() =>
					{
						isChanged = !isChanged;
						string iconName = isChanged ? "mGreenLight50" : "mRedLight50";
						lightBox.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", iconName, EnumImageType.PNG);
						InitNewRfidDataDic(dic);
						CheckInInstrumentData(_newRfid);
						if(_illegalRfid.Count>0)
						{
							MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("warnRFIDData ", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK);
							rfidCode.DicAddData(_illegalRfid, 2);
						}
						_new_uRfid = new Dictionary<string, string>();
						_newRfid = new Dictionary<string, string>();
						_illegalRfid = new Dictionary<string, string>();
						rfidCode.SetTagToZero();
					}));

				}
			//}
		}

		/// <summary>
		/// 设置已扫描的数量
		/// </summary>
		private void GetCountScanner()
		{
			//txtUnReadScanCount.ForeColor = Color.Red;
			//txtReadScanCount.ForeColor = Color.Red;
			int totalCount = _preDataTable == null ? 0 : _preDataTable.Rows.Count;
			int readCount;
			string str_readCount = txtReadScanCount.Text;
			int.TryParse(str_readCount, out readCount);
			readCount += 1;
			if (_uRfid.Count == 0)
				readCount = 0;
			txtReadScanCount.Text = readCount.ToString();
			int unReadCount = totalCount - readCount <= 0 ? 0 : totalCount - readCount;
			txtUnReadScanCount.Text = unReadCount.ToString();
			
		}

		/// <summary>
		/// 是否需要添加
		/// </summary>
		/// <param name="rfid_str"></param>
		private void CheckInInstrumentData(Dictionary<string, string> dic)
		{
			if (instrumentGrid.Rows != null && instrumentGrid.Rows.Count > 0)
			{
				foreach(KeyValuePair<string,string> item in dic)
				{
					CheckDicItem(item);
				}
			}
		}

		/// <summary>
		/// 检查是否有效
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private void CheckDicItem(KeyValuePair<string,string> item)
		{
			int m = 2;//1为有效  2不存在
			DataRow[] array1 =_preDataTable==null?null: _preDataTable.Select("rfid='" + item.Key + "'");
			if (array1!=null&&array1.Length > 0)
			{
				string temp_in_base_Id = array1[0]["instrument_id"].ToString();
				//int int_count = 0;
				for (int i = 0; i < instrumentGrid.Rows.Count; i++)
				{
					DataGridViewRow row = instrumentGrid.Rows[i];
					string tempId=Convert.ToString(row.Cells["idCol"].Value);
					if (tempId==temp_in_base_Id)
					{
						m = 1;
						string str_getNum = row.Cells["getNumCol"].Value.ToString();
						int getNum;
						int.TryParse(str_getNum, out getNum);
						row.Cells["getNumCol"].Value = getNum + 1;
						GetCountScanner();
					}
										
				}
				if (m == 2)
				{
					if (!_illegalRfid.ContainsKey(item.Key))
						_illegalRfid.Add(item.Key, string.Empty);
				}
				else
				{
					if (!_uRfid.ContainsKey(item.Key))
						_uRfid.Add(item.Key, temp_in_base_Id);
				}
			}
			else
			{
				if (!_illegalRfid.ContainsKey(item.Key))
					_illegalRfid.Add(item.Key, string.Empty);
			}
		}

		
		/// <summary>
		/// 提交前检查
		/// </summary>
		/// <returns></returns>
		private int CheckInstrumentCount()
		{
			int j = 0;
			if (!_isNewSet)
			{
				if (instrumentGrid.Rows.Count > 0)
				{
					for (int i = 0; i < instrumentGrid.Rows.Count; i++)
					{
						DataGridViewRow row = instrumentGrid.Rows[i];
						string instrument_basetype = Convert.ToString(row.Cells["inTypeCol"].Value);
						if (instrument_basetype.Equals("器械"))
						{
							string str_needNum = Convert.ToString(row.Cells["needNumCol"].Value);
							string str_getNum = Convert.ToString(row.Cells["getNumCol"].Value);
							int needNum, getNum;
							int.TryParse(str_needNum, out needNum);
							int.TryParse(str_getNum, out getNum);
							if (needNum > getNum)
							{
								//警告数量不足
								j += needNum - getNum;
							}
						}
					}
				}
			}
			if(j>0)
			{
				if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("checkrfidItem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					return 0;
				}
				else
				{
					return -1;
				}
			}
			return 0;
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		private void OnSaveData()
		{
			int flag_i=CheckInstrumentCount();
			if(flag_i<0)
			{
				return;
			}
			int pd_state = 0;
			//if(PdCode=="2020")
			//{
			//	pd_state = 8;
			//}
			CnasRemotCall remoteClient = new CnasRemotCall();
			string temp_sql = string.Empty;
			SortedList condition = new SortedList();
			SortedList par2_condition = new SortedList();
			//if(_preDataTable!=null&&_preDataTable.Rows.Count>0)
			//{
			//	SortedList par1_condition = new SortedList();
			//	for(int i=0;i<_preDataTable.Rows.Count;i++)
			//	{
			//		SortedList par_par1 = new SortedList();
			//		DataRow row=_preDataTable.Rows[i];
			//		string tempRfid = Convert.ToString(row["rfid"]);
			//		if(_uRfid!=null&&_uRfid.ContainsKey(tempRfid))
			//		{
			//			//包含
			//			par_par1.Add(1, 8);
			//			par_par1.Add(2, tempRfid);
			//			par1_condition.Add(i + 1, par_par1);
			//		}
			//		else
			//		{
			//			//不包含
			//			par_par1.Add(1, 2);
			//			par_par1.Add(2, tempRfid);
			//			par1_condition.Add(i + 1, par_par1);
			//		}
					
			//	}
			//	int par2_j = 1;
			//	if(_uRfid!=null&&_uRfid.Count>0)
			//	{
			//		foreach (KeyValuePair<string, string> item in _uRfid)
			//		{
			//			SortedList par_par2_condition = new SortedList();
			//			par_par2_condition.Add(1, _bccCode);
			//			par_par2_condition.Add(2, item.Value);
			//			par_par2_condition.Add(3, item.Key);
			//			par_par2_condition.Add(4, pd_state);
			//			par_par2_condition.Add(5, string.Empty);
			//			par_par2_condition.Add(6, userId);
			//			par_par2_condition.Add(7, PdCode);
			//			par_par2_condition.Add(8, _bcuCode);
			//			par_par2_condition.Add(par2_j, par_par2_condition); par2_j++;
			//		}
			//	}
			//	temp_sql = "HCS_set_rfid-up001";
			//	condition.Add(1, par1_condition);
			//	condition.Add(2, par2_condition);
			//}
			//else
			//{
				if (_uRfid != null && _uRfid.Count > 0)
				{
					int par1_j = 1;
					foreach(KeyValuePair<string,string> item in _uRfid)
					{
						SortedList par_par1 = new SortedList();
						par_par1.Add(1, _bccCode);
						par_par1.Add(2, item.Value);
						par_par1.Add(3, item.Key);
						par_par1.Add(4, pd_state);
						par_par1.Add(5, string.Empty);
						par_par1.Add(6, userId);
						par_par1.Add(7, PdCode);
						par_par1.Add(8, _bcuCode);
						condition.Add(par1_j, par_par1); par1_j++;
					}
					temp_sql = "HCS_set_rfid-up003";
				}
			//}
			if (condition.Count > 0&&!string.IsNullOrEmpty(temp_sql))
			{
				UpDataConditon = new SortedList();
				UpDataConditon.Add(1, temp_sql);
				UpDataConditon.Add(2, condition);
			}

			//MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("saveRFIDData", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK);
			Close();
			
			//string testSql = remoteClient.RemotInterface.CheckUPDataList(temp_sql, condition);
			//int result = remoteClient.RemotInterface.UPDataList(temp_sql, condition);
			//if(result>0)
			//{
			//	MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("uprfidItem", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK);
			//	Close();
			//}
		}

		///// <summary>
		///// 构造一个新的dgv
		///// </summary>
		///// <returns></returns>
		//private DataGridView InitNewDataGridView()
		//{
		//	DataGridView dgv = new DataGridView();
		//	DataGridViewTextBoxColumn idColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn inNameColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn inTypeColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn instrumentSNColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn inNumColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn needNumColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn getNumColN=new DataGridViewTextBoxColumn();
		//	DataGridViewCheckBoxColumn isPackagedColN=new DataGridViewCheckBoxColumn();
		//	DataGridViewTextBoxColumn costCNameColN=new DataGridViewTextBoxColumn();
		//	DataGridViewTextBoxColumn inPriceColN=new DataGridViewTextBoxColumn();
		//	idColN.Name = "idColN";
		//	inNameColN.Name = "inNameColN";
		//	inTypeColN.Name = "inTypeColN";
		//	instrumentSNColN.Name = "instrumentSNColN";
		//	inNumColN.Name = "inNumColN";
		//	needNumColN.Name = "needNumColN";
		//	getNumColN.Name = "getNumColN";
		//	isPackagedColN.Name = "isPackagedColN";
		//	costCNameColN.Name = "costCNameColN";
		//	inPriceColN.Name = "inPriceColN";
		//	dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		//	idColN,
		//	inNameColN,
		//	inTypeColN,
		//	instrumentSNColN,
		//	inNumColN,
		//	needNumColN,
		//	getNumColN,
		//	isPackagedColN,
		//	costCNameColN,
		//	inPriceColN});
		//	dgv.RowCount = instrumentGrid.RowCount;
		//	for (int i = 0; i < instrumentGrid.Rows.Count;i++ )
		//	{
		//		dgv.Rows[i].Cells["idColN"].Value = instrumentGrid.Rows[i].Cells["idCol"].Value;
		//		dgv.Rows[i].Cells["inNameColN"].Value = instrumentGrid.Rows[i].Cells["inNameCol"].Value;
		//		dgv.Rows[i].Cells["inTypeColN"].Value = instrumentGrid.Rows[i].Cells["inTypeCol"].Value;
		//		dgv.Rows[i].Cells["instrumentSNColN"].Value = instrumentGrid.Rows[i].Cells["instrumentSNCol"].Value;
		//		dgv.Rows[i].Cells["inNumColN"].Value = instrumentGrid.Rows[i].Cells["inNumCol"].Value;
		//		dgv.Rows[i].Cells["needNumColN"].Value = instrumentGrid.Rows[i].Cells["needNumCol"].Value;
		//		dgv.Rows[i].Cells["getNumColN"].Value = instrumentGrid.Rows[i].Cells["getNumCol"].Value;
		//		dgv.Rows[i].Cells["isPackagedColN"].Value = instrumentGrid.Rows[i].Cells["isPackagedCol"].Value;
		//		dgv.Rows[i].Cells["costCNameColN"].Value = instrumentGrid.Rows[i].Cells["costCNameCol"].Value;
		//		dgv.Rows[i].Cells["inPriceColN"].Value = instrumentGrid.Rows[i].Cells["inPriceCol"].Value;
		//	}
		//	return dgv;
		//}

		/// <summary>
		/// 确认
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			OnSaveData();
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSWF_instrument_RFID_search_FormClosing(object sender, FormClosingEventArgs e)
		{
			//StopRfidCode();
			//IsClosed = true;
		}

		/// <summary>
		/// 
		/// </summary>
		private void StopRfidCode()
		{
			if(rfidCode!=null)
			{
				rfidCode.DisConnecttion();
			}
		}

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			StopRfidCode();
			//Thread.Sleep(2000);
			IsClosed = true;
		}

		
	}
}
