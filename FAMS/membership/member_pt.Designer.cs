namespace FAMS
{
    partial class member_pt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_pt));
            this.payment_gb = new System.Windows.Forms.GroupBox();
            this.dgv_panel = new System.Windows.Forms.Panel();
            this.payment_DGV = new System.Windows.Forms.DataGridView();
            this.payment_type_txt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.card_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.card_expiry_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member_pt_payment_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_btn_panel = new System.Windows.Forms.Panel();
            this.total_payment_txt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.add_payment_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pt_emp_id = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.print_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.amount_left = new System.Windows.Forms.TextBox();
            this.amount_left_lbl1 = new System.Windows.Forms.Label();
            this.amount_left_lbl2 = new System.Windows.Forms.Label();
            this.seller_emp_lbl = new System.Windows.Forms.Label();
            this.seller_emp_id = new System.Windows.Forms.ComboBox();
            this.expiry_date = new System.Windows.Forms.MaskedTextBox();
            this.note_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.payment_gb.SuspendLayout();
            this.dgv_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payment_DGV)).BeginInit();
            this.payment_btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // payment_gb
            // 
            this.payment_gb.Controls.Add(this.dgv_panel);
            this.payment_gb.Controls.Add(this.payment_btn_panel);
            this.payment_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.payment_gb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.payment_gb.Location = new System.Drawing.Point(16, 175);
            this.payment_gb.Name = "payment_gb";
            this.payment_gb.Size = new System.Drawing.Size(653, 215);
            this.payment_gb.TabIndex = 8;
            this.payment_gb.TabStop = false;
            this.payment_gb.Text = "การชำระเงิน";
            // 
            // dgv_panel
            // 
            this.dgv_panel.Controls.Add(this.payment_DGV);
            this.dgv_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_panel.Location = new System.Drawing.Point(3, 63);
            this.dgv_panel.Name = "dgv_panel";
            this.dgv_panel.Size = new System.Drawing.Size(647, 149);
            this.dgv_panel.TabIndex = 1;
            // 
            // payment_DGV
            // 
            this.payment_DGV.AllowUserToAddRows = false;
            this.payment_DGV.AllowUserToResizeColumns = false;
            this.payment_DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.payment_DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.payment_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.payment_DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.payment_DGV.BackgroundColor = System.Drawing.Color.LightYellow;
            this.payment_DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.payment_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.payment_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payment_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.payment_type_txt,
            this.payment_amount,
            this.card_no,
            this.card_expiry_date,
            this.receive_by,
            this.receive_datetime,
            this.payment_type,
            this.member_pt_payment_id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.payment_DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.payment_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payment_DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.payment_DGV.EnableHeadersVisualStyles = false;
            this.payment_DGV.Location = new System.Drawing.Point(0, 0);
            this.payment_DGV.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.payment_DGV.MultiSelect = false;
            this.payment_DGV.Name = "payment_DGV";
            this.payment_DGV.ReadOnly = true;
            this.payment_DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.payment_DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.payment_DGV.RowHeadersVisible = false;
            this.payment_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_DGV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.payment_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.payment_DGV.Size = new System.Drawing.Size(647, 149);
            this.payment_DGV.TabIndex = 11;
            this.payment_DGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.payment_DGV_RowsAdded);
            this.payment_DGV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.payment_DGV_RowsRemoved);
            // 
            // payment_type_txt
            // 
            this.payment_type_txt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.payment_type_txt.HeaderText = "ชำระโดย";
            this.payment_type_txt.Name = "payment_type_txt";
            this.payment_type_txt.ReadOnly = true;
            this.payment_type_txt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.payment_type_txt.Width = 85;
            // 
            // payment_amount
            // 
            this.payment_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.payment_amount.HeaderText = "จำนวน";
            this.payment_amount.Name = "payment_amount";
            this.payment_amount.ReadOnly = true;
            this.payment_amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.payment_amount.Width = 69;
            // 
            // card_no
            // 
            this.card_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.card_no.HeaderText = "หมายเลขบัตร";
            this.card_no.Name = "card_no";
            this.card_no.ReadOnly = true;
            this.card_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.card_no.Width = 116;
            // 
            // card_expiry_date
            // 
            this.card_expiry_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.card_expiry_date.HeaderText = "วันหมดอายุบัตร";
            this.card_expiry_date.Name = "card_expiry_date";
            this.card_expiry_date.ReadOnly = true;
            this.card_expiry_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.card_expiry_date.Width = 127;
            // 
            // receive_by
            // 
            this.receive_by.HeaderText = "ผู้รับเงิน";
            this.receive_by.Name = "receive_by";
            this.receive_by.ReadOnly = true;
            this.receive_by.Width = 96;
            // 
            // receive_datetime
            // 
            this.receive_datetime.HeaderText = "รับเงินเมื่อ";
            this.receive_datetime.Name = "receive_datetime";
            this.receive_datetime.ReadOnly = true;
            this.receive_datetime.Width = 113;
            // 
            // payment_type
            // 
            this.payment_type.HeaderText = "payment_type";
            this.payment_type.Name = "payment_type";
            this.payment_type.ReadOnly = true;
            this.payment_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.payment_type.Visible = false;
            this.payment_type.Width = 136;
            // 
            // member_pt_payment_id
            // 
            this.member_pt_payment_id.HeaderText = "member_pt_payment_id";
            this.member_pt_payment_id.Name = "member_pt_payment_id";
            this.member_pt_payment_id.ReadOnly = true;
            this.member_pt_payment_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.member_pt_payment_id.Visible = false;
            this.member_pt_payment_id.Width = 216;
            // 
            // payment_btn_panel
            // 
            this.payment_btn_panel.Controls.Add(this.total_payment_txt);
            this.payment_btn_panel.Controls.Add(this.label2);
            this.payment_btn_panel.Controls.Add(this.add_payment_btn);
            this.payment_btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.payment_btn_panel.Location = new System.Drawing.Point(3, 22);
            this.payment_btn_panel.Name = "payment_btn_panel";
            this.payment_btn_panel.Size = new System.Drawing.Size(647, 41);
            this.payment_btn_panel.TabIndex = 6;
            // 
            // total_payment_txt
            // 
            this.total_payment_txt.AutoSize = true;
            this.total_payment_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.total_payment_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.total_payment_txt.Location = new System.Drawing.Point(55, 10);
            this.total_payment_txt.Name = "total_payment_txt";
            this.total_payment_txt.Size = new System.Drawing.Size(15, 20);
            this.total_payment_txt.TabIndex = 13;
            this.total_payment_txt.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "รวม : ";
            // 
            // add_payment_btn
            // 
            this.add_payment_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.add_payment_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_payment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_payment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.add_payment_btn.ForeColor = System.Drawing.Color.White;
            this.add_payment_btn.Location = new System.Drawing.Point(543, 0);
            this.add_payment_btn.Name = "add_payment_btn";
            this.add_payment_btn.Size = new System.Drawing.Size(104, 41);
            this.add_payment_btn.TabIndex = 10;
            this.add_payment_btn.Text = "ชำระเงิน";
            this.add_payment_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.add_payment_btn.UseVisualStyleBackColor = false;
            this.add_payment_btn.Click += new System.EventHandler(this.add_payment_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(16, 393);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 36);
            this.save_btn.TabIndex = 12;
            this.save_btn.Text = "บันทึก";
            this.save_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(278, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 71;
            this.label4.Text = "เทรนเนอร์ :";
            // 
            // pt_emp_id
            // 
            this.pt_emp_id.BackColor = System.Drawing.Color.LightYellow;
            this.pt_emp_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pt_emp_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pt_emp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.pt_emp_id.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pt_emp_id.FormattingEnabled = true;
            this.pt_emp_id.Location = new System.Drawing.Point(373, 43);
            this.pt_emp_id.Name = "pt_emp_id";
            this.pt_emp_id.Size = new System.Drawing.Size(296, 28);
            this.pt_emp_id.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(15, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 72;
            this.label7.Text = "วันหมดอายุ : ";
            // 
            // print_btn
            // 
            this.print_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.print_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.print_btn.ForeColor = System.Drawing.Color.White;
            this.print_btn.Location = new System.Drawing.Point(550, -1);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(129, 40);
            this.print_btn.TabIndex = 10;
            this.print_btn.Text = "พิมพ์ใบเสร็จ";
            this.print_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.print_btn.UseVisualStyleBackColor = false;
            this.print_btn.Visible = false;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 75;
            this.label3.Text = "ชั่วโมง";
            // 
            // hours
            // 
            this.hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.hours.ForeColor = System.Drawing.Color.DodgerBlue;
            this.hours.Location = new System.Drawing.Point(140, 13);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(58, 26);
            this.hours.TabIndex = 1;
            this.hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hours_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "จำนวน ชั่วโมง : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(484, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 78;
            this.label5.Text = "บาท";
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.price.ForeColor = System.Drawing.Color.DodgerBlue;
            this.price.Location = new System.Drawing.Point(373, 13);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(105, 26);
            this.price.TabIndex = 2;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 77;
            this.label6.Text = "ราคา : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 81;
            this.label8.Text = "เดือน";
            // 
            // age
            // 
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.age.ForeColor = System.Drawing.Color.DodgerBlue;
            this.age.Location = new System.Drawing.Point(71, 43);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(58, 26);
            this.age.TabIndex = 3;
            this.age.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.age.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.age_KeyPress);
            this.age.KeyUp += new System.Windows.Forms.KeyEventHandler(this.age_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 80;
            this.label9.Text = "อายุ : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(281, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 20);
            this.label10.TabIndex = 84;
            this.label10.Text = "( วว / ดด / ปี พ.ศ. )";
            // 
            // start_date
            // 
            this.start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.start_date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.start_date.Location = new System.Drawing.Point(140, 77);
            this.start_date.Margin = new System.Windows.Forms.Padding(4);
            this.start_date.Mask = "00/00/0000";
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(132, 26);
            this.start_date.TabIndex = 5;
            this.start_date.ValidatingType = typeof(System.DateTime);
            this.start_date.KeyUp += new System.Windows.Forms.KeyEventHandler(this.start_date_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(15, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 20);
            this.label11.TabIndex = 83;
            this.label11.Text = "วันที่เริ่มต้น PT :";
            // 
            // amount_left
            // 
            this.amount_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.amount_left.ForeColor = System.Drawing.Color.DodgerBlue;
            this.amount_left.Location = new System.Drawing.Point(562, 77);
            this.amount_left.Name = "amount_left";
            this.amount_left.Size = new System.Drawing.Size(58, 26);
            this.amount_left.TabIndex = 6;
            this.amount_left.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.amount_left.Visible = false;
            this.amount_left.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_left_KeyPress);
            // 
            // amount_left_lbl1
            // 
            this.amount_left_lbl1.AutoSize = true;
            this.amount_left_lbl1.Location = new System.Drawing.Point(454, 80);
            this.amount_left_lbl1.Name = "amount_left_lbl1";
            this.amount_left_lbl1.Size = new System.Drawing.Size(104, 20);
            this.amount_left_lbl1.TabIndex = 86;
            this.amount_left_lbl1.Text = "ชั่วโมงเหลือ : ";
            this.amount_left_lbl1.Visible = false;
            // 
            // amount_left_lbl2
            // 
            this.amount_left_lbl2.AutoSize = true;
            this.amount_left_lbl2.Location = new System.Drawing.Point(625, 81);
            this.amount_left_lbl2.Name = "amount_left_lbl2";
            this.amount_left_lbl2.Size = new System.Drawing.Size(54, 20);
            this.amount_left_lbl2.TabIndex = 87;
            this.amount_left_lbl2.Text = "ชั่วโมง";
            this.amount_left_lbl2.Visible = false;
            // 
            // seller_emp_lbl
            // 
            this.seller_emp_lbl.AutoSize = true;
            this.seller_emp_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.seller_emp_lbl.Location = new System.Drawing.Point(311, 111);
            this.seller_emp_lbl.Name = "seller_emp_lbl";
            this.seller_emp_lbl.Size = new System.Drawing.Size(56, 20);
            this.seller_emp_lbl.TabIndex = 89;
            this.seller_emp_lbl.Text = "ผู้ขาย :";
            this.seller_emp_lbl.Visible = false;
            // 
            // seller_emp_id
            // 
            this.seller_emp_id.BackColor = System.Drawing.Color.LightYellow;
            this.seller_emp_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seller_emp_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seller_emp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.seller_emp_id.ForeColor = System.Drawing.Color.DodgerBlue;
            this.seller_emp_id.FormattingEnabled = true;
            this.seller_emp_id.Location = new System.Drawing.Point(373, 108);
            this.seller_emp_id.Name = "seller_emp_id";
            this.seller_emp_id.Size = new System.Drawing.Size(296, 28);
            this.seller_emp_id.TabIndex = 8;
            this.seller_emp_id.Visible = false;
            // 
            // expiry_date
            // 
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.expiry_date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.expiry_date.Location = new System.Drawing.Point(121, 108);
            this.expiry_date.Margin = new System.Windows.Forms.Padding(4);
            this.expiry_date.Mask = "00/00/0000";
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(132, 26);
            this.expiry_date.TabIndex = 7;
            this.expiry_date.ValidatingType = typeof(System.DateTime);
            // 
            // note_txt
            // 
            this.note_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.note_txt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.note_txt.Location = new System.Drawing.Point(77, 139);
            this.note_txt.Name = "note_txt";
            this.note_txt.Size = new System.Drawing.Size(592, 26);
            this.note_txt.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "บันทึก : ";
            // 
            // member_pt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 441);
            this.Controls.Add(this.note_txt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.seller_emp_lbl);
            this.Controls.Add(this.seller_emp_id);
            this.Controls.Add(this.amount_left_lbl2);
            this.Controls.Add(this.amount_left);
            this.Controls.Add(this.amount_left_lbl1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.age);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pt_emp_id);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.payment_gb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "member_pt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลคอร์ส PT และการชำระเงิน";
            this.Load += new System.EventHandler(this.member_pt_Load);
            this.payment_gb.ResumeLayout(false);
            this.dgv_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.payment_DGV)).EndInit();
            this.payment_btn_panel.ResumeLayout(false);
            this.payment_btn_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox payment_gb;
        private System.Windows.Forms.Panel dgv_panel;
        public System.Windows.Forms.DataGridView payment_DGV;
        private System.Windows.Forms.Panel payment_btn_panel;
        private System.Windows.Forms.Label total_payment_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button add_payment_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox pt_emp_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_type_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_expiry_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn member_pt_payment_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox start_date;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox amount_left;
        private System.Windows.Forms.Label amount_left_lbl1;
        private System.Windows.Forms.Label amount_left_lbl2;
        private System.Windows.Forms.Label seller_emp_lbl;
        private System.Windows.Forms.ComboBox seller_emp_id;
        public System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.MaskedTextBox expiry_date;
        private System.Windows.Forms.TextBox note_txt;
        private System.Windows.Forms.Label label12;
    }
}