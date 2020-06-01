namespace FAMS
{
    partial class branch_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(branch_manage));
            this.branch_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tax_id = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.company_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // branch_name
            // 
            this.branch_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.branch_name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.branch_name.Location = new System.Drawing.Point(124, 6);
            this.branch_name.Name = "branch_name";
            this.branch_name.Size = new System.Drawing.Size(242, 26);
            this.branch_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชื่อเต็ม สาขา :";
            // 
            // prefix
            // 
            this.prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.prefix.ForeColor = System.Drawing.Color.DodgerBlue;
            this.prefix.Location = new System.Drawing.Point(312, 38);
            this.prefix.Name = "prefix";
            this.prefix.Size = new System.Drawing.Size(54, 26);
            this.prefix.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ตัวย่อ ( ภาษาอังกฤษ ตัวใหญ่ 2 ตัวอักษร ) :";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.Green;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(16, 317);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(104, 42);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "บันทึก";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tax_id);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.address);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.company_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 234);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลสาขา";
            // 
            // tax_id
            // 
            this.tax_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tax_id.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tax_id.Location = new System.Drawing.Point(188, 191);
            this.tax_id.Name = "tax_id";
            this.tax_id.Size = new System.Drawing.Size(152, 26);
            this.tax_id.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(13, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "เลขประจำตัวผู้เสียภาษี :";
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.address.ForeColor = System.Drawing.Color.DodgerBlue;
            this.address.Location = new System.Drawing.Point(77, 61);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(263, 124);
            this.address.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(13, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "ที่อยู่ :";
            // 
            // company_name
            // 
            this.company_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.company_name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.company_name.Location = new System.Drawing.Point(77, 29);
            this.company_name.Name = "company_name";
            this.company_name.Size = new System.Drawing.Size(263, 26);
            this.company_name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(13, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "บริษัท :";
            // 
            // branch_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.prefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.branch_name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "branch_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลสาขา";
            this.Load += new System.EventHandler(this.branch_manage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox branch_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tax_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox company_name;
        private System.Windows.Forms.Label label3;
    }
}