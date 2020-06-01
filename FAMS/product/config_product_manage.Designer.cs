namespace FAMS
{
    partial class config_product_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_product_manage));
            this.product_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.product_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.alert_amount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // product_name
            // 
            this.product_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.product_name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.product_name.Location = new System.Drawing.Point(98, 6);
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(239, 26);
            this.product_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชื่อสินค้า : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "บาท";
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.price.ForeColor = System.Drawing.Color.DodgerBlue;
            this.price.Location = new System.Drawing.Point(98, 65);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(105, 26);
            this.price.TabIndex = 3;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "ราคา : ";
            // 
            // product_code
            // 
            this.product_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.product_code.ForeColor = System.Drawing.Color.DodgerBlue;
            this.product_code.Location = new System.Drawing.Point(141, 35);
            this.product_code.Name = "product_code";
            this.product_code.Size = new System.Drawing.Size(196, 26);
            this.product_code.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "รหัส Barcode : ";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(16, 126);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 36);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // alert_amount
            // 
            this.alert_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.alert_amount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.alert_amount.Location = new System.Drawing.Point(185, 95);
            this.alert_amount.Name = "alert_amount";
            this.alert_amount.Size = new System.Drawing.Size(105, 26);
            this.alert_amount.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "แจ้งเตือนเมื่อคงเหลือ : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "หน่วย";
            // 
            // config_product_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 171);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.alert_amount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.product_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.product_name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "config_product_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลสินค้า";
            this.Load += new System.EventHandler(this.config_product_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox product_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox product_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox alert_amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}