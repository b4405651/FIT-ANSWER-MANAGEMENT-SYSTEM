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
    public partial class history_card_no : Form
    {
        String _member_id = "";
        public history_card_no(String member_id)
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
            DGVC.Add(new dgvColumn("change_datetime", "วันที่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("member_no", "เปลี่ยน เลขที่สมาชิก เป็น", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("note", "บันทึกเพิ่มเติม", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("change_by", "เปลี่ยนแปลงโดย", DataGridViewContentAlignment.MiddleLeft));
            btn_dgv.initColumn(DGVC);

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            GF.closeLoading();
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

            Dictionary<String, Object> Obj = DB.Post("Member/getHistoryCardNo/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        GF.formatDBDateTime(Item["change_datetime"].ToString()),
                        Item["card_no"].ToString(),
                        (Item["note"] ?? "").ToString(),
                        Item["change_by"].ToString()
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

