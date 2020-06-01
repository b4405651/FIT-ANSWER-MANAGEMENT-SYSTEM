namespace FAMS
{
    partial class member_payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_payment));
            this.label1 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.card_expiry_date = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.card_no = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.payment_type = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "จำนวนเงิน : ";
            // 
            // amount
            // 
            this.amount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.amount.Location = new System.Drawing.Point(112, 38);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(100, 26);
            this.amount.TabIndex = 2;
            this.amount.TextChanged += new System.EventHandler(this.amount_TextChanged);
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            this.amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.amount_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(218, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "บาท";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.Green;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(273, 6);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(104, 58);
            this.manage_btn.TabIndex = 3;
            this.manage_btn.Text = "บันทึก";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.card_expiry_date);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.card_no);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(16, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลบัตร";
            // 
            // card_expiry_date
            // 
            this.card_expiry_date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.card_expiry_date.Location = new System.Drawing.Point(154, 57);
            this.card_expiry_date.Mask = "00/00";
            this.card_expiry_date.Name = "card_expiry_date";
            this.card_expiry_date.Size = new System.Drawing.Size(54, 26);
            this.card_expiry_date.TabIndex = 4;
            this.card_expiry_date.ValidatingType = typeof(System.DateTime);
            this.card_expiry_date.Leave += new System.EventHandler(this.card_expiry_date_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "วันหมดอายุบัตร : ";
            // 
            // card_no
            // 
            this.card_no.ForeColor = System.Drawing.Color.DodgerBlue;
            this.card_no.Location = new System.Drawing.Point(154, 28);
            this.card_no.Mask = "0000 0000 0000 0000";
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(186, 26);
            this.card_no.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "หมายเลขบัตร : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "ชำระด้วย :";
            // 
            // payment_type
            // 
            this.payment_type.BackColor = System.Drawing.Color.LightYellow;
            this.payment_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payment_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.payment_type.ForeColor = System.Drawing.Color.DodgerBlue;
            this.payment_type.FormattingEnabled = true;
            this.payment_type.Location = new System.Drawing.Point(112, 6);
            this.payment_type.Name = "payment_type";
            this.payment_type.Size = new System.Drawing.Size(144, 28);
            this.payment_type.TabIndex = 1;
            this.payment_type.SelectedIndexChanged += new System.EventHandler(this.payment_type_SelectedIndexChanged);
            // 
            // member_payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 73);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.payment_type);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "member_payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ชำระเงิน";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox card_expiry_date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox card_no;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox payment_type;
    }
}