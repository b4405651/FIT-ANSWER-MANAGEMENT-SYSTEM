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
    public partial class check_in : Form
    {
        Boolean isReady = true;
        webBrowser wb;
        public check_in()
        {
            InitializeComponent();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                branch_list.Items.Add(new ComboItem(-1, "ทุกสาขา"), true);
                foreach (Dictionary<String, Object> Branch in (Array)Obj["result"])
                {
                    branch_list.Items.Add(new ComboItem(Convert.ToInt32(Branch["branch_id"].ToString()), Branch["branch_name"].ToString()));
                }
            }

            on_date.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + (DateTime.Now.Year + 543).ToString("0000");

            wb = new webBrowser(wb_panel); wb.DocumentText = "<center style='font-size: 24px; font-family:\'Tahoma\'; height: 100%; valign: middle;'><b><u>รายงาน การเข้าใช้บริการ</u></b></center>";
        }

        private void branch_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                if (e.NewValue == CheckState.Checked)
                {
                    ComboItem cbi = (branch_list.Items[e.Index] as ComboItem);
                    if (cbi.Key == -1)
                    {
                        for (int i = 0; i < branch_list.Items.Count; i++)
                            if ((branch_list.Items[i] as ComboItem).Key != -1)
                                branch_list.SetItemCheckState(i, CheckState.Unchecked);
                    }
                    else
                    {
                        branch_list.SetItemCheckState(0, CheckState.Unchecked);
                    }
                }
                isReady = true;
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

            if (!GF.validateDateTime(on_date)) return false;

            postParam = new Dictionary<string, string>(){
                { "branch", branch },
                { "on_date", on_date.Text },
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

            DB.PerformWebNavigate("Member/CheckIn/", wb, values);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (wb != null) wb.ShowPrintDialog();
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            DB.WebDownload(this, "Member/CheckIn/", "member_checkin.xls", values);
        }
    }
}
