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
    public partial class member_drop : Form
    {
        public String member_id = "";
        public member_drop()
        {
            InitializeComponent();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (drop_start.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ดรอปตั้งแต่วันที่' !!");
                drop_start.Select();
                return;
            }

            if (drop_start.Text.Trim().Length < 10)
            {
                GF.Error("กรุณากรอก 'ดรอปตั้งแต่วันที่' ให้ครบ !!\r\n\r\n(หาก วัน หรือ เดือน เป็นเลขตัวเดียว ให้เติม 0 ข้างหน้า)");
                drop_start.Select();
                return;
            }

            if (day_amount.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้กรอก 'จำนวนวัน' !!");
                day_amount.Select();
                return;
            }

            if (drop_note.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้กรอก 'สาเหตุการดรอป' !!");
                drop_note.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "member_id", member_id },
                { "drop_start", drop_start.Text.Trim() },
                { "drop_end", drop_end.Text.Trim() },
                { "drop_day_amount", day_amount.Text.Trim() },
                { "drop_note", drop_note.Text.Trim() },
                { "branch_id", GF.Settings("branch_id") },
                { "drop_by", GF.userID }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/Drop/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            (this.Owner as member).getData();

            GF.closeLoading();
            this.Close();
        }

        private void drop_start_Leave(object sender, EventArgs e)
        {
            GF.validateDateTime(drop_start);
        }

        private void day_amount_Leave(object sender, EventArgs e)
        {
            getEndDate();
        }

        private void day_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void drop_start_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getEndDate();
        }

        private void day_amount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getEndDate();
        }

        void getEndDate()
        {
            if (GF.validateDateTime(drop_start) && day_amount.Text.Trim() != String.Empty && Convert.ToInt32(day_amount.Text.Trim()) >= 0)
            {
                String[] tmpDate = drop_start.Text.Split('/');
                DateTime DateStart = new DateTime(Convert.ToInt32(tmpDate[2]) - 543, Convert.ToInt32(tmpDate[1]), Convert.ToInt32(tmpDate[0]));
                DateTime DateEnd = DateStart.AddDays(Convert.ToInt32(day_amount.Text.Trim()));
                drop_end.Text = DateEnd.Day.ToString("00") + "/" + DateEnd.Month.ToString("00") + "/" + (DateEnd.Year + 543).ToString("0000");
            }
        }
    }
}
