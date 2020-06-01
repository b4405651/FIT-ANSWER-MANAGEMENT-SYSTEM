namespace FAMS.User_Control
{
    partial class report_pagination
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pagination_panel = new System.Windows.Forms.Panel();
            this.max_page = new System.Windows.Forms.Label();
            this.page_sep_lbl = new System.Windows.Forms.Label();
            this.total_record = new System.Windows.Forms.Label();
            this.total_record_lbl = new System.Windows.Forms.Label();
            this.last_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.page = new System.Windows.Forms.TextBox();
            this.page_lbl = new System.Windows.Forms.Label();
            this.prev_btn = new System.Windows.Forms.Button();
            this.first_btn = new System.Windows.Forms.Button();
            this.pagination_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagination_panel
            // 
            this.pagination_panel.BackColor = System.Drawing.Color.LightCyan;
            this.pagination_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pagination_panel.Controls.Add(this.max_page);
            this.pagination_panel.Controls.Add(this.page_sep_lbl);
            this.pagination_panel.Controls.Add(this.total_record);
            this.pagination_panel.Controls.Add(this.total_record_lbl);
            this.pagination_panel.Controls.Add(this.last_btn);
            this.pagination_panel.Controls.Add(this.next_btn);
            this.pagination_panel.Controls.Add(this.page);
            this.pagination_panel.Controls.Add(this.page_lbl);
            this.pagination_panel.Controls.Add(this.prev_btn);
            this.pagination_panel.Controls.Add(this.first_btn);
            this.pagination_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagination_panel.Location = new System.Drawing.Point(0, 0);
            this.pagination_panel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pagination_panel.Name = "pagination_panel";
            this.pagination_panel.Size = new System.Drawing.Size(849, 41);
            this.pagination_panel.TabIndex = 1;
            this.pagination_panel.Resize += new System.EventHandler(this.pagination_panel_Resize);
            // 
            // max_page
            // 
            this.max_page.AutoSize = true;
            this.max_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.max_page.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(0)))));
            this.max_page.Location = new System.Drawing.Point(397, 9);
            this.max_page.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.max_page.Name = "max_page";
            this.max_page.Size = new System.Drawing.Size(19, 20);
            this.max_page.TabIndex = 19;
            this.max_page.Text = "0";
            // 
            // page_sep_lbl
            // 
            this.page_sep_lbl.AutoSize = true;
            this.page_sep_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.page_sep_lbl.Location = new System.Drawing.Point(371, 11);
            this.page_sep_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.page_sep_lbl.Name = "page_sep_lbl";
            this.page_sep_lbl.Size = new System.Drawing.Size(14, 20);
            this.page_sep_lbl.TabIndex = 18;
            this.page_sep_lbl.Text = "/";
            // 
            // total_record
            // 
            this.total_record.AutoSize = true;
            this.total_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.total_record.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(0)))));
            this.total_record.Location = new System.Drawing.Point(809, 9);
            this.total_record.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.total_record.Name = "total_record";
            this.total_record.Size = new System.Drawing.Size(19, 20);
            this.total_record.TabIndex = 17;
            this.total_record.Text = "0";
            // 
            // total_record_lbl
            // 
            this.total_record_lbl.AutoSize = true;
            this.total_record_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.total_record_lbl.Location = new System.Drawing.Point(689, 9);
            this.total_record_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.total_record_lbl.Name = "total_record_lbl";
            this.total_record_lbl.Size = new System.Drawing.Size(108, 20);
            this.total_record_lbl.TabIndex = 16;
            this.total_record_lbl.Text = "ข้อมูลทั้งหมด :";
            // 
            // last_btn
            // 
            this.last_btn.AutoSize = true;
            this.last_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.last_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.last_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.last_btn.ForeColor = System.Drawing.Color.White;
            this.last_btn.Location = new System.Drawing.Point(556, 3);
            this.last_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.last_btn.Name = "last_btn";
            this.last_btn.Size = new System.Drawing.Size(121, 32);
            this.last_btn.TabIndex = 15;
            this.last_btn.Text = "หน้าสุดท้าย >>";
            this.last_btn.UseVisualStyleBackColor = false;
            this.last_btn.Click += new System.EventHandler(this.last_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.AutoSize = true;
            this.next_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.next_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.next_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.next_btn.ForeColor = System.Drawing.Color.White;
            this.next_btn.Location = new System.Drawing.Point(452, 3);
            this.next_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(102, 32);
            this.next_btn.TabIndex = 14;
            this.next_btn.Text = "หน้าถัดไป >";
            this.next_btn.UseVisualStyleBackColor = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // page
            // 
            this.page.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.page.ForeColor = System.Drawing.Color.DodgerBlue;
            this.page.Location = new System.Drawing.Point(295, 6);
            this.page.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(64, 26);
            this.page.TabIndex = 13;
            this.page.Text = "0";
            this.page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.page.Click += new System.EventHandler(this.page_Leave);
            this.page.TextChanged += new System.EventHandler(this.page_TextChanged);
            this.page.Enter += new System.EventHandler(this.page_Enter);
            this.page.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.page_KeyPress);
            this.page.KeyUp += new System.Windows.Forms.KeyEventHandler(this.page_KeyUp);
            // 
            // page_lbl
            // 
            this.page_lbl.AutoSize = true;
            this.page_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.page_lbl.Location = new System.Drawing.Point(225, 9);
            this.page_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.page_lbl.Name = "page_lbl";
            this.page_lbl.Size = new System.Drawing.Size(58, 20);
            this.page_lbl.TabIndex = 12;
            this.page_lbl.Text = "หน้าที่ :";
            // 
            // prev_btn
            // 
            this.prev_btn.AutoSize = true;
            this.prev_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prev_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.prev_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.prev_btn.ForeColor = System.Drawing.Color.White;
            this.prev_btn.Location = new System.Drawing.Point(111, 3);
            this.prev_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(102, 32);
            this.prev_btn.TabIndex = 11;
            this.prev_btn.Text = "< หน้าที่แล้ว";
            this.prev_btn.UseVisualStyleBackColor = false;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // first_btn
            // 
            this.first_btn.AutoSize = true;
            this.first_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.first_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.first_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.first_btn.ForeColor = System.Drawing.Color.White;
            this.first_btn.Location = new System.Drawing.Point(6, 3);
            this.first_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.first_btn.Name = "first_btn";
            this.first_btn.Size = new System.Drawing.Size(102, 32);
            this.first_btn.TabIndex = 10;
            this.first_btn.Text = "<< หน้าแรก";
            this.first_btn.UseVisualStyleBackColor = false;
            this.first_btn.Click += new System.EventHandler(this.first_btn_Click);
            // 
            // report_pagination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pagination_panel);
            this.Name = "report_pagination";
            this.Size = new System.Drawing.Size(849, 41);
            this.pagination_panel.ResumeLayout(false);
            this.pagination_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pagination_panel;
        public System.Windows.Forms.Label max_page;
        private System.Windows.Forms.Label page_sep_lbl;
        public System.Windows.Forms.Label total_record;
        private System.Windows.Forms.Label total_record_lbl;
        public System.Windows.Forms.Button last_btn;
        public System.Windows.Forms.Button next_btn;
        public System.Windows.Forms.TextBox page;
        private System.Windows.Forms.Label page_lbl;
        public System.Windows.Forms.Button prev_btn;
        public System.Windows.Forms.Button first_btn;
    }
}
