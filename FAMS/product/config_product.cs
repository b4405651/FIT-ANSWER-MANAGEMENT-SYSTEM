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
    public partial class config_product : Form
    {
        public config_product()
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
            DGVC.Add(new dgvColumn("price", "ราคา"));
            DGVC.Add(new dgvColumn("product_code", "รหัส BARCODE"));
            DGVC.Add(new dgvColumn("alert", "แจ้งเตือน"));
            DGVC.Add(new dgvColumn("suspend_since", "ปิดการใช้ตั้งแต่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("product_id", "product_id", DataGridViewContentAlignment.BottomCenter, false));
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
                        {
                            btn_dgv.theContextMenu.MenuItems.Add("แก้ไข", new EventHandler(EditEvent));
                            if ((btn_dgv.DGV.SelectedRows[0].Cells["suspend_since"].Value ?? "").ToString() == String.Empty)
                                btn_dgv.theContextMenu.MenuItems.Add("ปิดการใช้", new EventHandler(DisableEvent));
                            else
                                btn_dgv.theContextMenu.MenuItems.Add("เปิดการใช้", new EventHandler(EnableEvent));
                        }
                    }
                }
            };
        }

        void EditEvent(object sender, EventArgs e)
        {
            using (config_product_manage configProductManage = new config_product_manage())
            {
                configProductManage.product_id = btn_dgv.DGV.SelectedRows[0].Cells["product_id"].Value.ToString();
                configProductManage.Owner = this;
                configProductManage.ShowDialog();
                this.BringToFront();
            }
        }

        void DisableEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "product_id", btn_dgv.DGV.SelectedRows[0].Cells["product_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Product/Suspend/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            getData();
        }

        void EnableEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "product_id", btn_dgv.DGV.SelectedRows[0].Cells["product_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Product/Enable/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            getData();
        }

        void doLoadGridData(object sender, EventArgs e)
        {
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
                { "is_suspend", (is_suspend.Checked ? "1" : "0") }
            };

            if (search_txt.Text.Trim() != String.Empty) values.Add("search_txt", search_txt.Text.Trim());

            Dictionary<String, Object> Obj = DB.Post("Product/getProductList/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        Item["product_name"].ToString(),
                        GF.formatNumber(Convert.ToInt32(Item["price"].ToString())),
                        (Item["product_code"] ?? "").ToString(),
                        GF.formatNumber(Convert.ToInt32(Item["alert_amount"].ToString())),
                        GF.formatDBDateTime((Item["suspend_since"] ?? "").ToString()),
                        Item["product_id"].ToString()
                    );
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            using (config_product_manage configProductManage = new config_product_manage())
            {
                configProductManage.Owner = this;
                configProductManage.ShowDialog();
            }
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getData();
        }
    }
}
