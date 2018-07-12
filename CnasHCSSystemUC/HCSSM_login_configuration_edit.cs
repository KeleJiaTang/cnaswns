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

namespace Cnas.wns.CnasHCSSystemUC
{
    public partial class HCSSM_login_configuration_edit : TemplateForm
    {
        SortedList SL_workid = new SortedList();
        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        private string Strselectid = "";//选择的id
        int _location = 0;//控件位置
        string work_id = "";//工作台id
        string saveWorkid = "";//需要保存的值
        public HCSSM_login_configuration_edit(SortedList SLdata)
        {
            InitializeComponent();
            string styStemName = ConfigurationManager.AppSettings["SystemName"].ToString();
			Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            _location = 87;//控件的起始位置的高



            if (SLdata != null)//在窗体上显示信息
            {
                this.Text = styStemName + "--修改配置";
                Strselectid = SLdata["id"].ToString();
                this.tb_MAC.Text = SLdata["mac_address"].ToString();
                this.tb_computer.Text = SLdata["computer"].ToString();
                if (SLdata["remark"] != null)
                    this.tb_remark.Text = SLdata["remark"].ToString();
                work_id = SLdata["work_id"].ToString();
                //string[] Array = SLdata["work_id"].ToString().Split(',');

                //for (int i = 0; i < Array.Length; i++)
                //{
                //    if (Array[i].ToString() != "")
                //    {

                //    }
                //}
            }
            DataTable App = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec010", null);
            if (App != null && App.Rows.Count > 0)
            {
                for (int i = 0; i < App.Rows.Count; i++)
                {

                    SL_workid.Add(App.Rows[i]["app_briefcode"].ToString(), App.Rows[i]["app_name"].ToString());
                    if ( App.Rows[i]["app_briefcode"].ToString() != "")
                        CreDynamicCheckBox(App.Rows[i]["app_briefcode"].ToString(), i);//添加控件
                }
            }
        }

        /// <summary>
        /// 创建CheckBox
        /// </summary>
        /// <param name="Worknum">工作台id</param>
        /// <param name="Num">创建的第几个</param>
        private void CreDynamicCheckBox(string Worknum, int Num)
        {
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, Worknum);
            //   string sql = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-app-sec011", sttemp01);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec011", sttemp01);
            if (getdt != null)
            {

                CheckBox che = new CheckBox();
                che.Size = new Size(130, 24);
                che.Location = new Point(116, _location);
                _location += 33;
                this.Height += 24;
                this.tb_remark.Location = new Point(116, this.tb_remark.Location.Y + 24);
                this.but_OK.Location = new Point(116, this.but_OK.Location.Y + 24);
                this.but_Cancel.Location = new Point(272, this.but_Cancel.Location.Y + 24);
                lb_remark.Location = new Point(57, lb_remark.Location.Y + 24);
                
                che.Name = Worknum;
                che.Text = getdt.Rows[0]["app_name"].ToString();
                che.UseVisualStyleBackColor = true;
                che.FlatStyle = FlatStyle.Standard;
                string[] Array = work_id.Split(',');
                for (int i = 0; i < Array.Length; i++)
                {
                    if (Array[i] == Worknum)
                    {
                        che.Checked = true;
                        saveWorkid += che.Name.ToString() + ",";//需要存的值
                    }
                }
                this.Controls.Add(che);
                che.CheckedChanged += new System.EventHandler(che_CheckedChanged);
            }



        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, tb_MAC.Text.Trim());

            sltmp01.Add(2, tb_computer.Text.Trim());
            sltmp01.Add(3, saveWorkid);
            sltmp01.Add(4, tb_remark.Text.Trim());
            sltmp01.Add(5, Strselectid);
            sltmp.Add(1, sltmp01);
            //string sql = reCnasRemotCall.RemotInterface.CheckUPData(1, "hcs-workspace-binding-up001", sltmp, null);
            int recint = reCnasRemotCall.RemotInterface.UPData(1, "hcs-workspace-binding-up001", sltmp, null);
            if (recint > -1)
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("updatesuccessful", EnumPromptMessage.warning, new string[] { "登录配置" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HCSSM_login_configuration_edit_Load(object sender, EventArgs e)
        {

        }

        private void che_CheckedChanged(object sender, EventArgs e)
        {
            saveWorkid = "";//清空记录
            CheckBox all = sender as CheckBox;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is CheckBox)//判断是否是CheckBox
                {
                    CheckBox chk = ctl as CheckBox;
                    if (chk.Checked == true)
                    {
                        saveWorkid += chk.Name.ToString() + ",";
                    }
                }
            }
           
        }
    }
}
