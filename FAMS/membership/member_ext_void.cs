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
    public partial class member_ext_void : Form
    {
        String _member_ext_id = "";
        public member_ext_void(String member_ext_id)
        {
            InitializeComponent();
            _member_ext_id = member_ext_id;
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
                    { "member_ext_id", _member_ext_id },
                    { "void_reason", reason.Text.Trim() },
                    { "void_by", GF.userID }
                };

                GF.showLoading(this);
                Dictionary<String, Object> result = DB.Post("Member/voidMemberExt/", values);

                if (result == null)
                {
                    GF.Error("เกิดความผิดพลาด !!");
                    GF.closeLoading();
                    return;
                }

                (this.Owner as history_buy_member).getData();
                ((this.Owner as history_buy_member).Owner as member).getData();

                GF.closeLoading();
                this.Close();
            }
        }
    }
}
