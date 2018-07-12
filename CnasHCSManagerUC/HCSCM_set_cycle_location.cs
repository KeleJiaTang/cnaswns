using Cnas.wns.CnasBaseClassClient;
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
    public partial class HCSCM_set_cycle_location : Form
    {
        DataTable setinfor = new DataTable();//存储包的信息
        public HCSCM_set_cycle_location(DataTable dtselect, bool type)
        {
            InitializeComponent();
            this.Text = ConfigurationManager.AppSettings["SystemName"].ToString() + "--分配接收地点";
            setinfor = dtselect;//赋值所有读取的包的信息id，barcode，名称。
            //如果type为true，则不显示原来位置的button
            if (type == true)
            {
                but_situ.Enabled = false;
            }
        }

        private void but_decon_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-set-incycle_wf'");//获得区域接受编号，如：decon为2020
            string strwork = arrayDR[0]["value_code"].ToString();
            strwork = strwork.Remove(strwork.LastIndexOf(','));
            string[] datalist = strwork.Split(',');//取得decon区接收的编号和打包区接收的编号。

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
                    sltmp01.Add(7, datalist[0]);//去污区接收的动作
                    sltmp01.Add(8, CnasBaseData.UserID);
                    sltmp01.Add(9, "");
                    sltmp.Add(1, sltmp01);
                    string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-workset-add003", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-workset-add003", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show("恭喜你，实体包已经进入循环成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    #endregion
                }
            }
        }

        private void but_package_Click(object sender, EventArgs e)
        {
            DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select("type_code='HCS-set-incycle_wf'");//获得区域接受编号，如：decon为2020
            string strwork = arrayDR[0]["value_code"].ToString();
            strwork = strwork.Remove(strwork.LastIndexOf(','));
            string[] datalist = strwork.Split(',');//取得package区接收的编号和打包区接收的编号。
            if (setinfor != null)
            {
                //datatable几行就循环几次，在工单中为每一个新的实体包添加记录
                for (int i = 0; i < setinfor.Rows.Count; i++)
                {
                    #region 放进循环时，在package区为新包添加记录
                    CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                    SortedList sltmp = new SortedList();
                    SortedList sltmp01 = new SortedList();
                    sltmp01.Add(1, setinfor.Rows[i]["id"].ToString());
                    sltmp01.Add(2, 0);//无用参数
                    sltmp01.Add(3, 0);//无用参数
                    sltmp01.Add(4, setinfor.Rows[i]["id"].ToString());
                    sltmp01.Add(5, setinfor.Rows[i]["bar_code"].ToString());
                    sltmp01.Add(6, setinfor.Rows[i]["ca_name"].ToString());
                    sltmp01.Add(7, datalist[1]);//打包区接收的动作
                    sltmp01.Add(8, CnasBaseData.UserID);
                    sltmp01.Add(9, "");
                    sltmp.Add(1, sltmp01);
                    string testSQL = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-workset-add003", sltmp, null);
                    int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-workset-add003", sltmp, null);
                    if (recint > -1)
                    {
                        MessageBox.Show("恭喜你，实体包已经进入循环成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    #endregion
                }
            }

        }
    }
}
