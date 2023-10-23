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
    public partial class ChucVu : Form
    {
        int index;
        AccessData ac = new AccessData();
        public ChucVu()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtTenCV.Text = "";
            cbMaCVQLCV.Text = "";
        }

        public void PhanQuyen()
        {
            if (ConstVariable.loaiTaiKhoan == false)
            {
                btnAdd.Enabled = btnDel.Enabled = btnUpdate.Enabled = false;
            }
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            // TODO: This line of code loads data into the 'quanLyNhanVienDataSet3.CHUCVU' table. You can move, or remove it, as needed.
            this.cHUCVUTableAdapter.Fill(this.quanLyNhanVienDataSet3.CHUCVU);
            refresh();
            try
            {
                string query = "select macv as 'Mã chức vụ', tencv as 'Tên chức vụ' from chucvu";
                dataGVChucVu.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGVChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; // lấy ra chỉ số

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cbMaCVQLCV.Text = dataGVChucVu.Rows[index].Cells[0].Value.ToString();
            txtTenCV.Text = dataGVChucVu.Rows[index].Cells[1].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(cbMaCVQLCV.Text != "")
            {
                string sql = "Insert into chucvu values ('" + cbMaCVQLCV.Text + "',N'" + txtTenCV.Text + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã có chức vụ này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select macv as 'Mã chức vụ', tencv as 'Tên chức vụ' from chucvu";
                dataGVChucVu.DataSource = ac.createTable(sql1);
            }
            else
            {
                errorProvider1.SetError(cbMaCVQLCV, "Vui lòng nhập mã chức vụ!");
            }
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "update chucvu set TENCV = N'" + txtTenCV.Text + "' where MACV = '" + cbMaCVQLCV.Text + "'";
            ac.ExcuteNonQuery(sql);
            refresh();
            string sql1 = "select macv as 'Mã chức vụ', tencv as 'Tên chức vụ' from chucvu";
            dataGVChucVu.DataSource = ac.createTable(sql1);
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query05 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_MACV_LUONG' AND parent_object_id = OBJECT_ID('LUONG'))\r\nBEGIN\r\n   ALTER TABLE LUONG ADD \r\n\tCONSTRAINT FK_MACV_LUONG FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)\r\nEND";
                ac.ExcuteNonQuery(query05);
                string query06 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_MACV_CHUCVU' AND parent_object_id = OBJECT_ID('HDLD'))\r\nBEGIN\r\n   ALTER TABLE HDLD ADD \r\n\tCONSTRAINT FK_MACV_CHUCVU FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)\r\nEND";
                ac.ExcuteNonQuery(query06);
                string query07 = "IF NOT EXISTS(SELECT * FROM sys.foreign_keys WHERE name = 'FK_MACV_NHANVIEN' AND parent_object_id = OBJECT_ID('NHANVIEN'))\r\nBEGIN\r\n    ALTER TABLE NHANVIEN ADD\r\n    CONSTRAINT FK_MACV_NHANVIEN FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)\r\nEND";
                ac.ExcuteNonQuery(query07);
                string query01 = "ALTER TABLE NHANVIEN DROP CONSTRAINT FK_MACV_NHANVIEN";
                ac.ExcuteNonQuery(query01);
                string query02 = "ALTER TABLE HDLD DROP CONSTRAINT FK_MACV_CHUCVU";
                ac.ExcuteNonQuery(query02);
                string query03 = "ALTER TABLE LUONG DROP CONSTRAINT FK_MACV_LUONG";
                ac.ExcuteNonQuery(query03);
                string query04 = "Delete from chucvu where MACV = '" + cbMaCVQLCV.Text + "'";
                ac.ExcuteNonQuery(query04);
                refresh();
                string sql100 = "select macv as 'Mã chức vụ', tencv as 'Tên chức vụ' from chucvu";
                dataGVChucVu.DataSource = ac.createTable(sql100);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select macv as 'Mã chức vụ', tencv as 'Tên chức vụ' from chucvu";
            dataGVChucVu.DataSource = ac.createTable(sql);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string sql = "";
            if(cbMaCVQLCV.Text == "" && txtTenCV.Text == "")
            {
                if (cbMaCVQLCV.Text == "")
                    errorProvider1.SetError(cbMaCVQLCV, "Vui lòng nhập đầy đủ dữ liệu!");
                if (txtTenCV.Text == "")
                    errorProvider1.SetError(txtTenCV, "Vui lòng nhập đầy đủ dữ liệu!");
            }
            else if(cbMaCVQLCV.Text != "")
            {
                sql = "SELECT * FROM CHUCVU WHERE MACV = '" + cbMaCVQLCV.Text + "'";
            }
            else if (txtTenCV.Text != "")
            {
                sql = "SELECT * FROM CHUCVU WHERE TENCV LIKE N'%" + txtTenCV.Text + "%'";
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
                dataGVChucVu.DataSource = dt;
                con.Close();
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy chức vụ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select macv as 'Mã chức vụ', tencv as 'Tên chức vụ' from chucvu";
                dataGVChucVu.DataSource = ac.createTable(query);
            }
        }

        private void dataGVChucVu_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGVChucVu.DefaultCellStyle.Font = new Font("Arial", 11);
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã chức vụ";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên chức vụ";

            cl2.ColumnWidth = 28.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "B3");

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
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("PositionCode");
            DataColumn col2 = new DataColumn("Name");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);

            foreach (DataGridViewRow dtgvRow in dataGVChucVu.Rows)
            {
                DataRow dtrow = dataTable.NewRow();

                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                
                dataTable.Rows.Add(dtrow);
            }

            ExportFile(dataTable, "Danh sach", "Danh sách chức vụ");
        }

        private void dataGVChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
