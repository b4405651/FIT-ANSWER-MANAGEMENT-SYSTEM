﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS.Report.PT
{
    public partial class training : Form
    {
        Boolean isReady = true;
        webBrowser wb;
        public training()
        {
            InitializeComponent();

            //PAGING DELEGATE
            pagination.firstClick += manage_btn_Click;
            pagination.prevClick += manage_btn_Click;
            pagination.nextClick += manage_btn_Click;
            pagination.lastClick += manage_btn_Click;
            pagination.pageNumberChanged += manage_btn_Click;

            branch_list.ItemCheck -= branch_list_ItemCheck;

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

            start_date.Text = end_date.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + (DateTime.Now.Year + 543).ToString("0000");

            branch_list.ItemCheck += branch_list_ItemCheck;

            get_trainer();

            wb = new webBrowser(wb_panel); wb.DocumentText = "<center style='font-size: 24px; font-family:\'Tahoma\'; height: 100%; valign: middle;'><b><u>รายงาน การเทรน</u></b></center>";
        }

        private void branch_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                GF.showLoading(this);
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
                this.BeginInvoke((MethodInvoker)(() => get_trainer()));
                GF.closeLoading();
            }
        }

        private void get_trainer()
        {
            pt_emp_id.Items.Clear();
            pt_emp_id.Items.Add(new ComboItem(0, "เลือก เทรนเนอร์"));

            String branch_id = String.Empty;
            foreach (var item in branch_list.CheckedItems)
            {
                branch_id += (item as ComboItem).Key.ToString() + ",";
            }
            
            if (branch_id != String.Empty)
            {
                branch_id = branch_id.Substring(0, branch_id.Length - 1);
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("branch_id", branch_id);

                Dictionary<String, Object> Obj = DB.Post("Employee/getTrainer/", values);

                if (Obj != null)
                {
                    foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                    {
                        pt_emp_id.Items.Add(new ComboItem(GF.toInt(Item["trainer_emp_id"].ToString()), Item["trainer_name"].ToString()));
                    }
                }
            }
            pt_emp_id.SelectedIndex = 0;
            GF.resizeComboBox(pt_emp_id);
        }

        Boolean validate(out Dictionary<string, string> postParam)
        {
            postParam = null;

            if (pt_emp_id.SelectedIndex == 0)
            {
                GF.Error("ยังไม่ได้เลือก 'เทรนเนอร์' !");
                pt_emp_id.Select();
                return false;
            }

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

            if (!GF.validateDateTime(start_date)) return false;
            if (!GF.validateDateTime(end_date)) return false;

            if (pagination.page.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุ 'หน้าที่' !");
                pagination.page.Select();
                return false;
            }

            postParam = new Dictionary<string, string>(){
                { "branch", branch },
                { "pt_emp_id", (pt_emp_id.SelectedItem as ComboItem).Key.ToString() },
                { "start_date", start_date.Text },
                { "end_date", end_date.Text },
                { "page", pagination.page.Text.Trim() }
            };
            return true;
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            Dictionary<String, Object> Obj = DB.ReportGetTotalRecord("PT/Training", values);

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

            DB.PerformWebNavigate("PT/Training", wb, values);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (wb != null) wb.ShowPrintDialog();
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = null;
            if (!validate(out values)) return;

            DB.WebDownload(this, "PT/Training", "pt_training.xls", values);
        }
    }
}
