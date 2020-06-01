namespace FAMS
{
    partial class trainer_job_manage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trainer_job_manage));
            this.trainer_emp_id = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.job_date = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.start_time = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.end_time = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.detail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trainer_emp_id
            // 
            this.trainer_emp_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainer_emp_id.FormattingEnabled = true;
            this.trainer_emp_id.Location = new System.Drawing.Point(112, 6);
            this.trainer_emp_id.Name = "trainer_emp_id";
            this.trainer_emp_id.Size = new System.Drawing.Size(172, 28);
            this.trainer_emp_id.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 118;
            this.label3.Text = "เทรนเนอร์ : ";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(221, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(143, 20);
            this.label33.TabIndex = 123;
            this.label33.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // job_date
            // 
            this.job_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.job_date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.job_date.Location = new System.Drawing.Point(115, 40);
            this.job_date.Mask = "00/00/0000";
            this.job_date.Name = "job_date";
            this.job_date.Size = new System.Drawing.Size(100, 26);
            this.job_date.TabIndex = 2;
            this.job_date.Tag = "วันเดือนปีเกิด";
            this.job_date.ValidatingType = typeof(System.DateTime);
            this.job_date.Leave += new System.EventHandler(this.job_date_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 122;
            this.label9.Text = "งานในวันที่ : ";
            // 
            // start_time
            // 
            this.start_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.start_time.ForeColor = System.Drawing.Color.DodgerBlue;
            this.start_time.Location = new System.Drawing.Point(115, 72);
            this.start_time.Mask = "00:00";
            this.start_time.Name = "start_time";
            this.start_time.Size = new System.Drawing.Size(51, 26);
            this.start_time.TabIndex = 3;
            this.start_time.Tag = "วันเดือนปีเกิด";
            this.start_time.ValidatingType = typeof(System.DateTime);
            this.start_time.Leave += new System.EventHandler(this.start_time_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 125;
            this.label1.Text = "เวลาเริ่มต้น : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(172, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 126;
            this.label2.Text = "( ตัวอย่าง : 22:59 )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(172, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 129;
            this.label4.Text = "( ตัวอย่าง : 22:59 )";
            // 
            // end_time
            // 
            this.end_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.end_time.ForeColor = System.Drawing.Color.DodgerBlue;
            this.end_time.Location = new System.Drawing.Point(115, 104);
            this.end_time.Mask = "00:00";
            this.end_time.Name = "end_time";
            this.end_time.Size = new System.Drawing.Size(51, 26);
            this.end_time.TabIndex = 4;
            this.end_time.Tag = "วันเดือนปีเกิด";
            this.end_time.ValidatingType = typeof(System.DateTime);
            this.end_time.Leave += new System.EventHandler(this.end_time_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "เวลาสิ้นสุด : ";
            // 
            // detail
            // 
            this.detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.detail.ForeColor = System.Drawing.Color.DodgerBlue;
            this.detail.Location = new System.Drawing.Point(115, 136);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(346, 26);
            this.detail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 130;
            this.label6.Text = "รายละเอียด :";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.Green;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(16, 168);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(104, 42);
            this.manage_btn.TabIndex = 6;
            this.manage_btn.Text = "บันทึก";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // trainer_job_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 221);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.end_time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.job_date);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trainer_emp_id);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "trainer_job_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลงานเทรนเนอร์";
            this.Load += new System.EventHandler(this.trainer_job_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox trainer_emp_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox job_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox start_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox end_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox detail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button manage_btn;
    }
}