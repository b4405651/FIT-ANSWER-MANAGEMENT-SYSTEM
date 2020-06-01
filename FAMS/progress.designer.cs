namespace FAMS
{
    partial class progress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(progress));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.file_no = new System.Windows.Forms.Label();
            this.backgroundTask = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 62);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(273, 23);
            this.progressBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "SYNC FILES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // file_no
            // 
            this.file_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_no.Location = new System.Drawing.Point(12, 30);
            this.file_no.Name = "file_no";
            this.file_no.Size = new System.Drawing.Size(273, 23);
            this.file_no.TabIndex = 2;
            this.file_no.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundTask
            // 
            this.backgroundTask.WorkerReportsProgress = true;
            this.backgroundTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundTask_DoWork);
            this.backgroundTask.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundTask_ProgressChanged);
            this.backgroundTask.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundTask_RunWorkerCompleted);
            // 
            // progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 98);
            this.Controls.Add(this.file_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "progress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "progress";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.progress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label file_no;
        public System.ComponentModel.BackgroundWorker backgroundTask;
    }
}