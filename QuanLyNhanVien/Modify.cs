using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanVien
{
    class Modify
    {
        SqlDataAdapter _adapter;
        SqlCommand cmd;
        public Modify() { }
        AccessData ac = new AccessData();

        public DataTable getAllNhanVien()
        {
            DataTable data = new DataTable();
            string query = "select * from nhanvien";
            using (SqlConnection sqlConnection = AccessData.getConnection())
            {
                sqlConnection.Open();
                _adapter = new SqlDataAdapter(query, sqlConnection);
                _adapter.Fill(data);
                sqlConnection.Close();
            }
            return data;
        }
        public bool insert(Nhanvien nhanvien)
        {
            SqlConnection conn = AccessData.getConnection();
            string query = "Insert into nhanvien values (@MANV, @TENNV, @GT, @DANTOC, @NGAYSINH, @DIACHI, @SDT, @TDHV, @MABP, @MACV)";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = nhanvien.Manv;
                cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nhanvien.Ten;
                cmd.Parameters.Add("@GT", SqlDbType.NVarChar).Value = nhanvien.Gioitinh;
                cmd.Parameters.Add("@DANTOC", SqlDbType.NVarChar).Value = nhanvien.Dantoc;
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.Date).Value = nhanvien.Birthday.ToShortDateString();
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = nhanvien.Diachi;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhanvien.Sdt;
                cmd.Parameters.Add("@TDHV", SqlDbType.NVarChar).Value = nhanvien.Tdhv;
                cmd.Parameters.Add("@MABP", SqlDbType.VarChar).Value = nhanvien.Mabp;
                cmd.Parameters.Add("@MACV", SqlDbType.VarChar).Value = nhanvien.Macv;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
