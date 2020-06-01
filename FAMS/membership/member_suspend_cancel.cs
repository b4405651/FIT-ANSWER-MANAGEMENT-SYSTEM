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
    public partial class member_suspend_cancel : Form
    {
        String _member_id = "";
        public member_suspend_cancel(String member_id)
        {
            InitializeComponent();

            _member_id = member_id;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "member_id", _member_id },
                { "cancel_suspend_by", GF.userID }
            };

            if (note.Text.Trim() != String.Empty)
                values.Add("note", note.Text.Trim());

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/cancelSuspend/", values);

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
