using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS.User_Control
{
    public partial class btn_dgv : UserControl
    {
        public ContextMenu theContextMenu = new ContextMenu();
        String pageBeforeChange = "1";

        // DELEGATE PART :: BEGIN
        public delegate void firstClickHandler(object sender, EventArgs e);
        public event firstClickHandler firstClick;
        public delegate void prevClickHandler(object sender, EventArgs e);
        public event prevClickHandler prevClick;
        public delegate void nextClickHandler(object sender, EventArgs e);
        public event nextClickHandler nextClick;
        public delegate void lastClickHandler(object sender, EventArgs e);
        public event lastClickHandler lastClick;
        public delegate void pageNumberChangedHandler(object sender, EventArgs e);
        public event pageNumberChangedHandler pageNumberChanged;

        public void onFirstClick(EventArgs e)
        {
            if (firstClick != null)
            {
                firstClick(this, e);
            }
        }
        public void onPrevClick(EventArgs e)
        {
            if (prevClick != null)
            {
                prevClick(this, e);
            }
        }
        public void onNextClick(EventArgs e)
        {
            if (nextClick != null)
            {
                nextClick(this, e);
            }
        }
        public void onLastClick(EventArgs e)
        {
            if (lastClick != null)
            {
                lastClick(this, e);
            }
        }

        private void first_btn_Click(object sender, EventArgs e)
        {
            //GF.showLoading((this.Parent as Form));

            page.Text = "1";

            GF.disableBtn(first_btn);
            GF.disableBtn(prev_btn);

            if (Convert.ToInt32(page.Text.Trim()) < Convert.ToInt32(max_page.Text.Trim()))
            {
                GF.enableBtn(next_btn, Color.DodgerBlue);
                GF.enableBtn(last_btn, Color.DodgerBlue);
            }

            onFirstClick(EventArgs.Empty);
        }
        private void prev_btn_Click(object sender, EventArgs e)
        {
            //GF.showLoading((this.Parent as Form));

            page.Text = (Convert.ToInt32(page.Text) - 1).ToString();

            if (page.Text == "1")
            {
                GF.disableBtn(first_btn);
                GF.disableBtn(prev_btn);
            }

            if (Convert.ToInt32(page.Text.Trim()) < Convert.ToInt32(max_page.Text.Trim()))
            {
                GF.enableBtn(next_btn, Color.DodgerBlue);
                GF.enableBtn(last_btn, Color.DodgerBlue);
            }

            onPrevClick(EventArgs.Empty);
        }
        private void next_btn_Click(object sender, EventArgs e)
        {
            //GF.showLoading((this.Parent as Form));

            page.Text = (Convert.ToInt32(page.Text) + 1).ToString();

            if (page.Text == max_page.Text)
            {
                GF.disableBtn(last_btn);
                GF.disableBtn(next_btn);
            }

            if (Convert.ToInt32(page.Text.Trim()) > 1)
            {
                GF.enableBtn(first_btn, Color.DodgerBlue);
                GF.enableBtn(prev_btn, Color.DodgerBlue);
            }

            onNextClick(EventArgs.Empty);
        }
        private void last_btn_Click(object sender, EventArgs e)
        {
            //GF.showLoading((this.Parent as Form));

            page.Text = max_page.Text;

            GF.disableBtn(last_btn);
            GF.disableBtn(next_btn);

            if (Convert.ToInt32(page.Text) > 1)
            {
                GF.enableBtn(first_btn, Color.DodgerBlue);
                GF.enableBtn(prev_btn, Color.DodgerBlue);
            }

            onLastClick(EventArgs.Empty);
        }

        private void page_Leave(object sender, EventArgs e)
        {
            if (page.Text.Trim() != "")
            {
                if (Convert.ToInt32(page.Text) < 1)
                {
                    page.Text = "1";
                    return;
                }
                if (Convert.ToInt32(page.Text) > Convert.ToInt32(max_page.Text))
                {
                    page.Text = max_page.Text;
                    return;
                }
                if (Convert.ToInt32(page.Text) != Convert.ToInt32(pageBeforeChange))
                {
                    onPageNumberChanged(EventArgs.Empty);
                }
            }
            else page.Text = pageBeforeChange;
        }

        public void onPageNumberChanged(EventArgs e)
        {
            if (pageNumberChanged != null)
            {
                pageNumberChanged(this, e);
            }
        }

        private void DGV_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = null;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = DGV.HitTest(e.X, e.Y);

                if(hitTestInfo.ColumnIndex > -1 && hitTestInfo.RowIndex > -1)
                {
                    DGV.Rows[hitTestInfo.RowIndex].Selected = true;
                    theContextMenu.Show(DGV, new Point(e.X, e.Y));
                }
            }
        }
        // DELEGATE PART :: END

        public btn_dgv()
        {
            InitializeComponent();

            DGV.Paint += GF.DGV_Paint;

            GF.disableBtn(first_btn);
            GF.disableBtn(prev_btn);
        }

        public void initColumn(List<dgvColumn> columns)
        {
            if (DGV.Columns.Count > 0) DGV.Columns.Clear();

            foreach(dgvColumn DGVC in columns)
            {
                DGV.Columns.Add(
                    DGVC.colID,
                    DGVC.colCaption
                );
                DGV.Columns[DGV.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                if(!DGVC.visible) DGV.Columns[DGV.Columns.Count - 1].Visible = DGVC.visible;
                if(DGVC.Align != DataGridViewContentAlignment.MiddleCenter) DGV.Columns[DGV.Columns.Count - 1].DefaultCellStyle.Alignment = DGVC.Align;
            }
        }

        private void page_TextChanged(object sender, EventArgs e)
        {
            if (page.Text.Trim() != String.Empty)
            {
                if (Convert.ToInt32(page.Text.Trim()) > Convert.ToInt32(max_page.Text.Trim()))
                    page.Text = max_page.Text.Trim();
            }
        }

        private void page_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void pagination_panel_Resize(object sender, EventArgs e)
        {
            pagination_panel.Height = 40;

            first_btn.Left = 3;
            prev_btn.Left = 106;
            page_lbl.Left = 219;
            page.Left = 285;
            page.Width = 40;
            page_sep_lbl.Left = 331;
            max_page.Left = 351;
            next_btn.Left = 407;
            last_btn.Left = 510;
            total_record_lbl.Left = 648;
            total_record.Left = 748;

            first_btn.Top = prev_btn.Top = next_btn.Top = last_btn.Top = 3;
            page.Top = 6;
            page_lbl.Top = page_sep_lbl.Top = max_page.Top = total_record_lbl.Top = total_record.Top = 9;
        }

        private void DGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);

            e.PaintHeader(DataGridViewPaintParts.Background
                | DataGridViewPaintParts.Border
                | DataGridViewPaintParts.Focus
                | DataGridViewPaintParts.SelectionBackground
                | DataGridViewPaintParts.ContentForeground);

            e.Handled = true;
        }

        private void DGV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) DGV.ClearSelection();
        }

        private void page_KeyUp(object sender, KeyEventArgs e)
        {
            if(page.Text.Trim() == String.Empty)
            {
                e.Handled = true;
                return;
            }

            if (Convert.ToInt32(page.Text.Trim()) < 1)
            {
                page.Text = "1";
            }
            else if (Convert.ToInt32(page.Text.Trim()) > Convert.ToInt32(max_page.Text.Trim()))
            {
                page.Text = max_page.Text;
            }

            if (e.KeyCode == Keys.Enter)
            {
                DGV.Select();
                //onPageKeyUp(null);
            }
        }

        private void page_Enter(object sender, EventArgs e)
        {
            pageBeforeChange = page.Text.Trim();
        }

        public void resetBtnDGV(String rowCount)
        {
            total_record.Text = rowCount;

            if (rowCount == "0")
            {
                max_page.Text = "0";
                page.Text = "1";
                page.Enabled = false;
            }
            else
            {
                max_page.Text = ((Convert.ToInt32(rowCount) / GF.rowsPerPage) + 1).ToString();
                if (Convert.ToInt32(max_page.Text.Trim()) <= 1)
                {
                    page.Text = max_page.Text;
                    GF.disableBtn(first_btn);
                    GF.disableBtn(prev_btn);
                    GF.disableBtn(next_btn);
                    GF.disableBtn(last_btn);
                    page.Enabled = false;
                }
                else
                {
                    GF.enableBtn(first_btn, Color.DodgerBlue);
                    GF.enableBtn(prev_btn, Color.DodgerBlue);
                    GF.enableBtn(next_btn, Color.DodgerBlue);
                    GF.enableBtn(last_btn, Color.DodgerBlue);
                    page.Enabled = true;
                }

                if (total_record.Text == "0")
                    this.Enabled = false;
                else
                    this.Enabled = true;
            }

            if(page.Text.Trim() == "1")
            {
                GF.disableBtn(first_btn);
                GF.disableBtn(prev_btn);
            }

            if (page.Text.Trim() == max_page.Text.Trim())
            {
                GF.disableBtn(next_btn);
                GF.disableBtn(last_btn);
            }

            GF.closeLoading();
        }

        private void DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DGV.Rows[e.RowIndex].HeaderCell.Value = (((Convert.ToInt32(page.Text.Trim()) - 1) * GF.rowsPerPage) + (e.RowIndex + 1)).ToString();
        }
    }
}
