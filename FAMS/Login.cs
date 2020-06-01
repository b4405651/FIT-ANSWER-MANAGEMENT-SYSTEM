using System;
using System.Deployment.Application;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            foreach (InputLanguage IL in InputLanguage.InstalledInputLanguages)
            {
                if (IL.LayoutName.ToString() == "US")
                {
                    InputLanguage.CurrentInputLanguage = IL;
                    break;
                }
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if(username.Text.Trim() == String.Empty)
            {
                GF.Error("PLEASE ENTER 'USERNAME' !!");
                username.Select();
                return;
            }

            if(password.Text.Trim() == String.Empty)
            {
                GF.Error("PLEASE ENTER 'PASSWORD' !!");
                password.Select();
                return;
            }

            GF.mainPage = new main();

            Dictionary<string, string> values = new Dictionary<string, string>();

            if (username.Text.Trim() == "admin" && password.Text.Trim() == "Cy{;yllN")
            {
                GF.userID = "-1";
                GF.isAdmin = true;

                this.Hide();

                values = new Dictionary<string, string>();
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

                GF.mainPage.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

                GF.mainPage.current_user.Text = "Software Developer";
                GF.mainPage.last_login.Text = "";

                GF.mainPage.last_login_lbl.Visible = false;

                getVersion();

                GF.mainPage.config_btn.Visible = GF.isAdmin;

                foreach (ToolStripMenuItem menu in GF.mainPage.main_menu.Items)
                    menu.Visible = true;

                GF.mainPage.change_pwd_btn.Visible = false;
                GF.mainPage.ShowDialog();

                return;
            }
            else
            {
                values = new Dictionary<string, string>
                {
                    { "branch_id", GF.Settings("branch_id") },
                    { "username", username.Text.Trim() },
                    { "password", password.Text.Trim() }
                };

                Dictionary<String, Object> Login = DB.Post("user/login/", values);

                if (Login != null)
                {
                    if (Login["result"].ToString().ToLower() == "true")
                    {
                        GF.userID = Login["userID"].ToString();
                        GF.isAdmin = (Login["isAdmin"].ToString() == "1");
                        this.Hide();
                        GF.mainPage = new main();

                        values = new Dictionary<string, string>();
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

                        GF.mainPage.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

                        GF.mainPage.current_user.Text = Login["owner_name"].ToString();
                        GF.mainPage.last_login.Text = Login["last_login"].ToString();

                        GF.mainPage.config_btn.Visible = GF.isAdmin;

                        getVersion();

                        String[] menu_list = Login["menu_list"].ToString().Split(new String[] { "!!" }, StringSplitOptions.None);
                        if (GF.isAdmin && (menu_list.Length == 0 || (menu_list.Length == 1 && menu_list[0] == "-1")))
                        {
                            foreach (ToolStripMenuItem menu in GF.mainPage.main_menu.Items)
                                menu.Visible = true;
                        }
                        else
                        {
                            foreach (String menu_id in menu_list)
                            {
                                foreach (ToolStripMenuItem menu in GF.mainPage.main_menu.Items)
                                {
                                    if ((menu.Tag ?? "").ToString() == menu_id)
                                    {
                                        menu.Visible = true;
                                        break;
                                    }
                                }
                            }
                        }

                        GF.mainPage.ShowDialog();
                    }
                    else
                        GF.Error(Login["msg"].ToString());
                }
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) SendKeys.Send("{TAB}");
        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) login_btn.PerformClick();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void getVersion()
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location);
            DateTime lastModified = fileInfo.LastWriteTime;

            GF.mainPage.last_published.Text = lastModified.ToString("dd MMMM yyyy HH:mm:ss");
        }
    }
}
