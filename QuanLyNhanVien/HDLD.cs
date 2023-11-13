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
    public partial class HDLD : Form
    {
        AccessData ac = new AccessData();
        int index;
        public HDLD()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtMahd.Text = "";
            txtMaNV.Text = "";
            cbLoai.Text = "";
            cbThoiHan.Text = "";
            NgayKy.Value = DateTime.Now;
            NgayBD.Value = DateTime.Now;
            NgayKT.Value = DateTime.Now;
            txtHS.Text = "";
            txtLCB.Text = "";
        }

        public void PhanQuyen()
        {
            if (ConstVariable.loaiTaiKhoan == false)
            {
                btnThem.Enabled = btnCapNhat.Enabled = btnXoa.Enabled = false;
            }
        }

        private void HDLD_Load(object sender, EventArgs e)
        {
            PhanQuyen ();
            try
            {
                string query = "SELECT * FROM HDLD";
                dataGridView1.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMahd.Text != "" && cbThoiHan.Text != "" && cbLoai.Text != "" && txtMaNV.Text != "" && txtHS.Text != "" && txtLCB.Text != "")
            {
                string sql = "Insert into hdld values ('" + txtMahd.Text + "','" + txtMaNV.Text + "',N'" + cbLoai.Text + "',N'" + cbThoiHan.Text + "','" + NgayKy.Text +  "','" + NgayBD.Text + "','" + NgayKT.Text + "','" + txtHS.Text + "','" + txtLCB.Text  + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã có mã hợp đồng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select * from hdld";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (txtMahd.Text == "")
                    errorProvider1.SetError(txtMahd, "Vui lòng nhập mã hợp đồng!");
                if (cbThoiHan.Text == "")
                    errorProvider1.SetError(cbThoiHan, "Vui lòng nhập thời hạn!");
                if (cbLoai.Text == "")
                    errorProvider1.SetError(cbLoai, "Vui lòng nhập loại hợp đồng!");
                if (txtMaNV.Text == "")
                    errorProvider1.SetError(txtMaNV, "Vui lòng nhập mã nhân viên!");
                if (txtHS.Text == "")
                    errorProvider1.SetError(txtMaNV, "Vui lòng nhập hệ số!");
                if (txtLCB.Text == "")
                    errorProvider1.SetError(txtMaNV, "Vui lòng nhập lương cơ bản!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sql = "update hdld set MANV = '" + txtMaNV.Text + "',loaihd = N'" + cbLoai.Text + "',THOIHAN = N'" + cbThoiHan.Text + "',ngayky = '" + NgayKy.Text + "',ngaybatdau = '" + NgayBD.Text + "',ngaykethuc = '" + NgayKT.Text + "', HESO = '" + txtHS.Text + "',LCB = '" + txtLCB.Text + "' where MACV = '" + txtMahd.Text + "'";
            try
            {
                ac.ExcuteNonQuery(sql);
                MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
            string sql1 = "select * from hdld";
            dataGridView1.DataSource = ac.createTable(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã hợp đồng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query06 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_MANV_HDLD' AND parent_object_id = OBJECT_ID('HDLD'))\r\nBEGIN\r\n   ALTER TABLE HDLD ADD \r\n\tCONSTRAINT FK_MANV_HDLD FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)\r\nEND";
                ac.ExcuteNonQuery(query06);
                string query03 = "ALTER TABLE HDLD DROP CONSTRAINT FK_MANV_HDLD";
                ac.ExcuteNonQuery(query03);
                string sql = "Delete from hdld where MAHD = '" + txtMahd.Text + "'";
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
                string sql1 = "select * from hdld";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select * from hdld";
            dataGridView1.DataSource = ac.createTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(txtMahd.Text != "")
            {
                sql = "SELECT * FROM HDLD WHERE MAHD LIKE '%" + txtMahd.Text + "%'";
                if ( cbThoiHan.Text != "")
                {
                    sql = "SELECT * FROM HDLD WHERE THOIHAB LIKE N'%" + cbThoiHan + "%'";
                }
            }
            if(cbThoiHan.Text != "")
            {
                sql = "SELECT * FROM HDLD WHERE THOIHAN LIKE N'%" + cbThoiHan.Text + "%'";
                if (cbLoai.Text != "")
                {
                    sql = "SELECT * FROM HDLD WHERE LOAIHD LIKE N'%" + cbLoai.Text + "%'";
                }
            }
            if (cbLoai.Text != "")
            {
                sql = "SELECT * FROM HDLD WHERE LOAIHD LIKE N'%" + cbLoai.Text + "%'";
                if (txtMaNV.Text != "")
                {
                    sql = "SELECT * FROM HDLD WHERE MANV LIKE '%" + txtMaNV.Text + "%'";
                }
            }
            if(txtMaNV.Text != "")
            {
                sql = "SELECT * FROM HDLD WHERE MANV LIKE '%" + txtMaNV.Text + "%'";
                if (txtMahd.Text != "")
                {
                    sql = "SELECT * FROM HDLD WHERE MAHD LIKE '%" + txtMahd.Text + "%'";
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
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy mã hợp đồng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select * from hdld";
                dataGridView1.DataSource = ac.createTable(query);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; // lấy ra chỉ số

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMahd.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtMaNV.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            cbLoai.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            cbThoiHan.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            DateTime datetimeValue1 = (DateTime)dataGridView1.Rows[index].Cells[4].Value;
            NgayKy.Value = datetimeValue1.Date;
            DateTime datetimeValue2 = (DateTime)dataGridView1.Rows[index].Cells[5].Value;
            NgayBD.Value = datetimeValue1.Date;
            DateTime datetimeValue3 = (DateTime)dataGridView1.Rows[index].Cells[6].Value;
            NgayKT.Value = datetimeValue3.Date;
            txtHS.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
            txtLCB.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();
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

            cl1.Value2 = "Mã hợp đồng";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã nhân viên";

            cl2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Loại hợp đồng";
            cl3.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Thời hạn";

            cl4.ColumnWidth = 14.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Ngày ký";

            cl5.ColumnWidth = 14.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Ngày bắt đầu";

            cl6.ColumnWidth = 12.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Ngày kết thúc";

            cl7.ColumnWidth = 12.5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Hệ số";

            cl8.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Lương cơ bản";

            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "I3");

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

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("Employee");
            DataColumn col2 = new DataColumn("Name");
            DataColumn col3 = new DataColumn("Gender");
            DataColumn col4 = new DataColumn("Nation");
            DataColumn col5 = new DataColumn("Birthday");
            DataColumn col6 = new DataColumn("Address");
            DataColumn col7 = new DataColumn("Code1");
            DataColumn col8 = new DataColumn("Code2");
            DataColumn col9 = new DataColumn("Code3");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);
            dataTable.Columns.Add(col9);

            foreach (DataGridViewRow dtgvRow in dataGridView1.Rows)
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


                dataTable.Rows.Add(dtrow);
            }

            ExportFile(dataTable, "Danh sach", "Danh sách hợp đồng");
        }
    }
}
