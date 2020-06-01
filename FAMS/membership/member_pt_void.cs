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
    public partial class member_pt_void : Form
    {
        String _member_pt_id = "";
        public member_pt_void(String member_pt_id)
        {
            InitializeComponent();
            _member_pt_id = member_pt_id;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (reason.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'สาเหตุ' !!");
                reason.Select();
                return;
            }

            if (MessageBox.Show("คุณแน่ใจหรือไม่ ที่จะ VOID รายการนี้ ?\r\n\r\nเมื่อ VOID แล้วจะไม่สามารถยกเลิกได้อีก ต้องสร้างรายการใหม่เท่านั้น !", "คำเตือน", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();

                values = new Dictionary<string, string>
                {
                    { "member_pt_id", _member_pt_id },
                    { "void_reason", reason.Text.Trim() },
                    { "void_by", GF.userID }
                };

                GF.showLoading(this);
                Dictionary<String, Object> result = DB.Post("Member/voidMemberPT/", values);

                if (result == null)
                {
                    GF.Error("เกิดความผิดพลาด !!");
                    GF.closeLoading();
                    return;
                }

                (this.Owner as history_buy_pt).getData();

                GF.closeLoading();
                this.Close();
            }
        }
    }
}
