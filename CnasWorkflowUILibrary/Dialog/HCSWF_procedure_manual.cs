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
    public partial class HCSWF_procedure_manual : MetroForm
    {
        private string PD_Code = "",Set_Code="";
        private DataTable DtmanualData;
        private CnasHCSWorkflowInterface CnasHCSWorkflowInterface01;

        public int Rec_data = -1;
		public HCSWF_procedure_manual(string in_pdcode, string in_setcode, CnasHCSWorkflowInterface indata)
        {
            PD_Code = in_pdcode;
            Set_Code = in_setcode;
            SortedList stdata01 = new SortedList();

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, in_pdcode);
            DtmanualData = reCnasRemotCall.RemotInterface.SelectData("HCS-proceduremanual-sec01", sttemp01);
            if (DtmanualData == null)
            {                                
                this.Close();
            }
            else
            {
                Rec_data = 0;
                for (int i = 0; i < DtmanualData.Rows.Count; i++)
                {
					//if (DtmanualData.Rows[i]["manual_type"] != null && DtmanualData.Rows[i]["manual_type"].ToString().Equals("2"))
					//{
						stdata01.Add("BCXP90000000" + DtmanualData.Rows[i]["manual_id"].ToString(), DtmanualData.Rows[i]["manual_name"].ToString());
					//}
                }                
            }

            InitializeComponent();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            CnasHCSWorkflowInterface01 = indata;
            if (stdata01.Count>0) AutoImage(stdata01);            
        }

        private void tex_remark_Click(object sender, EventArgs e)
        {
			HCSWF_parameters_info HCSWF_parameters_info01 = new HCSWF_parameters_info();
            HCSWF_parameters_info01.ShowDialog();
            tex_remark.Text = HCSWF_parameters_info01.Info_Data;
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

        private void BCX_Click(object sender, EventArgs e)
        {
            //选择手动处理编号对应处理到相关流程，并且判断是否需要记录信息
            string str_name = ((PictureBox)sender).Name;
            string strrec = setbarcode(str_name);
            if(strrec=="0")
            {
                Rec_data = 0;
                this.Close();

            }else
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "对不起，提交失败：" + strrec, "信息提示");
            }
        }

        private string setbarcode(string indata)
        {
            string str_bcx = indata.Substring(0, 5);
            if (str_bcx == "BCXP9")
            {
                string str_value = indata.Substring(12, 1);
                DataRow[] arrayDR = DtmanualData.Select("manual_id=" + str_value);

                string str_nextcode = arrayDR[0]["next_code"].ToString();
                string str_info = arrayDR[0]["if_needinfo"].ToString();
                string str_type = arrayDR[0]["manual_type"].ToString();

                #region 查询手动处理代码、类型、是否强制信息

                if (str_info == "1" && tex_remark.Text.Trim().Length==0)
                {
                    #region 手动处理：需要强制备注信息
                    HCSWF_parameters_info HCSWF_parameters_info01 = new HCSWF_parameters_info();
                    HCSWF_parameters_info01.ShowDialog();
                    tex_remark.Text = HCSWF_parameters_info01.Info_Data;
                    #endregion
                }               
                #region 手动处理：将包调度到指定流程

                //rexxie等待开发接口、和实现算法(完成，未测试)

                SortedList in_barcode=new SortedList();
                in_barcode.Add(Set_Code,Set_Code.Substring(0,3));

                SortedList SL_Submit = new SortedList();
                SL_Submit.Add("bar_code", Set_Code);
                SL_Submit.Add("current_code", PD_Code);
                SL_Submit.Add("next_code", str_nextcode);
                SL_Submit.Add("user_id", CnasBaseData.UserID);
                SL_Submit.Add("manual_type", str_type);
                SL_Submit.Add("manual_info", tex_remark.Text);

                SortedList sl_rec = CnasHCSWorkflowInterface01.SubmitProcedureManual(1001, in_barcode, SL_Submit, null);
                if (sl_rec["rec_result"].ToString() == "0")
                {
                    return "0";
                }else
                {
                    string strrec01 = "";
                    if (sl_rec["rec_data01"] != null) strrec01 = strrec01+sl_rec["rec_data01"].ToString();
                    if (sl_rec["rec_data02"] != null) strrec01 = strrec01 + sl_rec["rec_data02"].ToString();

                    return strrec01;
                }
                
                #endregion
               

                #endregion
            }else
            {
                return "提交指令非法，请仔细检查！";
            }

            
        }

        private void tb_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (tb_barcode.Text.Trim().Length == 13 && tb_barcode.Text.Substring(0, 5) == "BCXP9")
                {
                    string strrec = setbarcode(tb_barcode.Text);
                    tb_barcode.Text = "";
                    if (strrec == "0")
                    {
                        Rec_data = 0;
                        this.Close();

                    }
                    else
                    {
                        Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "对不起，提交失败：" + strrec, "信息提示");
                    }
                }
                tb_barcode.Text = "";
            }
        }

        private void tb_barcode_Leave(object sender, EventArgs e)
        {           
           tb_barcode.Focus();            
        }

        private void HCSWF_procedure_manual_Load(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }

        private void tb_barcode_TextChanged(object sender, EventArgs e)
        {
            if (tb_barcode.Text.Trim().Length == 13 && tb_barcode.Text.Substring(0, 5) == "BCXP9")
            {
                string strrec = setbarcode(tb_barcode.Text);
                tb_barcode.Text = "";
                if (strrec == "0")
                {
                    Rec_data = 0;
                    this.Close();

                }
                else
                {
                    tb_barcode.Text = "";
                    Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "对不起，提交失败：" + strrec, "信息提示");
                }
            }
            
        }

        private void HCSWF_procedure_manual_Activated(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }
    }
}
