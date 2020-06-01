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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("username", "ชื่อบัญชีผู้ใช้", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("owner_name", "ชื่อเจ้าของบัญชี", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("is_admin", "เป็นผู้ดูแล"));
            DGVC.Add(new dgvColumn("can_approve", "สามารถอนุมัติ"));
            DGVC.Add(new dgvColumn("can_use_web", "สามารถใช้ web report"));
            DGVC.Add(new dgvColumn("create_datetime", "สร้างเมื่อ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("last_modified_datetime", "ปรับปรุงล่าสุดเมื่อ", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("last_modified_by", "ปรับปรุงล่าสุดโดย", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("last_login", "เข้าระบบล่าสุด", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("suspend_since", "วันที่ระงับการใช้", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("user_id", "user_id", DataGridViewContentAlignment.BottomCenter, false));
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
                                btn_dgv.theContextMenu.MenuItems.Add("ระงับการใช้งาน", new EventHandler(DisableEvent));
                            else
                                btn_dgv.theContextMenu.MenuItems.Add("ยกเลิก ระงับการใช้งาน", new EventHandler(EnableEvent));
                        }
                    }
                }
            };
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            using (user_manage userManage = new user_manage())
            {
                userManage.Owner = this;
                userManage.ShowDialog();
                this.BringToFront();
            }
        }

        void EditEvent(object sender, EventArgs e)
        {
            using (user_manage userManage = new user_manage())
            {
                userManage.user_id = btn_dgv.DGV.SelectedRows[0].Cells["user_id"].Value.ToString();
                userManage.Owner = this;
                userManage.ShowDialog();
                this.BringToFront();
            }
        }

        void DisableEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "user_id", btn_dgv.DGV.SelectedRows[0].Cells["user_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("User/Suspend/", values);

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
                { "user_id", btn_dgv.DGV.SelectedRows[0].Cells["user_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("User/Enable/", values);

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
            GF.showLoading(this);

            getData();
        }

        public void getData()
        {
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "branch_id", GF.Settings("branch_id") }
            };

            if (search_txt.Text.Trim() != String.Empty) values.Add("search_txt", search_txt.Text.Trim());
            if (is_suspend.Checked) values.Add("is_suspend", "0");

            Dictionary<String, Object> Obj = DB.Post("User/UserList/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        Item["username"].ToString(),
                        Item["owner_name"].ToString(),
                        "",
                        "",
                        "",
                        GF.formatDBDateTime((Item["created_datetime"] ?? "").ToString()),
                        GF.formatDBDateTime((Item["last_modified_datetime"] ?? "").ToString()),
                        Item["last_modified_by"].ToString(),
                        GF.formatDBDateTime((Item["last_login"] ?? "").ToString()),
                        GF.formatDBDateTime((Item["suspend_since"] ?? "").ToString()),
                        Item["user_id"].ToString()
                    );
                    if (Item["is_admin"].ToString() == "1")
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_admin"].Value = "YES";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_admin"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_admin"].Value = "NO";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_admin"].Style.ForeColor = Color.Red;
                    }

                    if (Item["can_approve"].ToString() == "1")
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_approve"].Value = "YES";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_approve"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_approve"].Value = "NO";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_approve"].Style.ForeColor = Color.Red;
                    }

                    if (Item["can_use_web"].ToString() == "1")
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_use_web"].Value = "YES";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_use_web"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_use_web"].Value = "NO";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_use_web"].Style.ForeColor = Color.Red;
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
    }
}
