using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_set_detail : BaseForm
	{
		/// <summary>
		/// 包或者器械的id
		/// </summary>
		private int _packingSetBaseId = 0;

		/// <summary>
		/// 是否需要改变包的图片
		/// </summary>
		private List<Image> _defaultImage = new List<Image>() { ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "defaultBgHor") };
		private List<Image> _setImages = new List<Image>();
		/// <summary>
		/// 初始化win
		/// </summary>
		public HCSWF_set_detail()
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public override void InitializeButtonImage()
		{
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}
		/// <summary>
		/// 初始化win
		/// </summary>
		/// <param name="codeList"></param>
		public HCSWF_set_detail(SortedList codeList):base(codeList)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		/// <summary>
		/// 初始化控件数据
		/// </summary>
		public override void InitalizeControl()
		{
			base.InitalizeControl();
			InitalizeSetInfo();
			RefreshDataGrid();
			InitPicTypeCbx();
		}

		/// <summary>
		/// 初始化图片类型
		/// </summary>
		private void InitPicTypeCbx()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic.Add("1", "器械包");
			dic.Add("2", "器械");
			BindingSource bs = new BindingSource();
			bs.DataSource = dic;
			picTypeCbx.DataSource = bs;
			picTypeCbx.DisplayMember = "Value";
			picTypeCbx.ValueMember = "Key";
			picTypeCbx.SelectedIndex = 0;
		}

		/// <summary>
		/// 设置包的基本信息
		/// </summary>
		private void InitalizeSetInfo()
		{
			SortedList condition = new SortedList();
			condition.Add(1, "0");
			string setBarCodes = BarCodeHelper.GetBarCodeByType("BCC", ScanBarCodes);
			setBarCodes = setBarCodes.Replace(",", "','");
			condition.Add(2, setBarCodes);
			string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec004", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec004", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					if (data.Rows[i]["bar_code"] != null)
					{
						setBarCodeTxt.Text = data.Rows[i]["bar_code"].ToString();
						if (data.Rows[i]["ca_name"] != null) setNameTxt.Text = data.Rows[i]["ca_name"].ToString();
						//if (data.Rows[i]["pa_type"] != null) setTypeTxt.Text = data.Rows[i]["pa_type"].ToString();
						//if (data.Rows[i]["pa_priorty"] != null) setPriortyTxt.Text = data.Rows[i]["pa_priorty"].ToString();
						//if (data.Rows[i]["st_pr_Name"] != null) setSterilizerTxt.Text = data.Rows[i]["st_pr_Name"].ToString();
						//if (data.Rows[i]["wa_pr_Name"] != null) setWashingTxt.Text = data.Rows[i]["wa_pr_Name"].ToString();
						//if (data.Rows[i]["cost_center_name"] != null) costCenterTxt.Text = data.Rows[i]["cost_center_name"].ToString();
						//if (data.Rows[i]["location_name"] != null) setUseTxt.Text = data.Rows[i]["location_name"].ToString();
						//if (data.Rows[i]["base_set_id"] != null) int.TryParse(data.Rows[i]["base_set_id"].ToString(), out _packingSetBaseId);
						break;
					}
				}
			}
			_setImages = GetSetImages();
		}

		/// <summary>
		/// 加载grid数据
		/// </summary>
		private void RefreshDataGrid()
		{
			bool isBCCS = BarCodeHelper.IsSpecialSet(setBarCodeTxt.Text);
			string sql = isBCCS ? "HCS-instrument-info-sec002" : "HCS-instrument-info-sec001";
			SortedList condition = new SortedList();
			condition.Add(1, CnasBaseData.SystemID);
			condition.Add(2, isBCCS ? setBarCodeTxt.Text : _packingSetBaseId.ToString());
			string testSql = RemoteClient.RemotInterface.CheckSelectData(sql, condition);
			DataTable data = RemoteClient.RemotInterface.SelectData(sql, condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow item in data.Rows)
				{
					int rowIndex = instrumentGrid.Rows.Add();
					if (item["id"] != null) instrumentGrid.Rows[rowIndex].Cells["idCol"].Value = item["id"];
					if (item["ca_name"] != null) instrumentGrid.Rows[rowIndex].Cells["inNameCol"].Value = item["ca_name"];
					if (item["instrument_type"] != null) instrumentGrid.Rows[rowIndex].Cells["inTypeCol"].Value = item["instrument_type"];
					if (item["instrument_num"] != null) instrumentGrid.Rows[rowIndex].Cells["inNumCol"].Value = item["instrument_num"];
					if (item["costc_name"] != null) instrumentGrid.Rows[rowIndex].Cells["costCNameCol"].Value = item["costc_name"];
					if (item["ca_price"] != null) instrumentGrid.Rows[rowIndex].Cells["inPriceCol"].Value = item["ca_price"];
				}
				instrumentGrid.Rows[0].Selected = false;
			}

		}

		/// <summary>
		/// 设置包的图片信息
		/// </summary>
		private List<Image> GetSetImages()
		{
			List<Image> images = new List<Image>();
			SortedList sortedList = new SortedList();
			sortedList.Add(1, setBarCodeTxt.Text);
			sortedList.Add(2, "1");
			CnasRemotCall remoteClient = new CnasRemotCall();
			string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-image-sec002", sortedList);
			DataTable dtImageList = remoteClient.RemotInterface.SelectData("HCS-image-sec002", sortedList);
			if (dtImageList != null && dtImageList.Rows != null && dtImageList.Rows.Count > 0)
			{
				Image image = null;
				foreach (DataRow item in dtImageList.Rows)
				{
					string fileName = "";
					image = null;
					if (item["data_url"] != null) fileName = item["data_url"].ToString();
					if (!string.IsNullOrEmpty(fileName))
					{
						ImageCache imageCache = new ImageCache();
						image = imageCache.GetImageByFolderNameFileName("set/", fileName);
						if (image != null)
							images.Add(image);
					}
				}
			}
			else
			{
				images = _defaultImage;
			}

			return images;
		}

		/// <summary>
		/// 设置器械图片信息
		/// </summary>
		private List<Image> GetInstrumentImages(string instrumentId)
		{
			List<Image> images = new List<Image>();

			if (!string.IsNullOrEmpty(instrumentId))
			{
				SortedList sortedList = new SortedList();
				sortedList.Add(1, 2);
				sortedList.Add(2, instrumentId);
				sortedList.Add(3, 1);
				string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-image-sec001", sortedList);
				DataTable dtImageList = RemoteClient.RemotInterface.SelectData("HCS-image-sec001", sortedList);

				//无图片信息
				if (dtImageList == null || (dtImageList != null && dtImageList.Rows.Count == 0))
				{
					images = _defaultImage;
				}
				else
				{
					foreach (DataRow item in dtImageList.Rows)
					{
						string fileName = "";
						Image image = null;
						if (item["data_url"] != null) fileName = item["data_url"].ToString();
						if (!string.IsNullOrEmpty(fileName))
						{
							ImageCache imageCache = new ImageCache();
							image = imageCache.GetImageByFolderNameFileName("instruments/", fileName);
							if (image != null)
								images.Add(image);
						}
					}
				}
			}

			return images;
			
		}

		private void OnDataGridSelectedRowChanged(object sender, EventArgs e)
		{
			if (instrumentGrid.SelectedRows != null && instrumentGrid.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = instrumentGrid.SelectedRows[0];
				if (selectedRow.Cells["idCol"].Value != null && !string.IsNullOrEmpty(selectedRow.Cells["idCol"].Value.ToString()))
				{
					string instrumentId = selectedRow.Cells["idCol"].Value.ToString();
					pictureBoxData.Images = GetInstrumentImages(instrumentId);
					picTypeCbx.SelectedIndex = 1;

				}
			}
		}

		/// <summary>
		/// 图片选择事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPictureTypeChanged(object sender, EventArgs e)
		{
			if (picTypeCbx.SelectedItem != null && picTypeCbx.SelectedItem is KeyValuePair<string, string>)
			{
				KeyValuePair<string, string> typeItem = (KeyValuePair<string, string>)picTypeCbx.SelectedItem;
				if (typeItem.Key == "1")
				{
					pictureBoxData.Images = _setImages;
					instrumentGrid.ClearSelection();
				}
				else
				{
					OnDataGridSelectedRowChanged(null, null);
				}
			}
		}

		private void OnCancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
