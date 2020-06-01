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
    public partial class change_pwd : Form
    {
        public change_pwd()
        {
            InitializeComponent();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (password.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'รหัสผ่าน' !!");
                password.Select();
                return;
            }

            if (password.Text.Trim() != String.Empty && verify_password.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ยืนยันรหัสผ่าน' !!");
                verify_password.Select();
                return;
            }

            if (password.Text.Trim() != String.Empty && verify_password.Text.Trim() != password.Text.Trim())
            {
                GF.Error("'ยืนยันรหัสผ่าน' ที่กรอกไม่ตรงกับ 'รหัสผ่าน' !!");
                verify_password.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "password", password.Text.Trim() },
                { "user_id", GF.userID }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("User/change_pwd/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            GF.closeLoading();
            this.Close();
        }
    }
}
