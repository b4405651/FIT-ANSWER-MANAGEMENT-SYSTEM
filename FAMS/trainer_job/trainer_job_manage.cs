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
    public partial class trainer_job_manage : Form
    {
        public String trainer_job_id = "";
        public Boolean isReadOnly = false;
        public trainer_job_manage()
        {
            InitializeComponent();

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "branch_id", GF.Settings("branch_id") }
            };

            Dictionary<String, Object> Obj = DB.Post("Employee/getTrainer/", values);

            if (Obj != null)
            {
                trainer_emp_id.Items.Add(new ComboItem(0, "เลือก เทรนเนอร์"));
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    trainer_emp_id.Items.Add(new ComboItem(GF.toInt(Item["trainer_emp_id"].ToString()), Item["trainer_name"].ToString()));
                }

                trainer_emp_id.SelectedIndex = 0;
                GF.resizeComboBox(trainer_emp_id);
            }
        }

        private void trainer_job_manage_Load(object sender, EventArgs e)
        {
            if (isReadOnly)
            {
                trainer_emp_id.Enabled = false;
                job_date.Enabled = false;
                start_time.Enabled = false;
                end_time.Enabled = false;
                detail.Enabled = false;
                manage_btn.Enabled = false;
            }

            if (trainer_job_id.Trim() != String.Empty)
            {
                GF.showLoading(this);

                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "trainer_job_id" , trainer_job_id.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("TrainerJob/getJobData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    foreach (ComboItem cb in trainer_emp_id.Items)
                    {
                        if (cb.Key.ToString() == Item["trainer_emp_id"].ToString())
                        {
                            trainer_emp_id.Text = cb.Value;
                            break;
                        }
                    }

                    job_date.Text = Item["job_date"].ToString();
                    start_time.Text = Item["start_time"].ToString();
                    end_time.Text = Item["end_time"].ToString();
                    detail.Text = Item["detail"].ToString();
                }
                GF.closeLoading();
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (trainer_emp_id.SelectedIndex == 0)
            {
                GF.Error("ยังไม่ได้เลือก 'เทรนเนอร์' !!");
                trainer_emp_id.Select();
                return;
            }

            if (job_date.Text.Trim().Length < 10)
            {
                GF.Error("ยังไม่ได้กรอก 'วันที่'\r\nหรือ ยังกรอกไม่ครบ !!");
                job_date.Select();
                return;
            }

            if (start_time.Text.Trim().Length < 5)
            {
                GF.Error("ยังไม่ได้กรอก 'เวลาเริ่มต้น'\r\nหรือ ยังกรอกไม่ครบ !!");
                start_time.Select();
                return;
            }

            if (end_time.Text.Trim().Length < 5)
            {
                GF.Error("ยังไม่ได้กรอก 'เวลาสิ้นสุด'\r\nหรือ ยังกรอกไม่ครบ !!");
                end_time.Select();
                return;
            }

            if (detail.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้กรอก 'รายละเอียด' !!");
                detail.Select();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "trainer_emp_id", (trainer_emp_id.SelectedItem as ComboItem).Key.ToString() },
                { "job_date", job_date.Text.Trim() },
                { "start_time", start_time.Text.Trim() },
                { "end_time", end_time.Text.Trim() },
                { "detail", detail.Text.Trim() },
                { "create_by", GF.userID }
            };

            if (trainer_job_id != String.Empty) values.Add("trainer_job_id", trainer_job_id);

            GF.showLoading(this);
            Dictionary<String, Object> result = DB.Post("TrainerJob/manageJob/", values);

            if (result == null)
            {
                GF.Error("เกิดความผิดพลาด !!");
                GF.closeLoading();
                return;
            }

            ((trainer_job_list)this.Owner).getData();
            this.Close();
        }

        private void job_date_Leave(object sender, EventArgs e)
        {
            GF.validateDateTime(job_date);
        }

        private void start_time_Leave(object sender, EventArgs e)
        {
            GF.validateTime(start_time);
        }

        private void end_time_Leave(object sender, EventArgs e)
        {
            GF.validateTime(end_time);
        }
    }
}
