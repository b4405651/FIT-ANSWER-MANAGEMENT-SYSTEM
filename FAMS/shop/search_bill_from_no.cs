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
    public partial class search_bill_from_no : Form
    {
        public search_bill_from_no()
        {
            InitializeComponent();
        }

        private void bill_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (bill_no.Text.Trim() != String.Empty && e.KeyCode == Keys.Enter)
            {
                GF.showLoading(this);
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "bill_no" , bill_no.Text.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("Shop/getDataByBillNo/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> item = (Dictionary<String, Object>)Obj["result"];
                    String Product_Data = item["product_data"].ToString();
                    String Payment_Data = item["payment_data"].ToString();
                    (this.Owner as shop).bill_id = item["bill_id"].ToString();

                    if (item["is_void"].ToString() == "0" && GF.isAdmin)
                    {
                        (this.Owner as shop).void_btn.Visible = true;
                        (this.Owner as shop).void_txt.Visible = false;
                        (this.Owner as shop).void_txt.Left = 273;
                    }

                    if (item["is_void"].ToString() == "1")
                    {
                        (this.Owner as shop).void_txt.Visible = true;
                        (this.Owner as shop).void_txt.Text = "*** บิลถูก VOID : " + item["void_reason"].ToString() + " ***\r\nโดย : " + item["void_by"].ToString() + " เมื่อ " + GF.formatDBDateTime(item["void_datetime"].ToString());
                        (this.Owner as shop).void_txt.Left = (this.Owner as shop).void_btn.Left;
                    }

                    String[] tmp_data = Product_Data.Split(new String[] { "!!" }, StringSplitOptions.None);
                    foreach (String product in tmp_data)
                    {
                        String[] Item = product.Split(new String[] { "##" }, StringSplitOptions.None);
                        (this.Owner as shop).addRow(Item[0].ToString(), Item[1].ToString(), Item[2].ToString(), Item[3].ToString(), Item[5].ToString(), Item[6].ToString(), Item[7].ToString());
                    }

                    tmp_data = Payment_Data.Split(new String[] { "!!" }, StringSplitOptions.None);
                    foreach (String payment in tmp_data)
                    {
                        String[] Item = payment.Split(new String[] { "##" }, StringSplitOptions.None);
                        DataGridView DGV = (this.Owner as shop).payment_DGV;
                        DGV.Rows.Add(
                            GF.payment_type[Convert.ToInt32(Item[0].ToString())],
                            GF.formatNumber(Convert.ToInt32(Item[1].ToString())),
                            (Item[2] ?? "").ToString(),
                            (Item[3] ?? "").ToString(),
                            Item[4].ToString(),
                            GF.formatDBDateTime(Item[5].ToString()),
                            Item[0].ToString()
                        );
                    }

                    (this.Owner as shop).product_DGV.ClearSelection();
                    (this.Owner as shop).payment_DGV.ClearSelection();

                    (this.Owner as shop).bill_search_btn.Text = "เปิดบิลใหม่";
                    (this.Owner as shop).product_code.Enabled = false;
                    GF.disableBtn((this.Owner as shop).add_product_btn);
                    (this.Owner as shop).product_DGV.Enabled = false;
                    GF.disableBtn((this.Owner as shop).add_payment_btn);
                    (this.Owner as shop).payment_DGV.Enabled = false;
                    GF.disableBtn((this.Owner as shop).manage_btn);

                    (this.Owner as shop).print_btn.Visible = true;
                    (this.Owner as shop).print_btn.Left = (this.Owner as shop).manage_btn.Left;
                    (this.Owner as shop).print_btn.Top = (this.Owner as shop).manage_btn.Top;
                    (this.Owner as shop).print_btn.BringToFront();
                }

                GF.closeLoading();
                this.Close();
            }
        }
    }
}
