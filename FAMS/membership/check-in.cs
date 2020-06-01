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
    public partial class check_in : Form
    {
        String member_id = "";

        public check_in()
        {
            InitializeComponent();
            reset();
        }

        private void check_in_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void check_in_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Height = 192;
                if (member_pic_pb.Image != null)
                {
                    member_pic_pb.Image.Dispose();
                    member_pic_pb.Image = null;
                }
                reset();
            }
            else if (e.KeyCode == Keys.Enter && member_card_no.Text.Trim() != String.Empty)
            {
                GF.showLoading(this);
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "card_no" , member_card_no.Text.Trim() },
                    { "branch_id", GF.Settings("branch_id") },
                    { "is_check_in", "1" }
                };

                Dictionary<String, Object> Obj = DB.Post("Member/getMemberDataByCardNo/", values);

                if (Obj != null)
                {
                    if (Obj["result"].ToString() == "NOT FOUND")
                    {
                        GF.closeLoading();
                        this.BringToFront();
                        this.Activate();
                        GF.Error((Obj["msg"] ?? "").ToString());
                        reset();
                        return;
                    }

                    fullname_lbl.Text = "ชื่อ : คุณ " + Obj["firstname_th"].ToString() + " " + Obj["lastname_th"].ToString();
                    nickname_lbl.Text = "ชื่อเล่น : " + Obj["nickname_th"].ToString();
                    member_no_lbl.Text = "รหัสสมาชิก : " + Obj["member_no"].ToString();
                    card_no_lbl.Text = "เลขที่บัตร : " + (Obj["card_no"] ?? "").ToString();
                    member_type_lbl.Text = "ประเภทสมาชิก : " + Obj["member_type"].ToString();
                    during_date_lbl.Text = "ระหว่างวันที่ : " + Obj["during_date"].ToString();

                    if ((Obj["image_file"] ?? "").ToString() != String.Empty)
                        member_pic_pb.Image = FTP.download("member_picture", Obj["image_file"].ToString());
                    else
                    {
                        if (member_pic_pb.Image != null)
                        {
                            member_pic_pb.Image.Dispose();
                            member_pic_pb.Image = null;
                        }
                    }

                    this.Height = manage_btn.Top + manage_btn.Height + 60;

                    if (Obj["result"].ToString() == "YES")
                    {
                        member_id = Obj["member_id"].ToString();
                        this.CenterToScreen();
                        GF.closeLoading();
                        this.BringToFront();
                        this.Activate();
                    } else if (Obj["result"].ToString() == "NO")
                    {
                        manage_btn.Visible = false;
                        this.CenterToScreen();
                        GF.closeLoading();
                        this.BringToFront();
                        this.Activate();
                        GF.Error((Obj["msg"] ?? "").ToString());
                    }
                }
            } else {
                if (e.KeyData.ToString().Length == 1)
                    member_card_no.Text += e.KeyData.ToString();
                else if (e.KeyData.ToString().Length == 2 && e.KeyData.ToString()[0] == 'D')
                    member_card_no.Text += e.KeyData.ToString()[1];
                else if (e.KeyData.ToString().IndexOf("NumLock") > -1)
                    member_card_no.Text += e.KeyData.ToString().Replace("NumLock", "");
                else if (e.KeyData.ToString().IndexOf("NumPad") > -1)
                    member_card_no.Text += e.KeyData.ToString().Replace("NumPad", "");
                else if (e.KeyData.ToString() == "Back")
                {
                    if (member_card_no.Text.Trim().Length >= 1)
                        member_card_no.Text = member_card_no.Text.Trim().Substring(0, member_card_no.Text.Trim().Length - 1);
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "member_id" , member_id },
                { "branch_id", GF.Settings("branch_id") }
            };

            Dictionary<String, Object> Obj = DB.Post("Member/memberCheckIn/", values);

            if (Obj != null)
            {
                if (Obj["result"].ToString() == "true")
                {
                    GF.Error("บันทึกการเข้าใช้งานเรียบร้อย !!", "");
                    this.Close();
                }
                else
                    GF.Error("เกิดความผิดพลาด !!\r\n\r\nกรุณาแจ้งผู้ดูแลระบบ !!");
            }
        }

        void reset()
        {
            member_card_no.Text = "";
            fullname_lbl.Text = "";
            nickname_lbl.Text = "";
            member_no_lbl.Text = "";
            card_no_lbl.Text = "";
            member_type_lbl.Text = "";
            during_date_lbl.Text = "";
        }
    }
}
