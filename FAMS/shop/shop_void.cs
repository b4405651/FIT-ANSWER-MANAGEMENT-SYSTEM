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
    public partial class shop_void : Form
    {
        String bill_id = "";
        public shop_void(String bill_id)
        {
            InitializeComponent();

            this.bill_id = bill_id;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (reason.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณาระบุ 'สาเหตุ' !!");
                reason.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "bill_id", bill_id },
                { "void_by", GF.userID },
                { "void_reason", reason.Text.Trim() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Shop/Void/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            Dictionary<String, Object> Item = (Dictionary<String, Object>)result["result"];
            (this.Owner as shop).void_btn.Visible = false;
            (this.Owner as shop).void_txt.Visible = true;
            (this.Owner as shop).void_txt.Text = "*** บิลถูก VOID : " + Item["void_reason"].ToString() + " ***\r\nโดย : " + Item["void_by"].ToString() + " เมื่อ " + GF.formatDBDateTime(Item["void_datetime"].ToString());
            (this.Owner as shop).void_txt.Left = (this.Owner as shop).void_btn.Left;

            GF.closeLoading();
            this.Close();
        }
    }
}
