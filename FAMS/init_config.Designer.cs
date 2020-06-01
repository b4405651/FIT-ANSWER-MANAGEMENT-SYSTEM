namespace FAMS
{
    partial class init_config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(init_config));
            this.label1 = new System.Windows.Forms.Label();
            this.branch_id = new System.Windows.Forms.ComboBox();
            this.manage_btn = new System.Windows.Forms.Button();
            this.receipt_printer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.card_printer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "เครื่องนี้สำหรับสาขา : ";
            // 
            // branch_id
            // 
            this.branch_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branch_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.branch_id.FormattingEnabled = true;
            this.branch_id.Location = new System.Drawing.Point(201, 6);
            this.branch_id.Name = "branch_id";
            this.branch_id.Size = new System.Drawing.Size(196, 28);
            this.branch_id.TabIndex = 1;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.Green;
            this.manage_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(401, 0);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(102, 137);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "บันทึก";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // receipt_printer
            // 
            this.receipt_printer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.receipt_printer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.receipt_printer.FormattingEnabled = true;
            this.receipt_printer.Location = new System.Drawing.Point(178, 74);
            this.receipt_printer.Name = "receipt_printer";
            this.receipt_printer.Size = new System.Drawing.Size(219, 28);
            this.receipt_printer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Printer ใบเสร็จ : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "VAT : ";
            // 
            // vat
            // 
            this.vat.Location = new System.Drawing.Point(76, 107);
            this.vat.Name = "vat";
            this.vat.Size = new System.Drawing.Size(69, 23);
            this.vat.TabIndex = 4;
            this.vat.Text = "7.00";
            this.vat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vat_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(151, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // card_printer
            // 
            this.card_printer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.card_printer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.card_printer.FormattingEnabled = true;
            this.card_printer.Location = new System.Drawing.Point(178, 40);
            this.card_printer.Name = "card_printer";
            this.card_printer.Size = new System.Drawing.Size(219, 28);
            this.card_printer.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Printer บัตรพนักงาน : ";
            // 
            // init_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 137);
            this.Controls.Add(this.card_printer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.receipt_printer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.branch_id);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "init_config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ตั้งค่าเริ่มต้น";
            this.Load += new System.EventHandler(this.init_config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox branch_id;
        private System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.ComboBox receipt_printer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox vat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox card_printer;
        private System.Windows.Forms.Label label5;
    }
}

