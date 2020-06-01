namespace FAMS
{
    partial class config_employee_card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_employee_card));
            this.top_panel = new System.Windows.Forms.Panel();
            this.save_btn = new System.Windows.Forms.Button();
            this.browse_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(this.save_btn);
            this.top_panel.Controls.Add(this.browse_btn);
            this.top_panel.Controls.Add(this.label1);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Padding = new System.Windows.Forms.Padding(2);
            this.top_panel.Size = new System.Drawing.Size(502, 47);
            this.top_panel.TabIndex = 0;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(399, 2);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 43);
            this.save_btn.TabIndex = 15;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // browse_btn
            // 
            this.browse_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.browse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.browse_btn.ForeColor = System.Drawing.Color.White;
            this.browse_btn.Location = new System.Drawing.Point(123, 3);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(104, 41);
            this.browse_btn.TabIndex = 14;
            this.browse_btn.Text = "เลือกไฟล์";
            this.browse_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.browse_btn.UseVisualStyleBackColor = false;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "เลือกไฟล์รูป : ";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 47);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(502, 325);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // config_employee_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 372);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.top_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "config_employee_card";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บัตรพนักงาน";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.config_employee_card_FormClosing);
            this.Load += new System.EventHandler(this.config_employee_card_Load);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}