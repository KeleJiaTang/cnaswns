using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CRD.WinUI.Editors
{
    public class DataGridView : System.Windows.Forms.DataGridView
    {
        public DataGridView()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnCreateControl()
        {
            this.EnableHeadersVisualStyles = false;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 246, 239);
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            this.ColumnHeadersHeight = 26;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.RowHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RowHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DefaultCellStyle.SelectionBackColor = Color.Wheat;
            this.DefaultCellStyle.SelectionForeColor = Color.DarkSlateBlue;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AllowUserToOrderColumns = true;
            this.AutoGenerateColumns = true;

            base.OnCreateControl();
        }

        Color defaultcolor;

        //移到单元格时的颜色
        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {

            base.OnCellMouseMove(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.YellowGreen;

            }
            catch (Exception)
            {

            }
        }

        //进入单元格时保存当前的颜色
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            try
            {
                defaultcolor = Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            catch (Exception)
            {

            }

        }

        //离开时还原颜色
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = defaultcolor;
            }
            catch (Exception)
            {

            }
        }
    }
}
