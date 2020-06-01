using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS.Report.Member
{
    public partial class sell_member : Form
    {
        Boolean isReady = true;
        webBrowser wb;
        public sell_member()
        {
            InitializeComponent();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                //branch_list.Items.Add(new ComboItem(-1, "ทุกสาขา"), true);
                foreach (Dictionary<String, Object> Branch in (Array)Obj["result"])
                {
                    branch_list.Items.Add(new ComboItem(Convert.ToInt32(Branch["branch_id"].ToString()), Branch["branch_name"].ToString()));
                }
            }

            member_view_list.Items.Add(new ComboItem(-1, "ทั้งหมด"));
            member_view_list.Items.Add(new ComboItem(1, "ชำระมัดจำ"));
            member_view_list.Items.Add(new ComboItem(0, "ชำระเต็มจำนวน / ส่วนที่เหลือ"));

            on_date.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + (DateTime.Now.Year + 543).ToString("0000");

            wb = new webBrowser(wb_panel); wb.DocumentText = "<center style='font-size: 24px; font-family:\'Tahoma\'; height: 100%; valign: middle;'><b><u>รายงาน สมาชิกชำระเงินค่าซื้อ Member</u></b></center>";
        }

        private void branch_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                GF.showLoading(this);
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 0; i < branch_list.Items.Count; i++)
                        branch_list.SetItemCheckState(i, CheckState.Unchecked);
                }
                isReady = true;
                GF.closeLoading();
            }
        }

        private void member_view_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < member_view_list.Items.Count; i++)
                    member_view_list.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        Boolean validate(out Dictionary<string, string> postParam)
        {
            postParam = null;
            String branch = String.Empty;
            for (int i = 0; i < branch_list.Items.Count; i++)
                if (branch_list.GetItemCheckState(i) == CheckState.Checked)
                {
                    branch += (branch_list.Items[i] as ComboItem).Key.ToString() + ",";
                }

            if (branch == String.Empty)
            {
                GF.Error("ยังไม่ได้เลือกสาขา !");
                return false;
            }
            else
                branch = branch.Substring(0, branch.Length - 1);

            String member_view = String.Empty;
            for (int i = 0; i < member_view_list.Items.Count; i++)
                if (member_view_list.GetItemCheckState(i) == CheckState.Checked)
                {
                    member_view += (member_view_list.Items[i] as ComboItem).Key.ToString() + ",";
                }

            if (member_view == String.Empty)
            {
                GF.Error("ยังไม่ได้เลือกประเภทการชำระเงิน !");
                return false;
            }
            else
                member_view = member_view.Substring(0, member_view.Length - 1);

            if (!GF.validateDateTime(on_date)) return false;

            postParam = new Dictionary<string, string>(){
                { "branch", branch },
                { "member_view", member_view },
                { "on_date", on_date.Text }
            };
            return true;
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            wb = new webBrowser(wb_panel);
            wb.DocumentCompleted += (ss, ee) =>
            {
                GF.enableBtn(manage_btn, Color.LightCoral);
                print_btn.Visible = true;
                excel_btn.Visible = true;
            };

            GF.disableBtn(manage_btn);
            print_btn.Visible = false;
            excel_btn.Visible = false;

            DB.PerformWebNavigate("Member/SellMember/", wb, values);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (wb != null) wb.ShowPrintDialog();
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            DB.WebDownload(this, "Member/SellMember/", "sell_member.xls", values);
        }
    }
}
