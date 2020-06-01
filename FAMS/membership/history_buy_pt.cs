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
    public partial class history_buy_pt : Form
    {
        String _member_id = "";
        public history_buy_pt(String member_id)
        {
            InitializeComponent();

            _member_id = member_id;

            GF.showLoading(this);

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("datetime", "วันที่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("pt_course", "คอร์ส PT", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("trainer", "เทรนเนอร์", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("seller", "ผู้ขาย", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("hours", "คงเหลือ"));
            DGVC.Add(new dgvColumn("start_date", "วันเริ่มต้น"));
            DGVC.Add(new dgvColumn("expiry_date", "วันหมดอายุ"));
            DGVC.Add(new dgvColumn("void_by", "VOID โดย", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("void_datetime", "เมื่อ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("void_reason", "สาเหตุ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("member_pt_id", "member_pt_id", DataGridViewContentAlignment.MiddleLeft, false));
            btn_dgv.initColumn(DGVC);

            btn_dgv.DGV.CellContentDoubleClick += (ss, ee) =>
            {
                using (member_pt PtData = new member_pt())
                {
                    PtData.onlySee = true;
                    PtData.member_pt_id = btn_dgv.DGV.Rows[ee.RowIndex].Cells["member_pt_id"].Value.ToString();
                    PtData.Owner = this;
                    PtData.ShowDialog();
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
                                btn_dgv.theContextMenu.MenuItems.Add("เปลี่ยนเทรนเนอร์", new EventHandler(ChangeTrainerEvent));
                                if (GF.isAdmin)
                                {
                                    btn_dgv.theContextMenu.MenuItems.Add("-");
                                    btn_dgv.theContextMenu.MenuItems.Add("แก้ไขข้อมูลการซื้อ PT โดยผู้มีอำนาจ", new EventHandler(ForceEditEvent));
                                    btn_dgv.theContextMenu.MenuItems.Add("VOID รายการ โดยผู้มีอำนาจ", new EventHandler(VoidEvent));
                                }
                            }
                        }
                    }
                }
            };

            if (GF.isAdmin)
            {
                add_btn.Visible = true;
                add_btn.Click += (sss, eee) =>
                {
                    using (member_pt forceAddPT = new member_pt())
                    {
                        forceAddPT.member_id = member_id;
                        forceAddPT.isForceAdd = true;
                        forceAddPT.Owner = this;
                        forceAddPT.ShowDialog();
                    }
                    this.BringToFront();
                    this.Activate();
                };
            }

            GF.closeLoading();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.CenterToScreen();
        }

        void ChangeTrainerEvent(object sender, EventArgs e)
        {
            using (change_trainer changeTrainer = new change_trainer())
            {
                changeTrainer.member_pt_id = btn_dgv.DGV.SelectedRows[0].Cells["member_pt_id"].Value.ToString();
                changeTrainer.Owner = this;
                changeTrainer.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void ForceEditEvent(object sender, EventArgs e)
        {
            using (member_pt forceEditPT = new member_pt())
            {
                forceEditPT.member_pt_id = btn_dgv.DGV.SelectedRows[0].Cells["member_pt_id"].Value.ToString();
                forceEditPT.isForceEdit = true;
                forceEditPT.Owner = this;
                forceEditPT.ShowDialog();
            }
            this.BringToFront();
            this.Activate();
        }

        void VoidEvent(object sender, EventArgs e)
        {
            using (member_pt_void voidPage = new member_pt_void(btn_dgv.DGV.SelectedRows[0].Cells["member_pt_id"].Value.ToString()))
            {
                voidPage.Owner = this;
                voidPage.ShowDialog();
            }
            this.Select();
        }

        public void doLoadGridData(object sender, EventArgs e)
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

            Dictionary<String, Object> Obj = DB.Post("Member/getHistoryBuyPT/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        GF.formatDBDateTime(Item["datetime"].ToString()),
                        Item["pt_course_name"].ToString(),
                        Item["trainer"].ToString(),
                        Item["seller"].ToString(),
                        Item["hours"].ToString(),
                        (Item["start_date"] ?? "").ToString(),
                        Item["expiry_date"].ToString(),
                        (Item["void_by"] ?? "").ToString(),
                        GF.formatDBDateTime((Item["void_datetime"] ?? "").ToString()),
                        (Item["void_reason"] ?? "").ToString(),
                        Item["member_pt_id"].ToString()
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
