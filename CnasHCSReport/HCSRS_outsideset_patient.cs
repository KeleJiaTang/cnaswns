using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using System.Configuration;
using System.Collections;
using CnasUI;

namespace Cnas.wns.CnasHCSReport
{
	public partial class HCSRS_outsideset_patient : TemplateForm
	{
		public HCSRS_outsideset_patient(SortedList setData)
		{
			InitializeComponent();
			
			this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
			this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--包详情";
			try
			{
				tb_barcode.Text = setData["barcode"].ToString();
				tb_name.Text = setData["name"].ToString();
				CnasRemotCall reCnasRemotCall = new CnasRemotCall();
				SortedList selPatient = new SortedList();
				selPatient.Add(1, setData["barcode"].ToString());
				selPatient.Add(2, setData["batch"].ToString());
				DataTable PatientData = reCnasRemotCall.RemotInterface.SelectData("HCS_work_specialset_info-sec013", selPatient);
				if (PatientData.Rows.Count > 0)
				{
					tb_patient.Text = PatientData.Rows[0]["p_name"].ToString();
					tb_age.Text = PatientData.Rows[0]["p_age"].ToString();
					if (PatientData.Rows[0]["p_sex"].ToString() == "1")
					{
						tb_sex.Text = "男";
					}
					else if (PatientData.Rows[0]["p_sex"].ToString() == "2")
					{
						tb_sex.Text = "女";
					}
					tb_ops.Text = PatientData.Rows[0]["p_operation"].ToString();
					tb_opspeople.Text = PatientData.Rows[0]["p_doctor"].ToString();
					tb_number.Text = PatientData.Rows[0]["p_Number"].ToString();
					tb_opsdate.Text = PatientData.Rows[0]["p_operation_date"].ToString();
					tb_pack.Text = PatientData.Rows[0]["pack_instrumentName"].ToString();
					tb_update.Text = PatientData.Rows[0]["check_instrumentName"].ToString();
					tb_send.Text = PatientData.Rows[0]["send_instrumentName"].ToString();
					tb_credate.Text = PatientData.Rows[0]["note_time"].ToString();
					tb_remark.Text = PatientData.Rows[0]["remark"].ToString();
					tb_vender.Text = PatientData.Rows[0]["ca_vender_name"].ToString();
					tb_moddate.Text = PatientData.Rows[0]["arrive_time"].ToString();
					tb_telephone.Text = PatientData.Rows[0]["link_number"].ToString();
				}
			}
			catch(Exception ex)
			{

			}
		}
		//打印功能
		Bitmap memoryImage;

		private void CaptureScreen()
		{
			Graphics myGraphics = this.CreateGraphics();
			Size s = this.Size;
			memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			memoryGraphics.CopyFromScreen(
		   this.Location.X, this.Location.Y, 0, 0, s);
		}
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Rectangle destRect = new Rectangle(0, 0, 1150, 770);
			e.Graphics.DrawImage(memoryImage, destRect, 0, 0, memoryImage.Width, memoryImage.Height, System.Drawing.GraphicsUnit.Pixel); //.Pixel像素
		}
		private void radButton1_Click(object sender, EventArgs e)
		{
			if (this.printDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.DefaultPageSettings.Landscape = true;    //横向打印
				CaptureScreen();
				this.printDocument1.Print();
			}
		}

		private void tb_sex_TextChanged(object sender, EventArgs e)
		{

		}

		private void but_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
