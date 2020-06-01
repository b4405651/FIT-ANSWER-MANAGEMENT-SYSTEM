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
    public partial class member_card_no : Form
    {
        public String member_id = String.Empty;
        public member_card_no()
        {
            InitializeComponent();
        }

        private void member_no_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (card_no_txt.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุเลขบัตร !!");
                return;
            }
            GF.showLoading(this);
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "member_id", member_id },
                { "card_no", card_no_txt.Text.Trim()},
                { "change_by", GF.userID}
            };

            if (note_txt.Text.Trim() != String.Empty)
                values.Add("note", note_txt.Text.Trim());

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/changeCardNo/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            GF.closeLoading();
            (this.Owner as member).getData();
            this.Close();
        }
    }
}
