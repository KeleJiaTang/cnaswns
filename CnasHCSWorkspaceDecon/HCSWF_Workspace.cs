using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasWorkflowUILibrary;
using CRD.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSWorkspaceDecon
{
	public partial class HCSWF_Workspace : MetroForm
	{
		public string AppId { get; set; }
		private string _appPd = string.Empty;
		public HCSWF_Workspace(string text)
		{
			InitializeComponent();
			string appId = text.Substring(0, 4);
			this.AppId = appId;
			HCSSM_workspace workSpaceControl = new HCSSM_workspace(AppId);
			this._appPd = workSpaceControl.App_pd;
			MinimumSize = new Size(1350, 800);
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			Text = string.Format("{0} — {1}", CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString(), (text.Length > 4 ? text.Substring(5) : text));
			workSpaceControl.Dock = DockStyle.Fill;
			this.Controls.Add(workSpaceControl);
			Load += OnWorkSpaceFormLoad;
			FormClosed += OnWorkSpaceFormClosed;
		}

		private void OnWorkSpaceFormLoad(object sender, EventArgs e)
		{
			Form form = sender as Form;
			if (form != null)
			{
				Win32.ReleaseCapture();
				Win32.SendMessage(form.Handle, 274, Win32.SC_MAXIMIZE, 0);
			}
			if (!messageShower.IsBusy)
				messageShower.RunWorkerAsync();
		}

		private void OnWorkSpaceFormClosed(object sender, FormClosedEventArgs e)
		{
			Form form = sender as Form;
			if (form != null)
			{
				HCSSM_workspace workSpace = CnasUtilityTools.FindControl<HCSSM_workspace>(form);
				if (workSpace != null)
				{
					workSpace.ScannerHook.Stop();
				}
			}
			Application.Exit();
		}

		private void OnShowMessageDialog(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!string.IsNullOrEmpty(_appPd))
			{
				HCSSM_set_message_newshow showMessage = new HCSSM_set_message_newshow(_appPd);
				showMessage.UserId = CnasBaseData.UserID;
				showMessage.GenerateListBoxItem();
				if (showMessage.HasSetMessage)
					showMessage.ShowDialog();
				else
					showMessage.Dispose();
			}
		}
	}
}
