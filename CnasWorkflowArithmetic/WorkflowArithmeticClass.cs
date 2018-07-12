using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasBaseClassClient;
using System.Xml;
using log4net;
using System.Reflection;
using MSScriptControl;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowArithmetic
{
	public class WorkflowArithmeticClass : CnasHCSWorkflowInterface
	{
		private string strVersions = "1.0.0.1";
		public ILog Logger = null;

		/// <summary>
		/// 返回结果
		/// </summary>
		private SortedList SL_recdata = new SortedList();

		/// <summary>
		/// 所有手术实体包集合
		/// </summary>
		private DataTable dtsetdata = new DataTable();

		/// <summary>
		/// 流程参数类型为1的参数
		/// </summary>
		private SortedList SL_parametertmp01 = new SortedList();//流程参数类型为1的参数
		/// <summary>
		/// 流程参数类型为2的参数
		/// </summary>
		private SortedList SL_parametertmp02 = new SortedList();//流程参数类型为2的参数
		/// <summary>
		/// 参数类型2选择时候留下的备注信息
		/// </summary>
		private SortedList SL_parametersinfo = new SortedList();//参数类型2选择时候留下的备注信息
		/// <summary>
		/// 存储当前流程信息，用于判断流程扫描条码先后允许顺序
		/// </summary>
		private SortedList SL_check = new SortedList();//存储当前流程信息，用于判断流程扫描条码先后允许顺序

		/// <summary>
		/// 当前已经扫描上的条码
		/// </summary>
		private SortedList SL_barcode = new SortedList();//当前已经扫描上的条码

		public string Load_container_wf = "", Unload_container_wf = "", Transport_container_wf = "", Cre_BCU_wf = "", Set_notincycle_wf = "", Add_setandsterilizer_count = "", Add_washing_count = "";
		public string Add_set_count = string.Empty, Check_set_expiredate_wf = string.Empty, Modify_order_wf = string.Empty, Release_sterilizer_wf = string.Empty, Accept_order_wf = string.Empty, Recyle_set_wf = string.Empty;
		public string OR_Locations = string.Empty, Use_set_wf = string.Empty, Temp_storage_wf = string.Empty, Storge_set_wf = string.Empty, CheckUserLocation_wf = string.Empty;
		public string Entry_CSSD_wf = string.Empty, Leave_CSSD_wf = string.Empty, Show_RFID_wf = string.Empty, BD_test_wf = string.Empty, Check_set_Biology_wf = string.Empty;
		public string NoTempManual_wf = "";
		private bool _allMultWF = true;
		
		private string _warningSetType = string.Empty, _sendSetWithBiology = string.Empty, _useSetWithBiology = string.Empty;

		public WorkflowArithmeticClass()
		{
			Logger = LogManager.GetLogger("CnasWNSClient");
			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList sttemp01 = new SortedList();
			sttemp01.Add(1, CnasBaseData.SystemID);
			dtsetdata = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec0020", sttemp01);
			DataRow[] configData = CnasBaseData.SystemBaseData.Select("type_code='HCS-procedure-data'");
			foreach (DataRow dr in configData)
			{
				if (dr["key_code"] != null && dr["value_code"] != null)
				{
					FieldInfo fieldInfo = this.GetType().GetField(dr["key_code"].ToString());
					if (fieldInfo != null)
						fieldInfo.SetValue(this, dr["value_code"].ToString());
				}
			}
			DataRow[] config = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings'");
			if (config != null)
			{
				foreach (DataRow item in config)
				{
					string keyCode = Convert.ToString(item["key_code"]);
					string valueCode = Convert.ToString(item["value_code"]);
					if (!string.IsNullOrEmpty(valueCode))
					{
						switch (keyCode)
						{
							case "WarningSetType":
								_warningSetType = valueCode;
								break;
							case "SendSetWithBiology":
								_sendSetWithBiology = valueCode;
								break;
							case "UseSetWithBiology":
								_useSetWithBiology = valueCode;
								break;
							case "OR_locations":
								OR_Locations = valueCode;
								break;
							default:
								break;
						}
					}
				}
			}
		}


		/// <summary>
		/// 获取算法版本号
		/// </summary>
		/// <returns></returns>
		public string GetVersions()
		{
			return strVersions;
		}

		/// <summary>
		/// 初始化返回值
		/// </summary>
		private void RefreshData()
		{
			SL_recdata.Clear();
			SL_recdata.Add("rec_result", 99);//处理结果：0-成功，其他-失败；
			SL_recdata.Add("next_pdcode", null);//处理返回值：一个值数组
			SL_recdata.Add("rec_data01", null);//处理返回值：一个值数组
			SL_recdata.Add("rec_data02", null);//处理返回值：一个值数组
			SL_recdata.Add("rec_data03", null);//处理返回值：一个值数组
		}


		/// <summary>
		/// 替换和拼装条件串
		/// </summary>
		/// <param name="str_condition">条件字符串</param>
		/// <param name="par01">条件参数01</param>
		/// <param name="par02">条件参数02</param>
		/// <returns>返回计算结果:0-通过；1-不通过；3-失败语法错误</returns>
		private int ConditionReplace(string str_condition, SortedList par01, SortedList par02)
		{
			if (par01 != null)
			{
				for (int j = 0; j < par01.Count; j++)
				{
					string str_key01 = par01.GetKey(j).ToString();
					string str_value01 = par01.GetByIndex(j).ToString();
					str_condition = str_condition.Replace("#$" + str_key01 + "$#", str_value01);
				}
			}
			if (par02 != null)
			{
				for (int j = 0; j < par02.Count; j++)
				{
					string str_key01 = par02.GetKey(j).ToString();
					string str_value01 = par02.GetByIndex(j).ToString();
					str_condition = str_condition.Replace("#$" + str_key01 + "$#", str_value01);
				}
			}

			return ComputeCondition(str_condition);
		}

		private int ComputeCondition(string condition)
		{
			int result = 0;
			condition = condition.Replace("=", "==");
			condition = condition.Replace("!==", "!=");
			condition = condition.Replace(">==", ">=");
			condition = condition.Replace("<==", "<=");
			condition = condition.Replace("and", "&&");
			condition = condition.Replace("or", "||");
			try
			{
				ScriptControl sc = new ScriptControlClass();
				sc.Language = "JavaScript";
				object objResult = sc.Eval(condition);
				if (objResult is bool)
					result = ((bool)objResult) ? 0 : 1;
			}
			catch (Exception)
			{
				result = 3;
			}

			return result;
		}

		/// <summary>
		/// 根据流程编码获取提交方式
		/// </summary>
		/// <param name="in_pdcode">流程编码</param>
		/// <returns></returns>
		private int GetSubmitType(string in_pdcode)
		{
			//Load_container_wf = "", Unload_container_wf = "", Transport_container_wf = ""
			if (Load_container_wf == "" || Unload_container_wf == "" || Transport_container_wf == "" || in_pdcode == "")
			{
				return -101;
			}
			else
			{
				//加载车、清洗、灭菌设备
				if (Load_container_wf.IndexOf(in_pdcode + ",") > -1)
				{
					return 2001;
				}

				//运输车箱
				if (Transport_container_wf.IndexOf(in_pdcode + ",") > -1)
				{
					return 2002;
				}

				//卸载车、清洗、灭菌设备
				if (Unload_container_wf.IndexOf(in_pdcode + ",") > -1)
				{
					return 2003;
				}

				//提交正常包
				return 1001;
			}
		}

		/// <summary>
		/// 构造信息数据三类参数
		/// </summary>
		/// <param name="innumber">参数位置编号</param>
		/// <param name="inbcx">参数名字</param>
		/// <param name="in_barcode">条码</param>
		/// <returns>返回三类参数集合</returns>
		private SortedList Getinfo03data(int innumber, string inbcx, string in_barcode, SortedList slindata)
		{
			if (inbcx == "BCS" || inbcx == "BCE" || inbcx == "BCU" || inbcx == "BCW" || inbcx == "BCZ" || inbcx == "BCP")
			{
				slindata.Add(inbcx + innumber.ToString(), in_barcode);
			}

			return slindata;
		}

		private void UpdateTempSetInfo(string curPdCode, int storageId, SortedList updateTempSet, DataRow setDetail)
		{
			if (Storge_set_wf.Contains(curPdCode))
			{
				if (!(setDetail["id"] is DBNull))
				{
					SortedList updateTempSetData = new SortedList();
					updateTempSet.Add(updateTempSet.Count + 1, updateTempSetData);
					updateTempSetData.Add(1, storageId);
					updateTempSetData.Add(2, setDetail["set_code"]);
				}
			}
			
		}

		private void UpdateSetInfo(string curPdCode, int storageId, SortedList updateSet, string setId, DataRow setDetail)
		{
			if (Add_set_count.Contains(curPdCode) || Storge_set_wf.Contains(curPdCode) ||
				Leave_CSSD_wf.Contains(curPdCode) || Entry_CSSD_wf.Contains(curPdCode) ||
				Use_set_wf.Contains(curPdCode) || Recyle_set_wf.Contains(curPdCode))
			{
				SortedList updateSetData = new SortedList();
				int setRuntimes = 0;
				int.TryParse(Convert.ToString(setDetail["run_times"]), out setRuntimes);
				setRuntimes = Add_set_count.Contains(curPdCode) ? setRuntimes + 1 : setRuntimes;
				string set_storgaeid02 = string.Empty;
				DateTime startCSSD =setDetail["start_cssd"] is DBNull ? DateTime.Now : Convert.ToDateTime(setDetail["start_cssd"]);

				string endCSSD = string.Empty;
				string urgentState = setDetail["urgent"] is DBNull ? "0" : setDetail["urgent"].ToString();
				if (Entry_CSSD_wf.Contains(curPdCode))
				{
					if (!(setDetail["end_cssd"] is DBNull))
					{
						startCSSD = DateTime.Now;
					}
					endCSSD = "NULL";
				}
				endCSSD = (Entry_CSSD_wf.Contains(curPdCode) || (setDetail["end_cssd"] is DBNull))
					? "NULL" : setDetail["end_cssd"].ToString();
				 

				if (Leave_CSSD_wf.Contains(curPdCode))
				{
					endCSSD = DateTime.Now.ToString();
					urgentState = "0";
				}
				if (!endCSSD.Equals("NULL"))
					endCSSD = string.Format("'{0}'", endCSSD);

				if (Storge_set_wf.Contains(curPdCode))
				{
					if (storageId > 0)
						set_storgaeid02 = storageId.ToString();
					else
					{
						if (setDetail["storage_id"] != null)
							set_storgaeid02 = setDetail["storage_id"].ToString();
					}
				}
				else
				{
					if (Use_set_wf.Contains(curPdCode) || Recyle_set_wf.Contains(curPdCode))
					{
						set_storgaeid02 = "0";
					}
					else
					{
						set_storgaeid02 = Convert.ToString(setDetail["storage_id_02"]);
						if (string.IsNullOrEmpty(set_storgaeid02))
							set_storgaeid02 = "0";
					}
				}

				updateSet.Add(updateSet.Count + 1, updateSetData);
				updateSetData.Add(1, setRuntimes);
				updateSetData.Add(2, set_storgaeid02);
				updateSetData.Add(3, startCSSD);
				updateSetData.Add(4, endCSSD);
				updateSetData.Add(5, urgentState);
				updateSetData.Add(6, setId);
			}
		}

		private DataTable GetWorkSets(string pdCode, string bccCodes)
		{
			DataTable workSet = null;
			try
			{
				bccCodes = bccCodes.TrimEnd(',');
				bccCodes = bccCodes.Replace(",","','");
				SortedList condition = new SortedList();
				condition.Add(1, pdCode);
				condition.Add(2, bccCodes);
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckSelectData("HCS-workset-sec0011", condition);
				workSet = remoteCall.RemotInterface.SelectData("HCS-workset-sec0011", condition); 
			}
			catch (Exception)
			{
			}

			return workSet;
		}

		/// <summary>
		/// 提交到下一步流程:手术包
		/// </summary>
		/// <param name="inuserid"></param>
		/// <param name="nextPds"></param>
		/// <param name="inpar01"></param>
		/// <param name="inpar02"></param>
		/// <param name="inparinfo02"></param>
		/// <returns></returns>
		private string CreateNextWorkorderSet(string inuserid, Dictionary<string, string> nextPds, SortedList inpar01, SortedList inpar02, SortedList inparinfo02, SortedList configDialogParams)
		{
			if (SL_barcode == null || SL_barcode.Count == 0)
			{
				return "异常错误，没传输值.";
			}
			else
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				#region 构造输入参数（创建新流程记录）
				int cfm_userid = 0;
				string personBarCode = string.Empty;
				if (configDialogParams != null && configDialogParams.Count > 0)
				{
					if (configDialogParams.ContainsKey("confirmUserParams"))
					{
						SortedList temp = (SortedList)configDialogParams["confirmUserParams"];
						if (temp != null && temp.Count > 0)
						{
							if (temp.ContainsKey("confirmUserId"))
							{
								Int32.TryParse(temp["confirmUserId"].ToString(), out cfm_userid);
							}
						}
					}
					if (configDialogParams.ContainsKey("personParams"))
					{
						SortedList temp = (SortedList)configDialogParams["personParams"];
						if (temp != null && temp.Count > 0)
						{
							if (temp.ContainsKey("person_barcode"))
							{
								personBarCode = Convert.ToString(temp["person_barcode"]);
							}
						}
					}
				}

				string BCSCode = string.Empty;
				int storageId = 0;

				SortedList sqlParameters = new SortedList();
				SortedList sl_main01 = new SortedList();
				SortedList sl_main02 = new SortedList();
				SortedList inpar03 = new SortedList();
				string str_bcu = "";
				string location = string.Empty;
				string bccCodes = string.Empty;
				
				for (int i = 0; i < SL_barcode.Count; i++)
				{
					string str_bcode01 = SL_barcode.GetKey(i).ToString();
					string str_bcx = str_bcode01.Substring(0, 3);
					if (str_bcx != "BCC" && str_bcx != "BCB" && str_bcx != "BCV")
					{
						inpar03 = Getinfo03data(i, str_bcx, str_bcode01, inpar03);
					}
					if (str_bcx == "BCE")
					{
						location = str_bcode01;
					}
					if (str_bcode01.Contains("BCC"))
					{
						bccCodes += string.Format("{0},", str_bcode01.Substring(str_bcode01.IndexOf("BCC"), 13));
					}
					if (str_bcx == "BCU" && str_bcode01.Length == 13)
					{
						//打包时第一次打印出BCU码:记录下BCU然后一起更新到数据库
						str_bcu = str_bcode01;
					}

					if (str_bcx == "BCS")
					{
						string bcsKey = str_bcode01;
						string bcsType = bcsKey.Substring(0, 3);
						if (bcsType.Equals("BCS"))
						{
							string[] bcsCode = bcsKey.Split(':');
							if (bcsCode.Length == 2 && !string.IsNullOrEmpty(bcsCode[1]))
							{
								int.TryParse(bcsCode[1], out storageId);
								BCSCode = bcsCode[0];
							}
							else
							{
								SortedList param = new SortedList();
								param.Add(1, bcsCode[0]);
								string sqlTest = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec005", param);
								DataTable bcsData = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec005", param);
								if (bcsData != null && bcsData.Rows.Count > 0)
								{
									if (bcsData.Columns.Contains("id") && bcsData.Rows[0]["id"] != null)
										int.TryParse(bcsData.Rows[0]["id"].ToString(), out storageId);
								}
							}
						}
					}
				}
				DataTable workSets = GetWorkSets(nextPds["currentPd"], bccCodes);
				SortedList updateSet = new SortedList();
				SortedList updateTempSet = new SortedList();
				SortedList insertWorkSets = new SortedList();
				SortedList updateWorkSets = new SortedList();
				sqlParameters.Add(1, updateWorkSets);
				sqlParameters.Add(2, insertWorkSets);
				for (int i = 0; i < SL_barcode.Count; i++)
				{
					string key = SL_barcode.GetKey(i).ToString();
					string str_bcx = key.Substring(0, 3);
					string bccCode = string.Empty;
					if (str_bcx == "BCU" && key.IndexOf(":") > 0)
					{
						//BCC码已经被打包，只有BCU在包外面
						bccCode = key.Substring(key.IndexOf("BCC"), 13);
						str_bcu = key.Substring(key.IndexOf("BCU"), 13);
						str_bcx = bccCode.Substring(0, 3);
					}
					else if (str_bcx == "BCC")
						bccCode = key;

					if (str_bcx == "BCC")
					{

						string nextPd = string.Empty;
						if (nextPds.ContainsKey(bccCode))
						{
							nextPd = nextPds[bccCode];
						}
						//else if (nextPds.ContainsKey("standantNextPd"))
						//{
						//	nextPd = nextPds["standantNextPd"];
						//}
						string str_setid = "", str_setname = "", workSetBatch = string.Empty, wfCode =string.Empty;
						SortedList sl_part01 = new SortedList();
						SortedList insertWorkSet = new SortedList();
						DataRow[] arrayDR01 = GetSetData(bccCode, workSets);
						if (arrayDR01 == null || arrayDR01.Length == 0)
							continue;
						if (arrayDR01[0]["set_id"] != null) str_setid = arrayDR01[0]["set_id"].ToString();
						if (arrayDR01[0]["ca_name"] != null) str_setname = arrayDR01[0]["ca_name"].ToString();
						if (arrayDR01[0]["batch"] != null) workSetBatch = arrayDR01[0]["batch"].ToString();
						if (arrayDR01[0]["wf_code"] != null) wfCode = arrayDR01[0]["wf_code"].ToString();
						string tempSeria = ((inpar01 != null && inpar01.Count > 0) || (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0) || inpar03.Count > 0) ? str_Seria : string.Empty;

						UpdateCurrentWorkSet(inuserid, cfm_userid.ToString(), str_bcu, tempSeria, nextPds["currentPd"], "0", string.Empty, bccCode, wfCode, updateWorkSets);
						if (!string.IsNullOrEmpty(nextPd))
							CreateNextWorkSet(nextPds["currentPd"], nextPd, location, str_setid, str_setname, inuserid, "", bccCode, str_bcu, "0", string.Empty, "0", workSetBatch, insertWorkSets);

						if (!BarCodeHelper.IsOrderSet(bccCode))
						{
							if (BarCodeHelper.IsTempSet(bccCode))
							{
								UpdateTempSetInfo(nextPds["currentPd"], storageId, updateTempSet, arrayDR01[0]);
							}
							else
							{
								UpdateSetInfo(nextPds["currentPd"], storageId, updateSet, str_setid, arrayDR01[0]);
							}
						}
					}
				}
				int int_count = 0;
				if (inpar01 != null && inpar01.Count > 0)
				{
					for (int j = 0; j < inpar01.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar01.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar01.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 1);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}

				if (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0)
				{
					for (int j = 0; j < inpar02.Count; j++)
					{
						string str_tmp10 = inpar02.GetKey(j).ToString();
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar02.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar02.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 2);//info_type
						sl_part02.Add(5, inuserid);//user_id
						if (inparinfo02[str_tmp10] == null)
						{
							sl_part02.Add(6, "");//remark
						}
						else
						{
							sl_part02.Add(6, inparinfo02[str_tmp10]);//remark
						}
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}

				if (inpar03.Count > 0)
				{
					for (int j = 0; j < inpar03.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar03.GetKey(j).ToString().Substring(0, 3));//info_name
						sl_part02.Add(3, inpar03.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 3);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}
				if (!string.IsNullOrEmpty(BCSCode))
				{
					SortedList sl_part02 = new SortedList();
					sl_part02.Add(1, str_Seria);//info_serial
					sl_part02.Add(2, BCSCode.Substring(0, 3));//info_name
					sl_part02.Add(3, BCSCode);//info_data
					sl_part02.Add(4, 3);//info_type
					sl_part02.Add(5, inuserid);//user_id
					sl_part02.Add(6, "");//remark
					sl_main02.Add(int_count, sl_part02);
					int_count++;
				}

				if (!string.IsNullOrEmpty(personBarCode))
				{
					SortedList sl_part02 = new SortedList();
					sl_part02.Add(1, str_Seria);//info_serial
					sl_part02.Add(2, "patient");//info_name
					sl_part02.Add(3, personBarCode);//info_data
					sl_part02.Add(4, 3);//info_type
					sl_part02.Add(5, inuserid);//user_id
					sl_part02.Add(6, "");//remark
					sl_main02.Add(int_count, sl_part02);
					int_count++;
				}

				#endregion

				#region  create/Update work special set info
				if (configDialogParams != null && configDialogParams.ContainsKey("workspecialList"))
				{
					SortedList workspecialList = configDialogParams["workspecialList"] as SortedList;
					SortedList updateworkSpecialList = new SortedList();
					SortedList insertworkSpecialList = new SortedList();
					for (int i = 0; i < workspecialList.Count; i++)
					{
						SortedList data = (SortedList)workspecialList.GetByIndex(i);

						if (data != null)
						{
							if (data[0].ToString() == "0")
								insertworkSpecialList.Add(i, data);
							else
								updateworkSpecialList.Add(i, data);
							data.RemoveAt(0);
						}
					}
					sqlParameters.Add(4, insertworkSpecialList);
					sqlParameters.Add(5, updateworkSpecialList);
				}
				#endregion

				//sqlParameters.Add(1, sl_main01);
				sqlParameters.Add(3, sl_main02);
				sqlParameters.Add(6, updateSet);
				sqlParameters.Add(10, updateTempSet);

				#region 提交新流程记录
				string strsql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add006", sqlParameters);
				int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add006", sqlParameters);

				if (recint > -1)
				{
					return "0";
				}
				else
				{
					return "数据库更新失败。";
				}
				#endregion
			}
		}



		/// <summary>
		/// 提交到下一步流程:装载设备
		/// </summary>
		/// <param name="inuserid"></param>
		/// <param name="inwfcode"></param>
		/// <param name="inpar01"></param>
		/// <param name="inpar02"></param>
		/// <param name="inparinfo02"></param>
		/// <returns></returns>
		private string CreateNextWorkorderLoadContainer(string inuserid, string current_pd, Dictionary<string, string> nextPds, string Containercode, SortedList inpar01, SortedList inpar02, SortedList inparinfo02, SortedList SL_DialogParamsInfo)
		{
			if (SL_barcode == null || SL_barcode.Count == 0)
			{
				return "异常错误，没传输值.";
			}
			else
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);
				#region 构造输入参数（创建新流程记录）

				SortedList sqlParameters = new SortedList();
				SortedList sl_main01 = new SortedList();
				SortedList sl_main02 = new SortedList();
				SortedList inpar03 = new SortedList();
				string str_bcu = "";
				string location = string.Empty;
				string bccCodes = string.Empty;

				for (int i = 0; i < SL_barcode.Count; i++)
				{
					string str_bcode01 = SL_barcode.GetKey(i).ToString();
					string str_bcx = str_bcode01.Substring(0, 3);
					if (str_bcx != "BCC" && str_bcx != "BCB" && str_bcx != "BCV")
					{
						inpar03 = Getinfo03data(i, str_bcx, str_bcode01, inpar03);
					}
					if (str_bcx == "BCE")
					{
						location = str_bcode01;
					}
					if (str_bcode01.Contains("BCC"))
					{
						bccCodes += string.Format("{0},", str_bcode01.Substring(str_bcode01.IndexOf("BCC"), 13));
					}
					if (str_bcx == "BCU" && str_bcode01.Length == 13)
					{
						//打包时第一次打印出BCU码:记录下BCU然后一起更新到数据库
						str_bcu = str_bcode01;
					}
				}
				DataTable workSets = GetWorkSets(nextPds["currentPd"], bccCodes);
				SortedList deviceParams = SL_DialogParamsInfo.ContainsKey("deviceParams") ? (SortedList)SL_DialogParamsInfo["deviceParams"] : new SortedList();
				string deviceRuntimes = "1";
				if (deviceParams != null && deviceParams.ContainsKey("device_runtimes"))
					deviceRuntimes = deviceParams["device_runtimes"].ToString();
				SortedList updateSet = new SortedList();
				SortedList updateTempSet = new SortedList();
				SortedList insertWorkSets = new SortedList();
				SortedList updateWorkSets = new SortedList();
				sqlParameters.Add(1, updateWorkSets);
				sqlParameters.Add(2, insertWorkSets);
				for (int i = 0; i < SL_barcode.Count; i++)
				{
					string key = SL_barcode.GetKey(i).ToString();
					string bccCode = string.Empty;
					string str_bcx = key.Substring(0, 3);
					if (str_bcx == "BCU" && key.IndexOf(":") > 0)
					{
						//BCC码已经被打包，只有BCU在包外面
						bccCode = key.Substring(key.IndexOf("BCC"), 13);
						str_bcu = key.Substring(key.IndexOf("BCU"), 13);
						str_bcx = bccCode.Substring(0, 3);
					}
					else if (str_bcx == "BCC")
						bccCode = key;

					if (str_bcx == "BCC")
					{
						#region hcs_work_set data

						string nextPd = string.Empty;
						if (nextPds.ContainsKey(bccCode))
						{
							nextPd = nextPds[bccCode];
						}
						//else if (nextPds.ContainsKey("standantNextPd"))
						//{
						//	nextPd = nextPds["standantNextPd"];
						//}

						string str_setid = "", str_setname = "", set_runtimes = "1", set_storgaeid02 = "", workSetBatch = string.Empty, wfCode = string.Empty;
						//SortedList sl_part01 = new SortedList();
						SortedList insertWorkSet = new SortedList();
						DataRow[] arrayDR01 = GetSetData(bccCode, workSets);
						if (arrayDR01 == null || arrayDR01.Length == 0)
							continue;
						if (arrayDR01[0]["set_id"] != null) str_setid = arrayDR01[0]["set_id"].ToString();
						if (arrayDR01[0]["ca_name"] != null) str_setname = arrayDR01[0]["ca_name"].ToString();
						if (arrayDR01[0]["run_times"] != null) set_runtimes = arrayDR01[0]["run_times"].ToString();
						if (arrayDR01[0]["storage_id_02"] != null) set_storgaeid02 = arrayDR01[0]["storage_id_02"].ToString();
						if (arrayDR01[0]["batch"] != null) workSetBatch = arrayDR01[0]["batch"].ToString();
						if (arrayDR01[0]["wf_code"] != null) wfCode = arrayDR01[0]["wf_code"].ToString();
						int cfm_userid = 0;
						int storgaeid02 = 0;
						int.TryParse(set_storgaeid02, out storgaeid02);

						if (!BarCodeHelper.IsOrderSet(bccCode))
						{
							if (BarCodeHelper.IsTempSet(bccCode))
							{
								UpdateTempSetInfo(nextPds["currentPd"], storgaeid02, updateTempSet, arrayDR01[0]);
							}
							else
							{
								UpdateSetInfo(nextPds["currentPd"], storgaeid02, updateSet, str_setid, arrayDR01[0]);
							}
						}

						string tempSeria = ((inpar01 != null && inpar01.Count > 0) || (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0) || inpar03.Count > 0) ? str_Seria : string.Empty;
	
						UpdateCurrentWorkSet(inuserid, cfm_userid.ToString(), str_bcu, tempSeria, nextPds["currentPd"], deviceRuntimes, Containercode, bccCode, wfCode, updateWorkSets);
						if (!string.IsNullOrEmpty(nextPd))
 							CreateNextWorkSet(nextPds["currentPd"], nextPd, location, str_setid, str_setname, inuserid, "", bccCode, str_bcu, "0", Containercode, deviceRuntimes, workSetBatch, insertWorkSets);

						#endregion
					}
					else if (str_bcx == "BCD" || str_bcx == "BCW" || str_bcx == "BCZ")
					{
						SortedList device_part = new SortedList();
						SortedList device = new SortedList();
						device.Add(1, device_part);
						if (deviceParams.ContainsKey("device_runtimes"))
						{
							device_part.Add(1, deviceParams["device_runtimes"]);
							device_part.Add(2, key);
						}
						if (Add_washing_count.Contains(current_pd))
						{
							sqlParameters.Add(8, device);
						}
						else if (Add_setandsterilizer_count.Contains(current_pd))
						{
							sqlParameters.Add(9, device);
						}
					}
				}

				if (nextPds.ContainsKey("currentPd") && nextPds.ContainsKey("standantNextPd") && BD_test_wf.Contains(nextPds["currentPd"]))
				{
					CreateNextWorkSet(nextPds["currentPd"], nextPds["currentPd"], location, "0", "BD测试包", inuserid, str_Seria, BarCodeHelper.BDTestSetCode, BarCodeHelper.BDTestBCUCode, "8", Containercode, deviceRuntimes, "", insertWorkSets);
					CreateNextWorkSet(nextPds["currentPd"], nextPds["standantNextPd"], location, "0", "BD测试包", inuserid, string.Empty, BarCodeHelper.BDTestSetCode, BarCodeHelper.BDTestBCUCode, "0", Containercode, deviceRuntimes, "", insertWorkSets);
				}

				#region parameter type 1 --hcs_work_set_info data
				int int_count = 0;
				if (inpar01 != null && inpar01.Count > 0)
				{
					for (int j = 0; j < inpar01.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar01.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar01.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 1);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}
				#endregion

				#region parameter type 2 --hcs_work_set_info data
				if (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0)
				{
					for (int j = 0; j < inpar02.Count; j++)
					{
						string str_tmp10 = inpar02.GetKey(j).ToString();
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar02.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar02.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 2);//info_type
						sl_part02.Add(5, inuserid);//user_id
						if (inparinfo02[str_tmp10] == null)
						{
							sl_part02.Add(6, "");//remark
						}
						else
						{
							sl_part02.Add(6, inparinfo02[str_tmp10]);//remark
						}
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}
				#endregion

				#region parameter type 3 --hcs_work_set_info data
				if (inpar03.Count > 0)
				{
					for (int j = 0; j < inpar03.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar03.GetKey(j).ToString().Substring(0, 3));//info_name
						sl_part02.Add(3, inpar03.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 3);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}
				#endregion
				sqlParameters.Add(3, sl_main02);
				sqlParameters.Add(6, updateSet);
				sqlParameters.Add(10, updateTempSet);

				#endregion

				#region 提交新流程记录
				string strsql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add006", sqlParameters);
				int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add006", sqlParameters);

				#region		 Unused
				//int recint = -1;
				//if (sl_main02.Count == 0)
				//{                    
				//    string strrec01 = reCnasRemotCall.RemotInterface.CheckUPData(3, "HCS-workset-add002", sl_main01, null);
				//    recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-workset-add002", sl_main01, null);
				//}
				//else
				//{
				//    recint = reCnasRemotCall.RemotInterface.UPData(3, "HCS-workset-add001", sl_main01, sl_main02);
				//}

				#endregion

				if (recint > -1)
				{
					return "0";
				}
				else
				{
					return "数据库更新失败。";
				}
				#endregion
			}
		}

		/// <summary>
		/// 提交到下一步流程:运输设备
		/// </summary>
		/// <param name="inuserid"></param>
		/// <param name="inwfcode"></param>
		/// <param name="inpar01"></param>
		/// <param name="inpar02"></param>
		/// <param name="inparinfo02"></param>
		/// <returns></returns>
		private string CreateNextWorkorderTransportContainer(string inuserid, string incurcode, Dictionary<string, string> nextPds, string Containercode, SortedList inpar01, SortedList inpar02, SortedList inparinfo02, SortedList confirmDialogParameters, DataTable containerWorkSet)
		{
			if (SL_barcode == null || SL_barcode.Count == 0)
			{
				return "异常错误，没传输值.";
			}
			else
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);

				#region 获取车、清洗、灭菌设备内所有包集合
				//DataTable containerWorkSet;
				//string workSetResult = GetWorkSetByContainerCode(incurcode, Containercode, out containerWorkSet);
				//if (!string.IsNullOrEmpty(workSetResult))
				//	return workSetResult;

				SortedList condition = new SortedList();
				condition.Add(1, Containercode);
				condition.Add(2, CnasBaseData.SystemID);
				condition.Add(3, 1);
				DataTable transportDevice = reCnasRemotCall.RemotInterface.SelectData("HCS-transport-device-sec003", condition);
				int device_runtimes = 0;
				if (transportDevice == null || transportDevice.Rows.Count == 0)
				{
					return "运输车不存在，请扫描别的运输车";
				}
				else
				{
					if (transportDevice.Rows[0]["run_times"] != null)
						int.TryParse(transportDevice.Rows[0]["run_times"].ToString(), out device_runtimes);
				}
				#endregion

				#region 构造输入参数（创建新流程记录）

				SortedList sqlParameters = new SortedList();
				SortedList sl_main01 = new SortedList();
				SortedList sl_main02 = new SortedList();
				SortedList inpar03 = new SortedList();
				string location = string.Empty;
				for (int i = 0; i < SL_barcode.Count; i++)
				{
					string str_bcode01 = SL_barcode.GetKey(i).ToString();
					string str_bcx = str_bcode01.Substring(0, 3);
					if (str_bcx != "BCC" && str_bcx != "BCB" && str_bcx != "BCV")
					{
						inpar03 = Getinfo03data(i, str_bcx, str_bcode01, inpar03);
					}
					if (str_bcx == "BCE")
					{
						location = str_bcode01;
					}
				}
				int cfm_userid = 0;
				string str_bcu = "";
				SortedList updateSet = new SortedList();
				SortedList insertWorkSets = new SortedList();
				SortedList updateWorkSets = new SortedList();
				sqlParameters.Add(1, updateWorkSets);
				sqlParameters.Add(2, insertWorkSets);
				sqlParameters.Add(6, updateSet);
				for (int i = 0; i < containerWorkSet.Rows.Count; i++)
				{
					string str_setid = "", str_setname = "", bccCode = "", workSetBatch = string.Empty, wfCode = string.Empty;
					if (containerWorkSet.Rows[i]["set_id"] != null) str_setid = containerWorkSet.Rows[i]["set_id"].ToString();
					if (containerWorkSet.Rows[i]["set_code"] != null) bccCode = containerWorkSet.Rows[i]["set_code"].ToString();
					if (containerWorkSet.Rows[i]["set_name"] != null) str_setname = containerWorkSet.Rows[i]["set_name"].ToString();
					if (containerWorkSet.Rows[i]["BCU_Code"] != null) str_bcu = containerWorkSet.Rows[i]["BCU_Code"].ToString();
					if (containerWorkSet.Rows[i]["batch"] != null) workSetBatch = containerWorkSet.Rows[i]["batch"].ToString();
					if (containerWorkSet.Rows[i]["wf_code"] != null) wfCode = containerWorkSet.Rows[i]["wf_code"].ToString();
					string nextPd = string.Empty;
					//string nextPdItem = nextPds.Keys.FirstOrDefault(p => p.Contains(bccCode));
					if (nextPds.ContainsKey(bccCode))
					{
						nextPd = nextPds[bccCode];
					}
					//else if (nextPds.ContainsKey("standantNextPd"))
					//{
					//	nextPd = nextPds["standantNextPd"];
					//}

					SortedList sl_part01 = new SortedList();
					SortedList insertWorkSet = new SortedList();
					string tempSeria = ((inpar01 != null && inpar01.Count > 0) || (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0) || inpar03.Count > 0) ? str_Seria : string.Empty;

					UpdateCurrentWorkSet(inuserid, cfm_userid.ToString(), str_bcu, tempSeria, nextPds["currentPd"], device_runtimes.ToString(), Containercode, bccCode, wfCode, updateWorkSets);

					if (!string.IsNullOrEmpty(nextPd))
						CreateNextWorkSet(nextPds["currentPd"], nextPd, location, str_setid, str_setname, inuserid, "", bccCode, str_bcu, "0", Containercode, "0", workSetBatch, insertWorkSets);
					if (!BarCodeHelper.IsTempSet(bccCode) && !BarCodeHelper.IsOrderSet(bccCode))
					{
						DataRow[] setDetails = GetSetData(bccCode);
						if (setDetails.Length == 0)
							continue;
						UpdateSetInfo(nextPds["currentPd"], 0, updateSet, str_setid, setDetails[0]);
					}
				}
				int int_count = 0;
				if (inpar01 != null && inpar01.Count > 0)
				{
					for (int j = 0; j < inpar01.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar01.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar01.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 1);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}

				if (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0)
				{
					for (int j = 0; j < inpar02.Count; j++)
					{
						string str_tmp10 = inpar02.GetKey(j).ToString();
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar02.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar02.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 2);//info_type
						sl_part02.Add(5, inuserid);//user_id
						if (inparinfo02[str_tmp10] == null)
						{
							sl_part02.Add(6, "");//remark
						}
						else
						{
							sl_part02.Add(6, inparinfo02[str_tmp10]);//remark
						}
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}
				if (inpar03.Count > 0)
				{
					for (int j = 0; j < inpar03.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar03.GetKey(j).ToString().Substring(0, 3));//info_name
						sl_part02.Add(3, inpar03.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 3);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(int_count, sl_part02);
						int_count++;
					}
				}


				#endregion

				#region 提交新流程记录
				//sqlParameters.Add(1, sl_main01);
				sqlParameters.Add(3, sl_main02);
				if (Transport_container_wf.Contains(incurcode))
				{
					SortedList deviceParams = new SortedList();
					SortedList device = new SortedList();
					device.Add(1, Containercode);
					deviceParams.Add(1, device);
					sqlParameters.Add(7, deviceParams);
				}
				string strsql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add006", sqlParameters);
				int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add006", sqlParameters);

				if (recint > -1)
				{
					return "0";
				}
				else
				{
					return "数据库更新失败。";
				}
				#endregion
			}
		}

		private string GetWorkSetByContainerCode(string currentWF, string containercode, out DataTable dtworktmp)
		{
			SortedList condition = new SortedList();
			condition.Add(1, currentWF);
			condition.Add(2, containercode);
			condition.Add(3, 0);
			CnasRemotCall remoteCall = new CnasRemotCall();
			#if DEBUG
			string aaa = remoteCall.RemotInterface.CheckSelectData("HCS-workset-sec003", condition);
			#endif
			dtworktmp = remoteCall.RemotInterface.SelectData("HCS-workset-sec003", condition);
			if (dtworktmp == null || dtworktmp.Rows.Count == 0)
			{
				return "异常错误，该设备没有任何包.";
			}
			else return string.Empty;
		}

		/// <summary>
		/// 提交到下一步流程:卸载设备
		/// </summary>
		/// <param name="inuserid"></param>
		/// <param name="inwfcode"></param>
		/// <param name="inpar01"></param>
		/// <param name="inpar02"></param>
		/// <param name="inparinfo02"></param>
		/// <returns></returns>
		private string CreateNextWorkorderUnLoadContainer(string inuserid, string incurcode, Dictionary<string, string> nextPds, string Containercode, SortedList inpar01, SortedList inpar02, SortedList inparinfo02, SortedList configDialogParams, DataTable containWorkSet)
		{
			if (SL_barcode == null || SL_barcode.Count == 0)
			{
				return "异常错误，没传输值.";
			}
			else
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				string str_Seria = reCnasRemotCall.RemotInterface.Get_SerialNumber(1);

				#region 构造输入参数（创建新流程记录）

				SortedList sl_main01 = new SortedList();
				SortedList sl_main02 = new SortedList();
				SortedList inpar03 = new SortedList();
				string location = string.Empty;
				for (int i = 0; i < SL_barcode.Count; i++)
				{
					string str_bcode01 = SL_barcode.GetKey(i).ToString();
					string str_bcx = str_bcode01.Substring(0, 3);
					if (str_bcx != "BCC" && str_bcx != "BCB" && str_bcx != "BCV")
					{
						inpar03 = Getinfo03data(i, str_bcx, str_bcode01, inpar03);
					}
					if (str_bcx == "BCE")
					{
						location = str_bcode01;
					}
				}
				int cfm_userid = 0;
				string str_bcu = "";
				SortedList sqlParameters = new SortedList();
				SortedList updateSet = new SortedList();
				SortedList insertWorkSets = new SortedList();
				SortedList updateWorkSets = new SortedList();
				sqlParameters.Add(1, updateWorkSets);
				sqlParameters.Add(2, insertWorkSets);
				sqlParameters.Add(3, sl_main02);
				sqlParameters.Add(6, updateSet);
				for (int i = 0; i < containWorkSet.Rows.Count; i++)
				{
					string str_setid = "", str_setname = "", bccCode = "", workSetBatch = string.Empty, devRuntimes = "0", wfCode = string.Empty;
					SortedList insertWorkSet = new SortedList();
					if (containWorkSet.Rows[i]["set_id"] != null) str_setid = containWorkSet.Rows[i]["set_id"].ToString();
					if (containWorkSet.Rows[i]["set_code"] != null) bccCode = containWorkSet.Rows[i]["set_code"].ToString();
					if (containWorkSet.Rows[i]["set_name"] != null) str_setname = containWorkSet.Rows[i]["set_name"].ToString();
					if (containWorkSet.Rows[i]["BCU_Code"] != null) str_bcu = containWorkSet.Rows[i]["BCU_Code"].ToString();
					if (containWorkSet.Rows[i]["batch"] != null) workSetBatch = containWorkSet.Rows[i]["batch"].ToString();
					if (containWorkSet.Rows[i]["wf_code"] != null) wfCode = containWorkSet.Rows[i]["wf_code"].ToString();
					if (containWorkSet.Columns.Contains("device_runtimes") && !(containWorkSet.Rows[i]["device_runtimes"] is DBNull))
					{
						devRuntimes = containWorkSet.Rows[i]["device_runtimes"].ToString();
					}
					string nextPd = string.Empty;
					//string nextPdItem = nextPds.Keys.FirstOrDefault(p => p.Contains(bccCode));
					if (nextPds.ContainsKey(bccCode))
					{
						nextPd = nextPds[bccCode];
					}
					string tempSeria = ((inpar01 != null && inpar01.Count > 0) || (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0) || inpar03.Count > 0) ? str_Seria : string.Empty;

					SortedList updateList = UpdateCurrentWorkSet(inuserid, cfm_userid.ToString(), str_bcu, tempSeria, nextPds["currentPd"], devRuntimes, Containercode, bccCode, wfCode, updateWorkSets);

					if (bccCode != BarCodeHelper.BDTestSetCode && !string.IsNullOrEmpty(nextPd))
						CreateNextWorkSet(nextPds["currentPd"], nextPd, location, str_setid, str_setname, inuserid, "", bccCode, str_bcu, "0", string.Empty, "0", workSetBatch, insertWorkSets);
					else
					{
						bool bDTestResult = true;
						if (configDialogParams != null && configDialogParams.Count > 0)
						{
							if (configDialogParams.ContainsKey("BDTestResult"))
							{
								SortedList temp = (SortedList)configDialogParams["BDTestResult"];
								if (temp != null && temp.Count > 0)
								{
									if (temp.ContainsKey("BDTestResult"))
									{
										Boolean.TryParse(temp["BDTestResult"].ToString(), out bDTestResult);
									}
								}
							}
						}

						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, "BDTest_resullt");//info_name
						sl_part02.Add(3, bDTestResult.ToString());//info_data
						sl_part02.Add(4, 3);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						updateList[4] = str_Seria;
						sl_main02.Add(sl_main02.Count + 1, sl_part02);
					}

					if (!BarCodeHelper.IsTempSet(bccCode) && !BarCodeHelper.IsOrderSet(bccCode))
					{
						DataRow[] setDetails = GetSetData(bccCode);
						if (setDetails.Length == 0)
							continue;
						UpdateSetInfo(nextPds["currentPd"], 0, updateSet, str_setid, setDetails[0]);
					}
				}
				if (inpar01 != null && inpar01.Count > 0)
				{
					for (int j = 0; j < inpar01.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar01.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar01.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 1);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(sl_main02.Count +1, sl_part02);
					}
				}

				if (inpar02 != null && inpar02.Count > 0 && inparinfo02.Count > 0)
				{
					for (int j = 0; j < inpar02.Count; j++)
					{
						string str_tmp10 = inpar02.GetKey(j).ToString();
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar02.GetKey(j).ToString());//info_name
						sl_part02.Add(3, inpar02.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 2);//info_type
						sl_part02.Add(5, inuserid);//user_id
						if (inparinfo02[str_tmp10] == null)
						{
							sl_part02.Add(6, "");//remark
						}
						else
						{
							sl_part02.Add(6, inparinfo02[str_tmp10]);//remark
						}
						sl_main02.Add(sl_main02.Count + 1, sl_part02);
					}
				}

				if (inpar03.Count > 0)
				{
					for (int j = 0; j < inpar03.Count; j++)
					{
						SortedList sl_part02 = new SortedList();
						sl_part02.Add(1, str_Seria);//info_serial
						sl_part02.Add(2, inpar03.GetKey(j).ToString().Substring(0, 3));//info_name
						sl_part02.Add(3, inpar03.GetByIndex(j).ToString());//info_data
						sl_part02.Add(4, 3);//info_type
						sl_part02.Add(5, inuserid);//user_id
						sl_part02.Add(6, "");//remark
						sl_main02.Add(sl_main02.Count + 1, sl_part02);
					}
				}


				#endregion

				#region 提交新流程记录
				string strsql = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-workset-add006", sqlParameters);
				int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-workset-add006", sqlParameters);

				if (recint > -1)
				{
					return "0";
				}
				else
				{
					return "数据库更新失败。";
				}
				#endregion
			}
		}

		private SortedList UpdateCurrentWorkSet(string operationUser, string confirmUser, string bcuCode, string infoSeria, string currentPd, string deviceRuntimes, string containerCode, string bccCode, string mappedPdCode, SortedList updateWorkSets)
		{
			SortedList updateWorkSet = new SortedList();
			updateWorkSet.Add(1, operationUser);//user_id
			updateWorkSet.Add(2, confirmUser);//cfm_userid
			updateWorkSet.Add(3, bcuCode);
			updateWorkSet.Add(4, infoSeria);
			updateWorkSet.Add(5, currentPd);
			updateWorkSet.Add(6, deviceRuntimes);	  //device_runtimes
			updateWorkSet.Add(7, containerCode);		 //container_code
			updateWorkSet.Add(8, bccCode);//set_code
			updateWorkSet.Add(9, mappedPdCode);//set_code
			updateWorkSets = updateWorkSets ?? new SortedList();
			updateWorkSets.Add(updateWorkSets.Count + 1, updateWorkSet);

			return updateWorkSet;
		}

		private void CreateNextWorkSet(string currentPd, string nextPd, string location, string setid, string name, string userId, string infoSerial, string bccCode, string bcuCode, string statusCode, string containerCode, string devicRumtimes, string workSetBatch, SortedList insertWorkSets)
		{
			if (!(BarCodeHelper.IsTempSet(bccCode) && Accept_order_wf.Contains(string.Format("{0},", currentPd))
				 && (!string.IsNullOrEmpty(location) && !OR_Locations.Contains(location))))
			{
				if (Use_set_wf.Contains(string.Format("{0},", currentPd)))
				{
					bcuCode = string.Empty;
				}
				else if (Release_sterilizer_wf.Contains(string.Format("{0},", currentPd)))
				{
					int currentArea = 0;
					int nextArea = 0;
					if (!string.IsNullOrEmpty(currentPd))
					int.TryParse(currentPd.Substring(0, 1), out currentArea);
					if (!string.IsNullOrEmpty(nextPd))
						int.TryParse(nextPd.Substring(0, 1), out nextArea);
					if (nextArea < currentArea)
						bcuCode = string.Empty;
					if (BarCodeHelper.IsTempSet(bccCode))
					{
						string[] tempStorages = Temp_storage_wf.Split(',');
						foreach (string item in tempStorages)
						{
							if (item.StartsWith(nextPd.Substring(0, 1)))
								nextPd = item;
						}
					}
				}

				string[] nextWFs = nextPd.Split(',');
				if (nextWFs != null && nextWFs.Length > 0)
				{
					foreach (string nextWF in nextWFs)
					{
						if (!string.IsNullOrEmpty(nextWF))
						{
							SortedList insertWorkSet = new SortedList();
							insertWorkSet.Add(1, setid);//set_id
							insertWorkSet.Add(2, bccCode);//set_code
							insertWorkSet.Add(3, name);//set_name
							insertWorkSet.Add(4, nextWF);//wf_code
							insertWorkSet.Add(5, userId);	 //userId
							insertWorkSet.Add(6, infoSerial);	 //info_serial 
							insertWorkSet.Add(7, statusCode);//status
							insertWorkSet.Add(8, "");//remark
							insertWorkSet.Add(9, containerCode);  //container_code
							insertWorkSet.Add(10, bcuCode);
							insertWorkSet.Add(11, devicRumtimes);  //device_runtimes
							insertWorkSet.Add(12, workSetBatch);  //batch
							insertWorkSets.Add(insertWorkSets.Count + 1, insertWorkSet);
						}
					}
				}
			}
		}


		private DataRow[] GetSetData(string barCode, DataTable workSetData = null)
		{
			DataRow[] dataRows = null;
			try
			{
				if (workSetData != null)
				{
					dataRows = workSetData.Select("bar_code='" + barCode + "'");
				}
				else
				{
					if (BarCodeHelper.IsOrderSet(barCode) || BarCodeHelper.IsTempSet(barCode))
					{
						SortedList condition = new SortedList();
						condition.Add(1, barCode);
						string sql = "HCS-workset-sec009";
						if (BarCodeHelper.IsTempSet(barCode))
						{
							condition.Add(2, CnasBaseData.SystemID);
							sql = "HCS-bcct-sec003";
						}
						CnasRemotCall remote = new CnasRemotCall();
						string testSQL = remote.RemotInterface.CheckSelectData(sql, condition);
						DataTable data = remote.RemotInterface.SelectData(sql, condition);
						if (data != null)
							dataRows = data.Select();
					}
					else
					{
						dataRows = dtsetdata.Select("bar_code='" + barCode + "'");
					}
				}
			}
			catch (Exception)
			{

			}


			return dataRows;
		}

		public string Get_BCU_Code(string inpddata, string inbcdata)
		{
			if (Cre_BCU_wf.IndexOf(inpddata + ",") > -1)
			{
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList sttemp20 = new SortedList();
				sttemp20.Add(1, inbcdata);
				DataTable dtset01 = reCnasRemotCall.RemotInterface.SelectData("HCS-set-sec020", sttemp20);
				if (dtset01 != null)
				{
					string str_id = dtset01.Rows[0]["id"].ToString();
					string str_run_times = dtset01.Rows[0]["run_times"].ToString();
					int int_run = int.Parse(str_run_times) + 1;
					str_run_times = int_run.ToString();
					int int_count = str_run_times.Length;
					string strall = "BCU" + str_id;
					strall = strall.PadRight(13 - int_count, '0') + str_run_times;
					return strall;
				}
				else
				{
					return "";
				}
			}
			else return "";
		}
 
		public SortedList CheckBusinessLogic(string barCode, Dictionary<string, string> scanCodes)
		{
			SortedList result = new SortedList();
			result.Add("result_Code", 0);
			result.Add("result_Message", string.Empty);
			result.Add("barCode", barCode);
			result.Add("barCodeObjectName", string.Empty);
			result.Add("barCodeObjectId", string.Empty);
			result.Add("IsModifyOrder", false);
			result.Add("IsShowRFIDDialog", false);
			result.Add("Message_Type", MessageBoxIcon.Information);
			result.Add("Message_Operation", 1);
			result.Add("MessageBox_Message", string.Empty);
			result.Add("Message_Btn", 1);
			result.Add("WorkSetBatch", "");
			result.Add("BCU", "");
			result.Add("BCURRelation", string.Empty);

			CnasRemotCall remoteCall = new CnasRemotCall();
			string barCodeType = barCode.Substring(0, 3);
			if (barCodeType.Equals("BCB"))
			{
				if (scanCodes != null && scanCodes.Count == 1)
				{
					result["result_Code"] = 1; // 操作员已经存在
					result["result_Message"] = "操作员已经存在";
				}
				else
				{
					UserBase userInfo = UserBaseHelper.GetUserByBarCode(barCode);
					result["barCodeObjectName"] = userInfo.UserName;
				}
			}
			else if (barCodeType.Equals("BCV"))
			{
				if (scanCodes != null && scanCodes.Count == 1)
				{
					result["barCodeObjectName"] = "";
				}
				else
				{
					result["result_Code"] = 301; // 流程编码已经存在
					result["result_Message"] = "流程编码已经存在";
				}
			}
			else
			{
				string pdBarCode = scanCodes.FirstOrDefault(q => q.Value == "BCV").Key;
				if (!string.IsNullOrEmpty(pdBarCode))
				{
					string pdCode = pdBarCode.Substring(9, 4);
					SortedList searchFilter = new SortedList();
					searchFilter.Add(1, pdCode);
					string sqltest = remoteCall.RemotInterface.CheckSelectData("HCS-procedure-mapping-sec001", searchFilter);
					DataTable mapping = remoteCall.RemotInterface.SelectData("HCS-procedure-mapping-sec001", searchFilter);
					string mappedPdCode = string.Empty;
					if (mapping != null && mapping.Rows.Count > 0 && mapping.Columns.Contains("mapto_pd"))
					{
						foreach (DataRow item in mapping.Rows)
						{
							if (!(item["mapto_pd"] is DBNull))
								mappedPdCode += string.Format("{0},", Convert.ToString(item["mapto_pd"]));
						}
						mappedPdCode = mappedPdCode.TrimEnd(',');
						mappedPdCode = mappedPdCode.Replace(",", "','");
					}
					else
					{
						mappedPdCode = pdCode;
					}
					if (barCodeType.Equals("BCD") || barCodeType.Equals("BCW") ||
						barCodeType.Equals("BCZ") || barCodeType.Equals("BCP") ||
						barCodeType.Equals("BCO"))
					{
						#region 装载时-判断推进车、清洗、灭菌设备时候设备是不是该CSSD的设备，以及程序和机器是否吻合；

						if (string.IsNullOrEmpty(Load_container_wf))
						{
							//系统数据配置有问题	
							result["result_Code"] = 101;
							result["result_Message"] = "系统数据配置有问题";
						}
						else if (Load_container_wf.Contains(string.Format("{0}", pdCode)))
						{
							string sql = string.Empty;
							SortedList condition = new SortedList();
							if (barCodeType.Equals("BCD"))
							{
								sql = "HCS-transport-device-sec003";
								condition.Add(1, barCode);
								condition.Add(2, CnasBaseData.SystemID);
								condition.Add(3, 1);
							}
							else if (barCodeType.Equals("BCP"))
							{
								#region 判断机器程序逻辑

								if (scanCodes.ContainsValue("BCW"))
								{
									string machineBarCode = scanCodes.FirstOrDefault(q => q.Value == "BCW").Key;
									sql = "HCS-washing-program-sec003";
									condition.Add(1, machineBarCode);
									condition.Add(2, CnasBaseData.SystemID);
									condition.Add(3, barCode);
								}
								else if (scanCodes.ContainsValue("BCZ"))
								{
									string machineBarCode = scanCodes.FirstOrDefault(q => q.Value == "BCZ").Key;
									sql = "HCS-sterilizer-program-sec003";
									condition.Add(1, machineBarCode);
									condition.Add(2, CnasBaseData.SystemID);
									condition.Add(3, barCode);
								}
								else
								{
									if (barCode.StartsWith("BCP1"))
									{
										sql = "HCS-washing-program-sec004";
									}
									else if (barCode.StartsWith("BCP2"))
									{
										sql = "HCS-sterilizer-deviceprogram-sec004";
									}
									else
									{
										//Todo rui: 塑风机程序
										sql = string.Empty;
									}

									condition.Add(1, barCode);
								}

								#endregion
							}
							else if (barCodeType.Equals("BCW"))
							{
								#region 判断清洗剂逻辑
								condition.Add(1, barCode);
								condition.Add(2, CnasBaseData.SystemID);

								if (scanCodes.ContainsValue("BCP"))
								{
									string programCode = scanCodes.FirstOrDefault(q => q.Value == "BCP").Key;
									sql = "HCS-washing-program-sec003";
									condition.Add(3, programCode);
								}
								else
								{
									sql = "HCS-washing-device-sec002";
								}
								#endregion
							}
							else if (barCodeType.Equals("BCZ"))
							{
								#region 判断灭菌器逻辑

								condition.Add(1, barCode);
								condition.Add(2, CnasBaseData.SystemID);
								if (scanCodes.ContainsValue("BCP"))
								{
									string programCode = scanCodes.FirstOrDefault(q => q.Value == "BCP").Key;
									sql = "HCS-sterilizer-program-sec003";
									condition.Add(3, programCode);
								}
								else
									sql = "HCS-sterilizer-device-sec002";

								#endregion
							}
							string testSql = string.Empty;
							try
							{
								if (!string.IsNullOrEmpty(sql))
								{
									testSql = remoteCall.RemotInterface.CheckSelectData(sql, condition);
									DataTable data = remoteCall.RemotInterface.SelectData(sql, condition);
									if (data == null || data.Rows.Count == 0)
									{
										Logger.Info(string.Format("sql:{0}", testSql));
										result["result_Code"] = 102;
										if (sql == "HCS-sterilizer-device-sec002" || sql == "HCS-washing-device-sec002")
											result["result_Message"] = "装载的机器不存在";
										else if (sql == "HCS-washing-program-sec004" || sql == "HCS-sterilizer-deviceprogram-sec004")
											result["result_Message"] = "装载的程序不存在";
										else if (sql == "HCS-transport-device-sec003")
											result["result_Message"] = "装载的运输车失败";
										else
										{
											if (barCodeType.Equals("BCP"))
												result["result_Message"] = "装载机器和程序不匹配，请联系管理员";
											else
												result["result_Message"] = "装载机器和程序不匹配，请联系管理员";
										}
									}
									else
									{
										result["result_Code"] = 0;
										if (sql == "HCS-sterilizer-device-sec002" || sql == "HCS-washing-device-sec002")
										{
											result["barCodeObjectName"] = data.Rows[0]["ca_name"];
											result["barCodeObjectId"] = data.Rows[0]["id"];
											if (Add_setandsterilizer_count.Contains(pdCode) && !BD_test_wf.Contains(pdCode))
											{
												bool isNeedBdTest = true;
												if (data.Columns.Contains("if_bdtest"))
													isNeedBdTest = 	data.Rows[0]["if_bdtest"].ToString().Equals("1");
												DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
												if (data.Columns.Contains("bd_test_time"))
													DateTime.TryParse(data.Rows[0]["bd_test_time"].ToString(), out startDate);
												if (isNeedBdTest)
												{
													condition.Clear();
													condition.Add(1, barCode);
													condition.Add(2, "BDTest_resullt");
													testSql = remoteCall.RemotInterface.CheckSelectData("HCS-device-bdtest-sec001", condition);
													DataTable bDTestData = remoteCall.RemotInterface.SelectData("HCS-device-bdtest-sec001", condition);
													if (bDTestData != null && bDTestData.Rows.Count > 0)
													{
														if (bDTestData.Columns.Contains("BDTestResult") && !(bDTestData.Rows[0]["BDTestResult"] is DBNull)
															&& bDTestData.Columns.Contains("test_date") && !(bDTestData.Rows[0]["test_date"] is DBNull))
														{
															bool bdTestResult = true;
															Boolean.TryParse(bDTestData.Rows[0]["BDTestResult"].ToString(), out bdTestResult);
															DateTime testDate = Convert.ToDateTime(bDTestData.Rows[0]["test_date"].ToString());
															if (startDate <= testDate && testDate <= startDate.AddDays(1))
															{
																if (!bdTestResult)
																{
																	result["result_Code"] = 104;
																	result["result_Message"] = "该灭菌器为查询到今天的BD测试结果失败";
																}
															}
															else
															{
																result["result_Code"] = 103;
																result["result_Message"] = "该灭菌器为查询不到今天的BD测试结果";
															}
														}
													}
													else
													{
														result["result_Code"] = 103;
														result["result_Message"] = "该灭菌器为查询不到今天的BD测试结果";
													}
												}
											}

										}
										else if (sql == "HCS-washing-program-sec004" || sql == "HCS-sterilizer-deviceprogram-sec004")
											result["barCodeObjectName"] = data.Rows[0]["pr_name"];
										else if (sql == "HCS-transport-device-sec003")
										{
											result["barCodeObjectName"] = data.Rows[0]["ca_name"];
											result["result_Message"] = "装载运输车成功";
										}
										else
										{
											if (barCodeType.Equals("BCP"))
											{
												result["barCodeObjectName"] = data.Rows[0]["pr_name"];
												result["result_Message"] = "装载程序成功";
											}
											else
											{
												result["barCodeObjectName"] = data.Rows[0]["dev_name"];
												result["result_Message"] = "装载机器成功";
											}
										}
									}
								}
								else
								{
									result["result_Code"] = 0;
									result["result_Message"] = "装载成功";
								}
							}
							catch (Exception ex)
							{
								Logger.Info(string.Format("sql:{0}", testSql));
								Logger.Error(ex);
								//result = ex.Message;
							}
						}
						else
						{
							#region 接收时-判断车、清洗、灭菌设备是不是在当前流程环节
							SortedList condition = new SortedList();
							condition.Add(1, mappedPdCode);
							condition.Add(2, barCode);
							condition.Add(3, 0);
							string testSQL = string.Empty;
							try
							{
								testSQL = remoteCall.RemotInterface.CheckSelectData("HCS-workset-sec0010", condition);

								DataTable data = remoteCall.RemotInterface.SelectData("HCS-workset-sec0010", condition);
								if (data == null || data.Rows.Count == 0)
								{
									Logger.Info(string.Format("sql:{0}", testSQL));
									result["result_Code"] = 103;
									if (barCodeType.Equals("BCD"))
									{
										result["barCodeObjectName"] = "运输车";
										result["result_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("NotValidateCar", EnumPromptMessage.warning);
										//result["result_Message"] = "该运输车没有器械包，无需卸载";
									}
									else if (barCodeType.Equals("BCW"))
									{
										result["barCodeObjectName"] = "清洗设备";
										result["result_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("NotValidateWashing", EnumPromptMessage.warning);
										//result["result_Message"] = "该清洗设备没有器械包，无需释放";
									}
									else if (barCodeType.Equals("BCZ"))
									{
										result["barCodeObjectName"] = "灭菌设备";
										result["result_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("NotValidateSterilizer", EnumPromptMessage.warning);
										//result["result_Message"] = "该灭菌设备没有器械包，无需释放";
									}
									else if (barCodeType.Equals("BCO"))
									{
										result["barCodeObjectName"] = "发货单";
										//发货单已被接收或该发货单号非法
										result["result_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("NotValidateBCO", EnumPromptMessage.warning);
									}
								}
								else
								{
									result["result_Code"] = 0;
									if (barCodeType.Equals("BCD"))
									{
										result["barCodeObjectName"] = data.Rows[0]["car_name"];
										result["result_Message"] = "判断运输车成功";
									}
									else if (barCodeType.Equals("BCW"))
									{
										result["barCodeObjectName"] = data.Rows[0]["washing_name"];
										result["result_Message"] = "判断清洗设备成功";
									}
									else if (barCodeType.Equals("BCZ"))
									{
										result["barCodeObjectName"] = data.Rows[0]["sterilizer_name"];
										result["result_Message"] = "判断灭菌设备成功";
									}
									else if (barCodeType.Equals("BCO"))
									{
										result["barCodeObjectName"] = "发货单";
										result["result_Message"] = "查看发货单成功";
									}
								}
							}
							catch (Exception ex)
							{
								Logger.Info(string.Format("sql:{0}", testSQL));
								Logger.Error(ex);
							}

							#endregion
						}

						#endregion
					}
					else if (barCodeType.Equals("BCU") || barCodeType.Equals("BCC"))
					{
						string bccCode = string.Empty;
						if (barCodeType.Equals("BCU"))
						{
							SortedList sttemp01 = new SortedList();
							sttemp01.Add(1, barCode);
							DataTable dtworktmp = remoteCall.RemotInterface.SelectData("HCS-workset-sec004", sttemp01);
							if (dtworktmp == null || dtworktmp.Rows.Count == 0)
							{
								result["result_Code"] = 202;
								result["result_Message"] = "该标签条码无法获取器械包信息";
							}
							else
							{
								bccCode = dtworktmp.Rows[0]["set_code"].ToString();
								result["barCode"] = CnasUtilityTools.ConcatTwoString(barCode, bccCode);
							}
						}
						else
							bccCode = barCode;

						if (Set_notincycle_wf.Contains(string.Format("{0}", pdCode)))
							result["result_Message"] = "允许包不在循环也可以使用的流程环节。";
						else
						{
							if (!string.IsNullOrEmpty(bccCode))
							{
								#region 判断器械包是不是在当前流程环节

								SortedList condition = new SortedList();
								condition.Add(1, mappedPdCode);
								condition.Add(2, bccCode);
								condition.Add(3, 0);
								string testSQL = string.Empty;
								try
								{
									testSQL = remoteCall.RemotInterface.CheckSelectData("HCS-workset-sec002", condition);
									
									DataTable dataWorkSet = remoteCall.RemotInterface.SelectData("HCS-workset-sec002", condition);
									if (dataWorkSet == null || dataWorkSet.Rows.Count == 0)
									{
										result["result_Code"] = 201;
										Logger.Info(string.Format("sql:{0}", testSQL));
										result["result_Message"] = "该包不在当前流程环节。";
									}
									else
									{
										result["barCodeObjectName"] = dataWorkSet.Rows[0]["set_name"].ToString();
										result["barCodeObjectId"] = dataWorkSet.Rows[0]["set_id"].ToString();
										result["WorkSetBatch"] = dataWorkSet.Rows[0]["batch"].ToString();
										if (!BarCodeHelper.IsOrderSet(bccCode))
										{
											if (Show_RFID_wf.Contains(string.Format("{0},", pdCode)))
											{
												DataRow[] setDetails = GetSetData(bccCode);
												if (setDetails.Length > 0 && !(setDetails[0]["rfid_retrospect"] is DBNull))
												{
													result["IsShowRFIDDialog"] = setDetails[0]["rfid_retrospect"].ToString() == "1";
												}
											}

											#region BCC4O拆包逻辑

											if (barCodeType.Equals("BCU") && BarCodeHelper.IsSplitSet(barCode))
											{
												SortedList filter = new SortedList();
												filter.Add(1, barCode);
												CnasRemotCall remote = new CnasRemotCall();
												string sql = remote.RemotInterface.CheckSelectData("HCS-bcc-data-sec001", filter);
												DataTable bcctCodes = remote.RemotInterface.SelectData("HCS-bcc-data-sec001", filter);
												if (bcctCodes != null && bcctCodes.Rows.Count > 0)
												{
													string bcurMessage = "还需扫描条码{0}";
													string nextBCUR = string.Empty;
													foreach (DataRow row in bcctCodes.Rows)
													{
														string bcur = Convert.ToString(row["BCU_code"]);
														if (!string.IsNullOrEmpty(bcur))
														{
															string exisedBCUR = scanCodes.Keys.FirstOrDefault(p => p.StartsWith(bcur));
															if (string.IsNullOrEmpty(exisedBCUR) && bcur != barCode)
															{
																nextBCUR += string.Format("{0},", bcur);
															}
															result["BCURRelation"] += string.Format("{0},", bcur);
														}
													}
													if (!string.IsNullOrEmpty(nextBCUR))
													{
														nextBCUR = nextBCUR.TrimEnd(',');
														result["result_Message"] = string.Format(bcurMessage, nextBCUR);
													}
												}
											}

											#endregion

											#region 有效期检查

											if (Check_set_expiredate_wf.Contains(string.Format("{0},", pdCode)) && barCode.StartsWith("BCU"))
											{
												int expireDate = 7;
												DataRow[] setDetail = GetSetData(bccCode);
												if (setDetail != null && setDetail.Length > 0 && !(setDetail[0]["ca_expiration"] is DBNull))
													int.TryParse(setDetail[0]["ca_expiration"].ToString(), out expireDate);

												SortedList filter = new SortedList();
												CnasRemotCall remote = new CnasRemotCall();
												filter.Clear();
												filter.Add(1, barCode);
												filter.Add(2, Cre_BCU_wf.TrimEnd(',').Replace(",", "','"));
												string sql = remote.RemotInterface.CheckSelectData("HCS-workset-sec014", filter);
												DataTable expireData = remote.RemotInterface.SelectData("HCS-workset-sec014", filter);

												if (expireData != null && expireData.Rows.Count > 0 && expireData.Columns.Contains("mod_date"))
												{
													DateTime startDate = DateTime.Now.AddDays(-7);
													string startDateString = Convert.ToString(expireData.Rows[0]["mod_date"]);
													if (!string.IsNullOrEmpty(startDateString) && DateTime.TryParse(startDateString, out startDate))
													{
														if (startDate.AddDays(expireDate) <= DateTime.Now)
														{
															result["result_Code"] = 202;
															result["result_Message"] = "器械包已经过保质期。";
														}
													}
													else
													{
														result["result_Code"] = 203;
														result["result_Message"] = "无法查询器械包的生产时间。";
													}
													
												}
												else
												{
													result["result_Code"] = 203;
													result["result_Message"] = "无法查询器械包的生产时间。";
												}
											}

											#endregion

											#region 植入物检查

											if (Check_set_Biology_wf.Contains(string.Format("{0},", pdCode)) && barCode.StartsWith("BCU")
												&& !BarCodeHelper.IsTempSet(bccCode))
											{
												DataRow[] setDetails = GetSetData(bccCode);
												string setType = Convert.ToString(setDetails[0]["ca_type"]);
												if (!string.IsNullOrEmpty(setType) && _warningSetType.Contains(string.Format("{0}", setType)))
												{
													if (setType == "3")
													{
														result["Message_Type"] = MessageBoxIcon.Information;
														result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("BiologyCheck", EnumPromptMessage.warning);
														SortedList filter = new SortedList();
														filter.Add(1, barCode);
														CnasRemotCall remote = new CnasRemotCall();
														string sql = remote.RemotInterface.CheckSelectData("HCS-release-result-sec002", filter);
														DataTable biologyResults = remote.RemotInterface.SelectData("HCS-release-result-sec002", filter);
														bool? biologyResult = null;
														if (biologyResults != null && biologyResults.Rows.Count > 0)
														{
															biologyResult = biologyResults.Columns.Contains("result") ? Convert.ToString(biologyResults.Rows[0]["result"]) == "1" : false;
														}

														if (Load_container_wf.Contains(string.Format("{0},", pdCode)))
														{
															result["Message_Type"] = MessageBoxIcon.Information;
															//"该器械包含有植入物，根据国家标准需要等待生物监测结果成功后方可发放。";
															result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("BiologyCheckSend", EnumPromptMessage.warning);
															if (_sendSetWithBiology == "1")
															{
																if (biologyResult == false || biologyResult == null)
																{
																	result["result_Code"] = 204;
																	//"该包生物监测不合格, 不允许发放。";
																	result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("BiologyCheckNotSend", EnumPromptMessage.warning);
																	result["result_Message"] = result["MessageBox_Message"];
																}
															}
														}

														if (Use_set_wf.Contains(string.Format("{0},", pdCode)))
														{
															result["Message_Type"] = MessageBoxIcon.Information;
															//"该器械包含有植入物，根据国家标准需要等待生物监测结果成功后方可使用。";
															result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("BiologyCheckUse", EnumPromptMessage.warning);
															if (_useSetWithBiology == "1")
															{
																if (biologyResult == false || biologyResult == null)
																{
																	result["result_Code"] = 204;
																	//"该包生物监测不合格, 不允许使用。";
																	result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("BiologyCheckNotUse", EnumPromptMessage.warning);
																	result["result_Message"] = result["MessageBox_Message"];
																}
															}
														}
														
													}
												}
											}

											#endregion

											#region 使用地点验证

											
											if (CheckUserLocation_wf.Contains(string.Format("{0},", pdCode)) && barCode.StartsWith("BCU"))
											{
												DataRow[] setDetails = GetSetData(bccCode);
												string scanLocation = BarCodeHelper.GetBarCodeByType("BCE", scanCodes);
												if (!string.IsNullOrEmpty(scanLocation) && setDetails.Length > 0)
												{
													string setLocation = Convert.ToString(setDetails[0]["u_barcode"]);
													if (!setLocation.Equals(scanLocation))
													{
														result["Message_Operation"] = 2;
														//该包使用地点与扫描的使用地点不一致，请确认是否继续?
														result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("NotSameLocation", EnumPromptMessage.warning);
														result["result_Message"] = result["MessageBox_Message"];
													}
												}
												else
												{
													result["result_Code"] = 205;
													//"未扫描到使用地点编码";
													//result["MessageBox_Message"] = PromptMessageXmlHelper.Instance.GetPromptMessage("NoScanLocation", EnumPromptMessage.warning);
													result["result_Message"] = result["MessageBox_Message"];
												}
											}

											#endregion

											if (Modify_order_wf.Contains(string.Format("{0}", pdCode)) && BarCodeHelper.IsSpecialSet(barCode))
											{
												result["IsModifyOrder"] = true;
											}
										}
										else
										{
											if (Modify_order_wf.Contains(string.Format("{0}", pdCode)))
											{
												result["IsModifyOrder"] = true;
											}
										}
									}
								}
								catch (Exception ex)
								{
									Logger.Info(string.Format("sql:{0}", testSQL));
									Logger.Error(ex);
								}
								#endregion
							}
						}
					}
					else if (barCodeType.Equals("BCS"))
					{
						SortedList condition = new SortedList();
						condition.Add(1, barCode);
						string sqlTest = remoteCall.RemotInterface.CheckSelectData("HCS-storage-sec005", condition);
						DataTable data = remoteCall.RemotInterface.SelectData("HCS-storage-sec005", condition);
						if (data == null || data.Rows.Count == 0)
							result["result_Message"] = "该存储点不存在在数据库中";
						else
						{
							result["barCodeObjectName"] = Convert.ToString(data.Rows[0]["s_name"]);
							result["result_Message"] = "扫描存储点成功";
						}
					}
					else if (barCodeType.Equals("BCE"))
					{
						SortedList condition = new SortedList();
						condition.Add(1, barCode);
						DataTable data = remoteCall.RemotInterface.SelectData("HCS-use-location-sec006", condition);
						if (data == null || data.Rows.Count == 0)
							result["result_Message"] = "该使用地点不存在在数据库中";
						else
						{
							result["barCodeObjectName"] = Convert.ToString(data.Rows[0]["u_uname"]);
							result["result_Message"] = "扫描使用地点成功";
						}
					}
				}
				else
				{
					result["result_Code"] = 301; // 流程编码已经存在
					result["result_Message"] = "流程编码不存在";
				}
			}

			return result;
		}

		/// <summary>
		/// 判断该包或者车已经到当前流程
		/// </summary>
		/// <param name="inbcdata">条码编号</param>
		/// <param name="inpddata">当前流程编号</param>
		/// <returns>返回值:1-通过，其它-不通过</returns>
		public SortedList ifinwf(string inbcdata, string inpddata, DataTable inbasedata)
		{
			SortedList sl_rec = new SortedList();
			sl_rec.Add("rec_result", 99);
			sl_rec.Add("rec_data01", "");
			sl_rec.Add("rec_data02", "");
			sl_rec.Add("BCU", "");

			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			string strbc = inbcdata.Substring(0, 3);
			if (strbc == "BCC")
			{
				if (Set_notincycle_wf.IndexOf(inpddata + ",") > -1)
				{
					#region 允许包不在循环也可以使用的流程环节

					sl_rec["rec_result"] = 1;
					sl_rec["rec_data01"] = "允许包不在循环也可以使用的流程环节。";
					return sl_rec;
					#endregion
				}
				else
				{
					#region 判断器械包是不是在当前流程环节
					SortedList sttemp01 = new SortedList();
					sttemp01.Add(1, inpddata);
					sttemp01.Add(2, inbcdata);
					sttemp01.Add(3, 0);
					//string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec002", sttemp01);
					DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec002", sttemp01);
					if (dtworktmp == null)
					{
						sl_rec["rec_result"] = 0;
						sl_rec["rec_data01"] = "该包不在当前流程环节";
					}
					else
					{
						sl_rec["rec_result"] = 1;

						//if(Cre_BCU_wf.IndexOf(inpddata + ",") > -1)
						//{
						//    //需要将BCU码产生出来给到前端:HCS-set-sec020
						//    sl_rec["BCU"] = Get_BCU_Code(inpddata,inbcdata);
						//     
						//}
						sl_rec["rec_data01"] = "该包在当前流程环节";
						sl_rec["rec_data02"] = dtworktmp.Rows[0]["set_name"].ToString();
					}
					return sl_rec;
					#endregion
				}
			}
			else if (strbc == "BCD" || strbc == "BCW" || strbc == "BCZ")
			{

				#region 装载时-判断推进车、清洗、灭菌设备时候不需要检查，直接返回成功1；

				if (Load_container_wf == "")
				{
					//系统数据配置有问题
					sl_rec["rec_result"] = 101;
					sl_rec["rec_data01"] = "系统数据配置有问题";
					return sl_rec;
				}
				if (Load_container_wf.IndexOf(inpddata + ",") > -1)
				{
					sl_rec["rec_result"] = 1;
					sl_rec["rec_data01"] = "判断装载车、清洗、灭菌设备成功";
					return sl_rec;
				}
				#endregion

				#region 接收时-判断车、清洗、灭菌设备是不是在当前流程环节
				SortedList sttemp01 = new SortedList();
				sttemp01.Add(1, inpddata);
				sttemp01.Add(2, inbcdata);
				sttemp01.Add(3, 0);
				string testSQL = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec003", sttemp01);

				DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec003", sttemp01);
				if (dtworktmp == null || dtworktmp.Rows.Count == 0)
				{
					sl_rec["rec_result"] = 0;
					sl_rec["rec_data01"] = "判断运输和卸载车、清洗、灭菌设备失败";
					return sl_rec;
				}
				else
				{
					sl_rec["rec_result"] = 1;
					sl_rec["rec_data01"] = "判断运输和卸载车、清洗、灭菌设备成功";
					return sl_rec;
				}
				#endregion
			}
			else if (strbc == "BCU")
			{
				#region 生产条码：需要找出对应BCC条码

				//生产条码：需要找出对应BCC条码
				SortedList sttemp01 = new SortedList();
				sttemp01.Add(1, inbcdata);
				//string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec004", sttemp01);
				DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec004", sttemp01);
				if (dtworktmp == null)
				{
					sl_rec["rec_result"] = 0;
					sl_rec["rec_data01"] = "BCC条码无法通过BCU获取";
					return sl_rec;
				}
				else
				{
					if (dtworktmp.Rows.Count > 0)
					{
						string str_bcc01 = dtworktmp.Rows[0]["set_code"].ToString();
						//暂未判断该包是否在当前流程
						SortedList sttempTestBcu = new SortedList();
						sttempTestBcu.Add(1, inpddata);
						sttempTestBcu.Add(2, str_bcc01);
						sttempTestBcu.Add(3, 0);
						//string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec002", sttempTestBcu);
						DataTable dtworktmpBcu = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec002", sttempTestBcu);
						if (dtworktmpBcu != null && dtworktmpBcu.Rows.Count > 0)
						{
							sl_rec["rec_result"] = 1;
							sl_rec["rec_data01"] = str_bcc01;
							sl_rec["rec_data02"] = dtworktmp.Rows[0]["set_name"].ToString();
							return sl_rec;
						}
						else
						{
							sl_rec["rec_result"] = 0;
							sl_rec["rec_data01"] = "该包不在当前流程环节";
							return sl_rec;
						}

					}
					else
					{
						sl_rec["rec_result"] = 0;
						sl_rec["rec_data01"] = "BCC条码无法通过BCU获取";
						return sl_rec;
					}
				}
				#endregion
			}
			else if (strbc == "BCS")
			{
				SortedList condition = new SortedList();
				condition.Add(1, inbcdata);
				string sqlTest = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-storage-sec005", condition);
				DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-storage-sec005", condition);
				if (data == null)
				{
					sl_rec["rec_result"] = 1;
					sl_rec["rec_data01"] = "无需判断，直接返回";
					return sl_rec;
				}
				string storageIdStr = Convert.ToString(data.Rows[0]["id"]);
				string storageNameStr = Convert.ToString(data.Rows[0]["s_name"]);
				sl_rec["rec_result"] = 1;
				sl_rec["rec_data01"] = storageIdStr;
				sl_rec["rec_data02"] = storageNameStr;
				return sl_rec;
			}
			else if (strbc == "BCP")
			{
				//判断当前程序是否属于该设备（待开发）
				sl_rec["rec_result"] = 1;
				sl_rec["rec_data01"] = "该程序属于流程环节";
				return sl_rec;
			}
			else if (strbc == "BCE")
			{
				SortedList condition = new SortedList();
				condition.Add(1, inbcdata);
				//string sqlTest = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-use-location-sec006", condition);
				DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-use-location-sec006", condition);
				if (data != null)
				{
					string LocationNameStr = Convert.ToString(data.Rows[0]["u_uname"]);
					sl_rec["rec_result"] = 1;
					sl_rec["rec_data01"] = inbcdata;
					sl_rec["rec_data02"] = LocationNameStr;
					return sl_rec;
				}
				else
				{
					sl_rec["rec_result"] = 0;
					sl_rec["rec_data01"] = "使用地点错误";
					return sl_rec;
				}
			}
			else
			{
				sl_rec["rec_result"] = 1;
				sl_rec["rec_data01"] = "无需判断，直接返回";
				return sl_rec;
			}
		}

		public SortedList GetNextWFs(string currentPd, SortedList scanCodes, SortedList parameter01, SortedList parameter02)
		{
			SortedList result = new SortedList();
			DataTable dealingWorkSets = null;
			SortedList parameter01ForLog = new SortedList();

			Dictionary<string, string> nextPds = new Dictionary<string, string>();
			int submitType = GetSubmitType(currentPd);
			nextPds.Add("standantNextPd", string.Empty);
			nextPds.Add("currentPd", currentPd);
			result.Add("result_code", "0");
			result.Add("result_message", string.Empty);
			result.Add("result_nextPds", nextPds);
			result.Add("submit_Type", submitType);
			result.Add("result_DealingWorkSet", dealingWorkSets);
			result.Add("parameter01ForLog", parameter01ForLog);

			for (int i = 0; i < parameter01.Count; i++)
			{
				parameter01ForLog.Add(parameter01.GetKey(i), string.Empty);
			}

			CnasRemotCall reCnasRemotCall = new CnasRemotCall();
			SortedList condition = new SortedList();
			condition.Add(1, currentPd);
			string testSQL = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-pdrelation-sec001", condition);
			DataTable data = reCnasRemotCall.RemotInterface.SelectData("HCS-pdrelation-sec001", condition);
			if (scanCodes != null && (data != null && data.Rows.Count > 0))
			{
				string standNextWF = string.Empty;
				List<string> bccCodes = new List<string>();
				if (submitType == 1001 || submitType == 2001)
				{
					for (int i = 0; i < scanCodes.Count; i++)
					{
						string key = scanCodes.GetKey(i).ToString();
						if (key.Contains(":BCC") || key.StartsWith("BCC"))
						{
							string bccCode = key.Substring(key.IndexOf("BCC"), 13);
							if (!bccCodes.Contains(bccCode))
								bccCodes.Add(bccCode);
						}
					}
				}
				else if (submitType == 2002 || submitType == 2003)
				{
					string searchResult = string.Empty;
					for (int i = 0; i < scanCodes.Count; i++)
					{
						string key = scanCodes.GetKey(i).ToString();
						if (key.StartsWith("BCD") || key.StartsWith("BCZ") || key.StartsWith("BCW") || key.StartsWith("BCO"))
						{
							searchResult = GetWorkSetByContainerCode(currentPd, key, out dealingWorkSets);
							break;
						}
					}

					if (!string.IsNullOrEmpty(searchResult))
					{
						result["result_code"] = 101;
						result["result_message"] = searchResult;
						return result;
					}
					else
					{
						if (dealingWorkSets != null)
						{
							result["result_DealingWorkSet"] = dealingWorkSets;
							foreach (DataRow item in dealingWorkSets.Rows)
							{
								string bccCode = Convert.ToString(item["set_code"]);
								if (!bccCodes.Contains(bccCode))
									bccCodes.Add(bccCode);
							}
						}
					}
				}

				foreach (string bccCode in bccCodes)
				{
					SortedList nextWFResult = GetNextWF(bccCode, currentPd, scanCodes, parameter01ForLog, parameter02, data);
					if (int.Parse(nextWFResult["result_code"].ToString()) == 0)
					{
						nextPds.Add(bccCode, nextWFResult["result_nextPd"].ToString());
						result["result_message"] = nextWFResult["result_message"];
						if (bool.Parse(nextWFResult["result_standant"].ToString()))
						{
							standNextWF = nextWFResult["result_nextPd"].ToString();
							nextPds["standantNextPd"] = standNextWF;
						}
					}
				}

				if (string.IsNullOrEmpty(nextPds["standantNextPd"]))
				{
					SortedList nextWFResult = GetNextWF(string.Empty, currentPd, scanCodes, parameter01ForLog, parameter02, data);
					if (int.Parse(nextWFResult["result_code"].ToString()) == 0)
					{
						result["result_message"] = nextWFResult["result_message"];
						if (bool.Parse(nextWFResult["result_standant"].ToString()))
							nextPds["standantNextPd"] = nextWFResult["result_nextPd"].ToString();
					}
				}
			}
			else
			{
				result["result_code"] = 0;
				result["result_message"] = "没有配置下一步流程，工作流将结束。";
			}

			for (int i = 0; i < parameter01ForLog.Count; i++)
			{
				if (string.IsNullOrEmpty(parameter01ForLog[parameter01ForLog.GetKey(i)].ToString()))
					parameter01ForLog.RemoveAt(i);
			}

			return result;
		}

		private SortedList GetNextWF(string bccCode, string currentWF, SortedList scanCodes, SortedList parameter01, SortedList parameter02, DataTable nextWfs)
		{
			SortedList result = new SortedList();
			result.Add("result_code", 99);
			result.Add("result_message", string.Empty);
			result.Add("result_nextPd", string.Empty);
			result.Add("result_standant", true);

			string nextPd = string.Empty;
			string pdCondtion = string.Empty;

			if (BarCodeHelper.IsOrderSet(bccCode))
				result["result_standant"] = false;

			SortedList paramForSimgle = GenerateParameterByScanCodes(bccCode, scanCodes, ref parameter01);
			if (nextWfs.Rows.Count > 1)
			{
				#region 多条下一步流程：传入参数计算哪个流程合适（按照优先级从小到大计算）

				for (int i = 0; i < nextWfs.Rows.Count; i++)
				{
					if (nextWfs.Rows[i]["pr_condition"] != null) pdCondtion = nextWfs.Rows[i]["pr_condition"].ToString();
					if (nextWfs.Rows[i]["next_pdcode"] != null) nextPd = nextWfs.Rows[i]["next_pdcode"].ToString();
					if (pdCondtion.Trim() == "")//直接返回下一步流程编码
					{
						result["result_code"] = 0;
						if (_allMultWF)
						{
							result["result_nextPd"] += string.Format("{0},", nextPd);
							result["result_message"] += "流程条件为空，使用其为默认流程。\r\n";
						}
						else
						{
							result["result_nextPd"] = nextPd;
							result["result_message"] = "流程条件为空，使用其为默认流程。";
						}
					}
					else
					{
						int intrec = ConditionReplace(pdCondtion, paramForSimgle, parameter02);
						if (intrec == 0)
						{
							result["result_code"] = 0;
							if (_allMultWF)
							{
								result["result_nextPd"] += string.Format("{0},", nextPd);
								result["result_message"] += string.Format("多条下一步流程，【{0}】条件执行结果通过。\r\n", nextPd);
							}
							else
							{
								result["result_nextPd"] = nextPd;
								result["result_message"] = string.Format("多条下一步流程，【{0}】条件执行结果通过。", nextPd);
							}
						}
					}
				}

				if (result["result_code"].ToString() == "99")
				{
					result["result_code"] = 103;
					result["result_nextPd"] = "";
					result["result_message"] = string.Format("多条下一步流程，全部条件执行结果不通过。");
					return result;
				}

				#endregion
			}
			else
			{
				#region 只有唯一一个下一步流程：直接返回该流程为下一步流程
				//只有唯一一个下一步流程：
				if (nextWfs.Rows[0]["pr_condition"] != null) pdCondtion = nextWfs.Rows[0]["pr_condition"].ToString();
				if (nextWfs.Rows[0]["next_pdcode"] != null) nextPd = nextWfs.Rows[0]["next_pdcode"].ToString();

				if (pdCondtion.Trim() == "")//直接返回下一步流程编码
				{
					result["result_code"] = 0;
					result["result_nextPd"] = nextPd;
					result["result_message"] = "唯一下一步流程，条件为空，直接通过。";
				}
				else
				{
					int intrec = ConditionReplace(pdCondtion, paramForSimgle, parameter02);
					if (intrec == 0)
					{
						result["result_code"] = 0;
						result["result_message"] = string.Format("唯一下一步流程，【{0}】条件执行结果通过。", nextPd);
					}
					else
					{
						result["result_code"] = 101;
						result["result_message"] = string.Format("唯一下一步流程，【{0}】条件执行结果不通过。", nextPd);
					}
					result["result_nextPd"] = nextPd;

				}

				#endregion
			}

			return result;
		}

		public SortedList GenerateParameterByScanCodes(string bccCode, SortedList scanCodes, ref SortedList parameter01)
		{
			SortedList paramForSimgle = new SortedList();
			for (int i = 0; i < parameter01.Count; i++)
			{
				paramForSimgle.Add(parameter01.GetKey(i), parameter01[parameter01.GetKey(i)]);
			}

			if (parameter01 != null)
			{
				if (BarCodeHelper.IsOrderSet(bccCode))
				{
					if (parameter01.ContainsKey("if_BCCO"))
					{
						string orderType = bccCode.Substring(3, 1);
						paramForSimgle["if_BCCO"] = orderType;
						parameter01["if_BCCO"] += string.Format("\r\n{0}:{1}", bccCode, orderType);
					}
				}
				if (parameter01.ContainsKey("if_set_endProcedure"))
				{
					bool isOrderSet = BarCodeHelper.IsOrderSet(bccCode) || BarCodeHelper.IsTempSet(bccCode);
					paramForSimgle["if_set_endProcedure"] = isOrderSet ? "2" : "1";
					if (isOrderSet)
						parameter01["if_set_endProcedure"] += string.Format("\r\n{0}:{1}", bccCode, paramForSimgle["if_set_endProcedure"]);
				}
				if (parameter01.ContainsKey("if_standWf"))
				{
					string location = BarCodeHelper.GetBarCodeByType("BCE", scanCodes);
					parameter01["if_standWf"] = OR_Locations.Contains(location) ? "1" : "2";
				}

				if (parameter01.ContainsKey("if_tempSet"))
				{
					string orderType = bccCode.Substring(3, 1);
					if (!BarCodeHelper.IsTempSet(bccCode))
					{
						orderType = "0";
					}
					else
					{
						if (orderType.Equals("3"))
							parameter01["if_tempSet"] += string.Format("\r\n{0}:{1}", bccCode, orderType);
					}
					paramForSimgle["if_tempSet"] = orderType;
				}
			}

			return paramForSimgle;
		}

		public SortedList GetWorkflowParametersValue(int intype, int subtype, SortedList par01, SortedList par02, SortedList par03)
		{
			#region 初始化信息

			RefreshData();
			string currentPd = "", str_userid = "";
			SL_check = (SortedList)par01["SL_check"];
			SL_barcode = (SortedList)par01["sub_barcode"];
			SL_parametersinfo = (SortedList)par01["Par2_info"];
			SL_parametertmp01 = (SortedList)SL_check["pd_par1"];
			SL_parametertmp02 = (SortedList)SL_check["pd_par2"];
			currentPd = SL_check["pd_code"].ToString();
			str_userid = par01["user_id"].ToString();
			#endregion

			//int intsubtype = GetSubmitType(currentPd);
			
			SortedList getNextPds = GetNextWFs(currentPd, SL_barcode, SL_parametertmp01, SL_parametertmp02);

			if (getNextPds.ContainsKey("result_code") && getNextPds["result_code"].ToString()=="0")
			{
				SL_recdata["rec_result"] = 0;
				DataTable dealingWorkSet = getNextPds["result_DealingWorkSet"] as DataTable;
				SortedList parameter01ForLog = getNextPds["parameter01ForLog"] as SortedList;
				Dictionary<string, string> nextPds = getNextPds["result_nextPds"] as Dictionary<string, string>;
				SortedList confirmDialogParams = par01.ContainsKey("Par3_Dialog") ? (SortedList)par01["Par3_Dialog"] : new SortedList();
				int intsubtype = Convert.ToInt32(getNextPds["submit_Type"]);

				if (intsubtype == 1001)//单独提交包
				{
					#region 提交手术器械包到下一流程

					string strrec10 = CreateNextWorkorderSet(str_userid, nextPds, parameter01ForLog, SL_parametertmp02, SL_parametersinfo, confirmDialogParams);
					if (strrec10 == "0")
					{
						SL_recdata["rec_data02"] = "提交手术包到下一流程成功。";
					}
					else
					{
						SL_recdata["rec_result"] = 201;
						SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
					}
					return SL_recdata;

					#endregion
				}
				else if (intsubtype == 2001)//加载车、清洗、灭菌设备
				{
					#region 提交手加载车、清洗、灭菌设备
					for (int i = 0; i < SL_barcode.Count; i++)
					{
						string str_bcx = SL_barcode.GetKey(i).ToString();
						string str_bcxsp = str_bcx.Substring(0, 3);
						if (str_bcxsp == "BCD" || str_bcxsp == "BCW" || str_bcxsp == "BCZ")
						{
							string strrec10 = this.CreateNextWorkorderLoadContainer(str_userid, currentPd, nextPds, str_bcx, parameter01ForLog, SL_parametertmp02, SL_parametersinfo, confirmDialogParams);
							if (strrec10 == "0")
							{
								SL_recdata["rec_data02"] = "提交手术包到下一流程成功。";
							}
							else
							{
								SL_recdata["rec_result"] = 201;
								SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
							}
							return SL_recdata;
						}

					}

					#endregion
				}
				else if (intsubtype == 2002)//运输车箱
				{
					#region 提交手运输车箱
					for (int i = 0; i < SL_barcode.Count; i++)
					{
						string str_bcx = SL_barcode.GetKey(i).ToString();
						string str_bcxsp = str_bcx.Substring(0, 3);
						if (str_bcxsp == "BCD" || str_bcxsp == "BCW" || str_bcxsp == "BCZ")
						{
							string strrec10 = this.CreateNextWorkorderTransportContainer(str_userid, currentPd, nextPds, str_bcx, parameter01ForLog, SL_parametertmp02, SL_parametersinfo, confirmDialogParams, dealingWorkSet);
							if (strrec10 == "0")
							{
								SL_recdata["rec_data02"] = "提交手术包到下一流程成功。";
							}
							else
							{
								SL_recdata["rec_result"] = 201;
								SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
							}
							return SL_recdata;
						}
					}

					#endregion
				}
				else if (intsubtype == 2003)//卸载车、清洗、灭菌设备
				{
					#region 提交卸载车、清洗、灭菌设备
					for (int i = 0; i < SL_barcode.Count; i++)
					{
						string str_bcx = SL_barcode.GetKey(i).ToString();
						string str_bcxsp = str_bcx.Substring(0, 3);
						if (str_bcxsp == "BCD" || str_bcxsp == "BCW" || str_bcxsp == "BCZ" || str_bcxsp == "BCO")
						{

							string strrec10 = this.CreateNextWorkorderUnLoadContainer(str_userid, currentPd, nextPds, str_bcx, parameter01ForLog, SL_parametertmp02, SL_parametersinfo, confirmDialogParams, dealingWorkSet);
							if (strrec10 == "0")
							{
								SL_recdata["rec_data02"] = "提交手术包到下一流程成功。";
							}
							else
							{
								SL_recdata["rec_result"] = 201;
								SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
							}
							return SL_recdata;
						}
					}
					#endregion
				}
			}
			else
			{
				SL_recdata["rec_result"] = getNextPds["result_code"];
				SL_recdata["rec_data02"] = getNextPds["result_message"];
			}

			return SL_recdata;
		}

		/// <summary>
		/// 提交到下一步流程
		/// </summary>
		/// <param name="intype">类型</param>
		/// <param name="par01">参数01</param>
		/// <param name="par02">参数02</param>
		/// <param name="par03">参数03</param>
		/// <returns>返回值</returns>
		public SortedList SubmitNextWorkflow(int intype, SortedList par01, SortedList par02, SortedList par03)
		{
			SortedList SortedList01 = new SortedList();

			return SortedList01;
		}

		/// <summary>
		/// 处理手动操作工单
		/// </summary>
		/// <param name="intype"></param>
		/// <param name="par01"></param>
		/// <param name="par02"></param>
		/// <param name="par03"></param>
		/// <returns></returns>
		public SortedList SubmitProcedureManual(int intype, SortedList in_barcode, SortedList par01, SortedList par02)
		{
			RefreshData();
			string strbar_code = par01["bar_code"].ToString();
			string struser_id = par01["user_id"].ToString();
			string strcurrent_code = par01["current_code"].ToString();
			string strnext_code = par01["next_code"].ToString();
			string strmanual_type = par01["manual_type"].ToString();
			string strmanual_info = par01["manual_info"].ToString();
			Dictionary<string, string> nextPds = new Dictionary<string, string>();

			nextPds.Add("currentPd", strcurrent_code);
			nextPds.Add("standantNextPd", strnext_code);
			
			SL_barcode = in_barcode;

			if (strmanual_type == "1")
			{
				#region 处理单包:不允许退回到Container里面

				SortedList sl_par02 = new SortedList();
				sl_par02.Add("manual_info", 1);
				SortedList sl_parinfo = new SortedList();
				sl_parinfo.Add("manual_info", strmanual_info);
				nextPds.Add(strbar_code, strnext_code);

				string strrec10 = CreateNextWorkorderSet(struser_id, nextPds, null, sl_par02, sl_parinfo, null);
				if (strrec10 == "0")
				{
					SL_recdata["rec_result"] = 0;
					SL_recdata["rec_data02"] = "提交手术包到下一流程【" + strnext_code + "】成功。";
				}
				else
				{
					SL_recdata["rec_result"] = 201;
					SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
				}
				return SL_recdata;

				#endregion

			}
			else if (strmanual_type == "2")
			{
				#region 处理批次:不允许退回到有Container的流程，因为这里没有Container信息；不在Container里面，批次处理失败

				//通过包找到Container code
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList sttemp01 = new SortedList();
				sttemp01.Add(1, strcurrent_code);
				sttemp01.Add(2, strbar_code);
				sttemp01.Add(3, 0);
				DataTable dt01 = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec002", sttemp01);
				if (dt01 != null)
				{
					string str_Containercode = dt01.Rows[0]["container_code"].ToString();
					int intsubtype = GetSubmitType(strcurrent_code);
					SortedList sl_par02 = new SortedList();
					sl_par02.Add("manual_info", 1);
					SortedList sl_parinfo = new SortedList();
					sl_parinfo.Add("manual_info", strmanual_info);
					SortedList confirmDialogParams = new SortedList();
					DataTable containerWorkSet = null;

					if (intsubtype == 2002)//退回不卸载车箱
					{
						string str_bcxsp = str_Containercode.Substring(0, 3);
						if (str_bcxsp == "BCD")
						{
							string searchResult = GetWorkSetByContainerCode(strcurrent_code, str_Containercode, out containerWorkSet);
							if (!string.IsNullOrEmpty(searchResult))
							{
								SL_recdata["rec_result"] = 0;
								SL_recdata["rec_data02"] = searchResult;
							}

							foreach (DataRow row in containerWorkSet.Rows)
							{
								string bccCode = containerWorkSet.Columns.Contains("set_code") ? Convert.ToString(row["set_code"]) : string.Empty;
								if (!string.IsNullOrEmpty(bccCode) && !BarCodeHelper.IsTempSet(bccCode) && !nextPds.ContainsKey(bccCode))
									nextPds.Add(bccCode, strnext_code);
							}

							string strrec10 = this.CreateNextWorkorderTransportContainer(struser_id, strcurrent_code, nextPds, str_Containercode, null, sl_par02, sl_parinfo, confirmDialogParams, containerWorkSet);
							if (strrec10 == "0")
							{
								SL_recdata["rec_result"] = 0;
								SL_recdata["rec_data02"] = "提交手术包到下一流程【" + struser_id + "】成功。";
							}
							else
							{
								SL_recdata["rec_result"] = 201;
								SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
							}
							return SL_recdata;
						}
					}
					else if (intsubtype == 2001 || intsubtype == 2003)//退回卸载车、清洗、灭菌设备
					{
						string str_bcxsp = str_Containercode.Substring(0, 3);
						if (str_bcxsp == "BCW" || str_bcxsp == "BCZ")
						{
							string searchResult = GetWorkSetByContainerCode(strcurrent_code, str_Containercode, out containerWorkSet);
							if (!string.IsNullOrEmpty(searchResult))
							{
								SL_recdata["rec_result"] = 0;
								SL_recdata["rec_data02"] = searchResult;
							}

							foreach (DataRow row in containerWorkSet.Rows)
							{
								string bccCode = containerWorkSet.Columns.Contains("set_code") ? Convert.ToString(row["set_code"]) : string.Empty;
								if (!string.IsNullOrEmpty(bccCode) && !BarCodeHelper.IsTempSet(bccCode) && !nextPds.ContainsKey(bccCode))
									nextPds.Add(bccCode, strnext_code);
							}

							string strrec10 = this.CreateNextWorkorderUnLoadContainer(struser_id, strcurrent_code, nextPds, str_Containercode, null, sl_par02, sl_parinfo, confirmDialogParams, containerWorkSet);
							if (strrec10 == "0")
							{
								SL_recdata["rec_result"] = 0;
								SL_recdata["rec_data02"] = "提交手术包到下一流程【" + struser_id + "】成功。";
							}
							else
							{
								SL_recdata["rec_result"] = 201;
								SL_recdata["rec_data02"] = "提交包到下一步流程失败。" + strrec10;
							}
							return SL_recdata;
						}
					}
					else
					{
						SL_recdata["rec_result"] = 101;
						SL_recdata["rec_data01"] = "工单手动处理配置错误，退回的流程【" + strnext_code + "】不符合规定，请联系管理员。";
					}

				}
				else
				{
					SL_recdata["rec_result"] = 101;
					SL_recdata["rec_data01"] = "工单数据被修改，系统错误，请联系管理员。";
				}
				return SL_recdata;
				#endregion

			}
			else
			{
				SL_recdata["rec_result"] = 101;
				SL_recdata["rec_data01"] = "没有研发该参数，请联系管理员。";
				return SL_recdata;
			}
		}

		/// <summary>
		/// 获取打印代码参数
		/// </summary>
		/// <param name="in_barcode"></param>
		/// <param name="sl_par01"></param>
		/// <param name="sl_par02"></param>
		/// <returns></returns>
		public SortedList Get_BarCode_PrintData(string in_barcode, SortedList sl_par01, SortedList sl_par02)
		{
			SortedList sl_rec = new SortedList();
			sl_rec.Add("xml", "");
			sl_rec.Add("data", null);
			string str_bcx = in_barcode.Substring(0, 3);
			DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='" + str_bcx + "'");
			string strbarcodexml = arrayDR02[0]["other_code"].ToString().Trim();
			sl_rec["xml"] = strbarcodexml;
			if (str_bcx == "BCU")
			{
				SortedList sltmp = new SortedList();
				sltmp.Add("BarcodeValue", in_barcode);
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(strbarcodexml);
				string parameterName = string.Empty; string parameterValue = string.Empty;
				XmlNodeList BarcodeAddDataXML = xmlDoc.SelectNodes("/Data/BarcodeAddData/BarcodeAdd");
				for (int i = 0; i < BarcodeAddDataXML.Count; i++)
				{
					parameterName = BarcodeAddDataXML[i]["Name"].InnerXml;
					parameterValue = string.Empty;
					if (sl_par01 != null && i < sl_par01.Count)
						parameterValue = Convert.ToString(sl_par01.GetByIndex(i));
					sltmp.Add(parameterName, parameterValue);
				}
				sl_rec["data"] = sltmp;

				return sl_rec;
				//sltmp.Add("set_name", str_name);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 更新加急状态
		/// </summary>
		public void UpUrgent(bool isDone)
		{
			isDone = false;
			try
			{
				//doing ...
				//查出所有流通中的包以及所需包的最小数量
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				if (true)
				{
					reCnasRemotCall.RemotInterface.ExecuteProcedure("Proc_UrgentSet", new SortedList());
				}
				else
				{
					//string testAllSetNum = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec029", null);
					DataTable dtAllSetNum = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec029", null);
					//查询可加急的包(暂定在流程点4020后的包)
					//string testCssdSet = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec030", null);
					DataTable dtCssdSet = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec030", null);

					SortedList needChangeUrgent = new SortedList();
					int count = 1;
					if (dtAllSetNum != null && dtCssdSet != null)
					{
						foreach (DataRow itemAll in dtAllSetNum.Rows)
						{
							string itemAll_base_setcode = Convert.ToString(itemAll["base_setcode"]);
							string itemAll_allNum = Convert.ToString(itemAll["allNum"]);
							string itemAll_minimum_set = Convert.ToString(itemAll["minimum_set"]);
							int allNum, minimum_set;
							Int32.TryParse(itemAll_allNum, out allNum);
							Int32.TryParse(itemAll_minimum_set, out minimum_set);
							DataRow[] arrayCssdSet = dtCssdSet.Select("base_setcode='" + itemAll_base_setcode + "'");
							if (arrayCssdSet != null && arrayCssdSet.Length > 0 && allNum < minimum_set + arrayCssdSet.Length)
							{
								foreach (DataRow itemPart in arrayCssdSet)
								{
									string temp_urgent = Convert.ToString(itemPart["urgent"]);
									if (!temp_urgent.Equals("1"))
									{
										SortedList part_need = new SortedList();
										part_need.Add(1, 1);
										part_need.Add(2, Convert.ToString(itemPart["set_code"]));
										needChangeUrgent.Add(count, part_need);
										count++;
									}
								}
							}
						}
						if (count > 1)
						{
							//string testUpData = reCnasRemotCall.RemotInterface.CheckUPDataList("HCS-set-up002", needChangeUrgent);
							int result = reCnasRemotCall.RemotInterface.UPDataList("HCS-set-up002", needChangeUrgent);
							if (result > 0)
							{
								Logger.Info(string.Format("本次需更新数量：{0},已更新{1}条", needChangeUrgent.Count, result));
							}
						}
					}
				}

				isDone = true;
			}
			catch(Exception ex)
			{
				Logger.Info(string.Format("Trace:{0}", ex.StackTrace));
				//出现异常是否需要继续执行
				//isDone = true;
			}
			
		}

	}
}
