namespace FAMS
{
    partial class use_pt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(use_pt));
            this.label1 = new System.Windows.Forms.Label();
            this.card_no = new System.Windows.Forms.Label();
            this.member_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pt_no = new System.Windows.Forms.Label();
            this.trainer_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "เลขบัตรสมาชิก : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // card_no
            // 
            this.card_no.BackColor = System.Drawing.Color.Transparent;
            this.card_no.Dock = System.Windows.Forms.DockStyle.Top;
            this.card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.card_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.card_no.Location = new System.Drawing.Point(20, 50);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(442, 30);
            this.card_no.TabIndex = 4;
            this.card_no.Text = "0";
            this.card_no.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // member_name
            // 
            this.member_name.BackColor = System.Drawing.Color.Transparent;
            this.member_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.member_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.member_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.member_name.Location = new System.Drawing.Point(20, 80);
            this.member_name.Name = "member_name";
            this.member_name.Size = new System.Drawing.Size(442, 30);
            this.member_name.TabIndex = 7;
            this.member_name.Text = "0";
            this.member_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(20, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "รหัสเทรนเนอร์ : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pt_no
            // 
            this.pt_no.BackColor = System.Drawing.Color.Transparent;
            this.pt_no.Dock = System.Windows.Forms.DockStyle.Top;
            this.pt_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.pt_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.pt_no.Location = new System.Drawing.Point(20, 140);
            this.pt_no.Name = "pt_no";
            this.pt_no.Size = new System.Drawing.Size(442, 30);
            this.pt_no.TabIndex = 9;
            this.pt_no.Text = "0";
            this.pt_no.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainer_name
            // 
            this.trainer_name.BackColor = System.Drawing.Color.Transparent;
            this.trainer_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.trainer_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.trainer_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.trainer_name.Location = new System.Drawing.Point(20, 170);
            this.trainer_name.Name = "trainer_name";
            this.trainer_name.Size = new System.Drawing.Size(442, 30);
            this.trainer_name.TabIndex = 10;
            this.trainer_name.Text = "0";
            this.trainer_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // use_pt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(482, 224);
            this.Controls.Add(this.trainer_name);
            this.Controls.Add(this.pt_no);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.member_name);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "use_pt";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.use_pt_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.use_pt_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.use_pt_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label card_no;
        private System.Windows.Forms.Label member_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pt_no;
        private System.Windows.Forms.Label trainer_name;
    }
}