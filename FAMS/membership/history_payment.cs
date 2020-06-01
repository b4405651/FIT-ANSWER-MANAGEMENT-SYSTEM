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
    public partial class history_payment : Form
    {
        String _member_id = "";
        public history_payment(String member_id)
        {
            InitializeComponent();

            _member_id = member_id;

            GF.showLoading(this);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                branch_id.Items.Add(new ComboItem(0, "ทุกสาขา"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    branch_id.Items.Add(new ComboItem(GF.toInt(Item["branch_id"].ToString()), Item["branch_name"].ToString() + " (" + Item["prefix"].ToString() + ")"));
                }

                branch_id.SelectedIndex = 0;
                GF.resizeComboBox(branch_id);
            }
            else
            {
                GF.closeLoading();
                GF.Error("ไม่มีข้อมูล 'สาขา' ในฐานข้อมูล !!\r\n\r\nกรุณาติดต่อผู้ดูแลระบบ !!");
            }

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("datetime", "วันที่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("detail", "รายละเอียด", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("branch_name", "สาขา"));
            DGVC.Add(new dgvColumn("cash", "เงินสด"));
            DGVC.Add(new dgvColumn("card", "บัตร"));
            DGVC.Add(new dgvColumn("card_no", "บัตรหมายเลข"));
            DGVC.Add(new dgvColumn("card_expiry_date", "วันหมดอายุบัตร"));
            DGVC.Add(new dgvColumn("by", "ผู้รับเงิน"));
            btn_dgv.initColumn(DGVC);

            GF.closeLoading();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.CenterToScreen();
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            if (btn_dgv.DGV.Columns.Count == 0) return;
            getData();
        }

        void getData()
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
            if (((ComboItem)branch_id.SelectedItem).Key > 0)
                values.Add("branch_id", ((ComboItem)branch_id.SelectedItem).Key.ToString());

            Dictionary<String, Object> Obj = DB.Post("Member/getHistoryPayment/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        GF.formatDBDateTime((Item["datetime"] ?? "").ToString()),
                        Item["detail"].ToString(),
                        Item["branch_name"].ToString(),
                        (Item["cash_amount"] ?? "").ToString(),
                        (Item["card_amount"] ?? "").ToString(),
                        (Item["card_no"] ?? "").ToString(),
                        (Item["card_expiry_date"] ?? "").ToString(),
                        Item["process_by"].ToString()
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
    }
}
