using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Cnas.wns.CnasBaseClassClient;
using System.Reflection;


namespace Cnas.wns
{
    public partial class frmMain : Form
    {
        private DataTable dtappall = new DataTable();
        private DataTable dtappuser = new DataTable();
        private SortedList slappparent = new SortedList();
        private SortedList slappfile = new SortedList();

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));

        public frmMain()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string str_01data = "";
            qeb_main.ExplorerItems.Clear();


            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec001", sttemp01);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, CnasBaseData.UserName);
            //string aa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-user_app-sec001", sttemp02);
            dtappuser = reCnasRemotCall.RemotInterface.SelectData("HCS-user_app-sec001", sttemp02);
            if (dtappall != null && dtappuser != null)
            {
                #region 插入一级目录树

                DataRow[] arrayDR = dtappall.Select("app_type=0");
                foreach (DataRow dr in arrayDR)
                {
                    Qios.DevSuite.Components.QExplorerItem qei_parent = new Qios.DevSuite.Components.QExplorerItem(this.components);
                    qei_parent.Icon = ((System.Drawing.Icon)(resources.GetObject("qei_tmp.Icon")));
                    qei_parent.ItemName = dr["app_code"].ToString().Trim();
                    qei_parent.Title = dr["app_name"].ToString().Trim();
                    //dr["app_ico"].ToString().Trim();
                    qei_parent.Visible = false;

                    qei_parent.MenuItemActivated += new Qios.DevSuite.Components.QMenuEventHandler(this.qei_parent_MenuItemActivated);
                    this.qeb_main.ExplorerItems.Add(qei_parent);
                    slappparent.Add(dr["app_code"].ToString().Trim(), qei_parent);
                    if (str_01data == "") str_01data = dr["app_code"].ToString().Trim();
                }

                #endregion

                #region 插入二级目录树

                for (int i = 0; i < dtappuser.Rows.Count; i++)
                {
                    string str_id = dtappuser.Rows[i]["app_id"].ToString();
                    DataRow[] arrayDRdata = dtappall.Select("id=" + str_id);
                    string str_app_code = arrayDRdata[0]["app_code"].ToString();
                    string str_app_name = arrayDRdata[0]["app_name"].ToString();
                    string str_app_parent = arrayDRdata[0]["app_parent"].ToString();
                    string str_app_ico = arrayDRdata[0]["app_ico"].ToString();
                    string str_app_file = arrayDRdata[0]["app_file"].ToString();

                    Qios.DevSuite.Components.QExplorerItem qei_myparent = (Qios.DevSuite.Components.QExplorerItem)slappparent[str_app_parent];
                    Qios.DevSuite.Components.QExplorerItem qei_mychild = new Qios.DevSuite.Components.QExplorerItem(this.components);
                    qei_mychild.Icon = ((System.Drawing.Icon)(resources.GetObject("qei_mag.Icon")));
                    qei_mychild.ItemName = str_app_code;
                    qei_mychild.Title = str_app_name;
                    qei_mychild.MenuItemActivated += new Qios.DevSuite.Components.QMenuEventHandler(this.qei_child_MenuItemActivated);
                    qei_myparent.Visible = true;
                    qei_myparent.MenuItems.Add(qei_mychild);
                    slappfile.Add(str_app_code, str_app_file);
                }

                Qios.DevSuite.Components.QExplorerItem qei_myparent01 = (Qios.DevSuite.Components.QExplorerItem)slappparent[str_01data];
                qei_myparent01.Expanded = true;

                #endregion

            }
            else
            {
                MessageBox.Show("对不起！请联系管理员先配置用户权限。");

            }
        }


        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void qei_parent_MenuItemActivated(object sender, Qios.DevSuite.Components.QMenuEventArgs e)
        {
            QExplorerItem qetemp = (QExplorerItem)sender;
            tssl02.Text = qetemp.ItemName + "  parent_MenuItem:" + qetemp.Title;
        }


        private void qei_child_MenuItemActivated(object sender, Qios.DevSuite.Components.QMenuEventArgs e)
        {
            string strmoduname = "";
            QExplorerItem qetemp = (QExplorerItem)sender;
            tssl02.Text = qetemp.ItemName + "  child_MenuItem:" + qetemp.Title;
            strmoduname = qetemp.ItemName.Trim();
            if (strmoduname.Length > 0)
            {
                try
                {
                    object result = null;
                    Type typeofControl = null;
                    Assembly tempAssembly;
                    tempAssembly = Assembly.LoadFrom(slappfile[strmoduname].ToString() + ".dll");
                    typeofControl = tempAssembly.GetType("Cnas.wns." + slappfile[strmoduname].ToString() + "." + strmoduname);
                    result = Activator.CreateInstance(typeofControl);
                    UserControl contmp = (UserControl)result;
                    contmp.Dock = DockStyle.Fill;

                    spc_info.Panel2.Controls.Clear();
                    spc_info.Panel2.Controls.Add(contmp);

                    //frmmid frmnew = new frmmid(contmp);
                    //frmnew.ShowDialog();                    
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void qei_user_MenuItemActivated(object sender, Qios.DevSuite.Components.QMenuEventArgs e)
        {
            string strmoduname = "";
            QExplorerItem qetemp = (QExplorerItem)sender;
            tssl02.Text = qetemp.ItemName + ":" + qetemp.Title;
            strmoduname = qetemp.ItemName.Trim();
            if (strmoduname.Length > 0)
            {
                frmmid frmnew = new frmmid(strmoduname);
                frmnew.ShowDialog();
            }
        }

        private void tsm_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}

