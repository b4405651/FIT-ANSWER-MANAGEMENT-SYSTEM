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
    public partial class member_suspend : Form
    {
        String _member_id = "";
        public member_suspend(String member_id)
        {
            InitializeComponent();

            _member_id = member_id;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (reason.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'สาเหตุ' !!");
                reason.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "member_id", _member_id },
                { "reason", reason.Text.Trim() },
                { "branch_id", GF.Settings("branch_id") },
                { "suspend_by", GF.userID }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/Suspend/", values);

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
    }
}
