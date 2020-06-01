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
    public partial class branch : Form
    {
        public branch()
        {
            InitializeComponent();

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("branch_name", "ชื่อสาขา", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("prefix", "ตัวย่อ"));
            DGVC.Add(new dgvColumn("suspend_since", "ปิดการใช้ตั้งแต่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("branch_id", "branch_id", DataGridViewContentAlignment.BottomCenter, false));
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
                            btn_dgv.theContextMenu.MenuItems.Add("ดูตัวอย่างหัวบิล", new EventHandler(PrintEvent));
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
            using (branch_manage branchManage = new branch_manage())
            {
                branchManage.branch_id = btn_dgv.DGV.SelectedRows[0].Cells["branch_id"].Value.ToString();
                branchManage.Owner = this;
                branchManage.ShowDialog();
            }
        }

        void PrintEvent(object sender, EventArgs e)
        {
            preview_bill_header.initPrint(this, btn_dgv.DGV.SelectedRows[0].Cells["branch_id"].Value.ToString());
        }

        void DisableEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "branch_id", btn_dgv.DGV.SelectedRows[0].Cells["branch_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Branch/Suspend/", values);

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
                { "branch_id", btn_dgv.DGV.SelectedRows[0].Cells["branch_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Branch/Enable/", values);

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
                { "user_id", GF.userID },
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "is_suspend", (is_suspend.Checked ? "1" : "0") }
            };

            if (search_txt.Text.Trim() != String.Empty) values.Add("search_txt", search_txt.Text.Trim());

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        Item["branch_name"].ToString(),
                        Item["prefix"].ToString(),
                        GF.formatDBDateTime((Item["suspend_since"] ?? "").ToString()),
                        Item["branch_id"].ToString()
                    );
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            using (branch_manage branchManage = new branch_manage())
            {
                branchManage.Owner = this;
                branchManage.ShowDialog();
            }
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getData();
        }
    }
}
