using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class KhenThuong : Form
    {
        Modify modify;
        int index;
        AccessData ac = new AccessData();
        public KhenThuong()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            cbMa.Text = "";
            txtSo.Text = "";
            txtND.Text = "";
            txtSoTien.Text = "";
            dtpNK.Value = DateTime.Now;
            txtMaNV.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void PhanQuyen()
        {
            if (ConstVariable.loaiTaiKhoan == false)
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void KhenThuong_KyLuat_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            refresh();
            try
            {
                string query = "select * from khenthuong";
                dataGVKTKL.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGVKTKL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; // lấy ra chỉ số

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cbMa.Text = dataGVKTKL.Rows[index].Cells[0].Value.ToString();
            txtMaNV.Text = dataGVKTKL.Rows[index].Cells[1].Value.ToString();
            txtSo.Text = dataGVKTKL.Rows[index].Cells[2].Value.ToString();
            txtND.Text = dataGVKTKL.Rows[index].Cells[3].Value.ToString();
            txtSoTien.Text = dataGVKTKL.Rows[index].Cells[4].Value.ToString();
            DateTime datetimeValue = (DateTime)dataGVKTKL.Rows[index].Cells[5].Value;
            dtpNK.Value = datetimeValue.Date;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(cbMa.Text != "" && txtMaNV.Text != "")
            {
                string sql = "Insert into khenthuong values ('" + cbMa.Text + "','" + txtMaNV.Text + "',N'" + txtSo.Text + "',N'" + txtND.Text + "'," + txtSoTien.Text + ",'" + dtpNK.Text  + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã có mã khen thưởng này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select * from khenthuong";
                dataGVKTKL.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (cbMa.Text == "")
                    errorProvider1.SetError(cbMa, "Vui lòng nhập mã !");
                if (txtMaNV.Text == "")
                    errorProvider1.SetError(txtMaNV, "Vui lòng nhập mã nhân viên!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update khenthuong set MANV = '" + txtMaNV.Text + "',SOKT = N'" + txtSo.Text + "',NOIDUNG = N'" + txtND.Text + "',SOTIEN = " + txtSoTien.Text + ",NGAYKYQD = '" + dtpNK.Text + "' where MAKT = '" + cbMa.Text + "'";
            try
            {
                ac.ExcuteNonQuery(sql);
                MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi "+ ex.Message , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            refresh();
            string sql1 = "select * from khenthuong";
            dataGVKTKL.DataSource = ac.createTable(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã khen thưởng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query01 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_KHENTHUONG_MANV' AND parent_object_id = OBJECT_ID('KHENTHUONG'))\r\nBEGIN\r\n   ALTER TABLE KHENTHUONG ADD CONSTRAINT FK_KHENTHUONG_MANV FOREIGN KEY (MANV) REFERENCES NHANVIEN (MANV)\r\nEND";
                ac.ExcuteNonQuery(query01);
                string query02 = "ALTER TABLE KHENTHUONG DROP CONSTRAINT FK_KHENTHUONG_MANV";
                ac.ExcuteNonQuery(query02);
                string sql = "Delete from khenthuong where MAKT = '" + cbMa.Text + "'";
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
                string sql1 = "select * from khenthuong";
                dataGVKTKL.DataSource = ac.createTable(sql1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select * from khenthuong";
            dataGVKTKL.DataSource = ac.createTable(sql);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(cbMa.Text != "")
            {
                sql = "SELECT * FROM khenthuong WHERE MAKT LIKE '%" + cbMa.Text + "%'";
                if(txtMaNV.Text != "")
                {
                    sql = "SELECT * FROM khenthuong WHERE MANV LIKE '%" + txtMaNV.Text + "%'";
                }
            }
            if (txtMaNV.Text != "")
            {
                sql = "SELECT * FROM khenthuong WHERE MANV LIKE '%" + txtMaNV.Text + "%'";
            }

            if(txtSo.Text != "")
            {
                sql = "SELECT * FROM khenthuong WHERE SOKT LIKE '%" + txtSo.Text + "%'";
            }

            if(txtND.Text != "")
            {
                sql = "SELECT * FROM khenthuong WHERE NOIDUNG LIKE N'%" + txtND.Text + "%'";
            }

            if(txtSoTien.Text != "")
            {
                sql = "SELECT * FROM khenthuong WHERE SOTIEN LIKE '%" + txtSoTien.Text + "%'";
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
                dataGVKTKL.DataSource = dt;
                con.Close();
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy mã khen thưởng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select * from khenthuong";
                dataGVKTKL.DataSource = ac.createTable(query);
            }
        }

        private void dataGVKTKL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGVKTKL.DefaultCellStyle.Font = new Font("Arial", 11);
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

            cl1.Value2 = "Mã khen thưởng";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã nhân viên";

            cl2.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Số KT";

            cl3.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Nội dung";
            cl4.ColumnWidth = 40;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Số tiền";

            cl5.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Ngày ký quyết định";

            cl6.ColumnWidth = 16;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "F3");

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();

                DataColumn col1 = new DataColumn("Employee");
                DataColumn col2 = new DataColumn("Name");
                DataColumn col3 = new DataColumn("Gender");
                DataColumn col4 = new DataColumn("Nation");
                DataColumn col5 = new DataColumn("Birthday");
                DataColumn col6 = new DataColumn("Address");

                dataTable.Columns.Add(col1);
                dataTable.Columns.Add(col2);
                dataTable.Columns.Add(col3);
                dataTable.Columns.Add(col4);
                dataTable.Columns.Add(col5);
                dataTable.Columns.Add(col6);

                foreach (DataGridViewRow dtgvRow in dataGVKTKL.Rows)
                {
                    DataRow dtrow = dataTable.NewRow();

                    dtrow[0] = dtgvRow.Cells[0].Value;
                    dtrow[1] = dtgvRow.Cells[1].Value;
                    dtrow[2] = dtgvRow.Cells[2].Value;
                    dtrow[3] = dtgvRow.Cells[3].Value;
                    dtrow[4] = dtgvRow.Cells[4].Value;
                    dtrow[5] = dtgvRow.Cells[5].Value;

                    dataTable.Rows.Add(dtrow);
                }

                ExportFile(dataTable, "Danh sach", "Danh sách khen thưởng");
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi");
            }
            
        }
    }
}
