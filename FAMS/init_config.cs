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
    public partial class init_config : Form
    {
        Boolean isHalt = false;
        public Boolean justStart = true;
        Dictionary<String, String> Prefix = new Dictionary<string, string>();

        public init_config()
        {
            InitializeComponent();

            GF.showLoading(this);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if(Obj != null)
            {
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    branch_id.Items.Add(new ComboItem(GF.toInt(Item["branch_id"].ToString()), Item["branch_name"].ToString() + " (" + Item["prefix"].ToString() + ")"));
                    Prefix.Add(Item["branch_id"].ToString(), Item["prefix"].ToString());
                }

                branch_id.SelectedIndex = 0;
                GF.resizeComboBox(branch_id);
                GF.closeLoading();
            } else {
                GF.closeLoading();
                GF.Error("ไม่มีข้อมูล 'สาขา' ในฐานข้อมูล !!\r\n\r\nกรุณาติดต่อผู้ดูแลระบบ !!");
                isHalt = true;
            }

            card_printer.Items.Clear();
            card_printer.Items.Add("ไม่มี");
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                card_printer.Items.Add(printer);
            }
            card_printer.SelectedIndex = 0;

            receipt_printer.Items.Clear();
            receipt_printer.Items.Add("ไม่มี");
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                receipt_printer.Items.Add(printer);
            }
            receipt_printer.SelectedIndex = 0;
        }

        private void init_config_Load(object sender, EventArgs e)
        {
            if (isHalt) Application.Exit();

            if ((GF.Settings("branch_id") ?? "") != String.Empty)
            {
                foreach (ComboItem cb in branch_id.Items)
                {
                    if (cb.Key.ToString() == GF.Settings("branch_id"))
                    {
                        branch_id.Text = cb.Value;
                        break;
                    }
                }
            }

            if ((GF.Settings("card_printer") ?? "") != String.Empty)
                card_printer.Text = GF.Settings("card_printer");

            if ((GF.Settings("receipt_printer") ?? "") != String.Empty)
                receipt_printer.Text = GF.Settings("receipt_printer");

            if ((GF.Settings("vat") ?? "") != String.Empty)
                vat.Text = GF.Settings("vat");
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (vat.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้กรอก 'VAT' !!");
                vat.Select();
                return;
            }

            double vat_double = 0.00;
            if (!Double.TryParse(vat.Text.Trim(), out vat_double))
            {
                GF.Error("'VAT' ต้องประกอบด้วย ตัวเลขเท่านั้น และ ทศนิยม 2 ตำแหน่ง !!");
                vat.Select();
                return;
            }

            GF.Settings("branch_id", ((ComboItem)branch_id.SelectedItem).Key.ToString());
            GF.Settings("member_prefix", Prefix[((ComboItem)branch_id.SelectedItem).Key.ToString()]);
            GF.Settings("card_printer", card_printer.Text);
            GF.Settings("receipt_printer", receipt_printer.Text);
            GF.Settings("vat", vat.Text.Trim());

            this.Hide();
            if (justStart)
            {
                using (Login loginPage = new Login())
                {
                    loginPage.ShowDialog();
                }
                //Program.Restart();
            }
            else
            {
                if (this.Owner != null)
                {
                    if (this.Owner.Name == "main")
                    {
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        if (GF.Settings("branch_id") != String.Empty)
                        {
                            values.Add("branch_id", GF.Settings("branch_id"));

                            Dictionary<String, Object> Obj = DB.Post("Branch/getBranchData/", values);

                            if (Obj != null)
                            {
                                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                                GF.mainPage.branch_name.Text = Item["branch_name"].ToString();
                            }
                        }
                    }
                }
                this.Close();
            }
        }

        private void vat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))  //bypass control keys
            {
                int dotIndex = vat.Text.IndexOf('.');
                if (char.IsDigit(e.KeyChar))     //ensure it's a digit
                {   //we cannot accept another digit if
                    if (dotIndex != -1 &&  //there is already a dot and
                        //dot is to the left from the cursor position and
                        dotIndex < vat.SelectionStart &&
                        //there're already 2 symbols to the right from the dot
                        vat.Text.Substring(dotIndex + 1).Length >= 2)
                    {
                        e.Handled = true;
                    }
                }
                else
                    e.Handled = e.KeyChar != '.' || dotIndex != -1 || vat.Text.Length == 0 || vat.SelectionStart + 2 < vat.Text.Length;
            }
        }
    }
}
