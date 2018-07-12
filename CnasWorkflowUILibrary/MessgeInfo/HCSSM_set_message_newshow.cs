using Cnas.wns.CnasBaseClassClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSSM_set_message_newshow : BaseForm
	{
		/// <summary>
		/// 当前区域的流程
		/// </summary>
		private string _appPds = string.Empty;

		/// <summary>
		/// 当前操作者id(工作台赋值)
		/// </summary>
		public string UserId;

		public bool HasSetMessage { get; set; }

		/// <summary>
		/// 初始化win
		/// </summary>
		//public HCSSM_set_message_newshow()
		//{
		//	InitializeComponent();
		//	Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		//	noteListBox.ItemHeight = (int)(Math.Ceiling(noteListBox.Font.GetHeight()) * 3);
		//}

		/// <summary>
		/// 器械包备注信息窗口用于测试
		/// </summary>
		/// <param name="appPds">工作台所有的流程号</param>
		public HCSSM_set_message_newshow(string appPds) : base()
		{
			InitializeComponent();
			this._appPds = appPds;
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			noteListBox.ItemHeight = (int)(Math.Ceiling(noteListBox.Font.GetHeight()) * 3);
		}

		/// <summary>
		/// 器械包备注信息窗口用于测试
		/// </summary>
		/// <param name="pdCode">窗口所在流程编号</param>
		//public HCSSM_set_message_newshow(string pdCode)
		//	: base(pdCode)
		//{
		//	InitializeComponent();
		//	Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
		//	noteListBox.ItemHeight = (int)(Math.Ceiling(noteListBox.Font.GetHeight()) * 3);
		//	//GenerateListBoxItem();
		//}

		public override void InitializeButtonImage()
		{
 			base.InitializeButtonImage();
			btnDisable.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mStopWarning32", EnumImageType.PNG);
			btnDel.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mDelete32", EnumImageType.PNG);
			refreshBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRefresh32", EnumImageType.PNG);
			closeBtn.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose32", EnumImageType.PNG);
		}

		public void GenerateListBoxItem()
		{
			noteListBox.Items.Clear();
			SortedList dataItem = GetDataOfSetAndMessage();
			if (dataItem != null && dataItem.Count > 0)
			{
				for (int i = 0; i < dataItem.Count; i++)
				{
					Dictionary<string, string> dic = dataItem.GetByIndex(i) as Dictionary<string, string>;
					if (dic != null)
					{
						noteListBox.Items.Add(dic);
					}
				}
				HasSetMessage = true;
			}
			else
			{
				HasSetMessage = false;
			}
		}
		/// <summary>
		/// 获取所有的数据
		/// </summary>
		/// <param name="barcodeList"></param>
		/// <returns></returns>
		private SortedList GetDataOfSetAndMessage()
		{
			try
			{
				SortedList itemList = new SortedList();
				SortedList condition = new SortedList();
				condition.Add(1, _appPds);
				Dictionary<string, string> packageInfo;
				//包的信息
				string testpackageInfo = RemoteClient.RemotInterface.CheckSelectData("HCS-set-sec010", condition);
				DataTable datapackageInfo = RemoteClient.RemotInterface.SelectData("HCS-set-sec010", condition);

				//包的消息
				string testmessageInfo = RemoteClient.RemotInterface.CheckSelectData("HCS-set-message-info-sec001", condition);
				DataTable datamessageInfo = RemoteClient.RemotInterface.SelectData("HCS-set-message-info-sec001", condition);
				
				if (datamessageInfo != null && datamessageInfo.Rows.Count > 0 && datapackageInfo != null && datapackageInfo.Rows.Count > 0)
				{
					List<string> messageSet = new List<string>();
					foreach (DataRow messagerow in datamessageInfo.Rows)
					{
						string setCode = Convert.ToString(messagerow["set_code"]);
						string noteConfigStr = Convert.ToString(messagerow["note_procedure"]);
						DataRow[] setRowInfo= datapackageInfo.Select(string.Format("bar_code ='{0}'", setCode));
						if (setRowInfo != null && setRowInfo.Length > 0 && ForCheckNeedNote(noteConfigStr))
						{
							DataRow setRow = setRowInfo[0];
							if (!messageSet.Contains(setCode))
							{
								
								packageInfo = new Dictionary<string, string>();
								string displayString = string.Format("器械包码：   {0}\t器械包名：   {1}\r\n", setRow["bar_code"], setRow["ca_name"]);
								displayString += string.Format("优  先  级：   {0}\r\n", setRow["pa_priorty"]);
								displayString += string.Format("类        型：   {0}\r\n", setRow["pa_type"]);
								packageInfo.Add("packagetitle", "器械包");
								//packageInfo.Add("id", setRow["id"].ToString());
								packageInfo.Add("bar_code", setRow["bar_code"].ToString());
								packageInfo.Add("base_setcode", setRow["base_setcode"].ToString());
								packageInfo.Add("ca_name", setRow["ca_name"].ToString());
								packageInfo.Add("pa_type", setRow["pa_type"].ToString());
								//packageInfo.Add("department_id", setRow["department_id"].ToString());
								//packageInfo.Add("cre_date", setRow["cre_date"].ToString());
								//packageInfo.Add("st_pr_Name", setRow["st_pr_Name"].ToString());
								//packageInfo.Add("wa_pr_Name", setRow["wa_pr_Name"].ToString());
								//packageInfo.Add("cost_center_name", setRow["cost_center_name"].ToString());
								packageInfo.Add("pa_priorty", setRow["pa_priorty"].ToString());
								packageInfo.Add("DisplayString", displayString);

								itemList.Add(itemList.Count + 1, packageInfo);
								messageSet.Add(setCode);
							}

							Dictionary<string, string> messageInfo = new Dictionary<string, string>();
							if (!(messagerow["mod_date"] is DBNull))
								messageInfo.Add("mod_date", Convert.ToDateTime(messagerow["mod_date"]).ToString("yyyy-MM-dd HH:mm"));
							else
								messageInfo.Add("mod_date", string.Empty);
							if (!(messagerow["end_date"] is DBNull))
								messageInfo.Add("end_date", Convert.ToDateTime(messagerow["end_date"]).ToString("yyyy-MM-dd HH:mm"));
							else
								messageInfo.Add("end_date", string.Empty);
							messageInfo.Add("start_date", Convert.ToDateTime(messagerow["start_date"]).ToString("yyyy-MM-dd HH:mm"));

							string messageDisplayString = string.Format("        信息主题：   {0}\r\n", messagerow["subject"]);
							messageDisplayString += string.Format("        开始时间：   {0}\t结束时间：\t{1}\r\n", messageInfo["start_date"], messageInfo["end_date"]);
							messageDisplayString += string.Format("        信息详情：   {0}\r\n", messagerow["description"]);
							messageInfo.Add("bar_code", setCode);//记录条码
							messageInfo.Add("messagetitle", "器械包消息");//表示为消息
							messageInfo.Add("id", messagerow["id"].ToString());
							messageInfo.Add("set_id", messagerow["set_id"].ToString());
							messageInfo.Add("subject", messagerow["subject"].ToString());
							messageInfo.Add("message_type", messagerow["message_type"].ToString());
							messageInfo.Add("message_priorty", messagerow["message_priorty"].ToString());
							messageInfo.Add("note_procedure", messagerow["note_procedure"].ToString());
							messageInfo.Add("description", messagerow["description"].ToString());
							messageInfo.Add("state", messagerow["state"].ToString());
							messageInfo.Add("cre_user", messagerow["cre_user"].ToString());
							messageInfo.Add("cre_date", Convert.ToDateTime(messagerow["cre_date"]).ToString("yyyy-MM-dd HH:mm"));
							messageInfo.Add("mod_user", messagerow["mod_user"].ToString());
							
							messageInfo.Add("version", messagerow["version"].ToString());
							messageInfo.Add("DisplayString", messageDisplayString);
							itemList.Add(itemList.Count + 1, messageInfo);
						}
					}

					return itemList;
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
		/// <summary>
		/// 重新绘制listbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void noteListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			
				if (noteListBox.Items.Count > 0)
				{
					Dictionary<string, string> item = noteListBox.Items[e.Index] as Dictionary<string, string>;
					if (item != null)
					{
						Rectangle bound = e.Bounds;

						if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
						{
							e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
						}
						else
						{
							if (item.ContainsKey("message_priorty") && item.ContainsKey("message_priorty"))
							{
								e.Graphics.FillRectangle(GetItemColorByPriorty(item["message_priorty"].ToString()), e.Bounds);
							}
							else if (item.ContainsKey("packagetitle"))
							{
								e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
							}
						}

						e.Graphics.DrawLine(Pens.DarkGray, bound.X, bound.Y, bound.X + bound.Width, bound.Y);
						
						Brush fontColor = Brushes.Black;
						if (item.ContainsKey("state") && item["state"] != "1")
						{
							fontColor = Brushes.Gray;
						}

						e.Graphics.DrawString(item["DisplayString"], e.Font, fontColor, bound);

						//Rectangle titleBounds = new Rectangle(bound.X + noteListBox.Margin.Horizontal,
						//							  e.Bounds.Y + noteListBox.Margin.Top,
						//							  e.Bounds.Width - noteListBox.Margin.Right - noteListBox.Margin.Horizontal,
						//							  (int)e.Font.GetHeight() + 6);
						//Rectangle timeBounds = new Rectangle(bound.X + noteListBox.Margin.Horizontal,
						//							  titleBounds.Y + noteListBox.Margin.Top + noteListBox.Margin.Vertical + (int)Math.Ceiling(e.Font.GetHeight()),
						//							  titleBounds.Width - noteListBox.Margin.Right - noteListBox.Margin.Horizontal,
						//							  (int)e.Font.GetHeight() + 6);
						//Rectangle detailBounds = new Rectangle(bound.X + noteListBox.Margin.Horizontal,
						//							  timeBounds.Y + noteListBox.Margin.Top + noteListBox.Margin.Vertical + (int)Math.Ceiling(e.Font.GetHeight()),
						//							  timeBounds.Width - noteListBox.Margin.Right - noteListBox.Margin.Horizontal,
						//							  (int)e.Font.GetHeight() + 6);
						//string displayString = string.Empty;
						//if (item.ContainsKey("messagetitle"))
						//{
						//	if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
						//	{
						//		e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
						//	}
						//	else
						//	{
						//		if (item.ContainsKey("message_priorty") && item.ContainsKey("message_priorty"))
						//		{
						//			e.Graphics.FillRectangle(GetItemColorByPriorty(item["message_priorty"].ToString()), e.Bounds);
						//		}
						//	}
						//	e.Graphics.DrawLine(Pens.DarkGray, bound.X, bound.Y, bound.X + bound.Width, bound.Y);
						//
						//	Brush fontColor = Brushes.Black;
						//	if (item.ContainsKey("state") && item["state"] != "1")
						//	{
						//		fontColor = Brushes.Gray;
						//	}
						//
						//	if (item.ContainsKey("subject"))
						//	{
						//		string subject = string.Format("        信息主题：   {0}", item["subject"]);
						//		displayString += subject;
						//		e.Graphics.DrawString(subject, e.Font, fontColor, titleBounds);
						//	}
						//	if (item.ContainsKey("start_date"))
						//	{
						//		string endtimeStr = GetValueStr(item["end_date"]);
						//		string drawString = string.Format("        开始时间：   {0}\t结束时间：\t{1}", item["start_date"], endtimeStr);
						//		displayString += drawString;
						//		e.Graphics.DrawString(drawString, e.Font, fontColor, timeBounds);
						//	}
						//	if (item.ContainsKey("description"))
						//	{
						//		string drawString = string.Format("        信息详情：   {0}", item["description"]);
						//		displayString += drawString;
						//		e.Graphics.DrawString(drawString, e.Font, fontColor, detailBounds);
						//	}
						//
						//	if (!item.ContainsKey("DisplayString"))
						//		item.Add("DisplayString", displayString);
						//}
						//else if (item.ContainsKey("packagetitle"))
						//{
						//	e.Graphics.FillRectangle(Brushes.Gold, e.Bounds);
						//	e.Graphics.DrawLine(Pens.DarkGray, bound.X, bound.Y, bound.X + bound.Width, bound.Y);
						//	Brush fontColor = Brushes.Black;
						//	if (item.ContainsKey("bar_code") && item.ContainsKey("ca_name"))
						//	{
						//		string drawString = string.Format("器械包码：\t{0}\t器械包名：\t{1}", item["bar_code"], item["ca_name"]);
						//		displayString += drawString;
						//		e.Graphics.DrawString(drawString, e.Font, fontColor, titleBounds);
						//	}
						//	if (item.ContainsKey("pa_priorty"))
						//	{
						//		string drawString = string.Format("优  先  级：{0}", item["pa_priorty"]);
						//		displayString += drawString;
						//		e.Graphics.DrawString(drawString, e.Font, fontColor, timeBounds);
						//	}
						//	if (item.ContainsKey("pa_type"))
						//	{
						//		string drawString = string.Format("类        型：\t{0}", item["pa_type"]);
						//		displayString += drawString;
						//		e.Graphics.DrawString(displayString, e.Font, fontColor, detailBounds);
						//	}
						//
						//	if (!item.ContainsKey("DisplayString"))
						//		item.Add("DisplayString", displayString);
						//}
						e.DrawFocusRectangle();
					}

				}

		}

		private void OnMeasureItemEvent(object sender, MeasureItemEventArgs e)
		{
			ListBox listBox = sender as ListBox;
			if (e.Index >= 0 && listBox != null)
			{
				Dictionary<string, string> item = listBox.Items[e.Index] as Dictionary<string, string>;
				if (item != null && item.ContainsKey("DisplayString"))
				{
					SizeF displayStringSize = e.Graphics.MeasureString(item["DisplayString"], listBox.Font);
					e.ItemHeight = (int)Math.Ceiling(displayStringSize.Height);
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="priorty">the message's priorty</param>
		/// <returns>the priorty's color</returns>
		private Brush GetItemColorByPriorty(string priorty)
		{
			Brush result = Brushes.Gray;
			switch (priorty)
			{
				case "1":
					result = Brushes.White;
					break;
				case "2":
					result = Brushes.YellowGreen;
					break;
				case "3":
					result = Brushes.Yellow;
					break;
				default:
					break;
			}
			return result;
		}

		/// <summary>
		/// 将obj的值转化为string
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		private string GetValueStr(object obj)
		{
			if (obj == null)
				return string.Empty;
			return obj.ToString();
		}

		/// <summary>
		/// 验证提醒节点是否在当前区域且有有效消息
		/// </summary>
		/// <param name="noteConfigStr"></param>
		/// <param name="noteWriteStr"></param>
		/// <returns></returns>
		private bool ForCheckNeedNote(string noteConfigStr)
		{
			string noteStr = noteConfigStr;
			string[] noteArr = noteStr.Split(',');
			string[] pcConfigArr = _appPds.Replace("'", "").Split(',');
			for (int i = 0; i < pcConfigArr.Count(); i++)
			{
				//此处要改
				string str = pcConfigArr[i];
				foreach (string item in noteArr)
				{
					if (item.Equals(str))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// 删除提醒
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDel_Click(object sender, EventArgs e)
		{
			btnDisable.Enabled = false;
			int state = 9;
			ChangceItemEvent(state);
			btnDisable.Enabled = true;
		}

		/// <summary>
		/// 禁止提醒
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDisable_Click(object sender, EventArgs e)
		{
			btnDisable.Enabled = false;
			int state = 2;
			ChangceItemEvent(state);
			btnDisable.Enabled = true;
		}
		/// <summary>
		/// item改变事件
		/// </summary>
		/// <param name="state"></param>
		private void ChangceItemEvent(int state)
		{
			if (noteListBox.SelectedItem != null)
			{
				Dictionary<string, string> dic = noteListBox.SelectedItem as Dictionary<string, string>;
				if (dic != null)
				{
					if (dic.ContainsKey("messagetitle"))
					{
						string messageId = dic["id"].ToString();
						SortedList sqlParam = new SortedList();
						SortedList itemList = new SortedList();
						itemList.Add(1, state);
						itemList.Add(2, UserId);
						itemList.Add(3, messageId);
						sqlParam.Add(1, itemList);
						string testSql = RemoteClient.RemotInterface.CheckUPData(1, "HCS-set-message-info-show-up001", sqlParam, null);
						int result = RemoteClient.RemotInterface.UPData(1, "HCS-set-message-info-show-up001", sqlParam, null);
						if (result > -1)
						{
							int nowIndex = noteListBox.SelectedIndex;
							int backIndex = nowIndex - 1;
							int nextIndex = nowIndex+ 1;
							if(backIndex>=0)
							{
								Dictionary<string, string> backdic = noteListBox.Items[backIndex] as Dictionary<string, string>;
								bool isExitNext = false;
								if(nextIndex<noteListBox.Items.Count)
								{
									Dictionary<string, string> nextdic = noteListBox.Items[nextIndex] as Dictionary<string, string>;
									if (nextdic.ContainsKey("messagetitle"))
									{
										isExitNext = true;
									}
									else
									{
										isExitNext = false;
									}
								}
								if (backdic.ContainsKey("messagetitle")||isExitNext)
								{
									noteListBox.Items.RemoveAt(noteListBox.SelectedIndex);
								}
								else
								{
									noteListBox.Items.RemoveAt(noteListBox.SelectedIndex);
									noteListBox.Items.RemoveAt(backIndex);
									
									
								}
							}
							if (noteListBox.Items.Count == 0)
							{
								Close();
							}
						}
						else
						{
							MessageBox.Show("保存失败，请验证你所输入的内容。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}
		}

		/// <summary>
		/// 刷新事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			noteListBox.Items.Clear();
			SortedList dataItem = GetDataOfSetAndMessage();
			if (dataItem != null && dataItem.Count > 0)
			{
				for (int i = 0; i < dataItem.Count; i++)
				{
					Dictionary<string, string> dic = dataItem.GetByIndex(i) as Dictionary<string, string>;
					if (dic != null)
					{
						noteListBox.Items.Add(dic);
					}
				}
			}
			if(noteListBox.Items.Count==0)
			{
				Close();
			}
		}


		private void noteListBox_Click(object sender, EventArgs e)
		{
			if (noteListBox.SelectedItem!=null)
			{
				Dictionary<string, string> dic = noteListBox.SelectedItem as Dictionary<string, string>;
				if(!dic.ContainsKey("messagetitle"))
				{
					int nextIndex = noteListBox.SelectedIndex + 1;
					if(nextIndex<noteListBox.Items.Count)
					{
						noteListBox.ClearSelected();
						noteListBox.SelectedIndex = nextIndex;
					}
				}
			}
		}

		private void OnCloseBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}


		
		
	}
}
