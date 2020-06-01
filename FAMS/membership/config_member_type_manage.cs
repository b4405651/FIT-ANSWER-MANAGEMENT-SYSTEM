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
    public partial class config_member_type_manage : Form
    {
        public String member_type_id = "";

        public config_member_type_manage()
        {
            InitializeComponent();
        }

        private void config_member_type_manage_Load(object sender, EventArgs e)
        {
            if (member_type_id != String.Empty)
            {
                GF.showLoading(this);

                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "member_type_id" , member_type_id.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("MemberType/getMemberTypeData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    member_type_name.Text = Item["member_type_name"].ToString();
                    month_amount.Text = Item["month_amount"].ToString();
                    price.Text = Item["price"].ToString();
                }

                GF.closeLoading();
            }
        }

        private void month_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (member_type_name.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อประเภทสมาชิก' !!");
                member_type_name.Select();
                return;
            }

            if (month_amount.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'อายุ' !!");
                month_amount.Select();
                return;
            }

            if (Convert.ToInt32(month_amount.Text.Trim()) <= 0)
            {
                GF.Error("'อายุ' ต้องมากกว่า 0 !!");
                month_amount.Select();
                return;
            }

            if (price.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ราคา' !!");
                price.Select();
                return;
            }

            if (Convert.ToInt32(price.Text.Trim()) <= 0)
            {
                GF.Error("'ราคา' ต้องมากกว่า 0 !!");
                price.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "member_type_name", member_type_name.Text.Trim() },
                { "month_amount", month_amount.Text.Trim() },
                { "price", price.Text.Trim() }
            };

            if (member_type_id != String.Empty) values.Add("member_type_id", member_type_id);

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("MemberType/manageMemberType/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            ((config_member_type)this.Owner).getData();
            this.Close();
        }
    }
}
