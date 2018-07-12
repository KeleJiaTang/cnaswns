using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_access_car : ControlViewBase
	{


		public HCSWF_access_car()
		{
			InitializeComponent();
		}


		/// <summary>
		/// 接受车窗口
		/// </summary>
		/// <param name="pdCode">扫描条形码</param>
		public HCSWF_access_car(SortedList scanCodes)
			: base(scanCodes)
		{
			InitializeComponent();
		}

		public override void InitalizeControl()
		{
			base.InitalizeControl();
			RefreshDataGrid();
			if (_tranferCars != null)
				carNumTxt.Text = _tranferCars.Count.ToString();

			GetLocation();
		}


		private void GetLocation()
		{
			SortedList condition = new SortedList();
			string locationCode =  BarCodeHelper.GetBarCodeByType("BCE", ScanBarCodes);
			if (string.IsNullOrEmpty(locationCode))
				locationCode = BarCodeHelper.GetBarCodeByType("BCF", ScanBarCodes);
			if (string.IsNullOrEmpty(locationCode))
				return;
			condition.Add(1, locationCode);
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-use-location-sec004", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-use-location-sec004", condition);
			if (data != null && data.Rows.Count > 0)
			{
				DataRow row = data.Rows[0];
				if (row["type_name"] != null && row["u_uname"] !=null)
				{
					areaTxt.Text = (row["u_locationtype"] != null && row["u_locationtype"].ToString() != "5") ? row["type_name"].ToString() : row["u_uname"].ToString();
				}
			}
		}

		public void RefreshDataGrid()
		{
			GetTransferCars();
			GetWorkSets();
			for (int i = 0; i < _tranferCars.Count; i++)
			{
				Dictionary<string, string> car = _tranferCars[i] as Dictionary<string, string>;
				if (car != null)
				{
					int rowIndex = carDataGrid.Rows.Add();
					if (car.ContainsKey("id")) carDataGrid.Rows[rowIndex].Cells["idCol"].Value = car["id"].ToString();
					if (car.ContainsKey("bar_code"))
					{
						carDataGrid.Rows[rowIndex].Cells["carCodeCol"].Value = car["bar_code"].ToString();
						carDataGrid.Rows[rowIndex].Cells["setNumCol"].Value = GetSetNumber(_workSets, car["bar_code"].ToString());
					}
					if (car.ContainsKey("ca_name")) carDataGrid.Rows[rowIndex].Cells["nameCol"].Value = car["ca_name"].ToString();
					if (car.ContainsKey("run_times")) carDataGrid.Rows[rowIndex].Cells["runTimeCol"].Value = car["run_times"].ToString();
				}
			}
		}

		private int GetSetNumber(SortedList workSets, string carBarCode)
		{
			int count = 0;
			if (workSets != null && workSets.Count > 0)
			{
				for (int i = 0; i < workSets.Count; i++)
				{
					Dictionary<string, string> workSet = workSets[i] as Dictionary<string, string>;
					if (workSet != null && workSet.ContainsKey("container_code")
						&& workSet["container_code"].ToString() == carBarCode)
						count++;
				}
			}
			return count;
		} 

		private SortedList _tranferCars = new SortedList();
		private SortedList _workSets = new SortedList();

		public SortedList GetWorkSets()
		{
			_workSets.Clear();
			SortedList condition = new SortedList();
			condition.Add(1, "0");
			condition.Add(2, PdCode);
			condition.Add(6, BarCodeHelper.GetBarCodeByType("BCD", ScanBarCodes));
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec001", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec001", condition);
			if (data != null)
			{
				int index = 0;
				foreach (DataRow row in data.Rows)
				{
					Dictionary<string, string> workSet = new Dictionary<string, string>();
					if (row["id"] != null) workSet.Add("id", row["id"].ToString());
					if (row["set_id"] != null) workSet.Add("set_id", row["set_id"].ToString());
					if (row["set_code"] != null) workSet.Add("set_code", row["set_code"].ToString());
					if (row["set_name"] != null) workSet.Add("set_name", row["set_name"].ToString());
					if (row["wf_code"] != null) workSet.Add("wf_code", row["wf_code"].ToString());
					if (row["user_id"] != null) workSet.Add("user_id", row["user_id"].ToString());
					if (row["info_serial"] != null) workSet.Add("info_serial", row["info_serial"].ToString());
					if (row["container_code"] != null) workSet.Add("container_code", row["container_code"].ToString());
					if (row["BCU_code"] != null) workSet.Add("BCU_code", row["BCU_code"].ToString());
					if (row["status"] != null) workSet.Add("status", row["status"].ToString());
					if (row["cre_date"] != null) workSet.Add("cre_date", row["cre_date"].ToString());
					if (row["mod_date"] != null) workSet.Add("mod_date", row["mod_date"].ToString());
					if (row["remark"] != null) workSet.Add("remark", row["remark"].ToString());

					_workSets.Add(index, workSet);
					index++;
				}
			}

			return _workSets;
		}

		public SortedList GetTransferCars()
		{
			SortedList condition = new SortedList();
			_tranferCars.Clear();
			condition.Add(1, BarCodeHelper.GetBarCodeByType("BCD", ScanBarCodes));
			string sqlTest = RemoteClient.RemotInterface.CheckSelectData("HCS-transprot-device-sec001", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-transprot-device-sec001", condition);
			if (data != null)
			{
				int index = 0;
				foreach (DataRow row in data.Rows)
				{
					Dictionary<string, string> car = new Dictionary<string, string>();
					if (row["id"] != null) car.Add("id", row["id"].ToString());
					if (row["ca_name"] != null) car.Add("ca_name", row["ca_name"].ToString());
					if (row["bar_code"] != null) car.Add("bar_code", row["bar_code"].ToString());
					if (row["ca_type"] != null) car.Add("ca_type", row["ca_type"].ToString());
					if (row["max_times"] != null) car.Add("max_times", row["max_times"].ToString());
					if (row["run_times"] != null) car.Add("run_times", row["run_times"].ToString());
					if (row["ca_vendor"] != null) car.Add("ca_vendor", row["ca_vendor"].ToString());
					if (row["mod_date"] != null) car.Add("mod_date", row["mod_date"].ToString());
					if (row["cre_date"] != null) car.Add("cre_date", row["cre_date"].ToString());
					if (row["ca_remarks"] != null) car.Add("ca_remarks", row["ca_remarks"].ToString());
					if (row["si_id"] != null) car.Add("si_id", row["si_id"].ToString());
					if (row["sales_id"] != null) car.Add("sales_id", row["sales_id"].ToString());
					if (row["state"] != null) car.Add("state", row["state"].ToString());

					_tranferCars.Add(index, car);
					index++;
				}
			}
			return _tranferCars;
		}

		public void CheckTransferCar()
		{
			HCSWF_check_car checkCarDialog = new HCSWF_check_car(PdCode,ScanBarCodes);
			checkCarDialog.ShowDialog();
		}

		public override Dictionary<string, string> SetViewParameters()
		{
			Dictionary<string, string> result= base.SetViewParameters();
			if (WorkflowServer.Transport_container_wf.Contains(PdCode))
			{
				SortedList devices = new SortedList();
				int index = 1;
				foreach (DataGridViewRow item in carDataGrid.Rows)
				{
					SortedList device = new SortedList();
					device.Add(1, item.Cells["carCodeCol"].Value.ToString());
					devices.Add(index, device);
					index++;
				}
				OutputParameters.Add("deviceParams", devices);
			}


			return result;
		}

	}
}
