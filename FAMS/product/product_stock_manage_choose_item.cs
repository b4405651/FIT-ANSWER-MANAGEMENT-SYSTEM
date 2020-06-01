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
    public partial class product_stock_manage_choose_item : Form
    {
        Dictionary<string, string> product_name = new Dictionary<string, string>();
        public product_stock_manage_choose_item()
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
                    product_cb.Items.Add(new ComboItem(GF.toInt(Item["product_id"].ToString()), Item["product_name"].ToString()));
                    product_name.Add(Item["product_id"].ToString(), Item["product_name"].ToString());
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

            (this.Owner as product_stock_manage).addRow(
                product_name[((ComboItem)product_cb.SelectedItem).Key.ToString()].ToString(),
                ((ComboItem)product_cb.SelectedItem).Key.ToString()
            );

            this.Close();
        }
    }
}
