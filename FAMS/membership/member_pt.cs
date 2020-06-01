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
    public partial class member_pt : Form
    {
        public String member_id = "";
        public String member_pt_id = "";
        public Boolean isForceAdd = false;
        public Boolean isForceEdit = false;
        public Boolean onlySee = false;
        public Boolean isAlreadyVoided = false;
        Dictionary<String, String> PTPrice = new Dictionary<string, string>();
        Dictionary<String, int> MonthAmount = new Dictionary<string, int>();
        Dictionary<String, int> HoursAmount = new Dictionary<string, int>();
        int totalPaid = 0;
        public member_pt()
        {
            InitializeComponent();

            start_date.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + (DateTime.Now.Year + 543).ToString("0000");
            start_date.ValidatingType = typeof(DateTime);

            payment_DGV.Paint += GF.DGV_Paint;
        }

        private void member_pt_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);

            if (onlySee)
                disableAll();

            if (isForceEdit || isForceAdd)
            {
                amount_left_lbl1.Visible = amount_left.Visible = amount_left_lbl2.Visible = true;
                seller_emp_lbl.Visible = seller_emp_id.Visible = true;

                GF.disableBtn(add_payment_btn);
                payment_DGV.Enabled = false;
            }

            if (isAlreadyVoided)
            {
                amount_left.Enabled = false;
                seller_emp_id.Enabled = false;
            }

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "branch_id", ((isForceAdd || isForceEdit || onlySee) ? "-1" : GF.Settings("branch_id")) }
            };

            Dictionary<String, Object> Obj = DB.Post("PT/PTList/", values);

            if (Obj != null)
            {
                if(!isForceAdd && !isForceEdit)
                    pt_emp_id.Items.Add(new ComboItem(0, "เลือก 'เทรนเนอร์'"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    pt_emp_id.Items.Add(new ComboItem(GF.toInt(Item["emp_id"].ToString()), Item["fullname"].ToString() + " (" + Item["nickname"].ToString() + ")"));
                    seller_emp_id.Items.Add(new ComboItem(GF.toInt(Item["emp_id"].ToString()), Item["fullname"].ToString() + " (" + Item["nickname"].ToString() + ")"));
                }

                pt_emp_id.SelectedIndex = 0;
                seller_emp_id.SelectedIndex = 0;
                GF.resizeComboBox(pt_emp_id);
                GF.resizeComboBox(seller_emp_id);
            }
            else
                GF.Error("ไม่มีข้อมูล 'เทรนเนอร์' !!\r\n\r\nกรุณาแจ้งผู้ดูแลระบบ !!");

            // GET BUY PT DATA
            if (member_pt_id != String.Empty)
            {
                values = new Dictionary<string, string>()
                {
                    { "member_pt_id" , member_pt_id.Trim() }
                };

                Obj = DB.Post("Member/getBuyPTData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    hours.Text = Item["max_hours"].ToString();
                    start_date.Text = (Item["start_date"] ?? "").ToString();
                    expiry_date.Text = Item["expiry_date"].ToString();
                    price.Text = Item["price"].ToString();
                    age.Text = (Item["age"] ?? "").ToString();
                    amount_left.Text = (Item["left_hours"] ?? "").ToString();
                    note_txt.Text = (Item["note"] ?? "").ToString();

                    foreach (ComboItem cb in pt_emp_id.Items)
                    {
                        if (cb.Key.ToString() == Item["pt_emp_id"].ToString())
                        {
                            pt_emp_id.Text = cb.Value;
                        }
                    }

                    foreach (ComboItem cb in seller_emp_id.Items)
                    {
                        if (cb.Key.ToString() == Item["pt_seller_id"].ToString())
                        {
                            seller_emp_id.Text = cb.Value;
                        }
                    }

                    String payment_data = (Item["payment_data"] ?? "").ToString().Trim();
                    if (payment_data != String.Empty)
                    {
                        payment_DGV.Rows.Clear();
                        String[] payment_record = payment_data.Split(new String[] { "!!" }, StringSplitOptions.None);
                        foreach (String payment_item in payment_record)
                        {
                            String[] tmp = payment_item.Split(new String[] { "##" }, StringSplitOptions.None);
                            String the_payment_type = Array.Find(GF.payment_type, p => Convert.ToInt32(p.Key) == Convert.ToInt32(tmp[0].ToString())).Value;

                            String[] Data = {
                                the_payment_type,
                                tmp[1].ToString(),
                                (tmp[2] ?? "").ToString(),
                                (tmp[3] ?? "").ToString(),
                                tmp[4].ToString(),
                                GF.formatDBDateTime(tmp[5].ToString()),
                                tmp[6].ToString(),
                                tmp[7].ToString()
                            };

                            GF.addPaymentRow(payment_DGV, Data, tmp[6].ToString());
                        }
                        payment_DGV.ClearSelection();
                    }
                }
            }

            GF.closeLoading();
        }

        private void add_payment_btn_Click(object sender, EventArgs e)
        {
            if (price.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'ราคา' ก่อน !!");
                price.Select();
                return;
            }

            calculatePaid();
            if (Convert.ToInt32(GF.removeCommaDotFromNumber(total_payment_txt.Text.Trim())) == Convert.ToInt32(price.Text.Trim()))
            {
                GF.Error("ชำระเงินครบแล้ว !!");
                return;
            }
            using (member_pt_payment memberPTPayment = new member_pt_payment())
            {
                memberPTPayment.max_amount = Convert.ToInt32(price.Text.Trim()) - totalPaid;
                memberPTPayment.Owner = this;
                memberPTPayment.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }

        void calculatePaid()
        {
            totalPaid = 0;
            foreach (DataGridViewRow DGVR in payment_DGV.Rows)
            {
                totalPaid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["payment_amount"].Value.ToString()));
            }

            total_payment_txt.Text = GF.formatNumber(totalPaid);
        }

        public void calculateExpiryDate()
        {
            if (start_date.Text.Replace(" ", "").Replace("/", "").Trim() == String.Empty)
            {
                expiry_date.Text = "-";
                return;
            }

            if (start_date.Text.Trim().Length < 10)
            {
                expiry_date.Text = "-";
                return;
            }

            if (age.Text.Trim() == String.Empty)
            {
                expiry_date.Text = "-";
                return;
            }

            if (Convert.ToInt32(age.Text.Trim()) <= 0)
            {
                expiry_date.Text = "-";
                return;
            }

            int months = Convert.ToInt32(age.Text.Trim());

            String[] tmpDate = start_date.Text.Split('/');
            
            DateTime DateStart;
            if (!DateTime.TryParse(((Convert.ToInt32(tmpDate[2]) - 543)).ToString("0000") + "-" + Convert.ToInt32(tmpDate[1]).ToString("00") + "-" + Convert.ToInt32(tmpDate[0]).ToString("00"), out DateStart))
            {
                String errTxt = "วัน เดือน ปี ไม่อยู่ในรูปแบบที่ถูกต้อง !\r\nค่าปัจจุบัน : " + start_date;
                GF.printError("***" + errTxt + "*** (DateTime.TryParse @ member_pt.calculateExpiryDate)");
                //GF.submitErrorLog();
                GF.Error(errTxt);
                return;
            }

            DateTime DateEnd = DateStart.AddMonths(months).AddDays(-1);
            expiry_date.Text = DateEnd.Day.ToString("00") + "/" + DateEnd.Month.ToString("00") + "/" + (DateEnd.Year + 543).ToString("0000");
        }

        private void payment_DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calculatePaid();
        }

        private void payment_DGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculatePaid();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (hours.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'จำนวน ชั่วโมง' !!");
                hours.Select();
                return;
            }

            if (Convert.ToInt32(hours.Text.Trim()) <= 0)
            {
                GF.Error("'จำนวน ชั่วโมง' ต้องมากกว่า 0 !!");
                hours.Select();
                return;
            }

            if (price.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'ราคา' !!");
                price.Select();
                return;
            }

            if (Convert.ToInt32(price.Text.Trim()) <= 0)
            {
                GF.Error("'ราคา' ต้องมากกว่า 0 !!");
                price.Select();
                return;
            }

            if (start_date.Text.Replace(" ", "").Replace("/", "").Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'วันที่เริ่มต้น PT' !!");
                start_date.Select();
                return;
            }

            if (start_date.Text.Trim().Length < 10)
            {
                GF.Error("กรุณากรอก 'วันที่เริ่มต้น PT' ให้ครบ !!\r\n\r\n(หาก วัน หรือ เดือน เป็นเลขตัวเดียว ให้เติม 0 ข้างหน้า)");
                start_date.Select();
                return;
            }

            if (expiry_date.Text.Replace(" ", "").Replace("/", "").Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'วันหมดอายุ PT' !!");
                expiry_date.Select();
                return;
            }

            if (expiry_date.Text.Trim().Length < 10)
            {
                GF.Error("กรุณากรอก 'วันหมดอายุ PT' ให้ครบ !!\r\n\r\n(หาก วัน หรือ เดือน เป็นเลขตัวเดียว ให้เติม 0 ข้างหน้า)");
                expiry_date.Select();
                return;
            }

            if (age.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'อายุ' !!");
                age.Select();
                return;
            }

            if (Convert.ToInt32(age.Text.Trim()) <= 0)
            {
                GF.Error("'อายุ' ต้องมากกว่า 0 !!");
                age.Select();
                return;
            }

            if (pt_emp_id.SelectedIndex == 0 && !isForceAdd && !isForceEdit)
            {
                GF.Error("กรุณาเลือก 'เทรนเนอร์' !!");
                pt_emp_id.Select();
                return;
            }

            if (isForceAdd || isForceEdit)
            {
                if (amount_left.Text.Trim().Length == 0)
                {
                    GF.Error("กรุณาระบุ 'ชั่วโมงเหลือ' !!");
                    amount_left.Select();
                    return;
                }

                if (seller_emp_id.SelectedIndex == 0)
                {
                    GF.Error("กรุณาเลือก 'ผู้ขาย' !!");
                    seller_emp_id.Select();
                    return;
                }
            }

            String payment_list = "";

            String is_already_paid = "0";
            String do_not_insert_member_pt_payment = "0";

            double net_price_before_vat = 0.00;
            double vat = Convert.ToDouble(GF.Settings("vat"));
            double vat_amount = 0.00;
            int current_total_paid = 0;

            calculatePaid();
            if (!isForceEdit && !isForceAdd)
            {
                if (Convert.ToInt32(GF.removeCommaDotFromNumber(total_payment_txt.Text.Trim())) < Convert.ToInt32(price.Text.Trim()))
                {
                    GF.Error("ยังชำระเงินไม่ครบ " + GF.formatNumber(price.Text.Trim()) + " บาท !!");
                    return;
                }

                if (Convert.ToInt32(GF.removeCommaDotFromNumber(total_payment_txt.Text.Trim())) > Convert.ToInt32(price.Text.Trim()))
                {
                    GF.Error("ชำระเงินเกิน " + price.Text.Trim() + " บาท !!");
                    return;
                }
            }

            foreach (DataGridViewRow DGVR in payment_DGV.Rows)
            {
                payment_list += DGVR.Cells["payment_type"].Value.ToString() + "##";
                payment_list += GF.removeCommaDotFromNumber(DGVR.Cells["payment_amount"].Value.ToString()) + "##";
                payment_list += DGVR.Cells["card_no"].Value.ToString() + "##";
                payment_list += DGVR.Cells["card_expiry_date"].Value.ToString() + "!!";

                current_total_paid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["payment_amount"].Value.ToString()));
            }

            if (payment_list.Trim() != String.Empty)
                payment_list = payment_list.Substring(0, payment_list.Trim().Length - 2);

            net_price_before_vat += (current_total_paid * 100) / (100 + vat);
            vat_amount = current_total_paid - net_price_before_vat;

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "branch_id", GF.Settings("branch_id") },
                { "member_id", member_id },
                { "price", price.Text.Trim() },
                { "hours", hours.Text.Trim() },
                { "age", age.Text.Trim() },
                { "start_date", start_date.Text.Trim() },
                { "expiry_date", expiry_date.Text.Trim() },
                { "note", note_txt.Text.Trim() },
                { "pt_emp_id", ((ComboItem)pt_emp_id.SelectedItem).Key.ToString() },
                { "process_by", GF.userID },
                { "payment_list", payment_list },
                { "is_already_paid", is_already_paid },
                { "do_not_insert_member_pt_payment", do_not_insert_member_pt_payment },
                { "net_price_before_vat", net_price_before_vat.ToString("0.##") },
                { "vat_amount", vat_amount.ToString("0.##") },
                { "vat", string.Format("{0:f2}", vat) },
                { "isForceAdd", (isForceAdd ? "1" : "0") },
                { "isForceEdit", (isForceEdit ? "1" : "0") }
            };

            if (isForceEdit)
                values["member_pt_id"] = member_pt_id;

            if (isForceAdd || isForceEdit)
            {
                values["seller_emp_id"] = ((ComboItem)seller_emp_id.SelectedItem).Key.ToString();
                values["amount_left"] = amount_left.Text.Trim();
            }

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/BuyPT/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            disableAll();

            GF.closeLoading();
            member_pt_id = result["member_pt_id"].ToString();

            if(!isForceEdit && !isForceAdd)
                print();
            else
            {
                (this.Owner as history_buy_pt).getData();
                this.Close();
            }
        }

        void disableAll()
        {
            print_btn.Visible = true;
            save_btn.Visible = false;

            hours.Enabled = false;
            price.Enabled = false;
            age.Enabled = false;
            pt_emp_id.Enabled = false;
            start_date.Enabled = false;

            GF.disableBtn(add_payment_btn);
            payment_DGV.Enabled = false;
        }

        void print()
        {
            Boolean needVat = false;
            if (MessageBox.Show("ลูกค้าต้องการบิล Vat หรือไม่ ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                needVat = true;

            print_member_pt.initPrint(this, member_pt_id, needVat);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if(GF.hasReceiptPrinter()) print();
        }

        private void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void amount_left_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void age_KeyUp(object sender, KeyEventArgs e)
        {
            calculateExpiryDate();
        }

        private void start_date_KeyUp(object sender, KeyEventArgs e)
        {
            calculateExpiryDate();
        }
    }
}
