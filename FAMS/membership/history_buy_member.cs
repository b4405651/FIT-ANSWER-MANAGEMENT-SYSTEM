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
    public partial class history_buy_member : Form
    {
        String _member_id = "";
        public history_buy_member(String member_id)
        {
            InitializeComponent();

            _member_id = member_id;

            GF.showLoading(this);
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "is_suspend", "0" }
            };
            Dictionary<String, Object> Obj = DB.Post("MemberType/getMemberType/", values);

            if (Obj != null)
            {
                member_type_id.Items.Add(new ComboItem(0, "ทุกประเภท"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    member_type_id.Items.Add(new ComboItem(GF.toInt(Item["member_type_id"].ToString()), Item["member_type_name"].ToString()));
                }

                member_type_id.SelectedIndex = 0;
                GF.resizeComboBox(member_type_id);
            }
            else
            {
                GF.closeLoading();
                GF.Error("ไม่มีข้อมูล 'ประเภทสมาชิก' ในฐานข้อมูล !!\r\n\r\nกรุณาติดต่อผู้ดูแลระบบ !!");
            }

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("datetime", "วันที่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("member_type", "ประเภท Member", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("allow_branch", "สาขาที่ใช้ได้", DataGridViewContentAlignment.MiddleCenter));
            DGVC.Add(new dgvColumn("since", "เริ่มต้น"));
            DGVC.Add(new dgvColumn("until", "สิ้นสุด"));
            DGVC.Add(new dgvColumn("full_amount", "ราคาเต็ม"));
            DGVC.Add(new dgvColumn("discount_amount", "ส่วนลด"));
            DGVC.Add(new dgvColumn("discount_by", "อนุมัติส่วนลดโดย", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("discount_note", "รายละเอียดส่วนลด", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("void_by", "VOID โดย", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("void_datetime", "เมื่อ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("void_reason", "สาเหตุ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("member_ext_id", "member_ext_id", DataGridViewContentAlignment.MiddleLeft, false));
            DGVC.Add(new dgvColumn("is_import", "is_import", DataGridViewContentAlignment.MiddleLeft, false));
            btn_dgv.initColumn(DGVC);

            btn_dgv.DGV.CellDoubleClick += (ss, ee) =>
            {
                if (ee.RowIndex > -1 && ee.ColumnIndex > -1)
                {
                    using (member_ext ExtData = new member_ext())
                    {
                        ExtData.onlySee = true;
                        ExtData.member_ext_id = btn_dgv.DGV.Rows[ee.RowIndex].Cells["member_ext_id"].Value.ToString();
                        ExtData.manage_btn.Visible = false;
                        ExtData.print_btn.Left = ExtData.manage_btn.Right - ExtData.print_btn.Width;
                        ExtData.branch_list.Enabled = false;
                        ExtData.Owner = this;
                        ExtData.ShowDialog();
                    }
                    this.Select();
                }
            };

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
                            if (btn_dgv.DGV.Rows[btn_dgv.DGV.HitTest(ee.X, ee.Y).RowIndex].DefaultCellStyle.BackColor != Color.LightCoral)
                            {
                                btn_dgv.theContextMenu.MenuItems.Add("แก้ไข สาขาที่เข้าใช้ได้", new EventHandler(ChangeBranchEvent));
                                if (GF.isAdmin)
                                {
                                    btn_dgv.theContextMenu.MenuItems.Add("-");
                                    btn_dgv.theContextMenu.MenuItems.Add("แก้ไขข้อมูลการซื้อสมาชิก โดยผู้มีอำนาจ", new EventHandler(ForceEditEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("VOID รายการ โดยผู้มีอำนาจ", new EventHandler(VoidEvent));
                                }
                            }
                        }
                    }
                }
            };
            
            GF.closeLoading();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.CenterToScreen();
        }

        void ChangeBranchEvent(object sender, EventArgs e)
        {
            using (member_ext ExtData = new member_ext())
            {
                ExtData.isImport = (btn_dgv.DGV.SelectedRows[0].Cells["is_import"].Value.ToString() == "1" ? true : false);
                ExtData.onlySee = true;
                ExtData.changeData = true;
                ExtData.member_ext_id = btn_dgv.DGV.SelectedRows[0].Cells["member_ext_id"].Value.ToString();
                ExtData.print_btn.Left = ExtData.manage_btn.Right - ExtData.print_btn.Width;
                ExtData.Owner = this;
                ExtData.ShowDialog();
            }
            this.Select();
        }

        void ForceEditEvent(object sender, EventArgs e)
        {
            using (member_ext ExtData = new member_ext())
            {
                ExtData.isImport = (btn_dgv.DGV.SelectedRows[0].Cells["is_import"].Value.ToString() == "1" ? true : false);
                ExtData.onlySee = true;
                ExtData.changeData = true;
                ExtData.isForceEdit = true;
                ExtData.member_ext_id = btn_dgv.DGV.SelectedRows[0].Cells["member_ext_id"].Value.ToString();
                ExtData.print_btn.Left = ExtData.manage_btn.Right - ExtData.print_btn.Width;
                ExtData.Owner = this;
                ExtData.ShowDialog();
            }
            this.Select();
        }

        void VoidEvent(object sender, EventArgs e)
        {
            using (member_ext_void voidPage = new member_ext_void(btn_dgv.DGV.SelectedRows[0].Cells["member_ext_id"].Value.ToString()))
            {
                voidPage.Owner = this;
                voidPage.ShowDialog();
            }
            this.Select();
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
                { "member_id", _member_id }
            };

            if (since.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim().Count() > 0)
                values.Add("since", since.Text.Trim());
            if (until.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim().Count() > 0)
                values.Add("until", until.Text.Trim());
            if (((ComboItem)member_type_id.SelectedItem).Key > 0)
                values.Add("member_type_id", ((ComboItem)member_type_id.SelectedItem).Key.ToString());

            Dictionary<String, Object> Obj = DB.Post("Member/getHistoryBuyMember/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    String is_import = "0";
                    if (Item["is_paid"].ToString() == "1" && (Item["seller_emp_id"] ?? "").ToString() == "")
                        is_import = "1";

                    btn_dgv.DGV.Rows.Add(
                        GF.formatDBDateTime(Item["datetime"].ToString()),
                        Item["member_type_name"].ToString(),
                        (Item["allow_branch_id"] ?? "").ToString(),
                        Item["start_date"].ToString(),
                        Item["expiry_date"].ToString(),
                        GF.formatNumber(Item["full_amount"].ToString()),
                        GF.formatNumber((Item["discount_amount"] ?? "").ToString()),
                        (Item["discount_by"] ?? "").ToString(),
                        (Item["discount_note"] ?? "").ToString(),
                        (Item["void_by"] ?? "").ToString(),
                        GF.formatDBDateTime((Item["void_datetime"] ?? "").ToString()),
                        (Item["void_reason"] ?? "").ToString(),
                        Item["member_ext_id"].ToString(),
                        is_import
                    );

                    if (Item["is_void"].ToString() == "1")
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();
            this.BringToFront();
        }

        private void since_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GF.validateDateTime(since))
                    getData();
            }
        }

        private void since_Leave(object sender, EventArgs e)
        {
            GF.validateDateTime(since);
        }

        private void until_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GF.validateDateTime(until))
                    getData();
            }
        }

        private void until_Leave(object sender, EventArgs e)
        {
            GF.validateDateTime(until);
        }
    }
}
