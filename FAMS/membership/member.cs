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
    public partial class member : Form
    {
        public member()
        {
            InitializeComponent();

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            gender.SelectedIndex = 0;
            filter.SelectedIndex = 0;

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                foreach (Dictionary<String, Object> Branch in (Array)Obj["result"])
                {
                    branch_id.Items.Add(new ComboItem(Convert.ToInt32(Branch["branch_id"].ToString()), Branch["branch_name"].ToString()));
                }
                GF.resizeComboBox(branch_id);
                int selectedIndex = 0;

                foreach (var cb in branch_id.Items)
                {
                    if ((cb as ComboItem).Key.ToString() == GF.Settings("branch_id"))
                    {
                        branch_id.SelectedIndex = selectedIndex;
                        break;
                    }
                    selectedIndex++;
                }
            }

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("member_no", "รหัสสมาชิก"));
            DGVC.Add(new dgvColumn("card_no", "เลขบัตรสมาชิก"));
            DGVC.Add(new dgvColumn("fullname", "ชื่อ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("gender", "เพศ"));
            DGVC.Add(new dgvColumn("start_date", "บันทึกข้อมูลเมื่อ"));
            DGVC.Add(new dgvColumn("member_type", "ประเภทสมาชิก"));
            DGVC.Add(new dgvColumn("contract_no", "หมายเลขสัญญา"));
            DGVC.Add(new dgvColumn("during_date", "ระหว่างวันที่"));
            DGVC.Add(new dgvColumn("birthday", "วันเกิด"));
            DGVC.Add(new dgvColumn("age", "อายุ"));
            DGVC.Add(new dgvColumn("tel", "โทรศัพท์"));
            DGVC.Add(new dgvColumn("drop_during", "ใช้สิทธิ์ดรอประหว่างวันที่"));
            DGVC.Add(new dgvColumn("is_drop_active", "is_drop_active", DataGridViewContentAlignment.BottomCenter, false));
            DGVC.Add(new dgvColumn("suspend_since", "ระงับใช้เมื่อ"));
            DGVC.Add(new dgvColumn("suspend_reason", "สาเหตุ"));
            DGVC.Add(new dgvColumn("suspend_by", "ระงับโดย"));
            DGVC.Add(new dgvColumn("member_id", "member_id", DataGridViewContentAlignment.BottomCenter, false));
            DGVC.Add(new dgvColumn("member_drop_id", "member_drop_id", DataGridViewContentAlignment.BottomCenter, false));
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
                            btn_dgv.theContextMenu.MenuItems.Add("-");
                            btn_dgv.theContextMenu.MenuItems.Add("ซื้อ MEMBER", new EventHandler(BuyMemberEvent));

                            if ((btn_dgv.DGV.SelectedRows[0].Cells["member_no"].Value ?? "").ToString() != String.Empty)
                                if ((btn_dgv.DGV.SelectedRows[0].Cells["member_type"].Value ?? "").ToString() != String.Empty)
                                {
                                    btn_dgv.theContextMenu.MenuItems.Add("ซื้อ PT", new EventHandler(BuyPTEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("-");
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการซื้อ Member", new EventHandler(BuyMemberHistoryEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการซื้อ PT", new EventHandler(BuyPTHistoryEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("-");
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการเข้าใช้", new EventHandler(CheckInHistoryEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการชำระเงิน", new EventHandler(PaymentHistoryEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการใช้ PT", new EventHandler(PTUsageHistoryEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการดรอป", new EventHandler(DropHistoryEvent));

                                    if ((btn_dgv.DGV.SelectedRows[0].Cells["member_type"].Value ?? "").ToString() != "หมดอายุแล้ว" && (btn_dgv.DGV.SelectedRows[0].Cells["member_type"].Value ?? "").ToString() != "ยังไม่ถึงวันเริ่มต้น")
                                    {
                                        if ((btn_dgv.DGV.SelectedRows[0].Cells["drop_during"].Value ?? "").ToString() == String.Empty || (btn_dgv.DGV.SelectedRows[0].Cells["is_drop_active"].Value ?? "").ToString() == "NO")
                                        {
                                            btn_dgv.theContextMenu.MenuItems.Add("-");
                                            btn_dgv.theContextMenu.MenuItems.Add("ดรอป", new EventHandler(DropEvent));
                                        }
                                        else if (btn_dgv.DGV.SelectedRows[0].Cells["is_drop_active"].Value.ToString() == "YES")
                                        {
                                            btn_dgv.theContextMenu.MenuItems.Add("-");
                                            btn_dgv.theContextMenu.MenuItems.Add("ยกเลิกดรอป", new EventHandler(CancelDropEvent));
                                        }
                                    }

                                    btn_dgv.theContextMenu.MenuItems.Add("-");
                                    btn_dgv.theContextMenu.MenuItems.Add("บันทึก / เปลี่ยนแปลง บัตรสมาชิก", new EventHandler(CardNoEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติ การเปลี่ยนแปลง บัตรสมาชิก", new EventHandler(CardNoHistoryEvent));

                                    btn_dgv.theContextMenu.MenuItems.Add("-");
                                    if ((btn_dgv.DGV.SelectedRows[0].Cells["suspend_since"].Value ?? "").ToString() == String.Empty)
                                        btn_dgv.theContextMenu.MenuItems.Add("ระงับการใช้งาน", new EventHandler(SuspendEvent));
                                    else
                                        btn_dgv.theContextMenu.MenuItems.Add("ยกเลิก การระงับการใช้งาน", new EventHandler(CancelSuspendEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("ประวัติการระงับการใช้", new EventHandler(SuspendHistoryEvent));
                                }
                        }
                    }
                }
            };
        }

        void CardNoEvent(object sender, EventArgs e)
        {
            using (member_card_no cardNo = new member_card_no())
            {
                cardNo.member_id = btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString();
                cardNo.Owner = this;
                cardNo.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void CardNoHistoryEvent(object sender, EventArgs e)
        {
            using (history_card_no CardNoHistory = new history_card_no(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                CardNoHistory.Owner = this;
                CardNoHistory.ShowDialog();
            }

            this.BringToFront();
            this.Activate();
        }

        void EditEvent(object sender, EventArgs e)
        {
            using(member_manage memberManage = new member_manage())
            {
                memberManage.member_id = btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString();
                memberManage.Owner = this;
                memberManage.ShowDialog();
            }
            this.BringToFront();
        }

        void BuyMemberEvent(object sender, EventArgs e)
        {
            using (member_ext memberExt = new member_ext())
            {
                memberExt.member_id = btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString();
                memberExt.Owner = this;
                memberExt.ShowDialog();
            }
            this.BringToFront();
        }

        void BuyPTEvent(object sender, EventArgs e)
        {
            using (member_pt memberPT = new member_pt())
            {
                memberPT.member_id = btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString();
                memberPT.Owner = this;
                memberPT.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void CheckInHistoryEvent(object sender, EventArgs e)
        {
            using (history_checkin historyCheckIn = new history_checkin(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                historyCheckIn.Owner = this;
                historyCheckIn.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void PaymentHistoryEvent(object sender, EventArgs e)
        {
            using (history_payment historyPayment = new history_payment(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                historyPayment.Owner = this;
                historyPayment.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void PTUsageHistoryEvent(object sender, EventArgs e)
        {
            using (history_pt_usage historyPTUsage = new history_pt_usage(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                historyPTUsage.Owner = this;
                historyPTUsage.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void BuyMemberHistoryEvent(object sender, EventArgs e)
        {
            using (history_buy_member buyMemberHistory = new history_buy_member(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                buyMemberHistory.Owner = this;
                buyMemberHistory.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void BuyPTHistoryEvent(object sender, EventArgs e)
        {
            using (history_buy_pt buyMemberPT = new history_buy_pt(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                buyMemberPT.Owner = this;
                buyMemberPT.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void DropHistoryEvent(object sender, EventArgs e)
        {
            using (history_drop DropHistory = new history_drop(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                DropHistory.Owner = this;
                DropHistory.ShowDialog();
            }

            this.BringToFront();
            this.Activate();
        }

        void DropEvent(object sender, EventArgs e)
        {
            using (member_drop memberDrop = new member_drop())
            {
                memberDrop.member_id = btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString();
                memberDrop.Owner = this;
                memberDrop.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void CancelDropEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "member_id", btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString() },
                { "member_drop_id", btn_dgv.DGV.SelectedRows[0].Cells["member_drop_id"].Value.ToString() },
                { "cancelled_by", GF.userID }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/CancelDrop/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            getData();

            this.BringToFront();
            this.Activate();
        }

        void SuspendHistoryEvent(object sender, EventArgs e)
        {
            using (history_suspend SuspendHistory = new history_suspend(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                SuspendHistory.Owner = this;
                SuspendHistory.ShowDialog();
            }

            this.BringToFront();
            this.Activate();
        }

        void SuspendEvent(object sender, EventArgs e)
        {
            using (member_suspend Suspend = new member_suspend(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                Suspend.Owner = this;
                Suspend.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }
        void CancelSuspendEvent(object sender, EventArgs e)
        {
            using (member_suspend_cancel Suspend = new member_suspend_cancel(btn_dgv.DGV.SelectedRows[0].Cells["member_id"].Value.ToString()))
            {
                Suspend.Owner = this;
                Suspend.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            getData();

            this.BringToFront();
            this.Activate();
        }

        public void getData()
        {
            if (btn_dgv.DGV.Columns.Count == 0 || branch_id.Items.Count == 0) { return; }
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID },
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "branch_id", (branch_id.SelectedItem as ComboItem).Key.ToString() }
            };

            if (search_txt.Text.Trim() != String.Empty) values.Add("search_txt", search_txt.Text.Trim());
            if (gender.Text.Trim() != "ทั้งหมด") values.Add("gender", gender.Text.Trim());
            if (filter.SelectedIndex > 0)
            {
                if (filter.Text == "ไม่มีรหัสสมาชิก")
                    values.Add("member_no", "");
                else if (filter.Text == "ยังไม่หมดอายุ")
                    values.Add("is_expired", "0");
                else if (filter.Text == "หมดอายุ")
                    values.Add("is_expired", "1");
                else if (filter.Text == "ยังไม่ถึงวันเริ่มต้น")
                    values.Add("not_start", "");
            }

            Dictionary<String, Object> Obj = DB.Post("Member/MemberList/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    String fullname = Item["firstname_th"].ToString() + " " + Item["lastname_th"].ToString();
                    if ((Item["nickname_th"] ?? "").ToString() != String.Empty && (Item["nickname_th"] ?? "").ToString() != "-") 
                        fullname += " (" + Item["nickname_th"].ToString() + ")";

                    btn_dgv.DGV.Rows.Add(
                        (Item["member_no"] ?? "").ToString(),
                        (Item["card_no"] ?? "").ToString(),
                        fullname,
                        Item["gender"].ToString(),
                        GF.formatDBDateTime((Item["create_date"] ?? "").ToString()),
                        (Item["current_member_type"] ?? "").ToString(),
                        (Item["contract_no"] ?? "").ToString(),
                        (Item["during_date"] ?? "").ToString(),
                        (Item["birthday"] ?? "").ToString(),
                        GF.calculateAge((Item["birthday"] ?? "").ToString()),
                        Item["mobile_phone"].ToString(),
                        (Item["drop_during"] ?? "").ToString(),
                        Item["is_drop_active"].ToString(),
                        GF.formatDBDateTime((Item["suspend_since"] ?? "").ToString()),
                        (Item["suspend_reason"] ?? "").ToString(),
                        (Item["suspend_by"] ?? "").ToString(),
                        Item["member_id"].ToString(),
                        (Item["member_drop_id"] ?? "").ToString()
                    );
                    
                    if (Item["is_drop_active"].ToString() == "YES" || (Item["suspend_since"] ?? "").ToString() != String.Empty)
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();

            this.BringToFront();
            this.Activate();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            using(member_manage memberManage = new member_manage())
            {
                memberManage.Owner = this;
                memberManage.ShowDialog();
            }

            this.BringToFront();
            this.Activate();
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getData();
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();

            this.BringToFront();
            this.Activate();
        }

        private void branch_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_dgv.page.Text = "1";
            getData();
        }
    }
}
