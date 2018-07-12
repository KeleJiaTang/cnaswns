using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
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
	public partial class HCSSM_set_release_result : MetroForm
	{
		/// <summary>
		/// 结果类型
		/// </summary>
		private string _result_type = "12";
		/// <summary>
		/// 该包外标签
		/// </summary>
		private string _bcuCode=string.Empty;
		/// <summary>
		/// 默认图片
		/// </summary>
		private List<Image> _defaultImage = new List<Image>() { ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "defaultBgHor") };
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="bcu_code"></param>
		public HCSSM_set_release_result(string bcu_code)
		{
			_bcuCode = bcu_code;
			InitializeComponent();
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 设置选项值
		/// </summary>
		private void SetTypeCbxItem()
		{
			typeCbx.Items.Clear();
			DataRow[] data = CnasBaseData.SystemBaseData.Select("type_code='HCS-release-result-type'");
			if (data.Length > 0)
			{
				foreach (DataRow item in data)
				{
					string key = Convert.ToString(item["key_code"]);
					string value = Convert.ToString(item["value_code"]);
					KeyValuePair<string, string> cbxItem = new KeyValuePair<string, string>(key, value);
					typeCbx.Items.Add(cbxItem);
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

		/// <summary>
		/// 设置cobobox值
		/// </summary>
		private void SetTypeCbxValue(ComboBox cbb,string value_sel)
		{
			bool isFind=false;
			if (cbb.Items != null && cbb.Items.Count > 0)
			{
				for (int i = 0; i < cbb.Items.Count; i++)
				{
					if (cbb.Items[i] is KeyValuePair<string, string>)
					{
						KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbb.Items[i];
						if (item.Key == value_sel)
						{
							isFind = true; cbb.SelectedIndex = i;
						}
					}
				}
				if (!isFind)
					cbb.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_set_release_result_Load(object sender, EventArgs e)
		{
			InitializeButtonImage();
			SetTypeCbxItem();
			InitalizeResultCombox();
			//typeCbx.SelectedValue = _result_type;
			SetTypeCbxValue(typeCbx,_result_type);
			SortedList condition = new SortedList();
			//装载灭菌器
			string str_load_wf = CnasBaseDataHelper.Wf_SingleValue("HCS-procedure-data", "Load_sterilizer_container_wf");
			//释放灭菌器
			string str_release_wf = CnasBaseDataHelper.Wf_SingleValue("HCS-procedure-data", "Release_sterilizer_wf");
			condition.Add(1, str_load_wf);
			condition.Add(2, str_release_wf);
			condition.Add(3, _bcuCode);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec034", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec034", condition);
			if (data != null && data.Rows.Count > 0)
			{
				DataRow row = data.Rows[0];
				string str_id = Convert.ToString(row["id"]);
				string str_batchNum= Convert.ToString(row["device_runtimes"]);
				setNameTxt.Text = Convert.ToString(row["set_name"]);//包名
				setCodeTxt.Text = Convert.ToString(row["BCU_code"]);//保外标签
				machineTxt.Text = Convert.ToString(row["ca_name"]);//机器名称
				batchNumTxt.Text =str_batchNum;
				//container_code 机器码
				string match_code = Convert.ToString(row["container_code"]);
				string str_result = Convert.ToString(row["result"]); //监测结果
				remarkTxt.Text = Convert.ToString(row["remark"]);
				SetTypeCbxValue(resultCbx, str_result);
				if(!string.IsNullOrEmpty(str_batchNum))
				{
					Thread thread = new Thread(() =>
					{
						List<Image> setImages = GetImages(reCnasRemotCall, match_code, str_batchNum);
						this.Invoke(new Action(() =>
						{
							pictureBoxData.Images = setImages;
						}));
					});
					thread.Start();
				}
				else
				{
					ErrorClose();
				}
			}
			else
			{
				ErrorClose();
			}

		}

		/// <summary>
		/// 初始化按钮图片背景
		/// </summary>
		private void InitializeButtonImage()
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 关闭窗口
		/// </summary>
		private void ErrorClose()
		{
			MessageBox.Show("对不起,该包不存在生物监测详情");
			Close();
		}

		/// <summary>
		/// 获取图片
		/// </summary>
		private List<Image> GetImages(CnasRemotCall reCnasRemotCall,string match_code,string batch_num)
		{
			string tempStr = string.Format("BatchNum_{0}_", batch_num);//dataurl  前缀
			List<Image> images = new List<Image>();
			SortedList pic_condition = new SortedList();
			pic_condition.Add(1, (int)EUploadType.SterilizerResultMonitor);
			pic_condition.Add(2, 1);
			pic_condition.Add(3,match_code);
			pic_condition.Add(4, tempStr);
			string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-image-sec004", pic_condition);
			DataTable dtImageList = reCnasRemotCall.RemotInterface.SelectData("HCS-image-sec004", pic_condition);
			if (dtImageList != null && dtImageList.Rows != null && dtImageList.Rows.Count > 0)
			{
				Image image = null;
				foreach (DataRow item in dtImageList.Rows)
				{
					string fileName = "";
					image = null;
					if (item["data_url"] != null)
					{
						fileName = item["data_url"].ToString();
						fileName = fileName.Substring(tempStr.Length-1);
					}
					if (!string.IsNullOrEmpty(fileName))
					{
						ImageCache imageCache = new ImageCache();
						image = imageCache.GetImageByFolderNameFileName(CnasUtilityTools.GetFolderName(EUploadType.SetResultMonitor), fileName);
						if (image != null)
							images.Add(image);
					}
				}
				if(images==null||images.Count==0)
				{
					images = _defaultImage;
				}
			}
			else
			{
				images = _defaultImage;
			}
			return images;
		}
	}
}
