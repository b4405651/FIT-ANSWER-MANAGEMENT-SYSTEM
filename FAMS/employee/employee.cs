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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("emp_code", "รหัส"));
            DGVC.Add(new dgvColumn("fullname", "ชื่อ - สกุล", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("nickname", "ชื่อเล่น"));
            DGVC.Add(new dgvColumn("branch", "สังกัดสาขา", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("is_trainer", "PT"));
            DGVC.Add(new dgvColumn("can_get_commission", "คอมฯ"));
            DGVC.Add(new dgvColumn("suspend", "วันที่พักงาน/ลาออก", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("emp_id", "emp_id", DataGridViewContentAlignment.BottomCenter, false));
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
                            btn_dgv.theContextMenu.MenuItems.Add("พิมพ์บัตรพนักงาน", new EventHandler(PrintEvent));
                            if ((btn_dgv.DGV.SelectedRows[0].Cells["suspend"].Value ?? "").ToString() == String.Empty)
                                btn_dgv.theContextMenu.MenuItems.Add("พักงาน / ลาออก", new EventHandler(DisableEvent));
                            else
                                btn_dgv.theContextMenu.MenuItems.Add("ยกเลิก พักงาน / ลาออก", new EventHandler(EnableEvent));
                        }
                    }
                }
            };
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            using (employee_manage employeeManage = new employee_manage())
            {
                employeeManage.Owner = this;
                employeeManage.ShowDialog();
                this.BringToFront();
            }
        }

        void EditEvent(object sender, EventArgs e)
        {
            using (employee_manage employeeManage = new employee_manage())
            {
                employeeManage.emp_id = btn_dgv.DGV.SelectedRows[0].Cells["emp_id"].Value.ToString();
                employeeManage.Owner = this;
                employeeManage.ShowDialog();
                this.BringToFront();
            }
        }

        void PrintEvent(object sender, EventArgs e)
        {
            print_staff_card.initPrint(this, btn_dgv.DGV.SelectedRows[0].Cells["emp_id"].Value.ToString());
        }

        void DisableEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "emp_id", btn_dgv.DGV.SelectedRows[0].Cells["emp_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Employee/Suspend/", values);

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
                { "emp_id", btn_dgv.DGV.SelectedRows[0].Cells["emp_id"].Value.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Employee/Enable/", values);

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
                { "user_id", GF.userID },
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "branch_id", GF.Settings("branch_id") }
            };

            if (search_txt.Text.Trim() != String.Empty) values.Add("search_txt", search_txt.Text.Trim());
            if (is_trainer.Checked) values.Add("is_trainer", "1");
            if (can_get_commission.Checked) values.Add("can_get_commission", "1");
            if (is_suspend.Checked) values.Add("is_suspend", "1");

            Dictionary<String, Object> Obj = DB.Post("Employee/EmployeeList/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        Item["emp_code"].ToString(),
                        Item["fullname"].ToString(),
                        Item["nickname"].ToString(),
                        Item["branch_name"].ToString(),
                        "",
                        "",
                        GF.formatDBDateTime((Item["suspend_since"] ?? "").ToString()),
                        Item["emp_id"].ToString()
                    );
                    if (Item["is_trainer"].ToString() == "1")
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_trainer"].Value = "YES";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_trainer"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_trainer"].Value = "NO";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["is_trainer"].Style.ForeColor = Color.Red;
                    }

                    if (Item["can_get_commission"].ToString() == "1")
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_get_commission"].Value = "YES";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_get_commission"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_get_commission"].Value = "NO";
                        btn_dgv.DGV.Rows[btn_dgv.DGV.Rows.Count - 1].Cells["can_get_commission"].Style.ForeColor = Color.Red;
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
