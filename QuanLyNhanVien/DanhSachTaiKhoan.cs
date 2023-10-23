using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public class DanhSachTaiKhoan
    {
        // khi ma chúng ta thao tác với các thuộc tính và phương thức trong danh sách tài khoản này
        // thì sẽ thap tác thông qua cái instance này
        // sẽ hạn chế được rất nhiều lỗi

        private static DanhSachTaiKhoan instance;
        public static DanhSachTaiKhoan Instance {
            get
            {
                if(instance == null)
                       instance = new DanhSachTaiKhoan();
                return instance;
            } 
            set => instance = value; 
        }

        List<TaiKhoan> list;

        public List<TaiKhoan> ListTaiKhoan
        {
            get => list;
            set => list = value;
        }

        DanhSachTaiKhoan()
        {
            // phân quyền tài khoản
            // false là nhân viên
            // true là quản lý được phép chỉnh sửa thông tin 
            list = new List<TaiKhoan>();
            list.Add(new TaiKhoan("congtymaysonghong", "chienthang123", false));
            list.Add(new TaiKhoan("vuhiepdepzai", "1234", true));
            list.Add(new TaiKhoan("admin", "admin123", false));
        }
    }
}
