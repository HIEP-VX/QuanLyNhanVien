using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    class Nhanvien
    {
        private string _manv;
        private string _ten;
        private string _gioitinh;
        private string _dantoc;
        private DateTime _birthday;
        private string _diachi;
        private string _sdt;
        private string _tdhv;
        private string _mabp;
        private string _macv;

        public Nhanvien()
        {
        }

        public Nhanvien(string manv, string ten, string gioitinh, string dantoc, DateTime birthday, string diachi, string sdt, string tdhv, string mabp, string macv)
        {
            Manv = manv;
            Ten = ten;
            Gioitinh = gioitinh;
            Dantoc = dantoc;
            Birthday = birthday;
            Diachi = diachi;
            Sdt = sdt;
            Tdhv = tdhv;
            Mabp = mabp;
            Macv = macv;
        }

        public string Manv { get => _manv; set => _manv = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public string Dantoc { get => _dantoc; set => _dantoc = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Sdt { get => _sdt; set => _sdt = value; }
        public string Tdhv { get => _tdhv; set => _tdhv = value; }
        public string Mabp { get => _mabp; set => _mabp = value; }
        public string Macv { get => _macv; set => _macv = value; }
    }
}
