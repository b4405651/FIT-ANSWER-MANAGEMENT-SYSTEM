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
    public partial class config_product_manage : Form
    {
        public string product_id = "";
        public config_product_manage()
        {
            InitializeComponent();
        }

        private void config_product_manage_Load(object sender, EventArgs e)
        {
            if (product_id != String.Empty)
            {
                GF.showLoading(this);

                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "product_id" , product_id.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("Product/getProductData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    product_name.Text = Item["product_name"].ToString();
                    product_code.Text = (Item["product_code"] ?? "").ToString();
                    price.Text = Item["price"].ToString();
                    alert_amount.Text = Item["alert_amount"].ToString();
                }

                GF.closeLoading();
            }
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (product_name.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อสินค้า' !!");
                product_name.Select();
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

            if (alert_amount.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'แจ้งเตือนเมื่อคงเหลือ' !!");
                alert_amount.Select();
                return;
            }

            if (Convert.ToInt32(alert_amount.Text.Trim()) <= 0)
            {
                GF.Error("'แจ้งเตือนเมื่อคงเหลือ' ต้องมากกว่า 0 !!");
                alert_amount.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "product_name", product_name.Text.Trim() },
                { "price", price.Text.Trim() },
                { "alert_amount", alert_amount.Text.Trim() }
            };

            if (product_code.Text.Trim() != String.Empty)
                values.Add("product_code", product_code.Text.Trim());
            if (product_id != String.Empty) values.Add("product_id", product_id);

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Product/manageProduct/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            ((config_product)this.Owner).getData();
            this.Close();
        }
    }
}
