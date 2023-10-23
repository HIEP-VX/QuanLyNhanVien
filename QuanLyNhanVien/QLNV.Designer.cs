namespace QuanLyNhanVien
{
    partial class QLNV
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLNV));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaNVQLNV = new System.Windows.Forms.TextBox();
            this.txtTenNVQLNV = new System.Windows.Forms.TextBox();
            this.txtDiaChiQLNV = new System.Windows.Forms.TextBox();
            this.txtSoDTQLNV = new System.Windows.Forms.TextBox();
            this.txtGTQLNV = new System.Windows.Forms.ComboBox();
            this.cbMABPQLNV = new System.Windows.Forms.ComboBox();
            this.bOPHANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyNhanVienDataSet1 = new QuanLyNhanVien.QuanLyNhanVienDataSet1();
            this.cbMACVQLNV = new System.Windows.Forms.ComboBox();
            this.cHUCVUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyNhanVienDataSet2 = new QuanLyNhanVien.QuanLyNhanVienDataSet2();
            this.dateTimeNSQLNV = new System.Windows.Forms.DateTimePicker();
            this.DataGVNhanVien = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTDHVQLSV = new System.Windows.Forms.TextBox();
            this.txtDanTocQLSV = new System.Windows.Forms.TextBox();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.btnSuaNV = new System.Windows.Forms.Button();
            this.btnXoaNV = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.quanLyNhanVienDataSet = new QuanLyNhanVien.QuanLyNhanVienDataSet();
            this.quanLyNhanVienDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bOPHANTableAdapter = new QuanLyNhanVien.QuanLyNhanVienDataSet1TableAdapters.BOPHANTableAdapter();
            this.cHUCVUTableAdapter = new QuanLyNhanVien.QuanLyNhanVienDataSet2TableAdapters.CHUCVUTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bOPHANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHUCVUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày Sinh\r\n(mm/dd/yyyy)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mã bộ phận";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 413);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mã chức vụ";
            // 
            // txtMaNVQLNV
            // 
            this.txtMaNVQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNVQLNV.Location = new System.Drawing.Point(145, 28);
            this.txtMaNVQLNV.Name = "txtMaNVQLNV";
            this.txtMaNVQLNV.Size = new System.Drawing.Size(203, 26);
            this.txtMaNVQLNV.TabIndex = 8;
            // 
            // txtTenNVQLNV
            // 
            this.txtTenNVQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNVQLNV.Location = new System.Drawing.Point(145, 68);
            this.txtTenNVQLNV.Name = "txtTenNVQLNV";
            this.txtTenNVQLNV.Size = new System.Drawing.Size(203, 26);
            this.txtTenNVQLNV.TabIndex = 9;
            // 
            // txtDiaChiQLNV
            // 
            this.txtDiaChiQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiQLNV.Location = new System.Drawing.Point(145, 238);
            this.txtDiaChiQLNV.Multiline = true;
            this.txtDiaChiQLNV.Name = "txtDiaChiQLNV";
            this.txtDiaChiQLNV.Size = new System.Drawing.Size(203, 24);
            this.txtDiaChiQLNV.TabIndex = 10;
            // 
            // txtSoDTQLNV
            // 
            this.txtSoDTQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDTQLNV.Location = new System.Drawing.Point(145, 321);
            this.txtSoDTQLNV.Name = "txtSoDTQLNV";
            this.txtSoDTQLNV.Size = new System.Drawing.Size(203, 26);
            this.txtSoDTQLNV.TabIndex = 11;
            // 
            // txtGTQLNV
            // 
            this.txtGTQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGTQLNV.FormattingEnabled = true;
            this.txtGTQLNV.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.txtGTQLNV.Location = new System.Drawing.Point(145, 110);
            this.txtGTQLNV.Name = "txtGTQLNV";
            this.txtGTQLNV.Size = new System.Drawing.Size(203, 28);
            this.txtGTQLNV.TabIndex = 12;
            // 
            // cbMABPQLNV
            // 
            this.cbMABPQLNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMABPQLNV.DataSource = this.bOPHANBindingSource;
            this.cbMABPQLNV.DisplayMember = "MABP";
            this.cbMABPQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMABPQLNV.FormattingEnabled = true;
            this.cbMABPQLNV.Location = new System.Drawing.Point(145, 364);
            this.cbMABPQLNV.Name = "cbMABPQLNV";
            this.cbMABPQLNV.Size = new System.Drawing.Size(203, 28);
            this.cbMABPQLNV.TabIndex = 13;
            // 
            // bOPHANBindingSource
            // 
            this.bOPHANBindingSource.DataMember = "BOPHAN";
            this.bOPHANBindingSource.DataSource = this.quanLyNhanVienDataSet1;
            // 
            // quanLyNhanVienDataSet1
            // 
            this.quanLyNhanVienDataSet1.DataSetName = "QuanLyNhanVienDataSet1";
            this.quanLyNhanVienDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbMACVQLNV
            // 
            this.cbMACVQLNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMACVQLNV.DataSource = this.cHUCVUBindingSource;
            this.cbMACVQLNV.DisplayMember = "MACV";
            this.cbMACVQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMACVQLNV.FormattingEnabled = true;
            this.cbMACVQLNV.Location = new System.Drawing.Point(145, 408);
            this.cbMACVQLNV.Name = "cbMACVQLNV";
            this.cbMACVQLNV.Size = new System.Drawing.Size(203, 28);
            this.cbMACVQLNV.TabIndex = 14;
            // 
            // cHUCVUBindingSource
            // 
            this.cHUCVUBindingSource.DataMember = "CHUCVU";
            this.cHUCVUBindingSource.DataSource = this.quanLyNhanVienDataSet2;
            // 
            // quanLyNhanVienDataSet2
            // 
            this.quanLyNhanVienDataSet2.DataSetName = "QuanLyNhanVienDataSet2";
            this.quanLyNhanVienDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimeNSQLNV
            // 
            this.dateTimeNSQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeNSQLNV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeNSQLNV.Location = new System.Drawing.Point(145, 194);
            this.dateTimeNSQLNV.Name = "dateTimeNSQLNV";
            this.dateTimeNSQLNV.Size = new System.Drawing.Size(203, 26);
            this.dateTimeNSQLNV.TabIndex = 15;
            // 
            // DataGVNhanVien
            // 
            this.DataGVNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGVNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGVNhanVien.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGVNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVNhanVien.Location = new System.Drawing.Point(393, 12);
            this.DataGVNhanVien.Name = "DataGVNhanVien";
            this.DataGVNhanVien.ReadOnly = true;
            this.DataGVNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGVNhanVien.Size = new System.Drawing.Size(921, 676);
            this.DataGVNhanVien.TabIndex = 16;
            this.DataGVNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGVNhanVien_CellClick);
            this.DataGVNhanVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGVNhanVien_CellFormatting);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "Dân tộc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Trình độ học vấn";
            // 
            // txtTDHVQLSV
            // 
            this.txtTDHVQLSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDHVQLSV.Location = new System.Drawing.Point(145, 279);
            this.txtTDHVQLSV.Name = "txtTDHVQLSV";
            this.txtTDHVQLSV.Size = new System.Drawing.Size(203, 26);
            this.txtTDHVQLSV.TabIndex = 19;
            // 
            // txtDanTocQLSV
            // 
            this.txtDanTocQLSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanTocQLSV.Location = new System.Drawing.Point(145, 152);
            this.txtDanTocQLSV.Name = "txtDanTocQLSV";
            this.txtDanTocQLSV.Size = new System.Drawing.Size(203, 26);
            this.txtDanTocQLSV.TabIndex = 20;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNV.Image = global::QuanLyNhanVien.Properties.Resources._13_1;
            this.btnThemNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNV.Location = new System.Drawing.Point(55, 40);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(67, 36);
            this.btnThemNV.TabIndex = 21;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNV.Image = global::QuanLyNhanVien.Properties.Resources.button_update_icon;
            this.btnSuaNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaNV.Location = new System.Drawing.Point(145, 40);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(67, 36);
            this.btnSuaNV.TabIndex = 22;
            this.btnSuaNV.Text = "Sửa";
            this.btnSuaNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaNV.UseVisualStyleBackColor = true;
            this.btnSuaNV.Click += new System.EventHandler(this.btnSuaNV_Click);
            // 
            // btnXoaNV
            // 
            this.btnXoaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNV.Image = global::QuanLyNhanVien.Properties.Resources.Button_Delete_icon_v2;
            this.btnXoaNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNV.Location = new System.Drawing.Point(235, 40);
            this.btnXoaNV.Name = "btnXoaNV";
            this.btnXoaNV.Size = new System.Drawing.Size(67, 36);
            this.btnXoaNV.TabIndex = 23;
            this.btnXoaNV.Text = "Xóa";
            this.btnXoaNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaNV.UseVisualStyleBackColor = true;
            this.btnXoaNV.Click += new System.EventHandler(this.btnXoaNV_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Image = global::QuanLyNhanVien.Properties.Resources.button_refresh_icon;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(145, 95);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(67, 36);
            this.btnLamMoi.TabIndex = 24;
            this.btnLamMoi.Text = "Mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::QuanLyNhanVien.Properties.Resources.button_find_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(55, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 36);
            this.button1.TabIndex = 25;
            this.button1.Text = "Tìm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quanLyNhanVienDataSet
            // 
            this.quanLyNhanVienDataSet.DataSetName = "QuanLyNhanVienDataSet";
            this.quanLyNhanVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyNhanVienDataSetBindingSource
            // 
            this.quanLyNhanVienDataSetBindingSource.DataSource = this.quanLyNhanVienDataSet;
            this.quanLyNhanVienDataSetBindingSource.Position = 0;
            // 
            // bOPHANTableAdapter
            // 
            this.bOPHANTableAdapter.ClearBeforeFill = true;
            // 
            // cHUCVUTableAdapter
            // 
            this.cHUCVUTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::QuanLyNhanVien.Properties.Resources.button_excel_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(235, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 36);
            this.button2.TabIndex = 26;
            this.button2.Text = "Excel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenNVQLNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDanTocQLSV);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTDHVQLSV);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtMaNVQLNV);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDiaChiQLNV);
            this.groupBox1.Controls.Add(this.txtSoDTQLNV);
            this.groupBox1.Controls.Add(this.dateTimeNSQLNV);
            this.groupBox1.Controls.Add(this.txtGTQLNV);
            this.groupBox1.Controls.Add(this.cbMACVQLNV);
            this.groupBox1.Controls.Add(this.cbMABPQLNV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 458);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập dữ liệu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaNV);
            this.groupBox2.Controls.Add(this.btnThemNV);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnSuaNV);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 510);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 161);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // QLNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 700);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DataGVNhanVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QLNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên";
            this.Load += new System.EventHandler(this.QLNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOPHANBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHUCVUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaNVQLNV;
        private System.Windows.Forms.TextBox txtTenNVQLNV;
        private System.Windows.Forms.TextBox txtDiaChiQLNV;
        private System.Windows.Forms.TextBox txtSoDTQLNV;
        private System.Windows.Forms.ComboBox txtGTQLNV;
        private System.Windows.Forms.ComboBox cbMABPQLNV;
        private System.Windows.Forms.ComboBox cbMACVQLNV;
        private System.Windows.Forms.DateTimePicker dateTimeNSQLNV;
        private System.Windows.Forms.DataGridView DataGVNhanVien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTDHVQLSV;
        private System.Windows.Forms.TextBox txtDanTocQLSV;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.Button btnSuaNV;
        private System.Windows.Forms.Button btnXoaNV;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button button1;
        private QuanLyNhanVienDataSet quanLyNhanVienDataSet;
        private System.Windows.Forms.BindingSource quanLyNhanVienDataSetBindingSource;
        private QuanLyNhanVienDataSet1 quanLyNhanVienDataSet1;
        private System.Windows.Forms.BindingSource bOPHANBindingSource;
        private QuanLyNhanVienDataSet1TableAdapters.BOPHANTableAdapter bOPHANTableAdapter;
        private QuanLyNhanVienDataSet2 quanLyNhanVienDataSet2;
        private System.Windows.Forms.BindingSource cHUCVUBindingSource;
        private QuanLyNhanVienDataSet2TableAdapters.CHUCVUTableAdapter cHUCVUTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}