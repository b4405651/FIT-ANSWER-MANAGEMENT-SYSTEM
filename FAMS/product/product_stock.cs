using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class product_stock : Form
    {
        public product_stock()
        {
            InitializeComponent();

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("product_name", "ชื่อสินค้า", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("amount", "คงเหลือ"));
            DGVC.Add(new dgvColumn("product_code", "รหัส", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("product_id", "product_id", DataGridViewContentAlignment.MiddleLeft, false));
            btn_dgv.initColumn(DGVC);

            btn_dgv.DGV.MouseClick += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (btn_dgv.DGV.HitTest(ee.X, ee.Y).ColumnIndex > -1 && btn_dgv.DGV.HitTest(ee.X, ee.Y).RowIndex > -1)
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.HitTest(ee.X, ee.Y).RowIndex].Selected = true;
                        btn_dgv.theContextMenu.MenuItems.Clear();
                        if (btn_dgv.DGV.SelectedRows.Count == 1)
                            btn_dgv.theContextMenu.MenuItems.Add("ดูข้อมูลการเข้า-ออก", new EventHandler(TrxDetailEvent));
                    }
                }
            };
        }

        void TrxDetailEvent(object sender, EventArgs e)
        {
            using (product_stock_trx productStockTrx = new product_stock_trx(btn_dgv.DGV.SelectedRows[0].Cells["product_id"].Value.ToString()))
            {
                productStockTrx.Owner = this;
                productStockTrx.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            out_btn.Visible = GF.isAdmin;
            if (btn_dgv.DGV.Columns.Count == 0) return;
            getData();
        }

        public void getData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "is_alert", (is_alert.Checked ? "1" : "0") },
                { "branch_id", GF.Settings("branch_id") }
            };

            if (search_txt.Text.Trim() != String.Empty) values.Add("search_txt", search_txt.Text.Trim());

            Dictionary<String, Object> Obj = DB.Post("Product/getProductStock/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        Item["product_name"].ToString(),
                        GF.formatNumber(Convert.ToInt32(Item["amount"].ToString())),
                        (Item["product_code"] ?? "").ToString(),
                        Item["product_id"].ToString()
                    );

                    if (Item["is_alert"].ToString() == "1")
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getData();
        }

        private void in_btn_Click(object sender, EventArgs e)
        {
            using (product_stock_manage productStockManage = new product_stock_manage())
            {
                productStockManage.prefixAmount = "";
                productStockManage.Owner = this;
                productStockManage.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }

        private void out_btn_Click(object sender, EventArgs e)
        {
            using (product_stock_manage productStockManage = new product_stock_manage())
            {
                productStockManage.prefixAmount = "-";
                productStockManage.Owner = this;
                productStockManage.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }
    }
}
