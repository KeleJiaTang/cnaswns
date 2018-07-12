using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSWorkspaceDecon;
using Cnas.wns.CnasMetroFramework.Forms;
using Cnas.wns.CnasMetroFramework;
using System.Management;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using CRD.Common;



namespace Cnas.wns
{
    public partial class frmLogin : Form
    {
        private string SystemInfo_id = "";
        private string User_name = "";
        private int SiteSelect = 0;
        private string MacAddress;//计算机的MAC地址
        private string ComputerName;//计算机名称
        private string IpAddress;//计算机的IP地址
        CnasRemotCall reCnasRemotCall = new CnasRemotCall();
        public frmLogin()
        {
            InitializeComponent();
            
            MacAddress = GetMacAddress();
			CnasBaseData.MacAddress = MacAddress;
            ComputerName = GetComputerName();
			CnasBaseData.ComputerName = ComputerName;
            IpAddress = GetIPAddress();

            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));


            this.pictureBox1.BackgroundImage = ResourcesImageHelper.Instance.GetResourcesImage("Common.default", "lg_frm_bg02", EnumImageType.PNG);

            SortedList SL_mac = new SortedList();
            SL_mac.Add(1, MacAddress);
            DataTable DT_workspace = reCnasRemotCall.RemotInterface.SelectData("hcs-workspace-binding-sec001 ", SL_mac);
            if (DT_workspace != null )//如果mac地址存在，则读取它的配置显示出来，否则显示默认的（管理办公室）
            {

                string[] array = DT_workspace.Rows[0]["work_id"].ToString().Split(new char[] { ',' });//把工作台id截取出来
                DataTable App = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec010", null);
                if (App != null && App.Rows.Count > 0)
                {
                    for (int i = 0; i < App.Rows.Count; i++)
                    {
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (App.Rows[i]["app_briefcode"].ToString() == array[j])
                            {
                                com_workare.Items.Add(App.Rows[i]["app_briefcode"].ToString() + "-" + App.Rows[i]["app_name"].ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                //添加新的MAC数据
                SortedList SL_work = new SortedList();
                SortedList SL_work_1 = new SortedList();
                SL_work.Add(1, MacAddress);
                SL_work.Add(2, ComputerName);
                SL_work.Add(3, "");
                SL_work.Add(4, IpAddress);
                SL_work_1.Add(1, SL_work);
                int recint = reCnasRemotCall.RemotInterface.UPData(1, "hcs-workspace-binding-add001", SL_work_1, null);

                if (recint <= -1)
                {
                    MessageBox.Show("MAC添加失败。");
                    this.Close();
                }
            }

            getsysxml();
            LoadsystemData();


        }
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public string GetIPAddress()
        {
            try
            {
                //获取IP地址 
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString(); 
                        System.Array ar;
                        ar = (System.Array)(mo.Properties["IpAddress"].Value);
                        st = ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }
        /// <summary> 
        ///  获取计算机名
        /// </summary> 
        /// <returns></returns> 
        public string GetComputerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }

        /// <summary>
        /// 获取计算机的MAC地址（zsx 7-29 修改为获取CPU序列号）
        /// </summary>
        /// <returns></returns>
        public string GetMacAddress()
        {


            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                String strCpuID = null;
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                return strCpuID;
            }
            catch
            {
                return "unknow";
            } 
        }

        private void getsysxml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("configdata.xml");
            XmlNode xn1 = xmlDoc.SelectSingleNode("data");
            XmlNode xn2 = xn1.SelectSingleNode("logindata");
            SystemInfo_id = xn2["defsite"].InnerText;
            int selectIndex = int.Parse(xn2["workspace"].InnerText);
            SiteSelect = selectIndex >= com_workare.Items.Count ? com_workare.Items.Count - 1 : selectIndex;
            User_name = xn2["user"].InnerText;
            tex_user.Text = User_name;
            com_workare.SelectedIndex = SiteSelect;
        }

        private void setsysxml(string inusername, string insite)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("configdata.xml");
            XmlNode xn1 = xmlDoc.SelectSingleNode("data");
            XmlNode xn2 = xn1.SelectSingleNode("logindata");
            xn2["defsite"].InnerText = SystemInfo_id;
            xn2["workspace"].InnerText = insite;
            xn2["user"].InnerText = inusername;
            xmlDoc.Save("configdata.xml");
        }



        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_ok_Click(object sender, EventArgs e)
        {
            if (com_workare.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("Configuration_tips", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tex_user.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("usernameRequired", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tex_pwd.Text.Trim() == "")
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("userPassWordRequired", EnumPromptMessage.warning), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断用户帐号密码是否 正确
            if (!(UserBaseHelper.CheckUserInfo(tex_user.Text.Trim(), tex_pwd.Text.Trim()) > 0))
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("userpassworderror", EnumPromptMessage.error), "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //根据用户名，返回用户信息
            CnasBaseData.UserBaseInfo = UserBaseHelper.UserInfoByUserName(tex_user.Text.Trim());

            CnasBaseData.UserName = tex_user.Text.Trim();
            if (check_rec.Checked == true)
            {
                setsysxml(this.tex_user.Text, com_workare.SelectedIndex.ToString());
            }

            string str_ws = com_workare.Text;
            string str_code = str_ws.Substring(0, 4);
            if (str_code == "9000")
            {
                CnasMain f_frmmin = new CnasMain();
                this.Hide();
                f_frmmin.Show();
            }
            else
            {
				CnasBaseData.UserAccessCustomer = GetUserAccessCustomers(str_code);
				var form = new HCSWF_Workspace(str_ws);
				this.Hide();
				form.ShowDialog();
			}
		}

		private DataTable GetUserAccessCustomers(string appId)
		{
			DataTable customers = null;

			try
			{
				SortedList condition = new SortedList();
				string sql = "HCS-customer-sec001";
				condition.Add(1, "1");
				if (appId == "1050")
				{
					condition.Add(2, CnasBaseData.UserBaseInfo.UserID.ToString());
					sql = "HCS-customer-sec005";
				}
				CnasRemotCall remoteCall = new CnasRemotCall();
				string testSql = remoteCall.RemotInterface.CheckSelectData(sql, condition);
				customers = remoteCall.RemotInterface.SelectData(sql, condition);
				customers = customers ?? new DataTable();
			}
			catch (Exception)
			{
				customers = new DataTable();
			}

			return customers;
		}

        private void but_ok_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.FlatStyle == FlatStyle.Popup)
            {
                btn.FlatStyle = FlatStyle.Flat;

            }
        }

        private void but_ok_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.FlatStyle == FlatStyle.Flat)
            {
                btn.FlatStyle = FlatStyle.Popup;
            }
        }

        private void but_cancel_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.FlatStyle == FlatStyle.Flat)
            {
                btn.FlatStyle = FlatStyle.Popup;
            }
        }

        private void but_cancel_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.FlatStyle == FlatStyle.Popup)
            {
                btn.FlatStyle = FlatStyle.Flat;
            }
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tex_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //but_ok.Focus();
                but_ok_Click(null, null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {


            this.tex_user.Focus();
        }

        private void tex_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                tex_pwd.Focus();
            }
        }
        private void LoadsystemData()
        {
            CnasBaseData.SystemID = SystemInfo_id;
            CnasBaseData.UserID = "1";
            CnasBaseData.UserName = User_name;
            string a = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-systemdata-sec001", null);
            CnasBaseData.SystemBaseData = reCnasRemotCall.RemotInterface.SelectData("HCS-systemdata-sec001", null);
            SortedList sltmp01 = new SortedList();
            sltmp01.Add(1, SystemInfo_id);
            CnasBaseData.SystemInfoData = reCnasRemotCall.RemotInterface.SelectData("HCS-systeminfo-sec001", sltmp01);
            this.lab_customer.Text = CnasBaseData.SystemInfoData.Rows[0]["customer"].ToString();
            this.lab_site.Text = CnasBaseData.SystemInfoData.Rows[0]["site_name"].ToString();
            this.liVersions.Text = "当前版本号：" + CnasBaseData.SystemInfoData.Rows[0]["versions"].ToString();
            this.lab_software.Text = CnasBaseData.SystemInfoData.Rows[0]["sortware_name"].ToString();
			LoadConfigData();
            //MessageBox.Show(CnasBaseData.SystemBaseData.Rows.Count.ToString());
        }

		private void LoadConfigData()
		{
			DataRow[] config = CnasBaseData.SystemBaseData.Select("type_code='HCS-system-settings' and key_code ='SystemVersion'");
			int systemVersion = 1;
			if (config.Length > 0 && config[0]["value_code"] != null)
			{
				int.TryParse(Convert.ToString(config[0]["value_code"]), out systemVersion);
			}
			CnasBaseData.SystemVersion = systemVersion;
		}



       
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
