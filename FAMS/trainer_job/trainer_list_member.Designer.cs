namespace FAMS
{
    partial class trainer_list_member
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
            this.btn_panel = new System.Windows.Forms.Panel();
            this.trainer_emp_id = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.show_expired_or_empty = new System.Windows.Forms.CheckBox();
            this.btn_dgv = new FAMS.User_Control.btn_dgv();
            this.btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_panel
            // 
            this.btn_panel.BackColor = System.Drawing.Color.LightCyan;
            this.btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_panel.Controls.Add(this.trainer_emp_id);
            this.btn_panel.Controls.Add(this.label3);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(852, 41);
            this.btn_panel.TabIndex = 1;
            // 
            // trainer_emp_id
            // 
            this.trainer_emp_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainer_emp_id.FormattingEnabled = true;
            this.trainer_emp_id.ItemHeight = 20;
            this.trainer_emp_id.Location = new System.Drawing.Point(111, 5);
            this.trainer_emp_id.Name = "trainer_emp_id";
            this.trainer_emp_id.Size = new System.Drawing.Size(305, 28);
            this.trainer_emp_id.TabIndex = 117;
            this.trainer_emp_id.SelectedIndexChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 116;
            this.label3.Text = "เทรนเนอร์ : ";
            // 
            // show_expired_or_empty
            // 
            this.show_expired_or_empty.AutoSize = true;
            this.show_expired_or_empty.BackColor = System.Drawing.Color.LightCyan;
            this.show_expired_or_empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.show_expired_or_empty.Location = new System.Drawing.Point(423, 8);
            this.show_expired_or_empty.Name = "show_expired_or_empty";
            this.show_expired_or_empty.Size = new System.Drawing.Size(293, 24);
            this.show_expired_or_empty.TabIndex = 118;
            this.show_expired_or_empty.Text = "ดูสมาชิกที่คอร์สหมดอายุหรือใช้หมดแล้ว";
            this.show_expired_or_empty.UseVisualStyleBackColor = false;
            this.show_expired_or_empty.CheckedChanged += new System.EventHandler(this.show_expired_or_empty_CheckedChanged);
            // 
            // btn_dgv
            // 
            this.btn_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_dgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dgv.Location = new System.Drawing.Point(0, 41);
            this.btn_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(852, 362);
            this.btn_dgv.TabIndex = 7;
            // 
            // trainer_list_member
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 403);
            this.ControlBox = false;
            this.Controls.Add(this.show_expired_or_empty);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.btn_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "trainer_list_member";
            this.Text = "trainer_job";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel btn_panel;
        public User_Control.btn_dgv btn_dgv;
        private System.Windows.Forms.ComboBox trainer_emp_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox show_expired_or_empty;
    }
}