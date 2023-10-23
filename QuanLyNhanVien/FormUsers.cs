using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class FormUsers : Form
    {
        int index = -1;

        List<string> listAccountType = new List<string>() { "Quản lý", "Nhân viên" };
        public FormUsers()
        {
            InitializeComponent();
        }
        void LoadListUser()
        {
            dgvListUser.DataSource = null;
            dgvListUser.DataSource = DanhSachTaiKhoan.Instance.ListTaiKhoan;
            dgvListUser.Refresh();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            cbLoaiTKFormUser.DataSource = listAccountType;
            LoadListUser();
        }

        private void dgvListUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // bắt sự kiện đang trỏ chuột đang chỏ dòng thứ bao nhiêu
            index = e.RowIndex; // lấy ra chỉ số
            if( index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtUserNameFormUser.Text = dgvListUser.Rows[index].Cells[0].Value.ToString();
            txtMatKhauFormUser.Text = dgvListUser.Rows[index].Cells[1].Value.ToString();

            switch (DanhSachTaiKhoan.Instance.ListTaiKhoan[index].LoaiTaiKhoan)
            {
                case true:
                    cbLoaiTKFormUser.Text = "Quản lý";
                    break;
                case false:
                    cbLoaiTKFormUser.Text = "Nhân viên";
                    break;
            }
        }

        private void btnThemUser_Click(object sender, EventArgs e)
        {
            string userName = txtUserNameFormUser.Text;
            string passWord = txtMatKhauFormUser.Text;
            bool accountType = false;

            switch (cbLoaiTKFormUser.Text)
            {
                case "Quản lý":
                    accountType= true;
                    break;
                case "Nhân viên":
                    accountType= false;
                    break;
            }
            errorProvider1.Clear();
            if(userName != "" && passWord != "")
            {
                DanhSachTaiKhoan.Instance.ListTaiKhoan.Add(new TaiKhoan(userName, passWord, accountType));
                LoadListUser();
            }
            else
            {
                if(userName == "")
                    errorProvider1.SetError(txtUserNameFormUser, "Vui lòng nhập tên đăng nhập!");
                if(passWord == "")
                    errorProvider1.SetError(txtMatKhauFormUser, "Vui lòng nhập mật khẩu!");
            }

            
        }

        private void btnSuaUser_Click(object sender, EventArgs e)
        {
            string userName = txtUserNameFormUser.Text;
            string passWord = txtMatKhauFormUser.Text;
            bool accountType = false;

            switch (cbLoaiTKFormUser.Text)
            {
                case "Quản lý":
                    accountType = true;
                    break;
                case "Nhân viên":
                    accountType = false;
                    break;
            }

            DanhSachTaiKhoan.Instance.ListTaiKhoan[index].TenTaiKhoan = userName;
            DanhSachTaiKhoan.Instance.ListTaiKhoan[index].MatKhau = passWord;
            MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadListUser();
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                DanhSachTaiKhoan.Instance.ListTaiKhoan.RemoveAt(index);
                LoadListUser();
            }
        }

        private void dgvListUser_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvListUser.DefaultCellStyle.Font = new Font("Arial", 11);
        }
    }
}