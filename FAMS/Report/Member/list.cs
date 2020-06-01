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
    public partial class list : Form
    {
        Boolean isReady = true;
        webBrowser wb;
        public list()
        {
            InitializeComponent();

            //PAGING DELEGATE
            pagination.firstClick += manage_btn_Click;
            pagination.prevClick += manage_btn_Click;
            pagination.nextClick += manage_btn_Click;
            pagination.lastClick += manage_btn_Click;
            pagination.pageNumberChanged += manage_btn_Click;

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

            member_view_list.Items.Add(new ComboItem(-1, "สมาชิกทั้งหมด"), true);
            member_view_list.Items.Add(new ComboItem(0, "สมาชิกใหม่"));
            member_view_list.Items.Add(new ComboItem(1, "สมาชิกที่ยังไม่หมดอายุ"));
            member_view_list.Items.Add(new ComboItem(2, "สมาชิกที่หมดอายุ"));
            member_view_list.Items.Add(new ComboItem(3, "สมาชิกดรอป"));
            member_view_list.Items.Add(new ComboItem(4, "สมาชิกที่ยังชำระไม่ครบ"));
            member_view_list.Items.Add(new ComboItem(5, "สมาชิกที่ถูกระงับการใช้"));

            Obj = DB.Post("MemberType/MemberTypeList/", values);

            if (Obj != null)
            {
                member_type_list.Items.Add(new ComboItem(-1, "ทั้งหมด"), true);
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    member_type_list.Items.Add(new ComboItem(GF.toInt(Item["member_type_id"].ToString()), Item["member_type_name"].ToString()));
                }
            }

            wb = new webBrowser(wb_panel); wb.DocumentText = "<center style='font-size: 24px; font-family:\'Tahoma\'; height: 100%; valign: middle;'><b><u>รายงาน รายชื่อสมาชิก</u></b></center>";
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

        private void member_view_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                if (e.NewValue == CheckState.Checked)
                {
                    ComboItem cbi = (member_view_list.Items[e.Index] as ComboItem);
                    for (int i = 0; i < member_view_list.Items.Count; i++)
                        if (i != e.Index)
                            member_view_list.SetItemCheckState(i, CheckState.Unchecked);
                }
                isReady = true;
            }
        }

        private void member_type_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                if (e.NewValue == CheckState.Checked)
                {
                    ComboItem cbi = (member_type_list.Items[e.Index] as ComboItem);
                    if (cbi.Key == -1)
                    {
                        for (int i = 0; i < member_type_list.Items.Count; i++)
                            if ((member_type_list.Items[i] as ComboItem).Key != -1)
                                member_type_list.SetItemCheckState(i, CheckState.Unchecked);
                    }
                    else
                    {
                        member_type_list.SetItemCheckState(0, CheckState.Unchecked);
                    }
                }
                isReady = true;
            }
        }

        Boolean validate(out Dictionary<string, string> postParam)
        {
            postParam = null;

            // BRANCH
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

            // MEMBER_VIEW
            String member_view = String.Empty;
            for (int i = 0; i < member_view_list.Items.Count; i++)
                if (member_view_list.GetItemCheckState(i) == CheckState.Checked)
                {
                    member_view = (member_view_list.Items[i] as ComboItem).Key.ToString();
                    break;
                }

            if (member_view == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุ 'เลือกดูสมาชิก' !");
                return false;
            }

            // MEMBER_TYPE
            String member_type = String.Empty;
            for (int i = 0; i < member_type_list.Items.Count; i++)
                if (member_type_list.GetItemCheckState(i) == CheckState.Checked)
                {
                    member_type += (member_type_list.Items[i] as ComboItem).Key.ToString() + ",";
                }

            if (member_type == String.Empty)
            {
                GF.Error("ยังไม่ได้เลือก 'ประเภทสมาชิก' !");
                return false;
            }
            else
                member_type = member_type.Substring(0, member_type.Length - 1);

            if (pagination.page.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุ 'หน้าที่' !");
                pagination.page.Select();
                return false;
            }

            postParam = new Dictionary<string, string>(){
                { "branch", branch },
                { "member_view", member_view },
                { "member_type", member_type },
                { "page", pagination.page.Text.Trim() }
            };
            return true;
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            Dictionary<String, Object> Obj = DB.ReportGetTotalRecord("Member/ListMember", values);

            if (Obj != null)
            {
                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];
                pagination.resetPagination(Item["total_record"].ToString());
            }
            else
            {
                pagination.toggle(false);
                pagination.page.Text = "1";
            }

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

            DB.PerformWebNavigate("Member/ListMember", wb, values);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (wb != null) wb.ShowPrintDialog();
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            DB.WebDownload(this, "Member/ListMember", "member_list.xls", values);
        }
    }
}
