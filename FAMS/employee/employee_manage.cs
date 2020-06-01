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
    public partial class employee_manage : Form
    {
        public string emp_id = "";
        public employee_manage()
        {
            InitializeComponent();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };
            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    branch_id.Items.Add(new ComboItem(GF.toInt(Item["branch_id"].ToString()), Item["branch_name"].ToString()));
                }
            }

            branch_id.SelectedIndex = 0;
            GF.resizeComboBox(branch_id);
        }

        private void employee_manage_Load(object sender, EventArgs e)
        {
            if (emp_id.Trim() != String.Empty)
            {
                GF.showLoading(this);
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "emp_id" , emp_id.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("Employee/getEmployeeData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    emp_code.Text = (Item["emp_code"] ?? "").ToString();
                    fullname.Text = Item["fullname"].ToString();
                    nickname.Text = Item["nickname"].ToString();
                    if (Item["is_trainer"].ToString() == "1")
                        is_trainer.Checked = true;
                    if (Item["can_get_commission"].ToString() == "1")
                        can_get_commission.Checked = true;

                    foreach (ComboItem cb in branch_id.Items)
                    {
                        if (cb.Key.ToString() == Item["branch_id"].ToString())
                        {
                            branch_id.Text = cb.Value;
                            break;
                        }
                    }
                }

                GF.closeLoading();
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (emp_code.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'รหัสพนักงาน' !!");
                emp_code.Select();
                return;
            }

            if (fullname.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อ - สกุล' !!");
                fullname.Select();
                return;
            }

            if (nickname.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อเล่น' !!");
                nickname.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "emp_code", emp_code.Text.Trim() },
                { "fullname", fullname.Text.Trim() },
                { "nickname", nickname.Text.Trim() },
                { "is_trainer", (is_trainer.Checked ? "1" : "0") },
                { "can_get_commission", (can_get_commission.Checked ? "1" : "0") },
                { "branch_id", (branch_id.SelectedItem as ComboItem).Key.ToString() }
            };

            if (emp_id != String.Empty) values.Add("emp_id", emp_id);

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Employee/manageEmployee/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            ((employee)this.Owner).getData();
            this.Close();
        }
    }
}
