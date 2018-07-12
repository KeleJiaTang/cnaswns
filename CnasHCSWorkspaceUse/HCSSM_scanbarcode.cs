using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using Cnas.wns.CnasBarcodeLib;
using Cnas.wns.CnasBaseInterface;

using Cnas.wns.CnasBaseClassClient;

namespace Cnas.wns.CnasHCSWorkspaceUse
{
    public partial class HCSSM_scanbarcode : MetroForm
    {
        /// <summary>
        /// 界面固定条码按钮
        /// </summary>
        private SortedList SL_main = new SortedList();//界面固定条码按钮
        /// <summary>
        /// 提交给算法参数集合
        /// </summary>
        private SortedList SL_Submit = new SortedList();
        /// <summary>
        /// 当前已经扫描上的条码
        /// </summary>
        private SortedList SL_barcode = new SortedList();//当前已经扫描上的条码

        private SortedList SL_DGV = new SortedList();//当前已经扫描到DGV上的条码
        /// <summary>
        /// 当前区域工作台程序允许流程list
        /// </summary>
        private SortedList SL_AppPD = new SortedList();//当前区域工作台程序允许流程list

        private DataTable dtpdpart, dtapppd;

        private DataTable dtcarset;

        private DataTable dtpartvalue = new DataTable();//所有参数的值集合

        /// <summary>
        /// 所有流程参数
        /// </summary>
        private SortedList SL_parameter = new SortedList();//所有流程参数
        /// <summary>
        /// 流程参数类型为1的参数
        /// </summary>
        private SortedList SL_parametertmp01 = new SortedList();//流程参数类型为1的参数
        /// <summary>
        /// 流程参数类型为2的参数
        /// </summary>
        private SortedList SL_parametertmp02 = new SortedList();//流程参数类型为2的参数
        /// <summary>
        /// 参数类型2选择时候留下的备注信息
        /// </summary>
        private SortedList SL_parametersinfo = new SortedList();//参数类型2选择时候留下的备注信息
        /// <summary>
        /// 存储当前流程信息，用于判断流程扫描条码先后允许顺序
        /// </summary>
        private SortedList SL_check = new SortedList();//存储当前流程信息，用于判断流程扫描条码先后允许顺序
        /// <summary>
        /// 将流程扫描允许条件放入集合SL_checkbarcode
        /// </summary>
        private SortedList SL_checkbarcode = new SortedList();//将流程扫描允许条件放入集合SL_checkbarcode
        /// <summary>
        /// 扫描进Dvg的条码集合
        /// </summary>
        private SortedList SL_sacnDvg = new SortedList();//扫描进Dvg的条码集合
        private CnasHCSWorkflowInterface CnasHCSWorkflowInterface01;

        /// <summary>
        /// 初始化类构造函数
        /// </summary>
        /// <param name="indata">算法类</param>
        /// <param name="userbarcode">用户条码</param>
        /// <param name="dtpdpartin">所有参数集合</param>
        /// <param name="dtapppddata">当前工作台流程集合</param>
        public HCSSM_scanbarcode(CnasHCSWorkflowInterface indata, string userbarcode, DataTable dtpdpartdata, DataTable dtapppddata, DataTable dtpartvaluedata)
        {
            InitializeComponent();

            if (dtpdpartdata == null || dtapppddata == null)
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "对不起！流程参数数据获取失败，不能继续。", "信息提示");
                this.Close();
            }
            dtpartvalue = dtpartvaluedata;

            for (int i = 0; i < dtapppddata.Rows.Count; i++)
            {
                string str_pdname = "", str_pdbcode = "";
                if (dtapppddata.Rows[i]["pd_bcode"] != null) str_pdbcode = dtapppddata.Rows[i]["pd_bcode"].ToString();
                if (dtapppddata.Rows[i]["pd_name"] != null) str_pdname = dtapppddata.Rows[i]["pd_name"].ToString();
                SL_AppPD.Add(str_pdbcode, str_pdname);
            }
            if (SL_AppPD.Count > 0) AutoImage(SL_AppPD);

            //pic_01.Image = GetBarcodeImage("BCX0000008998", "接收登记");
            //pic_02.BackgroundImage = GetBarcodeImage("BCX0000008998", "清洗");

            BCXP900000002.BackgroundImage = GetBarcodeImage("BCXP900000002", "退出扫码");
            BCXP900000001.BackgroundImage = GetBarcodeImage("BCXP900000001", "确认操作");
            SL_main.Add("BCXP900000001", BCXP900000001);
            SL_main.Add("BCXP900000002", BCXP900000002);
            //SL_main.Add("BCXP900000003", BCXP900000003);


            dtpdpart = dtpdpartdata;
            dtapppd = dtapppddata;

            CnasHCSWorkflowInterface01 = indata;
            SL_barcode.Add(userbarcode, "BCB");
            addtodgv(userbarcode, "用户");

            //检查参数：用来存储判断参数
            SL_check.Add("pd_code", "");
            SL_check.Add("pd_name", "");
            SL_check.Add("pd_barcode", "");
            SL_check.Add("pd_scan", "");
            SL_check.Add("pd_par1", "");
            SL_check.Add("pd_par2", "");



        }

        private void tb_barcode_Leave(object sender, EventArgs e)
        {
            tb_barcode.Focus();
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

        private void AutoImage(SortedList indata)
        {
            gp_03.Controls.Clear();
            int int_Y = 15;
            for (int i = 0; i < indata.Count; i++)
            {
                if (i > 6) return; //最多允许排列6个按钮；
                PictureBox pic_tmp = new PictureBox();
                pic_tmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                pic_tmp.Location = new System.Drawing.Point(1, int_Y);
                //this.pic_02.Location = new System.Drawing.Point(2, 20);
                pic_tmp.Name = indata.GetKey(i).ToString();
                pic_tmp.Size = new System.Drawing.Size(180, 80);
                pic_tmp.TabStop = false;
                pic_tmp.BackgroundImage = GetBarcodeImage(indata.GetKey(i).ToString(), indata.GetByIndex(i).ToString());
                pic_tmp.Click += new System.EventHandler(this.BCX_Click);
                gp_03.Controls.Add(pic_tmp);
                int_Y = int_Y + 90;
            }

        }


        private void BCX_Click(object sender, EventArgs e)
        {
            //参数类三种：1、系统参数；2、人机交互参数；3、其他参数；9、界面固定控制按钮
            string str_name = ((PictureBox)sender).Name;
            string strrec = setbarcode(str_name);
            if (strrec != "") mlab_info.Text = strrec;
        }

        private string setbarcode(string indata)
        {
            string str_bcx = indata.Substring(0, 5);
            if (str_bcx == "BCXP9")
            {
                if (indata == "BCXP900000001")
                {
                    //确定开始提交（扫描万所有用户、流程、包等等）
                    #region 首先判断是否有人机交互参数需要选择，如果有需要调用HCSSM_parameters_select
                    string str_pdcode = SL_check["pd_code"].ToString();
                    //检查所有条码是否已经扫描完成
                    if (str_pdcode == "" || submitok() < 0)
                    {
                        Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "请先选择流程,或者扫描完所有条码后提交！！！", "信息提示");
                        return "请先选择流程,或者扫描完所有条码后提交！！！";
                    }
                    //开始人机交互参数选择界面
                    if (SL_parametertmp02.Count > 0 && SL_parametersinfo.Count == 0)
                    {
                        HCSSM_parameters_select HCSSM_parameters_select01 = new HCSSM_parameters_select(SL_check["pd_code"].ToString(), SL_parametertmp02, dtpartvalue);
                        HCSSM_parameters_select01.ShowDialog();
                        //获取parameter_02参数的交互值
                        if (HCSSM_parameters_select01.Int_rec < 0) return "取消提交，参数选择未完成。";

                        SL_parametertmp02 = HCSSM_parameters_select01.SL_returnparametersvalue;
                        SL_parametersinfo = HCSSM_parameters_select01.SL_returnparametersinfo;
                        SL_check["pd_par2"] = SL_parametertmp02;
                    }

                    #endregion


                    #region 开始提交给下一步流程
                    submitwf();

                    #endregion

                }
                else if (indata == "BCXP900000002")
                {
                    this.Close();
                }
                else if (indata == "BCXP900000003")
                {

                }
            }
            else if (str_bcx == "BCXP2")
            {
                //处理人机交互选择

            }
            else if (str_bcx == "BCXP1")
            {
                //系统参数，好像不用处理

            }
            else
            {
                //处理业务条码
                #region 处理业务条码
                string str_bcx02 = indata.Substring(0, 3);
                if (SL_barcode[indata] == null)//
                {
                    #region 正常加入条码
                    if (str_bcx02 == "BCV")
                    {
                        #region 扫描流程
                        //判断是否已经有流程扫描
                        for (int j = 0; j < SL_barcode.Count; j++)
                        {
                            if (SL_barcode.GetByIndex(j).ToString().Substring(0, 3) == "BCV") return "已经选择一个流程";
                        }

                        DataRow[] arrayDR = dtapppd.Select("pd_bcode='" + indata + "'");
                        if (arrayDR.Length == 0) return "扫描的流程不属于该区域";
                        string str_pdid = "", str_pdcode = "", str_pdname = "", str_pdscan = "";
                        //if (arrayDR[0]["pd_id"] != null) str_pdid = arrayDR[0]["pd_id"].ToString();
                        if (arrayDR[0]["pd_code"] != null) str_pdcode = arrayDR[0]["pd_code"].ToString();
                        if (arrayDR[0]["pd_name"] != null) str_pdname = arrayDR[0]["pd_name"].ToString();
                        if (arrayDR[0]["pd_scan"] != null) str_pdscan = arrayDR[0]["pd_scan"].ToString();

                        #region 处理参数，并且对参数分类
                        SL_parametertmp01.Clear();
                        SL_parametertmp02.Clear();
                        DataRow[] arrayDR01 = dtpdpart.Select("par_code=" + str_pdcode);
                        foreach (DataRow dr in arrayDR01)
                        {

                            if (dr["par_name"] != null)
                            {
                                string str_parname01 = dr["par_name"].ToString();
                                string str_partype01 = dr["par_type"].ToString();
                                string str_par_description = dr["par_description"].ToString();
                                if (str_partype01 == "2")
                                {
                                    SL_parametertmp02.Add(str_parname01, str_par_description);
                                }
                                else
                                {
                                    SL_parametertmp01.Add(str_parname01, str_par_description);
                                }
                            }
                        }
                        #endregion

                        //将流程扫描允许条件放入集合SL_checkbarcode
                        SL_checkbarcode.Clear();
                        if (str_pdscan.Length > 0)
                        {
                            string[] strbarcode = str_pdscan.Split(';');
                            for (int i = 0; i < strbarcode.Length; i++)
                            {
                                if (strbarcode[i].Length > 0) SL_checkbarcode.Add(strbarcode[i].Substring(0, 3), strbarcode[i].Substring(3));
                            }
                        }

                        SL_check["pd_code"] = str_pdcode;//流程代码
                        SL_check["pd_name"] = str_pdname;//流程名字
                        SL_check["pd_barcode"] = indata;//流程编码
                        SL_check["pd_scan"] = SL_checkbarcode;//流程允许扫描代码
                        SL_check["pd_par1"] = SL_parametertmp01;//所有流程参数为1的集合
                        SL_check["pd_par2"] = SL_parametertmp02;//所有流程参数为2的集合

                        SL_barcode.Add(indata, "BCV");
                        return addtodgv(indata, str_pdname);

                        #endregion
                    }
                    else
                    {
                        #region 扫描实体（并且判断改实体是不是到了该流程环节）
                        if (SL_check["pd_code"].ToString() == "" || SL_checkbarcode.Count == 0 || SL_checkbarcode[str_bcx02] == null)
                        {
                            return "没有扫流程条码或扫描规则不符合";   //没有扫流程条码、扫描规则不符合，不允许任何下一步动作
                        }
                        else
                        {
                            //判断实体允许数量
                            int int_scan = int.Parse(SL_checkbarcode[str_bcx02].ToString());
                            int int_count = 0;
                            for (int i = 0; i < SL_barcode.Count; i++)
                            {
                                if (SL_barcode.GetByIndex(i).ToString().Substring(0, 3) == str_bcx02)
                                {
                                    int_count++;
                                }
                            }
                            if (int_count >= int_scan)//已经满足扫描码条件数量，不允许再扫描该条形码
                            {
                                return "已经满足扫描码条件数量";
                            }
                        }

                        //判断实体是否在当前流程环节
                        if (str_bcx02 == "BCC" || str_bcx02 == "BCD")
                        {
                            if (ifinwf(indata, SL_check["pd_code"].ToString()) < 0)
                            {
                                //弹出改包所在流程环节。
                                return "该物品还未到【" + SL_check["pd_name"].ToString() + "】流程环节。";
                            }
                        }

                        SL_barcode.Add(indata, str_bcx02);

                        #region 查找代码解释
                        string str_tmp01 = "未知编码";
                        DataRow[] arrayDR02 = CnasBaseData.SystemBaseData.Select("type_code='HCS_barcode_type' and key_code='" + indata.Substring(0, 3) + "'");
                        if (arrayDR02.Length > 0)
                        {
                            str_tmp01 = arrayDR02[0]["value_code"].ToString();
                        }
                        #endregion

                        return addtodgv(indata, str_tmp01);
                        #endregion
                    }

                    #endregion
                }
                else
                {
                    #region 处理重复扫描代码
                    //string strtmp = SL_barcode[indata].ToString();
                    for (int i = 0; i < dgv_01.Rows.Count; i++)
                    {
                        if (dgv_01.Rows[i].Cells["barcode"].Value.ToString() == indata)
                        {
                            dgv_01.Rows[i].Selected = true;
                            break;
                        }
                    }
                    return "该条码已经存在，帮助你找到。";
                    #endregion
                }
                #endregion
            }
            return "";
        }

        /// <summary>
        /// 判断该包或者车已经到当前流程
        /// </summary>
        /// <param name="inbcdata">条码编号</param>
        /// <param name="inpddata">流程编号</param>
        /// <returns>返回值</returns>
        private int ifinwf(string inbcdata, string inpddata)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            string strbc = inbcdata.Substring(0, 3);
            if (strbc == "BCC")
            {
                #region 判断改包是不是在当前流程环节
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, inpddata);
                sttemp01.Add(2, inbcdata);
                sttemp01.Add(3, 0);
                //string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec002", sttemp01);
                DataTable dtworktmp = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec002", sttemp01);
                if (dtworktmp == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
                #endregion
            }
            else if (strbc == "BCD")
            {
                #region 判断改运输车是不是在当前流程环节
                SortedList sttemp01 = new SortedList();
                sttemp01.Add(1, inpddata);
                sttemp01.Add(2, inbcdata);
                sttemp01.Add(3, 0);
                //string aaa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec003", sttemp01);
                dtcarset = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec003", sttemp01);
                if (dtcarset == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

                #endregion
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 判断是否具备提交条件（所有要求条码都具备）
        /// </summary>
        /// <returns></returns>
        private int submitok()
        {
            //string strscan = SL_check["pd_scan"].ToString();
            if (SL_checkbarcode.Count > 0 && dgv_01.RowCount > 0)
            {
                for (int i = 0; i < SL_checkbarcode.Count; i++)
                {
                    string str_tmp = SL_checkbarcode.GetKey(i).ToString();
                    int int_tag = 0;
                    for (int j = 0; j < dgv_01.RowCount; j++)
                    {
                        string str_tmo01 = dgv_01.Rows[j].Cells["barcode"].Value.ToString().Substring(0, 3);
                        if (str_tmp == str_tmo01) int_tag = 1;
                    }
                    if (int_tag == 0) return -1;
                }
            }
            else
            {

                return -1;
            }
            return 1;
        }




        private string addtodgv(string inbcdata, string bardis)
        {
            //加入条码to dgv_01            
            SL_DGV.Add(inbcdata, bardis);
            int rownumber = dgv_01.RowCount;
            dgv_01.RowCount++;
            dgv_01.Rows[rownumber].Cells["id"].Value = dgv_01.RowCount;
            dgv_01.Rows[rownumber].Cells["barcode"].Value = inbcdata;
            dgv_01.Rows[rownumber].Cells["name"].Value = bardis;
            return "扫码成功";
        }

        private void HCSSM_scanbarcode_Activated(object sender, EventArgs e)
        {
            tb_barcode.Focus();
        }

        private void tb_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //mlab_next.Text = e.KeyChar.ToString();
            if ((int)e.KeyChar == 13)
            {
                //setbarcode(tb_barcode.Text);
                //tb_barcode.Text = "";
            }
        }
        private void tb_barcode_TextChanged(object sender, EventArgs e)
        {
            if (tb_barcode.Text.Length == 13 && tb_barcode.Text.Substring(0, 2) == "BC")
            {
                string strrec = setbarcode(tb_barcode.Text);
                if (strrec != "")
                {
                    mlab_info.Text = strrec;
                }
                else
                {
                    mlab_info.Text = tb_barcode.Text;
                }
                tb_barcode.Text = "";
            }
        }

        private void submitwf()
        {
            SL_Submit.Clear();
            SL_Submit.Add("SL_check", SL_check);
            SL_Submit.Add("sub_barcode", SL_barcode);
            SL_Submit.Add("user_id", "1");
            SL_Submit.Add("Par2_info", SL_parametersinfo);

            SortedList sl_rec009 = CnasHCSWorkflowInterface01.GetWorkflowParametersValue(1001, 1001, SL_Submit, null, null);
            string strrec01 = sl_rec009["rec_result"].ToString();
            if (strrec01 == "0")
            {
                Cnas.wns.CnasMetroFramework.MetroMessageBox.Show(this, "恭喜你！提交成功。", "信息提示");
                this.Close();
            }
            else
            {
                mlab_info.Text = strrec01 + "-" + sl_rec009["rec_data01"].ToString();
            }
        }


    }
}
