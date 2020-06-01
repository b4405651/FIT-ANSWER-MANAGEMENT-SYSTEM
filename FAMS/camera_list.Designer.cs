namespace FAMS
{
    partial class camera_list
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
            this.save_btn = new System.Windows.Forms.Button();
            this.cam_index = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(323, 3);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 36);
            this.save_btn.TabIndex = 11;
            this.save_btn.Text = "เลือก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cam_index
            // 
            this.cam_index.BackColor = System.Drawing.Color.LightYellow;
            this.cam_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cam_index.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cam_index.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cam_index.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cam_index.FormattingEnabled = true;
            this.cam_index.Location = new System.Drawing.Point(12, 6);
            this.cam_index.Name = "cam_index";
            this.cam_index.Size = new System.Drawing.Size(305, 33);
            this.cam_index.TabIndex = 9;
            // 
            // camera_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 45);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.cam_index);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "camera_list";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เลือก กล้อง WebCam";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.ComboBox cam_index;
    }
}