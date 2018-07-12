using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;
using System.IO;
using System.Drawing.Imaging;


namespace Cnas.wns.CnasHCSSystemUC
{
	public partial class HCSSM_user_new : TemplateForm
	{
		private SortedList sl_type = new SortedList();
		private SortedList sl_user = new SortedList();
		private SortedList sl_location = new SortedList();
		private SortedList sl_customer = new SortedList();//客户集合
		private SortedList sl_department = new SortedList();//部门集合
		DataTable DTlocation = null;
		DataTable DTdepartment = null;
		SortedList Image = null;
		private string Strselectid = "";
		//如果是修改，则记录用户名称
		private string UserName = "";

		//用于记录原图片名称
		string imageName = "";





		public HCSSM_user_new(SortedList SLdata, SortedList slusertype)
		{
			InitializeComponent();
			pic_userimg.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "people", EnumImageType.PNG);
			but_Cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
			but_OK.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
			//this.Font = new Font(this.Font.FontFamily, 11);
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--创建用户";
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));

			this.tb_cssd.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString() + "-->" + CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//string ww = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-use-location-sec001", null);
			//DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec001", null);
			//if (DTlocation != null)
			//{
			//	int ii = DTlocation.Rows.Count;
			//	if (ii <= 0) return;
			//	for (int i = 0; i < ii; i++)
			//	{
			//		if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
			//		{
			//			sl_location.Add(DTlocation.Rows[i]["id"].ToString(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
			//			cb_location.Items.Add(DTlocation.Rows[i]["u_uname"].ToString().Trim());
			//		}
			//	}
			//}



			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-customer-sec002", null);//部门
			if (getdt != null)
			{
				int ii = getdt.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null && getdt.Rows[i]["bar_code"].ToString().Trim() != null)
					{
						sl_customer.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["cu_name"].ToString().Trim());
						cb_customer.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
					}
				}
			}

			if (slusertype != null)
			{
				for (int i = 0; i < slusertype.Count; i++)
				{
					cb_usertype.Items.Add(slusertype.GetKey(i).ToString().Trim() + "：" + slusertype.GetByIndex(i).ToString().Trim());
				}
			}
			sl_user = SLdata;
			if (SLdata != null)
			{
				this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--修改用户";
				//lb_info.Text = "用户-修改";
				Strselectid = SLdata["id"] == null ? string.Empty : SLdata["id"].ToString();
				this.tb_name.Text = SLdata["user_name"] == null ? string.Empty : SLdata["user_name"].ToString();
				UserName = SLdata["user_name"] == null ? string.Empty : SLdata["user_name"].ToString();
				this.tb_code.Text = SLdata["user_bcode"] == null ? string.Empty : SLdata["user_bcode"].ToString();
				this.tb_eid.Text = SLdata["user_eid"] == null ? string.Empty : SLdata["user_eid"].ToString();
				this.tb_nick.Text = SLdata["user_nick"] == null ? string.Empty : SLdata["user_nick"].ToString();
				//this.tb_pwd.Text = SLdata["user_pwd"].ToString();
				this.cb_sex.Text = SLdata["sex"] == null ? string.Empty : SLdata["sex"].ToString();
				this.tb_age.Text = SLdata["age"] == null ? string.Empty : SLdata["age"].ToString();
				this.cb_customer.Text = SLdata["customer_id"] == null ? string.Empty : SLdata["customer_id"].ToString();

				cb_customer_SelectedIndexChanged(cb_customer, null);
				this.cb_department.Text = SLdata["department_id"] == null ? string.Empty : SLdata["department_id"].ToString();
				this.cb_location.Text = SLdata["location_id"] == null ? string.Empty : sl_location[SLdata["location_id"]].ToString();
				ImageCache imageCache = new ImageCache();


				if (SLdata.ContainsKey("pic") && SLdata["pic"] != null && !string.IsNullOrEmpty(SLdata["pic"].ToString()))
				{

					Image picViewImage = imageCache.GetImageByFolderNameFileName(userImageFolder, SLdata["pic"].ToString());
					if (picViewImage == null)
					{
						pic_userimg.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "people", EnumImageType.PNG);
					}
					else
					{
						System.Drawing.Image aa = picViewImage.GetThumbnailImage(80, 85, null, IntPtr.Zero);
						pic_userimg.Image = aa;
						//pictureName = SLdata["pic"].ToString();


						imageName = SLdata["pic"].ToString();
					}
				}
				else
				{
					pic_userimg.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "people", EnumImageType.PNG);
				}
				cb_usertype.Text = SLdata["user_type"].ToString() + "：" + slusertype[SLdata["user_type"]].ToString();
				passwordWarningLbl.Visible = false;
			}
		}

		private void but_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void but_OK_Click(object sender, EventArgs e)
		{
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList customerid=new SortedList();
			customerid.Add(1, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
				DataTable User=reCnasRemotCall.RemotInterface.SelectData("HCS-user-sec0011",customerid);
			if (string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_name.Text.Trim())
				|| string.IsNullOrEmpty(tb_nick.Text) || string.IsNullOrEmpty(tb_nick.Text.Trim())
				|| string.IsNullOrEmpty(cb_sex.Text) || string.IsNullOrEmpty(cb_sex.Text.Trim())
				|| string.IsNullOrEmpty(cb_usertype.Text) || string.IsNullOrEmpty(cb_usertype.Text.Trim()))
			{
				MessageBox.Show("对不起！请仔细查看填写内容！！！！");
				return;
			}

			if (string.IsNullOrEmpty(cb_location.Text) || string.IsNullOrEmpty(cb_location.Text.Trim()))
			{
				MessageBox.Show("请分配使用地点。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (string.IsNullOrEmpty(cb_customer.Text) || string.IsNullOrEmpty(cb_customer.Text.Trim()))
			{
				MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("fillcustomer", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (string.IsNullOrEmpty(cb_department.Text) || string.IsNullOrEmpty(cb_department.Text.Trim()))
			{
				MessageBox.Show("请选择部门。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}



			if (sl_user == null)//insert data
			{
				if (string.IsNullOrEmpty(tb_pwd.Text) || string.IsNullOrEmpty(tb_pwd.Text.Trim()))
				{
					MessageBox.Show("请填写密码。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}


				
				  if (User != null)
                    {
                        int ii = User.Rows.Count;
                        if (ii > 0)
                        {
                            for (int i = 0; i < ii; i++)
                            {
                                if (User.Rows[i]["user_name"].ToString().Trim() != null)
                                {
                                    if (tb_name.Text.Trim().ToString() == User.Rows[i]["user_name"].ToString().Trim())
                                    {
                                        MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "用户登录名" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
				//if (UserBaseHelper.UserInfoByUserName(tb_name.Text.Trim()) != null)//判断是否同名
				//{
				//	MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("usernameRepetition", EnumPromptMessage.warning), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//	return;
				//}
				SortedList sltmp = new SortedList();
				SortedList sltmp01 = new SortedList();
				sltmp01.Add(1, tb_name.Text.Trim());
				sltmp01.Add(2, tb_code.Text.Trim());
				sltmp01.Add(3, tb_eid.Text.Trim());
				sltmp01.Add(4, tb_nick.Text.Trim());
				sltmp01.Add(5, CnasClientMethods.GetMD5Hash(tb_pwd.Text.Trim()));
				sltmp01.Add(6, cb_sex.Text.Trim());
				sltmp01.Add(7, tb_age.Text.Trim());
				sltmp01.Add(8, CnasBaseData.SystemID);
				sltmp01.Add(9, cb_usertype.Text.Substring(0, 1));
				sltmp01.Add(10, sl_location.GetKey(sl_location.IndexOfValue(cb_location.Text.Trim())).ToString());
				sltmp01.Add(11, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
				sltmp01.Add(12, sl_department.GetKey(sl_department.IndexOfValue(cb_department.Text.Trim())).ToString());
				sltmp01.Add(13, pictureName);
				sltmp01.Add(14, tb_name.Text.Trim());
				sltmp.Add(1, sltmp01);
				
				string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-userdata-add001", sltmp, null);
				int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-userdata-add001", sltmp, null);
				if (recint > -1)
				{
					MessageBox.Show("恭喜你，增加用户成功。");
					UploadUserImage();
					this.Close();
				}
			}
			else// update data        
			{
				//判断用户是否有修改用户名称
				if (tb_name.Text.Trim() != UserName)
				{
					if (User != null)
					{
						int ii = User.Rows.Count;
						if (ii > 0)
						{
							for (int i = 0; i < ii; i++)
							{
								if (User.Rows[i]["user_name"].ToString().Trim() != null)
								{
									if (tb_name.Text.Trim().ToString() == User.Rows[i]["user_name"].ToString().Trim())
									{
										MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("namerepetition", EnumPromptMessage.warning, new string[] { "用户登录名" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
										return;
									}
								}
							}
						}
					}
				}
				
				//update ca_user set user_name='?', user_eid='?',user_nick='?',user_pwd='?',sex='?',age='?',user_type=?,mod_date=now() where id=?;
				SortedList sltmp = new SortedList();
				SortedList sltmp01 = new SortedList();
				int recint = -1;
				if (tb_pwd.Text.Trim() == "")//不需要修改密码
				{
					sltmp01.Add(1, tb_name.Text.Trim());
					sltmp01.Add(2, tb_eid.Text.Trim());
					sltmp01.Add(3, tb_nick.Text.Trim());
					sltmp01.Add(4, cb_sex.Text.Trim());
					sltmp01.Add(5, tb_age.Text.Trim());
					sltmp01.Add(6, cb_usertype.Text.Substring(0, 1));
					sltmp01.Add(7, sl_location.GetKey(sl_location.IndexOfValue(cb_location.Text.Trim())).ToString());
					sltmp01.Add(8, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
					sltmp01.Add(9, sl_department.GetKey(sl_department.IndexOfValue(cb_department.Text.Trim())).ToString());
					sltmp01.Add(10, pictureName);
					sltmp01.Add(11, Strselectid);
					sltmp.Add(1, sltmp01);
					//CnasRemotCall reCnasRemotCall = new CnasRemotCall();
					//string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-userdata-up001", sltmp, null);
					recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-userdata-up002", sltmp, null);
				}
				else  //需要修改密码
				{
					if (tb_pwd.Text.Trim().Length < 4)
					{
						MessageBox.Show("对不起！用户密码必须大于四位。");
						return;
					}
					sltmp01.Add(1, tb_name.Text.Trim());
					sltmp01.Add(2, tb_eid.Text.Trim());
					sltmp01.Add(3, tb_nick.Text.Trim());
					sltmp01.Add(4, CnasClientMethods.GetMD5Hash(tb_pwd.Text.Trim()));
					sltmp01.Add(5, cb_sex.Text.Trim());
					sltmp01.Add(6, tb_age.Text.Trim());
					sltmp01.Add(7, cb_usertype.Text.Substring(0, 1));
					sltmp01.Add(8, sl_location.GetKey(sl_location.IndexOfValue(cb_location.Text.Trim())).ToString());
					sltmp01.Add(9, sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text.Trim())).ToString());
					sltmp01.Add(10, sl_department.GetKey(sl_department.IndexOfValue(cb_department.Text.Trim())).ToString());
					sltmp01.Add(11, pictureName);
					sltmp01.Add(12, Strselectid);
					sltmp.Add(1, sltmp01);
					//string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-userdata-up001", sltmp, null);
					recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-userdata-up001", sltmp, null);
				}
				if (recint > -1)
				{
					MessageBox.Show("恭喜你，修改用户成功。");
					UploadUserImage();
					this.Close();
				}
			}
		}
		/// <summary>
		/// 上传图片
		/// </summary>
		private void UploadUserImage()
		{
			MemoryStream memStream = new MemoryStream();
			ImageCache imageCache = new ImageCache();
			//拍照上传
			if (cameraTool != null && cameraTool.BitmapData != null && isChangeImage)
			{
				cameraTool.BitmapData.Save(memStream, ImageFormat.Jpeg);
				imageCache.SaveImageCache(userImageFolder, pictureName, memStream);
				memStream.Dispose();
				memStream.Close();
			}
			else
				//导入上传
				if (open_file.FileName != null && pictureName != "")
				{
					pic_userimg.Image.Save(memStream, ImageFormat.Jpeg);
					imageCache.SaveImageCache(userImageFolder, pictureName, memStream);
					memStream.Dispose();
					memStream.Close();
				}

			if (imageName != "")
			{
				imageCache.DeleteImageCache(userImageFolder, imageName);
			}
		}

		private string pictureName = string.Empty;
		private string userImageFolder = @"user/";
		private Cnas.wns.CnasCameraUC.ControlCameraTools cameraTool = null;
		private bool isChangeImage = false;

		/// <summary>
		/// 拍照上传图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void but_scan_Click(object sender, EventArgs e)
		{
			isChangeImage = true;
			cameraTool = new Cnas.wns.CnasCameraUC.ControlCameraTools();
			if (cameraTool.ShowDialog() == DialogResult.OK)
			{

				System.Drawing.Image aa = cameraTool.BitmapData.GetThumbnailImage(80, 85, null, IntPtr.Zero);
				pic_userimg.Image = aa;
				ImageCache imageCache = new ImageCache();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string guid = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				pictureName = string.Format("{0}.jpg", guid);
				imageCache.DeleteImageCache(userImageFolder, pictureName);
			}
		}

		public void cb_customer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
		{
			this.cb_department.Items.Clear();
			this.cb_location.Items.Clear();
			sl_department.Clear();
			sl_location.Clear();
			string str = sl_customer.GetKey(sl_customer.IndexOfValue(cb_customer.Text)).ToString();//获取键，即cu_id
			SortedList sl_barcode = new SortedList();
			sl_barcode.Add(1, str);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-department-sec001", sl_barcode);//部门
			if (getdt != null)
			{
				int ii = getdt.Rows.Count;
				if (ii <= 0) return;
				for (int i = 0; i < ii; i++)
				{
					if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null)
					{
						sl_department.Add(getdt.Rows[i]["id"].ToString().Trim(), getdt.Rows[i]["ca_name"].ToString().Trim());
						this.cb_department.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
					}
				}
				DTlocation = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec0010", sl_barcode);
				if (DTlocation != null)
				{
					int aa = DTlocation.Rows.Count;
					if (aa <= 0) return;
					for (int i = 0; i < aa; i++)
					{
						if (DTlocation.Rows[i]["id"].ToString() != null && DTlocation.Rows[i]["u_uname"].ToString().Trim() != null)
						{
							sl_location.Add(DTlocation.Rows[i]["id"].ToString(), DTlocation.Rows[i]["u_uname"].ToString().Trim());
							cb_location.Items.Add(DTlocation.Rows[i]["u_uname"].ToString().Trim());
						}
					}
				}
			}
		}


		/// <summary>
		/// 导入图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void but_import_Click(object sender, EventArgs e)
		{
			open_file.Multiselect = false;
			open_file.Filter = "png图片文件|*.png|jpg图片文件|*.jpg";
			if (open_file.ShowDialog() == DialogResult.OK)
			{
				//验证用户是否选择了多张文件
				if (open_file.FileNames.Length > 1) return;

				pic_userimg.Image = new Bitmap(open_file.FileName);

				ImageCache imageCache = new ImageCache();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();

				string guid = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				pictureName = string.Format("{0}.jpg", guid);
				imageCache.DeleteImageCache(userImageFolder, pictureName);
			}


		}

		private void spc_main_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
