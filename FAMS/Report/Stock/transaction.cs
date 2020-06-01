using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS.Report.Stock
{
    public partial class transaction : Form
    {
        Boolean isReady = true;
        webBrowser wb;
        public transaction()
        {
            InitializeComponent();

            //PAGING DELEGATE
            pagination.firstClick += manage_btn_Click;
            pagination.prevClick += manage_btn_Click;
            pagination.nextClick += manage_btn_Click;
            pagination.lastClick += manage_btn_Click;
            pagination.pageNumberChanged += manage_btn_Click;

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                foreach (Dictionary<String, Object> Branch in (Array)Obj["result"])
                {
                    branch_list.Items.Add(new ComboItem(Convert.ToInt32(Branch["branch_id"].ToString()), Branch["branch_name"].ToString()));
                }
            }

            values = new Dictionary<string, string>()
            {
                { "is_suspend" , "0" }
            };

            Obj = DB.Post("Product/getProductList/", values);

            if (Obj != null)
            {
                product_id.Items.Add(new ComboItem(0, "เลือก สินค้า"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    product_id.Items.Add(new ComboItem(GF.toInt(Item["product_id"].ToString()), Item["product_name"].ToString() + " (" + GF.formatNumber(Item["price"].ToString()) + " บาท)"));
                }

                product_id.SelectedIndex = 0;
                GF.resizeComboBox(product_id);
            }

            start_date.Text = end_date.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + (DateTime.Now.Year + 543).ToString("0000");

            wb = new webBrowser(wb_panel); wb.DocumentText = "<center style='font-size: 24px; font-family:\'Tahoma\'; height: 100%; valign: middle;'><b><u>รายงาน การเข้าออก ของสินค้า</u></b></center>";
        }

        private void branch_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                GF.showLoading(this);
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 0; i < branch_list.Items.Count; i++)
                        branch_list.SetItemCheckState(i, CheckState.Unchecked);
                }
                isReady = true;
                GF.closeLoading();
            }
        }

        Boolean validate(out Dictionary<string, string> postParam)
        {
            postParam = null;

            if (product_id.SelectedIndex == 0)
            {
                GF.Error("ยังไม่ได้เลือก 'สินค้า' !");
                product_id.Select();
                return false;
            }

            // BRANCH
            String branch = String.Empty;
            for (int i = 0; i < branch_list.Items.Count; i++)
                if (branch_list.GetItemCheckState(i) == CheckState.Checked)
                {
                    branch += (branch_list.Items[i] as ComboItem).Key.ToString() + ",";
                }

            if (branch == String.Empty)
            {
                GF.Error("ยังไม่ได้เลือกสาขา !");
                return false;
            }
            else
                branch = branch.Substring(0, branch.Length - 1);

            if (!GF.validateDateTime(start_date)) return false;
            if (!GF.validateDateTime(end_date)) return false;

            if (pagination.page.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุ 'หน้าที่' !");
                pagination.page.Select();
                return false;
            }

            postParam = new Dictionary<string, string>(){
                { "branch_id", branch },
                { "product_id", (product_id.SelectedItem as ComboItem).Key.ToString() },
                { "start_date", start_date.Text },
                { "end_date", end_date.Text },
                { "page", pagination.page.Text.Trim() }
            };
            return true;
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            Dictionary<String, Object> Obj = DB.ReportGetTotalRecord("Stock/Transaction", values);

            if (Obj != null)
            {
                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];
                pagination.resetPagination(Item["total_record"].ToString());
            }
            else
            {
                pagination.toggle(false);
                pagination.page.Text = "1";
            }

            wb = new webBrowser(wb_panel);
            wb.DocumentCompleted += (ss, ee) =>
            {
                GF.enableBtn(manage_btn, Color.LightCoral);
                print_btn.Visible = true;
                excel_btn.Visible = true;
            };

            GF.disableBtn(manage_btn);
            print_btn.Visible = false;
            excel_btn.Visible = false;

            DB.PerformWebNavigate("Stock/Transaction", wb, values);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (wb != null) wb.ShowPrintDialog();
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            DB.WebDownload(this, "Stock/Transaction", "product_transaction.xls", values);
        }
    }
}
