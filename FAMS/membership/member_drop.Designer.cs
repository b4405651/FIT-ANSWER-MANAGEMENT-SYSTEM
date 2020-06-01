namespace FAMS
{
    partial class member_drop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_drop));
            this.drop_start = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.day_amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drop_end = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.drop_note = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // drop_start
            // 
            this.drop_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drop_start.ForeColor = System.Drawing.Color.DodgerBlue;
            this.drop_start.Location = new System.Drawing.Point(141, 6);
            this.drop_start.Mask = "00/00/0000";
            this.drop_start.Name = "drop_start";
            this.drop_start.Size = new System.Drawing.Size(100, 26);
            this.drop_start.TabIndex = 1;
            this.drop_start.Tag = "วันเดือนปีเกิด";
            this.drop_start.ValidatingType = typeof(System.DateTime);
            this.drop_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.drop_start_KeyUp);
            this.drop_start.Leave += new System.EventHandler(this.drop_start_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 20);
            this.label9.TabIndex = 63;
            this.label9.Text = "ดรอปตั้งแต่วันที่ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "( ปี วว / ดด / ปี พ.ศ. )";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(16, 140);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 36);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // day_amount
            // 
            this.day_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.day_amount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.day_amount.Location = new System.Drawing.Point(141, 38);
            this.day_amount.Name = "day_amount";
            this.day_amount.Size = new System.Drawing.Size(100, 26);
            this.day_amount.TabIndex = 2;
            this.day_amount.Tag = "ชื่อ";
            this.day_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.day_amount_KeyPress);
            this.day_amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.day_amount_KeyUp);
            this.day_amount.Leave += new System.EventHandler(this.day_amount_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "จำนวนวัน : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(247, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 69;
            this.label2.Text = "วัน";
            // 
            // drop_end
            // 
            this.drop_end.AutoSize = true;
            this.drop_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.drop_end.ForeColor = System.Drawing.Color.DodgerBlue;
            this.drop_end.Location = new System.Drawing.Point(167, 76);
            this.drop_end.Name = "drop_end";
            this.drop_end.Size = new System.Drawing.Size(15, 20);
            this.drop_end.TabIndex = 71;
            this.drop_end.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 70;
            this.label4.Text = "วันที่สิ้นสุดการดรอป :";
            // 
            // drop_note
            // 
            this.drop_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.drop_note.ForeColor = System.Drawing.Color.DodgerBlue;
            this.drop_note.Location = new System.Drawing.Point(141, 104);
            this.drop_note.Name = "drop_note";
            this.drop_note.Size = new System.Drawing.Size(320, 26);
            this.drop_note.TabIndex = 3;
            this.drop_note.Tag = "ชื่อ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 73;
            this.label3.Text = "สาเหตุการดรอป : ";
            // 
            // member_drop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 184);
            this.Controls.Add(this.drop_note);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drop_end);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.day_amount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drop_start);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "member_drop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ดรอปการใช้งาน";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox drop_start;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox day_amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label drop_end;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox drop_note;
        private System.Windows.Forms.Label label3;
    }
}