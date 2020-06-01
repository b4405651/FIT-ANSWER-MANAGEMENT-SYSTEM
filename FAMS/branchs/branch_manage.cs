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
    public partial class branch_manage : Form
    {
        public String branch_id = "";
        public branch_manage()
        {
            InitializeComponent();
        }

        private void branch_manage_Load(object sender, EventArgs e)
        {
            if (branch_id != String.Empty)
            {
                GF.showLoading(this);

                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "branch_id" , branch_id.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("Branch/getBranchData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    branch_name.Text = Item["branch_name"].ToString();
                    prefix.Text = Item["prefix"].ToString();
                    company_name.Text = Item["company_name"].ToString();
                    address.Text = Item["address"].ToString();
                    tax_id.Text = Item["tax_id"].ToString();
                }
                GF.closeLoading();
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (branch_name.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อเต็ม สาขา' !!");
                branch_name.Select();
                return;
            }

            if (prefix.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ตัวย่อ' !!");
                prefix.Select();
                return;
            }

            if (company_name.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ชื่อบริษัท' !!");
                company_name.Select();
                return;
            }

            if (address.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'ที่อยู่' !!");
                address.Select();
                return;
            }

            if (tax_id.Text.Trim() == String.Empty)
            {
                GF.Error("กรุณากรอก 'เลขประจำตัวผู้เสียภาษี' !!");
                tax_id.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "branch_name", branch_name.Text.Trim() },
                { "prefix", prefix.Text.Trim() },
                { "company_name", company_name.Text.Trim() },
                { "address", address.Text.Trim() },
                { "tax_id", tax_id.Text.Trim() }
            };

            if (branch_id != String.Empty) values.Add("branch_id", branch_id);

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("Branch/manageBranch/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            ((branch)this.Owner).getData();
            this.Close();
        }
    }
}
