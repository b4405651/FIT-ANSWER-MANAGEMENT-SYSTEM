using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class user_manage : Form
    {
        public string user_id = "";
        public user_manage()
        {
            InitializeComponent();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Branch/BranchList/", values);

            if (Obj != null)
            {
                branch_TreeView.Nodes.Add("-1", "ทุกสาขา");
                foreach (Dictionary<String, Object> Branch in (Array)Obj["result"])
                {
                    branch_TreeView.Nodes.Add(Branch["branch_id"].ToString(), Branch["branch_name"].ToString());
                }
            }

            branch_TreeView.ExpandAll();

            values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Obj = DB.Post("User/getMenu/", values);

            if (Obj != null)
            {
                menu_TreeView.Nodes.Add("-1", "ทุกเมนู");
                foreach (Dictionary<String, Object> menu in (Array)Obj["result"]) // 1st level
                {
                    menu_TreeView.Nodes.Add(menu["menu_id"].ToString(), menu["menu_name"].ToString());
                }
            }

            menu_TreeView.ExpandAll();

            values = new Dictionary<string, string>()
            {
                { "user_id", GF.userID }
            };

            Obj = DB.Post("User/getWebMenu/", values);

            if (Obj != null)
            {
                web_TreeView.Nodes.Add("-1", "ทุกเมนู");
                foreach (Dictionary<String, Object> menu in (Array)Obj["result"]) // 1st level
                {
                    web_TreeView.Nodes.Add(menu["menu_web_id"].ToString(), menu["menu_web_name"].ToString());
                }
            }

            web_TreeView.ExpandAll();

            web_TreeView.Enabled = false;
        }

        private void user_manage_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "branch_id", GF.Settings("branch_id") }
            };

            if(user_id != String.Empty) values.Add("user_id", user_id);

            Dictionary<String, Object> Obj = DB.Post("User/getUserOwner/", values);

            if (Obj != null)
            {
                emp_id.Items.Add(new ComboItem(0, "เลือก พนักงานเจ้าของบัญชี"));
                emp_id.Items.Add(new ComboItem(-1, "ไม่ใช่พนักงาน"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    emp_id.Items.Add(new ComboItem(Convert.ToInt32(Item["emp_id"].ToString()), Item["owner_name"].ToString()));
                }
            } else
                emp_id.Items.Add(new ComboItem(0, "เกิดความผิดพลาด !!"));

            emp_id.SelectedIndex = 0;

            if (user_id != String.Empty)
            {
                values = new Dictionary<string, string>()
                {
                    { "user_id" , user_id.Trim() }
                };

                Obj = DB.Post("User/getUserData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    username.Text = Item["username"].ToString();
                    manual_owner_name.Text = (Item["manual_owner_name"] ?? "").ToString();
                    if (Item["is_admin"].ToString() == "1")
                        is_admin.Checked = true;

                    if (Item["can_approve"].ToString() == "1")
                        can_approve.Checked = true;

                    if (Item["can_use_web"].ToString() == "1")
                    {
                        can_use_web.Checked = true;
                        web_TreeView.Enabled = true;
                    }
                    else
                    {
                        web_TreeView.Enabled = false;
                    }

                    foreach (ComboItem cb in emp_id.Items)
                    {
                        if (cb.Key.ToString() == Item["emp_id"].ToString())
                        {
                            emp_id.Text = cb.Value;
                            break;
                        }
                    }

                    String[] BranchList = Item["branch_list"].ToString().Split(new String[] { "!!" }, StringSplitOptions.None);
                    foreach (String Branch in BranchList)
                    {
                        TreeNode[] Nodes = branch_TreeView.Nodes.Find(Branch, true);
                        if(Nodes.Count() == 1)
                            Nodes[0].Checked = true;
                    }

                    String[] MenuList = Item["menu_list"].ToString().Split(new String[] { "!!" }, StringSplitOptions.None);
                    foreach (String Menu in MenuList)
                    {
                        TreeNode[] Nodes = menu_TreeView.Nodes.Find(Menu, true);
                        if (Nodes.Count() == 1)
                            Nodes[0].Checked = true;
                    }

                    String[] MenuWebList = Item["menu_web_list"].ToString().Split(new String[] { "!!" }, StringSplitOptions.None);
                    foreach (String Menu in MenuWebList)
                    {
                        TreeNode[] Nodes = web_TreeView.Nodes.Find(Menu, true);
                        if (Nodes.Count() == 1)
                            Nodes[0].Checked = true;
                    }
                }
            }
            GF.closeLoading();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (username.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อผู้ใช้งาน' !!");
                username.Select();
                return;
            }

            if(username.Text.ToLower().Trim().IndexOf("admin") > -1)
            {
                GF.Error("'ชื่อผู้ใช้งาน' ห้ามมีคำว่า 'admin' !!");
                username.Select();
                return;
            }

            if (user_id.Trim() == String.Empty && password.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'รหัสผ่าน' !!");
                password.Select();
                return;
            }

            if (password.Text.Trim() != String.Empty && verify_password.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ยืนยันรหัสผ่าน' !!");
                verify_password.Select();
                return;
            }

            if (password.Text.Trim() != String.Empty && verify_password.Text.Trim() != password.Text.Trim())
            {
                GF.Error("'ยืนยันรหัสผ่าน' ที่กรอกไม่ตรงกับ 'รหัสผ่าน' !!");
                verify_password.Select();
                return;
            }

            if (emp_id.SelectedIndex == 0)
            {
                GF.Error("กรุณาเลือก 'พนักงานเจ้าของบัญชี' !!");
                emp_id.Select();
                return;
            }

            if (((ComboItem)emp_id.SelectedItem).Key == -1 && manual_owner_name.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'เจ้าของบัญชี ( หากไม่ใช่พนักงาน )' !!");
                manual_owner_name.Select();
                return;
            }

            String branch_list = "";
            foreach (TreeNode node in branch_TreeView.Nodes)
                if (node.Checked)
                    branch_list += node.Name + "!!";

            if (branch_list.Trim() == String.Empty)
            {
                GF.Error("กรุณาเลือก 'สาขา' !!");
                return;
            }
            else
                branch_list = branch_list.Substring(0, branch_list.Length - 2);

            String menu_list = "";
            foreach (TreeNode node in menu_TreeView.Nodes)
                if (node.Checked)
                    menu_list += node.Name + "!!";

            if (menu_list.Trim() == String.Empty)
            {
                GF.Error("กรุณาเลือกกำหนดสิทธิ์การใช้โปรแกรม !!");
                return;
            }
            else
                menu_list = menu_list.Substring(0, menu_list.Length - 2);

            String menu_web_list = "";
            if (can_use_web.Checked)
            {
                foreach (TreeNode node in web_TreeView.Nodes)
                    if (node.Checked)
                        menu_web_list += node.Name + "!!";

                if (menu_web_list.Trim() == String.Empty)
                {
                    GF.Error("กรุณาเลือกกำหนดสิทธิ์การใช้ web report !!");
                    return;
                }
                else
                    menu_web_list = menu_web_list.Substring(0, menu_web_list.Length - 2);
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "username", username.Text.Trim() },
                { "is_admin", (is_admin.Checked ? "1" : "0") },
                { "can_approve", (can_approve.Checked ? "1" : "0") },
                { "can_use_web", (can_use_web.Checked ? "1" : "0") },
                { "branch_list", branch_list },
                { "menu_list", menu_list },
                { "menu_web_list", menu_web_list },
                { "emp_id", ((ComboItem)emp_id.SelectedItem).Key.ToString() },
                { "last_modified_by", GF.userID }
            };

            if (manual_owner_name.Enabled)
                values.Add("manual_owner_name", manual_owner_name.Text);
            else
                values.Add("manual_owner_name", null);

            if (user_id == String.Empty) values.Add("password", password.Text.Trim());
            else if (password.Text.Trim() != String.Empty && password.Text.Trim() == verify_password.Text.Trim())
                values.Add("password", password.Text.Trim());
            if (user_id != String.Empty) values.Add("user_id", user_id);

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("User/manageUser/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            ((user)this.Owner).getData();
            this.Close();
        }

        private void menu_TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "-1")
            {
                if (e.Node.Checked)
                    foreach (TreeNode node in menu_TreeView.Nodes)
                        if (node.Name != "-1")
                            node.Checked = false;
            }
            else
            {
                if (e.Node.Checked)
                    menu_TreeView.Nodes[0].Checked = false;
            }
        }

        private void branch_TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "-1")
            {
                if (e.Node.Checked)
                    foreach (TreeNode node in branch_TreeView.Nodes)
                        if (node.Name != "-1")
                            node.Checked = false;
            }
            else
            {
                if (e.Node.Checked)
                    branch_TreeView.Nodes[0].Checked = false;
            }
        }

        private void web_TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "-1")
            {
                if (e.Node.Checked)
                    foreach (TreeNode node in web_TreeView.Nodes)
                        if (node.Name != "-1")
                            node.Checked = false;
            }
            else
            {
                if (e.Node.Checked)
                    web_TreeView.Nodes[0].Checked = false;
            }
        }

        private void emp_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            manual_owner_name.Enabled = (((ComboItem)emp_id.SelectedItem).Key == -1);
        }

        private void can_use_web_CheckedChanged(object sender, EventArgs e)
        {
            web_TreeView.Enabled = can_use_web.Checked;
            if (!can_use_web.Checked)
            {
                foreach (TreeNode node in web_TreeView.Nodes)
                    node.Checked = false;
            }
        }
    }
}