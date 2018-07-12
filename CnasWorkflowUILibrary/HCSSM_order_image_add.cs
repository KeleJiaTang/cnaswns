using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSManagerUC;
using Cnas.wns.CnasMetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_order_image_add : MetroForm
	{
		/// <summary>
		/// 1. 导入图片或拍照， 2 无订单时查看图片, 3有订单时查看图片
		/// </summary>
		private int _imageMode { get;set; }
		/// <summary>
		/// 批次号
		/// </summary>
		public string BatchNum { get; set; }
		/// <summary>
		/// 订单号
		/// </summary>
		public string BarCode { get; set; }
		/// <summary>
		/// orderNum_id
		/// </summary>
		private string _objectId = "0";
		/// <summary>
		/// 文件列表
		/// </summary>
		private List<string> _fileNames = new List<string>();
		/// <summary>
		/// 文件夹
		/// </summary>
		private string _uploadFolder = string.Empty;
		/// <summary>
		/// 服务器文件名
		/// </summary>
		private Dictionary<string, DataGridViewRow> _serverFileName = new Dictionary<string, DataGridViewRow>();
		/// <summary>
		/// 用于保存的文件
		/// </summary>
		public Dictionary<string, string> SaveFiles = new Dictionary<string, string>();
		/// <summary>
		/// 上次保存的文件记录
		/// </summary>
		private Dictionary<string, string> _oldFiles = new Dictionary<string, string>();

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="imageModel">枚举 1. 导入图片或拍照， 2 无订单时查看图片, 3有订单时查看图片</param>
		/// <param name="batchNum">临时编码</param>
		/// <param name="barCode">订单号</param>
		public HCSSM_order_image_add(int imageModel,string batchNum,string barCode)
		{
			_imageMode = imageModel;
			BatchNum = batchNum;
			BarCode = barCode;
			InitializeComponent();
			InitializeButtonImage();
		}

		/// <summary>
		/// 初始化按钮事件
		/// </summary>
		public void InitializeButtonImage()
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			deleteBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDelete32", EnumImageType.PNG);
			photoBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPhoto32", EnumImageType.PNG);
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			SetImportBtnStatus(true);
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFormLoaded(object sender, EventArgs e)
		{
			SetFunctionVisable();
			EUploadType eUpType = (EUploadType)OrderHelper.GetUploadType();
			_uploadFolder = CnasUtilityTools.GetFolderName(eUpType);
			string tempCode = _imageMode != 3 ? BatchNum : BarCode;
			LoadData(tempCode);
		}

		/// <summary>
		/// 设置导入按钮文本
		/// </summary>
		/// <param name="isImport"></param>
		private void SetImportBtnStatus(bool isImport)
		{
			string tileImageName = isImport ? "mImport32" : "mCancelImport32";
			string tileText = isImport ? "导 入 " : "停 止 ";
			importBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", tileImageName, EnumImageType.PNG);
			importBtn.Text = tileText;
		}

		/// <summary>
		/// 控制按钮呈现
		/// </summary>
		private void SetFunctionVisable()
		{
			bool isAdd = _imageMode == 1;
			lab_orderNum.Text = isAdd ? "临时编号:" : "订单编号:";
			txt_orderNum.Text = isAdd ? BatchNum : BarCode;
			pictureGrid.ContextMenuStrip = isAdd ? gridContextMenu : null;
			confirmBtn.Visible = isAdd;
			importBtn.Visible = isAdd;
			photoBtn.Visible = isAdd;
			closeBtn.Visible = !isAdd;
			cancelBtn.Visible = isAdd;
			deleteBtn.Visible = isAdd;
			buttonPanel.Visible = isAdd;
		}

		/// <summary>
		/// 拍照
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhotoBtnClick(object sender, EventArgs e)
		{
			SortedList sortedList = new SortedList();
			sortedList.Add("type", OrderHelper.GetUploadType());
			sortedList.Add("pack_id", _objectId);
			sortedList.Add("pack_barcode", BatchNum);

			HCSCM_set_image addNewImage = new HCSCM_set_image(sortedList);
			//获取一个值，指是否在Windows任务栏中显示窗体。
			addNewImage.ShowInTaskbar = false;
			if (addNewImage.ShowDialog() == DialogResult.OK)
			{
				string imageName = string.Format("{0}.jpg", addNewImage.ImageData01.Name);
				int rowIndex = pictureGrid.Rows.Add();
				pictureGrid.Rows[rowIndex].Cells["idCol"].Value = pictureGrid.RowCount;
				pictureGrid.Rows[rowIndex].Cells["pictureNameCol"].Value = string.Format("图片{0}", pictureGrid.RowCount);
				if (addNewImage.ImageData01 != null)
					pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = imageName;
				pictureGrid.Rows[rowIndex].Cells["imageCol"].Value = addNewImage.PrictureView.Image;
				pictureGrid.Rows[rowIndex].Cells["uploadStateCol"].Value = "上传完成";
				picturePreview.Images = new List<Image>() { addNewImage.PrictureView.Image };
				SortedList sqlParameters = new SortedList();
				SortedList imageItem = new SortedList();
				sqlParameters.Add(1, imageItem);
				imageItem.Add(1, imageName);
				CnasRemotCall remoteCall = new CnasRemotCall();
				//string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image_up003", sqlParameters);
				int result = remoteCall.RemotInterface.UPDataList("HCS_image_up003", sqlParameters);
			}
		}

		/// <summary>
		/// 导入图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImportBtnClick(object sender, EventArgs e)
		{
			if (!uploadFileWorker.IsBusy)
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.Multiselect = true;
				fileDialog.Filter = "图片文件(*.gif,*.jpg,*.jepg;*bmp,*png)|*.gif;*.jpg;*.jepg;*bmp;*png";
				fileDialog.FilterIndex = 2;
				fileDialog.Title = "打开图片文件(*.gif,*.jpg,*.jepg;*bmp,*png)";
				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					CnasRemotCall remoteCall = new CnasRemotCall();
					_serverFileName.Clear();

					foreach (string fileName in fileDialog.FileNames)
					{
						if (!_fileNames.Contains(fileName))
						{
							int rowIndex = pictureGrid.Rows.Add();
							string imageName = string.Format("{0}.jpg", remoteCall.RemotInterface.Get_SerialNumber(2));
							pictureGrid.Rows[rowIndex].Cells["idCol"].Value = pictureGrid.RowCount;
							pictureGrid.Rows[rowIndex].Cells["pictureNameCol"].Value = string.Format("图片{0}", pictureGrid.RowCount);
							pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = imageName;
							pictureGrid.Rows[rowIndex].Cells["uploadStateCol"].Value = "正在上传";
							pictureGrid.Rows[rowIndex].Cells["filePathCol"].Value = fileName;
							_fileNames.Add(fileName);
							_serverFileName.Add(imageName, pictureGrid.Rows[rowIndex]);
						}
					}
					SetImportBtnStatus(false);
					uploadFileWorker.RunWorkerAsync(_serverFileName);
				}
			}
			else
			{
				if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("uploading", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
				{
					uploadFileWorker.CancelAsync();
					for (int i = 0; i < _serverFileName.Count; i++)
					{
						KeyValuePair<string, DataGridViewRow> item = _serverFileName.ElementAt(i);
						 string fileName = item.Value.Cells["filePathCol"].Value != null ?
							item.Value.Cells["filePathCol"].Value.ToString() : string.Empty;
						if (!string.IsNullOrEmpty(fileName))
						{
							if (_fileNames.Contains(fileName))
								_fileNames.Remove(fileName);
							if (pictureGrid.Rows.Contains(item.Value))
								pictureGrid.Rows.Remove(item.Value);
						}
					}

					SetImportBtnStatus(true);
				}
			}
		}

		/// <summary>
		/// 删除事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDeleteBtnClick(object sender, EventArgs e)
		{
			if (pictureGrid.CurrentRow != null)
			{
				if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete2", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
				{
					string imageName = pictureGrid.CurrentRow.Cells["imageNameCol"].Value != null ? 
						pictureGrid.CurrentRow.Cells["imageNameCol"].Value.ToString() : string.Empty;
					if (!string.IsNullOrEmpty(imageName))
					{
						ImageCache imageCache = new ImageCache();
						imageCache.DeleteImageCache(_uploadFolder, imageName);
						SortedList sqlParameters = new SortedList();
						SortedList imageItem = new SortedList();
						sqlParameters.Add(1, imageItem);
						imageItem.Add(1, OrderHelper.GetUploadType());
						imageItem.Add(2, imageName);
						CnasRemotCall remoteCall = new CnasRemotCall();
						string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image_delete003", sqlParameters);
						int result =remoteCall.RemotInterface.UPDataList("HCS_image_delete003", sqlParameters);
						if (result > 0)
						{
							pictureGrid.Rows.Remove(pictureGrid.CurrentRow);
						}
					}
					else
					{
						pictureGrid.Rows.Remove(pictureGrid.CurrentRow);
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("removedata", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// 保存事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnConfirmBtnClick(object sender, EventArgs e)
		{
			if (uploadFileWorker.IsBusy)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("uploading", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string fileNameArran = string.Empty;
			foreach (DataGridViewRow item in pictureGrid.Rows)
			{
				string fileName = Convert.ToString(item.Cells["imageNameCol"].Value);
				fileNameArran += fileName + "','";
				if (!SaveFiles.ContainsKey(fileName))
				{
					SaveFiles.Add(fileName, BatchNum);
				}
			}
			if (!string.IsNullOrEmpty(fileNameArran))
			{
				fileNameArran = fileNameArran.Substring(0, fileNameArran.Length - "','".Length);
				CnasRemotCall remoteCall = new CnasRemotCall();
				SortedList sqlParameters = new SortedList();
				SortedList par_sqlParameters=new SortedList();
				par_sqlParameters.Add(1, 1);//state
				par_sqlParameters.Add(2, OrderHelper.GetUploadType());//type
				par_sqlParameters.Add(3, fileNameArran);//dataurl arrange
				sqlParameters.Add(1, par_sqlParameters);
				string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image_up002", sqlParameters);
				int insertResult = remoteCall.RemotInterface.UPDataList("HCS_image_up002", sqlParameters);
			}
			Close();
		}

		private void OnCancelBtnClick(object sender, EventArgs e)
		{
			OnFormClosed();
		}

		/// <summary>
		/// 选择事件更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			if (pictureGrid.CurrentRow != null )
			{
				if (pictureGrid.CurrentRow.Cells["imageCol"].Value != null&&pictureGrid.CurrentRow.Cells["imageCol"].Value is Image)
				{
					Image image = pictureGrid.CurrentRow.Cells["imageCol"].Value as Image;
					picturePreview.Images = new List<Image>() { image };
				}
				else
				{
					string fileName = Convert.ToString(pictureGrid.CurrentRow.Cells["imageNameCol"].Value);
					ImageCache imageCache = new ImageCache();
					Image image = imageCache.GetImageByFolderNameFileName(_uploadFolder, fileName);
					picturePreview.Images = new List<Image>() { image };
				}
			}
		}

		/// <summary>
		/// 上传事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUploadingEvent(object sender, DoWorkEventArgs e)
		{
			if (!string.IsNullOrEmpty(_uploadFolder) && e.Argument != null  && e.Argument is Dictionary<string, DataGridViewRow>)
			{
				Dictionary<string, DataGridViewRow> serverFileName = e.Argument as Dictionary<string, DataGridViewRow>;
				ImageCache imageCache = new ImageCache();
				CnasRemotCall remoteCall = new CnasRemotCall();

				for (int i = 0; i < serverFileName.Count; i++)
				{
					KeyValuePair<string, DataGridViewRow> item = serverFileName.ElementAt(i);
					string fileName = item.Value.Cells["filePathCol"].Value != null ?
						item.Value.Cells["filePathCol"].Value.ToString() : string.Empty;
					string imageName = item.Value.Cells["imageNameCol"].Value != null ?
						item.Value.Cells["imageNameCol"].Value.ToString() : string.Empty;
					bool upLoadResult = false;
					if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(imageName)
						&& File.Exists(fileName))
					{
						Bitmap image = new System.Drawing.Bitmap(fileName);
						item.Value.Cells["imageCol"].Value = image;
						using (MemoryStream memStream = new MemoryStream())
						{
							//update the file to remote machine.
							image.Save(memStream, ImageFormat.Jpeg);
							upLoadResult = imageCache.SaveImageCache(_uploadFolder, item.Key, memStream);

							//Save the data in db.

							if (upLoadResult)
							{
								if (!string.IsNullOrEmpty(imageName))
								{
									SortedList sqlParameters = new SortedList();
									SortedList imageItem = new SortedList();
									sqlParameters.Add(1, imageItem);
									imageItem.Add(1, OrderHelper.GetUploadType());
									imageItem.Add(2, _objectId);
									imageItem.Add(3, BatchNum);
									imageItem.Add(4, imageName);
									imageItem.Add(5, "8");
									string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image-data-add001", sqlParameters);
									int insertResult = remoteCall.RemotInterface.UPDataList("HCS_image-data-add001", sqlParameters);
									upLoadResult = insertResult > 0 && upLoadResult;
								}

								if (upLoadResult)
								{
									serverFileName.Remove(item.Key);
									i--;
								}
							}
							else
							{
								if (_fileNames.Contains(fileName))
								{
									_fileNames.Remove(fileName);
								}
							}
						}

						uploadFileWorker.ReportProgress(upLoadResult ? 1 : 0, item);
					}
				}
			}
		}

		/// <summary>
		/// 长传图片进度
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState != null && e.UserState is KeyValuePair<string, DataGridViewRow>)
			{
				KeyValuePair<string, DataGridViewRow> reportItem =(KeyValuePair<string, DataGridViewRow>)e.UserState;
				if (pictureGrid.Rows.Contains(reportItem.Value))
				{
					reportItem.Value.Cells["uploadStateCol"].Value = e.ProgressPercentage == 1 ? "上传完成" : "上传失败";
					reportItem.Value.Cells["statusCol"].Value = e.ProgressPercentage;
					if (reportItem.Value.Cells["imageCol"].Value != null && reportItem.Value.Cells["imageCol"].Value is Image)
					{
						Image image = reportItem.Value.Cells["imageCol"].Value as Image;
						picturePreview.Images = new List<Image>() { image };
					}
				}
			}
		}

		/// <summary>
		/// 上传时更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUploaded(object sender, RunWorkerCompletedEventArgs e)
		{
			SetImportBtnStatus(true);
		}

		/// <summary>
		/// 窗口取消关闭 时删除所有上传文件记录
		/// </summary>
		private void OnFormClosed()
		{
			//如果后台线程还在处理,则停止
			if(uploadFileWorker.IsBusy)
			{
				uploadFileWorker.CancelAsync();
			}
			if (MessageBox.Show("本次上传的图片将删除..如果要保存则确认.", "信息提示", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return;
			}
			SaveFiles = new Dictionary<string, string>();
			string tempCode = _imageMode != 3 ? BatchNum : BarCode;
			foreach (DataGridViewRow item in pictureGrid.Rows)
			{
				string imageName = item.Cells["imageNameCol"].Value != null ?
						item.Cells["imageNameCol"].Value.ToString() : string.Empty;
				if (!string.IsNullOrEmpty(imageName)&&!_oldFiles.ContainsKey(imageName))
				{
					ImageCache imageCache = new ImageCache();
					imageCache.DeleteImageCache(_uploadFolder, imageName);
					SortedList sqlParameters = new SortedList();
					SortedList imageItem = new SortedList();
					sqlParameters.Add(1, imageItem);
					imageItem.Add(1, OrderHelper.GetUploadType());//type
					imageItem.Add(2, imageName);//data_url
					CnasRemotCall remoteCall = new CnasRemotCall();
					string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image_delete003", sqlParameters);
					int result = remoteCall.RemotInterface.UPDataList("HCS_image_delete003", sqlParameters);
				}
				if(_oldFiles.ContainsKey(imageName))
				{
					SaveFiles.Add(imageName, tempCode);
				}
			}
			Close();
		}

		/// <summary>
		/// 重新上传
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReLoadClick(object sender, EventArgs e)
		{
			if (pictureGrid.CurrentRow != null)
			{
				pictureGrid.CurrentRow.Cells["uploadStateCol"].Value = "正在上传";
				ImageCache imageCache = new ImageCache();
				CnasRemotCall remoteCall = new CnasRemotCall();
				string fileName = pictureGrid.CurrentRow.Cells["filePathCol"].Value != null ?
						pictureGrid.CurrentRow.Cells["filePathCol"].Value.ToString() : string.Empty;
				string imageName = pictureGrid.CurrentRow.Cells["imageNameCol"].Value != null ?
					pictureGrid.CurrentRow.Cells["imageNameCol"].Value.ToString() : string.Empty;
				bool upLoadResult = false;
				if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(imageName)
					&& File.Exists(fileName))
				{
					Bitmap image = new System.Drawing.Bitmap(fileName);
					pictureGrid.CurrentRow.Cells["imageCol"].Value = image;
					using (MemoryStream memStream = new MemoryStream())
					{
						//update the file to remote machine.
						image.Save(memStream, ImageFormat.Jpeg);
						upLoadResult = imageCache.SaveImageCache(_uploadFolder, imageName, memStream);
					}

					//Save the data in db.
					if (upLoadResult)
					{
						if (!string.IsNullOrEmpty(imageName))
						{
							SortedList sqlParameters = new SortedList();
							SortedList imageItem = new SortedList();
							sqlParameters.Add(1, imageItem);
							imageItem.Add(1, OrderHelper.GetUploadType());
							imageItem.Add(2, _objectId);
							imageItem.Add(3, BarCode);
							imageItem.Add(4, imageName);
							imageItem.Add(5, "8");
							string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image-data-add001", sqlParameters);
							int insertResult = remoteCall.RemotInterface.UPDataList("HCS_image-data-add001", sqlParameters);
							upLoadResult = insertResult > 0 && upLoadResult;
						}
					}
					pictureGrid.CurrentRow.Cells["uploadStateCol"].Value = upLoadResult ? "上传完成" : "上传失败";
					pictureGrid.CurrentRow.Cells["statusCol"].Value = upLoadResult ? 1 : 0;
					if (pictureGrid.CurrentRow.Cells["imageCol"].Value != null && pictureGrid.CurrentRow.Cells["imageCol"].Value is Image)
					{
						picturePreview.Images = new List<Image>() { image };
					}
				}
			}
		}

		private void OnContextMenuOpening(object sender, CancelEventArgs e)
		{
			if (pictureGrid.CurrentRow != null)
			{
				reloadBtn.Enabled = (pictureGrid.CurrentRow.Cells["statusCol"].Value != null && (int)pictureGrid.CurrentRow.Cells["statusCol"].Value == 0);
			}
			contextDeleteBtn.Enabled = pictureGrid.CurrentRow != null;
		}

		/// <summary>
		/// 关闭窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeBtn_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 加载已经上传的图片
		/// </summary>
		/// <param name="barCode"></param>
		private void LoadData(string barCode)
		{
			CnasRemotCall remoteCall = new CnasRemotCall();
			SortedList sqlParameters = new SortedList();
			sqlParameters.Add(1, 1);//state
			sqlParameters.Add(2, OrderHelper.GetUploadType());//type
			sqlParameters.Add(3, barCode);//dataurl arrange
			string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-image-sec003", sqlParameters);
			DataTable dgv_Data = remoteCall.RemotInterface.SelectData("HCS-image-sec003", sqlParameters);
			if(dgv_Data!=null&&dgv_Data.Rows.Count>0)
			{
				for(int i=0;i<dgv_Data.Rows.Count;i++)
				{
					int rowIndex = pictureGrid.Rows.Add();
					string imageName = Convert.ToString(dgv_Data.Rows[rowIndex]["data_url"]);
					pictureGrid.Rows[rowIndex].Cells["idCol"].Value = pictureGrid.RowCount;
					pictureGrid.Rows[rowIndex].Cells["pictureNameCol"].Value = string.Format("图片{0}", pictureGrid.RowCount);
					pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = imageName;//data_url
					pictureGrid.Rows[rowIndex].Cells["uploadStateCol"].Value = "上传完成";
					if(!_oldFiles.ContainsKey(imageName))
					{
						_oldFiles.Add(imageName, barCode);
					}
				}
				pictureGrid.ClearSelection();
			}
		}
	}
}