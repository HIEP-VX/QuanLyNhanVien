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
    public partial class Login : Form
    {
        List<TaiKhoan> list = DanhSachTaiKhoan.Instance.ListTaiKhoan;
        bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            for(int i = 0; i< list.Count; i++)
            {
                if (tenDangNhap == list[i].TenTaiKhoan && matKhau == list[i].MatKhau)
                {
                    // trả kết quả là loại tài khoản này là loại tài khoản gì
                    ConstVariable.loaiTaiKhoan = list[i].LoaiTaiKhoan;
                    return true;
                }
            }
            return false;
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textA = txtUserName.Text;
            string textB = txtPasswordLogin.Text;
            errorProvider1.Clear();
            if(KiemTraDangNhap(txtUserName.Text, txtPasswordLogin.Text) && textA != "" && textB != "")
            {
                MainForm f = new MainForm();
                f.Show();
                this.Hide();
                f.Logout += F_Logout;
            }
            else 
            {
                if (textA == "")
                {
                    errorProvider1.SetError(txtUserName, "Vui lòng nhập tên đăng nhập!");
                }
                else if (textB == "")
                {
                    errorProvider1.SetError(txtPasswordLogin, "Vui lòng nhập mật khẩu!");
                }
                else if (KiemTraDangNhap(txtUserName.Text, txtPasswordLogin.Text) == false){
                    MessageBox.Show("Sai thông tin đăng nhập",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }
        private void F_Logout(object sender, EventArgs e)
        {
            (sender as MainForm).isExit = false;    // trường hợp này k tắt chương trình mà chỉ đăng xuất ra thôi
            (sender as MainForm).Close();
            this.Show();
            txtPasswordLogin.Text = "";
            txtUserName.Text = "";
            checkBox1.Checked = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                txtPasswordLogin.PasswordChar = '\0';
            else
                txtPasswordLogin.PasswordChar = '*';
        }
    }
}
