namespace FAMS
{
    partial class history_pt_usage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(history_pt_usage));
            this.btn_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.until = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.since = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_dgv = new FAMS.User_Control.btn_dgv();
            this.btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_panel
            // 
            this.btn_panel.BackColor = System.Drawing.Color.LightCyan;
            this.btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_panel.Controls.Add(this.label1);
            this.btn_panel.Controls.Add(this.until);
            this.btn_panel.Controls.Add(this.label2);
            this.btn_panel.Controls.Add(this.label33);
            this.btn_panel.Controls.Add(this.since);
            this.btn_panel.Controls.Add(this.label9);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(1061, 41);
            this.btn_panel.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(574, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // until
            // 
            this.until.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.until.ForeColor = System.Drawing.Color.DodgerBlue;
            this.until.Location = new System.Drawing.Point(468, 5);
            this.until.Mask = "00/00/0000";
            this.until.Name = "until";
            this.until.Size = new System.Drawing.Size(100, 26);
            this.until.TabIndex = 3;
            this.until.Tag = "วันเดือนปีเกิด";
            this.until.ValidatingType = typeof(System.DateTime);
            this.until.KeyUp += new System.Windows.Forms.KeyEventHandler(this.until_KeyUp);
            this.until.Leave += new System.EventHandler(this.until_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(375, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 110;
            this.label2.Text = "จนถึงวันที่ : ";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(210, 8);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(143, 20);
            this.label33.TabIndex = 108;
            this.label33.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // since
            // 
            this.since.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.since.ForeColor = System.Drawing.Color.DodgerBlue;
            this.since.Location = new System.Drawing.Point(104, 5);
            this.since.Mask = "00/00/0000";
            this.since.Name = "since";
            this.since.Size = new System.Drawing.Size(100, 26);
            this.since.TabIndex = 2;
            this.since.Tag = "วันเดือนปีเกิด";
            this.since.ValidatingType = typeof(System.DateTime);
            this.since.KeyUp += new System.Windows.Forms.KeyEventHandler(this.since_KeyUp);
            this.since.Leave += new System.EventHandler(this.since_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(11, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 107;
            this.label9.Text = "ตั้งแต่วันที่ : ";
            // 
            // btn_dgv
            // 
            this.btn_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_dgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dgv.Location = new System.Drawing.Point(0, 41);
            this.btn_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(1061, 362);
            this.btn_dgv.TabIndex = 4;
            // 
            // history_pt_usage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 403);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.btn_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "history_pt_usage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ประวัติการใช้ PT";
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox until;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox since;
        private System.Windows.Forms.Label label9;
        public User_Control.btn_dgv btn_dgv;
    }
}