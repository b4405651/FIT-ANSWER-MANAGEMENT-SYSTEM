namespace FAMS
{
    partial class member
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member));
            this.btn_panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.branch_id = new System.Windows.Forms.ComboBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.filter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.ComboBox();
            this.search_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dgv = new FAMS.User_Control.btn_dgv();
            this.btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_panel
            // 
            this.btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_panel.Controls.Add(this.label4);
            this.btn_panel.Controls.Add(this.branch_id);
            this.btn_panel.Controls.Add(this.add_btn);
            this.btn_panel.Controls.Add(this.label3);
            this.btn_panel.Controls.Add(this.filter);
            this.btn_panel.Controls.Add(this.label2);
            this.btn_panel.Controls.Add(this.gender);
            this.btn_panel.Controls.Add(this.search_txt);
            this.btn_panel.Controls.Add(this.label1);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(1152, 43);
            this.btn_panel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "ข้อมูลสาขา :";
            // 
            // branch_id
            // 
            this.branch_id.BackColor = System.Drawing.Color.LightYellow;
            this.branch_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branch_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.branch_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.branch_id.ForeColor = System.Drawing.Color.DodgerBlue;
            this.branch_id.FormattingEnabled = true;
            this.branch_id.Location = new System.Drawing.Point(113, 7);
            this.branch_id.Name = "branch_id";
            this.branch_id.Size = new System.Drawing.Size(141, 37);
            this.branch_id.TabIndex = 6;
            this.branch_id.SelectedIndexChanged += new System.EventHandler(this.branch_id_SelectedIndexChanged);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.add_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.add_btn.ForeColor = System.Drawing.Color.White;
            this.add_btn.Location = new System.Drawing.Point(998, 0);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(152, 41);
            this.add_btn.TabIndex = 4;
            this.add_btn.Text = "เพิ่มสมาชิกใหม่";
            this.add_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(715, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "แสดงสมาชิก :";
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.LightYellow;
            this.filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.filter.ForeColor = System.Drawing.Color.DodgerBlue;
            this.filter.FormattingEnabled = true;
            this.filter.Items.AddRange(new object[] {
            "ทั้งหมด",
            "ยังไม่หมดอายุ",
            "หมดอายุ",
            "ยังไม่ถึงวันเริ่มต้น",
            "ไม่มีรหัสสมาชิก"});
            this.filter.Location = new System.Drawing.Point(824, 7);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(141, 37);
            this.filter.TabIndex = 3;
            this.filter.SelectedIndexChanged += new System.EventHandler(this.filter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(553, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "เพศ :";
            // 
            // gender
            // 
            this.gender.BackColor = System.Drawing.Color.LightYellow;
            this.gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gender.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gender.FormattingEnabled = true;
            this.gender.Items.AddRange(new object[] {
            "ทั้งหมด",
            "ชาย",
            "หญิง"});
            this.gender.Location = new System.Drawing.Point(600, 7);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(100, 37);
            this.gender.TabIndex = 2;
            this.gender.SelectedIndexChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // search_txt
            // 
            this.search_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.search_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.search_txt.Location = new System.Drawing.Point(339, 7);
            this.search_txt.Name = "search_txt";
            this.search_txt.Size = new System.Drawing.Size(203, 35);
            this.search_txt.TabIndex = 1;
            this.search_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.search_txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(279, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ค้นหา :";
            // 
            // btn_dgv
            // 
            this.btn_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_dgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dgv.Location = new System.Drawing.Point(0, 43);
            this.btn_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(1152, 668);
            this.btn_dgv.TabIndex = 5;
            // 
            // member
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1152, 711);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.btn_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "member";
            this.Text = "member";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox filter;
        public User_Control.btn_dgv btn_dgv;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox branch_id;
    }
}