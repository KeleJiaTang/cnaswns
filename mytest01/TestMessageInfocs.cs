using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasWorkflowUILibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mytest01
{
	public partial class TestMessageInfocs : Form
	{
		public TestMessageInfocs()
		{

			InitializeComponent();
			CnasRemotCall remoteClient = new CnasRemotCall();
			CnasBaseData.SystemBaseData = remoteClient.RemotInterface.SelectData("HCS-systemdata-sec001", null);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			HCSSM_set_message_new testDialog = new HCSSM_set_message_new(1, "3012");
			testDialog.PackageBarCode = "BCC0000000154";
			testDialog.UserBarCode = "BCB0000000016";
			testDialog.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			HCSSM_set_message_new testDialog = new HCSSM_set_message_new(2, "2020");
			testDialog.PackageBarCode = "BCC0000000154";
			testDialog.UserBarCode = "BCB0000000016";
			testDialog.MessageId = 118;
			testDialog.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			HCSSM_set_message_new testDialog = new HCSSM_set_message_new(3, "2020");
			testDialog.PackageBarCode = "BCC0000000154";
			testDialog.UserBarCode = "BCB0000000016";
			testDialog.MessageId = 118;
			testDialog.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			
		}

		private void button5_Click(object sender, EventArgs e)
		{
			HCSSM_set_message_manager temp = new HCSSM_set_message_manager();
			temp.User_bCode = "BCB0000000016";
			temp.Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			HCSWF_set_device_release test = new HCSWF_set_device_release();
			//test.PdCode = "BCV0000003010";
			//test.UserCode = "BCB0000000001";
			//test.MachineCode = "BCW0000000041";
			test.PdCode = "BCV0000004010";

			string tempStr = string.Format("是否释放你选中的模式：{0} \r\n" ,test.ConfirmMode);
			string sb = string.Empty;
			//if (test.BarCodeList != null)
			//{
			//	for (int i = 0; i < test.BarCodeList.Count; i++)
			//	{
			//		object tempDic = test.BarCodeList.GetByIndex(i);
			//		sb = sb + tempDic.ToString() + ",";
			//	}
			//	tempStr = tempStr + string.Format("其中包码有：{0}", sb);
			//}
			MessageBox.Show(tempStr);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			//HCSWF_set_device_load test = new HCSWF_set_device_load();
			//test.ShowDialog();
			SortedList condition = new SortedList();
			string temp = "BCB0000000001,BCV0000002020,BCC0000000179";
			string[] strList = temp.Split(',');
			for(int i=0;i<strList.Count();i++)
			{
				condition.Add(strList[i], strList[i].Substring(0,3));
			}
			HCSWF_set_detail test = new HCSWF_set_detail(condition);
			test.ShowDialog();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			SortedList scanCodes = new SortedList();
			CnasBaseData.SystemID = "1";

			if (!string.IsNullOrEmpty(paramTxt.Text))
			{
				string[] scanCode = paramTxt.Text.Split(',');
				for (int i = 0; i < scanCode.Length; i++)
				{
					scanCodes.Add(scanCode[i], scanCode[i].Substring(0,3));
				}

				HCSWF_dialog_container form = new HCSWF_dialog_container(scanCodes);
				//BaseForm form = WorkFlowDialogGenerator.Instance.GeneratorForm(scanCodes);

				form.ShowDialog();
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			//string testSQL = "update hcs_work_set set status='?', remark='?' where id ='?';#"+
			//		"update hcs_set_message_info set state='?', description='?', subject='?' where id='?' #" +
			//		"update hcs_set set ca_name='?' where id='?' ";
			string testSQL = "update hcs_work_set set status='?', remark='?' where id ='?';";
			
			SortedList parameters = new SortedList();
			SortedList param01 = new SortedList();

			SortedList pa11 = new SortedList();
			pa11.Add(1, "9");
			pa11.Add(2, "Remark test1");
			pa11.Add(3, "1");
			param01.Add(1, pa11);

			SortedList pa12 = new SortedList();
			pa12.Add(1, "8");
			pa12.Add(2, "Remark test2222222");
			pa12.Add(3, "2");
			param01.Add(2, pa12);

			SortedList pa13 = new SortedList();
			pa13.Add(1, "3");
			pa13.Add(2, "Remark test333333333");
			pa13.Add(3, "3");
			param01.Add(3, pa13);


			SortedList param02 = new SortedList();

			SortedList pa21 = new SortedList();
			pa21.Add(1, "1");
			pa21.Add(2, "Subject 120");
			pa21.Add(3, "Description 120");
			pa21.Add(4, "120");
			param02.Add(1, pa21);

			SortedList pa22 = new SortedList();
			pa22.Add(1, "1");
			pa22.Add(2, "Subject 121");
			pa22.Add(3, "Description 121");
			pa22.Add(4, "121");
			param02.Add(2, pa22);

			SortedList pa23 = new SortedList();
			pa23.Add(1, "1");
			pa23.Add(2, "Subject 122");
			pa23.Add(3, "Description 122");
			pa23.Add(4, "122");
			param02.Add(3, pa23);
			SortedList pa24 = new SortedList();
			pa24.Add(1, "1");
			pa24.Add(2, "Subject 123");
			pa24.Add(3, "Description 123");
			pa24.Add(4, "123");
			param02.Add(4, pa24);


			SortedList param03 = new SortedList();
			SortedList pa31 = new SortedList();
			pa31.Add(1, "特殊器械包《《BCCS2");
			pa31.Add(2, "96");
			param03.Add(1, pa31);

			SortedList pa32 = new SortedList();
			pa32.Add(1, "特殊器械包BCCS1》》");
			pa32.Add(2, "97");
			param03.Add(2, pa32);


			parameters.Add(1, param01);
			//parameters.Add(2, param02);
			//parameters.Add(3, param03);

			CnasRemotCall remote = new CnasRemotCall();
			CnasBaseData.SystemID = "1";
			string resultSQl = remote.RemotInterface.CheckUPDataList(testSQL, parameters);

		}

		private void button10_Click(object sender, EventArgs e)
		{
			string testSQL = "update hcs_work_set set status='?', remark='?' where id ='?';#"+
					"update hcs_set_message_info set state='?', description='?', subject='?' where id='?' #" +
					"update hcs_set set ca_name='?' where id='?' ";

			SortedList parameters = new SortedList();
			SortedList param01 = new SortedList();

			SortedList pa11 = new SortedList();
			pa11.Add(1, "9");
			pa11.Add(2, "Remark test1");
			pa11.Add(3, "1");
			param01.Add(1, pa11);

			SortedList pa12 = new SortedList();
			pa12.Add(1, "8");
			pa12.Add(2, "Remark test2222222");
			pa12.Add(3, "2");
			param01.Add(2, pa12);

			SortedList pa13 = new SortedList();
			pa13.Add(1, "3");
			pa13.Add(2, "Remark test333333333");
			pa13.Add(3, "3");
			param01.Add(3, pa13);


			SortedList param02 = new SortedList();

			SortedList pa21 = new SortedList();
			pa21.Add(1, "1");
			pa21.Add(2, "Subject 120");
			pa21.Add(3, "Description 120");
			pa21.Add(4, "120");
			param02.Add(1, pa21);

			SortedList pa22 = new SortedList();
			pa22.Add(1, "1");
			pa22.Add(2, "Subject 121");
			pa22.Add(3, "Description 121");
			pa22.Add(4, "121");
			param02.Add(2, pa22);

			SortedList pa23 = new SortedList();
			pa23.Add(1, "1");
			pa23.Add(2, "Subject 122");
			pa23.Add(3, "Description 122");
			pa23.Add(4, "122");
			param02.Add(3, pa23);
			SortedList pa24 = new SortedList();
			pa24.Add(1, "1");
			pa24.Add(2, "Subject 123");
			pa24.Add(3, "Description 123");
			pa24.Add(4, "123");
			param02.Add(4, pa24);


			SortedList param03 = new SortedList();
			SortedList pa31 = new SortedList();
			pa31.Add(1, "特殊器械包《《BCCS2");
			pa31.Add(2, "96");
			param03.Add(1, pa31);

			SortedList pa32 = new SortedList();
			pa32.Add(1, "特殊器械包BCCS1》》");
			pa32.Add(2, "97");
			param03.Add(2, pa32);


			parameters.Add(1, param01);
			parameters.Add(2, null);
			//parameters.Add(3, param03);

			CnasRemotCall remote = new CnasRemotCall();
			string resultSQl = remote.RemotInterface.CheckUPDataList(testSQL, parameters);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			string testSQL = "update hcs_work_set set status='?', remark='?' where id ='?';#" +
					"update hcs_set_message_info set state='?', description='?', subject='?' where id='?' #" +
					"update hcs_set set ca_name='?' where id='?' ";

			SortedList parameters = new SortedList();
			SortedList param01 = new SortedList();

			SortedList pa11 = new SortedList();
			pa11.Add(1, "9");
			pa11.Add(2, "Remark test1");
			pa11.Add(3, "1");
			param01.Add(1, pa11);

			SortedList pa12 = new SortedList();
			pa12.Add(1, "8");
			pa12.Add(2, "Remark test2222222");
			pa12.Add(3, "2");
			param01.Add(2, pa12);

			SortedList pa13 = new SortedList();
			pa13.Add(1, "3");
			pa13.Add(2, "Remark test333333333");
			pa13.Add(3, "3");
			param01.Add(3, pa13);


			SortedList param02 = new SortedList();

			SortedList pa21 = new SortedList();
			pa21.Add(1, "1");
			pa21.Add(2, "Subject 120");
			pa21.Add(3, "Description 120");
			pa21.Add(4, "120");
			param02.Add(1, pa21);

			SortedList pa22 = new SortedList();
			pa22.Add(1, "1");
			pa22.Add(2, "Subject 121");
			pa22.Add(3, "Description 121");
			pa22.Add(4, "121");
			param02.Add(2, pa22);

			SortedList pa23 = new SortedList();
			pa23.Add(1, "1");
			pa23.Add(2, "Subject 122");
			pa23.Add(3, "Description 122");
			pa23.Add(4, "122");
			param02.Add(3, pa23);
			SortedList pa24 = new SortedList();
			pa24.Add(1, "1");
			pa24.Add(2, "Subject 123");
			pa24.Add(3, "Description 123");
			pa24.Add(4, "123");
			param02.Add(4, pa24);


			SortedList param03 = new SortedList();
			SortedList pa31 = new SortedList();
			pa31.Add(1, "特殊器械包《《BCCS2");
			pa31.Add(2, "96");
			param03.Add(1, pa31);

			SortedList pa32 = new SortedList();
			pa32.Add(1, "特殊器械包BCCS1》》");
			pa32.Add(2, "97");
			param03.Add(2, pa32);


			parameters.Add(1, param01);
			//parameters.Add(2, param02);
			parameters.Add(3, param03);

			CnasRemotCall remote = new CnasRemotCall();
			string resultSQl = remote.RemotInterface.CheckUPDataList(testSQL, parameters);
		}

		private void sqlTestBtn04_Click(object sender, EventArgs e)
		{
			string testSQL = "update hcs_work_set set status='?', remark='?' where id ='?';";

			SortedList parameters = new SortedList();
			SortedList param01 = new SortedList();

			SortedList pa11 = new SortedList();
			pa11.Add(1, "9");
			pa11.Add(2, "Remark test1");
			pa11.Add(3, "1");
			param01.Add(1, pa11);

			SortedList pa12 = new SortedList();
			pa12.Add(1, "8");
			pa12.Add(2, "Remark test2222222");
			pa12.Add(3, "2");

			parameters.Add(1, pa11);
			parameters.Add(2, pa12);

			CnasRemotCall remote = new CnasRemotCall();
			string resultSQl = remote.RemotInterface.CheckUPDataList(testSQL, parameters);
		}

		private void modifySet_Click(object sender, EventArgs e)
		{
			HCSWF_set_instrument_modify modifyDialog = new HCSWF_set_instrument_modify("BCCS300000196");
			modifyDialog.ShowDialog();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			CnasRemotCall aa = new CnasRemotCall();
			SortedList bb = new SortedList();
			bb.Add("firstTime", "2016-5-1");
			bb.Add("laseTime", "2016-5-31");
			bb.Add("errortype", "6");
			var result = aa.RemotInterface.ExecuteProcedure("aa", bb);
		}
	}
}
