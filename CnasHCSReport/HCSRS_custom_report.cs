using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnas.wns.CnasBaseClassClient;
using Cnas.wns.CnasBaseUC;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Telerik.QuickStart.WinControls;
using Telerik.WinControls;
using System.Collections;
using System.Reflection;

namespace Cnas.wns.CnasHCSReport
{
    public partial class HCSRS_custom_report : UserControl
    {
        /// <summary>
        /// 一级菜单
        /// </summary>
        //SortedList _levelMenu = new SortedList();

        public HCSRS_custom_report()
        {
            InitializeComponent();


            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, 1);
            sttemp01.Add(2, CnasBaseData.SystemID);
            //二级目录菜单
            DataTable dtappall = new DataTable();
            //string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-custom-dropReport-sel001", sttemp01);
            dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-dropReport-sel001", sttemp01);


            //判断一级二级目录是否有值
            if (dtappall != null)
            {
                #region 插入目录树

                Dictionary<string, RadTreeNode> dic = new Dictionary<string, RadTreeNode>();

                foreach (DataRow item in dtappall.Rows)
                {
                    string name = item["name"].ToString();
                    string id = item["id"].ToString();
                    string type = item["type"].ToString();
                    string parentId = item["parent_id"].ToString();
                    RadTreeNode rtn = new RadTreeNode();
                    rtn.Text = name;
                    rtn.Name = id;
                    rtn.Expanded = true;
                    if (parentId == "0")
                    {
                        rtvCustomTemplate.Nodes.Add(rtn);
                    }
                    dic.Add(id, rtn);
                    if (dic.ContainsKey(parentId) && parentId != "0")
                    {
                        dic[parentId].Nodes.Add(rtn);
                    }
                }
                #endregion
            }
        }

        private void HCSRS_custom_report_Load(object sender, EventArgs e)
        {

        }

        //private void OnIndicatorTypeClick(object sender, EventArgs e)
        //{
        //    RadButton clickedBtn = sender as RadButton;
        //    if (clickedBtn != null && clickedBtn.Tag != null)
        //    {
        //        string indicator = clickedBtn.Tag.ToString();
        //        EIndicator indicatorType = EIndicator.WashingFailed;
        //        Enum.TryParse(indicator, out indicatorType);
        //        HCSRS_common_dialog hh = new HCSRS_common_dialog();
        //        hh.IndicatorType = indicatorType;
        //        hh.ShowDialog();
        //    }

        //}
        /// <summary>
        /// 模板行，点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtvCustomTemplate_NodeMouseClick(object sender, RadTreeViewEventArgs e)
        {


        }
        /// <summary>
        /// 模板行，转换行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtvCustomTemplate_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {

            btnPanel.Controls.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttemp01 = new SortedList();
            sttemp01.Add(1, e.Node.Name.ToString());
            sttemp01.Add(2, 2);
            sttemp01.Add(3, CnasBaseData.SystemID);

            DataTable dtappall = new DataTable();
            // string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-custom-dropReport-sel002", sttemp01);
            dtappall = reCnasRemotCall.RemotInterface.SelectData("HCS-custom-dropReport-sel002", sttemp01);//加载右边显示的按钮
            if (dtappall == null) return;
            //为每条信息动态加载一个button按钮
            for (int i = 0; i < dtappall.Rows.Count; i++)
            {
                RadButton bnt = new RadButton();
                bnt.Text = dtappall.Rows[i]["name"].ToString();
                bnt.Name = dtappall.Rows[i]["id"].ToString();
                bnt.Size = new Size(160, 130);
                bnt.ThemeName = "Office2007Silver";
                bnt.Margin = new Padding(50, 50, 50, 50);
                bnt.TextAlignment = ContentAlignment.MiddleCenter;
                bnt.ImageAlignment = ContentAlignment.MiddleCenter;
                bnt.TextImageRelation = TextImageRelation.ImageAboveText;
                bnt.Image = ResourcesImageHelper.Instance.GetResourcesImage("MenuIcon", "HCSRS_eighteen_indicators");
                bnt.Tag = dtappall.Rows[i];
                btnPanel.Controls.Add(bnt);
                
                bnt.Click += bnt_Click;
            }
        }

        private void bnt_Click(object sender, EventArgs e)
        {
            RadButton selBnt = sender as RadButton;//将触发此事件的对象转换为该Button对象

            if (selBnt !=null)
            {
                if (selBnt.Tag != null && selBnt.Tag is DataRow)
                {
                    DataRow data = selBnt.Tag as DataRow;
                    InvokeFrom(data["filename"].ToString(), data["hcs_namespace"].ToString(), data["hcs_dialogname"].ToString(), data["indicator_type"].ToString() ,data["name"].ToString());
                }
            }
        }

        /// <summary>
        /// 加载dll，显示窗体
        /// </summary>
        /// <param name="lpFileName">dll名称</param>
        /// <param name="Namespace">命名空间</param>
        /// <param name="ClassName">类名</param>
        /// <param name="sqlName">存储过程名称</param>
        private void InvokeFrom(string lpFileName, string nameSpace, string className, string sqlName,string formName)
        {
            try
            {   // 载入程序集
                Assembly myAssembly = Assembly.LoadFrom(lpFileName);

				ReportBaseForm conditionForm = myAssembly.CreateInstance(nameSpace + "." + className) as ReportBaseForm;
				conditionForm.ShowIcon = false;
				conditionForm.IndicatorType = sqlName;
				conditionForm.FormName = formName;
				conditionForm.StartPosition = FormStartPosition.CenterScreen;
				conditionForm.Show();

            }//try
            catch (System.NullReferenceException e)
            {
                MessageBox.Show(e.Message);
            }//catch

        }// Invoke
    }
}
