using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSReport
{
	public partial class HCSRS_outsideset_instrument : TemplateForm
	{
		public HCSRS_outsideset_instrument(SortedList setData)
		{
			InitializeComponent();
			this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
			this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--包的器械详情";
			try
			{
				tb_barcode.Text = setData["barcode"].ToString();
				tb_name.Text = setData["name"].ToString();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList selInstrument = new SortedList();
				selInstrument.Add(1, setData["barcode"].ToString());
				selInstrument.Add(2, setData["batch"].ToString());
				string ss = reCnasRemotCall.RemotInterface.CheckSelectData("HCS_work_specialset_info-sec020", selInstrument);
				DataTable InstrumentData = reCnasRemotCall.RemotInterface.SelectData("HCS_work_specialset_info-sec020", selInstrument);
				if (InstrumentData != null && InstrumentData.Rows.Count > 0)
				{
					int ii = InstrumentData.Rows.Count;
					if (ii <= 0) return;
					dgv_01.RowCount = ii;

					for (int i = 0; i < ii; i++)
					{
						if (InstrumentData.Columns.Contains("ca_name") && !string.IsNullOrEmpty(InstrumentData.Rows[i]["ca_name"].ToString())) dgv_01.Rows[i].Cells["name"].Value = InstrumentData.Rows[i]["ca_name"].ToString();
						if (InstrumentData.Columns.Contains("instrument_count") && !string.IsNullOrEmpty(InstrumentData.Rows[i]["instrument_count"].ToString())) dgv_01.Rows[i].Cells["num"].Value = InstrumentData.Rows[i]["instrument_count"].ToString();
						if (InstrumentData.Columns.Contains("send_count") && !string.IsNullOrEmpty(InstrumentData.Rows[i]["send_count"].ToString())) dgv_01.Rows[i].Cells["send_num"].Value = InstrumentData.Rows[i]["send_count"].ToString();
					}
					if (ii > 0)
					{
						dgv_01.CurrentRow = dgv_01.Rows[0];
					}
				}
			}
			catch(Exception ex)
			{

			}
		}

		private void but_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
