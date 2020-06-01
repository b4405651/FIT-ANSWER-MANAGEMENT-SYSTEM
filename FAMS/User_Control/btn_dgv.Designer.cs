namespace FAMS.User_Control
{
    partial class btn_dgv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.DGV_panel = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.pagination_panel.SuspendLayout();
            this.DGV_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
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
            this.pagination_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagination_panel.Location = new System.Drawing.Point(0, 428);
            this.pagination_panel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pagination_panel.Name = "pagination_panel";
            this.pagination_panel.Size = new System.Drawing.Size(1500, 55);
            this.pagination_panel.TabIndex = 0;
            this.pagination_panel.Resize += new System.EventHandler(this.pagination_panel_Resize);
            // 
            // max_page
            // 
            this.max_page.AutoSize = true;
            this.max_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.max_page.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(0)))));
            this.max_page.Location = new System.Drawing.Point(586, 10);
            this.max_page.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.max_page.Name = "max_page";
            this.max_page.Size = new System.Drawing.Size(27, 29);
            this.max_page.TabIndex = 19;
            this.max_page.Text = "1";
            // 
            // page_sep_lbl
            // 
            this.page_sep_lbl.AutoSize = true;
            this.page_sep_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.page_sep_lbl.Location = new System.Drawing.Point(552, 10);
            this.page_sep_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.page_sep_lbl.Name = "page_sep_lbl";
            this.page_sep_lbl.Size = new System.Drawing.Size(21, 29);
            this.page_sep_lbl.TabIndex = 18;
            this.page_sep_lbl.Text = "/";
            // 
            // total_record
            // 
            this.total_record.AutoSize = true;
            this.total_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.total_record.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(0)))));
            this.total_record.Location = new System.Drawing.Point(1247, 10);
            this.total_record.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.total_record.Name = "total_record";
            this.total_record.Size = new System.Drawing.Size(27, 29);
            this.total_record.TabIndex = 17;
            this.total_record.Text = "1";
            // 
            // total_record_lbl
            // 
            this.total_record_lbl.AutoSize = true;
            this.total_record_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.total_record_lbl.Location = new System.Drawing.Point(1080, 10);
            this.total_record_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.total_record_lbl.Name = "total_record_lbl";
            this.total_record_lbl.Size = new System.Drawing.Size(154, 29);
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
            this.last_btn.Location = new System.Drawing.Point(850, 3);
            this.last_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.last_btn.Name = "last_btn";
            this.last_btn.Size = new System.Drawing.Size(173, 41);
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
            this.next_btn.Location = new System.Drawing.Point(678, 3);
            this.next_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(147, 41);
            this.next_btn.TabIndex = 14;
            this.next_btn.Text = "หน้าถัดไป >";
            this.next_btn.UseVisualStyleBackColor = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // page
            // 
            this.page.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.page.ForeColor = System.Drawing.Color.DodgerBlue;
            this.page.Location = new System.Drawing.Point(476, 5);
            this.page.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(64, 35);
            this.page.TabIndex = 13;
            this.page.Text = "1";
            this.page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.page.TextChanged += new System.EventHandler(this.page_TextChanged);
            this.page.Enter += new System.EventHandler(this.page_Enter);
            this.page.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.page_KeyPress);
            this.page.KeyUp += new System.Windows.Forms.KeyEventHandler(this.page_KeyUp);
            this.page.Leave += new System.EventHandler(this.page_Leave);
            // 
            // page_lbl
            // 
            this.page_lbl.AutoSize = true;
            this.page_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.page_lbl.Location = new System.Drawing.Point(366, 10);
            this.page_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.page_lbl.Name = "page_lbl";
            this.page_lbl.Size = new System.Drawing.Size(86, 29);
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
            this.prev_btn.Location = new System.Drawing.Point(177, 3);
            this.prev_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(148, 41);
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
            this.first_btn.Size = new System.Drawing.Size(150, 41);
            this.first_btn.TabIndex = 10;
            this.first_btn.Text = "<< หน้าแรก";
            this.first_btn.UseVisualStyleBackColor = false;
            this.first_btn.Click += new System.EventHandler(this.first_btn_Click);
            // 
            // DGV_panel
            // 
            this.DGV_panel.Controls.Add(this.DGV);
            this.DGV_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_panel.Location = new System.Drawing.Point(0, 0);
            this.DGV_panel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DGV_panel.Name = "DGV_panel";
            this.DGV_panel.Size = new System.Drawing.Size(1500, 428);
            this.DGV_panel.TabIndex = 1;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.LightYellow;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(1500, 428);
            this.DGV.TabIndex = 0;
            this.DGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DGV_RowPrePaint);
            this.DGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGV_RowsAdded);
            this.DGV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyUp);
            this.DGV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DGV_MouseUp);
            // 
            // btn_dgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV_panel);
            this.Controls.Add(this.pagination_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "btn_dgv";
            this.Size = new System.Drawing.Size(1500, 483);
            this.pagination_panel.ResumeLayout(false);
            this.pagination_panel.PerformLayout();
            this.DGV_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
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
        private System.Windows.Forms.Panel DGV_panel;
        public System.Windows.Forms.DataGridView DGV;
    }
}
