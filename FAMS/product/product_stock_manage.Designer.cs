namespace FAMS
{
    partial class product_stock_manage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(product_stock_manage));
            this.top_panel = new System.Windows.Forms.Panel();
            this.add_product_btn = new System.Windows.Forms.Button();
            this.product_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ref_txt = new System.Windows.Forms.TextBox();
            this.ref_lbl = new System.Windows.Forms.Label();
            this.bottom_panel = new System.Windows.Forms.Panel();
            this.manage_btn = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.top_panel.SuspendLayout();
            this.bottom_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.LightCyan;
            this.top_panel.Controls.Add(this.add_product_btn);
            this.top_panel.Controls.Add(this.product_code);
            this.top_panel.Controls.Add(this.label1);
            this.top_panel.Controls.Add(this.ref_txt);
            this.top_panel.Controls.Add(this.ref_lbl);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(515, 71);
            this.top_panel.TabIndex = 0;
            // 
            // add_product_btn
            // 
            this.add_product_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.add_product_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_product_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_product_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.add_product_btn.ForeColor = System.Drawing.Color.White;
            this.add_product_btn.Location = new System.Drawing.Point(420, 0);
            this.add_product_btn.Name = "add_product_btn";
            this.add_product_btn.Size = new System.Drawing.Size(95, 71);
            this.add_product_btn.TabIndex = 3;
            this.add_product_btn.Text = "เลือกสินค้า";
            this.add_product_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.add_product_btn.UseVisualStyleBackColor = false;
            this.add_product_btn.Click += new System.EventHandler(this.add_product_btn_Click);
            // 
            // product_code
            // 
            this.product_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.product_code.ForeColor = System.Drawing.Color.DodgerBlue;
            this.product_code.Location = new System.Drawing.Point(211, 38);
            this.product_code.Name = "product_code";
            this.product_code.Size = new System.Drawing.Size(203, 26);
            this.product_code.TabIndex = 2;
            this.product_code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.product_code_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "ค้นหาสินค้าจาก Barcode :";
            // 
            // ref_txt
            // 
            this.ref_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ref_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ref_txt.Location = new System.Drawing.Point(135, 6);
            this.ref_txt.Name = "ref_txt";
            this.ref_txt.Size = new System.Drawing.Size(279, 26);
            this.ref_txt.TabIndex = 1;
            // 
            // ref_lbl
            // 
            this.ref_lbl.AutoSize = true;
            this.ref_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ref_lbl.ForeColor = System.Drawing.Color.Black;
            this.ref_lbl.Location = new System.Drawing.Point(12, 9);
            this.ref_lbl.Name = "ref_lbl";
            this.ref_lbl.Size = new System.Drawing.Size(117, 20);
            this.ref_lbl.TabIndex = 40;
            this.ref_lbl.Text = "อ้างอิงเอกสาร : ";
            // 
            // bottom_panel
            // 
            this.bottom_panel.BackColor = System.Drawing.Color.LightCyan;
            this.bottom_panel.Controls.Add(this.manage_btn);
            this.bottom_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom_panel.Location = new System.Drawing.Point(0, 328);
            this.bottom_panel.Name = "bottom_panel";
            this.bottom_panel.Size = new System.Drawing.Size(515, 36);
            this.bottom_panel.TabIndex = 1;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.Green;
            this.manage_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(417, 0);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(98, 36);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.TabStop = false;
            this.manage_btn.Text = "บันทึก";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
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
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_name,
            this.amount,
            this.product_id});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(0, 71);
            this.DGV.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV.Size = new System.Drawing.Size(515, 257);
            this.DGV.TabIndex = 4;
            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);
            // 
            // product_name
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.product_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.product_name.HeaderText = "สินค้า";
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            this.product_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.product_name.Width = 61;
            // 
            // amount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.amount.HeaderText = "จำนวน";
            this.amount.Name = "amount";
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amount.Width = 69;
            // 
            // product_id
            // 
            this.product_id.HeaderText = "product_id";
            this.product_id.Name = "product_id";
            this.product_id.Visible = false;
            this.product_id.Width = 128;
            // 
            // product_stock_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 364);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.bottom_panel);
            this.Controls.Add(this.top_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "product_stock_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "จัดการข้อมูลสต๊อกสินค้า";
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.bottom_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.TextBox ref_txt;
        private System.Windows.Forms.Label ref_lbl;
        private System.Windows.Forms.Panel bottom_panel;
        public System.Windows.Forms.Button manage_btn;
        public System.Windows.Forms.TextBox product_code;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button add_product_btn;
        public System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
    }
}