namespace QuanLyNhanVien
{
    partial class FormUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsers));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserNameFormUser = new System.Windows.Forms.TextBox();
            this.txtMatKhauFormUser = new System.Windows.Forms.TextBox();
            this.cbLoaiTKFormUser = new System.Windows.Forms.ComboBox();
            this.btnThemUser = new System.Windows.Forms.Button();
            this.btnSuaUser = new System.Windows.Forms.Button();
            this.btnXoaUser = new System.Windows.Forms.Button();
            this.dgvListUser = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Loại tài khoản";
            // 
            // txtUserNameFormUser
            // 
            this.txtUserNameFormUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNameFormUser.Location = new System.Drawing.Point(142, 28);
            this.txtUserNameFormUser.Name = "txtUserNameFormUser";
            this.txtUserNameFormUser.Size = new System.Drawing.Size(182, 24);
            this.txtUserNameFormUser.TabIndex = 3;
            // 
            // txtMatKhauFormUser
            // 
            this.txtMatKhauFormUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauFormUser.Location = new System.Drawing.Point(142, 73);
            this.txtMatKhauFormUser.Name = "txtMatKhauFormUser";
            this.txtMatKhauFormUser.Size = new System.Drawing.Size(182, 24);
            this.txtMatKhauFormUser.TabIndex = 4;
            // 
            // cbLoaiTKFormUser
            // 
            this.cbLoaiTKFormUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiTKFormUser.FormattingEnabled = true;
            this.cbLoaiTKFormUser.Location = new System.Drawing.Point(142, 117);
            this.cbLoaiTKFormUser.Name = "cbLoaiTKFormUser";
            this.cbLoaiTKFormUser.Size = new System.Drawing.Size(182, 26);
            this.cbLoaiTKFormUser.TabIndex = 5;
            // 
            // btnThemUser
            // 
            this.btnThemUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemUser.Image = global::QuanLyNhanVien.Properties.Resources.button_add_icon;
            this.btnThemUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemUser.Location = new System.Drawing.Point(42, 177);
            this.btnThemUser.Name = "btnThemUser";
            this.btnThemUser.Size = new System.Drawing.Size(67, 36);
            this.btnThemUser.TabIndex = 6;
            this.btnThemUser.Text = "Thêm";
            this.btnThemUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemUser.UseVisualStyleBackColor = true;
            this.btnThemUser.Click += new System.EventHandler(this.btnThemUser_Click);
            // 
            // btnSuaUser
            // 
            this.btnSuaUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaUser.Image = global::QuanLyNhanVien.Properties.Resources.button_update_icon;
            this.btnSuaUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaUser.Location = new System.Drawing.Point(136, 177);
            this.btnSuaUser.Name = "btnSuaUser";
            this.btnSuaUser.Size = new System.Drawing.Size(67, 36);
            this.btnSuaUser.TabIndex = 7;
            this.btnSuaUser.Text = "Sửa";
            this.btnSuaUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaUser.UseVisualStyleBackColor = true;
            this.btnSuaUser.Click += new System.EventHandler(this.btnSuaUser_Click);
            // 
            // btnXoaUser
            // 
            this.btnXoaUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaUser.Image = global::QuanLyNhanVien.Properties.Resources.Button_Delete_icon1;
            this.btnXoaUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaUser.Location = new System.Drawing.Point(229, 177);
            this.btnXoaUser.Name = "btnXoaUser";
            this.btnXoaUser.Size = new System.Drawing.Size(67, 36);
            this.btnXoaUser.TabIndex = 8;
            this.btnXoaUser.Text = "Xóa";
            this.btnXoaUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaUser.UseVisualStyleBackColor = true;
            this.btnXoaUser.Click += new System.EventHandler(this.btnXoaUser_Click);
            // 
            // dgvListUser
            // 
            this.dgvListUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListUser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListUser.Location = new System.Drawing.Point(330, 12);
            this.dgvListUser.MultiSelect = false;
            this.dgvListUser.Name = "dgvListUser";
            this.dgvListUser.ReadOnly = true;
            this.dgvListUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListUser.Size = new System.Drawing.Size(501, 229);
            this.dgvListUser.TabIndex = 10;
            this.dgvListUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListUser_CellClick);
            this.dgvListUser.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListUser_CellFormatting_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(843, 253);
            this.Controls.Add(this.dgvListUser);
            this.Controls.Add(this.btnXoaUser);
            this.Controls.Add(this.btnSuaUser);
            this.Controls.Add(this.btnThemUser);
            this.Controls.Add(this.cbLoaiTKFormUser);
            this.Controls.Add(this.txtMatKhauFormUser);
            this.Controls.Add(this.txtUserNameFormUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.FormUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserNameFormUser;
        private System.Windows.Forms.TextBox txtMatKhauFormUser;
        private System.Windows.Forms.ComboBox cbLoaiTKFormUser;
        private System.Windows.Forms.Button btnThemUser;
        private System.Windows.Forms.Button btnSuaUser;
        private System.Windows.Forms.Button btnXoaUser;
        private System.Windows.Forms.DataGridView dgvListUser;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}