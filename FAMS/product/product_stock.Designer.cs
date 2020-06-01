namespace FAMS
{
    partial class product_stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(product_stock));
            this.btn_panel = new System.Windows.Forms.Panel();
            this.out_btn = new System.Windows.Forms.Button();
            this.is_alert = new System.Windows.Forms.CheckBox();
            this.in_btn = new System.Windows.Forms.Button();
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
            this.btn_panel.Controls.Add(this.out_btn);
            this.btn_panel.Controls.Add(this.is_alert);
            this.btn_panel.Controls.Add(this.in_btn);
            this.btn_panel.Controls.Add(this.search_txt);
            this.btn_panel.Controls.Add(this.label1);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(921, 43);
            this.btn_panel.TabIndex = 3;
            // 
            // out_btn
            // 
            this.out_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.out_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.out_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.out_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.out_btn.ForeColor = System.Drawing.Color.White;
            this.out_btn.Location = new System.Drawing.Point(523, 0);
            this.out_btn.Name = "out_btn";
            this.out_btn.Size = new System.Drawing.Size(198, 41);
            this.out_btn.TabIndex = 3;
            this.out_btn.Text = "นำสินค้าออกจากสต๊อก";
            this.out_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.out_btn.UseVisualStyleBackColor = false;
            this.out_btn.Visible = false;
            this.out_btn.Click += new System.EventHandler(this.out_btn_Click);
            // 
            // is_alert
            // 
            this.is_alert.AutoSize = true;
            this.is_alert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.is_alert.Location = new System.Drawing.Point(290, 9);
            this.is_alert.Name = "is_alert";
            this.is_alert.Size = new System.Drawing.Size(86, 24);
            this.is_alert.TabIndex = 2;
            this.is_alert.Text = "ใกล้หมด";
            this.is_alert.UseVisualStyleBackColor = true;
            this.is_alert.CheckedChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // in_btn
            // 
            this.in_btn.BackColor = System.Drawing.Color.Green;
            this.in_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.in_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.in_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.in_btn.ForeColor = System.Drawing.Color.White;
            this.in_btn.Location = new System.Drawing.Point(721, 0);
            this.in_btn.Name = "in_btn";
            this.in_btn.Size = new System.Drawing.Size(198, 41);
            this.in_btn.TabIndex = 4;
            this.in_btn.Text = "นำสินค้าเข้าสต๊อก";
            this.in_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.in_btn.UseVisualStyleBackColor = false;
            this.in_btn.Click += new System.EventHandler(this.in_btn_Click);
            // 
            // search_txt
            // 
            this.search_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.search_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.search_txt.Location = new System.Drawing.Point(72, 7);
            this.search_txt.Name = "search_txt";
            this.search_txt.Size = new System.Drawing.Size(203, 26);
            this.search_txt.TabIndex = 1;
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
            this.btn_dgv.Location = new System.Drawing.Point(0, 43);
            this.btn_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(921, 353);
            this.btn_dgv.TabIndex = 4;
            // 
            // product_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 396);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.btn_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "product_stock";
            this.Text = "product_stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.Button in_btn;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.Label label1;
        public User_Control.btn_dgv btn_dgv;
        private System.Windows.Forms.CheckBox is_alert;
        private System.Windows.Forms.Button out_btn;
    }
}