namespace FAMS
{
    partial class trainer_job_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trainer_job_list));
            this.btn_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.until = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.since = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.trainer_emp_id = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.add_btn = new System.Windows.Forms.Button();
            this.search_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dgv = new FAMS.User_Control.btn_dgv();
            this.btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_panel
            // 
            this.btn_panel.BackColor = System.Drawing.Color.LightCyan;
            this.btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_panel.Controls.Add(this.label2);
            this.btn_panel.Controls.Add(this.until);
            this.btn_panel.Controls.Add(this.label4);
            this.btn_panel.Controls.Add(this.label33);
            this.btn_panel.Controls.Add(this.since);
            this.btn_panel.Controls.Add(this.label9);
            this.btn_panel.Controls.Add(this.trainer_emp_id);
            this.btn_panel.Controls.Add(this.label3);
            this.btn_panel.Controls.Add(this.add_btn);
            this.btn_panel.Controls.Add(this.search_txt);
            this.btn_panel.Controls.Add(this.label1);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(852, 77);
            this.btn_panel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(513, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 123;
            this.label2.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // until
            // 
            this.until.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.until.ForeColor = System.Drawing.Color.DodgerBlue;
            this.until.Location = new System.Drawing.Point(407, 39);
            this.until.Mask = "00/00/0000";
            this.until.Name = "until";
            this.until.Size = new System.Drawing.Size(100, 26);
            this.until.TabIndex = 5;
            this.until.Tag = "วันเดือนปีเกิด";
            this.until.ValidatingType = typeof(System.DateTime);
            this.until.KeyUp += new System.Windows.Forms.KeyEventHandler(this.until_KeyUp);
            this.until.Leave += new System.EventHandler(this.until_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(314, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 122;
            this.label4.Text = "จนถึงวันที่ : ";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(513, 10);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(143, 20);
            this.label33.TabIndex = 120;
            this.label33.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // since
            // 
            this.since.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.since.ForeColor = System.Drawing.Color.DodgerBlue;
            this.since.Location = new System.Drawing.Point(407, 7);
            this.since.Mask = "00/00/0000";
            this.since.Name = "since";
            this.since.Size = new System.Drawing.Size(100, 26);
            this.since.TabIndex = 4;
            this.since.Tag = "วันเดือนปีเกิด";
            this.since.ValidatingType = typeof(System.DateTime);
            this.since.KeyUp += new System.Windows.Forms.KeyEventHandler(this.since_KeyUp);
            this.since.Leave += new System.EventHandler(this.since_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(314, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 119;
            this.label9.Text = "ตั้งแต่วันที่ : ";
            // 
            // trainer_emp_id
            // 
            this.trainer_emp_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainer_emp_id.FormattingEnabled = true;
            this.trainer_emp_id.ItemHeight = 20;
            this.trainer_emp_id.Location = new System.Drawing.Point(112, 39);
            this.trainer_emp_id.Name = "trainer_emp_id";
            this.trainer_emp_id.Size = new System.Drawing.Size(172, 28);
            this.trainer_emp_id.TabIndex = 117;
            this.trainer_emp_id.SelectedIndexChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 116;
            this.label3.Text = "เทรนเนอร์ : ";
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.add_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.add_btn.ForeColor = System.Drawing.Color.White;
            this.add_btn.Location = new System.Drawing.Point(679, 0);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(171, 75);
            this.add_btn.TabIndex = 6;
            this.add_btn.Text = "เพิ่มงานเทรนเนอร์";
            this.add_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // search_txt
            // 
            this.search_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.search_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.search_txt.Location = new System.Drawing.Point(72, 7);
            this.search_txt.Name = "search_txt";
            this.search_txt.Size = new System.Drawing.Size(212, 26);
            this.search_txt.TabIndex = 2;
            this.search_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.search_txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ค้นหา :";
            // 
            // btn_dgv
            // 
            this.btn_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_dgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dgv.Location = new System.Drawing.Point(0, 77);
            this.btn_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(852, 326);
            this.btn_dgv.TabIndex = 7;
            // 
            // trainer_job
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 403);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.btn_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "trainer_job";
            this.Text = "trainer_job";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.Label label1;
        public User_Control.btn_dgv btn_dgv;
        private System.Windows.Forms.ComboBox trainer_emp_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox since;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox until;
        private System.Windows.Forms.Label label4;
    }
}