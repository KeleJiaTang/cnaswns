using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseInterface;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasWorkflowArithmetic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	public partial class HCSWF_specialset_pack : MetroForm
	{
		public BarCodeHook _barCodeHook = new BarCodeHook();

		public HCSWF_specialset_pack(CnasHCSWorkflowInterface workInterface, DataTable pdData, DataTable pdparameters, string appId)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			if (specialSetPacking != null)
			{
				specialSetPacking.WorkflowServer = workInterface as WorkflowArithmeticClass;
				specialSetPacking.PdData = pdData;
				specialSetPacking.Pdparameters = pdparameters;
				specialSetPacking.ScanBarCodes.Add("BCV0000003020", "BCV");
				specialSetPacking.AppId = appId;
				specialSetPacking.GenerateCheckList();
			}
			_barCodeHook.BarCodeEvent += OnBarCodeEvent;
			_barCodeHook.Start(false);
		}

		private void OnBarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);
			if (matchBarCode.Length == 13 && matchBarCode.Substring(0, 2) == "BC")
			{
				if (specialSetPacking != null)
				{
					specialSetPacking.HandleScanBarCode(matchBarCode);
				}
			}
		}

		private void OnFormClosedEvent(object sender, FormClosedEventArgs e)
		{
			 if (_barCodeHook != null)
			 {
				 _barCodeHook.Stop();
			 }

		}
	}
}
