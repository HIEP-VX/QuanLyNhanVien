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
    public partial class BoPhan : Form
    {
        Modify modify;
        int index;
        AccessData ac = new AccessData();
        public BoPhan()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            cbMaBP.Text = "";
            cbMaPB.Text = "";
            txtTenBP.Text = "";
            txtDiaChi.Text = "";
        }

        public void PhanQuyen()
        {
            if (ConstVariable.loaiTaiKhoan == false)
            {
                btnThem.Enabled = btnUpdate.Enabled = btnXoa.Enabled = false;
            }
        }

        private void BoPhan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienDataSet11.PHONGBAN' table. You can move, or remove it, as needed.
            this.pHONGBANTableAdapter.Fill(this.quanLyNhanVienDataSet11.PHONGBAN);
            PhanQuyen();
            // TODO: This line of code loads data into the 'quanLyNhanVienDataSet4.BOPHAN' table. You can move, or remove it, as needed.
            this.bOPHANTableAdapter.Fill(this.quanLyNhanVienDataSet4.BOPHAN);
            refresh();
            try
            {
                string query = "select mabp as 'Mã bộ phận',mapb as 'Mã phòng ban', tenbp as 'Tên bộ phận', diachibp as 'Địa chỉ' from bophan";
                dataGVBoPhan.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGVBoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cbMaBP.Text = dataGVBoPhan.Rows[index].Cells[0].Value.ToString();
            cbMaPB.Text = dataGVBoPhan.Rows[index].Cells[1].Value.ToString();
            txtTenBP.Text = dataGVBoPhan.Rows[index].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGVBoPhan.Rows[index].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cbMaBP.Text != "" && txtTenBP.Text != "")
            {
                string sql = "Insert into bophan (mabp, mapb, tenbp, diachibp) values ('" + cbMaBP.Text + "','" + cbMaPB.Text + "', N'" + txtTenBP.Text + "', N'" + txtDiaChi.Text + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có bộ phận này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select mabp as 'Mã bộ phận',mapb as 'Mã phòng ban', tenbp as 'Tên bộ phận', diachibp as 'Địa chỉ' from bophan";
                dataGVBoPhan.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (cbMaBP.Text == "")
                    errorProvider1.SetError(cbMaBP, "Vui lòng nhập mã bộ phận!");
                if (txtTenBP.Text == "")
                    errorProvider1.SetError(txtTenBP, "Vui lòng nhập tên bộ phận!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "update bophan set MAPB = '" + cbMaPB.Text + "',TENBP = N'" + txtTenBP.Text + "',DIACHIBP = N'" + txtDiaChi.Text + "' where MABP = '" + cbMaBP.Text + "'";
            try
            {
                ac.ExcuteNonQuery(sql);
                MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
            string sql1 = "select mabp as 'Mã bộ phận',mapb as 'Mã phòng ban', tenbp as 'Tên bộ phận', diachibp as 'Địa chỉ' from bophan";
            dataGVBoPhan.DataSource = ac.createTable(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bộ phận này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query05 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_MABP_NHANVIEN' AND parent_object_id = OBJECT_ID('NHANVIEN'))\r\nBEGIN\r\n   ALTER TABLE NHANVIEN ADD \r\n\tCONSTRAINT FK_MABP_NHANVIEN FOREIGN KEY(MABP) REFERENCES BOPHAN(MABP)\r\nEND";
                ac.ExcuteNonQuery(query05);
                string query06 = "ALTER TABLE NHANVIEN DROP CONSTRAINT FK_MABP_NHANVIEN";
                ac.ExcuteNonQuery(query06);
                string sql = "Delete from bophan where MABP = '" + cbMaBP.Text + "'";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    string sql1 = "select mabp as 'Mã bộ phận',mapb as 'Mã phòng ban', tenbp as 'Tên bộ phận', diachibp as 'Địa chỉ' from bophan";
                    dataGVBoPhan.DataSource = ac.createTable(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select mabp as 'Mã bộ phận',mapb as 'Mã phòng ban', tenbp as 'Tên bộ phận', diachibp as 'Địa chỉ' from bophan";
            dataGVBoPhan.DataSource = ac.createTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string sql = "";
            if (cbMaBP.Text == "" && txtTenBP.Text == "" && txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            } else if (cbMaBP.Text != "")
            {
                sql = "SELECT * FROM BOPHAN WHERE MABP = '" + cbMaBP.Text + "'";
            } else if (cbMaPB.Text != "") 
            {
                sql = "SELECT * FROM BOPHAN WHERE MAPB LIKE '%" + cbMaPB.Text + "%'";
            } else if (txtTenBP.Text != "")
            {
                sql = "SELECT * FROM BOPHAN WHERE TENBP LIKE N'%" + txtTenBP.Text + "%'";
            } else if (txtDiaChi.Text != "")
            {
                sql = "SELECT * FROM BOPHAN WHERE DIACHIBP LIKE N'%" + txtDiaChi.Text + "%'";
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
                dataGVBoPhan.DataSource = dt;
                con.Close();
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy bộ phận này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select mabp as 'Mã bộ phận',mapb as 'Mã phòng ban', tenbp as 'Tên bộ phận', diachibp as 'Địa chỉ' from bophan";
                dataGVBoPhan.DataSource = ac.createTable(query);
            }
        }

        private void dataGVBoPhan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGVBoPhan.DefaultCellStyle.Font = new Font("Arial", 11);
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

            cl1.Value2 = "Mã bộ phận";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã phòng ban";

            cl2.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tên bộ phận";

            cl3.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Địa chỉ bộ phận";
            cl4.ColumnWidth = 35;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "D3");

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

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("DepartmentCode");
            DataColumn col2 = new DataColumn("Name");
            DataColumn col3 = new DataColumn("Address");
            DataColumn col4 = new DataColumn("Code");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);

            foreach (DataGridViewRow dtgvRow in dataGVBoPhan.Rows)
            {
                DataRow dtrow = dataTable.NewRow();

                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;

                dataTable.Rows.Add(dtrow);
            }

            ExportFile(dataTable, "Danh sach", "Danh sách bộ phận");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
