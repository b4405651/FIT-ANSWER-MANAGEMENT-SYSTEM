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
    public partial class change_trainer : Form
    {
        public String member_pt_id = String.Empty;
        public change_trainer()
        {
            InitializeComponent();
        }

        private void change_trainer_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "branch_id", GF.Settings("branch_id") },
                { "only_active", "1" }
            };

            Dictionary<String, Object> Obj = DB.Post("PT/PTList/", values);

            if (Obj != null)
            {
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    pt_emp_id.Items.Add(new ComboItem(GF.toInt(Item["emp_id"].ToString()), Item["fullname"].ToString() + " (" + Item["nickname"].ToString() + ")"));
                }

                pt_emp_id.SelectedIndex = 0;
                GF.resizeComboBox(pt_emp_id);
            }
            else
                GF.Error("ไม่มีข้อมูล 'เทรนเนอร์' !!\r\n\r\nกรุณาแจ้งผู้ดูแลระบบ !!");

            // GET BUY PT DATA
            if (member_pt_id != String.Empty)
            {
                values = new Dictionary<string, string>()
                {
                    { "member_pt_id" , member_pt_id.Trim() }
                };

                Obj = DB.Post("Member/getBuyPTData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    foreach (ComboItem cb in pt_emp_id.Items)
                    {
                        if (cb.Key.ToString() == Item["pt_emp_id"].ToString())
                        {
                            pt_emp_id.Text = cb.Value;
                        }
                    }
                }
                GF.closeLoading();
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "member_pt_id", member_pt_id.Trim() },
                { "pt_emp_id", ((ComboItem)pt_emp_id.SelectedItem).Key.ToString() }
            };

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Member/ChangePT/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            GF.closeLoading();

            if(this.Owner.Name == "history_buy_pt") (this.Owner as history_buy_pt).doLoadGridData(this, EventArgs.Empty);
            if (this.Owner.Name == "trainer_list_member") (this.Owner as trainer_list_member).doLoadGridData(this, EventArgs.Empty);
            this.Close();
        }
    }
}
