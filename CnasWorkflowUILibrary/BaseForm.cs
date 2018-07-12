using Cnas.wns.CnasBarcodeLib;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasMetroFramework.Forms;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasWorkflowUILibrary
{
	/// <summary>
	/// 流程窗口的基本窗口
	/// </summary>
	public partial class BaseForm : MetroForm
	{
		public ILog Logger = null;
		/// <summary>
		/// 服务端
		/// </summary>
		private CnasRemotCall _remoteClient = null;

		/// <summary>
		/// 流程编号
		/// </summary>
		private string _pdCode;

		private SortedList _scanBarCodes = new SortedList();
		public SortedList ScanBarCodes
		{
			get
			{
				if (_scanBarCodes == null)
					_scanBarCodes = new SortedList();
				return _scanBarCodes;
			}
			set
			{
				if (value != _scanBarCodes)
					_scanBarCodes = value;
			}
		}

		    

		/// <summary>
		/// 窗口数据
		/// </summary>
		private SortedList _viewData = new SortedList();

		private BarCodeHook _barCodeHolder = new BarCodeHook();

		/// <summary>
		/// 条形码扫描器
		/// </summary>
		public BarCodeHook BarCodeHolder
		{
			get
			{
				return _barCodeHolder;
			}
		} 

		/// <summary>
		/// 服务端
		/// </summary>
		public CnasRemotCall RemoteClient
		{
			
			get
			{
				if (_remoteClient == null)
					_remoteClient = new CnasRemotCall();
				return _remoteClient;
			}
		}

		/// <summary>
		/// 窗口数据
		/// </summary>
		public SortedList ViewData
		{
			get
			{
				if (_viewData == null)
					_viewData = new SortedList();
				return _viewData;
			}
			set
			{
				if (value != _viewData)
					_viewData = value;
			}
		}

		/// <summary>
		/// 流程好
		/// </summary>
		public string PdCode 
		{ 
			get 
			{
				return _pdCode;
			}
			set
			{
				if (value != _pdCode)
					_pdCode = value;
			}
		}

		/// <summary>
		/// 流程窗口的基本窗口
		/// </summary>
		public BaseForm()
		{
			InitializeComponent();
			Logger = LogManager.GetLogger("CnasWNSClient");
		}

		/// <summary>
		/// 流程窗口的基本窗口
		/// </summary>
		/// <param name="parentForm">窗口的父窗口</param>
		public BaseForm(BaseForm parentForm) : this()
		{
			Parent = parentForm;
			if (parentForm != null)
				_pdCode = parentForm.PdCode;
		}

		public BaseForm(SortedList scanCodes)
		{
			InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
			Logger = LogManager.GetLogger("CnasWNSClient");
			if (scanCodes != null)
			{
				_scanBarCodes = scanCodes;
				string wfCode = BarCodeHelper.GetBarCodeByType("BCV", _scanBarCodes);
				PdCode = string.IsNullOrEmpty(wfCode) ? "" : wfCode.Substring(9, 4);
			}
			else
			{
				Logger.Error(string.Format("Scan code is null."));
			}
		}

		/// <summary>
		/// 流程窗口的基本窗口
		/// </summary>
		/// <param name="pdCode">窗口流程编号</param>
		public BaseForm(string pdCode) : this()
		{
			_pdCode = pdCode;
		}

		public virtual void InitializeButtonImage()
		{
		}

		/// <summary>
		/// 初始化控件
		/// </summary>
		public virtual void InitalizeControl()
		{
			_barCodeHolder.Start(false);
			this.Focus();
		}

		/// <summary>
		/// 获取数据
		/// </summary>
		public virtual void LoadData()
		{
		}

		/// <summary>
		/// 窗口的Load事件
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event</param>
		private void BaseForm_Load(object sender, EventArgs e)
		{
			InitializeButtonImage();
			LoadData();
			InitalizeControl();
		}

		/// <summary>
		/// 关闭事件
		/// </summary>
		/// <param name="sender">the event sender</param>
		/// <param name="e">the event</param>
		private void OnBaseFormClosed(object sender, FormClosedEventArgs e)
		{
			if (_barCodeHolder != null)
			{
				_barCodeHolder.Stop();
			}
		}  
 
	}
}
