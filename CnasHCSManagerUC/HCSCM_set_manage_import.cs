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
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Cnas.wns.CnasHCSManagerUC
{
    public partial class HCSCM_set_manage_import : TemplateForm
    {
        // 定义下拉列表框  
        private ComboBox cmb_Temp = new ComboBox();//成本中心
        private ComboBox cmb_vender_sales = new ComboBox();//生产销售商


        //创建集合
        private SortedList sl_type = new SortedList();//存放客户(id与名字)
        private SortedList sl_type_02 = new SortedList();//存放客户(code)
        private SortedList sl_cc = new SortedList();//成本中心(id)
        private SortedList sl_cc_02 = new SortedList();//成本中心(code)
        private SortedList sl_type_complexity = new SortedList();//清洗难度  
        private SortedList sl_material = new SortedList();//打包材料
        private SortedList sl_material2 = new SortedList();//保质期
        private SortedList sl_settype = new SortedList();//包的类型
        private SortedList sl_type_washing = new SortedList();//清洗类型
        private SortedList sl_type_sterilization = new SortedList();//灭菌类型
        private SortedList sl_vender = new SortedList();//生产商
        private SortedList sl_sales = new SortedList();//销售商
        //存放成本中心的表，用于验证导入的excel中客户与成本中心的关系是否正确
        DataTable DTcc = new DataTable();
        //存放存储过程查出的所有表
        DataSet DS_pnorm = null;
        public HCSCM_set_manage_import()
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
            this.cmb_vender_sales.Visible = false;
            this.cmb_vender_sales.DropDownStyle = ComboBoxStyle.DropDownList;

            this.dgv_01.CurrentCellChanged += dgv_01_CurrentCellChanged;
            this.dgv_01.ColumnWidthChanged += dgv_01_ColumnWidthChanged;
            this.dgv_01.Scroll += dgv_01_Scroll;


            this.cmb_Temp.SelectedIndexChanged += cmb_Temp_SelectedIndexChanged;
            this.cmb_Temp.DrawItem += cmb_Temp_DrawItem;
            this.cmb_vender_sales.SelectedIndexChanged += cmb_vender_sales_SelectedIndexChanged;
            this.cmb_vender_sales.DrawItem += cmb_vender_sales_DrawItem;

            //将下拉列表加入到DataGridView的控件集合内，否则下拉列表不会显示在你点击的单元格上 
            this.dgv_01.Controls.Add(cmb_Temp);

            //表格栏底色
            dgv_01.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgv_01.RowsDefaultCellStyle.BackColor = Color.White;
            //DGV表格首行字段居中对齐
            dgv_01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_01.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //只能选择一行
            //this.dgv_01.MultiSelect = false;


            #region 给集合赋值
            CnasRemotCall CRkey_value = new CnasRemotCall();
            SortedList SLkey_value = new SortedList();
            SLkey_value.Add("siid_type", CnasBaseData.SystemID);
            DataSet DSnorm = new DataSet();
            DSnorm = CRkey_value.RemotInterface.ExecuteProcedure("set_keyvalue", SLkey_value);
            DS_pnorm = DSnorm;
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

                #region 给打包材料赋值
                int ii_3 = DSnorm.Tables[3].Rows.Count;
                if (ii_3 <= 0) return;
                for (int i = 0; i < ii_3; i++)
                {
                    if (DSnorm.Tables[3].Rows[i]["id"].ToString() != null && DSnorm.Tables[3].Rows[i]["ca_name"].ToString().Trim() != null)
                    {
                        sl_material.Add(DSnorm.Tables[3].Rows[i]["id"].ToString(), DSnorm.Tables[3].Rows[i]["ca_name"].ToString().Trim());
                        sl_material2.Add(DSnorm.Tables[3].Rows[i]["id"].ToString(), DSnorm.Tables[3].Rows[i]["expiration_day"].ToString().Trim());
                    }
                }
                #endregion

                #region 给包的类型数组赋值
                int ii_4 = DSnorm.Tables[4].Rows.Count;
                if (ii_4 <= 0) return;
                for (int i = 0; i < ii_4; i++)
                {
                    if (DSnorm.Tables[4].Rows[i]["key_code"].ToString() != null && DSnorm.Tables[4].Rows[i]["value_code"].ToString().Trim() != null)
                    {
                        sl_settype.Add(DSnorm.Tables[4].Rows[i]["key_code"].ToString(), DSnorm.Tables[4].Rows[i]["value_code"].ToString().Trim());
                    }
                }
                #endregion

                #region 给清洗程序数组赋值
                sl_type_washing.Add("0", "无清洗程序");
                int ii_5 = DSnorm.Tables[5].Rows.Count;
                if (ii_5 <= 0) return;
                for (int i = 0; i < ii_5; i++)
                {
                    if (DSnorm.Tables[5].Rows[i]["id"].ToString() != null && DSnorm.Tables[5].Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_washing.Add(DSnorm.Tables[5].Rows[i]["id"].ToString(), DSnorm.Tables[5].Rows[i]["pr_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给灭菌程序数组赋值
                sl_type_sterilization.Add("0", "无灭菌程序");
                int ii_6 = DSnorm.Tables[6].Rows.Count;
                if (ii_6 <= 0) return;
                for (int i = 0; i < ii_6; i++)
                {
                    if (DSnorm.Tables[6].Rows[i]["id"].ToString() != null && DSnorm.Tables[6].Rows[i]["pr_name"].ToString().Trim() != null)
                    {
                        sl_type_sterilization.Add(DSnorm.Tables[6].Rows[i]["id"].ToString(), DSnorm.Tables[6].Rows[i]["pr_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给生产商数组赋值
                int ii_7 = DSnorm.Tables[7].Rows.Count;
                if (ii_7 <= 0) return;
                for (int i = 0; i < ii_7; i++)
                {
                    if (DSnorm.Tables[7].Rows[i]["id"].ToString() != null && DSnorm.Tables[7].Rows[i]["v_name"].ToString().Trim() != null)
                    {
                        sl_vender.Add(DSnorm.Tables[7].Rows[i]["id"].ToString(), DSnorm.Tables[7].Rows[i]["v_name"].ToString().Trim());
                    }
                }
                #endregion

                #region 给销售商数组赋值
                int ii_8 = DSnorm.Tables[8].Rows.Count;
                if (ii_8 <= 0) return;
                for (int i = 0; i < ii_8; i++)
                {
                    if (DSnorm.Tables[8].Rows[i]["id"].ToString() != null && DSnorm.Tables[8].Rows[i]["v_name"].ToString().Trim() != null)
                    {
                        sl_sales.Add(DSnorm.Tables[8].Rows[i]["id"].ToString(), DSnorm.Tables[8].Rows[i]["v_name"].ToString().Trim());
                    }
                }
                #endregion




            }
            #endregion

        }
      
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        //for (int i = 0; i < dtSource.Rows.Count; i++)
                        //{
                        string headerName = "";
                        try
                        {

                            //if (dtSource.Rows[0]["客户（索引）"].ToString() != DTcc.Select("id=" + dtSource.Rows[0]["成本中心（索引）"].ToString())[0]["cu_id"].ToString())
                            //{
                            //    MessageBox.Show("Excel表中第" + (0 + 1) + "行成本中心与客户不匹配，请做注意修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["客户（索引）"].ToString()))
                            {
                                headerName = "客户";
                                dtSource.Rows[0]["客户（索引）"] = sl_type.GetByIndex(sl_type.IndexOfKey(dtSource.Rows[0]["客户（索引）"])).ToString();
                                
                            }

                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["成本中心（索引）"].ToString()))
                            {
                                headerName = "成本中心";
                                dtSource.Rows[0]["成本中心（索引）"] = sl_cc.GetByIndex(sl_cc.IndexOfKey(dtSource.Rows[0]["成本中心（索引）"])).ToString();
                               
                            }
                                
                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["清洗难度（索引）"].ToString()))
                            {
                                headerName = "清洗难度";
                                dtSource.Rows[0]["清洗难度（索引）"] = dtSource.Rows[0]["清洗难度（索引）"].ToString() + ":" + sl_type_complexity.GetByIndex(sl_type_complexity.IndexOfKey(dtSource.Rows[0]["清洗难度（索引）"])).ToString();
                                
                            }
                               
                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["打包材料（索引）"].ToString()))
                            {
                                headerName = "打包材料";
                                dtSource.Rows[0]["打包材料（索引）"] = sl_material.GetByIndex(sl_material.IndexOfKey(dtSource.Rows[0]["打包材料（索引）"])).ToString();
                               
                            }
                               
                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["包的类型（索引）"].ToString()))
                            {
                                headerName = "包的类型";
                                //   dtSource.Rows[i]["清洗难度（索引）"] = sl_type_complexity.GetByIndex(sl_type_complexity.IndexOfKey(dtSource.Rows[i]["清洗难度（索引）"])).ToString();
                                dtSource.Rows[0]["包的类型（索引）"] = dtSource.Rows[0]["包的类型（索引）"] + ":" + sl_settype.GetByIndex(sl_settype.IndexOfKey(dtSource.Rows[0]["包的类型（索引）"])).ToString();
                               
                            }
                               
                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["清洗程序（索引）"].ToString()))
                            {
                                headerName = "清洗程序";
                                dtSource.Rows[0]["清洗程序（索引）"] = sl_type_washing.GetByIndex(sl_type_washing.IndexOfKey(dtSource.Rows[0]["清洗程序（索引）"])).ToString();
                              
                            }
                                
                            if (!string.IsNullOrEmpty(dtSource.Rows[0]["灭菌程序（索引）"].ToString()))
                            {
                                headerName = "灭菌程序";
                                dtSource.Rows[0]["灭菌程序（索引）"] = sl_type_sterilization.GetByIndex(sl_type_sterilization.IndexOfKey(dtSource.Rows[0]["灭菌程序（索引）"])).ToString();
                               
                            }
                               
                            for (int a = 2; a < dtSource.Rows.Count; a++)//赋值生产、销售商
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(dtSource.Rows[a]["可用次数"].ToString()))
                                    {
                                        headerName = "可用次数";
                                        dtSource.Rows[a]["可用次数"] = sl_vender.GetByIndex(sl_vender.IndexOfKey(dtSource.Rows[a]["可用次数"])).ToString();
                                       
                                    }
                                        
                                    if (!string.IsNullOrEmpty(dtSource.Rows[a]["尺寸"].ToString()))
                                    {
                                        headerName = "尺寸";
                                        dtSource.Rows[a]["尺寸"] = sl_sales.GetByIndex(sl_sales.IndexOfKey(dtSource.Rows[a]["尺寸"])).ToString();
                                      
                                    }
                                        
                                }
                                catch
                                {
                                    MessageBox.Show("Excel表中第" + (a + 1) + "行" + headerName + "索引存在错误，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Excel表中第" + (0 + 1) + "行" + headerName + "索引存在错误，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //}
                        //导入的数据赋给数据源
                        this.dgv_01.DataSource = dtSource;
                        //给dgv_01字段设置宽度
                        for (int j = 0; j < dgv_01.Columns.Count; j++)
                        {
                            dgv_01.Columns[j].Width = 156;
                        }
                        //不允许dgv_01排序
                        for (int i = 0; i < this.dgv_01.Columns.Count; i++)
                            this.dgv_01.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
        private Dictionary<string, string> _tempData = new Dictionary<string, string>();
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBut_ok_Click(object sender, EventArgs e)
        {
            if (dgv_01.Rows.Count == 0) return;
            string[] item_id = new string[dgv_01.Rows.Count - 3];//按顺序存储器械的id
            int sumI_id = 0;//累加判断，用于判断dgv的某一列数据是否与数据库比较玩
            CnasRemotCall reCnasRemotCall = new CnasRemotCall();
            SortedList sttmp02 = new SortedList();
            sttmp02.Add(1, CnasBaseData.SystemID);
            DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec001", sttmp02);
            //检查输入的数据是否符合要求

            try
            {
                #region 验证包的信息

                double u;
                #region 判断名称在数据库中是否重复
                if (getdt != null)
                {
                    int ii = getdt.Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                        if (getdt.Rows[i]["ca_name"].ToString().Trim() != null)
                        {
                            if (dgv_01.Rows[0].Cells["器械包名称"].Value.ToString().Trim() == getdt.Rows[i]["ca_name"].ToString().Trim())
                            {
                                if (dgv_01.Rows[0].Cells["器械包名称"].Value.ToString().Trim() == getdt.Rows[i]["ca_name"].ToString().Trim())
                                {
                                    MessageBox.Show("器械包名称已经存在，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                }
                #endregion

                #region 判断导入的数据是否存在重名的数据
                //for (int i = 0; i < dgv_01.Rows.Count - 0; i++)
                //{
                if (dgv_01.Rows[0].Cells["器械包名称"].Value.ToString().Trim() == getdt.Rows[0]["ca_name"].ToString().Trim())
                {
                    MessageBox.Show("第" + (0 + 1) + "行器械名称重复，请做查证后再保存。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //}


                #endregion

                if (sl_type.GetKey(sl_type.IndexOfValue(dgv_01.Rows[0].Cells["客户（索引）"].Value.ToString().Trim())).ToString() !=
                    DTcc.Select("id=" + sl_cc.GetKey(sl_cc.IndexOfValue(dgv_01.Rows[0].Cells["成本中心（索引）"].Value.ToString().Trim())))[0]["cu_id"].ToString())//判断客户与成本中心是否匹配
                {
                    MessageBox.Show("第" + (0 + 1) + "行成本中心与客户不匹配，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dgv_01.Rows[0].Cells["器械包名称"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行器械包名称不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_01.Rows[0].Cells["价格"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行价格不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!double.TryParse(dgv_01.Rows[0].Cells["价格"].Value.ToString().Trim(), out u))
                {
                    MessageBox.Show("价格必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                if (dgv_01.Rows[0].Cells["客户（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行客户（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_01.Rows[0].Cells["成本中心（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行成本中心（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_01.Rows[0].Cells["打包材料（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行打包材料（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_01.Rows[0].Cells["清洗难度（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行清洗难度（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_01.Rows[0].Cells["包的类型（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行包的类型（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (dgv_01.Rows[0].Cells["清洗程序（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行清洗程序（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_01.Rows[0].Cells["灭菌程序（索引）"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("第" + (0 + 1) + "行灭菌程序（索引）不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (dgv_01.Rows[0].Cells["可用次数"].Value.ToString().Trim() == "")
                {
                    dgv_01.Rows[0].Cells["可用次数"].Value = 0;

                }

                if (!double.TryParse(dgv_01.Rows[0].Cells["可用次数"].Value.ToString().Trim(), out u))
                {
                    MessageBox.Show("可用次数必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                if (dgv_01.Rows[0].Cells["重量"].Value.ToString().Trim() == "")
                {
                    dgv_01.Rows[0].Cells["重量"].Value = 0;
                }
                if (!double.TryParse(dgv_01.Rows[0].Cells["重量"].Value.ToString().Trim(), out u))
                {
                    MessageBox.Show("重量必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                if (dgv_01.Rows[0].Cells["尺寸"].Value.ToString().Trim() == "")
                {
                    dgv_01.Rows[0].Cells["尺寸"].Value = "0x0x0";
                }

                else
                {
                    string[] sArray = dgv_01.Rows[0].Cells["尺寸"].Value.ToString().Trim().Split('x');
                    if (sArray.Length != 3)
                    {
                        MessageBox.Show("输入的尺寸格式不正确，请做修改。(如300x500x300)", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (sl_type.GetKey(sl_type.IndexOfValue(dgv_01.Rows[0].Cells["客户（索引）"].Value.ToString().Trim())).ToString() !=
                  DTcc.Select("id=" + sl_cc.GetKey(sl_cc.IndexOfValue(dgv_01.Rows[0].Cells["成本中心（索引）"].Value.ToString().Trim())))[0]["cu_id"].ToString())//判断客户与成本中心是否匹配
                {
                    MessageBox.Show("第" + (0 + 1) + "行成本中心与客户不匹配，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                #endregion
            }
            catch
            {
                MessageBox.Show("模板有误，请选择下载的模板", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #region 验证器械的信息

            SortedList sttmp = new SortedList();
            sttmp.Add(1, CnasBaseData.SystemID);
            DataTable getdt2 = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec001", sttmp);
            if (getdt2 != null)
            {
                int sum = 0;


                for (int a = 2; a < dgv_01.Rows.Count - 1; a++)
                {
                    sumI_id = 0;//清零

                    if (!_tempData.ContainsKey(dgv_01.Rows[a].Cells["器械包名称"].Value.ToString()))
                        _tempData.Add(dgv_01.Rows[a].Cells["器械包名称"].Value.ToString(), dgv_01.Rows[a].Cells["器械包名称"].ToString());


                    #region 判断名称在数据库中是否重复
                    if (getdt2 != null)
                    {
                        int ii = getdt2.Rows.Count;
                        if (ii <= 0) return;
                        for (int i = 0; i < ii; i++)
                            if (getdt2.Rows[i]["ca_name"].ToString().Trim() != null)
                            {
                                if (dgv_01.Rows[a].Cells["器械包名称"].Value.ToString().Trim() != getdt2.Rows[i]["ca_name"].ToString().Trim())//器械为新器械时，在数据库添加一把
                                {
                                    sumI_id++;
                                }
                                else
                                {
                                    sumI_id--;
                                }
                            }
                        if (dgv_01.Rows[a].Cells["价格"].Value.ToString() == "")
                        {
                            MessageBox.Show("器械数量不能为空，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        double u;
                        if (!double.TryParse(dgv_01.Rows[a].Cells["价格"].Value.ToString(), out u))
                        {
                            MessageBox.Show("器械数量必须为数字，请做修改。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                        }
                    }
                    #endregion

                    //#region 判断导入的数据是否存在重名的数据
                    //for (int i = a; i < dgv_01.Rows.Count - a; i++)
                    //{
                    //    if (dgv_01.Rows[a].Cells["器械包名称"].Value.ToString().Trim() == dgv_01.Rows[i + 1].Cells["器械包名称"].Value.ToString().Trim())
                    //    {
                    //        MessageBox.Show("第" + (a + 1) + "行器械名称重复，请做查证后再保存。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}
                    //#endregion

                    if (sumI_id == getdt2.Rows.Count)
                    {
                        #region 增加新器械

                        SortedList sl_item = new SortedList();
                        SortedList sl_item01 = new SortedList();
                        sl_item.Add(1, dgv_01.Rows[a].Cells["器械包名称"].Value.ToString().Trim());

                        sl_item.Add(2, sl_cc_02.GetKey(sl_cc_02.IndexOfValue(dgv_01.Rows[0].Cells["成本中心（索引）"].Value.ToString().Trim())));//成本中心
                        sl_item.Add(3, sl_type_02.GetKey(sl_type_02.IndexOfValue(dgv_01.Rows[0].Cells["客户（索引）"].Value.ToString().Trim())));//顾客

                        sl_item.Add(4, sl_type_sterilization.GetKey(sl_type_sterilization.IndexOfValue(dgv_01.Rows[0].Cells["灭菌程序（索引）"].Value.ToString().Trim())).ToString());//清洗程序


                        sl_item.Add(5, dgv_01.Rows[0].Cells["清洗难度（索引）"].Value.ToString().Trim().Substring(0, 1));//清洗难度
                        try
                        {
                            sl_item.Add(6, sl_vender.GetKey(sl_vender.IndexOfValue(dgv_01.Rows[a].Cells["可用次数"].Value.ToString().Trim())).ToString());//生产商内容
                        }
                        catch
                        {
                            MessageBox.Show("第" + a + "生产商输入错误，请做修改", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }



                        sl_item.Add(7, sl_type_washing.GetKey(sl_type_washing.IndexOfValue(dgv_01.Rows[0].Cells["清洗程序（索引）"].Value.ToString().Trim())).ToString());


                        sl_item.Add(8, "");//型号
                        sl_item.Add(9, "NULL");//价格
                        sl_item.Add(10, "NULL");//次数
                        sl_item.Add(11, "NULL");//重量
                        sl_item.Add(12, "");//大小
                        sl_item.Add(13, 1);//器械类型
                        try
                        {
                            sl_item.Add(14, sl_sales.GetKey(sl_sales.IndexOfValue(dgv_01.Rows[a].Cells["尺寸"].Value.ToString().Trim())).ToString());//销售商内容
                        }
                        catch
                        {
                            MessageBox.Show("第" + a + "销售商输入错误，请做修改", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        sl_item.Add(15, CnasBaseData.SystemID);
                        sl_item01.Add(1, sl_item);
                        string hgg = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-instrument-base-add01", sl_item01, null);
                        int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-instrument-base-add01", sl_item01, null);
                        if (recint <= -1)
                        {
                            MessageBox.Show("器械关联失败,数据异常，请联系管理员", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        #endregion
                        //存储新器械的id
                        string text = reCnasRemotCall.RemotInterface.CheckSelectData("HCS-instrument-base-sec010", null);
                        DataTable getdt_id = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec010", null);
                        if (getdt_id != null)
                        {
                            //item_id[0] = "123";
                            // string n = getdt_id.Rows[0]["id"].ToString();
                            item_id[sum] = getdt_id.Rows[0]["id"].ToString();
                            sum++;
                        }

                    }
                    else
                    {
                        //存储旧器械的id
                        SortedList sttmp_id = new SortedList();
                        sttmp_id.Add(1, dgv_01.Rows[a].Cells["器械包名称"].Value.ToString().Trim());
                        DataTable getdt_id = reCnasRemotCall.RemotInterface.SelectData("HCS-instrument-base-sec011", sttmp_id);
                        item_id[sum] = getdt_id.Rows[0]["id"].ToString();
                        sum++;
                    }
                }
            }
            #endregion

            if (_tempData.Count != dgv_01.Rows.Count - 3)//判断dgv中是否有重复名称的存在
            {
                MessageBox.Show("导入的数据中存在器械名称重复，请做查证后再保存。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 创建需要导入的数据

            #region 创建基本包模板
            SortedList sltmp = new SortedList();
            SortedList sltmp01 = new SortedList();
            sltmp.Add(1, dgv_01.Rows[0].Cells["器械包名称"].Value.ToString().Trim());//名字
            sltmp.Add(2, "");//条码
            sltmp.Add(3, sl_material2[sl_material.GetKey(sl_material.IndexOfValue(dgv_01.Rows[0].Cells["打包材料（索引）"].Value.ToString().Trim()))].ToString());//保质期天数
            sltmp.Add(4, dgv_01.Rows[0].Cells["价格"].Value.ToString().Trim());//价格
            sltmp.Add(5, "");//备注
            sltmp.Add(6, dgv_01.Rows[0].Cells["尺寸"].Value.ToString().Trim());//大小
            sltmp.Add(7, dgv_01.Rows[0].Cells["可用次数"].Value.ToString().Trim());//使用次数
            sltmp.Add(8, dgv_01.Rows[0].Cells["重量"].Value.ToString().Trim());//重量
            sltmp.Add(9, dgv_01.Rows[0].Cells["清洗难度（索引）"].Value.ToString().Trim().Substring(0, 1));//清洗难度
            sltmp.Add(10, dgv_01.Rows[0].Cells["包的类型（索引）"].Value.ToString().Trim().Substring(0, 1));//包的类型
            sltmp.Add(11, sl_cc_02.GetKey(sl_cc_02.IndexOfValue(dgv_01.Rows[0].Cells["成本中心（索引）"].Value.ToString().Trim())));//成本中心
            sltmp.Add(12, sl_type_02.GetKey(sl_type_02.IndexOfValue(dgv_01.Rows[0].Cells["客户（索引）"].Value.ToString().Trim())));//顾客
            sltmp.Add(13, sl_material.GetKey(sl_material.IndexOfValue(dgv_01.Rows[0].Cells["打包材料（索引）"].Value.ToString().Trim())));//打包材料
            sltmp.Add(14, 1);//摆放方式
            sltmp.Add(15, sl_type_sterilization.GetKey(sl_type_sterilization.IndexOfValue(dgv_01.Rows[0].Cells["灭菌程序（索引）"].Value.ToString().Trim())));//灭菌类型
            sltmp.Add(16, sl_type_washing.GetKey(sl_type_washing.IndexOfValue(dgv_01.Rows[0].Cells["清洗程序（索引）"].Value.ToString().Trim())));//清洗类型
            sltmp.Add(17, 1);//为正常包
            sltmp.Add(18, CnasBaseData.SystemID);
            sltmp.Add(19, CnasBaseData.UserName);//创建人
            sltmp.Add(20, 1);
            sltmp.Add(21, 0);
            sltmp.Add(22, "NULL");//最低保有量
            sltmp.Add(23, 0);//RFID追溯
            sltmp01.Add(1, sltmp);
            // string textsql = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
            int recint1 = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-base-add001", sltmp01, null);
            sltmp.Clear();
            sltmp01.Clear();
            if (recint1 <= -1)
            {
                MessageBox.Show("对不起，系统增加出错，请联系管理员。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            #endregion


            #region 创建器械与包的关联关系
            getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-set-base-sec003", null);//查询基本包最后创建的信息，取id
            string strid = "";
            string strtype = "";
            if (getdt != null)
            {
                DataRow arrayDR = getdt.Select()[0];
                strid = arrayDR["id"].ToString().Trim();
                strtype = arrayDR["ca_type"].ToString().Trim();

            }


            int sint = 0;
            int k = 0;
            for (int i = 2; i < dgv_01.Rows.Count - 1; i++)
            {

                if (dgv_01.Rows[i].Cells["价格"].Value != null)
                {
                    try
                    {
                        for (int i02 = 0; i02 < int.Parse(dgv_01.Rows[i].Cells["价格"].Value.ToString()); i02++)
                        {
                            sltmp.Add(1, item_id[i - 2]);//器械id
                            sltmp.Add(2, strid);//基本包id
                            sltmp.Add(3, strtype);//基本包类型
                            sltmp01.Add(1, sltmp);
                            //     string strtmp = reCnasRemotCall.RemotInterface.CheckUPData(1, "HCS-set-base-add001", sltmp01, null);
                            int recint = reCnasRemotCall.RemotInterface.UPData(1, "HCS-set-instrument-add001", sltmp01, null);
                            if (recint > -1)
                            {
                                sint++;//添加器械正常，sint自加；
                            }
                            sltmp.Clear();
                            sltmp01.Clear();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("输入的数据异常，关联失败。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }

                }
                if (sint == int.Parse(dgv_01.Rows[i].Cells["价格"].Value.ToString()))//为真，代表这累器械添加的数量正常
                {
                    //
                    k++;
                    sint = 0;//清零
                }
            }
            if (k == dgv_01.Rows.Count - 3)//ii每次自加成功代表sint在循环里没出错！
            {
                MessageBox.Show(PromptMessageXmlHelper.Instance.GetPromptMessage("addsuccessful", EnumPromptMessage.warning, new string[] { "基本包" }), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }


            #endregion





        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBut_close_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        if (dgv_01.SelectedRows[0].Cells["器械包名称"].Value.ToString().Trim() != "器械名称")//不能删除器械表头
                        {
                            drv.Delete();
                        }

                }
            }
            else
            {
                MessageBox.Show("请选择一行。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 下载模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radBut_downloadw_Click(object sender, EventArgs e)
        {

            string DownLoadPath = ConfigurationManager.AppSettings["DownLoadPath"].ToString();

            DownLoadPath += "\\SetImportTem.xlsx";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = " doc files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName += "器械包导入模板.xlsx";

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
        void cmb_vender_sales_DrawItem(object sender, DrawItemEventArgs e)
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
        public void cmb_vender_sales_SelectedIndexChanged(object sender, EventArgs e)
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
        private void dgv_01_CurrentCellChanged(object sender, EventArgs e)
        {

        }
        /// 给下拉框赋值
        /// </summary>
        /// <param name="Sql_name">表</param>
        private void Load_Box(DataTable table)
        {



        }

        private void dgv_01_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("录入数据异常，请查询。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void dgv_01_CurrentCellChanged_1(object sender, EventArgs e)
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
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框

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


                if (DS_pnorm.Tables[0] != null)
                {
                    int ii = DS_pnorm.Tables[0].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[0].Rows[i]["id"].ToString() != null && DS_pnorm.Tables[0].Rows[i]["cu_name"].ToString().Trim() != null && DS_pnorm.Tables[0].Rows[i]["bar_code"].ToString().Trim() != null)
                        {
                            cmb_Temp.Items.Add(DS_pnorm.Tables[0].Rows[i]["cu_name"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion

            #region 添加成本中心下拉框
            if (column.Name.Equals("成本中心（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框
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

                string str = "";
                if (sl_type.Count != 0 && dgv_01.Rows[rowIndex].Cells[columnIndex - 1].Value.ToString() != "")//数组有值则取其中的名称
                {
                    try
                    {
                        str = sl_type.GetKey(sl_type.IndexOfValue(dgv_01.Rows[rowIndex].Cells[columnIndex - 1].Value.ToString())).ToString();//获取键，即cu_id
                    }
                    catch
                    {
                        MessageBox.Show("客户的键值抛异常，请联系管理员", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                CnasRemotCall reCnasRemotCall = new CnasRemotCall();
                SortedList Sl_cu = new SortedList();
                Sl_cu.Add(1, str);

                //    string test_sql = reCnasRemotCall.RemotInterface.CheckSelectData(Sql_name, Sl_cu);
                DataTable getdt = reCnasRemotCall.RemotInterface.SelectData("HCS-costcenter-sec002", Sl_cu);
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
            #endregion


            #region 添加清洗难度下拉框
            if (column.Name.Equals("清洗难度（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框
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

                if (DS_pnorm.Tables[2] != null)
                {
                    int ii = DS_pnorm.Tables[2].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[2].Rows[i]["key_code"].ToString() != null && DS_pnorm.Tables[2].Rows[i]["value_code"].ToString().Trim() != null)
                        {
                            this.cmb_Temp.Items.Add(DS_pnorm.Tables[2].Rows[i]["key_code"].ToString().Trim() + ":" + DS_pnorm.Tables[2].Rows[i]["value_code"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion


            #region 添加打包材料下拉框
            if (column.Name.Equals("打包材料（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框
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

                if (DS_pnorm.Tables[3] != null)
                {
                    int ii = DS_pnorm.Tables[3].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[3].Rows[i]["id"].ToString() != null && DS_pnorm.Tables[3].Rows[i]["ca_name"].ToString().Trim() != null)
                        {
                            cmb_Temp.Items.Add(DS_pnorm.Tables[3].Rows[i]["ca_name"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion

            #region 添加包的类型下拉框
            if (column.Name.Equals("包的类型（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框
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

                if (DS_pnorm.Tables[4] != null)
                {
                    int ii = DS_pnorm.Tables[4].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[4].Rows[i]["key_code"].ToString() != null && DS_pnorm.Tables[4].Rows[i]["value_code"].ToString().Trim() != null)
                        {
                            this.cmb_Temp.Items.Add(DS_pnorm.Tables[4].Rows[i]["key_code"].ToString().Trim() + ":" + DS_pnorm.Tables[4].Rows[i]["value_code"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion



            #region 添加清洗程序下拉框
            if (column.Name.Equals("清洗程序（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框
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

                this.cmb_Temp.Items.Add("无清洗程序");
                if (DS_pnorm.Tables[5] != null)
                {
                    int ii = DS_pnorm.Tables[5].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[5].Rows[i]["id"].ToString() != null && DS_pnorm.Tables[5].Rows[i]["pr_name"].ToString().Trim() != null)
                        {

                            cmb_Temp.Items.Add(DS_pnorm.Tables[5].Rows[i]["pr_name"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion

            #region 添加灭菌程序下拉框
            if (column.Name.Equals("灭菌程序（索引）"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex != 0) return;//如果不是第一行则不显示下拉框
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

                this.cmb_Temp.Items.Add("无灭菌程序");
                if (DS_pnorm.Tables[6] != null)
                {
                    int ii = DS_pnorm.Tables[6].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[6].Rows[i]["id"].ToString() != null && DS_pnorm.Tables[6].Rows[i]["pr_name"].ToString().Trim() != null)
                        {

                            cmb_Temp.Items.Add(DS_pnorm.Tables[6].Rows[i]["pr_name"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion

            #region 添加生产商下拉框
            if (column.Name.Equals("可用次数"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex <= 1) return;//如果是第一行第二行则不显示下拉框
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


                if (DS_pnorm.Tables[7] != null)
                {
                    int ii = DS_pnorm.Tables[7].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[7].Rows[i]["id"].ToString() != null && DS_pnorm.Tables[7].Rows[i]["v_name"].ToString().Trim() != null)
                        {

                            cmb_Temp.Items.Add(DS_pnorm.Tables[7].Rows[i]["v_name"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion

            #region 添加销售商下拉框
            if (column.Name.Equals("尺寸"))
            {
                cmb_Temp.Items.Clear();
                int columnIndex = dgv_01.CurrentCell.ColumnIndex;
                int rowIndex = dgv_01.CurrentCell.RowIndex;
                if (rowIndex <= 1) return;//如果是第一行第二行则不显示下拉框
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


                if (DS_pnorm.Tables[8] != null)
                {
                    int ii = DS_pnorm.Tables[8].Rows.Count;
                    if (ii <= 0) return;
                    for (int i = 0; i < ii; i++)
                    {
                        if (DS_pnorm.Tables[8].Rows[i]["id"].ToString() != null && DS_pnorm.Tables[8].Rows[i]["v_name"].ToString().Trim() != null)
                        {

                            cmb_Temp.Items.Add(DS_pnorm.Tables[8].Rows[i]["v_name"].ToString().Trim());
                        }
                    }
                }
            }
            #endregion
        }
    }
}
