namespace FAMS
{
    partial class employee_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employee_manage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emp_code = new System.Windows.Forms.TextBox();
            this.fullname = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.is_trainer = new System.Windows.Forms.CheckBox();
            this.can_get_commission = new System.Windows.Forms.CheckBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.branch_id = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสพนักงาน : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อ - สกุล : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อเล่น : ";
            // 
            // emp_code
            // 
            this.emp_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.emp_code.ForeColor = System.Drawing.Color.DodgerBlue;
            this.emp_code.Location = new System.Drawing.Point(126, 6);
            this.emp_code.Name = "emp_code";
            this.emp_code.Size = new System.Drawing.Size(161, 26);
            this.emp_code.TabIndex = 1;
            // 
            // fullname
            // 
            this.fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fullname.ForeColor = System.Drawing.Color.DodgerBlue;
            this.fullname.Location = new System.Drawing.Point(126, 37);
            this.fullname.Name = "fullname";
            this.fullname.Size = new System.Drawing.Size(283, 26);
            this.fullname.TabIndex = 2;
            // 
            // nickname
            // 
            this.nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nickname.ForeColor = System.Drawing.Color.DodgerBlue;
            this.nickname.Location = new System.Drawing.Point(126, 67);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(161, 26);
            this.nickname.TabIndex = 3;
            // 
            // is_trainer
            // 
            this.is_trainer.AutoSize = true;
            this.is_trainer.Location = new System.Drawing.Point(16, 133);
            this.is_trainer.Name = "is_trainer";
            this.is_trainer.Size = new System.Drawing.Size(125, 24);
            this.is_trainer.TabIndex = 5;
            this.is_trainer.Text = "เป็นเทรนเนอร์";
            this.is_trainer.UseVisualStyleBackColor = true;
            // 
            // can_get_commission
            // 
            this.can_get_commission.AutoSize = true;
            this.can_get_commission.Location = new System.Drawing.Point(16, 163);
            this.can_get_commission.Name = "can_get_commission";
            this.can_get_commission.Size = new System.Drawing.Size(175, 24);
            this.can_get_commission.TabIndex = 6;
            this.can_get_commission.Text = "สามารถได้รับค่าคอมฯ";
            this.can_get_commission.UseVisualStyleBackColor = true;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(12, 193);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 36);
            this.save_btn.TabIndex = 7;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "สังกัดสาขา :";
            // 
            // branch_id
            // 
            this.branch_id.BackColor = System.Drawing.Color.LightYellow;
            this.branch_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branch_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.branch_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.branch_id.ForeColor = System.Drawing.Color.DodgerBlue;
            this.branch_id.FormattingEnabled = true;
            this.branch_id.Location = new System.Drawing.Point(126, 99);
            this.branch_id.Name = "branch_id";
            this.branch_id.Size = new System.Drawing.Size(211, 28);
            this.branch_id.TabIndex = 4;
            // 
            // employee_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 238);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.branch_id);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.can_get_commission);
            this.Controls.Add(this.is_trainer);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.fullname);
            this.Controls.Add(this.emp_code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "employee_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลพนักงาน";
            this.Load += new System.EventHandler(this.employee_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emp_code;
        private System.Windows.Forms.TextBox fullname;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.CheckBox is_trainer;
        private System.Windows.Forms.CheckBox can_get_commission;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox branch_id;
    }
}