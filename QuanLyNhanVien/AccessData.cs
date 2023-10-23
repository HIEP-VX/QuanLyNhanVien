using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace QuanLyNhanVien
{
    class AccessData
    {
        // chuỗi này mở kết nối đến database
        public static SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-6GG2D7G\DATASSMS;Initial Catalog=QuanLyNhanVien;Integrated Security=True");
        }

        public DataTable createTable(string sql)
        {
            SqlConnection conn = getConnection();
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public void ExcuteNonQuery(string sql)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
    }
}
