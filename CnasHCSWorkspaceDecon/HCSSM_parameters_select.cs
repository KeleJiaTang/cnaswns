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

namespace Cnas.wns.CnasHCSWorkspaceDecon
{
    public partial class HCSSM_parameters_select : MetroForm
    {
        /// <summary>
        /// 返回类型2的参数和参数值
        /// </summary>
        public SortedList SL_returnparametersvalue = new SortedList();
        public SortedList SL_returnparametersinfo = new SortedList();

        public int Int_rec = -1;
        public string Next_PDcode = "", Current_parcode="";
        /// <summary>
        /// 参数所有值集合
        /// </summary>
        private DataTable dtpartvalue = new DataTable();
        /// <summary>
        /// 流程参数配置表
        /// </summary>
        private DataTable dtpartvalueconfig = new DataTable();

        //private int cyc_count = 0, run_times=0;
        private string str_parname = "", str_next_code = "", str_par_description, str_wfid = "";

        public HCSSM_parameters_select(string strwfid, SortedList sl_par02, DataTable dtpartvaluedata)
        {
            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //SL_returnparametersvalue = sl_par02;
            str_wfid = strwfid;
            dtpartvalue = dtpartvaluedata;
            //cyc_count = SL_returnparametersvalue.Count;

            //HCS-pdparametervalue-sec04
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, strwfid);
            //string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-pdparametervalue-sec04", sttemp01);
            dtpartvalueconfig = reCnasRemotCall.RemotInterface.SelectData("HCS-pdparametervalue-sec04", sttemp01);
            if (dtpartvalueconfig==null)
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
                this.Close();
            }else
            {
                //开始第一个参数选择
                mlab_next.Text = dtpartvalueconfig.Rows[0]["par_description"].ToString();
                Current_parcode = dtpartvalueconfig.Rows[0]["par_code"].ToString();
                str_next_code = dtpartvalueconfig.Rows[0]["next_code"].ToString();
                str_parname = dtpartvalueconfig.Rows[0]["par_name"].ToString();
                DataRow[] arrayDR = dtpartvalue.Select("par_code='" + Current_parcode + "'");

                mcb_result.Items.Clear();
                SortedList sl_picdata = new SortedList();
                foreach (DataRow dr in arrayDR)
                {
                    mcb_result.Items.Add(dr["v_value"].ToString() + "：" + dr["v_name"].ToString());
                    sl_picdata.Add("BCXP90000000" + dr["v_value"].ToString(), dr["v_name"].ToString());                    
                }
                //默认选择为第一个
                if (mcb_result.Items.Count > 0)
                {
                    mcb_result.SelectedIndex = 0;
                    this.AutoImage(sl_picdata);
                } 
            }
        }

  
        private void mett_03_Click(object sender, EventArgs e)
        { 
            string[] strarr=mcb_result.Text.Split('：');
            SL_returnparametersvalue.Add(str_parname,strarr[0]);
            SL_returnparametersinfo.Add(str_parname, tex_remark.Text.Trim());

            str_next_code = select_nextpardata(Current_parcode, strarr[0]);

            if (str_next_code.Trim() == "" || str_next_code.Substring(0,1)=="P")
            {
                //参数配置完成，直接提交结果
                if (str_next_code.Trim() != "") Next_PDcode = str_next_code.Substring(1);
                Int_rec = 0;
                this.Close();
            }
            else if (str_next_code.Substring(0, 1) == "A")
            {
                //连续配置参数和信息
                tex_remark.Text = "";               

            }else
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                Int_rec = -1;
                this.Close();
            }           
        }

        private void mett_01_Click(object sender, EventArgs e)
        {
            Next_PDcode = "";
            SL_returnparametersinfo.Clear();
            SL_returnparametersvalue.Clear();
            //开始第一个参数选择
            mlab_next.Text = dtpartvalueconfig.Rows[0]["par_description"].ToString();
            string str_01 = dtpartvalueconfig.Rows[0]["par_code"].ToString();
            str_next_code = dtpartvalueconfig.Rows[0]["next_code"].ToString();
            str_parname = dtpartvalueconfig.Rows[0]["par_name"].ToString();
            DataRow[] arrayDR = dtpartvalue.Select("par_code='" + str_01 + "'");
            mcb_result.Items.Clear();
            foreach (DataRow dr in arrayDR)
            {
                mcb_result.Items.Add(dr["v_value"].ToString() + "：" + dr["v_name"].ToString());
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
        private void mcb_result_SelectedValueChanged(object sender, EventArgs e)
        {
            //string str_temp01 = mcb_result.Text.Substring(0, 1);
            //str_next_code = select_nextpardata(Current_parcode, str_temp01);
        }

        private string select_nextpardata(string in_strcuparcode, string in_value)
        {
            DataRow[] arrayDR01 = dtpartvalueconfig.Select("par_code='" + in_strcuparcode + "' and v_value='" + in_value + "'");
            if (arrayDR01.Length < 1)
            {
                //Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "编号为“" + str_wfid + "”的流程配置参数错误，请联系管理员！！！", "信息提示");
                //Int_rec = -1;
                //this.Close();
                return "";
            }
            else
            {   
                gp_03.Controls.Clear();
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
                        mcb_result.Items.Add(dr["v_value"].ToString() + "：" + dr["v_name"].ToString());
                        sl_picdata.Add("BCXP90000000" + dr["v_value"].ToString(), dr["v_name"].ToString());
                    }
                    if (sl_picdata.Count > 0)
                    {
                        mcb_result.SelectedIndex = 0;
                        this.AutoImage(sl_picdata);
                    }
                    DataRow[] arrayDR03 = dtpartvalueconfig.Select("par_code='" + Current_parcode + "'");
                    str_par_description = arrayDR03[0]["par_description"].ToString();
                    str_parname = arrayDR03[0]["par_name"].ToString();
                    mlab_next.Text = str_par_description;
                }
                return str_01;
            }
        }



        private void AutoImage(SortedList indata)
        {
            gp_03.Controls.Clear();
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
                pic_tmp.BackgroundImage = GetBarcodeImage(indata.GetKey(i).ToString(), indata.GetByIndex(i).ToString());
                pic_tmp.Click += new System.EventHandler(this.BCX_Click);
                gp_03.Controls.Add(pic_tmp);
                int_Y = int_Y + 90;
            }
        }

        private Image GetBarcodeImage(string inVarcode, string inname)
        {
            //inVarcode = inVarcode +"\r";
            Barcode Barcode01 = new Barcode();
            Barcode01.ChangeRawData = inname;
            Barcode01.IncludeLabel = true;
            Barcode01.Alignment = AlignmentPositions.CENTER;
            Barcode01.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            Barcode01.LabelPosition = LabelPositions.TOPCENTER;
            return Barcode01.Encode(TYPE.CODE128, inVarcode, Color.Black, Color.White, 180, 90);
        }

        private void tex_remark_Click(object sender, EventArgs e)
        {
            HCSSM_parameters_info HCSSM_parameters_info01 = new HCSSM_parameters_info();
            HCSSM_parameters_info01.ShowDialog();
            tex_remark.Text = HCSSM_parameters_info01.Info_Data;
        }

        private void tb_barcode_Leave(object sender, EventArgs e)
        {
            if (mcb_result.Focused == false)
            {
                tb_barcode.Focus();
            }
        }

        private void HCSSM_parameters_select_Activated(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }

        private void mcb_result_Leave(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }

        private void mcb_result_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13 || ((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || ((int)e.KeyChar >= (int)'A' && (int)e.KeyChar <= (int)'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                tb_barcode.Focus();
                tb_barcode.Text = e.KeyChar.ToString();
                tb_barcode.SelectionStart = tb_barcode.Text.Length;
            }
        }

        private void tb_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((int)e.KeyChar == 13)
            //{
            //    if (tb_barcode.Text.Length == 13 && tb_barcode.Text.Substring(0, 2) == "BC")
            //    {
            //        string str_value = tb_barcode.Text.Substring(12, 1);
            //        for (int i = 0; i < mcb_result.Items.Count; i++)
            //        {
            //            if (mcb_result.Items[i].ToString().Substring(0, 1) == str_value)
            //            {
            //                mcb_result.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //        mett_03_Click(null, null);
            //        tb_barcode.Text = "";
            //    }
            //    tb_barcode.Text = "";
            //}
        }

        private void tb_barcode_TextChanged(object sender, EventArgs e)
        {
            if (tb_barcode.Text.Length == 13 && tb_barcode.Text.Substring(0, 2) == "BC")
            {
                string str_value = tb_barcode.Text.Substring(12, 1);
                for (int i = 0; i < mcb_result.Items.Count; i++)
                {
                    if (mcb_result.Items[i].ToString().Substring(0, 1) == str_value)
                    {
                        mcb_result.SelectedIndex = i;
                        break;
                    }
                }
                mett_03_Click(null, null);
                tb_barcode.Text = "";
            }
        }

        private void HCSSM_parameters_select_Load(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }


     
    }
}
