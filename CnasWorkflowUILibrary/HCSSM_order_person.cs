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
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_order_person : MetroForm
	{
		/// <summary>
		/// 订单供应商信息id
		/// </summary>
		public int Venderinfo_id;
		/// <summary>
		/// 病人id
		/// </summary>
		public int Patient_Id;
		/// <summary>
		/// 病人信息
		/// </summary>
		public SortedList PatientList=new SortedList();

		/// <summary>
		/// 模型0 新建2 OnlyView
		/// </summary>
		public int ModleType=0;

		/// <summary>
		/// 初始化
		/// </summary>
		public HCSSM_order_person()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 绑定供应商信息
		/// </summary>
		private void BingVerderInfoItem()
		{
			cbb_vender.Items.Clear();
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, 1);//state
			condition.Add(2, 1);//is_outinstrument
			string testSql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-vender-sec003", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-vender-sec003", condition);
			if(data!=null&&data.Rows.Count>0)
			{
				for(int i=0;i<data.Rows.Count;i++)
				{
					string str_Id = Convert.ToString(data.Rows[i]["id"]);
					string str_Name = Convert.ToString(data.Rows[i]["v_name"]);
					cbb_vender.Items.Add(new KeyValuePair<string, string>(str_Id, str_Name));
				}
				if(cbb_vender.Items.Count>0)
				{
					cbb_vender.SelectedIndex = 0;
				}
			}
		}

		/// <summary>
		/// 绑定性别
		/// </summary>
		private void BindSexItem()
		{
			//table方式
			DataTable d_source = new DataTable();
			DataColumn key = new DataColumn();
			key.ColumnName = "Key";
			DataColumn key_value = new DataColumn();
			key_value.ColumnName = "Key_value";
			d_source.Columns.AddRange(new DataColumn[]{key, key_value});
			d_source.Rows.Add("1","男");
			d_source.Rows.Add("2", "女");
			txt_pSex.DataSource = d_source;
			txt_pSex.DisplayMember = "Key_value";
			txt_pSex.ValueMember = "Key";
			//Dic方式
			//Dictionary<string, string> dic = new Dictionary<string, string>();
			//dic.Add("1", "男");
			//dic.Add("2", "女");
			//BindingSource bs = new BindingSource();
			//bs.DataSource = dic;
			//txt_pSex.DataSource = bs;
			//txt_pSex.DisplayMember = "Value";
			//txt_pSex.ValueMember = "Key";
			txt_pSex.SelectedIndex = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			OnSaveClick();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			OnCloseClick();
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		private void OnCloseClick()
		{
			Close();
		}

		/// <summary>
		/// 保存事件
		/// </summary>
		private void OnSaveClick()
		{
			//p Data
			string p_Number = txt_pNumber.Text.Trim();
			string p_Name = txt_pName.Text.Trim();
			string p_Sex = txt_pSex.SelectedValue.ToString();//性别
			string p_Age = txt_pAge.Text.Trim();
			string p_Operation = txt_pOperation.Text.Trim();
			string p_Doctor = txt_pDoctor.Text.Trim();
			DateTime p_OperationTime = txt_pOperationTime.Value;
			// v Data
			string v_id = string.Empty;
			string v_name = string.Empty;
			string v_packName = txt_pack.Text.Trim();
			string v_checkName = txt_check.Text.Trim();
			string v_sendName = txt_send.Text.Trim() ;
			string v_linkNum=txt_link.Text.Trim();
			DateTime v_noteDate = date_note.Value;
			DateTime v_arriveDate = date_arrive.Value;
			string v_remark = txt_remark.Text.Trim();
			if(cbb_vender.Items.Count>0)
			{
				if(cbb_vender.SelectedItem !=null &&cbb_vender.SelectedItem is KeyValuePair<string,string>)
				{
					KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbb_vender.SelectedItem;
					v_id = item.Key;
					v_name = item.Value;
				}
			}
			//start check Data
			if (string.IsNullOrEmpty(p_Number)) { MessageBox.Show("对不起,请填写住院号"); return; }
			if (string.IsNullOrEmpty(p_Name)) { MessageBox.Show("对不起,请填写病人姓名"); return; }
			if (string.IsNullOrEmpty(p_Age)) { MessageBox.Show("对不起,请填写年龄"); return; }
			int tempAge;
			if (!int.TryParse(p_Age, out tempAge)) { MessageBox.Show("对不起,年龄请填写整数"); return; }
			if (string.IsNullOrEmpty(p_Operation)) { MessageBox.Show("对不起,请填写手术名称"); return; }
			if (string.IsNullOrEmpty(p_Doctor)) { MessageBox.Show("对不起,请填写医生名称"); return; }

			if (string.IsNullOrEmpty(v_id)) { MessageBox.Show("对不起,没有外来器械供应商,请联系管理员登记"); return; }
			if (string.IsNullOrEmpty(v_packName)) { MessageBox.Show("对不起，请填写配货人"); return; }
			if (string.IsNullOrEmpty(v_checkName)) { MessageBox.Show("对不起，请填写复核人"); return; }
			if (string.IsNullOrEmpty(v_sendName)) { MessageBox.Show("对不起，请填写下送人"); return; }
			if (string.IsNullOrEmpty(v_linkNum)) { MessageBox.Show("对不起，请填写联系方式"); return; }
			//验证电话号码
			if (!OrderHelper.IsPhone(v_linkNum)) { MessageBox.Show("对不起，请填写正确的联系方式"); return; }
			//end check Data

			if (PatientList == null) PatientList = new SortedList();
			if (PatientList.ContainsKey("p_Number")) PatientList["p_Number"] = p_Number;
			else PatientList.Add("p_Number", p_Number);
			if (PatientList.ContainsKey("p_Name")) PatientList["p_Name"] = p_Name;
			else PatientList.Add("p_Name", p_Name);
			if (PatientList.ContainsKey("p_Sex")) PatientList["p_Sex"] = p_Sex;
			else PatientList.Add("p_Sex", p_Sex);
			if (PatientList.ContainsKey("p_Age")) PatientList["p_Age"] = p_Age;
			else PatientList.Add("p_Age", p_Age);
			if (PatientList.ContainsKey("p_Operation")) PatientList["p_Operation"] = p_Operation;
			else PatientList.Add("p_Operation", p_Operation);
			if (PatientList.ContainsKey("p_Doctor")) PatientList["p_Doctor"] = p_Doctor;
			else PatientList.Add("p_Doctor", p_Doctor);
			if (PatientList.ContainsKey("p_OperationTime")) PatientList["p_OperationTime"] = p_OperationTime;
			else PatientList.Add("p_OperationTime", p_OperationTime);

			SortedList condition = new SortedList();//插入
			SortedList sea_condition = new SortedList();//查询
			SortedList condition1 = new SortedList();
			SortedList condition2 = new SortedList();
			SortedList par_condition = new SortedList();
			SortedList par_condition2 = new SortedList();
			//p Datas
			par_condition.Add(1, p_Number);
			par_condition.Add(2, p_Name);
			par_condition.Add(3, p_Sex);
			par_condition.Add(4, p_Age);
			par_condition.Add(5, p_Operation);
			par_condition.Add(6, p_Doctor);
			par_condition.Add(7, p_OperationTime);
			par_condition.Add(8, 1);
			condition1.Add(1, par_condition);
			condition.Add(1, condition1);
			//v Datas
			par_condition2.Add(1,v_id);
			par_condition2.Add(2, v_name);
			par_condition2.Add(3, v_packName);
			par_condition2.Add(4, v_checkName);
			par_condition2.Add(5, v_sendName);
			par_condition2.Add(6, v_linkNum);
			par_condition2.Add(7, v_noteDate);
			par_condition2.Add(8, v_arriveDate);
			par_condition2.Add(9, v_remark);
			par_condition2.Add(10, CnasBaseData.UserID);
			condition2.Add(1, par_condition2);
			condition.Add(2, condition2);
			//
			sea_condition.Add(1, p_Number);
			sea_condition.Add(2, p_Name);
			sea_condition.Add(3, v_id);
			sea_condition.Add(4, v_packName);
			sea_condition.Add(5, v_checkName);
			sea_condition.Add(6, v_sendName);
			sea_condition.Add(7, v_linkNum);
			sea_condition.Add(8, v_noteDate);
			sea_condition.Add(9, v_arriveDate);
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			//string testsql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-specialset-person-up002", condition);
			int rect = reCnasRemotCall.RemotInterface.UPDataList("HCS-specialset-person-up002", condition);
			if(rect>0)
			{
				//string testSecData = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-person-sec002", sea_condition);
				DataTable data=reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-person-sec002", sea_condition);
				if(data!=null&&data.Rows.Count>0)
				{
					for (int i = 0; i < data.Rows.Count; i++)
					{
						string tempId = Convert.ToString(data.Rows[i]["id"]);
						string tempType = Convert.ToString(data.Rows[i]["idType"]);
						switch (tempType)
						{
							case "1": int.TryParse(tempId, out Patient_Id); break;
							case "2": int.TryParse(tempId, out Venderinfo_id); break;
							default: break;
						}
					}
				}
				else
				{
					MessageBox.Show("对不起,保存失败!");
				}
			}
			else
			{
				MessageBox.Show("对不起,保存失败!");
			}
			Close();
		}

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HCSSM_order_person_Load(object sender, EventArgs e)
		{
			InitButtonImage();
			if(ModleType==0)
			{
				BindSexItem();
				BingVerderInfoItem();
			}
			if(ModleType==2)
			{
				btnSave.Visible = false;
				InitViewData();
			}
		}

		/// <summary>
		/// 初始化图标
		/// </summary>
		private void InitButtonImage()
		{
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			btnSave.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mOK32", EnumImageType.PNG);
			btnClose.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		/// <summary>
		/// 查看数据信息加载
		/// </summary>
		private void InitViewData()
		{

			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList pCondition=new SortedList();
			pCondition.Add(1,Patient_Id);
			//string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-person-sec003", pCondition);
			DataTable pData = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-person-sec003", pCondition);
			if (pData != null && pData.Rows.Count > 0)
			{
				DataRow row = pData.Rows[0];
				//p Data
				DateTime t_Opration;
				txt_pNumber.Text = Convert.ToString(row["p_Number"]);
				txt_pName.Text = Convert.ToString(row["p_name"]);
				txt_pSex.Items.Clear();
				string str_SexType = Convert.ToString(row["p_sex"]);
				string str_SexName = string.Empty;
				switch (str_SexType)
				{
					case "1": { str_SexName = "男"; break; }
					case "2": { str_SexName = "女"; break; }
					default: break;
				}
				KeyValuePair<string, string> item = new KeyValuePair<string, string>(str_SexType, str_SexName);
				txt_pSex.Items.Add(item);
				txt_pSex.DisplayMember = "Value";
				txt_pSex.ValueMember = "Key";
				txt_pSex.SelectedIndex = 0;
				 txt_pAge.Text = Convert.ToString(row["p_age"]);
				 txt_pOperation.Text = Convert.ToString(row["p_operation"]);
				 txt_pDoctor.Text = Convert.ToString(row["p_doctor"]);
				 DateTime.TryParse(Convert.ToString(row["p_operation_date"]), out t_Opration);
				 txt_pOperationTime.Value = t_Opration;
			}
			SortedList vCondition = new SortedList();
			vCondition.Add(1, Venderinfo_id);
			//sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-specialset-venderinfo-sec001", vCondition);
			DataTable vData = reCnasRemotCall.RemotInterface.SelectData("HCS-specialset-venderinfo-sec001", vCondition);
			if (vData != null && vData.Rows.Count > 0)
			{
				// v Data
				DataRow row= vData.Rows[0];
				DateTime t_note, t_arrive;
				txt_pack.Text = Convert.ToString(row["pack_instrumentName"]);
				txt_check.Text = Convert.ToString(row["check_instrumentName"]);
				txt_send.Text = Convert.ToString(row["send_instrumentName"]);
				txt_link.Text = Convert.ToString(row["link_number"]);
				DateTime.TryParse(Convert.ToString(row["note_time"]), out t_note);
				DateTime.TryParse(Convert.ToString(row["arrive_time"]), out t_arrive);
				date_note.Value = t_note;
				date_arrive.Value = t_arrive;
				txt_remark.Text = Convert.ToString(row["remark"]);
				string str_id = Convert.ToString(row["ca_vender_id"]);
				string str_name = Convert.ToString(row["ca_vender_name"]);
				cbb_vender.Items.Clear();
				cbb_vender.Items.Add(new KeyValuePair<string, string>(str_id, str_name));
				cbb_vender.DisplayMember = "Value";
				cbb_vender.ValueMember = "Key";
				cbb_vender.SelectedIndex = 0;
			}
			//p Data
			txt_pNumber.Enabled = false;
			txt_pName.Enabled = false;
			txt_pSex.Enabled = false;
			txt_pAge.Enabled = false;
			txt_pOperation.Enabled = false;
			txt_pDoctor.Enabled = false;
			txt_pOperationTime.Enabled = false;
			// v Data
			txt_pack.Enabled = false;
			txt_check.Enabled = false;
			txt_send.Enabled = false;
			txt_link.Enabled = false;
			date_note.Enabled = false;
			date_arrive.Enabled = false;
			txt_remark.Enabled = false;
			cbb_vender.Enabled = false;
		}
	}
}
