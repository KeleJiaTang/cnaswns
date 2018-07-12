using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasHCSWorkspaceDecon;
using CnasUI;
using CRD.WinUI.Forms;
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
using Telerik.QuickStart.WinControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Cnas.wns
{
    public partial class CnasMain : Main
    {
        public CnasMain()
        {
            InitializeComponent();
        }

        private DataTable dtappall = new DataTable();
        private DataTable dtappuser = new DataTable();

        private SortedList slappfile = new SortedList();

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CnasMain_Load(object sender, EventArgs e)
        {

            

            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));





            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.pnlBackground.BorderStyle = BorderStyle.None;
            this.radPageViewContent.ViewElement.ShowItemCloseButton = true;

            //更换皮肤
            //ThemeResolutionService.ApplyThemeToControlTree(this, "Windows7");

            //Telerik.WinControls.Themes.Office2010BlueTheme s = new Telerik.WinControls.Themes.Office2010BlueTheme();

            //Telerik.WinControls.Themes.TelerikMetroBlueTheme buleTheme = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            
            Telerik.WinControls.Themes.Office2007SilverTheme officeTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();

            this.ApplyTheme(officeTheme.ThemeName);

            //this.radPageViewContent.ThemeName = s.ThemeName;
            this.radPageViewContent.ThemeName = officeTheme.ThemeName;

            //this.LeftMenu.ThemeName = s.ThemeName;
            this.LeftMenu.ThemeName = officeTheme.ThemeName;

            //this.toolLeft.AllowedDockState &= ~AllowedDockState.All;
            //this.toolLeft.AllowedDockState &= ~AllowedDockState.Floating;
            //this.toolLeft.AllowedDockState &= ~AllowedDockState.TabbedDocument;

            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, CnasBaseData.SystemID);
            //一级目录菜单
            dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-app-sec001", sttemp01);
            SortedList sttemp02 = new SortedList();
            sttemp02.Add(1, CnasBaseData.UserName);

            //string aa = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-user_app-sec001", sttemp02);

            //二级目录菜单
            dtappuser = reCnasRemotCall.RemotInterface.SelectData("HCS-user_app-sec001", sttemp02);

            string up1 = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-app-sec001", sttemp01);
            string up2 = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-user_app-sec001", sttemp02);

            //判断一级二级目录是否有值
            if (dtappall != null && dtappuser != null)
            {
                #region 插入一级目录树
                DataRow[] arrayDR = dtappall.Select("app_type=0");
                foreach (DataRow dr in arrayDR)
                {
                    RadPageViewPage rpvPage = new RadPageViewPage();

                    rpvPage.Font = new Font(rpvPage.Font.FontFamily, 11);

                    rpvPage.Name = dr["app_name"].ToString().Trim();
                    rpvPage.Tag = dr["app_code"].ToString().Trim();
                    rpvPage.Image = ResourcesImageHelper.Instance.GetResourcesImage("MenuIcon", dr["app_code"].ToString());
                    rpvPage.TextAlignment = ContentAlignment.MiddleCenter;
                    this.LeftMenu.Pages.Add(rpvPage);
                }

                #endregion

                #region 插入二级目录树

                try
                {
                    //插入二级目录
					for (int i = 0; i < dtappuser.Rows.Count; i++)
					{
						string str_id = dtappuser.Rows[i]["app_id"].ToString();
						//获得数据的详细数据
						DataRow[] arrayDRdata = dtappall.Select("id=" + str_id);
						if (arrayDRdata.Count() <= 0 || arrayDRdata[0]["state"].ToString() == "0")
							continue;
						string appBreifCode = arrayDRdata[0]["app_briefcode"].ToString();
						string str_app_code = arrayDRdata[0]["app_code"].ToString();
						string str_app_name = arrayDRdata[0]["app_name"].ToString();
						string str_app_parent = arrayDRdata[0]["app_parent"].ToString();
						string str_app_ico = arrayDRdata[0]["app_ico"].ToString();
						string str_app_file = arrayDRdata[0]["app_file"].ToString();

                        try
                        {
                            //获取父级的菜单
                            DataRow[] dtData = dtappall.Select("app_code='" + str_app_parent + "'");
                            string parentName = dtData[0]["app_name"].ToString().Trim();

                            RadPageViewPage parentPage = this.LeftMenu.Pages[parentName];


                            parentPage.Font = new Font(parentPage.Font.FontFamily, 11);


                            parentPage.AutoScroll = true;

                            RadLabel radLi = new RadLabel();

                            radLi.Font = LeftMenu.Font;

                            radLi.AutoSize = false;

                            radLi.Image = ResourcesImageHelper.Instance.GetResourcesImage("MenuIcon", str_app_code);
                            radLi.ImageAlignment = ContentAlignment.TopCenter;

                            //radLi.TextImageRelation = TextImageRelation.Overlay;

                            radLi.Height = 70;
                            radLi.Width = parentPage.Width - 10;

                            radLi.Text = str_app_name;
                            radLi.TextAlignment = ContentAlignment.BottomCenter;

                            radLi.Tag = CnasUtilityTools.ConcatTwoString(appBreifCode, str_app_code);

                            radLi.Cursor = System.Windows.Forms.Cursors.Hand;
                            radLi.Click += radLi_Click;
                            //radLi.Left = 5;

                            if (parentPage.Controls.Count == 0)
                                radLi.Top = 10;
                            else
                                radLi.Top = parentPage.Controls.Count * 82;


                            parentPage.Controls.Add(radLi);
                            slappfile.Add(CnasUtilityTools.ConcatTwoString(appBreifCode, str_app_code), str_app_file);
                        }
                        catch (Exception ex)
                        { 
                        
                        }
						
					}
                }
                catch (Exception ex)
                {
                  
                }
                #endregion
            }
            else
            {
                MessageBox.Show("对不起！请联系管理员先配置用户权限。");
            }
            this.Resize += CnasMain_Resize;

        }

        public void CnasMain_Resize(object sender, EventArgs e)
        {

            //由于放大缩小的时候，UserControl 没有自动缩小放大，所以做一个如下操作，解决这个问题
            //if (this.radDock1.DockWindows.Count > 0)
            //{
            //    //打开则定位到当前选项卡
            //    DockWindow dockWindow = this.radDock1.ActiveWindow;
            //    this.radDock1.ActiveWindow = null;
            //    this.radDock1.ActiveWindow = dockWindow;
            //}
        }

        /// <summary>
        /// 点击显示页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radLi_Click(object sender, EventArgs e)
        {
            RadLabel senderBtn = (RadLabel)sender;

			string strmoduname = senderBtn.Tag.ToString();
            if (strmoduname.Length > 0)
            {
                try
                {
					string[] appInfo = strmoduname.Split(':');
					if (appInfo.Length >=2)
					{
						object result = null;
						Type typeofControl = null;
						Assembly tempAssembly;

						tempAssembly = Assembly.LoadFrom(slappfile[strmoduname].ToString() + ".dll");
						typeofControl = tempAssembly.GetType("Cnas.wns." + slappfile[strmoduname].ToString() + "." + appInfo[1]);
						if (appInfo[0] == "1010" || appInfo[0] == "1020" 
							|| appInfo[0] == "1030" || appInfo[0] == "1050")
							result = Activator.CreateInstance(typeofControl, new object[] { appInfo[0] });
						else
							result = Activator.CreateInstance(typeofControl);
						UserControl contmp = (UserControl)result;

						contmp.Dock = DockStyle.Fill;

						//判断当前打开的页数是否超出10个
						if (this.radPageViewContent.Pages.Count >= 10)
						{
							//如果 页面选项卡超过10个，则关闭第一个
							this.radPageViewContent.Pages.Remove(this.radPageViewContent.Pages[0]);
						}

						string windowsText = senderBtn.Text;
						//判断当前页面是否已经打开当前选项卡
						if (!DocumentWindowsItemList().Keys.Contains(windowsText))
						{
							RadPageViewPage radPageViewPage = new RadPageViewPage(windowsText);
							radPageViewPage.VisibleChanged += OnPageVisibleChanged;


                            radPageViewPage.Image = ResourcesImageHelper.Instance.GetResourcesImage("MenuIcon", appInfo[1] + "_24");

							radPageViewPage.Controls.Add(contmp);
							this.radPageViewContent.Pages.Add(radPageViewPage);
							this.radPageViewContent.SelectedPage = radPageViewPage;
						}
						else
						{
							//打开则定位到当前选项卡
							this.radPageViewContent.SelectedPage = DocumentWindowsItemList()[windowsText];
						}
					}
                }
                catch (Exception ee)
                {
					log4net.ILog logger = log4net.LogManager.GetLogger("CnasWNSClient");
					logger.Error("Menu Click error: {0}", ee);
                    MessageBox.Show(ee.Message);
                }
            }
        }

		void OnPageVisibleChanged(object sender, EventArgs e)
		{
			RadPageViewPage page = sender as RadPageViewPage;
			if (page != null)
			{
				HCSSM_workspace workSpace = CnasUtilityTools.FindControl<HCSSM_workspace>(page);
				if (workSpace != null)
				{
					if (page.Visible)
					{
						workSpace.ScannerHook.Start(false);
					}
					else
					{
						workSpace.ScannerHook.Stop();
					}
				}
			}
		}




        /// <summary>
        /// 获取所有打开的窗体
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, RadPageViewPage> DocumentWindowsItemList()
        {
            Dictionary<string, RadPageViewPage> itemList = new Dictionary<string, RadPageViewPage>();

            foreach (RadPageViewPage item in this.radPageViewContent.Pages)
            {
                itemList.Add(item.Text, item);
            }
            return itemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CnasMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }


        public void ApplyTheme(string themeName)
        {
            //this.ThemeName = themeName;
            //ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }




    }
}
