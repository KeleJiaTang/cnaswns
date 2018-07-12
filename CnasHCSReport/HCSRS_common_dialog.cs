using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using CnasUI;
using Cnas.wns.CnasBaseUC;
using Telerik.WinControls.UI;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_common_dialog : ReportBaseForm
    {
        ///// <summary>
        ///// 查询类型
        ///// </summary>
        //SortedList Sl_type = new SortedList();
        //RadGridView dgv = new RadGridView();
        public HCSRS_common_dialog()
            : base()
        {
            InitializeComponent();
            #region  
            this.bnt_print.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "printCode", EnumImageType.PNG);
            bnt_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            but_sel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "select_big", EnumImageType.PNG);
            #endregion
        }

        private void cb_indicator_TextChanged(object sender, EventArgs e)
        {
            if (endTimePicker.Value < startTimePicker.Value && !string.IsNullOrEmpty(startTimePicker.Text)
                && !string.IsNullOrEmpty(endTimePicker.Text))
            {
                RadDateTimePicker currentPicker = sender as RadDateTimePicker;
                if (currentPicker != null)
                {
                    if (currentPicker.Name == "startTimePicker")
                    {
                        MessageBox.Show("你好，你设置的开始时间有误。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("你好。你设置的结束时间有误。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (bnt_print.Visible == true)
            {
                PrintOrDisplay(false);//不显示窗体
            }

        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="IsShowFrom">是否显示窗体</param>
        /// <param name="ValueStar">开始时间</param>
        /// <param name="Format">时间格式</param>
        /// <param name="ValueEnd">结束时间</param>
        void LoadData(bool IsShowFrom, string ValueStar, string Format, string ValueEnd)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList bb = new SortedList();
            bb.Add("firstTime", ValueStar);
            bb.Add("format", Format);
            bb.Add("lastTime", ValueEnd);
            DataSet result = reCnasRemotCall.RemotInterface.ExecuteProcedure(IndicatorType, bb);
            if (result == null)
            {
                MessageBox.Show("此项没有数据。","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
            DataTable DtContents = result.Tables[0];
            dgv.DataSource = result.Tables[0] as object;//赋值打印数据给dgv
            if (IsShowFrom)//判断是否显示
            {
                HCSRS_statistical_index hh = new HCSRS_statistical_index(DtContents, IndicatorType, FormName);
               // hh.StartPosition = FormStartPosition.CenterParent;
                hh.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 直接打印或显示窗体
        /// </summary>
        /// <param name="isShow">是否显示窗体</param>
        void PrintOrDisplay(bool isShow)
        {
            if (searchTypeCbx.SelectedItem.Value == null) return;
            if (searchTypeCbx.SelectedItem.Value.ToString() == "2")//年
            {
                LoadData(isShow, startTimePicker.Value.Year + "-01-01", "%Y", endTimePicker.Value.Year == startTimePicker.Value.Year ? endTimePicker.Value.Year + "-12-31" : endTimePicker.Value.Year + "-01-01");
                return;
            }
            if (searchTypeCbx.SelectedItem.Value.ToString() == "3")//月
            {
                LoadData(isShow, startTimePicker.Value.ToString(), "%Y-%m", endTimePicker.Value.ToString());
                return;
            }
            if (searchTypeCbx.SelectedItem.Value.ToString() == "4")//日
            {
                LoadData(isShow, startTimePicker.Value.ToString(), "%Y-%m-%d", endTimePicker.Value.ToString());
                return;
            }
            if (searchTypeCbx.SelectedItem.Value.ToString() == "1")//时间段
            {
                LoadData(isShow, startTimePicker.Value.ToString(), startTimePicker.Value + "--" + endTimePicker.Value, endTimePicker.Value.ToString());
                return;
            }
        }

        private void but_sel_Click(object sender, EventArgs e)
        {
            PrintOrDisplay(true);//显示窗体
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_print_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS-print-type' and key_code=" + "'" + IndicatorType + "'");
            string pringxml = arrayDR02[0]["other_code"].ToString().Trim();
            RadPrintHelper RadPrintHelper = new CnasBaseClassClient.RadPrintHelper();
            RadPrintHelper.Print_DataGridView(dgv, pringxml);
        }

        private void bnt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 加载窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCSRS_common_dialog_Load(object sender, EventArgs e)
        {
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-time-search-type'");//时间
            if (arrayDR.Length < 0) return;
            foreach (DataRow item in arrayDR)
            {
                if (item["key_code"].ToString() != null && item["value_code"].ToString().Trim() != null)
                {
                    RadListDataItem cbxItem = new RadListDataItem(item["value_code"].ToString().Trim(), item["key_code"].ToString().Trim());
                    searchTypeCbx.Items.Add(cbxItem);
                }
                searchTypeCbx.SelectedIndex = 0;
            }
			DateTime currentDate = DateTime.Now;
			endTimePicker.Value = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day).AddDays(1).AddMilliseconds(-1);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--" + FormName;
            Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
        }

        private void searchTypeCbx_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
			string selectedValue = Convert.ToString(searchTypeCbx.SelectedItem.Value);
			DateTime currentDate = DateTime.Now;
			endTimePicker.Value = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day).AddDays(1).AddMilliseconds(-1);
			switch (selectedValue)
			{
				case "1":
				case "4":
					{
						startTimePicker.Format = DateTimePickerFormat.Custom;
						startTimePicker.CustomFormat = "yyyy年MM月dd日";
						endTimePicker.Format = DateTimePickerFormat.Custom;
						endTimePicker.CustomFormat = "yyyy年MM月dd日";
						if (endTimePicker.Value != null)
							startTimePicker.Value = endTimePicker.Value.AddDays(-30);
					}
					break;
				case "2":
					{
						startTimePicker.Format = DateTimePickerFormat.Custom;
						startTimePicker.CustomFormat = "yyyy年";
						endTimePicker.Format = DateTimePickerFormat.Custom;
						endTimePicker.CustomFormat = "yyyy年";
						if (endTimePicker.Value != null)
							startTimePicker.Value = endTimePicker.Value.AddYears(-1);
					}
					break;
				case "3":
					{
						startTimePicker.Format = DateTimePickerFormat.Custom;
						startTimePicker.CustomFormat = "yyyy年MM月";
						endTimePicker.Format = DateTimePickerFormat.Custom;
						endTimePicker.CustomFormat = "yyyy年MM月";
						if (endTimePicker.Value != null)
							startTimePicker.Value = endTimePicker.Value.AddMonths(-6);
					}
					break;
				default:
					break;
			}
        }
    }
}
