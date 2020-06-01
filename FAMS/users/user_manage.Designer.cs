namespace FAMS
{
    partial class user_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user_manage));
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.verify_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emp_id = new System.Windows.Forms.ComboBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.is_admin = new System.Windows.Forms.CheckBox();
            this.branch_gb = new System.Windows.Forms.GroupBox();
            this.branch_TreeView = new System.Windows.Forms.myTreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menu_TreeView = new System.Windows.Forms.myTreeView();
            this.manual_owner_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.can_approve = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.web_TreeView = new System.Windows.Forms.myTreeView();
            this.can_use_web = new System.Windows.Forms.CheckBox();
            this.branch_gb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อผู้ใช้งาน : ";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.username.Location = new System.Drawing.Point(129, 6);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(269, 26);
            this.username.TabIndex = 1;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.password.Location = new System.Drawing.Point(129, 38);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(269, 26);
            this.password.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "รหัสผ่าน : ";
            // 
            // verify_password
            // 
            this.verify_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.verify_password.Location = new System.Drawing.Point(129, 70);
            this.verify_password.Name = "verify_password";
            this.verify_password.PasswordChar = '*';
            this.verify_password.Size = new System.Drawing.Size(269, 26);
            this.verify_password.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "ยืนยันรหัสผ่าน : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "พนักงานเจ้าของบัญชี : ";
            // 
            // emp_id
            // 
            this.emp_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emp_id.FormattingEnabled = true;
            this.emp_id.Location = new System.Drawing.Point(183, 102);
            this.emp_id.Name = "emp_id";
            this.emp_id.Size = new System.Drawing.Size(215, 28);
            this.emp_id.TabIndex = 4;
            this.emp_id.SelectedIndexChanged += new System.EventHandler(this.emp_id_SelectedIndexChanged);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(16, 224);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 36);
            this.save_btn.TabIndex = 15;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // is_admin
            // 
            this.is_admin.AutoSize = true;
            this.is_admin.Location = new System.Drawing.Point(16, 194);
            this.is_admin.Name = "is_admin";
            this.is_admin.Size = new System.Drawing.Size(130, 24);
            this.is_admin.TabIndex = 6;
            this.is_admin.Text = "เป็นผู้ดูแลระบบ";
            this.is_admin.UseVisualStyleBackColor = true;
            // 
            // branch_gb
            // 
            this.branch_gb.Controls.Add(this.branch_TreeView);
            this.branch_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.branch_gb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.branch_gb.Location = new System.Drawing.Point(404, 6);
            this.branch_gb.Name = "branch_gb";
            this.branch_gb.Size = new System.Drawing.Size(244, 254);
            this.branch_gb.TabIndex = 9;
            this.branch_gb.TabStop = false;
            this.branch_gb.Text = "สาขาที่เข้าใช้ได้";
            // 
            // branch_TreeView
            // 
            this.branch_TreeView.CheckBoxes = true;
            this.branch_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.branch_TreeView.Location = new System.Drawing.Point(3, 22);
            this.branch_TreeView.Name = "branch_TreeView";
            this.branch_TreeView.Size = new System.Drawing.Size(238, 229);
            this.branch_TreeView.TabIndex = 10;
            this.branch_TreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.branch_TreeView_AfterCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menu_TreeView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(654, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 254);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "สิทธิ์การใช้โปรแกรม";
            // 
            // menu_TreeView
            // 
            this.menu_TreeView.CheckBoxes = true;
            this.menu_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu_TreeView.Location = new System.Drawing.Point(3, 22);
            this.menu_TreeView.Name = "menu_TreeView";
            this.menu_TreeView.Size = new System.Drawing.Size(238, 229);
            this.menu_TreeView.TabIndex = 12;
            this.menu_TreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.menu_TreeView_AfterCheck);
            // 
            // manual_owner_name
            // 
            this.manual_owner_name.Enabled = false;
            this.manual_owner_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.manual_owner_name.Location = new System.Drawing.Point(129, 162);
            this.manual_owner_name.Name = "manual_owner_name";
            this.manual_owner_name.Size = new System.Drawing.Size(269, 26);
            this.manual_owner_name.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "เจ้าของบัญชี ( หากไม่ใช่พนักงาน ) : ";
            // 
            // can_approve
            // 
            this.can_approve.AutoSize = true;
            this.can_approve.Location = new System.Drawing.Point(258, 194);
            this.can_approve.Name = "can_approve";
            this.can_approve.Size = new System.Drawing.Size(140, 24);
            this.can_approve.TabIndex = 7;
            this.can_approve.Text = "สามารถอนุมัติได้";
            this.can_approve.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.web_TreeView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.Location = new System.Drawing.Point(901, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 254);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "สิทธิ์การใช้ web report";
            // 
            // web_TreeView
            // 
            this.web_TreeView.CheckBoxes = true;
            this.web_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_TreeView.Location = new System.Drawing.Point(3, 22);
            this.web_TreeView.Name = "web_TreeView";
            this.web_TreeView.Size = new System.Drawing.Size(238, 229);
            this.web_TreeView.TabIndex = 14;
            this.web_TreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.web_TreeView_AfterCheck);
            // 
            // can_use_web
            // 
            this.can_use_web.AutoSize = true;
            this.can_use_web.Location = new System.Drawing.Point(183, 224);
            this.can_use_web.Name = "can_use_web";
            this.can_use_web.Size = new System.Drawing.Size(213, 24);
            this.can_use_web.TabIndex = 8;
            this.can_use_web.Text = "สามารถใช้ web report ได้";
            this.can_use_web.UseVisualStyleBackColor = true;
            this.can_use_web.CheckedChanged += new System.EventHandler(this.can_use_web_CheckedChanged);
            // 
            // user_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 270);
            this.Controls.Add(this.can_use_web);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.can_approve);
            this.Controls.Add(this.manual_owner_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.branch_gb);
            this.Controls.Add(this.is_admin);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.emp_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.verify_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "user_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลบัญชีผู้ใช้งาน";
            this.Load += new System.EventHandler(this.user_manage_Load);
            this.branch_gb.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox verify_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox emp_id;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.CheckBox is_admin;
        private System.Windows.Forms.GroupBox branch_gb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.myTreeView menu_TreeView;
        private System.Windows.Forms.myTreeView branch_TreeView;
        private System.Windows.Forms.TextBox manual_owner_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox can_approve;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.myTreeView web_TreeView;
        private System.Windows.Forms.CheckBox can_use_web;
    }
}