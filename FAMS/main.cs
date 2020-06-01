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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void main_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    if (ctl.GetType() != typeof(StatusStrip) && ctl.GetType() != typeof(MenuStrip))
                    {
                        ctlMDI = (MdiClient)ctl;

                        // Set the BackColor of the MdiClient control.
                        ctlMDI.BackColor = this.BackColor;
                    }
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                    Console.WriteLine(exc.Message);
                }
            }
            
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void check_in_btn_Click(object sender, EventArgs e)
        {
            using(check_in checkInPage = new check_in())
            {
                checkInPage.Owner = this;
                checkInPage.ShowDialog();
            }
        }

        private void member_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new member());
        }

        private void employee_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new employee());
        }

        private void user_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new user());
        }

        private void change_pwd_btn_Click(object sender, EventArgs e)
        {
            using (change_pwd changePassword = new change_pwd())
            {
                changePassword.Owner = this;
                changePassword.ShowDialog();
            }
        }

        private void member_type_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new config_member_type());
        }

        private void trainer_btn_Click(object sender, EventArgs e)
        {
            using (use_pt usePT = new use_pt())
            {
                usePT.Owner = this;
                usePT.ShowDialog();
            }
        }

        private void config_product_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new config_product());
        }

        private void stock_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new product_stock());
        }

        private void init_config_btn_Click(object sender, EventArgs e)
        {
            using (init_config initConfig = new init_config())
            {
                initConfig.justStart = false;
                initConfig.Owner = this;
                initConfig.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }

        private void branch_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new branch());
        }

        private void shop_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new shop());
        }

        private void trainer_job_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void during_date_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Summary.DuringDate());
        }

        private void on_date_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Summary.OnDate());
        }

        private void member_list_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Member.list());
        }

        private void sell_member_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Member.sell_member());
        }

        private void sell_pt_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Member.sell_pt());
        }

        private void use_pt_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Member.use_pt());
        }

        private void member_checkin_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Member.check_in());
        }

        private void employee_list_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Employee.list());
        }

        private void pt_list_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.PT.list());
        }

        private void training_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.PT.training());
        }

        private void schedule_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.PT.schedule());
        }

        private void product_list_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Stock.list());
        }

        private void balance_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Stock.balance());
        }

        private void transaction_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Stock.transaction());
        }

        private void shop_sales_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Shop.sales());
        }

        private void shop_revenue_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Shop.revenue());
        }

        private void shop_void_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new Report.Shop.@void());
        }

        private void account_btn_Click(object sender, EventArgs e)
        {
            using (accounting_report report = new accounting_report())
            {
                report.Owner = this;
                report.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }

        private void trainer_job_list_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new trainer_job_list());
        }

        private void trainer_list_member_btn_Click(object sender, EventArgs e)
        {
            GF.closeChildren(new trainer_list_member());
        }

        private void emp_card_btn_Click(object sender, EventArgs e)
        {
            using (config_employee_card emp_card = new config_employee_card())
            {
                emp_card.Owner = this;
                emp_card.ShowDialog();
                this.BringToFront();
                this.Activate();
            }
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
