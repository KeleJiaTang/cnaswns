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
using System.Threading;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_device_result_add : MetroForm
	{
		/// <summary>
		/// 1. 灭菌器结果监测， 2 清洗机结果监测, 3 器械包结果监测
		/// </summary>
		public int ResultMode { get;set; }
		public string BatchNum { get; set; }
		public string BarCode { get; set; }
		public UserBase OperationUser { get; set; }
		private string _objectId { get; set; }
		private List<string> _fileNames = new List<string>();
		private SortedList Data { get; set; }
		private string _uploadFolder = string.Empty;
		private string _imageNamePrefix = string.Empty;
		private Dictionary<string, DataGridViewRow> _serverFileName = new Dictionary<string, DataGridViewRow>();

		private bool _isInsertResult = true;

		public HCSWF_device_result_add()
		{
			InitializeComponent();
			pictureGrid.Font = machineTxt.Font;
			InitializeButtonImage();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public HCSWF_device_result_add(SortedList data, int resultMode)
		{
			InitializeComponent();
			Data = data;
			ResultMode = resultMode;
			EUploadType eUpType = (EUploadType)GetUploadType();
			_uploadFolder = CnasUtilityTools.GetFolderName(eUpType);
			InitalizeData(data);
			InitializeButtonImage();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		}

		public void InitializeButtonImage()
		{
			cancelBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
			confirmBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			deleteBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDelete32", EnumImageType.PNG);
			photoBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mPhoto32", EnumImageType.PNG);
			SetImportBtnStatus(true);
		}

		private void InitalizeCombox()
		{
			SetFunctionVisable();
			typeCbx.Items.Clear();
			if (ResultMode < 1 && ResultMode > 3)
				return;
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS-release-result-type'");
			if (data.Length > 0 )
			{
				foreach (DataRow item in data)
				{
					string key = item["key_code"].ToString();
					string value = item["value_code"].ToString();
					if (key.StartsWith(ResultMode.ToString()) || (ResultMode == 3 && key.StartsWith("1")))
					{
						KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
						typeCbx.Items.Add(cbxItem);
						if (Data != null && Data.ContainsKey("release_type") && key.Equals(Data["release_type"].ToString()))
						{
							int index = typeCbx.Items.IndexOf(cbxItem);
							typeCbx.SelectedIndex = index;
							typeCbx.Enabled = false;
						}
					}
				}

				if (typeCbx.SelectedIndex < 0 && typeCbx.Items.Count > 0)
				{
					typeCbx.SelectedIndex = 0;
				}
			}
		}

		private void InitalizeResultCombox()
		{
			resultCbx.Items.Clear();
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS-release-result'");
			if (data.Length > 0)
			{
				foreach (DataRow item in data)
				{
					string key = item["key_code"].ToString();
					string value = item["value_code"].ToString();

					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					resultCbx.Items.Add(cbxItem);
				}
				resultCbx.SelectedIndex = 0;
			}
		}

		private void OnFormLoaded(object sender, EventArgs e)
		{

			InitalizeResultCombox();
			InitalizeCombox();

			if (!string.IsNullOrEmpty(_objectId))
				InitalizeData();
		}

		private void RefreshImageGrid()
		{
			pictureGrid.Rows.Clear();
			picturePreview.Images = new List<Image>();
			SortedList condition = new SortedList();
			condition.Add(1, BarCode);
			condition.Add(2, _imageNamePrefix);
			CnasRemotCall remoteCall = new CnasRemotCall();
			#if DEBUG
			string resultSQL = remoteCall.RemotInterface.CheckSelectData("HCS-image-data-sec001", condition);
			#endif

			DataTable data = remoteCall.RemotInterface.SelectData("HCS-image-data-sec001", condition);
			if (data != null && data.Rows.Count > 0)
			{
				foreach (DataRow row in data.Rows)
				{
					int rowIndex = pictureGrid.Rows.Add();
					pictureGrid.Rows[rowIndex].Cells["idCol"].Value = pictureGrid.RowCount;
					pictureGrid.Rows[rowIndex].Cells["pictureNameCol"].Value = string.Format("图片{0}", pictureGrid.RowCount);
					if (data.Columns.Contains("data_url"))
						pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = row["data_url"];
					pictureGrid.Rows[rowIndex].Cells["uploadStateCol"].Value = string.Empty;
					if (data.Columns.Contains("id"))
						pictureGrid.Rows[rowIndex].Cells["imageIdCol"].Value = row["id"];
					pictureGrid.Rows[rowIndex].Cells["imageStateCol"].Value = row["state"];
					//if (addNewImage.ImageData01 != null)
					//	pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = imageName;
					//pictureGrid.Rows[rowIndex].Cells["imageCol"].Value = addNewImage.PrictureView.Image;
					//pictureGrid.Rows[rowIndex].Cells["uploadStateCol"].Value = "上传完成";
				}

				OnSelectionChanged(pictureGrid, null);
			}

		}

		private void SetImportBtnStatus(bool isImport)
		{
			string tileImageName = isImport ? "mImport32" : "mCancelImport32";
			string tileText = isImport ? "导 入 " : "停 止 ";
			importBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", tileImageName, EnumImageType.PNG);
			importBtn.Text = tileText;
		}

		private void InitalizeData()
		{
			if (!string.IsNullOrEmpty(BarCode) && ResultMode > 0)
			{
				string sql = string.Empty;
				SortedList condition = new SortedList();
				condition.Add(1, BarCode);
				condition.Add(2, BatchNum);
				if (ResultMode == 1)
				{
					sql = "";
				}
				else if (ResultMode == 2)
				{
					sql = "";
					
				}
				else
				{
					sql = "";
				}
				

				CnasRemotCall remoteCall = new CnasRemotCall();
				string resultSQL = remoteCall.RemotInterface.CheckSelectData(sql, condition);
				DataTable data = remoteCall.RemotInterface.SelectData(sql, condition);
				if (data != null && data.Rows.Count > 0)
				{
					if (data.Columns.Contains("dev_name") && !(data.Rows[0]["dev_name"] is DBNull))
						machineTxt.Text = data.Rows[0]["dev_name"].ToString();
					//if (data.Columns.Contains("pro_name") && !(data.Rows[0]["pro_name"] is DBNull))
					//	programTxt.Text = data.Rows[0]["pro_name"].ToString();
					if (data.Columns.Contains("batch_num") && !(data.Rows[0]["batch_num"] is DBNull))
						batchNumTxt.Text = data.Rows[0]["batch_num"].ToString();
					if (data.Columns.Contains("set_name") && !(data.Rows[0]["set_name"] is DBNull))
						setNameTxt.Text = data.Rows[0]["set_name"].ToString();
					if (data.Columns.Contains("set_priorty") && !(data.Rows[0]["set_priorty"] is DBNull))
						setPriortyTxt.Text = data.Rows[0]["set_priorty"].ToString();
				}
			}
		}

		private void InitalizeData(SortedList data)
		{
			if (data != null)
			{
				if (data.ContainsKey("dev_name"))
					machineTxt.Text = data["dev_name"].ToString();
				//if (data.ContainsKey("pro_name"))
				//	programTxt.Text = data["pro_name"].ToString();
				if (data.ContainsKey("batch_num"))
				{
					batchNumTxt.Text = data["batch_num"].ToString();
					BatchNum = batchNumTxt.Text;
					_imageNamePrefix = string.Format("BatchNum_{0}_", BatchNum); 
				}
				if (data.ContainsKey("set_name"))
					setNameTxt.Text = data["set_name"].ToString();
				if (data.ContainsKey("set_priorty"))
					setPriortyTxt.Text = data["set_priorty"].ToString();
				if (data.ContainsKey("object_id"))
					_objectId = data["object_id"].ToString();
				if (data.ContainsKey("bar_code"))
					BarCode = data["bar_code"].ToString();
			}
		}

		private void SetFunctionVisable()
		{
			bool isSetFunctionVisable = ResultMode == 3;
			setNameLbl.Visible = isSetFunctionVisable;
			setNameTxt.Visible = isSetFunctionVisable;
			setPriortyLbl.Visible = isSetFunctionVisable;
			setPriortyTxt.Visible = isSetFunctionVisable;
		}

		private void OnPhotoBtnClick(object sender, EventArgs e)
		{
			SortedList sortedList = new SortedList();
			sortedList.Add("type", GetUploadType());
			sortedList.Add("pack_id", _objectId);
			sortedList.Add("pack_barcode", BarCode);

			HCSCM_set_image addNewImage = new HCSCM_set_image(sortedList);
			//获取一个值，指是否在Windows任务栏中显示窗体。
			addNewImage.ShowInTaskbar = false;
			if (addNewImage.ShowDialog() == DialogResult.OK)
			{
				string imageName = string.Format("{0}{1}.jpg", _imageNamePrefix, addNewImage.ImageData01.Name);
				int rowIndex = pictureGrid.Rows.Add();
				pictureGrid.Rows[rowIndex].Cells["idCol"].Value = pictureGrid.RowCount;
				pictureGrid.Rows[rowIndex].Cells["pictureNameCol"].Value = string.Format("图片{0}", pictureGrid.RowCount);
				if (addNewImage.ImageData01 != null)
					pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = imageName;
				pictureGrid.Rows[rowIndex].Cells["imageCol"].Value = addNewImage.PrictureView.Image;
				pictureGrid.Rows[rowIndex].Cells["uploadStateCol"].Value = "上传完成";
				pictureGrid.Rows[rowIndex].Cells["imageStateCol"].Value = 8;
				picturePreview.Images = new List<Image>() { addNewImage.PrictureView.Image };
				SortedList sqlParameters = new SortedList();
				SortedList imageItem = new SortedList();
				sqlParameters.Add(1, imageItem);
				imageItem.Add(1, imageName);
				imageItem.Add(2, string.Format("{0}.jpg",addNewImage.ImageData01.Name));
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image_up001", sqlParameters);
				int result = remoteCall.RemotInterface.UPDataList("HCS_image_up001", sqlParameters);
			}
		}

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
							//string imageName = string.Format("{0}{1}.jpg",_imageNamePrefix, remoteCall.RemotInterface.Get_SerialNumber(2));
							pictureGrid.Rows[rowIndex].Cells["idCol"].Value = pictureGrid.RowCount;
							pictureGrid.Rows[rowIndex].Cells["pictureNameCol"].Value = string.Format("图片{0}", pictureGrid.RowCount);
							pictureGrid.Rows[rowIndex].Cells["imageNameCol"].Value = string.Format("{0}{1}", _imageNamePrefix, imageName);
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

		private bool IsExistedImage(Image validateImage)
		{
			bool isExisted = false;
			if (pictureGrid.Rows != null)
			{
				foreach (DataGridViewRow item in pictureGrid.Rows)
				{
					if (item.Cells["imageCol"].Value != null && item.Cells["imageCol"].Value is Image)
					{
						Image image = item.Cells["imageCol"].Value as Image;
						if (CnasUtilityTools.IsSameImage(image, validateImage))
						{
							isExisted = true;
							break;
						}
					}
				}
			}

			return isExisted;
		}

		private void OnDeleteBtnClick(object sender, EventArgs e)
		{
			if (pictureGrid.CurrentRow != null)
			{
				if (MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("choicedelete2", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
				{
					string imageName = pictureGrid.CurrentRow.Cells["imageNameCol"].Value != null ? 
						pictureGrid.CurrentRow.Cells["imageNameCol"].Value.ToString() : string.Empty;
					string imageId = pictureGrid.CurrentRow.Cells["imageIdCol"].Value != null ?
						pictureGrid.CurrentRow.Cells["imageIdCol"].Value.ToString() : string.Empty;
					if (!string.IsNullOrEmpty(imageName))
					{
						ImageCache imageCache = new ImageCache();
						imageCache.DeleteImageCache(_uploadFolder, imageName.Contains(_imageNamePrefix) ? imageName.Substring(_imageNamePrefix.Length) : imageName);
						SortedList sqlParameters = new SortedList();
						SortedList imageItem = new SortedList();
						sqlParameters.Add(1, imageItem);
						imageItem.Add(1, imageName);
						string sql = string.IsNullOrEmpty(imageId) ? "HCS_image_delete001" : "HCS_image_delete002";
						CnasRemotCall remoteCall = new CnasRemotCall();
						string testSql = remoteCall.RemotInterface.CheckUPDataList(sql, sqlParameters);
						int result = remoteCall.RemotInterface.UPDataList(sql, sqlParameters);
						if (result > 0)
						{
							pictureGrid.Rows.Remove(pictureGrid.CurrentRow);
						}
					}
					else
					{
						pictureGrid.Rows.Remove(pictureGrid.CurrentRow);
					}
					if (pictureGrid.RowCount == 0)
					{
						picturePreview.Images.Clear();
						picturePreview.SelectImage = null;
					}
				}
			}
			else
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("removedata", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnConfirmBtnClick(object sender, EventArgs e)
		{
			if (uploadFileWorker.IsBusy)
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("uploading", EnumPromptMessage.warning), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			SortedList sqlParameters = new SortedList();
			SortedList imageItems = new SortedList();
			sqlParameters.Add(2, imageItems);
			int i = 1;
			foreach (DataGridViewRow item in pictureGrid.Rows)
			{
				
				SortedList image = new SortedList();
				imageItems.Add(imageItems.Count + 1, image);
				image.Add(1, BatchNum);
				image.Add(2, BarCode);
				image.Add(3, 1);
				image.Add(4, i);
				image.Add(5, item.Cells["imageNameCol"].Value != null ? item.Cells["imageNameCol"].Value.ToString() : string.Empty);
				i++;
			}
			if (_isInsertResult)
			{
				SortedList insertList = new SortedList();
				sqlParameters.Add(1, insertList);
				SortedList insertData = new SortedList();
				insertList.Add(1, insertData);
				insertData.Add(1, _objectId);
				insertData.Add(2, BarCode);
				insertData.Add(3, ResultMode);
				insertData.Add(4, BatchNum);
				insertData.Add(5, (typeCbx.SelectedItem != null && typeCbx.SelectedItem is KeyValuePair<string, string>) ?
					((KeyValuePair<string, string>)typeCbx.SelectedItem).Key : string.Empty);
				insertData.Add(6, OperationUser != null ? OperationUser.UserID : CnasBaseData.UserBaseInfo.UserID);
				insertData.Add(7, remarkTxt.Text);
				insertData.Add(8, "1");
				insertData.Add(9, (resultCbx.SelectedItem != null && resultCbx.SelectedItem is KeyValuePair<string, string>) ?
					((KeyValuePair<string, string>)resultCbx.SelectedItem).Key : "1");
			}
			else
			{
				SortedList updateList = new SortedList();
				sqlParameters.Add(3, updateList);
				SortedList updateData = new SortedList();
				updateList.Add(1, updateData);
				updateData.Add(1, remarkTxt.Text);
				updateData.Add(2, (resultCbx.SelectedItem != null && resultCbx.SelectedItem is KeyValuePair<string, string>) ?
					((KeyValuePair<string, string>)resultCbx.SelectedItem).Key : "1");
				updateData.Add(3, OperationUser != null ? OperationUser.UserID : CnasBaseData.UserBaseInfo.UserID);
				updateData.Add(4, BatchNum);
				updateData.Add(5, BarCode);
				updateData.Add(6, (typeCbx.SelectedItem != null && typeCbx.SelectedItem is KeyValuePair<string, string>) ?
					((KeyValuePair<string, string>)typeCbx.SelectedItem).Key : string.Empty);
			}


			CnasRemotCall remoteCall = new CnasRemotCall();
			string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_release_result_add001", sqlParameters);
			int sqlResult = remoteCall.RemotInterface.UPDataList("HCS_release_result_add001", sqlParameters);
			if (sqlResult > 0)
			{
				this.Close();
			}
		}

		private void OnCancelBtnClick(object sender, EventArgs e)
		{
			DeleteTempImages(_imageNamePrefix);
			Close();
		}

		private int GetUploadType()
		{
			int result = 0;
			if (ResultMode == 1)
			{
				result = (int)EUploadType.SterilizerResultMonitor;
			}
			else if (ResultMode == 2)
			{
				result = (int)EUploadType.WashingResultMonitor;
			}
			else if (ResultMode == 3)
			{
				result = (int)EUploadType.SetResultMonitor;
			}
			return result;
		}

		private void OnSelectionChanged(object sender, EventArgs e)
		{
			if (pictureGrid.CurrentRow != null)
			{
				if (pictureGrid.CurrentRow.Cells["imageCol"].Value != null && pictureGrid.CurrentRow.Cells["imageCol"].Value is Image)
				{
					Image image = pictureGrid.CurrentRow.Cells["imageCol"].Value as Image;
					picturePreview.Images = new List<Image>() { image };
				}
				else
				{
					string imageUrl = Convert.ToString(pictureGrid.CurrentRow.Cells["imageNameCol"].Value);
					if (!string.IsNullOrEmpty(imageUrl))
					{
						ImageCache imageCache = new ImageCache();
						Image image = imageCache.GetImageByFolderNameFileName(_uploadFolder, imageUrl.Contains(_imageNamePrefix) ? imageUrl.Substring(_imageNamePrefix.Length) : imageUrl);
						pictureGrid.CurrentRow.Cells["imageCol"].Value = image;
						picturePreview.Images = new List<Image>() { image };
					}
				}
			}
		}

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
									imageItem.Add(1, GetUploadType());
									imageItem.Add(2, _objectId);
									imageItem.Add(3, BarCode);
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

		private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState != null && e.UserState is KeyValuePair<string, DataGridViewRow>)
			{
				KeyValuePair<string, DataGridViewRow> reportItem =(KeyValuePair<string, DataGridViewRow>)e.UserState;
				if (pictureGrid.Rows.Contains(reportItem.Value))
				{
					reportItem.Value.Cells["uploadStateCol"].Value = e.ProgressPercentage == 1 ? "上传完成" : "上传失败";
					reportItem.Value.Cells["imageStateCol"].Value = 8;
					reportItem.Value.Cells["statusCol"].Value = e.ProgressPercentage;
					if (reportItem.Value.Cells["imageCol"].Value != null && reportItem.Value.Cells["imageCol"].Value is Image)
					{
						Image image = reportItem.Value.Cells["imageCol"].Value as Image;
						picturePreview.Images = new List<Image>() { image };
					}
				}
			}
		}

		private void OnUploaded(object sender, RunWorkerCompletedEventArgs e)
		{
			SetImportBtnStatus(true);
		}

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			foreach (DataGridViewRow item in pictureGrid.Rows)
			{
				string imageName = item.Cells["imageNameCol"].Value != null ?
						item.Cells["imageNameCol"].Value.ToString() : string.Empty;
				if (!string.IsNullOrEmpty(imageName))
				{
					ImageCache imageCache = new ImageCache();
					imageCache.DeleteImageCache(_uploadFolder, imageName);
					SortedList sqlParameters = new SortedList();
					SortedList imageItem = new SortedList();
					sqlParameters.Add(1, imageItem);
					imageItem.Add(1, imageName);
					CnasRemotCall remoteCall = new CnasRemotCall();
					string testSql = remoteCall.RemotInterface.CheckUPDataList("HCS_image_delete001", sqlParameters);
					int result = remoteCall.RemotInterface.UPDataList("HCS_image_delete001", sqlParameters);
				}
			}
		}

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
							imageItem.Add(1, GetUploadType());
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
					pictureGrid.CurrentRow.Cells["imageStateCol"].Value = 8;
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

		private void OnResultTypeSelectionChanged(object sender, EventArgs e)
		{
			string preSelectionPrefix = _imageNamePrefix;
			InitalizeResultData();
			DeleteTempImages(preSelectionPrefix);

			RefreshImageGrid();
		}

		private void DeleteTempImages(string preSelectionPrefix)
		{
			SortedList deleteImage = new SortedList();
			foreach (DataGridViewRow dataRow in pictureGrid.Rows)
			{
				string imageState = Convert.ToString(dataRow.Cells["imageStateCol"].Value);
				string imageName = Convert.ToString(dataRow.Cells["imageNameCol"].Value);
				if (imageState == "8")
				{
					deleteImage.Add(deleteImage.Count + 1, imageName);
				}
			}

			if (deleteImage != null && deleteImage.Count > 0)
			{
				System.Threading.Tasks.Task.Factory.StartNew(() =>
				{
					CnasRemotCall remoteCall = new CnasRemotCall();
					for (int i = 0; i < deleteImage.Count; i++)
					{
						ImageCache imageCache = new ImageCache();
						string imageName = Convert.ToString(deleteImage.GetByIndex(i));
						if (!string.IsNullOrEmpty(imageName))
							imageCache.DeleteImageCache(_uploadFolder, imageName.Contains(preSelectionPrefix) ? imageName.Substring(preSelectionPrefix.Length) : imageName);
					}

					SortedList sqlParameter = new SortedList();
					sqlParameter.Add(1, deleteImage);
					string deleteSQL = remoteCall.RemotInterface.CheckUPDataList("HCS_image_delete001", sqlParameter);
					remoteCall.RemotInterface.UPDataList("HCS_image_delete001", sqlParameter);
				});
			}
		}

		private void InitalizeResultData()
		{
			string typeKey = (typeCbx.SelectedItem != null && typeCbx.SelectedItem is KeyValuePair<string, string>) ?
					((KeyValuePair<string, string>)typeCbx.SelectedItem).Key : string.Empty;
			SortedList conditon = new SortedList();
			conditon.Add(1, BarCode);
			conditon.Add(2, BatchNum);
			conditon.Add(3, typeKey);
			_imageNamePrefix = string.Format("BatchNum_{0}_ResultType_{1}_", BatchNum, typeKey);
		
			CnasRemotCall remoteCall = new CnasRemotCall();
			string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-release-result-sec001", conditon);
			DataTable data = remoteCall.RemotInterface.SelectData("HCS-release-result-sec001", conditon);
			if (data != null && data.Rows.Count > 0)
			{
				string resultKey = Convert.ToString(data.Rows[0]["result"]);
				remarkTxt.Text = Convert.ToString(data.Rows[0]["remark"]);
				SetResultSelectedItem(resultKey);
				_isInsertResult = false;
			}
			else
			{
				_isInsertResult = true;
			}
		}

		private void SetResultSelectedItem(string resultKey)
		{
			if (resultCbx.Items != null && resultCbx.Items.Count > 0 && !string.IsNullOrEmpty(resultKey))
			{
				foreach (KeyValuePair<string, string> item in resultCbx.Items)
				{
					if (item.Key == resultKey)
					{
						int index = resultCbx.Items.IndexOf(item);
						resultCbx.SelectedIndex = index;
						break;
					}
				}
			}

		}
	}
}