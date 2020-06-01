namespace FAMS.Report.Member
{
    partial class list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(list));
            this.filter_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.member_type_list = new System.Windows.Forms.CheckedListBox();
            this.member_view_list = new System.Windows.Forms.CheckedListBox();
            this.excel_btn = new System.Windows.Forms.Button();
            this.print_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.branch_list = new System.Windows.Forms.CheckedListBox();
            this.wb_panel = new System.Windows.Forms.Panel();
            this.pagination = new FAMS.User_Control.report_pagination();
            this.filter_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filter_panel
            // 
            this.filter_panel.BackColor = System.Drawing.Color.LightCyan;
            this.filter_panel.Controls.Add(this.label5);
            this.filter_panel.Controls.Add(this.label4);
            this.filter_panel.Controls.Add(this.label3);
            this.filter_panel.Controls.Add(this.member_type_list);
            this.filter_panel.Controls.Add(this.member_view_list);
            this.filter_panel.Controls.Add(this.excel_btn);
            this.filter_panel.Controls.Add(this.print_btn);
            this.filter_panel.Controls.Add(this.manage_btn);
            this.filter_panel.Controls.Add(this.branch_list);
            this.filter_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter_panel.Location = new System.Drawing.Point(0, 0);
            this.filter_panel.Name = "filter_panel";
            this.filter_panel.Size = new System.Drawing.Size(1370, 120);
            this.filter_panel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(378, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 119;
            this.label5.Text = "ประเภทสมาชิก : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(189, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "เลือกดูสมาชิก : ";
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
            // member_type_list
            // 
            this.member_type_list.CheckOnClick = true;
            this.member_type_list.FormattingEnabled = true;
            this.member_type_list.Location = new System.Drawing.Point(382, 29);
            this.member_type_list.Name = "member_type_list";
            this.member_type_list.ScrollAlwaysVisible = true;
            this.member_type_list.Size = new System.Drawing.Size(183, 88);
            this.member_type_list.TabIndex = 3;
            this.member_type_list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.member_type_list_ItemCheck);
            // 
            // member_view_list
            // 
            this.member_view_list.CheckOnClick = true;
            this.member_view_list.FormattingEnabled = true;
            this.member_view_list.Location = new System.Drawing.Point(193, 29);
            this.member_view_list.Name = "member_view_list";
            this.member_view_list.ScrollAlwaysVisible = true;
            this.member_view_list.Size = new System.Drawing.Size(183, 88);
            this.member_view_list.TabIndex = 2;
            this.member_view_list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.member_view_list_ItemCheck);
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
            this.excel_btn.TabIndex = 7;
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
            this.print_btn.TabIndex = 8;
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
            this.manage_btn.TabIndex = 4;
            this.manage_btn.Text = "เรียกรายงาน";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
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
            this.wb_panel.TabIndex = 5;
            // 
            // pagination
            // 
            this.pagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagination.Enabled = false;
            this.pagination.Location = new System.Drawing.Point(0, 363);
            this.pagination.Margin = new System.Windows.Forms.Padding(5);
            this.pagination.Name = "pagination";
            this.pagination.Size = new System.Drawing.Size(1370, 40);
            this.pagination.TabIndex = 6;
            // 
            // list
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "list";
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
        public System.Windows.Forms.CheckedListBox branch_list;
        public System.Windows.Forms.CheckedListBox member_view_list;
        public System.Windows.Forms.CheckedListBox member_type_list;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private User_Control.report_pagination pagination;
        private System.Windows.Forms.Panel wb_panel;
    }
}