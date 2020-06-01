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
    public partial class list : Form
    {
        webBrowser wb;
        public list()
        {
            InitializeComponent();

            //PAGING DELEGATE
            pagination.firstClick += manage_btn_Click;
            pagination.prevClick += manage_btn_Click;
            pagination.nextClick += manage_btn_Click;
            pagination.lastClick += manage_btn_Click;
            pagination.pageNumberChanged += manage_btn_Click;

            wb = new webBrowser(wb_panel); wb.DocumentText = "<center style='font-size: 24px; font-family:\'Tahoma\'; height: 100%; valign: middle;'><b><u>รายงาน รายชื่อสินค้าทั้งหมด</u></b></center>";
        }

        Boolean validate(out Dictionary<string, string> postParam)
        {
            postParam = null;

            if (pagination.page.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุ 'หน้าที่' !");
                pagination.page.Select();
                return false;
            }

            postParam = new Dictionary<string, string>(){
                { "page", pagination.page.Text.Trim() }
            };
            return true;
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            Dictionary<String, Object> Obj = DB.ReportGetTotalRecord("Stock/ListProduct", values);

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

            DB.PerformWebNavigate("Stock/ListProduct", wb, values);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (wb != null) wb.ShowPrintDialog();
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            DB.WebDownload(this, "Stock/ListProduct", "product_list.xls", values);
        }
    }
}
