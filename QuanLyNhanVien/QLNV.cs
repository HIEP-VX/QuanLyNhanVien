using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace QuanLyNhanVien
{
    public partial class QLNV : Form
    {
        Modify modify;
        int index;
        public QLNV()
        {
            InitializeComponent();
        }

        public void PhanQuyen()
        {
            if(ConstVariable.loaiTaiKhoan == false)
            {
                btnThemNV.Enabled = btnSuaNV.Enabled = btnXoaNV.Enabled = false;
            }
        }

        AccessData ac = new AccessData();

        public void refresh()
        {
            txtMaNVQLNV.Text = "";
            txtTenNVQLNV.Text = "";
            txtGTQLNV.Text = "";
            txtDanTocQLSV.Text = "";
            dateTimeNSQLNV.Value = DateTime.Now;
            txtDiaChiQLNV.Text = "";
            txtSoDTQLNV.Text = "";
            txtTDHVQLSV.Text = "";
            cbMABPQLNV.Text = "";
            cbMACVQLNV.Text = "";
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            // TODO: This line of code loads data into the 'quanLyNhanVienDataSet2.CHUCVU' table. You can move, or remove it, as needed.
            this.cHUCVUTableAdapter.Fill(this.quanLyNhanVienDataSet2.CHUCVU);
            // TODO: This line of code loads data into the 'quanLyNhanVienDataSet1.BOPHAN' table. You can move, or remove it, as needed.
            this.bOPHANTableAdapter.Fill(this.quanLyNhanVienDataSet1.BOPHAN);
            refresh();
            string query2 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_MACV_NHANVIEN')\r\nBEGIN\r\n    ALTER TABLE NHANVIEN ADD\r\n    CONSTRAINT FK_MACV_NHANVIEN FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)\r\nEND";
            
            ac.ExcuteNonQuery(query2);
            
            try
            {
                string query = "SELECT * FROM NHANVIEN";
                DataGVNhanVien.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void DataGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; // lấy ra chỉ số

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMaNVQLNV.Text = DataGVNhanVien.Rows[index].Cells[0].Value.ToString();
            txtTenNVQLNV.Text = DataGVNhanVien.Rows[index].Cells[1].Value.ToString();
            txtGTQLNV.Text = DataGVNhanVien.Rows[index].Cells[2].Value.ToString();
            txtDanTocQLSV.Text = DataGVNhanVien.Rows[index].Cells[3].Value.ToString();
            DateTime datetimeValue = (DateTime)DataGVNhanVien.Rows[index].Cells[4].Value;
            dateTimeNSQLNV.Value = datetimeValue.Date;
            txtDiaChiQLNV.Text = DataGVNhanVien.Rows[index].Cells[5].Value.ToString();
            txtSoDTQLNV.Text = DataGVNhanVien.Rows[index].Cells[6].Value.ToString();
            txtTDHVQLSV.Text = DataGVNhanVien.Rows[index].Cells[7].Value.ToString();
            cbMABPQLNV.Text = DataGVNhanVien.Rows[index].Cells[8].Value.ToString();
            cbMACVQLNV.Text = DataGVNhanVien.Rows[index].Cells[9].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(txtMaNVQLNV.Text != "" && cbMABPQLNV.Text != "" && cbMACVQLNV.Text != "")
            {
                string sql = "Insert into nhanvien values ('" + txtMaNVQLNV.Text + "',N'" + txtTenNVQLNV.Text + "',N'" + txtGTQLNV.Text + "',N'" + txtDanTocQLSV.Text + "',N'" + dateTimeNSQLNV.Value + "',N'" + txtDiaChiQLNV.Text + "',N'" + txtSoDTQLNV.Text + "',N'" + txtTDHVQLSV.Text + "','" + cbMABPQLNV.Text + "','" + cbMACVQLNV.Text + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select * from nhanvien";
                DataGVNhanVien.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (txtMaNVQLNV.Text == "")
                    errorProvider1.SetError(txtMaNVQLNV, "Vui lòng nhập mã nhân viên!");
                if (cbMABPQLNV.Text == "")
                    errorProvider1.SetError(cbMABPQLNV, "Vui lòng chọn mã bộ phận!");
                if (cbMACVQLNV.Text == "")
                    errorProvider1.SetError(cbMACVQLNV, "Vui lòng chọn mã chức vụ!");
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string sql = "update nhanvien set TENNV = N'" + txtTenNVQLNV.Text + "', GT = N'" + txtGTQLNV.Text + "', DANTOC = N'" + txtDanTocQLSV.Text + "', NGAYSINH = '" + dateTimeNSQLNV.Value.ToString("MM/dd/yyyy") + "', DIACHI = N'" + txtDiaChiQLNV.Text + "', SDT = N'" + txtSoDTQLNV.Text + "', TDHV = N'" + txtTDHVQLSV.Text + "', MABP = '" + cbMABPQLNV.Text + "', MACV = '" + cbMACVQLNV.Text + "' where MANV = '" + txtMaNVQLNV.Text + "'";
            try
            {
                ac.ExcuteNonQuery(sql);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
            string sql1 = "select * from nhanvien";
            DataGVNhanVien.DataSource = ac.createTable(sql1);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                string sql = "Delete from nhanvien where MANV = '" + txtMaNVQLNV.Text + "'";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select * from nhanvien";
                DataGVNhanVien.DataSource = ac.createTable(sql1);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select * from nhanvien";
            DataGVNhanVien.DataSource = ac.createTable(sql);
        }
        
        // chức năng tìm kiếm. Chưa làm được
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string sql = "";
            /*if(txtMaNVQLNV.Text == "" && txtTenNVQLNV.Text == "" && txtGTQLNV.Text == "" && txtDanTocQLSV.Text == "" && txtDiaChiQLNV.Text == "" && txtSoDTQLNV.Text == "" && dateTimeNSQLNV.Value == DateTime.Now && txtTDHVQLSV.Text == "" && cbMABPQLNV.Text != "" && cbMACVQLNV.Text != "")
            {
                errorProvider1.SetError(txtMaNVQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(txtTenNVQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(txtGTQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(txtDanTocQLSV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(txtDiaChiQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(txtSoDTQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(txtTDHVQLSV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(cbMABPQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                errorProvider1.SetError(cbMACVQLNV, "Vui lòng nhập thông tin tìm kiếm!");
                
            }else*/
            if(txtMaNVQLNV.Text != "")
            {
                /*
                
                
                if (cbMABPQLNV.Text != "" && cbMACVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MABP LIKE '%" + cbMABPQLNV.Text + "%'and MACV LIKE '%" + cbMACVQLNV.Text + "%'";
                }
                */
                
            }
            if (txtMaNVQLNV.Text != "")
            {
                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%'";
                if (txtTenNVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                    if (txtGTQLNV.Text != "")
                    {
                        sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%'";
                        if (cbMABPQLNV.Text != "")
                        {
                            sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%'";
                            if (txtTDHVQLSV.Text != "")
                            {
                                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%' and TDHV LIKE N'%" + txtTDHVQLSV.Text + "%'";
                            }
                        }
                    }
                }
            }

            if (txtTenNVQLNV.Text != "")
            {
                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                if (txtMaNVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%'";
                    if (txtTenNVQLNV.Text != "")
                    {
                        sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                        if (txtGTQLNV.Text != "")
                        {
                            sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%'";
                            if (cbMABPQLNV.Text != "")
                            {
                                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%'";
                                if (txtTDHVQLSV.Text != "")
                                {
                                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%' and TDHV LIKE N'%" + txtTDHVQLSV.Text + "%'";
                                }
                            }
                        }
                    }
                }
            }
            if (txtGTQLNV.Text != "")
            {
                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE GT LIKE N'%" + txtGTQLNV.Text + "%'";
                if (txtMaNVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%'";
                    if (txtTenNVQLNV.Text != "")
                    {
                        sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                        if (txtGTQLNV.Text != "")
                        {
                            sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%'";
                            if (cbMABPQLNV.Text != "")
                            {
                                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%'";
                                if (txtTDHVQLSV.Text != "")
                                {
                                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%' and TDHV LIKE N'%" + txtTDHVQLSV.Text + "%'";
                                }
                            }
                        }
                    }
                }
            }
            if (txtDiaChiQLNV.Text != "")
            {
                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE DIACHI LIKE N'%" + txtDiaChiQLNV.Text + "%'";
                if (txtMaNVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%'";
                    if (txtTenNVQLNV.Text != "")
                    {
                        sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                        if (txtGTQLNV.Text != "")
                        {
                            sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%'";
                            if (cbMABPQLNV.Text != "")
                            {
                                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%'";
                                if (txtTDHVQLSV.Text != "")
                                {
                                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%' and TDHV LIKE N'%" + txtTDHVQLSV.Text + "%'";
                                }
                            }
                        }
                    }
                }
            }
            if (cbMABPQLNV.Text != "")
            {
                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MABP = '" + cbMABPQLNV.Text + "'";
                if (txtMaNVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%'";
                    if (txtTenNVQLNV.Text != "")
                    {
                        sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                        if (txtGTQLNV.Text != "")
                        {
                            sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%'";
                            if (cbMABPQLNV.Text != "")
                            {
                                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%'";
                                if (txtTDHVQLSV.Text != "")
                                {
                                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%' and TDHV LIKE N'%" + txtTDHVQLSV.Text + "%'";
                                }
                            }
                        }
                    }
                }
            }
            if (cbMACVQLNV.Text != "")
            {
                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MACV LIKE '%" + cbMACVQLNV.Text + "%'";
                if (txtMaNVQLNV.Text != "")
                {
                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%'";
                    if (txtTenNVQLNV.Text != "")
                    {
                        sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%'";
                        if (txtGTQLNV.Text != "")
                        {
                            sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%'";
                            if (cbMABPQLNV.Text != "")
                            {
                                sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%'";
                                if (txtTDHVQLSV.Text != "")
                                {
                                    sql = "SELECT DISTINCT * FROM NHANVIEN WHERE MANV like '%" + txtMaNVQLNV.Text + "%' and TENNV LIKE N'%" + txtTenNVQLNV.Text + "%' and GT LIKE N'%" + txtGTQLNV.Text + "%' and MABP LIKE '%" + cbMABPQLNV.Text + "%' and TDHV LIKE N'%" + txtTDHVQLSV.Text + "%'";
                                }
                            }
                        }
                    }
                }
            }
            SqlConnection con = AccessData.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataGVNhanVien.DataSource = dt;
                con.Close();
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select * from nhanvien";
                DataGVNhanVien.DataSource = ac.createTable(query);
            }
        }

        private void DataGVNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGVNhanVien.DefaultCellStyle.Font = new Font("Arial", 11);
        }

        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "J1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã nhân viên";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Họ tên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Giới tính";
            cl3.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Dân tộc";

            cl4.ColumnWidth = 12.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Ngày sinh";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Địa chỉ";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Số điện thoại";

            cl7.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Trình độ học vấn";

            cl8.ColumnWidth = 14.5;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Mã bộ phận";

            cl9.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range c20 = oSheet.get_Range("J3", "J3");

            c20.Value2 = "Mã chức vụ";

            c20.ColumnWidth = 12.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "J3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable= new DataTable();

            DataColumn col1 = new DataColumn("Employee");
            DataColumn col2 = new DataColumn("Name");
            DataColumn col3 = new DataColumn("Gender");
            DataColumn col4 = new DataColumn("Nation");
            DataColumn col5 = new DataColumn("Birthday");
            DataColumn col6 = new DataColumn("Address");
            DataColumn col7 = new DataColumn("PhoneNumber");
            DataColumn col8 = new DataColumn("Education");
            DataColumn col9 = new DataColumn("DepartmentCode");
            DataColumn col10 = new DataColumn("PositionCode");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);
            dataTable.Columns.Add(col9);
            dataTable.Columns.Add(col10);

            foreach(DataGridViewRow dtgvRow in DataGVNhanVien.Rows)
            {
                DataRow dtrow = dataTable.NewRow();

                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;
                dtrow[7] = dtgvRow.Cells[7].Value;
                dtrow[8] = dtgvRow.Cells[8].Value;
                dtrow[9] = dtgvRow.Cells[9].Value;

                dataTable.Rows.Add(dtrow);
            }

            ExportFile(dataTable, "Danh sach", "Danh sách nhân viên");
        }
    }
}
