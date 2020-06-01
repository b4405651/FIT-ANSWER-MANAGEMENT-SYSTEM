namespace FAMS.Report.Stock
{
    partial class transaction
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
            this.filter_panel = new System.Windows.Forms.Panel();
            this.product_id = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.excel_btn = new System.Windows.Forms.Button();
            this.print_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.branch_list = new System.Windows.Forms.CheckedListBox();
            this.wb_panel = new System.Windows.Forms.Panel();
            this.pagination = new FAMS.User_Control.report_pagination();
            this.filter_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filter_panel
            // 
            this.filter_panel.BackColor = System.Drawing.Color.LightCyan;
            this.filter_panel.Controls.Add(this.product_id);
            this.filter_panel.Controls.Add(this.label4);
            this.filter_panel.Controls.Add(this.label3);
            this.filter_panel.Controls.Add(this.excel_btn);
            this.filter_panel.Controls.Add(this.print_btn);
            this.filter_panel.Controls.Add(this.manage_btn);
            this.filter_panel.Controls.Add(this.label1);
            this.filter_panel.Controls.Add(this.end_date);
            this.filter_panel.Controls.Add(this.label2);
            this.filter_panel.Controls.Add(this.label33);
            this.filter_panel.Controls.Add(this.start_date);
            this.filter_panel.Controls.Add(this.label9);
            this.filter_panel.Controls.Add(this.branch_list);
            this.filter_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter_panel.Location = new System.Drawing.Point(0, 0);
            this.filter_panel.Name = "filter_panel";
            this.filter_panel.Size = new System.Drawing.Size(1370, 120);
            this.filter_panel.TabIndex = 0;
            // 
            // product_id
            // 
            this.product_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.product_id.FormattingEnabled = true;
            this.product_id.Location = new System.Drawing.Point(260, 3);
            this.product_id.Name = "product_id";
            this.product_id.Size = new System.Drawing.Size(177, 28);
            this.product_id.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(193, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "สินค้า : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 117;
            this.label3.Text = "สาขา : ";
            // 
            // excel_btn
            // 
            this.excel_btn.BackColor = System.Drawing.Color.Green;
            this.excel_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.excel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.excel_btn.ForeColor = System.Drawing.Color.White;
            this.excel_btn.Location = new System.Drawing.Point(977, 0);
            this.excel_btn.Name = "excel_btn";
            this.excel_btn.Size = new System.Drawing.Size(131, 120);
            this.excel_btn.TabIndex = 8;
            this.excel_btn.Text = "EXCEL";
            this.excel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.excel_btn.UseVisualStyleBackColor = false;
            this.excel_btn.Visible = false;
            this.excel_btn.Click += new System.EventHandler(this.excel_btn_Click);
            // 
            // print_btn
            // 
            this.print_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.print_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.print_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.print_btn.ForeColor = System.Drawing.Color.White;
            this.print_btn.Location = new System.Drawing.Point(1108, 0);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(131, 120);
            this.print_btn.TabIndex = 9;
            this.print_btn.Text = "พิมพ์รายงาน";
            this.print_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.print_btn.UseVisualStyleBackColor = false;
            this.print_btn.Visible = false;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.LightCoral;
            this.manage_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(1239, 0);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(131, 120);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "เรียกรายงาน";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(396, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // end_date
            // 
            this.end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.end_date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.end_date.Location = new System.Drawing.Point(290, 73);
            this.end_date.Mask = "00/00/0000";
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(100, 26);
            this.end_date.TabIndex = 4;
            this.end_date.Tag = "วันเดือนปีเกิด";
            this.end_date.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(193, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 110;
            this.label2.Text = "ถึงวันที่ : ";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(396, 50);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(143, 20);
            this.label33.TabIndex = 108;
            this.label33.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // start_date
            // 
            this.start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.start_date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.start_date.Location = new System.Drawing.Point(290, 47);
            this.start_date.Mask = "00/00/0000";
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(100, 26);
            this.start_date.TabIndex = 3;
            this.start_date.Tag = "วันเดือนปีเกิด";
            this.start_date.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(193, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 107;
            this.label9.Text = "ตั้งแต่วันที่ : ";
            // 
            // branch_list
            // 
            this.branch_list.CheckOnClick = true;
            this.branch_list.FormattingEnabled = true;
            this.branch_list.Location = new System.Drawing.Point(4, 29);
            this.branch_list.Name = "branch_list";
            this.branch_list.ScrollAlwaysVisible = true;
            this.branch_list.Size = new System.Drawing.Size(183, 88);
            this.branch_list.TabIndex = 1;
            this.branch_list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.branch_list_ItemCheck);
            // 
            // wb_panel
            // 
            this.wb_panel.BackColor = System.Drawing.Color.White;
            this.wb_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wb_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_panel.Location = new System.Drawing.Point(0, 120);
            this.wb_panel.Name = "wb_panel";
            this.wb_panel.Size = new System.Drawing.Size(1370, 243);
            this.wb_panel.TabIndex = 6;
            // 
            // pagination
            // 
            this.pagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagination.Enabled = false;
            this.pagination.Location = new System.Drawing.Point(0, 363);
            this.pagination.Margin = new System.Windows.Forms.Padding(5);
            this.pagination.Name = "pagination";
            this.pagination.Size = new System.Drawing.Size(1370, 40);
            this.pagination.TabIndex = 7;
            // 
            // transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 403);
            this.ControlBox = false;
            this.Controls.Add(this.wb_panel);
            this.Controls.Add(this.pagination);
            this.Controls.Add(this.filter_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "transaction";
            this.Text = "list";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.filter_panel.ResumeLayout(false);
            this.filter_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filter_panel;
        private System.Windows.Forms.Button excel_btn;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox end_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox start_date;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.CheckedListBox branch_list;
        private System.Windows.Forms.Label label3;
        private User_Control.report_pagination pagination;
        private System.Windows.Forms.Panel wb_panel;
        private System.Windows.Forms.ComboBox product_id;
        private System.Windows.Forms.Label label4;
    }
}