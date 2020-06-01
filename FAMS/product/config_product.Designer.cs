namespace FAMS
{
    partial class config_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_product));
            this.btn_panel = new System.Windows.Forms.Panel();
            this.is_suspend = new System.Windows.Forms.CheckBox();
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
            this.btn_panel.Controls.Add(this.is_suspend);
            this.btn_panel.Controls.Add(this.add_btn);
            this.btn_panel.Controls.Add(this.search_txt);
            this.btn_panel.Controls.Add(this.label1);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(923, 43);
            this.btn_panel.TabIndex = 2;
            // 
            // is_suspend
            // 
            this.is_suspend.AutoSize = true;
            this.is_suspend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.is_suspend.Location = new System.Drawing.Point(291, 9);
            this.is_suspend.Name = "is_suspend";
            this.is_suspend.Size = new System.Drawing.Size(212, 33);
            this.is_suspend.TabIndex = 2;
            this.is_suspend.Text = "เฉพาะที่ปิดการใช้";
            this.is_suspend.UseVisualStyleBackColor = true;
            this.is_suspend.CheckedChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.add_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.add_btn.ForeColor = System.Drawing.Color.White;
            this.add_btn.Location = new System.Drawing.Point(723, 0);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(198, 41);
            this.add_btn.TabIndex = 3;
            this.add_btn.Text = "เพิ่มสินค้าใหม่";
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
            this.search_txt.Size = new System.Drawing.Size(203, 35);
            this.search_txt.TabIndex = 1;
            this.search_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.search_txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 10);
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
            this.btn_dgv.Size = new System.Drawing.Size(923, 360);
            this.btn_dgv.TabIndex = 4;
            // 
            // config_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 403);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.btn_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "config_product";
            this.Text = "config_product";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.CheckBox is_suspend;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.Label label1;
        public User_Control.btn_dgv btn_dgv;
    }
}