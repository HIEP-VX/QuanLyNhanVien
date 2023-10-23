namespace QuanLyNhanVien
{
    partial class KhenThuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhenThuong));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMa = new System.Windows.Forms.ComboBox();
            this.kHENTHUONGKYLUATBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyNhanVienDataSet8 = new QuanLyNhanVien.QuanLyNhanVienDataSet8();
            this.txtND = new System.Windows.Forms.TextBox();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.dtpNK = new System.Windows.Forms.DateTimePicker();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGVKTKL = new System.Windows.Forms.DataGridView();
            this.quanLyNhanVienDataSet = new QuanLyNhanVien.QuanLyNhanVienDataSet();
            this.kHENTHUONGKYLUATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kHENTHUONG_KYLUATTableAdapter = new QuanLyNhanVien.QuanLyNhanVienDataSetTableAdapters.KHENTHUONG_KYLUATTableAdapter();
            this.kHENTHUONG_KYLUATTableAdapter1 = new QuanLyNhanVien.QuanLyNhanVienDataSet8TableAdapters.KHENTHUONG_KYLUATTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kHENTHUONGKYLUATBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVKTKL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHENTHUONGKYLUATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số KT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nội dung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày ký ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã nhân viên";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbMa
            // 
            this.cbMa.DataSource = this.kHENTHUONGKYLUATBindingSource1;
            this.cbMa.DisplayMember = "MAKP";
            this.cbMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMa.FormattingEnabled = true;
            this.cbMa.Location = new System.Drawing.Point(116, 36);
            this.cbMa.Name = "cbMa";
            this.cbMa.Size = new System.Drawing.Size(111, 26);
            this.cbMa.TabIndex = 6;
            // 
            // kHENTHUONGKYLUATBindingSource1
            // 
            this.kHENTHUONGKYLUATBindingSource1.DataMember = "KHENTHUONG_KYLUAT";
            this.kHENTHUONGKYLUATBindingSource1.DataSource = this.quanLyNhanVienDataSet8;
            // 
            // quanLyNhanVienDataSet8
            // 
            this.quanLyNhanVienDataSet8.DataSetName = "QuanLyNhanVienDataSet8";
            this.quanLyNhanVienDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtND
            // 
            this.txtND.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtND.Location = new System.Drawing.Point(116, 197);
            this.txtND.Multiline = true;
            this.txtND.Name = "txtND";
            this.txtND.Size = new System.Drawing.Size(190, 89);
            this.txtND.TabIndex = 7;
            // 
            // txtSo
            // 
            this.txtSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo.Location = new System.Drawing.Point(116, 139);
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(149, 24);
            this.txtSo.TabIndex = 8;
            // 
            // dtpNK
            // 
            this.dtpNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNK.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNK.Location = new System.Drawing.Point(116, 378);
            this.dtpNK.Name = "dtpNK";
            this.dtpNK.Size = new System.Drawing.Size(149, 24);
            this.dtpNK.TabIndex = 9;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(116, 88);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(149, 24);
            this.txtMaNV.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QuanLyNhanVien.Properties.Resources.button_add_icon;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(41, 472);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(67, 36);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QuanLyNhanVien.Properties.Resources.button_update_icon;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(120, 472);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(67, 36);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QuanLyNhanVien.Properties.Resources.Button_Delete_icon1;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(198, 472);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(67, 36);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTK
            // 
            this.btnTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTK.Image = global::QuanLyNhanVien.Properties.Resources.button_find_icon;
            this.btnTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTK.Location = new System.Drawing.Point(41, 518);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(67, 36);
            this.btnTK.TabIndex = 15;
            this.btnTK.Text = "Tìm";
            this.btnTK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::QuanLyNhanVien.Properties.Resources.button_refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(120, 518);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 36);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGVKTKL
            // 
            this.dataGVKTKL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGVKTKL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVKTKL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVKTKL.Location = new System.Drawing.Point(327, 12);
            this.dataGVKTKL.Name = "dataGVKTKL";
            this.dataGVKTKL.ReadOnly = true;
            this.dataGVKTKL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVKTKL.Size = new System.Drawing.Size(930, 562);
            this.dataGVKTKL.TabIndex = 17;
            this.dataGVKTKL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVKTKL_CellClick);
            this.dataGVKTKL.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGVKTKL_CellFormatting);
            // 
            // quanLyNhanVienDataSet
            // 
            this.quanLyNhanVienDataSet.DataSetName = "QuanLyNhanVienDataSet";
            this.quanLyNhanVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kHENTHUONGKYLUATBindingSource
            // 
            this.kHENTHUONGKYLUATBindingSource.DataMember = "KHENTHUONG_KYLUAT";
            this.kHENTHUONGKYLUATBindingSource.DataSource = this.quanLyNhanVienDataSet;
            // 
            // kHENTHUONG_KYLUATTableAdapter
            // 
            this.kHENTHUONG_KYLUATTableAdapter.ClearBeforeFill = true;
            // 
            // kHENTHUONG_KYLUATTableAdapter1
            // 
            this.kHENTHUONG_KYLUATTableAdapter1.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::QuanLyNhanVien.Properties.Resources.button_excel_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(198, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 36);
            this.button1.TabIndex = 18;
            this.button1.Text = "Excel";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Số tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(116, 319);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(149, 24);
            this.txtSoTien.TabIndex = 20;
            // 
            // KhenThuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1269, 586);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGVKTKL);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.dtpNK);
            this.Controls.Add(this.txtSo);
            this.Controls.Add(this.txtND);
            this.Controls.Add(this.cbMa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KhenThuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khen thưởng";
            this.Load += new System.EventHandler(this.KhenThuong_KyLuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kHENTHUONGKYLUATBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVKTKL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHENTHUONGKYLUATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMa;
        private System.Windows.Forms.TextBox txtND;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.DateTimePicker dtpNK;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGVKTKL;
        private QuanLyNhanVienDataSet quanLyNhanVienDataSet;
        private System.Windows.Forms.BindingSource kHENTHUONGKYLUATBindingSource;
        private QuanLyNhanVienDataSetTableAdapters.KHENTHUONG_KYLUATTableAdapter kHENTHUONG_KYLUATTableAdapter;
        private QuanLyNhanVienDataSet8 quanLyNhanVienDataSet8;
        private System.Windows.Forms.BindingSource kHENTHUONGKYLUATBindingSource1;
        private QuanLyNhanVienDataSet8TableAdapters.KHENTHUONG_KYLUATTableAdapter kHENTHUONG_KYLUATTableAdapter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label7;
    }
}