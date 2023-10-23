namespace QuanLyNhanVien
{
    partial class PhuCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhuCap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMapc = new System.Windows.Forms.ComboBox();
            this.pHUCAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyNhanVienDataSet7 = new QuanLyNhanVien.QuanLyNhanVienDataSet7();
            this.txtNDPC = new System.Windows.Forms.TextBox();
            this.txtTienPC = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnCap = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dataGVPhuCap = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pHUCAPTableAdapter = new QuanLyNhanVien.QuanLyNhanVienDataSet7TableAdapters.PHUCAPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pHUCAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPhuCap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phụ cấp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nội dung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số tiền";
            // 
            // cbMapc
            // 
            this.cbMapc.DataSource = this.pHUCAPBindingSource;
            this.cbMapc.DisplayMember = "MAPC";
            this.cbMapc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMapc.FormattingEnabled = true;
            this.cbMapc.Location = new System.Drawing.Point(125, 16);
            this.cbMapc.Name = "cbMapc";
            this.cbMapc.Size = new System.Drawing.Size(244, 26);
            this.cbMapc.TabIndex = 3;
            // 
            // pHUCAPBindingSource
            // 
            this.pHUCAPBindingSource.DataMember = "PHUCAP";
            this.pHUCAPBindingSource.DataSource = this.quanLyNhanVienDataSet7;
            // 
            // quanLyNhanVienDataSet7
            // 
            this.quanLyNhanVienDataSet7.DataSetName = "QuanLyNhanVienDataSet7";
            this.quanLyNhanVienDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNDPC
            // 
            this.txtNDPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDPC.Location = new System.Drawing.Point(125, 55);
            this.txtNDPC.Name = "txtNDPC";
            this.txtNDPC.Size = new System.Drawing.Size(244, 26);
            this.txtNDPC.TabIndex = 4;
            // 
            // txtTienPC
            // 
            this.txtTienPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienPC.Location = new System.Drawing.Point(125, 92);
            this.txtTienPC.Name = "txtTienPC";
            this.txtTienPC.Size = new System.Drawing.Size(244, 26);
            this.txtTienPC.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QuanLyNhanVien.Properties.Resources.button_add_icon;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(396, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(67, 36);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QuanLyNhanVien.Properties.Resources.Button_Delete_icon1;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(570, 19);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(67, 36);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Image = global::QuanLyNhanVien.Properties.Resources.button_refresh_icon;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(484, 68);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(67, 36);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnCap
            // 
            this.btnCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCap.Image = global::QuanLyNhanVien.Properties.Resources.button_update_icon;
            this.btnCap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCap.Location = new System.Drawing.Point(484, 19);
            this.btnCap.Name = "btnCap";
            this.btnCap.Size = new System.Drawing.Size(67, 36);
            this.btnCap.TabIndex = 9;
            this.btnCap.Text = "Sửa";
            this.btnCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCap.UseVisualStyleBackColor = true;
            this.btnCap.Click += new System.EventHandler(this.btnCap_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Image = global::QuanLyNhanVien.Properties.Resources.button_find_icon;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(396, 68);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(67, 36);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dataGVPhuCap
            // 
            this.dataGVPhuCap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGVPhuCap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVPhuCap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGVPhuCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVPhuCap.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGVPhuCap.Location = new System.Drawing.Point(12, 133);
            this.dataGVPhuCap.Name = "dataGVPhuCap";
            this.dataGVPhuCap.ReadOnly = true;
            this.dataGVPhuCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVPhuCap.Size = new System.Drawing.Size(663, 196);
            this.dataGVPhuCap.TabIndex = 11;
            this.dataGVPhuCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVPhuCap_CellClick);
            this.dataGVPhuCap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGVPhuCap_CellFormatting);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::QuanLyNhanVien.Properties.Resources.button_excel_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(571, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "Excel";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pHUCAPTableAdapter
            // 
            this.pHUCAPTableAdapter.ClearBeforeFill = true;
            // 
            // PhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(686, 341);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGVPhuCap);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnCap);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTienPC);
            this.Controls.Add(this.txtNDPC);
            this.Controls.Add(this.cbMapc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PhuCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng phụ cấp";
            this.Load += new System.EventHandler(this.PhuCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pHUCAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPhuCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMapc;
        private System.Windows.Forms.TextBox txtNDPC;
        private System.Windows.Forms.TextBox txtTienPC;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnCap;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGVPhuCap;
        private System.Windows.Forms.Button button1;
        private QuanLyNhanVienDataSet7 quanLyNhanVienDataSet7;
        private System.Windows.Forms.BindingSource pHUCAPBindingSource;
        private QuanLyNhanVienDataSet7TableAdapters.PHUCAPTableAdapter pHUCAPTableAdapter;
    }
}