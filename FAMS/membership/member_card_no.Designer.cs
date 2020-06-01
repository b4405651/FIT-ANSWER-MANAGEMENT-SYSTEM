namespace FAMS
{
    partial class member_card_no
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_card_no));
            this.card_no_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.note_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // card_no_txt
            // 
            this.card_no_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.card_no_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.card_no_txt.Location = new System.Drawing.Point(135, 6);
            this.card_no_txt.Name = "card_no_txt";
            this.card_no_txt.Size = new System.Drawing.Size(203, 35);
            this.card_no_txt.TabIndex = 1;
            this.card_no_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.member_no_txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "เลขที่บัตร :";
            // 
            // note_txt
            // 
            this.note_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.note_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.note_txt.Location = new System.Drawing.Point(135, 38);
            this.note_txt.Name = "note_txt";
            this.note_txt.Size = new System.Drawing.Size(203, 35);
            this.note_txt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "บันทึกเพิ่มเติม :";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(357, 0);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 72);
            this.save_btn.TabIndex = 3;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // member_card_no
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 72);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.note_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.card_no_txt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "member_card_no";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บันทึก / เปลี่ยนแปลง เลขที่สมาชิก";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_no_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox note_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save_btn;
    }
}