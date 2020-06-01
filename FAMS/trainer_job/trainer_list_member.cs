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
    public partial class trainer_list_member : Form
    {
        public trainer_list_member()
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
                trainer_emp_id.Items.Add(new ComboItem(0, "เลือก เทรนเนอร์"));
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
            DGVC.Add(new dgvColumn("member_no", "รหัสสมาชิก", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("member_name", "สมาชิก", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("pt_course_name", "คอร์ส", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("hours", "คงเหลือ", DataGridViewContentAlignment.MiddleCenter));
            DGVC.Add(new dgvColumn("expiry_date", "วันหมดอายุ", DataGridViewContentAlignment.MiddleCenter));
            DGVC.Add(new dgvColumn("seller", "ผู้ขาย", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("process_date", "วันที่ซื้อ", DataGridViewContentAlignment.MiddleCenter));
            DGVC.Add(new dgvColumn("member_pt_id", "member_pt_id", DataGridViewContentAlignment.MiddleLeft, false));
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
                            btn_dgv.theContextMenu.MenuItems.Add("เปลี่ยนเทรนเนอร์", new EventHandler(ChangeTrainerEvent));
                        }
                    }
                }
            };

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

        public void doLoadGridData(object sender, EventArgs e)
        {
            if (btn_dgv.DGV.Columns.Count == 0) return;
            getData();
        }

        public void getData()
        {
            if (trainer_emp_id.Items.Count == 0) return;
            if (((ComboItem)trainer_emp_id.SelectedItem).Key == 0)
            {
                btn_dgv.DGV.Rows.Clear();
                btn_dgv.resetBtnDGV("0");
                return;
            }
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "branch_id", GF.Settings("branch_id") },
                { "trainer_emp_id", ((ComboItem)trainer_emp_id.SelectedItem).Key.ToString()}
            };

            if (show_expired_or_empty.Checked)
                values.Add("show_expired_or_empty", "1");

            Dictionary<String, Object> Obj = DB.Post("TrainerJob/listMember/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    String fullname = Item["firstname_th"].ToString() + " " + Item["lastname_th"].ToString();
                    if ((Item["nickname_th"] ?? "").ToString() != String.Empty) fullname += " (" + Item["nickname_th"].ToString() + ")";

                    btn_dgv.DGV.Rows.Add(
                        Item["member_no"].ToString(),
                        fullname,
                        Item["pt_course_name"].ToString(),
                        Item["hours"].ToString(),
                        Item["expiry_date"].ToString(),
                        Item["seller"].ToString(),
                        GF.formatDBDateTime((Item["datetime"] ?? "").ToString()),
                        Item["member_pt_id"].ToString()
                    );
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();
            this.BringToFront();
        }

        private void show_expired_or_empty_CheckedChanged(object sender, EventArgs e)
        {
            getData();
        }
    }
}
