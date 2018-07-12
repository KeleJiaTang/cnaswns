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

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_in_cycle_location : TemplateForm
    {
        int success = 0;//用于判断添加是否添加成功
        bool set_newold = true;//true为新包
        DataTable setinfor = new DataTable();//存储包的信息
        public HCSCM_in_cycle_location(bool type, DataTable DTdgv)
        {
            InitializeComponent();
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--分配接收地点";
            set_newold = type;//赋值是否是新包
            setinfor = DTdgv;//赋值所有读取的包的信息id，barcode，名称。

            #region 读取数据库中有什么流程动作
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-set-incycle_wf'");//获得区域接受编号，如：decon为2020
            string strwork = arrayDR[0]["value_code"].ToString();
            strwork = strwork.Remove(strwork.LastIndexOf(','));
            string[] datalist = strwork.Split(',');//取得decon区接收的编号和打包区接收的编号。
            #endregion
            for (int i = 1; i <= datalist.Length; i++)
            {

                CreDynamicButton(datalist[i - 1], i);
            }
            //type为真时，实体包为新包
            if (type == true)
            {
                but_situ.Enabled = false;
            }

        }
        /// <summary>
        /// 创建button
        /// </summary>
        /// <param name="Worknum">动作编号</param>
        /// <param name="Num">创建的第几个</param>
        private void CreDynamicButton(string Worknum, int Num)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Worknum);
            // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-procedure-sec003", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-procedure-sec003", sttemp01);
            if (getdt != null)
            {
                Button but = new Button();
                but.Size = new Size(99, 42);
                if (Num == 1)
                {
                    but.Location = new Point(100 * Num, 32);
                }
                else
                {
                    but.Location = new Point(99 * Num, 32);
                }

                this.Width = Width + 99;
                but.Name = Worknum;
                but.Text = getdt.Rows[0]["pd_name"].ToString();
                but.UseVisualStyleBackColor = true;
                but.FlatStyle = FlatStyle.Standard;
                this.Controls.Add(but);
                but.Click += new System.EventHandler(but_click);
            }



        }
        private void but_click(object sender, EventArgs e)
        {
            Button b1 = (Button)sender;//将触发此事件的对象转换为该Button对象
            //为true，是新包，否则为旧包
            if (set_newold == true)
            {
                if (setinfor != null)
                {
                    //datatable几行就循环几次，在工单中为每一个新的实体包添加记录
                    for (int i = 0; i < setinfor.Rows.Count; i++)
                    {
                        #region 放进循环时，在decon区为新包添加记录
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        SortedList sltmp = new SortedList();
                        SortedList sltmp01 = new SortedList();
                        sltmp01.Add(1, setinfor.Rows[i]["id"].ToString());
                        sltmp01.Add(2, 0);//无用参数
                        sltmp01.Add(3, 0);//无用参数
                        sltmp01.Add(4, setinfor.Rows[i]["id"].ToString());
                        sltmp01.Add(5, setinfor.Rows[i]["bar_code"].ToString());
                        sltmp01.Add(6, setinfor.Rows[i]["ca_name"].ToString());
                        sltmp01.Add(7, b1.Name);
                        sltmp01.Add(8, CnasBaseData.UserID);
                        sltmp01.Add(9, "");
                        sltmp.Add(1, sltmp01);
                        // string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-workset-add003", sltmp, null);
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-workset-add003", sltmp, null);
                        if (recint > -1)
                        {
                            success++;
                        }
                        #endregion
                    }
                }
            }
            else
            {
                if (setinfor != null)
                {
                    //datatable几行就循环几次，在工单中为每一个新的实体包添加记录
                    for (int i = 0; i < setinfor.Rows.Count; i++)
                    {
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        SortedList sttemp01 = new SortedList();
                        sttemp01.Add(1, setinfor.Rows[i]["id"].ToString());
                        // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec006", sttemp01);
                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec006", sttemp01);
                        if (getdt == null) return;
                        //如果这旧包原本位置就在decon，则还原位置
                        if (getdt.Rows[0]["wf_code"].ToString() == b1.Name)
                        {

                            #region 放进循环时，还原包的记录
                            SortedList sltmp = new SortedList();
                            SortedList sltmp01 = new SortedList();
                            sltmp01.Add(1, 1);
                            sltmp01.Add(2, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(3, 0);
                            sltmp01.Add(4, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(5, getdt.Rows[0]["wf_code"].ToString());
                            sltmp.Add(1, sltmp01);
                            //  string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                            if (recint > -1)
                            {
                                success++;
                            }
                            #endregion

                        }
                        else
                        {
                            #region 放进循环时，在decon区为旧包添加记录

                            SortedList sltmp = new SortedList();
                            SortedList sltmp01 = new SortedList();
                            sltmp01.Add(1, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(2, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(3, getdt.Rows[0]["wf_code"].ToString());
                            sltmp01.Add(4, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(5, setinfor.Rows[i]["bar_code"].ToString());
                            sltmp01.Add(6, setinfor.Rows[i]["ca_name"].ToString());
                            sltmp01.Add(7, b1.Name);
                            sltmp01.Add(8, CnasBaseData.UserID);
                            sltmp01.Add(9, "");
                            sltmp.Add(1, sltmp01);
                            // string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-workset-add003", sltmp, null);
                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-workset-add003", sltmp, null);
                            if (recint > -1)
                            {
                                success++;
                            }
                            #endregion
                        }


                    }
                }

            }
            //如果需要添加的数量等于添加成功的数量，则移进成功
            if (setinfor.Rows.Count == success)
            {
                 MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "实体包移进循环" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorloop", EnumPromptMessage.error, new string[] { "移进" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            success = 0;//清零

        }


        private void but_situ_Click(object sender, EventArgs e)
        {
            //false为旧包
            if (set_newold == false)
            {
                if (setinfor != null)
                {
                    //datatable几行就循环几次，在工单中为每一个新的实体包添加记录
                    for (int i = 0; i < setinfor.Rows.Count; i++)
                    {
                        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                        SortedList sttemp01 = new SortedList();
                        sttemp01.Add(1, setinfor.Rows[i]["id"].ToString());
                        // string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-workset-sec006", sttemp01);
                        DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-workset-sec006", sttemp01);
                        if (getdt != null && getdt.Rows.Count > 0)
                        {


                            #region 放进循环时，还原包的记录
                            SortedList sltmp = new SortedList();
                            SortedList sltmp01 = new SortedList();
                            sltmp01.Add(1, 1);
                            sltmp01.Add(2, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(3, 0);
                            sltmp01.Add(4, setinfor.Rows[i]["id"].ToString());
                            sltmp01.Add(5, getdt.Rows[0]["wf_code"].ToString());
                            sltmp.Add(1, sltmp01);
                            //   string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-worksetupcycle-up001", sltmp, null);
                            if (recint > -1)
                            {
                                success++;
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("读取不了编号为:"+setinfor.Rows[i]["id"].ToString()+"的包，请联系管理员。","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                //如果需要添加的数量等于添加成功的数量，则移进成功
                if (setinfor.Rows.Count == success)
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("successful", EnumPromptMessage.warning, new string[] { "实体包移进循环" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("errorloop", EnumPromptMessage.error, new string[] { "移进" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                success = 0;//清零
            }
        }
    }
}
