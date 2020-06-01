namespace FAMS
{
    partial class accounting_report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accounting_report));
            this.year_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.month_range = new System.Windows.Forms.CheckedListBox();
            this.get_excel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // year_txt
            // 
            this.year_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.year_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.year_txt.Location = new System.Drawing.Point(102, 6);
            this.year_txt.Name = "year_txt";
            this.year_txt.Size = new System.Drawing.Size(109, 26);
            this.year_txt.TabIndex = 1;
            this.year_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ปี พ.ศ. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 119;
            this.label3.Text = "ช่วงเดือน : ";
            // 
            // month_range
            // 
            this.month_range.CheckOnClick = true;
            this.month_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.month_range.FormattingEnabled = true;
            this.month_range.Items.AddRange(new object[] {
            "1 ม.ค. - 30 มิ.ย.",
            "1 ม.ค. - 31 ธ.ค."});
            this.month_range.Location = new System.Drawing.Point(102, 35);
            this.month_range.Name = "month_range";
            this.month_range.ScrollAlwaysVisible = true;
            this.month_range.Size = new System.Drawing.Size(183, 46);
            this.month_range.TabIndex = 2;
            this.month_range.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.month_range_ItemCheck);
            // 
            // get_excel_btn
            // 
            this.get_excel_btn.BackColor = System.Drawing.Color.Green;
            this.get_excel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.get_excel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.get_excel_btn.ForeColor = System.Drawing.Color.White;
            this.get_excel_btn.Location = new System.Drawing.Point(16, 87);
            this.get_excel_btn.Name = "get_excel_btn";
            this.get_excel_btn.Size = new System.Drawing.Size(127, 48);
            this.get_excel_btn.TabIndex = 120;
            this.get_excel_btn.Text = "บันทึก File";
            this.get_excel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.get_excel_btn.UseVisualStyleBackColor = false;
            this.get_excel_btn.Click += new System.EventHandler(this.get_excel_btn_Click);
            // 
            // accounting_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 140);
            this.Controls.Add(this.get_excel_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.month_range);
            this.Controls.Add(this.year_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "accounting_report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบุรายละเอียดรายงานทางบัญชี";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox year_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckedListBox month_range;
        private System.Windows.Forms.Button get_excel_btn;
    }
}