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
    public partial class trainer_job_list : Form
    {
        public trainer_job_list()
        {
            InitializeComponent();

            GF.showLoading(this);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "branch_id", GF.Settings("branch_id") }
            };

            Dictionary<String, Object> Obj = DB.Post("Employee/getTrainer/", values);

            if (Obj != null)
            {
                trainer_emp_id.Items.Add(new ComboItem(0, "ทุกคน"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    trainer_emp_id.Items.Add(new ComboItem(GF.toInt(Item["trainer_emp_id"].ToString()), Item["trainer_name"].ToString()));
                }

                trainer_emp_id.SelectedIndex = 0;
                GF.resizeComboBox(trainer_emp_id);
            }

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("datetime", "วันที่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("during", "ระหว่างเวลา"));
            DGVC.Add(new dgvColumn("detail", "รายละเอียด", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("trainer_name", "เทรนเนอร์", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("confirm_by", "ยืนยันว่าเกิดขึ้นจริง โดย"));
            DGVC.Add(new dgvColumn("confirm_datetime", "วันเวลา ที่ยืนยันว่าเกิดขึ้นจริง"));
            DGVC.Add(new dgvColumn("create_by", "สร้าง โดย"));
            DGVC.Add(new dgvColumn("create_datetime", "สร้าง เมื่อ"));
            DGVC.Add(new dgvColumn("last_modified_by", "ปรับปรุงล่าสุด โดย"));
            DGVC.Add(new dgvColumn("last_modified_datetime", "ปรับปรุงล่าสุด เมื่อ"));
            DGVC.Add(new dgvColumn("trainer_job_id", "trainer_job_id", DataGridViewContentAlignment.MiddleLeft, false));
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
                            if ((btn_dgv.DGV.SelectedRows[0].Cells["confirm_by"].Value ?? "").ToString() == String.Empty)
                                btn_dgv.theContextMenu.MenuItems.Add("ยืนยันว่าเกิดขึ้นจริง", new EventHandler(ConfirmEvent));
                        }
                    }
                }
            };

            GF.closeLoading();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.CenterToScreen();
        }

        void EditEvent(object sender, EventArgs e)
        {
            using (trainer_job_manage jobManage = new trainer_job_manage())
            {
                jobManage.trainer_job_id = btn_dgv.DGV.SelectedRows[0].Cells["trainer_job_id"].Value.ToString();
                jobManage.isReadOnly = !((btn_dgv.DGV.SelectedRows[0].Cells["confirm_by"].Value ?? "").ToString() == String.Empty);
                jobManage.Owner = this;
                jobManage.ShowDialog();
            }
        }

        void ConfirmEvent(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "trainer_job_id", btn_dgv.DGV.SelectedRows[0].Cells["trainer_job_id"].Value.ToString() },
                { "confirm_by", GF.userID }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("TrainerJob/Confirm/", values);

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
            if (trainer_emp_id.Items.Count == 0) return;
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "branch_id", GF.Settings("branch_id") }
            };

            if (since.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim().Count() > 0)
                values.Add("since", since.Text.Trim());
            if (until.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim().Count() > 0)
                values.Add("until", until.Text.Trim());
            if (((ComboItem)trainer_emp_id.SelectedItem).Key > 0)
                values.Add("trainer_emp_id", ((ComboItem)trainer_emp_id.SelectedItem).Key.ToString());
            if (search_txt.Text.Trim() != String.Empty)
                values.Add("search_txt", search_txt.Text.Trim());

            Dictionary<String, Object> Obj = DB.Post("TrainerJob/getTrainerJob/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        Item["job_date"].ToString(),
                        Item["during"].ToString(),
                        Item["detail"].ToString(),
                        Item["trainer_name"].ToString(),
                        (Item["confirm_by"] ?? "").ToString(),
                        GF.formatDBDateTime((Item["confirm_datetime"] ?? "").ToString()),
                        (Item["create_by"] ?? "").ToString(),
                        GF.formatDBDateTime((Item["create_datetime"] ?? "").ToString()),
                        (Item["last_modified_by"] ?? "").ToString(),
                        GF.formatDBDateTime((Item["last_modified_datetime"] ?? "").ToString()),
                        Item["trainer_job_id"].ToString()
                    );
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

        private void add_btn_Click(object sender, EventArgs e)
        {
            using (trainer_job_manage trainerJobManage = new trainer_job_manage())
            {
                trainerJobManage.Owner = this;
                trainerJobManage.ShowDialog();
            }
        }

        private void search_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getData();
        }
    }
}
