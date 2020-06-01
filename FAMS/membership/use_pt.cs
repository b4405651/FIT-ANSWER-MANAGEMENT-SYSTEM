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
    public partial class use_pt : Form
    {
        Label currentLabel = null;
        String member_id = "";
        String pt_emp_id = "";
        public use_pt()
        {
            InitializeComponent();

            card_no.Text = "";
            member_name.Text = "";

            pt_no.Text = "";
            trainer_name.Text = "";

            currentLabel = card_no;

            this.Text = "แสกน หรือ พิมพ์ เลขบัตรสมาชิก";
        }

        private void use_pt_Load(object sender, EventArgs e)
        {
            //GF.Error("แสกนบัตรสมาชิก\r\nหรือ\r\nพิมพ์ รหัสสมาชิก แล้วกด Enter", "รหัสสมาชิก");
        }

        private void use_pt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void use_pt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                currentLabel.Text = "";
            }
            else if (e.KeyCode == Keys.Enter && card_no.Text.Trim() != String.Empty)
            {
                if (currentLabel == card_no && card_no.Text.Trim() != String.Empty)
                {
                    // GET MEMBER DATA
                    GF.showLoading(this);
                    Dictionary<string, string> values = new Dictionary<string, string>()
                    {
                        { "branch_id" , GF.Settings("branch_id") },
                        { "card_no" , card_no.Text.Trim() },
                        { "is_check_in", "0" }
                    };

                    Dictionary<String, Object> Obj = DB.Post("Member/getMemberDataByCardNo/", values);

                    if (Obj != null)
                    {
                        if (Obj["result"].ToString() == "NOT FOUND" || Obj["result"].ToString() == "NO")
                        {
                            GF.closeLoading();
                            this.BringToFront();
                            this.Activate();
                            GF.Error((Obj["msg"] ?? "").ToString());
                            card_no.Text = "";
                            return;
                        }

                        member_id = Obj["member_id"].ToString();
                        member_name.Text = Obj["firstname_th"].ToString() + " " + Obj["lastname_th"].ToString();
                        if (Obj["nickname_th"].ToString().Trim() != "-" && Obj["nickname_th"].ToString() != String.Empty)
                            member_name.Text += " (" + Obj["nickname_th"].ToString() + ")";
                        GF.closeLoading();
                        this.BringToFront();
                        this.Activate();
                        currentLabel = pt_no;
                        this.Text = "แสกน หรือ พิมพ์ รหัสพนักงาน";
                        //GF.Error("แสกนบัตรเทรนเนอร์\r\nหรือ\r\nพิมพ์ รหัสเทรนเนอร์ แล้วกด Enter", "รหัสเทรนเนอร์");
                    }
                }
                else if (currentLabel == pt_no && pt_no.Text.Trim() != String.Empty)
                {
                    // GET EMP DATA
                    GF.showLoading(this);
                    Dictionary<string, string> values = new Dictionary<string, string>()
                    {
                        { "emp_code" , pt_no.Text.Trim() }
                    };

                    Dictionary<String, Object> Obj = DB.Post("Employee/getEmployeeByCode/", values);

                    if (Obj != null)
                    {
                        if (Obj["result"].ToString().ToUpper() == "NOT FOUND" || Obj["result"].ToString().ToUpper() == "NO" || Obj["result"].ToString().ToUpper() == "FALSE")
                        {
                            GF.closeLoading();
                            this.BringToFront();
                            this.Activate();
                            GF.Error((Obj["msg"] ?? "").ToString());
                            pt_no.Text = "";
                            trainer_name.Text = "";
                            return;
                        }

                        pt_emp_id = Obj["emp_id"].ToString();
                        trainer_name.Text = Obj["emp_name"].ToString();

                        // USE PT
                        values = new Dictionary<string, string>()
                        {
                            { "member_id", member_id },
                            { "pt_emp_id", pt_emp_id },
                            { "branch_id", GF.Settings("branch_id") },
                            { "process_by", GF.userID }
                        };

                        Obj = DB.Post("Member/UsePT/", values);

                        if (Obj != null)
                        {
                            if (Obj["result"].ToString().ToUpper() == "TRUE")
                            {
                                GF.closeLoading();
                                GF.Error(Obj["msg"].ToString(), "บันทึก SESSION เรียบร้อยแล้ว !");
                                this.Close();
                            }
                            else
                            {
                                pt_no.Text = "";
                                trainer_name.Text = "";

                                GF.closeLoading();
                                GF.Error(Obj["msg"].ToString());
                            }
                        }
                        else
                        {
                            pt_no.Text = "";
                            trainer_name.Text = "";

                            GF.closeLoading();
                        }
                    }
                }
            }
            else
            {
                if (e.KeyData.ToString().Length == 1)
                    currentLabel.Text += e.KeyData.ToString();
                else if (e.KeyData.ToString().Length == 2 && e.KeyData.ToString()[0] == 'D')
                    currentLabel.Text += e.KeyData.ToString()[1];
                else if (e.KeyData.ToString().IndexOf("NumLock") > -1)
                    currentLabel.Text += e.KeyData.ToString().Replace("NumLock", "");
                else if (e.KeyData.ToString().IndexOf("NumPad") > -1)
                    currentLabel.Text += e.KeyData.ToString().Replace("NumPad", "");
                else if (e.KeyData.ToString() == "Back")
                {
                    if (currentLabel.Text.Trim().Length >= 1)
                        currentLabel.Text = currentLabel.Text.Trim().Substring(0, currentLabel.Text.Trim().Length - 1);
                }
            }
        }
    }
}
