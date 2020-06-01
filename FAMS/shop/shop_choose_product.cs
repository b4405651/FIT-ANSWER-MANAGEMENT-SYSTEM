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
    public partial class shop_choose_product : Form
    {
        Dictionary<string, string> product_name = new Dictionary<string, string>();
        Dictionary<string, string> product_price = new Dictionary<string, string>();
        public shop_choose_product()
        {
            InitializeComponent();

            GF.showLoading(this);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "is_suspend" , "0" }
            };

            Dictionary<String, Object> Obj = DB.Post("Product/getProductList/", values);

            if (Obj != null)
            {
                product_cb.Items.Add(new ComboItem(0, "เลือก สินค้า"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    product_cb.Items.Add(new ComboItem(GF.toInt(Item["product_id"].ToString()), Item["product_name"].ToString() + " (" + GF.formatNumber(Item["price"].ToString()) + " บาท)"));
                    product_name.Add(Item["product_id"].ToString(), Item["product_name"].ToString());
                    product_price.Add(Item["product_id"].ToString(), Item["price"].ToString());
                }

                product_cb.SelectedIndex = 0;
                GF.resizeComboBox(product_cb);
            }
            else
            {
                GF.closeLoading();
                GF.Error("ไม่มีข้อมูล 'สินค้า' !!\r\n\r\nกรุณาแจ้งผู้ดูแลระบบ !!");
            }
            GF.closeLoading();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (product_cb.SelectedIndex == 0)
            {
                GF.Error("กรุณาเลือก 'สินค้า' !!");
                product_cb.Select();
                return;
            }

            (this.Owner as shop).addRow(
                product_name[((ComboItem)product_cb.SelectedItem).Key.ToString()].ToString(),
                product_price[((ComboItem)product_cb.SelectedItem).Key.ToString()].ToString(),
                ((ComboItem)product_cb.SelectedItem).Key.ToString(),
                "1"
            );

            this.Close();
        }
    }
}
