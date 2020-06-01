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
    public partial class member_payment : Form
    {
        public int max_amount = 0;
        public bool isDeposit = false;

        public member_payment()
        {
            InitializeComponent();

            foreach(ComboItem cbi in GF.payment_type)
            {
                payment_type.Items.Add(cbi);
            }

            payment_type.SelectedIndex = 0;
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void payment_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(payment_type.SelectedIndex == 0)
            {
                this.Height = 107;
            } else
            {
                this.Height = 230;
            }
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            if(amount.Text.Trim() != String.Empty)
            {
                if (Convert.ToInt32(amount.Text) > max_amount)
                    amount.Text = max_amount.ToString();
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if(amount.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'จำนวนเงิน' !!");
                amount.Select();
                return;
            }

            if (Convert.ToInt32(amount.Text.Trim()) <= 0)
            {
                GF.Error("'จำนวนเงิน' ต้องมากกว่า 0 !!");
                amount.Select();
                return;
            }

            if (payment_type.SelectedIndex == 1)
            {
                if(card_no.Text.Trim().Replace("_", "").Replace(" ", "") == String.Empty)
                {
                    GF.Error("กรุณากรอก 'หมายเลขบัตร' !!");
                    card_no.Select();
                    return;
                }

                if(card_no.Text.Trim().Replace("_", "").Replace(" ", "").Length < 16)
                {
                    GF.Error("กรุณากรอก 'หมายเลขบัตร' ให้ครบ 16 หลัก !!");
                    card_no.Select();
                    return;
                }

                if(card_expiry_date.Text.Trim().Replace("_", "").Replace("/", "").Replace(" ", "") == String.Empty)
                {
                    GF.Error("กรุณากรอก 'วันหมดอายุบัตร' !!");
                    card_expiry_date.Select();
                    return;
                }

                if(card_expiry_date.Text.Trim().Replace("_", "").Replace("/", "").Replace(" ", "").Length < 4)
                {
                    GF.Error("กรุณากรอก 'วันหมดอายุบัตร' ให้ครบ !!\r\n\r\n(หากเลขเดือนมีหลักเดียว ให้เติม 0 ข้างหน้า)");
                    card_expiry_date.Select();
                    return;
                }
            }

            String[] Data = {
                payment_type.Text,
                GF.formatNumber(Convert.ToInt32(amount.Text)),
                "",
                "",
                "",
                "",
                ((ComboItem)payment_type.SelectedItem).Key.ToString()
            };

            if (payment_type.SelectedIndex == 1)
            {
                Data[2] = card_no.Text;
                Data[3] = card_expiry_date.Text;
            }

            if (isDeposit)
                GF.addPaymentRow(((member_ext)this.Owner).deposit_DGV, Data, ((ComboItem)payment_type.SelectedItem).Key.ToString());
            else
                GF.addPaymentRow(((member_ext)this.Owner).full_DGV, Data, ((ComboItem)payment_type.SelectedItem).Key.ToString());

            this.Close();
        }

        private void amount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (amount.Text.Trim() != String.Empty)
                    if (Convert.ToInt32(amount.Text.Trim()) > 0)
                        if (payment_type.SelectedIndex == 0)
                            manage_btn.PerformClick();
                        else
                            SendKeys.Send("{TAB}");
        }

        private void card_expiry_date_Leave(object sender, EventArgs e)
        {
            GF.validateCardExpiry(card_expiry_date);
        }
    }
}
