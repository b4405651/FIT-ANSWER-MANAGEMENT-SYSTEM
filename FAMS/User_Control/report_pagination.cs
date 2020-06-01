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
    public partial class report_pagination : UserControl
    {
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
            GF.showLoading((this.Parent as Form));

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
            GF.showLoading((this.Parent as Form));

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
            GF.showLoading((this.Parent as Form));

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
            GF.showLoading((this.Parent as Form));

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
        // DELEGATE PART :: END
        public report_pagination()
        {
            InitializeComponent();

            GF.disableBtn(first_btn);
            GF.disableBtn(prev_btn);
            GF.disableBtn(next_btn);
            GF.disableBtn(last_btn);
            page.Enabled = false;

            this.Enabled = false;
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

        public void toggle(Boolean mode)
        {
            if (mode == true)
            {
                GF.enableBtn(first_btn, Color.DodgerBlue);
                GF.enableBtn(prev_btn, Color.DodgerBlue);
                GF.enableBtn(next_btn, Color.DodgerBlue);
                GF.enableBtn(last_btn, Color.DodgerBlue);
            }
            else
            {
                GF.disableBtn(first_btn);
                GF.disableBtn(prev_btn);
                GF.disableBtn(next_btn);
                GF.disableBtn(last_btn);
            }

            page.Enabled = mode;
            this.Enabled = mode;
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

        private void page_KeyUp(object sender, KeyEventArgs e)
        {
            if (page.Text.Trim() == String.Empty)
            {
                e.Handled = true;
                return;
            }

            if (Convert.ToInt32(page.Text.Trim()) < 1)
            {
                page.Text = pageBeforeChange;
            }
            else if (Convert.ToInt32(page.Text.Trim()) > Convert.ToInt32(max_page.Text.Trim()))
            {
                page.Text = max_page.Text;
            }

            if (Convert.ToInt32(page.Text.Trim()) == 1 && page.Text.Trim() != max_page.Text.Trim())
            {
                GF.disableBtn(first_btn);
                GF.disableBtn(prev_btn);
                GF.enableBtn(next_btn, Color.DodgerBlue);
                GF.enableBtn(last_btn, Color.DodgerBlue);
            }

            if (page.Text.Trim() == max_page.Text.Trim() && page.Text.Trim() != "1")
            {
                GF.disableBtn(next_btn);
                GF.disableBtn(last_btn);
                GF.enableBtn(first_btn, Color.DodgerBlue);
                GF.enableBtn(prev_btn, Color.DodgerBlue);
            }

            if (page.Text.Trim() == "1" && page.Text == max_page.Text.Trim())
            {
                GF.disableBtn(first_btn);
                GF.disableBtn(prev_btn);
                GF.disableBtn(next_btn);
                GF.disableBtn(last_btn);
            }
        }

        private void page_Enter(object sender, EventArgs e)
        {
            pageBeforeChange = page.Text.Trim();
        }

        public void resetPagination(String rowCount)
        {
            total_record.Text = rowCount;
            if (rowCount == "0")
                max_page.Text = "0";
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
                    this.Enabled = false;
                }
                else
                {
                    GF.enableBtn(first_btn, Color.DodgerBlue);
                    GF.enableBtn(prev_btn, Color.DodgerBlue);
                    GF.enableBtn(next_btn, Color.DodgerBlue);
                    GF.enableBtn(last_btn, Color.DodgerBlue);
                    page.Enabled = true;
                    this.Enabled = true;
                }
            }

            if (page.Text.Trim() == "1")
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
    }
}
