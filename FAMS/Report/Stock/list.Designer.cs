namespace FAMS.Report.Stock
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
            this.filter_panel = new System.Windows.Forms.Panel();
            this.excel_btn = new System.Windows.Forms.Button();
            this.print_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.wb_panel = new System.Windows.Forms.Panel();
            this.pagination = new FAMS.User_Control.report_pagination();
            this.filter_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filter_panel
            // 
            this.filter_panel.BackColor = System.Drawing.Color.LightCyan;
            this.filter_panel.Controls.Add(this.excel_btn);
            this.filter_panel.Controls.Add(this.print_btn);
            this.filter_panel.Controls.Add(this.manage_btn);
            this.filter_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter_panel.Location = new System.Drawing.Point(0, 0);
            this.filter_panel.Name = "filter_panel";
            this.filter_panel.Size = new System.Drawing.Size(1370, 66);
            this.filter_panel.TabIndex = 0;
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
            this.excel_btn.Size = new System.Drawing.Size(131, 66);
            this.excel_btn.TabIndex = 4;
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
            this.print_btn.Size = new System.Drawing.Size(131, 66);
            this.print_btn.TabIndex = 5;
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
            this.manage_btn.Size = new System.Drawing.Size(131, 66);
            this.manage_btn.TabIndex = 1;
            this.manage_btn.Text = "เรียกรายงาน";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // wb_panel
            // 
            this.wb_panel.BackColor = System.Drawing.Color.White;
            this.wb_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wb_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_panel.Location = new System.Drawing.Point(0, 66);
            this.wb_panel.Name = "wb_panel";
            this.wb_panel.Size = new System.Drawing.Size(1370, 297);
            this.wb_panel.TabIndex = 2;
            // 
            // pagination
            // 
            this.pagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagination.Enabled = false;
            this.pagination.Location = new System.Drawing.Point(0, 363);
            this.pagination.Margin = new System.Windows.Forms.Padding(5);
            this.pagination.Name = "pagination";
            this.pagination.Size = new System.Drawing.Size(1370, 40);
            this.pagination.TabIndex = 3;
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "list";
            this.Text = "list";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.filter_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filter_panel;
        private System.Windows.Forms.Button excel_btn;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button manage_btn;
        private User_Control.report_pagination pagination;
        private System.Windows.Forms.Panel wb_panel;
    }
}