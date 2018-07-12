using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSManagerUC;
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
	public partial class HCSSM_statistics_manager : UserControl
	{
		/// <summary>
		/// 区域id
		/// </summary>
		public string App_ID=string.Empty;
		/// <summary>
		/// 区域存储值
		/// </summary>
		private Dictionary<string, string> _areaDic;
		/// <summary>
		/// 区域key对应原因Key
		/// </summary>
		private Dictionary<string, string> _areaReasonDic;
		/// <summary>
		/// 服务端
		/// </summary>
		public CnasRemotCall RemoteClient
		{
			get
			{
				if (_remoteClient == null)
					_remoteClient = new CnasRemotCall();
				return _remoteClient;
			}
		}
		/// <summary>
		/// 服务端
		/// </summary>
		private CnasRemotCall _remoteClient = null;
		/// <summary>
		/// 记录原因
		/// </summary>
		private Dictionary<string, string> _reasonDic;
		/// <summary>
		/// 记录类型
		/// </summary>
		private Dictionary<string, string> _typeDic;
		/// <summary>
		/// 初始化win
		/// </summary>
		public HCSSM_statistics_manager(string app_ID)
		{
			App_ID = app_ID;
			InitializeComponent();
			crestartdate.Value = DateTime.Now.AddMonths(-1);
			creenddate.Value = DateTime.Now;
			GetComboxItemData();
			InitComboxItem(cbbreason, _reasonDic);
			InitComboxItem(cbbType, _typeDic);
			InitDvg_01Data();
			InitializeButtonImage();
		}

		private void InitializeButtonImage()
		{
			btnEdit.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mModify32", EnumImageType.PNG);
			btnDel.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDelete32", EnumImageType.PNG);
			btnPri.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			searchBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mSearch16", EnumImageType.PNG);
		}

		/// <summary>
		/// 获取下拉列表的值
		/// </summary>
		private void GetComboxItemData()
		{
			if (_reasonDic == null || (_reasonDic != null && _reasonDic.Count == 0))
			{
				_reasonDic = new Dictionary<string, string>();
				_reasonDic.Add("0", "所有");
			}
			if (_typeDic == null || (_typeDic != null && _typeDic.Count == 0))
			{
				_typeDic = new Dictionary<string, string>();
				_typeDic.Add("0", "所有");
			}
			if (_areaDic == null || (_typeDic != null && _typeDic.Count == 0))
			{
				_areaDic = new Dictionary<string, string>();
			}
			if (_areaReasonDic == null || (_areaReasonDic != null && _areaReasonDic.Count == 0))
			{
				_areaReasonDic = new Dictionary<string, string>();
			}
			bool isAddReason = _reasonDic != null && _reasonDic.Count == 1;
			bool isAddType = _typeDic != null && _typeDic.Count == 1;
			bool isAddArea=_areaDic!=null&&_areaDic.Count==0;
			bool isAddAreaReason = _areaReasonDic != null && _areaReasonDic.Count == 0;
			DataRow[] data = CnasBaseData.SystemBaseData.Select(" type_code='HCS-qualitydetection-area' or type_code='HCS_workapace_type' or type_code='HCS-quality-detection-type' or type_code = 'HCS-detection-type'");
			Dictionary<string, string> tempDic = new Dictionary<string, string>();
			if (data != null && data.Length > 0)
			{
				foreach (DataRow item in data)
				{
					if (item["type_code"] != null)
					{
						if (item["type_code"].ToString() == "HCS-quality-detection-type")
						{
							if (isAddReason)
							{
								_reasonDic.Add(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
							}
						}
						else if (item["type_code"].ToString() == "HCS-detection-type")
						{
							if (isAddType)
							{
								_typeDic.Add(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
							}
						}
						else if (item["type_code"].ToString() == "HCS_workapace_type")
						{
							if(isAddArea)
							{
								_areaDic.Add(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
							}
						}
						else if (item["type_code"].ToString() == "HCS-qualitydetection-area")
						{
							if (isAddAreaReason)
							{
								_areaReasonDic.Add(item["key_code"].ToString().Trim(), item["value_code"].ToString().Trim());
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// 设置combox
		/// </summary>
		/// <param name="combox"></param>
		/// <param name="dataSource"></param>
		private void InitComboxItem(ComboBox combox,Dictionary<string,string> dataSource)
		{
			if (dataSource != null && dataSource.Count > 0)
			{
				BindingSource bs = new BindingSource();
				bs.DataSource = dataSource;
				combox.DataSource = bs;
				combox.DisplayMember = "Value";
				combox.ValueMember = "Key";
			}
		}

		/// <summary>
		/// 查询事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			InitDvg_01Data();
		}

		/// <summary>
		/// 加载datagrid数据
		/// </summary>
		private void InitDvg_01Data()
		{
			string typestr =Convert.ToString(cbbType.SelectedValue);
			string reasonstr = Convert.ToString(cbbreason.SelectedValue);
			int type = 0, reasontype = 0;
			Int32.TryParse(typestr, out type);
			Int32.TryParse(reasonstr, out reasontype);
			string whereSql = string.Empty;
			whereSql += type == 0 ? "" : string.Format(" and  entity_type={0} ", type);
			whereSql += reasontype == 0 ? "" : string.Format(" and  type={0} ", reasontype);

			SortedList condition = new SortedList();
			condition.Add(1, crestartdate.Value);
			condition.Add(2, creenddate.Value);
			condition.Add(3, whereSql);
			string testReasonSql = RemoteClient.RemotInterface.CheckSelectData("HCS-qualitydetection-area-sec004", condition);
			DataTable tempTable = RemoteClient.RemotInterface.SelectData("HCS-qualitydetection-area-sec004", condition);
			SetDvg_01Data(tempTable);
		}

		/// <summary>
		/// 填充grid
		/// </summary>
		/// <param name="table"></param>
		private void SetDvg_01Data(DataTable table)
		{
			if (dgv_01.Rows.Count > 0)
			{
				dgv_01.Rows.Clear();
			}
			bool isChangceReason = _reasonDic != null && _reasonDic.Count > 1;
			bool isChangceType = _typeDic != null && _typeDic.Count > 1;
			bool isChangceArea = _areaDic != null && _areaDic.Count > 0;
			string customerId = string.Empty;
			if (App_ID== ("1050"))
			{
				if (CnasBaseData.UserAccessCustomer != null)
				{
					foreach (DataRow item in CnasBaseData.UserAccessCustomer.Rows)
					{
						if (item["id"] != null)
							customerId += string.Format("{0},", item["id"]);
					}
				}
			}
			else
			{
				customerId ="ALL";
			}
			if(table!=null&&table.Rows.Count>0)
			{
				foreach (DataRow row in table.Rows)
				{
					if (!string.IsNullOrEmpty(customerId) &&(customerId == "ALL" || 
						(row["customer_id"]!= null && CnasUtilityTools.IsContains(customerId, Convert.ToString(row["customer_id"])))))
					{
						int rowIndex = dgv_01.Rows.Add();
						if (table.Columns.Contains("location_id") && row["location_id"] != null)
						{
							dgv_01.Rows[rowIndex].Cells["location_id"].Value = Convert.ToString(row["location_id"]);
						}
						if (table.Columns.Contains("area") && row["area"] != null) dgv_01.Rows[rowIndex].Cells["location_idText"].Value = Convert.ToString(row["area"]);
						if (table.Columns.Contains("entity") && row["entity"] != null) dgv_01.Rows[rowIndex].Cells["entity_typeText"].Value = Convert.ToString(row["entity"]);
						if (table.Columns.Contains("statistics_type") && row["statistics_type"] != null) dgv_01.Rows[rowIndex].Cells["typeText"].Value = Convert.ToString(row["statistics_type"]);

						if (table.Columns.Contains("id") && row["id"] != null) dgv_01.Rows[rowIndex].Cells["id"].Value = Convert.ToString(row["id"]);
						if (table.Columns.Contains("bar_code") && row["bar_code"] != null) dgv_01.Rows[rowIndex].Cells["bar_code"].Value = Convert.ToString(row["bar_code"]);
						if (table.Columns.Contains("ca_name") && row["ca_name"] != null) dgv_01.Rows[rowIndex].Cells["ca_name"].Value = Convert.ToString(row["ca_name"]);
						if (table.Columns.Contains("entity_type") && row["entity_type"] != null)
						{
							dgv_01.Rows[rowIndex].Cells["entity_type"].Value = Convert.ToString(row["entity_type"]);
						}
						if (table.Columns.Contains("num") && row["num"] != null) dgv_01.Rows[rowIndex].Cells["num"].Value = row["num"];
						if (table.Columns.Contains("type") && row["type"] != null)
						{
							dgv_01.Rows[rowIndex].Cells["type"].Value = Convert.ToString(row["type"]);
						}
						if (table.Columns.Contains("remark") && row["remark"] != null) dgv_01.Rows[rowIndex].Cells["remark"].Value = Convert.ToString(row["remark"]);
						if (table.Columns.Contains("cre_date") && row["cre_date"] != null) dgv_01.Rows[rowIndex].Cells["cre_date"].Value = row["cre_date"];
					}
				}
			}
		}

		/// <summary>
		/// 返回对应值 枚举值转换
		/// </summary>
		/// <param name="cellValu"></param>
		/// <param name="dic"></param>
		/// <returns></returns>
		private string SetDataValue(object cellValue,Dictionary<string,string> dic,bool isflag)
		{
			if(isflag)
			{
				if (cellValue == null)
					return string.Empty;
				else
				{
					if(dic.ContainsKey(cellValue.ToString()))
					{
						return dic[cellValue.ToString()].ToString();
					}
					else
					{
						return Convert.ToString(cellValue);
					}
				}
			}
			else
			{
				return Convert.ToString(cellValue);
			}
		}

		/// <summary>
		/// 根据value  得到key
		/// </summary>
		/// <param name="dic"></param>
		/// <param name="dicValue"></param>
		/// <returns></returns>
		private string GetDataValue(Dictionary<string,string> dic,string dicValue)
		{
			if(dic!=null&&dic.Count>0)
			{
				foreach(KeyValuePair<string,string> item in dic)
				{
					if(item.Value.Equals(dicValue))
					{
						return item.Key;
					}
				}
			}
			return dicValue;
		}

		/// <summary>
		/// 修改事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dgv_01.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgv_01.SelectedRows[0];
				Dictionary<string, string> tempReasonDic = new Dictionary<string, string>();
				string areaId = Convert.ToString(row.Cells["location_id"].Value);//区域
				string typeId = Convert.ToString(row.Cells["entity_type"].Value);//类型
				if (_areaReasonDic != null && _areaReasonDic.Count > 0 && _reasonDic != null && _reasonDic.Count > 0)
				{
					if (_areaReasonDic.ContainsKey(areaId))
					{
						string areaCode = _areaReasonDic[areaId].ToString();
						string[] reasonArray = areaCode.Split(',');
						for(int i=0;i<reasonArray.Count();i++)
						{
							if(!string.IsNullOrEmpty(reasonArray[i])&&reasonArray[i].Substring(0,1).Equals(typeId))
							{
								if(_reasonDic.ContainsKey(reasonArray[i]))
								{
									tempReasonDic.Add(reasonArray[i], _reasonDic[reasonArray[i]]);
								}
							}
						}
					}
				}
				if (tempReasonDic.Count > 0)
				{
					HCSSM_statistics_edit edit = new HCSSM_statistics_edit();
					edit.ViewDataRow = row;
					edit.ReasonDic = tempReasonDic;
					edit.ShowDialog();
					row.Cells["typeText"].Value = edit.ViewDataRow.Cells["typeText"].Value;
					row.Cells["type"].Value = edit.ViewDataRow.Cells["type"].Value;
					row.Cells["num"].Value = edit.ViewDataRow.Cells["num"].Value;
					row.Cells["remark"].Value = edit.ViewDataRow.Cells["remark"].Value;
				}
			}
		}
		/// <summary>
		/// 打印Pri
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPri_Click(object sender, EventArgs e)
		{
			DataGridView dataGrid = dgv_01;
			if (dataGrid != null&&dataGrid.Rows.Count>0)
			{
				//DataRow[] data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and value_code like '%{0},%'", PdCode));
				DataRow[] data = CnasBaseData.SystemBaseData.Select(string.Format("type_code='HCS-print-WF-type' and key_code = 'defaultTemplate'"));
				if (data != null&&data.Length>0)
				{
					string pringxml = data[0]["other_code"].ToString().Trim();
					PrintHelper.Instance.Print_DataGridView(dataGrid, pringxml);
				}
				else
				{
					MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindPrintTemplage", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("notfindSetGrid", EnumPromptMessage.error), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			if(dgv_01.SelectedRows.Count>0)
			{
				DataGridViewRow row = dgv_01.SelectedRows[0];
				int id;
				Int32.TryParse(Convert.ToString(row.Cells["id"].Value), out id);
				SortedList condition = new SortedList();
				condition.Add(1, id);
				SortedList paramlist = new SortedList();
				paramlist.Add(1, condition);
				string testReasonSql = RemoteClient.RemotInterface.CheckUPData(1, "HCS-qualitydetection-area-up002", paramlist, null);
				int result = RemoteClient.RemotInterface.UPData(1, "HCS-qualitydetection-area-up002", paramlist, null);
				if(result>0)
				{
					dgv_01.Rows.Remove(row);
				}
				else
				{
					MessageBox.Show("删除失败！");
				}
			}
		}

		private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			btnEdit_Click(null, null);
		}

		private void dgv_01_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
