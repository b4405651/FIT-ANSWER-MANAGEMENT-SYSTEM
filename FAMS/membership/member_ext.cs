using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class member_ext : Form
    {
        Boolean isHalt = false;
        public Boolean isForceEdit = false;
        public Boolean isImport = false;
        public Boolean onlySee = false;
        public Boolean changeData = false;
        public Boolean isAlreadyVoided = false;
        public string member_ext_id = "";
        public string member_id = "";
        Dictionary<String, String> MemberPrice = new Dictionary<string, string>();
        Dictionary<String, int> MonthAmount = new Dictionary<string, int>();
        String member_type_before_change = "";
        int totalPaid = 0;
        Boolean mustPayFullAmount = false;
        String is_already_paid = "0";

        public member_ext()
        {
            InitializeComponent();

            deposit_DGV.Paint += GF.DGV_Paint;
            full_DGV.Paint += GF.DGV_Paint;

            start_date.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + (DateTime.Now.Year + 543).ToString("0000");
            start_date.ValidatingType = typeof(DateTime);

            GF.showLoading(this);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("User/getApprover/", values);

            if (Obj != null)
            {
                discount_by.Items.Add(new ComboItem(0, "เลือก 'ผู้อนุมัติ'"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    discount_by.Items.Add(new ComboItem(GF.toInt(Item["user_id"].ToString()), Item["approver"].ToString()));
                }

                discount_by.SelectedIndex = 0;
                GF.resizeComboBox(discount_by);
            }
                
            values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                foreach (Dictionary<String, Object> Branch in (Array)Obj["result"])
                {
                    Boolean isChecked = (Convert.ToInt32(Branch["branch_id"].ToString()) == Convert.ToInt32(GF.Settings("branch_id")) && member_ext_id.Trim() == String.Empty);
                    branch_list.Items.Add(new ComboItem(Convert.ToInt32(Branch["branch_id"].ToString()), Branch["branch_name"].ToString()), isChecked);
                }
            }

            GF.closeLoading();
        }

        private void member_ext_Load(object sender, EventArgs e)
        {
            if (isHalt)
            {
                this.Close();
                return;
            }

            getTotalDeposit();
            getTotalFullPayment();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID },
                { "can_get_commission" , "1" }
            };

            if (!(onlySee || changeData)) values.Add("branch_id", GF.Settings("branch_id"));

            if (member_ext_id != String.Empty)
                values.Add("member_ext_id", member_ext_id);

            Dictionary<String, Object> Obj = DB.Post("Employee/EmployeeList/", values);

            if (Obj != null)
            {
                seller_emp_id.Items.Add(new ComboItem(0, "เลือก 'ผู้รับคอมมิชชั่น'"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    seller_emp_id.Items.Add(new ComboItem(GF.toInt(Item["emp_id"].ToString()), Item["fullname"].ToString() + " (" + Item["nickname"].ToString() + ")"));
                }

                seller_emp_id.SelectedIndex = 0;
                GF.resizeComboBox(seller_emp_id);
            }
            else
            {
                GF.closeLoading();
                GF.Error("ไม่มีข้อมูล 'บุคลากร' !!\r\n\r\nกรุณาแจ้งผู้ดูแลระบบ !!");
            }

            Obj = DB.Post("MemberType/MemberTypeList/", values);

            if (Obj != null)
            {
                if (!isForceEdit)
                    member_type.Items.Add(new ComboItem(0, "เลือก 'ประเภทสมาชิก'"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    member_type.Items.Add(new ComboItem(GF.toInt(Item["member_type_id"].ToString()), Item["member_type_name"].ToString()));
                    MemberPrice.Add(Item["member_type_id"].ToString(), Item["price"].ToString());
                    MonthAmount.Add(Item["member_type_id"].ToString(), Convert.ToInt32(Item["month_amount"].ToString()));
                }

                member_type.SelectedIndex = 0;
                GF.resizeComboBox(member_type);
            }
            else
            {
                GF.closeLoading();
                GF.Error("ไม่มีข้อมูล 'ประเภทสมาชิก' !!\r\n\r\nกรุณาแจ้งผู้ดูแลระบบ !!");
                isHalt = true;
            }

            values = new Dictionary<string, string>()
            {
                { "member_id" , member_id.Trim() }
            };

            if (member_ext_id != String.Empty)
                values.Add("member_ext_id", member_ext_id);

            Obj = DB.Post("Member/getExtData/", values);

            if (Obj != null)
            {
                if ((Obj["result"] as Dictionary<String, Object>) != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    is_already_paid = Item["is_paid"].ToString();

                    if(member_ext_id == String.Empty)
                        member_ext_id = Item["member_ext_id"].ToString();
                    member_id = Item["member_id"].ToString();
                    member_type.Text = Item["member_type_name"].ToString();
                    contract_no.Text = (Item["contract_no"] ?? "").ToString();
                    start_date.Text = Item["start_date"].ToString();
                    expiry_date.Text = Item["expiry_date"].ToString();
                    note.Text = (Item["note"] ?? "").ToString();

                    if ((Item["discount_by"] ?? "").ToString() != String.Empty)
                        discount_cb.Checked = true;

                    if ((Item["discount_amount"] ?? "").ToString() != String.Empty)
                        discount_amount.Text = Item["discount_amount"].ToString();

                    if ((Item["discount_note"] ?? "").ToString() != String.Empty)
                        discount_note.Text = Item["discount_note"].ToString();

                    if ((Item["discount_by"] ?? "").ToString() != String.Empty)
                    {
                        foreach (ComboItem cb in discount_by.Items)
                        {
                            if (cb.Key.ToString() == Item["discount_by"].ToString())
                            {
                                discount_by.Text = cb.Value;
                                break;
                            }
                        }
                    }

                    if ((Item["seller_emp_id"] ?? "").ToString() != String.Empty)
                    {
                        foreach (ComboItem cb in seller_emp_id.Items)
                        {
                            if (cb.Key.ToString() == Item["seller_emp_id"].ToString())
                            {
                                seller_emp_id.Text = cb.Value;
                                break;
                            }
                        }
                    }

                    mustPayFullAmount = (Item["is_paid"].ToString() == "0");

                    String deposit_data = (Item["deposit_data"] ?? "").ToString().Trim();
                    if (deposit_data != String.Empty)
                    {
                        deposit_DGV.Rows.Clear();
                        String[] deposit_record = deposit_data.Split(new String[] { "!!" }, StringSplitOptions.None);
                        foreach (String deposit_item in deposit_record)
                        {
                            String[] tmp = deposit_item.Split(new String[] { "##" }, StringSplitOptions.None);
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

                            GF.addPaymentRow(deposit_DGV, Data, tmp[6].ToString());
                        }
                        deposit_DGV.ClearSelection();
                        deposit_DGV.Enabled = false;
                        GF.disableBtn(add_deposit_btn);
                        getTotalDeposit();
                    }

                    String full_payment_data = (Item["full_payment_data"] ?? "").ToString().Trim();
                    if (full_payment_data != String.Empty)
                    {
                        full_DGV.Rows.Clear();
                        String[] full_payment_record = full_payment_data.Split(new String[] { "!!" }, StringSplitOptions.None);
                        foreach (String full_payment_item in full_payment_record)
                        {
                            String[] tmp = full_payment_item.Split(new String[] { "##" }, StringSplitOptions.None);
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

                            GF.addPaymentRow(full_DGV, Data, tmp[6].ToString());
                        }
                        full_DGV.ClearSelection();
                        full_DGV.Enabled = false;
                        GF.disableBtn(add_full_btn);
                        getTotalFullPayment();
                    }

                    String[] allow_branch = Item["allow_branch_id"].ToString().Split(',');
                    for (int i = 0; i < branch_list.Items.Count; i++)
                        if (allow_branch.Contains((branch_list.Items[i] as ComboItem).Key.ToString()))
                            branch_list.SetItemCheckState(i, CheckState.Checked);
                        else
                            branch_list.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            if (onlySee)
                disableAll();

            if (changeData)
            {
                manage_btn.Visible = true;
                print_btn.Visible = false;
            }

            if (isForceEdit)
            {
                //member_type.Enabled = true;
                contract_no.Enabled = true;
                start_date.Enabled = true;
                expiry_date.Enabled = true;
                seller_emp_id.Enabled = true;
            }

            if (isAlreadyVoided) {
                branch_list.Enabled = false;
            }
        }

        private void member_type_Enter(object sender, EventArgs e)
        {
            member_type_before_change = member_type.Text;
        }

        private void member_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean flag = !(/*member_type.SelectedIndex == 0 && */member_type.Text == "เลือก 'ประเภทสมาชิก'");

            if (!isForceEdit)
            {
                manage_btn.Visible = flag;
                deposit_gb.Enabled = flag;
                full_payment_gb.Enabled = flag;
                discount_gb.Enabled = flag;
            }

            if (/*member_type.SelectedIndex == 0 && */member_type.Text == "เลือก 'ประเภทสมาชิก'")
            {
                full_amount.Text = "-";
                expiry_date.Clear();
                discount_cb.Checked = false;
                GF.disableBtn(add_deposit_btn);
                GF.disableBtn(add_full_btn);
            }
            else
            {
                full_amount.Text = GF.formatNumber(Convert.ToInt32(MemberPrice[((ComboItem)member_type.SelectedItem).Key.ToString()])) + " บาท";
                if (!isForceEdit)
                {
                    GF.enableBtn(add_deposit_btn, Color.FromArgb(255, 128, 0));
                    GF.enableBtn(add_full_btn, Color.FromArgb(255, 128, 0));
                }
                getEndDate();
            }
        }

        void getEndDate()
        {
            if(!isForceEdit)
                if (member_type.SelectedIndex > 0)
                {
                    if (start_date.Text.Trim() != String.Empty)
                    {
                        String[] tmpDate = start_date.Text.Split('/');
                        DateTime DateStart = new DateTime(Convert.ToInt32(tmpDate[2]) - 543, Convert.ToInt32(tmpDate[1]), Convert.ToInt32(tmpDate[0]));
                        DateTime DateEnd = DateStart.AddMonths(MonthAmount[((ComboItem)member_type.SelectedItem).Key.ToString()]).AddDays(-1);
                        expiry_date.Text = DateEnd.Day.ToString("00") + "/" + DateEnd.Month.ToString("00") + "/" + (DateEnd.Year + 543).ToString("0000");
                    }
                }
        }

        void calculatePaid()
        {
            totalPaid = 0;
            foreach(DataGridViewRow DGVR in deposit_DGV.Rows)
            {
                totalPaid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["deposit_amount"].Value.ToString()));
            }

            foreach (DataGridViewRow DGVR in full_DGV.Rows)
            {
                totalPaid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["full_payment_amount"].Value.ToString()));
            }
        }

        private void add_deposit_btn_Click(object sender, EventArgs e)
        {
            calculatePaid();
            int amount_left = Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Split(' ')[0])) - totalPaid - Convert.ToInt32(discount_amount.Text.Trim());
            if(amount_left <= 0)
            {
                GF.Error("ลูกค้าชำระครบแล้ว !!");
                return;
            }
            using (member_payment memberPayment = new member_payment())
            {
                memberPayment.max_amount = amount_left;
                memberPayment.Text += " :: คงเหลือที่ต้องชำระ " + GF.formatNumber(amount_left) + " บาท";
                memberPayment.isDeposit = true;
                memberPayment.Owner = this;
                memberPayment.ShowDialog();
                this.BringToFront();
            }
            getTotalDeposit();
        }

        private void add_full_btn_Click(object sender, EventArgs e)
        {
            calculatePaid();
            int amount_left = Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Split(' ')[0])) - totalPaid - Convert.ToInt32(discount_amount.Text.Trim());
            if (amount_left <= 0)
            {
                GF.Error("ลูกค้าชำระครบแล้ว !!");
                return;
            }
            using (member_payment memberPayment = new member_payment())
            {
                memberPayment.max_amount = amount_left;
                memberPayment.Text += " :: คงเหลือที่ต้องชำระ " + GF.formatNumber(amount_left) + " บาท";
                memberPayment.isDeposit = false;
                memberPayment.Owner = this;
                memberPayment.ShowDialog();
                this.BringToFront();
            }
            getTotalFullPayment();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (member_ext_id == String.Empty)
            {
                if ((deposit_DGV.Rows.Count > 0 && deposit_DGV.Enabled) && (full_DGV.Rows.Count > 0 && full_DGV.Enabled))
                {
                    GF.Error("การชำระเงินในครั้งแรก ของการซื้อ member ...\r\n\r\nต้องเลือกระหว่าง 'มัดจำ' หรือ 'ชำระเต็มจำนวน' อย่างใดอย่างหนึ่ง\r\n\r\nไม่สามารถระบุพร้อมกันได้ !!");
                    return;
                }
            }
            if(/*member_type.SelectedIndex == 0 && */member_type.Text == "เลือก 'ประเภทสมาชิก'" && !isForceEdit)
            {
                GF.Error("กรุณาเลือก 'ประเภทสมาชิก' !!");
                member_type.Select();
                return;
            }

            if(start_date.Text.Replace(" ", "").Replace("/", "").Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'วันที่เริ่มต้นสมาชิก' !!");
                start_date.Select();
                return;
            }

            if(start_date.Text.Trim().Length < 10)
            {
                GF.Error("กรุณากรอก 'วันที่เริ่มต้นสมาชิก' ให้ครบ !!\r\n\r\n(หาก วัน หรือ เดือน เป็นเลขตัวเดียว ให้เติม 0 ข้างหน้า)");
                start_date.Select();
                return;
            }

            if (expiry_date.Text.Replace(" ", "").Replace("/", "").Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'วันที่สิ้นสุดสมาชิก' !!");
                expiry_date.Select();
                return;
            }

            if (expiry_date.Text.Trim().Length < 10)
            {
                GF.Error("กรุณาระบุ 'วันที่สิ้นสุดสมาชิก' ให้ครบ !!\r\n\r\n(หาก วัน หรือ เดือน เป็นเลขตัวเดียว ให้เติม 0 ข้างหน้า)");
                expiry_date.Select();
                return;
            }

            if (seller_emp_id.SelectedIndex == 0 && !isImport && !isForceEdit)
            {
                GF.Error("กรุณาเลือก 'ผู้ขายสมาชิก' !!");
                seller_emp_id.Select();
                return;
            }

            if (discount_cb.Checked)
            {
                if (discount_amount.Text.Trim() == String.Empty || discount_amount.Text.Trim() == "0")
                {
                    GF.Error("ยังไม่ได้ระบุมูลค่าส่วนลด !!");
                    discount_amount.Select();
                    return;
                }

                if (discount_by.SelectedIndex == 0)
                {
                    GF.Error("ยังไม่ได้ระบุ 'ผู้อนุมัติส่วนลด' !!");
                    discount_by.Select();
                    return;
                }

                if (discount_note.Text.Trim() == "")
                {
                    GF.Error("ยังไม่ได้ระบุ 'รายละเอียดส่วนลด' !!");
                    discount_note.Select();
                    return;
                }
            }
            
            String payment_list = "";

            is_already_paid = "0";

            double net_price_before_vat = 0.00;
            double vat = 0.00;
            double vat_amount = 0.00;
            int current_total_paid = 0;

            calculatePaid();

            if (!isImport && !isForceEdit && member_ext_id == String.Empty && deposit_DGV.Rows.Count == 0 && full_DGV.Rows.Count > 0 && Convert.ToInt32(GF.removeCommaDotFromNumber(total_full_txt.Text.Trim().Split(' ')[0])) < Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim()))
            {
                GF.Error("ยังบันทึกเงินไม่ครบ !!\r\n\r\nต้องบันทึกให้ครบ " + GF.formatNumber(Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim())));
                return;
            }

            if (!mustPayFullAmount && !isForceEdit && (deposit_DGV.Rows.Count == 0 && full_DGV.Rows.Count == 0) && !isImport)
            {
                GF.Error("ยังไม่ได้บันทึกจำนวนเงินที่ลูกค้าชำระ !!\r\n\r\n('มัดจำ' หรือ 'ชำระเต็มจำนวน')");
                return;
            }

            is_already_paid = (totalPaid >= Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim()) ? "1" : "0");

            if (mustPayFullAmount && !isImport && !isForceEdit)
            {
                if (full_DGV.Rows.Count == 0)
                {
                    GF.Error("ยังไม่ได้บันทึกจำนวนเงิน !!\r\n\r\n('ชำระส่วนที่เหลือ')");
                    return;
                }
                else
                {
                    if (totalPaid < Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim()))
                    {
                        GF.Error("ยังบันทึกเงินไม่ครบ !!\r\n\r\nต้องบันทึกให้ครบ " + GF.formatNumber(Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim())));
                        return;
                    }
                }
            }

            if (totalPaid > Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim()))
            {
                GF.Error("จำนวนเงินที่รับชำระมา มากกว่า จำนวนเงินที่ลูกค้าต้องชำระ !!\r\nกรุณาตรวจสอบอีกครั้ง !!\r\n\r\nรับชำระมา : " + GF.formatNumber(totalPaid) + " บาท\r\nจำนวนเงินที่ลูกค้าต้องชำระ : " + GF.formatNumber(Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])) - Convert.ToInt32(discount_amount.Text.Trim())) + " บาท");
                return;
            }

            if (!mustPayFullAmount)
            {
                if (deposit_DGV.Rows.Count > 0)
                {
                    if (deposit_DGV.Enabled)
                    {
                        foreach (DataGridViewRow DGVR in deposit_DGV.Rows)
                        {
                            payment_list += "1##";
                            payment_list += DGVR.Cells["deposit_payment_type"].Value.ToString() + "##";
                            payment_list += GF.removeCommaDotFromNumber(DGVR.Cells["deposit_amount"].Value.ToString()) + "##";
                            payment_list += DGVR.Cells["deposit_card_no"].Value.ToString() + "##";
                            payment_list += DGVR.Cells["deposit_card_expiry_date"].Value.ToString() + "!!";

                            current_total_paid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["deposit_amount"].Value.ToString()));
                        }
                    }
                }
                else if (full_DGV.Rows.Count > 0)
                {
                    if (full_DGV.Enabled)
                    {
                        foreach (DataGridViewRow DGVR in full_DGV.Rows)
                        {
                            payment_list += "0##";
                            payment_list += DGVR.Cells["full_payment_type"].Value.ToString() + "##";
                            payment_list += GF.removeCommaDotFromNumber(DGVR.Cells["full_payment_amount"].Value.ToString()) + "##";
                            payment_list += DGVR.Cells["full_card_no"].Value.ToString() + "##";
                            payment_list += DGVR.Cells["full_card_expiry_date"].Value.ToString() + "!!";

                            current_total_paid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["full_payment_amount"].Value.ToString()));
                        }
                    }
                }
            }
            else
            {
                if (full_DGV.Enabled)
                {
                    foreach (DataGridViewRow DGVR in full_DGV.Rows)
                    {
                        payment_list += "0##";
                        payment_list += DGVR.Cells["full_payment_type"].Value.ToString() + "##";
                        payment_list += GF.removeCommaDotFromNumber(DGVR.Cells["full_payment_amount"].Value.ToString()) + "##";
                        payment_list += DGVR.Cells["full_card_no"].Value.ToString() + "##";
                        payment_list += DGVR.Cells["full_card_expiry_date"].Value.ToString() + "!!";

                        current_total_paid += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["full_payment_amount"].Value.ToString()));
                    }
                }
            }
            if (payment_list.Trim() != String.Empty) payment_list = payment_list.Substring(0, payment_list.Trim().Length - 2);

            vat = Convert.ToDouble(GF.Settings("vat"));

            int grand_total = Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0]));
            if (discount_amount.Text.Trim() != String.Empty)
                if (Convert.ToInt32(discount_amount.Text.Trim()) > 0)
                    grand_total = grand_total - Convert.ToInt32(discount_amount.Text.Trim());

            net_price_before_vat += (grand_total * 100) / (100 + vat);
            vat_amount = grand_total - net_price_before_vat;

            Boolean isDeposit = false;
            
            if ((deposit_DGV.Rows.Count > 0 && deposit_DGV.Enabled) && full_DGV.Rows.Count == 0)
                isDeposit = true;

            if (member_ext_id == String.Empty && is_already_paid == "1" && ((deposit_DGV.Rows.Count > 0 && deposit_DGV.Enabled) && full_DGV.Rows.Count == 0))
                isDeposit = false;

            if (is_already_paid == "1" && contract_no.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'เลขที่สัญญา' !!");
                contract_no.Select();
                return;
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
                return;
            }
            else
                branch = branch.Substring(0, branch.Length - 1);

            Dictionary<string, string> values = new Dictionary<string, string>();

            if ((!onlySee && !changeData) || isForceEdit) // ADD NEW DAT -- OR -- ForceEdit
            {
                values = new Dictionary<string, string>
                {
                    { "member_id", member_id },
                    { "member_type_id", ((ComboItem)member_type.SelectedItem).Key.ToString() },
                    { "full_amount", GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0].Trim()) },
                    { "contract_no", contract_no.Text.Trim() },
                    { "start_date", start_date.Text.Trim() },
                    { "expiry_date", expiry_date.Text.Trim() },
                    { "is_paid", is_already_paid },
                    { "is_deposit", (isDeposit ? "1" : "0") },
                    { "payment_list", payment_list },
                    { "seller_emp_id", ((ComboItem)seller_emp_id.SelectedItem).Key.ToString() },
                    { "branch_id", GF.Settings("branch_id") },
                    { "ext_by", GF.userID },
                    { "discount_amount", (discount_cb.Checked ? discount_amount.Text.Trim() : "") },
                    { "discount_by", (discount_cb.Checked ? ((ComboItem)discount_by.SelectedItem).Key.ToString() : "") },
                    { "discount_note", (discount_cb.Checked ? discount_note.Text.Trim() : "") },
                    { "net_price_before_vat", net_price_before_vat.ToString("0.##") },
                    { "vat_amount", vat_amount.ToString("0.##") },
                    { "vat", string.Format("{0:f2}", vat) },
                    { "current_total_paid", current_total_paid.ToString("0.##") },
                    { "note", note.Text.Trim() },
                    { "allow_branch_id", branch },
                    { "isForceEdit", (isForceEdit ? "1" : "0")}
                };

                if (member_ext_id != String.Empty) values.Add("member_ext_id", member_ext_id);

                GF.showLoading(this);
                Dictionary<String, Object> result = DB.Post("Member/manageMemberExt/", values);

                if (result == null)
                {
                    GF.Error("เกิดความผิดพลาด !!");
                    GF.closeLoading();
                    this.Select();
                    return;
                }
                else if (result["result"].ToString() == "ERROR")
                {
                    GF.Error(result["error"].ToString());
                    GF.closeLoading();
                    this.Select();
                    return;
                }

                if(this.Owner.Name == "history_buy_member")
                    (this.Owner as history_buy_member).getData();
                else
                    (this.Owner as member).getData();

                disableAll();
                GF.closeLoading();

                if (isForceEdit)
                    this.Close();
                else
                {
                    member_ext_id = result["member_ext_id"].ToString();

                    GF.disableBtn(add_deposit_btn);
                    deposit_DGV.Enabled = false;

                    GF.disableBtn(add_full_btn);
                    full_DGV.Enabled = false;

                    print_btn.Left = branch_gb.Right - print_btn.Width;
                    print((is_already_paid == "1"));
                }
            }

            if (onlySee && changeData && !isForceEdit && member_ext_id != String.Empty) // CHANGE BRANCH
            {
                values = new Dictionary<string, string>
                {
                    { "member_ext_id", member_ext_id },
                    { "allow_branch_id", branch }
                };

                GF.showLoading(this);
                Dictionary<String, Object> result = DB.Post("Member/MemberExtChangeBranch/", values);

                if (result == null)
                {
                    GF.Error("เกิดความผิดพลาด !!");
                    GF.closeLoading();
                    this.Select();
                    return;
                }
                else if (result["result"].ToString() == "ERROR")
                {
                    GF.Error(result["error"].ToString());
                    GF.closeLoading();
                    this.Select();
                    return;
                }

                (this.Owner as history_buy_member).getData();

                this.Close();
            }
        }

        private void start_date_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                if (GF.validateDateTime(start_date))
                    getEndDate();
        }

        private void start_date_Leave(object sender, EventArgs e)
        {
            if (GF.validateDateTime(start_date))
                getEndDate();
        }

        private void expiry_date_KeyUp(object sender, KeyEventArgs e)
        {
            if (expiry_date.Enabled)
                if (e.KeyCode == Keys.Enter)
                    if (!GF.validateDateTime(expiry_date))
                        expiry_date.Select();
        }

        private void expiry_date_Leave(object sender, EventArgs e)
        {
            if (expiry_date.Enabled)
                if (!GF.validateDateTime(expiry_date))
                    expiry_date.Select();
        }

        void getTotalDeposit()
        {
            int totalDeposit = 0;
            foreach (DataGridViewRow DGVR in deposit_DGV.Rows)
            {
                totalDeposit += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["deposit_amount"].Value.ToString()));
            }
            total_deposit_txt.Text = GF.formatNumber(totalDeposit) + " บาท.";
        }

        void getTotalFullPayment()
        {
            int totalFullPayment = 0;
            foreach (DataGridViewRow DGVR in full_DGV.Rows)
            {
                totalFullPayment += Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells["full_payment_amount"].Value.ToString()));
            }
            total_full_txt.Text = GF.formatNumber(totalFullPayment) + " บาท.";
        }

        private void deposit_DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            getTotalDeposit();
        }

        private void deposit_DGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            getTotalDeposit();
        }

        private void full_DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            getTotalFullPayment();
        }

        private void full_DGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            getTotalFullPayment();
        }

        private void discount_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void discount_amount_Leave(object sender, EventArgs e)
        {
            if (discount_amount.Text.Trim() == String.Empty)
                discount_amount.Text = "0";
        }

        private void discount_amount_TextChanged(object sender, EventArgs e)
        {
            if (full_amount.Text.Trim() != "-")
            {
                if (discount_amount.Text.Trim() != String.Empty)
                {
                    if (Convert.ToInt32(discount_amount.Text.Trim()) > Convert.ToInt32(GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0])))
                        discount_amount.Text = GF.removeCommaDotFromNumber(full_amount.Text.Trim().Split(' ')[0]);
                }
            }
        }

        private void discount_cb_CheckedChanged(object sender, EventArgs e)
        {
            Boolean flag = discount_cb.Checked;
            discount_amount.Enabled = flag;
            discount_by.Enabled = flag;
            discount_note.Enabled = flag;

            discount_amount.Text = "0";
            discount_by.SelectedIndex = 0;
            discount_note.Text = "";
        }

        void disableAll()
        {
            print_btn.Visible = true;
            manage_btn.Visible = false;

            member_type.Enabled = false;
            contract_no.Enabled = false;
            start_date.Enabled = false;
            expiry_date.Enabled = false;
            seller_emp_id.Enabled = false;

            discount_cb.Enabled = false;
            discount_amount.Enabled = false;
            discount_by.Enabled = false;
            discount_note.Enabled = false;

            note.Enabled = false;

            GF.disableBtn(add_deposit_btn);
            deposit_DGV.Enabled = false;

            GF.disableBtn(add_full_btn);
            full_DGV.Enabled = false;
        }

        void print(Boolean isDeposit)
        {
            Boolean needVat = false;
            if (!isDeposit && MessageBox.Show("ลูกค้าต้องการบิล Vat หรือไม่ ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                needVat = true;

            print_member_ext.initPrint(this, member_ext_id, needVat);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if(GF.hasReceiptPrinter())
                print((is_already_paid == "1"));
        }
    }
}
