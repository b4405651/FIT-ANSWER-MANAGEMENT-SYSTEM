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
    public partial class shop : Form
    {
        public String bill_id = "";
        public shop()
        {
            InitializeComponent();

            product_DGV.Paint += GF.DGV_Paint;
            payment_DGV.Paint += GF.DGV_Paint;

            product_code.Select();
        }

        void newBill()
        {
            print_btn.Visible = false;

            product_DGV.Rows.Clear();
            product_DGV.Enabled = true;
            calculateGrandTotal();

            payment_DGV.Rows.Clear();
            payment_DGV.Enabled = true;
            calculatePaid();

            bill_search_btn.Text = "ค้นหาใบเสร็จ";
            product_code.Enabled = true;
            GF.enableBtn(add_product_btn, Color.FromArgb(255, 128, 0));
            GF.enableBtn(add_payment_btn, Color.FromArgb(255, 128, 0));
            GF.enableBtn(manage_btn, Color.Green);

            void_btn.Visible = false;
            void_txt.Visible = false;
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

                    addRow(Item["product_name"].ToString(), Item["price"].ToString(), Item["product_id"].ToString(), "1");

                    product_DGV.Select();
                    product_DGV.Rows[product_DGV.Rows.Count - 1].Cells["amount"].Selected = true;

                    product_code.Text = "";
                }

                GF.closeLoading();
            }
        }

        public void addRow(String product_name, String price, String product_id, String amount, String net_price_before_vat = "", String vat_amount = "", String vat = "")
        {
            int index = -1;
            foreach (DataGridViewRow DGVR in product_DGV.Rows)
            {
                if (DGVR.Cells["product_id"].Value.ToString() == product_id)
                {
                    index = DGVR.Index;
                    break;
                }
            }

            if (index == -1)
            {
                product_DGV.Rows.Add(
                    product_name,
                    price,
                    amount,
                    "0.00",
                    net_price_before_vat,
                    vat_amount,
                    vat,
                    product_id
                );

                product_DGV.Rows[product_DGV.Rows.Count - 1].HeaderCell.Value = product_DGV.Rows.Count.ToString();
                calculateRowTotal(product_DGV.Rows[product_DGV.Rows.Count - 1]);
            }
            else
            {
                DataGridViewRow DGVR = product_DGV.Rows[index];
                Int32 tmp;
                if (!Int32.TryParse(DGVR.Cells["amount"].Value.ToString(), out tmp))
                {
                    String errTxt = "'จำนวน' ในตาราง ต้องไม่ถูกเว้นว่าง หรือ ต้องมากกว่า 0 !\r\nค่าปัจจุบัน : " + DGVR.Cells["amount"].Value.ToString();
                    GF.printError("*** " + errTxt + " *** (Int32.TryParse(DGVR.Cells['amount'].Value.ToString()) @ shop.addRow)");
                    GF.submitErrorLog();
                    GF.Error(errTxt);
                    return;
                }
                if (!Int32.TryParse(amount, out tmp))
                {
                    String errTxt = "'จำนวน' ที่กรอก ต้องไม่ถูกเว้นว่าง หรือ ต้องมากกว่า 0 !\r\nค่าปัจจุบัน : " + amount;
                    GF.printError("*** " + errTxt + " *** (Int32.TryParse(amount) @ shop.addRow)");
                    GF.submitErrorLog();
                    GF.Error(errTxt);
                    return;
                }
                DGVR.Cells["amount"].Value = Convert.ToInt32(DGVR.Cells["amount"].Value.ToString()) + Convert.ToInt32(amount);
                calculateRowTotal(product_DGV.Rows[index]);
            }
        }

        private void calculateRowTotal(DataGridViewRow DGVR)
        {
            int price = Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["price"].Value.ToString()));
            int amount = 0;
            if (!Int32.TryParse(DGVR.Cells["amount"].Value.ToString(), out amount))
            {
                GF.Error("จำนวนต้องเป็นตัวเลขเท่านั้น !!");
                return;
            }
            if (amount < 0)
            {
                GF.Error("จำนวนต้องมากกว่า 0 !!");
                DGVR.Cells["total_price"].Value = "0";
                return;
            }
            if (amount == 0)
            {
                product_DGV.Rows.Remove(DGVR);
                calculateGrandTotal();
                return;
            }

            int total_price = price * amount;
            DGVR.Cells["total_price"].Value = GF.formatNumber(total_price);

            double vat = 0.00;
            if ((DGVR.Cells["the_vat"].Value ?? "").ToString() == String.Empty) vat = Convert.ToDouble(GF.Settings("vat"));
            else vat = Convert.ToDouble(DGVR.Cells["the_vat"].Value.ToString());
            DGVR.Cells["net_price_before_vat"].Value = ((total_price * 100) / (100 + vat)).ToString("0.##");
            DGVR.Cells["vat_amount"].Value = (Convert.ToDouble(DGVR.Cells["total_price"].Value.ToString()) - Convert.ToDouble(DGVR.Cells["net_price_before_vat"].Value.ToString())).ToString("0.##");
            DGVR.Cells["the_vat"].Value = string.Format("{0:f2}", vat);

            calculateGrandTotal();
        }

        void calculateGrandTotal()
        {
            int total = 0;
            foreach (DataGridViewRow DGVR in product_DGV.Rows)
            {
                total += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["total_price"].Value.ToString()));
            }
            grand_total.Text = GF.formatNumber(total) + ".00 บาท";
        }

        void calculatePaid()
        {
            int total_paid = 0;

            foreach (DataGridViewRow DGVR in payment_DGV.Rows)
            {
                total_paid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["payment_amount"].Value.ToString()));
            }

            paid.Text = GF.formatNumber(total_paid) + ".00 บาท";
        }

        private void product_DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateRowTotal(product_DGV.Rows[e.RowIndex]);

            product_code.Select();
        }

        private void product_DGV_KeyUp(object sender, KeyEventArgs e)
        {
            if (product_DGV.SelectedCells.Count == 1)
            {
                if (product_DGV.SelectedCells[0].ReadOnly && e.KeyCode == Keys.Delete)
                {
                    product_DGV.Rows.RemoveAt(product_DGV.SelectedCells[0].RowIndex);
                    return;
                }
            }
        }

        private void add_product_btn_Click(object sender, EventArgs e)
        {
            int rowCountBeforeChooseProduct = product_DGV.Rows.Count;
            using (shop_choose_product chooseProduct = new shop_choose_product())
            {
                chooseProduct.Owner = this;
                chooseProduct.ShowDialog();
            }
            this.BringToFront();
            this.Activate();

            if (product_DGV.Rows.Count > rowCountBeforeChooseProduct)
            {
                product_DGV.Select();
                product_DGV.Rows[product_DGV.Rows.Count - 1].Cells["amount"].Selected = true;
            }
            else product_code.Select();
        }

        private void add_payment_btn_Click(object sender, EventArgs e)
        {
            if (grand_total.Text.Trim() == "0.00 บาท")
            {
                GF.Error("กรุณาเลือกสินค้าก่อน !!");
                return;
            }
            if (grand_total.Text.Trim() == paid.Text.Trim())
            {
                GF.Error("ชำระเงินครบแล้ว !!");
                return;
            }
            using (shop_payment shopPayment = new shop_payment())
            {
                int tmp_total = Convert.ToInt32(GF.removeCommaDotFromNumber(grand_total.Text.Trim().Split(' ')[0]));
                int tmp_paid = Convert.ToInt32(GF.removeCommaDotFromNumber(paid.Text.Trim().Split(' ')[0]));
                shopPayment.max_amount = tmp_total - tmp_paid;
                shopPayment.Owner = this;
                shopPayment.ShowDialog();
            }
            calculatePaid();
            this.BringToFront();
            this.Activate();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (product_DGV.Rows.Count == 0)
            {
                GF.Error("ยังไม่ได้เลือกสินค้า !!");
                return;
            }

            if (payment_DGV.Rows.Count == 0)
            {
                GF.Error("ยังไม่ได้บันทึกจำนวนเงินที่ลูกค้าชำระ !!");
                return;
            }

            calculatePaid();

            if (paid.Text.Trim() != grand_total.Text.Trim())
            {
                GF.Error("ยังบันทึกเงินไม่ครบ !!\r\n\r\nต้องบันทึกให้ครบ " + grand_total.Text);
                return;
            }

            Double total_net_price_before_vat = 0.00;
            Double total_vat_amount = 0.00;

            String product_list = "";
            foreach (DataGridViewRow DGVR in product_DGV.Rows)
            {
                product_list += DGVR.Cells["product_id"].Value.ToString() + "##";
                product_list += GF.removeCommaDotFromNumber(DGVR.Cells["price"].Value.ToString()) + "##";
                product_list += DGVR.Cells["amount"].Value.ToString() + "##";
                product_list += GF.removeCommaDotFromNumber(DGVR.Cells["total_price"].Value.ToString()) + "##";
                product_list += DGVR.Cells["net_price_before_vat"].Value.ToString() + "##";
                product_list += DGVR.Cells["vat_amount"].Value.ToString() + "##";
                product_list += string.Format("{0:f2}", Convert.ToDouble(DGVR.Cells["the_vat"].Value.ToString())) + "!!";

                total_net_price_before_vat += Convert.ToDouble(DGVR.Cells["net_price_before_vat"].Value.ToString());
                total_vat_amount += Convert.ToDouble(DGVR.Cells["vat_amount"].Value.ToString());
            }
            if (product_list.Trim() != String.Empty) product_list = product_list.Substring(0, product_list.Trim().Length - 2);

            String payment_list = "";
            foreach (DataGridViewRow DGVR in payment_DGV.Rows)
            {
                payment_list += DGVR.Cells["payment_type"].Value.ToString() + "##";
                payment_list += GF.removeCommaDotFromNumber(DGVR.Cells["payment_amount"].Value.ToString()) + "##";
                payment_list += DGVR.Cells["card_no"].Value.ToString() + "##";
                payment_list += DGVR.Cells["card_expiry_date"].Value.ToString() + "!!";
            }
            if (payment_list.Trim() != String.Empty) payment_list = payment_list.Substring(0, payment_list.Trim().Length - 2);

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "grand_total", GF.removeCommaDotFromNumber(grand_total.Text.Trim().Split(' ')[0].Trim()) },
                { "product_list", product_list },
                { "payment_list", payment_list },
                { "branch_id", GF.Settings("branch_id") },
                { "receive_by", GF.userID },
                { "total_net_price_before_vat", total_net_price_before_vat.ToString("0.##") },
                { "total_vat_amount", total_vat_amount.ToString("0.##") },
                { "vat", Convert.ToDouble(GF.Settings("vat")).ToString("0.##") }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Shop/Payment/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            Dictionary<String, Object> Item = (Dictionary<String, Object>)result["result"];
            bill_id = Item["bill_id"].ToString();

            product_DGV.ClearSelection();
            payment_DGV.ClearSelection();

            bill_search_btn.Text = "เปิดบิลใหม่";
            product_code.Enabled = false;
            GF.disableBtn(add_product_btn);
            product_DGV.Enabled = false;
            GF.disableBtn(add_payment_btn);
            payment_DGV.Enabled = false;
            GF.disableBtn(manage_btn);

            if (GF.isAdmin) void_btn.Visible = true;

            GF.closeLoading();

            if (bill_id.Trim() != String.Empty) 
                if(GF.hasReceiptPrinter()) 
                    print();
        }

        private void bill_search_btn_Click(object sender, EventArgs e)
        {
            if (bill_search_btn.Text == "ค้นหาใบเสร็จ")
            {
                using (search_bill_from_no BillNo = new search_bill_from_no())
                {
                    BillNo.Owner = this;
                    BillNo.ShowDialog();

                    calculateGrandTotal();
                    calculatePaid();
                }
            }
            else if (bill_search_btn.Text == "เปิดบิลใหม่")
                newBill();
        }

        private void void_btn_Click(object sender, EventArgs e)
        {
            using (shop_void Void = new shop_void(bill_id))
            {
                Void.Owner = this;
                Void.ShowDialog();
            }

            this.BringToFront();
            this.Activate();
        }

        private void payment_DGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculatePaid();
        }

        void print()
        {
            Boolean needVat = false;
            if (MessageBox.Show("ลูกค้าต้องการบิล Vat หรือไม่ ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                needVat = true;

            print_receipt.initPrint(this, bill_id, needVat);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            print();
        }
    }
}
