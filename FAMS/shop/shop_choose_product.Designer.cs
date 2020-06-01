namespace FAMS
{
    partial class shop_choose_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shop_choose_product));
            this.label2 = new System.Windows.Forms.Label();
            this.product_cb = new System.Windows.Forms.ComboBox();
            this.manage_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "สินค้า :";
            // 
            // product_cb
            // 
            this.product_cb.BackColor = System.Drawing.Color.LightYellow;
            this.product_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.product_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.product_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.product_cb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.product_cb.FormattingEnabled = true;
            this.product_cb.Location = new System.Drawing.Point(74, 6);
            this.product_cb.Name = "product_cb";
            this.product_cb.Size = new System.Drawing.Size(229, 28);
            this.product_cb.TabIndex = 1;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.Green;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.manage_btn.ForeColor = System.Drawing.Color.White;
            this.manage_btn.Location = new System.Drawing.Point(220, 40);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(83, 41);
            this.manage_btn.TabIndex = 2;
            this.manage_btn.Text = "เพิ่ม";
            this.manage_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // shop_choose_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 89);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.product_cb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "shop_choose_product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เลือกสินค้า";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox product_cb;
        private System.Windows.Forms.Button manage_btn;
    }
}