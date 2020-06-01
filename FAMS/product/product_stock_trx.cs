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
    public partial class product_stock_trx : Form
    {
        String _product_id = "";
        public product_stock_trx(String product_id)
        {
            InitializeComponent();

            _product_id = product_id;

            //PAGING DELEGATE
            btn_dgv.firstClick += doLoadGridData;
            btn_dgv.prevClick += doLoadGridData;
            btn_dgv.nextClick += doLoadGridData;
            btn_dgv.lastClick += doLoadGridData;
            btn_dgv.pageNumberChanged += doLoadGridData;

            List<dgvColumn> DGVC = new List<dgvColumn>();
            DGVC.Add(new dgvColumn("trx_datetime", "วันที่", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("ref", "อ้างอิง", DataGridViewContentAlignment.MiddleLeft));
            DGVC.Add(new dgvColumn("amount", "จำนวน"));
            DGVC.Add(new dgvColumn("trx_by", "โดย", DataGridViewContentAlignment.MiddleLeft));
            btn_dgv.initColumn(DGVC);
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            if (btn_dgv.DGV.Columns.Count == 0) return;
            getData();
        }

        void getData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "page" , btn_dgv.page.Text.Trim() },
                { "recordCount", GF.rowsPerPage.ToString() },
                { "product_id", _product_id },
                { "branch_id", GF.Settings("branch_id") }
            };

            if (trx_since.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim().Count() > 0) 
                values.Add("trx_since", trx_since.Text.Trim());
            if (trx_until.Text.Replace("_", "").Replace(" ", "").Replace("/", "").Trim().Count() > 0) 
                values.Add("trx_until", trx_until.Text.Trim());

            Dictionary<String, Object> Obj = DB.Post("Product/getProductTrx/", values);

            if (Obj != null)
            {
                btn_dgv.resetBtnDGV(Obj["total_record"].ToString());
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    btn_dgv.DGV.Rows.Add(
                        GF.formatDBDateTime(Item["trx_datetime"].ToString()),
                        (Item["ref"] ?? "").ToString(),
                        GF.formatNumber(Convert.ToInt32(Item["amount"].ToString())),
                        Item["trx_by"].ToString()
                    );
                }
                btn_dgv.DGV.ClearSelection();
            }

            GF.closeLoading();
        }

        private void trx_since_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GF.validateDateTime(trx_since))
                    getData();
            }
        }

        private void trx_since_Leave(object sender, EventArgs e)
        {
            GF.validateDateTime(trx_since);
        }

        private void trx_until_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GF.validateDateTime(trx_until))
                    getData();
            }
        }

        private void trx_until_Leave(object sender, EventArgs e)
        {
            GF.validateDateTime(trx_until);
        }
    }
}
