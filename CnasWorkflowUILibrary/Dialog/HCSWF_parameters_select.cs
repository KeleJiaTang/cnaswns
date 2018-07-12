using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using Cnas.wns.CnasBaseInterface;
using System.Reflection;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBarcodeLib;

namespace Cnas.wns.CnasWorkflowUILibrary
{
    public partial class HCSWF_parameters_select : MetroForm
    {
        /// <summary>
        /// 返回类型2的参数和参数值
        /// </summary>
        public SortedList SL_returnparametersvalue = new SortedList();
        public SortedList SL_returnparametersinfo = new SortedList();

        public int Int_rec = -1;
        public string Next_PDcode = "", Current_parcode="";
		private int _dialogResultStatus = 1;
		/// <summary>
		/// 用于设置cfm关闭状态
		/// </summary>
		/// 1--关闭窗口或确认窗口失败。
		/// 2--确认窗口成功。
		/// 3--窗口中没有要处理的参数。 (关闭HCSSM_scan_barcode窗口.)
		public int DialogResultStatus
		{
			get
			{
				return _dialogResultStatus;
			}
			set
			{
				if (value != _dialogResultStatus)
					_dialogResultStatus = value;
			}
		}

        /// <summary>
        /// 参数所有值集合
        /// </summary>
        private DataTable dtpartvalue = new DataTable();
        /// <summary>
        /// 流程参数配置表
        /// </summary>
        private DataTable dtpartvalueconfig = new DataTable();
		private BarCodeHook _scanerHook = new BarCodeHook();

        //private int cyc_count = 0, run_times=0;
        private string str_parname = "", str_next_code = "", str_par_description, str_wfid = "";

        public HCSWF_parameters_select(string strwfid, SortedList sl_par02, DataTable dtpartvaluedata)
        {
            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            str_wfid = strwfid;
            dtpartvalue = dtpartvaluedata;

            //HCS-pdparametervalue-sec04
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, strwfid);
            //string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-pdparametervalue-sec04", sttemp01);
            dtpartvalueconfig = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec04", sttemp01);
            if (dtpartvalueconfig == null)
            {
                MessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
				DialogResultStatus = 3;
            }else
            {
                //开始第一个参数选择
				_dialogResultStatus = 1;
                mlab_next.Text = dtpartvalueconfig.Rows[0]["par_description"].ToString();
                Current_parcode = dtpartvalueconfig.Rows[0]["par_code"].ToString();
                str_next_code = dtpartvalueconfig.Rows[0]["next_code"].ToString();
                str_parname = dtpartvalueconfig.Rows[0]["par_name"].ToString();
                DataRow[] arrayDR = dtpartvalue.Select("par_code='" + Current_parcode + "'");

                mcb_result.Items.Clear();
                SortedList sl_picdata = new SortedList();
                foreach (DataRow dr in arrayDR)
                {
					if (IsExitParcodeValue(Current_parcode, Convert.ToString(dr["v_value"])))
					{
						mcb_result.Items.Add(CnasUtilityTools.ConcatTwoString(dr["v_value"].ToString(), dr["v_name"].ToString()));
						sl_picdata.Add("BCXP90000000" + dr["v_value"].ToString(), dr["v_name"].ToString());
					}
                }
                //默认选择为第一个
                if (mcb_result.Items.Count > 0)
                {
                    mcb_result.SelectedIndex = 0;
                    this.AutoImage(sl_picdata);
                } 
            }
			InitializeButtonImage();
			if (_scanerHook == null)
				_scanerHook = new BarCodeHook();
			_scanerHook.Start(false);
			_scanerHook.BarCodeEvent += OnBarCodeEvent;
        }

		public void InitializeButtonImage()
		{
			mett_03.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mRechoose40", EnumImageType.PNG);
			mett_02.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mClose40", EnumImageType.PNG);
			mett_01.TileImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom.WorkSpace", "mConfirm40", EnumImageType.PNG);
		}

		private void OnBarCodeEvent(BarCodeHook.BarCodes barCode)
		{
			string matchBarCode = BarCodeHelper.GetMatchBarCode(barCode.BarCode);

			if (matchBarCode.Length == 13 && matchBarCode.Substring(0, 2) == "BC")
			{
				string str_value = matchBarCode.Substring(12, 1);
				for (int i = 0; i < mcb_result.Items.Count; i++)
				{
					if (mcb_result.Items[i].ToString().Substring(0, 1) == str_value)
					{
						mcb_result.SelectedIndex = i;
						break;
					}
				}
				mett_03_Click(null, null);
			}
		}

		/// <summary>
		/// 验证是否已经配置该选项
		/// </summary>
		/// <param name="par_code"></param>
		/// <param name="v_value"></param>
		/// <returns></returns>
		private bool IsExitParcodeValue(string par_code,string v_value)
		{
			for (int i = 0; i < dtpartvalueconfig.Rows.Count;i++)
			{
				string tempParCode = Convert.ToString(dtpartvalueconfig.Rows[i]["par_code"]);
				string tempValue = Convert.ToString(dtpartvalueconfig.Rows[i]["v_value"]);
				if(tempParCode.Equals(par_code)&&tempValue.Equals(v_value))
				{
					return true;
				}
			}
			return false;
		}

  
        private void mett_03_Click(object sender, EventArgs e)
        { 
            string[] strarr=mcb_result.Text.Split(':');
            SL_returnparametersvalue.Add(str_parname,strarr[0]);
            SL_returnparametersinfo.Add(str_parname, tex_remark.Text.Trim());

            str_next_code = select_nextpardata(Current_parcode, strarr[0]);

            if (str_next_code.Trim() == "" || str_next_code.Substring(0,1)=="P")
            {
                //参数配置完成，直接提交结果
                if (str_next_code.Trim() != "") Next_PDcode = str_next_code.Substring(1);
                Int_rec = 0;
				DialogResultStatus = 2;
                this.Close();
            }
            else if (str_next_code.Substring(0, 1) == "A")
            {
                //连续配置参数和信息
                tex_remark.Text = "";               

            }else
            {
                MessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
                this.Close();
            }           
        }

        private void mett_01_Click(object sender, EventArgs e)
        {
            Next_PDcode = "";
            SL_returnparametersinfo.Clear();
            SL_returnparametersvalue.Clear();
			string str_01 = string.Empty;
            //开始第一个参数选择
			DataRow[] arrayDR03 = dtpartvalueconfig.Select("par_code='" + Current_parcode + "'");
			if (arrayDR03 != null && arrayDR03.Count() > 0)
			{
				str_par_description = arrayDR03[0]["par_description"].ToString();
				str_parname = arrayDR03[0]["par_name"].ToString();
				mlab_next.Text = str_par_description;
				str_01 = arrayDR03[0]["par_code"].ToString();
				str_next_code = dtpartvalueconfig.Rows[0]["next_code"].ToString();
			}
            DataRow[] arrayDR = dtpartvalue.Select("par_code='" + str_01 + "'");
            mcb_result.Items.Clear();
            foreach (DataRow dr in arrayDR)
            {
				if (IsExitParcodeValue(Current_parcode, Convert.ToString(dr["v_value"])))
				{
					mcb_result.Items.Add(CnasUtilityTools.ConcatTwoString(dr["v_value"].ToString(), dr["v_name"].ToString()));
				}
            }
			//默认选择为第一个
			if (mcb_result.Items.Count > 0)
			{
				mcb_result.SelectedIndex = 0;
			} 
        }

        private void mett_02_Click(object sender, EventArgs e)
        {
            Int_rec = -1;//不提交选择
            this.Close();
        }

        private void BCX_Click(object sender, EventArgs e)
        {
            //参数类三种：1、系统参数；2、人机交互参数；3、其他参数；9、界面固定控制按钮
            string str_name = ((PictureBox)sender).Name;
            if(str_name.Length==13 && str_name.Substring(0,5)=="BCXP9")
            {
                string str_value = str_name.Substring(12, 1);
                for (int i = 0; i < mcb_result.Items.Count; i++)
                {
                    if(mcb_result.Items[i].ToString().Substring(0,1)==str_value)
                    {
                        mcb_result.SelectedIndex = i;                        
                        break;
                    }
                }
                mett_03_Click(null, null);
            }
        }

        private string select_nextpardata(string in_strcuparcode, string in_value)
        {
            DataRow[] arrayDR01 = dtpartvalueconfig.Select("par_code='" + in_strcuparcode + "' and v_value='" + in_value + "'");
            if (arrayDR01.Length < 1)
            {
                return "";
            }
            else
            {
				selectPanel.Controls.Clear();
                mcb_result.Items.Clear();
                string str_01 = arrayDR01[0]["next_code"].ToString();
                Current_parcode = str_01.Substring(1);
                if (str_01.Length>0 && str_01.Substring(0,1) == "A")
                {
                    //显示下一个参数按键
                    DataRow[] arrayDR = dtpartvalue.Select("par_code='" + Current_parcode + "'");                    
                    SortedList sl_picdata = new SortedList();
                    foreach (DataRow dr in arrayDR)
                    {
						if (IsExitParcodeValue(Current_parcode, Convert.ToString(dr["v_value"])))
						{
							mcb_result.Items.Add(CnasUtilityTools.ConcatTwoString(dr["v_value"].ToString(), dr["v_name"].ToString()));
							sl_picdata.Add("BCXP90000000" + dr["v_value"].ToString(), dr["v_name"].ToString());
						}
                    }
                    if (sl_picdata.Count > 0)
                    {
                        mcb_result.SelectedIndex = 0;
                        this.AutoImage(sl_picdata);
                    }
                    DataRow[] arrayDR03 = dtpartvalueconfig.Select("par_code='" + Current_parcode + "'");
					if (arrayDR03 != null && arrayDR03.Count() > 0)
					{
						str_par_description = arrayDR03[0]["par_description"].ToString();
						str_parname = arrayDR03[0]["par_name"].ToString();
						mlab_next.Text = str_par_description;
					}
					else
					{
						str_01 = "99";//表示流程配置错误
					}
                }
                return str_01;
            }
        }

        private void AutoImage(SortedList indata)
        {
			selectPanel.Controls.Clear();
            int int_Y = 15;
            for (int i = 0; i < indata.Count; i++)
            {
                if (i > 5) return; //最多允许排列5个按钮；
                PictureBox pic_tmp = new PictureBox();
                pic_tmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                pic_tmp.Location = new System.Drawing.Point(1, int_Y);
                pic_tmp.Name = indata.GetKey(i).ToString();
                pic_tmp.Size = new System.Drawing.Size(180, 80);
                pic_tmp.TabStop = false;
                pic_tmp.BackgroundImage = BarCodeHelper.GetBarcodeImage(indata.GetKey(i).ToString(), indata.GetByIndex(i).ToString());
                pic_tmp.Click += new System.EventHandler(this.BCX_Click);
				selectPanel.Controls.Add(pic_tmp);
                int_Y = int_Y + 90;
            }
        }

        private void tex_remark_Click(object sender, EventArgs e)
        {
            HCSWF_parameters_info HCSWF_parameters_info01 = new HCSWF_parameters_info();
            HCSWF_parameters_info01.ShowDialog();
            tex_remark.Text = HCSWF_parameters_info01.Info_Data;
        }

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			if (_scanerHook != null)
				_scanerHook.Stop();
		}


     
    }
}
