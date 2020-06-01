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
    public partial class product_stock_manage : Form
    {
        public String prefixAmount = "";
        public Boolean isReadOnly = false;
        
        public product_stock_manage()
        {
            InitializeComponent();

            DGV.Paint += GF.DGV_Paint;
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            product_code.Select();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (ref_txt.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'อ้างอิง' !!");
                return;
            }

            String product_list = "";
            foreach (DataGridViewRow DGVR in DGV.Rows)
                product_list += DGVR.Cells["product_id"].Value.ToString() + "###" + prefixAmount + DGVR.Cells["amount"].Value.ToString() + "@@@";

            if (product_list.Trim() != String.Empty) product_list = product_list.Substring(0, product_list.Trim().Length - 3);

            if (product_list.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้เลือก สินค้า !!");
                return;
            }
            GF.showLoading(this);
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "branch_id", GF.Settings("branch_id") },
                { "ref", ref_txt.Text.Trim() },
                { "trx_by", GF.userID },
                { "product_list", product_list }
            };

            Dictionary<string, Object> Obj = DB.Post("Product/manageProductTrx/", values);

            GF.closeLoading();

            if (Obj == null) return;
            if (Obj["result"].ToString() == "true")
            {
                ((product_stock)this.Owner).getData();
                this.Close();
            }
        }

        private void product_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (product_code.Text.Trim() != String.Empty && e.KeyCode == Keys.Enter)
            {
                GF.showLoading(this);
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "product_code" , product_code.Text.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("Product/getProductFromBarcode/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    DGV.ClearSelection();
                    addRow(Item["product_name"].ToString(), Item["product_id"].ToString());

                    DGV.Select();
                    DGV.Rows[DGV.Rows.Count - 1].Cells["amount"].Selected = true;

                    product_code.Text = "";
                }

                GF.closeLoading();
            }
        }

        public void addRow(String product_name, String product_id)
        {
            int index = -1;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (DGVR.Cells["product_id"].Value.ToString() == product_id)
                {
                    index = DGVR.Index;
                    break;
                }
            }

            if (index == -1)
            {
                DGV.Rows.Add(
                    product_name,
                    "1",
                    product_id
                );

                DGV.Rows[DGV.Rows.Count - 1].HeaderCell.Value = DGV.Rows.Count.ToString();
            }
            else
            {
                DataGridViewRow DGVR = DGV.Rows[index];
                DGVR.Cells["amount"].Value = Convert.ToInt32(DGVR.Cells["amount"].Value.ToString()) + 1;
            }
        }

        private void add_product_btn_Click(object sender, EventArgs e)
        {
            int rowCountBeforeChooseProduct = DGV.Rows.Count;
            using (product_stock_manage_choose_item chooseProduct = new product_stock_manage_choose_item())
            {
                chooseProduct.Owner = this;
                chooseProduct.ShowDialog();
            }
            this.BringToFront();
            this.Activate();

            if (DGV.Rows.Count > rowCountBeforeChooseProduct)
            {
                DGV.Select();
                DGV.Rows[DGV.Rows.Count - 1].Cells["amount"].Selected = true;
            }
            else product_code.Select();
        }
    }
}
