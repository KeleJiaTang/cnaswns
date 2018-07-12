using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasWorkflowUILibrary
{
    public partial class HCSWF_set_detail_new : Telerik.WinControls.UI.RadForm
    {
		/// <summary>
		/// 是否第一次加载
		/// </summary>
		private bool _isFirst = true;
		/// <summary>
		/// 器械包BCC
		/// </summary>
		private string _bccCode;
		/// <summary>
		/// 包或者器械的id
		/// </summary>
		private int _packingSetBaseId = 0;
		/// <summary>
		/// 是否需要改变包的图片
		/// </summary>
		private List<Image> _defaultImage = new List<Image>() { ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "defaultBgHor") };
		/// <summary>
		/// 包的图片
		/// </summary>
		private List<Image> _setImages = new List<Image>();
		/// <summary>
		/// 初始化win
		/// </summary>
		public HCSWF_set_detail_new()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 初始化win
		/// </summary>
		/// <param name="codeList"></param>
		public HCSWF_set_detail_new(SortedList codeList)
		{
			InitializeComponent();
			string setBarCodes = BarCodeHelper.GetBarCodeByType("BCC", codeList);
			setBarCodes = setBarCodes.Replace(",", "','");
			_bccCode = setBarCodes;
			
		}
		/// <summary>
		/// 初始化win
		/// </summary>
		/// <param name="bccCode"></param>
		public HCSWF_set_detail_new(string bccCode)
		{
			InitializeComponent();
			_bccCode = bccCode;
		}

		/// <summary>
		/// 初始化控件数据
		/// </summary>
		public void InitalizeControl(string bccCode)
		{
			InitalizeSetInfo(bccCode);
			RefreshDataGrid();
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
		private void InitalizeSetInfo(string setBarCodes)
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			CnasRemotCall RemoteClient=new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, "0");
			condition.Add(2, setBarCodes);
			//string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-work-set-sec007", condition);
			DataTable data = RemoteClient.RemotInterface.SelectData("HCS-work-set-sec007", condition);
			if (data != null && data.Rows.Count > 0)
			{
				for (int i = 0; i < data.Rows.Count; i++)
				{
					if (data.Rows[i]["bar_code"] != null)
					{
						setBarCodeTxt.Text = data.Rows[i]["bar_code"].ToString();
						if (data.Rows[i]["ca_name"] != null) setNameTxt.Text = data.Rows[i]["ca_name"].ToString();
						//if (data.Rows[i]["pa_type"] != null) setTypeTxt.Text = data.Rows[i]["pa_type"].ToString();
						if (data.Rows[i]["pa_priorty"] != null) setPriortyTxt.Text = data.Rows[i]["pa_priorty"].ToString();
						//if (data.Rows[i]["st_pr_Name"] != null) setSterilizerTxt.Text = data.Rows[i]["st_pr_Name"].ToString();
						//if (data.Rows[i]["wa_pr_Name"] != null) setWashingTxt.Text = data.Rows[i]["wa_pr_Name"].ToString();
						if (data.Rows[i]["cost_center_name"] != null) costCenterTxt.Text = data.Rows[i]["cost_center_name"].ToString();
						if (data.Rows[i]["location_name"] != null) setUseTxt.Text = data.Rows[i]["location_name"].ToString();
						if (data.Rows[i]["base_set_id"] != null) int.TryParse(data.Rows[i]["base_set_id"].ToString(), out _packingSetBaseId);
						setBCU_code.Text = Convert.ToString(data.Rows[i]["BCU_code"]);
						setPriortyTxt.Text = Convert.ToString(data.Rows[i]["pa_priorty"]);
						customertxt.Text = Convert.ToString(data.Rows[i]["cu_name"]);
						fir_sname.Text = Convert.ToString(data.Rows[i]["fir_sname"]);
						sec_sname.Text = Convert.ToString(data.Rows[i]["sec_sname"]);
						break;
					}
				}
			}
			Thread thread = new Thread(() =>
			{
				_setImages = GetSetImages();
				if (picTypeCbx.SelectedItem != null)
				{
					RadListDataItem typeItem = picTypeCbx.SelectedItem;
					if (Convert.ToString(typeItem.Value) == "1")
					{
						this.Invoke(new Action(()=>{
							pictureBoxData.Images = _setImages;
						}));
					}
				}
			});
			thread.Start();
		}

		/// <summary>
		/// 加载grid数据
		/// </summary>
		private void RefreshDataGrid()
		{
			CnasRemotCall RemoteClient=new CnasRemotCall();
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
					GridViewRowInfo row = instrumentGrid.Rows.AddNew();
					if (item["id"] != null) row.Cells["idCol"].Value = item["id"];
					if (item["ca_name"] != null) row.Cells["inNameCol"].Value = item["ca_name"];
					if (item["instrument_type"] != null) row.Cells["inTypeCol"].Value = item["instrument_type"];
					if (item["instrument_num"] != null) row.Cells["inNumCol"].Value = item["instrument_num"];
					if (item["costc_name"] != null) row.Cells["costCNameCol"].Value = item["costc_name"];
					if (item["ca_price"] != null) row.Cells["inPriceCol"].Value = item["ca_price"];
				}
				instrumentGrid.ClearSelection();
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
			//string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-image-sec002", sortedList);
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
			CnasRemotCall RemoteClient=new CnasRemotCall();
			if (!string.IsNullOrEmpty(instrumentId))
			{
				SortedList sortedList = new SortedList();
				sortedList.Add(1, 2);
				sortedList.Add(2, instrumentId);
				sortedList.Add(3, 1);
				//string testSql = RemoteClient.RemotInterface.CheckSelectData("HCS-image-sec001", sortedList);
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

		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 图片选择事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPictureTypeChanged(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				if (picTypeCbx.SelectedItem != null)
				{
					if (picTypeCbx.SelectedIndex == 0)
					{
						pictureBoxData.Images = _setImages;
						SetPictureHeight();
						instrumentGrid.ClearSelection();
					}
					else
					{
						if ((instrumentGrid.SelectedRows == null || instrumentGrid.SelectedRows.Count == 0) && instrumentGrid.Rows.Count > 0)
						{
							instrumentGrid.Rows[0].IsSelected = true;
						}
						ChangeInstrumentImage();
					}
				}
			}
		}

		/// <summary>
		/// 切换器械图片
		/// </summary>
		private void ChangeInstrumentImage()
		{
			if (!_isFirst)
			{
				if (picTypeCbx.SelectedIndex == 1)
				{
					if (instrumentGrid.SelectedRows != null && instrumentGrid.SelectedRows.Count > 0)
					{
						GridViewRowInfo selectedRow = instrumentGrid.SelectedRows[0];
						string instrumentId = Convert.ToString(selectedRow.Cells["idCol"].Value);
						if (!string.IsNullOrEmpty(instrumentId))
						{
							pictureBoxData.Images = GetInstrumentImages(instrumentId);
							SetPictureHeight();
						}
					}
				}
				else
				{
					if (instrumentGrid.SelectedRows != null && instrumentGrid.SelectedRows.Count > 0)
					{
						picTypeCbx.SelectedIndex = 1;
					}
				}
			}
		}

		/// <summary>
		/// 选择器械
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDataGridSelectedRowChanged(object sender, EventArgs e)
		{
			ChangeInstrumentImage();
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSWF_set_detail_new_Load(object sender, EventArgs e)
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			InitButtonImage();
			InitPicTypeCbx();
			InitalizeControl(_bccCode);
			_isFirst = false;
		}


		/// <summary>
		/// 重新设置高度
		/// </summary>
		private void SetPictureHeight()
		{
			if (pictureBoxData.SelectImage != null)
			{
				pictureBoxData.Height= pictureBoxData.SelectImage.Height * pictureBoxData.Width / pictureBoxData.SelectImage.Width;
			}
			else
			{
				pictureBoxData.Height = 9 * pictureBoxData.Width / 16;
			}
		}

		/// <summary>
		/// 重绘制
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rightPanel_Resize(object sender, EventArgs e)
		{
			if (!_isFirst)
			{
				SetPictureHeight();
			}
		}
    }
}
