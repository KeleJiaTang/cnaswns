using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasWorkflowArithmetic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_order_setdetail : MetroForm
	{
		/// <summary>
		/// 区域ID
		/// </summary>
		public string App_ID = string.Empty;
		/// <summary>
		/// 数据库访问接口
		/// </summary>
		private CnasRemotCall remoteClient = new CnasRemotCall();
		/// <summary>
		/// 是否需要改变包的图片
		/// </summary>
		private List<Image> _defaultImage = new List<Image>() { ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "defaultBgHor") };
		/// <summary>
		/// 包的图片
		/// </summary>
		private List<Image> _setImages = new List<Image>();
		/// <summary>
		/// 是否第一次加载
		/// </summary>
		private bool _isFirst = true;
		/// <summary>
		/// 流程核算
		/// </summary>
		private CnasHCSWorkflowInterface _workflowServer = null;
		/// <summary>
		/// 流程
		/// </summary>
		private DataTable _pdData = null;
		/// <summary>
		/// 流程参数
		/// </summary>
		private DataTable _pdParameters = null;
		/// <summary>
		/// 1器械还是2订单包
		/// </summary>
		private int _model;
		/// <summary>
		/// 基本id
		/// </summary>
		private string _baseId;
		/// <summary>
		/// 订单号
		/// </summary>
		private string _orderNum;
		/// <summary>
		/// 流程
		/// </summary>
		public DataTable PdData {
			get
			{
				return _pdData;
			}
			set
			{
				if(value!=_pdData)
					_pdData = value;
			}
		}
		/// <summary>
		/// 流程参数
		/// </summary>
		public DataTable Pdparameters
		{
			get
			{
				return _pdParameters;
			}
			set
			{
				if (value != _pdParameters)
					_pdParameters = value;
			}
		}
		/// <summary>
		/// 流程核算
		/// </summary>
		public CnasHCSWorkflowInterface WorkflowServer
		{
			get
			{
				return _workflowServer;
			}
			set
			{
				if (value != _workflowServer)
					_workflowServer = value;
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="model"></param>
		public HCSSM_order_setdetail(int model,string baseid,string orderNum)
		{
			if(model!=1&&model!=2)
			{
				throw new Exception("model值只能为1或2!");
			}
			_model = model;
			_baseId = baseid;
			_orderNum = orderNum;
			InitializeComponent();
		}

		/// <summary>
		/// 设置包的图片信息
		/// </summary>
		private List<Image> GetSetImages()
		{
			List<Image> images = new List<Image>();
			SortedList sortedList = new SortedList();
			sortedList.Add(1, 1);
			sortedList.Add(2, _baseId);
			sortedList.Add(3, 1);
			//CnasRemotCall remoteClient = new CnasRemotCall();
			string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-image-sec001", sortedList);
			DataTable dtImageList = remoteClient.RemotInterface.SelectData("HCS-image-sec001", sortedList);
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
				instrumentGrid.ClearSelection();
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
				//string testSql = remoteClient.RemotInterface.CheckSelectData("HCS-image-sec001", sortedList);
				DataTable dtImageList = remoteClient.RemotInterface.SelectData("HCS-image-sec001", sortedList);
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
		/// 初始化图片
		/// </summary>
		public void InitializeButtonImage()
		{
			btnSetImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 加载窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_setdetail_Load(object sender, EventArgs e)
		{
			InitButtonImage();
			InitStateModel();
			LoadData();
			_isFirst = false;
			if (_model != 1)
			{
				ChangeInstrumentImage();
				btnSetImage_Click(null, null);
			}
			
		}

		/// <summary>
		/// 初始化相关信息
		/// </summary>
		private void InitStateModel()
		{
			btnSetImage.Visible = App_ID == "1020";
			lbOrderSetName.Text = _model == 1 ? "器械名称" : "包  名  称";
			instrumentGrid.Visible = _model != 1;
			btnSetImage.Visible = _model != 1;
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void LoadData()
		{
			instrumentGrid.Rows.Clear();
			SortedList otherCon = new SortedList();
			otherCon.Add(1, _model);
			otherCon.Add(2, _baseId);
			otherCon.Add(3, _orderNum);
			DataTable dataCus = remoteClient.RemotInterface.SelectData("hcs_work_specialset_info-sec011", otherCon);
			if (dataCus != null && dataCus.Rows.Count > 0)
			{
				txtOrderName.Text = Convert.ToString(dataCus.Rows[0]["orderName"]);
				txtLocationName.Text = Convert.ToString(dataCus.Rows[0]["u_uname"]);
			}
			string sql = _model == 1 ? "HCS-instrument-info-sec005" : "HCS-instrument-info-sec004";
			SortedList condition = new SortedList();
			condition.Add(1, _baseId);
			condition.Add(2, CnasBaseData.SystemID);
			if (_model != 1) condition.Add(3, _baseId);
			//string testSql = remoteClient.RemotInterface.CheckSelectData(sql, condition);
			DataTable data = remoteClient.RemotInterface.SelectData(sql, condition);
			if(data!=null&&data.Rows.Count>0)
			{
				DataRow row = data.Rows[0];
				txtCustomerName.Text = Convert.ToString(row["cu_name"]);
				//txtCostCenter.Text = Convert.ToString(row["costc_name"]);
				txtOrderSetName.Text = _model == 1 ? Convert.ToString(row["ca_name"]) : Convert.ToString(row["setc_name"]);
				if (_model != 1)
				{
					int allNum = 0;
					int num_int;
					foreach (DataRow item in data.Rows)
					{
						string str_id = Convert.ToString(item["id"]);
						if (!string.IsNullOrEmpty(str_id))
						{
							int rowIndex = instrumentGrid.Rows.Add();
							if (item["id"] != null) instrumentGrid.Rows[rowIndex].Cells["idCol"].Value = item["id"];
							if (item["ca_name"] != null) instrumentGrid.Rows[rowIndex].Cells["inNameCol"].Value = item["ca_name"];
							if (item["instrument_type"] != null) instrumentGrid.Rows[rowIndex].Cells["inTypeCol"].Value = item["instrument_type"];
							if (item["instrument_num"] != null){
								string tempNum = Convert.ToString(item["instrument_num"]);
								Int32.TryParse(tempNum,out num_int);
								allNum += num_int;
								instrumentGrid.Rows[rowIndex].Cells["inNumCol"].Value = tempNum;
							}
						}
					}
					if(allNum>0)
					{
						instrumentGrid.Columns["inNumCol"].HeaderCell.Value = string.Format("数量(总数量: {0})", allNum);
					}
					if(instrumentGrid.Rows.Count>0)
						instrumentGrid.Rows[0].Selected = true;
				}
			}
			if (_model == 1)
			{
				//图片未呈现前关闭会异常
				//Thread thread = new Thread(() =>
				//{
					List<Image> instrumentImage = GetInstrumentImages(_baseId);
					//this.Invoke(new Action(() =>
					//{
						pictureBoxData.Images = instrumentImage;
					//}));
				//});
				//thread.Start();
			}
			if(instrumentGrid.Rows.Count==0)
			{
				btnSetImage_Click(null, null);
				instrumentGrid.Visible = false;
				btnSetImage.Visible = false;
			}
		}

		/// <summary>
		/// 重新设置高度
		/// </summary>
		private void SetPictureHeight()
		{
			if (pictureBoxData.SelectImage != null)
			{
				pictureBoxData.Height = pictureBoxData.SelectImage.Height * pictureBoxData.Width / pictureBoxData.SelectImage.Width;
			}
			else
			{
				pictureBoxData.Height = 9 * pictureBoxData.Width / 16;
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			btnSetImage.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPrint32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// close
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 查看包的图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetImage_Click(object sender, EventArgs e)
		{
			if (_model != 1)
			{
				//图片未呈现前关闭会异常
				//Thread thread = new Thread(() =>
				//{
				_setImages = GetSetImages();
				//	this.Invoke(new Action(() =>
				//	{
						pictureBoxData.Images = _setImages;
				//	}));
				//});
				//thread.Start();
			}
		}

		/// <summary>
		/// 切换器械图片
		/// </summary>
		private void ChangeInstrumentImage()
		{
			if (!_isFirst&&_model!=1)
			{
				if (instrumentGrid.SelectedRows != null && instrumentGrid.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = instrumentGrid.SelectedRows[0];
					string instrumentId = Convert.ToString(selectedRow.Cells["idCol"].Value);
					if (!string.IsNullOrEmpty(instrumentId))
					{
						pictureBoxData.Images = GetInstrumentImages(instrumentId);
					}
					else
					{
						pictureBoxData.Images = _defaultImage;
					}
					SetPictureHeight();
				}
			}
		}

		/// <summary>
		/// 切换图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void instrumentGrid_SelectionChanged(object sender, EventArgs e)
		{
			ChangeInstrumentImage();
		}
	}
}
