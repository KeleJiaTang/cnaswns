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
	public partial class HCSWF_access_set : ControlViewBase
	{


		/// <summary>
		/// 无参数初始化win
		/// </summary>
		public HCSWF_access_set()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 系列条形码初始化
		/// </summary>
		/// <param name="codeList"></param>
		public HCSWF_access_set(SortedList codeList):base(codeList)
		{
			InitializeComponent();
			
		}

		/// <summary>
		/// 初始化窗口控件 -- 在Load事件中加载
		/// </summary>
		public override void InitalizeControl()
		{
			base.InitalizeControl();
			RefreshWorkSets();
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void RefreshWorkSets()
		{
			setDataGrid.Rows.Clear();
			if(!string.IsNullOrEmpty(PdCode))
			{
				SortedList condition = new SortedList();
				condition.Add(1, PdCode);
				condition.Add(2, "0");

				string setBarCodes = BarCodeHelper.GetBarCodeByType("BCC", ScanBarCodes);
				setBarCodes = setBarCodes.Replace(",", "','");
				condition.Add(3, setBarCodes);
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec003", condition);
				DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec003", condition);
				if(data != null && data.Rows.Count > 0)
				{
					foreach (DataRow item in data.Rows)
					{
						DataConverter.ConvertSetData(setDataGrid, item);
					}
				}

				AppendTempBCCSet();
				setNumTxt.Text = setDataGrid.Rows.Count.ToString();

			}
		}


		//public void ReleaseSpecialSet()
		//{
		//	if (setDataGrid.SelectedRows != null && setDataGrid.SelectedRows.Count == 1)
		//	{
		//		string setBarCode = setDataGrid.SelectedRows[0].Cells["setBarCodeCol"].Value.ToString();
		//		bool isBCCSSet = BarCodeHelper.IsSpecialSet(setBarCode);
		//		if (isBCCSSet)
		//		{
		//			string message = string.Format("请确认不再绑定器械包{0}-{1}与下列器械的关系。", setBarCode, setDataGrid.SelectedRows[0].Cells["ca_name"].Value.ToString());
		//			SortedList condition = new SortedList();
		//			condition.Add(1, CnasBaseData.SystemID);
		//			condition.Add(2, setBarCode);
		//			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-instrument-info-sec002", condition);
		//			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-instrument-info-sec002", condition);
		//			SortedList deleteData = new SortedList();
		//			if (data != null && data.Rows.Count > 0)
		//			{
		//				int index = 1;
		//				foreach (DataRow item in data.Rows)
		//				{
		//					SortedList deleteItem = new SortedList();
		//					deleteData.Add(index, deleteItem);
		//					index++;
		//					if (item["ca_name"] != null && item["instrument_num"] != null)
		//					{
		//						message += "\r\n" + item["ca_name"].ToString() + item["instrument_num"].ToString();
		//					}
		//					deleteData.Add(2, item["wsin_remark"] != null ? item["id"].ToString() : "");
		//					deleteData.Add(2, "9");
		//					deleteData.Add(3, item["wsin_id"]);
		//				}
		//
		//				if (MessageBox.Show(message, "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
		//				{
		//					string testDeleteSql = RemoteClient.RemotInterface.CheckUPDataList("HCS-work-specialset-info-up002", deleteData);
		//					int result = RemoteClient.RemotInterface.UPDataList("HCS-work-specialset-info-up002", deleteData);
		//					if (result <= -1)
		//					{
		//						MessageBox.Show("保存特殊器械包器械配置失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//					}
		//				}
		//			}
		//		}
		//		else
		//			MessageBox.Show("请选择特殊器械包", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//	}
		//	else
		//	{
		//		MessageBox.Show("请选择特殊器械包", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//	}
		//}


	}
}
