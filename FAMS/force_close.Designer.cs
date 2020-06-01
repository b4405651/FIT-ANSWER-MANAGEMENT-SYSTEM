namespace FAMS
{
    partial class force_close
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
            this.force_close_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // force_close_btn
            // 
            this.force_close_btn.BackColor = System.Drawing.Color.Red;
            this.force_close_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.force_close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.force_close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.force_close_btn.ForeColor = System.Drawing.Color.White;
            this.force_close_btn.Location = new System.Drawing.Point(0, 0);
            this.force_close_btn.Name = "force_close_btn";
            this.force_close_btn.Size = new System.Drawing.Size(150, 40);
            this.force_close_btn.TabIndex = 0;
            this.force_close_btn.Text = "บังคับปิดโปรแกรม";
            this.force_close_btn.UseVisualStyleBackColor = false;
            this.force_close_btn.Click += new System.EventHandler(this.force_close_btn_Click);
            // 
            // force_close
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 40);
            this.ControlBox = false;
            this.Controls.Add(this.force_close_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "force_close";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "force_close";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button force_close_btn;

    }
}