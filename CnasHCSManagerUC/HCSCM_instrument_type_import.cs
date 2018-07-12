using Cnas.wns.CnasBaseClassClient;
using CnasUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_instrument_type_import : TemplateForm
    {
        /// <summary>
        /// 列名
        /// </summary>
        string ColumnName = "";
        // 定义下拉列表框  
        private ComboBox cmb_Temp = new ComboBox();//成本中心
        //创建集合
        private SortedList sl_type = new SortedList();//存放客户(id与名字)
        private SortedList sl_type_02 = new SortedList();//存放客户(code)
        private SortedList sl_cc = new SortedList();//成本中心(id)
        private SortedList sl_cc_02 = new SortedList();//成本中心(code)
        private SortedList sl_type_complexity = new SortedList();//清洗难度  
        private SortedList sl_vender = new SortedList();//生产商
        private SortedList sl_sales = new SortedList();//销售商
        private SortedList sl_Itype = new SortedList();//器械类型
        private SortedList sl_type_washing = new SortedList();//清洗类型
        private SortedList sl_type_sterilization = new SortedList();//灭菌类型
        //存放成本中心的表，用于验证导入的excel中客户与成本中心的关系是否正确
        DataTable DTcc = new DataTable();
        public HCSCM_instrument_type_import()
        {
            InitializeComponent();
            #region Button图标

            this.radBut_downloadw.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "downloadImportTemplate", EnumImageType.PNG);
            this.but_ok.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "OK", EnumImageType.PNG);
            this.but_cancel.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "cancel", EnumImageType.PNG);
            this.but_import.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "import", EnumImageType.PNG);
            this.radBut_delete.Image = ResourcesImageHelper.Instance.GetResourcesImage("Common.Buttom", "deleteRow", EnumImageType.PNG);
            #endregion
            //设置窗体图标
            this.Icon = new Icon(ResourcesImageHelper.Instance.GetResourcesStream("Common.icon", "MainIco", EnumImageType.ICO));
            //this.Font = new Font(this.Font.FontFamily, 11);
            this.cmb_Temp.Visible = false;
            this.cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dgv_01.CurrentCellChanged += dgv_01_CurrentCellChanged;
            this.dgv_01.ColumnWidthChanged += dgv_01_ColumnWidthChanged;
            this.dgv_01.Scroll += dgv_01_Scroll;


            this.cmb_Temp.SelectedIndexChanged += cmb_Temp_SelectedIndexChanged;
            this.cmb_Temp.DrawItem += cmb_Temp_DrawItem;

            //将下拉列表加入到DataGridView的控件集合内，否则下拉列表不会显示在你点击的单元格上 
            this.dgv_01.Controls.Add(cmb_Temp);


            #region 给集合赋值
            CnasRemotCall CRkey_value = new CnasRemotCall();
            SortedList SLkey_value = new SortedList();
            SLkey_value.Add("id_type", CnasBaseData.SystemID);
            DataSet DSnorm = new DataSet();
            DSnorm = CRkey_value.RemotInterface.ExecuteProcedure("key_value", SLkey_value);
            if (DSnorm != null)
            {

                #region 给客户数组赋值
                int ii = DSnorm.Tables[0].Rows.Count;
                if (ii <= 0) return;
                for (int i = 0; i < ii; i++)
                {
                    if (DSnorm.Tables[0].Rows[i]["id"].ToString() != null && DSnorm.Tables[0].Rows[i]["cu_name"].ToString().Trim() != null)
                    {
                        sl_type.Add(DSnorm.Tables[0].Rows[i]["id"].ToString(), DSnorm.Tables[0].Rows[i]["cu_name"].ToString().Trim());
                        sl_type_02.Add(DSnorm.Tables[0].Rows[i]["bar_code"].ToString(), DSnorm.Tables[0].Rows[i]["cu_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给成本中心数组赋值
                DTcc = DSnorm.Tables[1];
                int ii_1 = DSnorm.Tables[1].Rows.Count;
                if (ii_1 <= 0) return;
                for (int i = 0; i < ii_1; i++)
                {
                    if (DSnorm.Tables[1].Rows[i]["id"].ToString() != null && DSnorm.Tables[1].Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_cc.Add(DSnorm.Tables[1].Rows[i]["id"].ToString(), DSnorm.Tables[1].Rows[i]["ca_name"].ToString().Trim());
                        sl_cc_02.Add(DSnorm.Tables[1].Rows[i]["bar_code"].ToString(), DSnorm.Tables[1].Rows[i]["ca_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给清洗难度数组赋值
                int ii_2 = DSnorm.Tables[2].Rows.Count;
                if (ii_2 <= 0) return;
                for (int i = 0; i < ii_2; i++)
                {
                    if (DSnorm.Tables[2].Rows[i]["key_code"].ToString() != null && DSnorm.Tables[2].Rows[i]["value_code"].ToString().Trim() != null)
                    {
                        sl_type_complexity.Add(DSnorm.Tables[2].Rows[i]["key_code"].ToString(), DSnorm.Tables[2].Rows[i]["value_code"].ToString().Trim());
                    }
                }
                #endregion

                #region 给生产商数组赋值
                int ii_3 = DSnorm.Tables[3].Rows.Count;
                if (ii_3 <= 0) return;
                for (int i = 0; i < ii_3; i++)
                {
                    if (DSnorm.Tables[3].Rows[i]["id"].ToString() != null && DSnorm.Tables[3].Rows[i]["v_name"].ToString().Trim() != null)
                    {
                        sl_vender.Add(DSnorm.Tables[3].Rows[i]["id"].ToString(), DSnorm.Tables[3].Rows[i]["v_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给销售商数组赋值
                int ii_4 = DSnorm.Tables[4].Rows.Count;
                if (ii_4 <= 0) return;
                for (int i = 0; i < ii_4; i++)
                {
                    if (DSnorm.Tables[4].Rows[i]["id"].ToString() != null && DSnorm.Tables[4].Rows[i]["v_name"].ToString().Trim() != null)
                    {
                        sl_sales.Add(DSnorm.Tables[4].Rows[i]["id"].ToString(), DSnorm.Tables[4].Rows[i]["v_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给器械类型数组赋值
                int ii_5 = DSnorm.Tables[5].Rows.Count;
                if (ii_5 <= 0) return;
                for (int i = 0; i < ii_5; i++)
                {
                    if (DSnorm.Tables[5].Rows[i]["key_code"].ToString() != null && DSnorm.Tables[5].Rows[i]["value_code"].ToString().Trim() != null)
                    {
                        sl_Itype.Add(DSnorm.Tables[5].Rows[i]["key_code"].ToString(), DSnorm.Tables[5].Rows[i]["value_code"].ToString().Trim());
                    }
                }
                #endregion

                #region 给清洗程序数组赋值
                sl_type_washing.Add("0", "无清洗程序");
                int ii_6 = DSnorm.Tables[6].Rows.Count;
                if (ii_6 <= 0) return;
                for (int i = 0; i < ii_6; i++)
                {
                    if (DSnorm.Tables[6].Rows[i]["id"].ToString() != null && DSnorm.Tables[6].Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_washing.Add(DSnorm.Tables[6].Rows[i]["id"].ToString(), DSnorm.Tables[6].Rows[i]["pr_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给灭菌程序数组赋值
                sl_type_sterilization.Add("0", "无灭菌程序");
                int ii_7 = DSnorm.Tables[7].Rows.Count;
                if (ii_7 <= 0) return;
                for (int i = 0; i < ii_7; i++)
                {
                    if (DSnorm.Tables[7].Rows[i]["id"].ToString() != null && DSnorm.Tables[7].Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_sterilization.Add(DSnorm.Tables[7].Rows[i]["id"].ToString(), DSnorm.Tables[7].Rows[i]["pr_name"].ToString().Trim());
                    }
                }
                #endregion
            }
            #endregion

            //表格栏底色
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //DGV表格首行字段居中对齐
            dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }
        /// <summary>
        /// 可视方位发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmb_Temp_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(this.cmb_Temp.Items[e.Index].ToString(), e.Font, Brushes.Black,
                e.Bounds, StringFormat.GenericDefault);
        }

        /// <summary>
        /// 下拉列表属性值发生改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmb_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果下拉列表值发生改变，则需要在这里做记录
            if (dgv_01.CurrentCell != null)

                dgv_01.CurrentCell.Value = cmb_Temp.Items[cmb_Temp.SelectedIndex];

        }

        /// <summary>
        /// 滚动控件的时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgv_01_Scroll(object sender, ScrollEventArgs e)
        {
            this.cmb_Temp.Visible = false;
        }

        /// <summary>
        /// 数据列表宽度发生改变时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgv_01_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.cmb_Temp.Visible = false;
        }
        private void radBut_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdUploadFile = new OpenFileDialog();
            ofdUploadFile.Filter = "微软Excel工作表 (*.xlsx)|*.xlsx|(*.xls)|*.xls";
            ofdUploadFile.FilterIndex = 1;

            try
            {
                if (ofdUploadFile.ShowDialog() == DialogResult.OK)
                {
                    //获取上传已经转为DataTable的数据
                    DataTable dtSource = ExcelHelper.ExcelToDataTable("*", ofdUploadFile.FileName);

                    if (dtSource.Rows.Count > 0)
                    {
                        //这里加入For循环，就可以实现对导入数据的控制（加入验证）
                        //处理导入的数据
                        //foreach (var item in dtSource.Rows)
                        //{

                        //}
                        //对导入的数据检查，判断
                        for (int i = 0; i < dtSource.Rows.Count; i++)
                        {
                            try
                            {
                                //if (dtSource.Rows[i]["客户（索引）"].ToString() != DTcc.Select("id=" + dtSource.Rows[i]["成本中心（索引）"].ToString())[0]["cu_id"].ToString())
                                //{
                                //    MessageBox.Show("Excel表中第" + (i + 1) + "行成本中心与客户不匹配，请做注意修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["客户（索引）"].ToString()))
                                {
                                    ColumnName = "客户";
                                    dtSource.Rows[i]["客户（索引）"] = sl_type.GetByIndex(sl_type.IndexOfKey(dtSource.Rows[i]["客户（索引）"])).ToString();
                                }
                                   
                                //string a = dtSource.Rows[i]["客户（索引）"].ToString();
                                //string b = DTcc.Select("id=" + dtSource.Rows[i]["成本中心（索引）"].ToString())[0]["cu_id"].ToString();
                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["成本中心（索引）"].ToString()))
                                {
                                    ColumnName = "成本中心";
                                    dtSource.Rows[i]["成本中心（索引）"] = sl_cc.GetByIndex(sl_cc.IndexOfKey(dtSource.Rows[i]["成本中心（索引）"])).ToString();
                                }

                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["清洗难度（索引）"].ToString()))
                                {
                                    ColumnName = "清洗难度";
                                    dtSource.Rows[i]["清洗难度（索引）"] = dtSource.Rows[i]["清洗难度（索引）"].ToString() + ":" + sl_type_complexity.GetByIndex(sl_type_complexity.IndexOfKey(dtSource.Rows[i]["清洗难度（索引）"])).ToString();
                                }

                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["生产商（索引）"].ToString()))
                                {
                                    ColumnName = "生产商";
                                    dtSource.Rows[i]["生产商（索引）"] = sl_vender.GetByIndex(sl_vender.IndexOfKey(dtSource.Rows[i]["生产商（索引）"])).ToString();
                                }

                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["销售商（索引）"].ToString()))
                                {
                                    ColumnName = "销售商";
                                    dtSource.Rows[i]["销售商（索引）"] = sl_sales.GetByIndex(sl_sales.IndexOfKey(dtSource.Rows[i]["销售商（索引）"])).ToString();
                                }

                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["器械类型（索引）"].ToString()))
                                {
                                    ColumnName = "器械类型";
                                    dtSource.Rows[i]["器械类型（索引）"] = dtSource.Rows[i]["器械类型（索引）"] + ":" + sl_Itype.GetByIndex(sl_Itype.IndexOfKey(dtSource.Rows[i]["器械类型（索引）"])).ToString();
                                }

                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["清洗程序（索引）"].ToString()))
                                {
                                    ColumnName = "清洗程序";
                                    dtSource.Rows[i]["清洗程序（索引）"] = sl_type_washing.GetByIndex(sl_type_washing.IndexOfKey(dtSource.Rows[i]["清洗程序（索引）"])).ToString();
                                }

                                if (!string.IsNullOrEmpty(dtSource.Rows[i]["灭菌程序（索引）"].ToString()))
                                {
                                    ColumnName = "灭菌程序";
                                    dtSource.Rows[i]["灭菌程序（索引）"] = sl_type_sterilization.GetByIndex(sl_type_sterilization.IndexOfKey(dtSource.Rows[i]["灭菌程序（索引）"])).ToString();
                                }
                                   
                            }
                            catch
                            {
                                MessageBox.Show("Excel表中第" + (i + 1) + "行" + ColumnName + "存在错误，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }


                        }
                        //导入的数据赋给数据源
                        this.dgv_01.DataSource = dtSource;
                        //给dgv_01后6项字段设置宽度
                        for (int j = 6; j < dgv_01.Columns.Count; j++)
                        {
                            dgv_01.Columns[j].Width = 154;
                        }
                        //给dgv_01添加comboBox
                        dgv_01.Controls.Add(cmb_Temp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 下载导入模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBut_downloadw_Click(object sender, EventArgs e)
        {
            string DownLoadPath = ConfigurationManager.AppSettings["DownLoadPath"].ToString();

            DownLoadPath += "\\InstrumentImportTem.xlsx";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = " doc files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName += "手术器械导入模板.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WebClient client = new WebClient();
                try
                {
                    client.DownloadFile(DownLoadPath, saveFileDialog1.FileName);
                    MessageBox.Show("下载成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    client.Dispose();
                }
            }

        }

        private Dictionary<string, string> _tempData = new Dictionary<string, string>();

        /// <summary>
        /// 确定，添加器械模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBut_ok_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0) return;
            _tempData.Clear();
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp02 = new SortedList();
            sttmp02.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttmp02);


            //检查输入的数据是否符合要求
            for (int a = 0; a < dgv_01.Rows.Count - 1; a++)
            {
                try
                {

                    if (!_tempData.ContainsKey(dgv_01.Rows[a].Cells["器械名称"].Value.ToString()))
                        _tempData.Add(dgv_01.Rows[a].Cells["器械名称"].Value.ToString(), dgv_01.Rows[a].Cells["器械名称"].ToString());


                    #region 对需要导入的数据做验证
                    double u;

                    #region 判断名称在数据库中是否重复
                    if (getdt != null)
                    {
                        int ii = getdt.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                            if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                            {
                                if (dgv_01.Rows[a].Cells["器械名称"].Value.ToString().Trim() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                {
                                    if (dgv_01.Rows[a].Cells["器械名称"].Value.ToString().Trim() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                    {
                                        MessageBox.Show("第" + (a + 1) + "行器械名称已经存在，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                    }
                    #endregion

                    #region 判断导入的数据是否存在重名的数据
                    //int isExit = 0;
                    //for (int i = a; i < dgv_01.Rows.Count - a; i++)
                    //{
                    //    if (dgv_01.Rows[a].Cells["器械名称"] != null && dgv_01.Rows[a].Cells["器械名称"].Value != null 
                    //        &&_tempData.ContainsKey(dgv_01.Rows[a].Cells["器械名称"].Value.ToString()))
                    //    {
                    //        isExit++;
                    //        break;
                    //       
                    //    }
                    //    //if (dgv_01.Rows[a].Cells["器械名称"].Value.ToString().Trim() == dgv_01.Rows[i+1].Cells["器械名称"].Value.ToString().Trim())
                    //    //{
                    //    //    MessageBox.Show("第" + (a + 1) + "行器械名称重复，请做查证后再保存。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //    return;
                    //    //}
                    //}

                    //if (_tempData.Count == dgv_01.Rows.Count)
                    //{
                    //    MessageBox.Show("第" + (a + 1) + "行器械名称重复，请做查证后再保存。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}


                    #endregion


                    if (dgv_01.Rows[a].Cells["器械名称"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行器械名称不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (dgv_01.Rows[a].Cells["价格"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行价格不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!double.TryParse(dgv_01.Rows[a].Cells["价格"].Value.ToString().Trim(), out u))
                    {
                        MessageBox.Show("价格必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    if (dgv_01.Rows[a].Cells["客户（索引）"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行客户（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (dgv_01.Rows[a].Cells["成本中心（索引）"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行成本中心（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //if (dgv_01.Rows[a].Cells["清洗难度（索引）"].Value.ToString().Trim() == "")
                    //{
                    //    MessageBox.Show("第" + (a + 1) + "行清洗难度（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    if (dgv_01.Rows[a].Cells["生产商（索引）"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行生产商（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (dgv_01.Rows[a].Cells["销售商（索引）"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行销售商（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (dgv_01.Rows[a].Cells["器械类型（索引）"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("第" + (a + 1) + "行器械类型（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ////如果选择的不是辅料或一次性物品
                    //if (dgv_01.Rows[a].Cells["器械类型（索引）"].Value.ToString().Trim() != "2:辅料" && dgv_01.Rows[a].Cells["器械类型（索引）"].Value.ToString().Trim() != "3:敷料")
                    //{

                    //    if (dgv_01.Rows[a].Cells["品牌"].Value.ToString().Trim() == "")
                    //    {
                    //        MessageBox.Show("第" + (a + 1) + "行品牌不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }

                    //    if (dgv_01.Rows[a].Cells["清洗程序（索引）"].Value.ToString().Trim() == "")
                    //    {
                    //        MessageBox.Show("第" + (a + 1) + "行清洗程序（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //    if (dgv_01.Rows[a].Cells["灭菌程序（索引）"].Value.ToString().Trim() == "")
                    //    {
                    //        MessageBox.Show("第" + (a + 1) + "行灭菌程序（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }

                    //}
                    if (dgv_01.Rows[a].Cells["可用次数"].Value.ToString().Trim() == "")
                    {
                        dgv_01.Rows[a].Cells["可用次数"].Value = "NULL";

                    }
                    if (!double.TryParse(dgv_01.Rows[a].Cells["可用次数"].Value.ToString().Trim(), out u))
                    {
                        MessageBox.Show("可用次数必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    if (dgv_01.Rows[a].Cells["重量"].Value.ToString().Trim() == "")
                    {
                        dgv_01.Rows[a].Cells["重量"].Value = "NULL";
                    }
                    if (!double.TryParse(dgv_01.Rows[a].Cells["重量"].Value.ToString().Trim(), out u))
                    {
                        MessageBox.Show("重量必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    if (dgv_01.Rows[a].Cells["长度"].Value.ToString().Trim() == "")
                    {
                        dgv_01.Rows[a].Cells["长度"].Value = "";
                    }
                    if (sl_type.GetKey(sl_type.IndexOfValue(dgv_01.Rows[a].Cells["客户（索引）"].Value.ToString().Trim())).ToString() !=
                        DTcc.Select("id=" + sl_cc.GetKey(sl_cc.IndexOfValue(dgv_01.Rows[a].Cells["成本中心（索引）"].Value.ToString().Trim())))[0]["cu_id"].ToString())//判断客户与成本中心是否匹配
                    {
                        MessageBox.Show("第" + (a + 1) + "行成本中心与客户不匹配，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion
                }
                catch
                {
                    MessageBox.Show("模板有误，请选择下载的模板", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

            if (_tempData.Count != dgv_01.Rows.Count - 1)//判断dgv中是否有重复名称的存在
            {
                MessageBox.Show("导入的数据中存在器械名称重复，请做查证后再保存。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #region 创建需要导入的数据
            SortedList sltmp01 = new SortedList();

            for (int j = 0; j < dgv_01.Rows.Count - 1; j++)
            {
                SortedList sltmp = new SortedList();
                sltmp.Add(1, dgv_01.Rows[j].Cells["器械名称"].Value.ToString().Trim());

                sltmp.Add(2, sl_cc_02.GetKey(sl_cc_02.IndexOfValue(dgv_01.Rows[j].Cells["成本中心（索引）"].Value.ToString().Trim())));//成本中心
                sltmp.Add(3, sl_type_02.GetKey(sl_type_02.IndexOfValue(dgv_01.Rows[j].Cells["客户（索引）"].Value.ToString().Trim())));//顾客
                //如果选择的不是辅料或敷料
                if (dgv_01.Rows[j].Cells["器械类型（索引）"].Value.ToString().Trim() != "2:辅料" && dgv_01.Rows[j].Cells["器械类型（索引）"].Value.ToString().Trim() != "3:敷料" && dgv_01.Rows[j].Cells["灭菌程序（索引）"].Value.ToString().Trim() != "")
                {
                    sltmp.Add(4, sl_type_sterilization.GetKey(sl_type_sterilization.IndexOfValue(dgv_01.Rows[j].Cells["灭菌程序（索引）"].Value.ToString().Trim())).ToString());//清洗程序
                }
                else
                {
                    sltmp.Add(4, "NULL");
                }
                if (dgv_01.Rows[j].Cells["清洗难度（索引）"].Value.ToString().Trim() != "")
                {
                    sltmp.Add(5, dgv_01.Rows[j].Cells["清洗难度（索引）"].Value.ToString().Trim().Substring(0, 1));//清洗难度
                }
                else
                {
                    sltmp.Add(5, "NULL");
                }

                sltmp.Add(6, sl_vender.GetKey(sl_vender.IndexOfValue(dgv_01.Rows[j].Cells["生产商（索引）"].Value.ToString().Trim())).ToString());
                //如果选择的不是辅料或敷料
                if (dgv_01.Rows[j].Cells["器械类型（索引）"].Value.ToString().Trim() != "2:辅料" && dgv_01.Rows[j].Cells["器械类型（索引）"].Value.ToString().Trim() != "3:敷料" && dgv_01.Rows[j].Cells["清洗程序（索引）"].Value.ToString().Trim() != "")
                {
                    sltmp.Add(7, sl_type_washing.GetKey(sl_type_washing.IndexOfValue(dgv_01.Rows[j].Cells["清洗程序（索引）"].Value.ToString().Trim())).ToString());
                }
                else
                {
                    sltmp.Add(7, "NULL");
                }

                sltmp.Add(8, dgv_01.Rows[j].Cells["品牌"].Value.ToString().Trim());//型号
                sltmp.Add(9, dgv_01.Rows[j].Cells["价格"].Value.ToString().Trim());//价格
                sltmp.Add(10, dgv_01.Rows[j].Cells["可用次数"].Value.ToString().Trim());//次数
                sltmp.Add(11, dgv_01.Rows[j].Cells["重量"].Value.ToString().Trim());//重量
                sltmp.Add(12, dgv_01.Rows[j].Cells["长度"].Value.ToString().Trim());//大小
                sltmp.Add(13, dgv_01.Rows[j].Cells["器械类型（索引）"].Value.ToString().Trim().Substring(0, 1));
                sltmp.Add(14, sl_sales.GetKey(sl_sales.IndexOfValue(dgv_01.Rows[j].Cells["销售商（索引）"].Value.ToString().Trim())).ToString());
                sltmp.Add(15, CnasBaseData.SystemID);
                sltmp01.Add(j, sltmp);

            }

            // string hgg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-base-add01", sltmp01, null);
            int recint = reCnasRemotCall.RemotInterface.UPDataList("HCS-instrument-base-add01", sltmp01);
            if (recint > -1)
            {
                MessageBox.Show("恭喜你，增加成功。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            #endregion
        }

        private void radBut_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// 给下拉框赋值
        /// </summary>
        /// <param name="Sql_name">需要用到的sql名称</param>
        /// <param name="type">查的类型</param>
        /// <param name="value">特殊值</param>
        private void Load_Box(string Sql_name, int type, string value)
        {
            if (type == 1)//特殊类型1，根据客户名称查客户对应的成本中心
            {
                string str = "";
                if (sl_type.Count != 0 && value != "")//数组有值则取其中的名称
                {
                    try
                    {
                        str = sl_type.GetKey(sl_type.IndexOfValue(value)).ToString();//获取键，即cu_id
                    }
                    catch
                    {
                        MessageBox.Show("客户的键值出现异常，请联系管理员", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList Sl_cu = new SortedList();
                Sl_cu.Add(1, str);

                //    string test_sql = reCnasRemotCall.RemotInterface.CheckSelectData(Sql_name, Sl_cu);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData(Sql_name, Sl_cu);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["ca_name"].ToString().Trim() != null && getdt.Rows[i]["bar_code"].ToString().Trim() != null)
                        {
                            cmb_Temp.Items.Add(getdt.Rows[i]["ca_name"].ToString().Trim());
                        }
                    }
                }
            }
            else if (type == 2)//特殊类型2，给下拉列表赋值并存储客户的id与名称
            {
                sl_type.Clear();
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList Sl_cu = new SortedList();
                Sl_cu.Add(1, CnasBaseData.SystemID);

                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData(Sql_name, Sl_cu);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["cu_name"].ToString().Trim() != null && getdt.Rows[i]["bar_code"].ToString().Trim() != null)
                        {
                            sl_type.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["cu_name"].ToString().Trim());
                            cmb_Temp.Items.Add(getdt.Rows[i]["cu_name"].ToString().Trim());
                        }
                    }
                }
            }
            else if (type == 3)//类型3，生产商销售商的值
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList Sl_cu = new SortedList();
                Sl_cu.Add(1, value);
                string test_sql = reCnasRemotCall.RemotInterface.CheckSelectData(Sql_name, Sl_cu);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData(Sql_name, Sl_cu);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["v_name"].ToString().Trim() != null)
                        {
                            cmb_Temp.Items.Add(getdt.Rows[i]["v_name"].ToString().Trim());
                        }
                    }
                }
            }
            else if (type == 4)//类型4，清洗、灭菌类型
            {
                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData(Sql_name, null);
                this.cmb_Temp.Items.Add(value);
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (getdt.Rows[i]["id"].ToString() != null && getdt.Rows[i]["pr_name"].ToString().Trim() != null)
                        {

                            cmb_Temp.Items.Add(getdt.Rows[i]["pr_name"].ToString().Trim());
                        }
                    }
                }
            }
            else//清洗难度和器械类型
            {
                DataRow[] arrayDR = CnasBaseData.SystemBaseData.Select(Sql_name);
                foreach (DataRow dr in arrayDR)
                {

                    this.cmb_Temp.Items.Add(dr["key_code"].ToString().Trim() + ":" + dr["value_code"].ToString().Trim());
                }
            }


        }


        private void dgv_01_CurrentCellChanged(object sender, EventArgs e)
        {

            if (this.dgv_01.CurrentCell == null) return;
            cmb_Temp.Visible = false;

            DataGridViewColumn column = dgv_01.CurrentCell.OwningColumn;
            //如果是要显示下拉列表的列的话
            #region 添加客户下拉框
            if (column.Name.Equals("客户（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("HCS-customer-sec001", 2, null);
            }
            #endregion

            #region 添加成本中心下拉框
            if (column.Name.Equals("成本中心（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;
                Load_Box("HCS-costcenter-sec002", 1, dgv_01.Rows[rowIndex].Cells[columnIndex - 1].Value.ToString());
            }
            #endregion

            #region 添加生产商下拉框
            if (column.Name.Equals("生产商（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("HCS-vender-sec001", 3, "1");
            }
            #endregion

            #region 添加销售商下拉框
            if (column.Name.Equals("销售商（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("HCS-vender-sec001", 3, "2");
            }
            #endregion

            #region 添加器械类型下拉框
            if (column.Name.Equals("器械类型（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("type_code='HCS_instrument_type'", 0, null);
            }
            #endregion

            #region 添加清洗难度下拉框
            if (column.Name.Equals("清洗难度（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("type_code='HCS_set_complexity'", 0, null);
            }
            #endregion

            #region 添加清洗程序下拉框
            if (column.Name.Equals("清洗程序（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("HCS-washing-program-sec001", 4, "无清洗程序");
            }
            #endregion

            #region 添加灭菌程序下拉框
            if (column.Name.Equals("灭菌程序（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                Rectangle rect = dgv_01.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                cmb_Temp.Left = rect.Left;
                cmb_Temp.Top = rect.Top;
                cmb_Temp.Width = rect.Width;
                cmb_Temp.Height = rect.Height;
                //将单元格的内容显示为下拉列表的当前项
                string consultingRoom = dgv_01.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int index = cmb_Temp.Items.IndexOf(consultingRoom);
                cmb_Temp.SelectedIndex = index;
                cmb_Temp.Visible = true;

                Load_Box("HCS-sterilizer-program-sec001", 4, "无灭菌程序");
            }
            #endregion
        }
        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBut_delete_Click(object sender, EventArgs e)
        {

            if (this.dgv_01.SelectedRows.Count > 0)
            {
                int num = this.dgv_01.SelectedRows.Count;
                for (int i = 0; i < num; i++)
                {
                    DataRowView drv = dgv_01.SelectedRows[0].DataBoundItem as DataRowView;
                    if (drv != null)
                        drv.Delete();
                }
            }
            else
            {
                MessageBox.Show("请选择一行。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void dgv_01_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("录入数据异常，请查询。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
