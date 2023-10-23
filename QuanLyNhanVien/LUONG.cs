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
    public partial class LUONG : Form
    {
        Modify modify;
        int index;
        AccessData ac = new AccessData();
        public LUONG()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void LUONG_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            label1.Text = "Bảng tính lương cho nhân viên tháng " + month;
            try
            {
                string sql = "select * from luong";
                dataGridView1.DataSource = ac.createTable(sql);
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; 

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMALUONG.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtMANV.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE LUONG SET\r\n\tTENNV = (SELECT NHANVIEN.TENNV FROM NHANVIEN WHERE NHANVIEN.MANV = LUONG.MANV),\r\n\tSONGAYCONG = (SELECT COUNT(DISTINCT NGAY) FROM BANGCONG WHERE THANG = 4 AND NAM = 2023 AND TRANGTHAI LIKE N'Đã chấm công' AND BANGCONG.MANV = LUONG.MANV),\r\n\tTIENUL = (SELECT UNGLUONG.TIENUL FROM UNGLUONG WHERE LUONG.MANV = UNGLUONG.MANV),\r\n\tLCB = (SELECT HDLD.LCB FROM HDLD WHERE LUONG.MANV = HDLD.MANV)\r\n\t\r\n\tUPDATE LUONG SET \r\n\tLCB = 0 WHERE LCB IS NULL\r\n\r\n\tUPDATE LUONG SET \r\n\tSOGIOTC = 0 WHERE SOGIOTC IS NULL \r\n\r\n\tUPDATE LUONG SET \r\n\tTIENPC = 0 WHERE TIENPC IS NULL\r\n\r\n\tUPDATE LUONG SET\r\n\tTIENTHUONG = 0 WHERE TIENTHUONG IS NULL\r\n\r\n\tUPDATE LUONG SET\r\n\tTIENPHAT = 0 WHERE TIENPHAT IS NULL\r\n\r\n\tUPDATE LUONG SET\r\n\tTIENUL = 0 WHERE TIENUL IS NULL\r\n\r\n\tUPDATE LUONG SET \r\n\tTHUCLINH = 0 WHERE THUCLINH IS NULL\r\n\r\n\tUPDATE LUONG \r\n\tSET SOGIOTC = (SELECT SUM(TANGCA.SOGIOTC) FROM TANGCA WHERE TANGCA.MANV = LUONG.MANV)\r\n\tWHERE MANV IN (SELECT MANV FROM TANGCA)\r\n\t\r\n\tUPDATE LUONG\r\n\tSET TIENPC = (SELECT SUM(NHANVIENPC.TIENPC) FROM NHANVIENPC WHERE LUONG.MANV = NHANVIENPC.MANV)\r\n\tWHERE MANV IN (SELECT MANV FROM NHANVIENPC)\r\n\r\n\tUPDATE LUONG\r\n\tSET TIENTHUONG = (SELECT SUM(KHENTHUONG.TIENTHUONG) FROM KHENTHUONG WHERE LUONG.MANV = KHENTHUONG.MANV)\r\n\tWHERE MANV IN (SELECT MANV FROM KHENTHUONG)\r\n\r\n\tUPDATE LUONG\r\n\tSET TIENPHAT = (SELECT KYLUAT.TIENPHAT FROM KYLUAT WHERE LUONG.MANV = KYLUAT.MANV)\r\n\tWHERE MANV IN (SELECT MANV FROM KYLUAT)\r\n\r\n\tUPDATE LUONG\r\n\tSET THUCLINH = (HD.LCB / 26) * SONGAYCONG + (SOGIOTC * 50000) + TIENPC - TIENUL + ISNULL(TIENTHUONG, 0) - ISNULL(TIENPHAT, 0)\r\n\tFROM LUONG\r\n\tJOIN HDLD AS HD ON LUONG.MANV = HD.MANV\r\n\tWHERE HD.LOAIHD LIKE N'Hợp đồng chính thức' \r\n\tAND CAST(SUBSTRING(HD.THOIHAN, 1, 1) AS INT) > 1;\r\n\r\n\tUPDATE LUONG\r\n\tSET THUCLINH = (HD.LCB * 0.7 / 26) * SONGAYCONG + (SOGIOTC * 50000) + TIENPC - TIENUL + ISNULL(TIENTHUONG, 0) - ISNULL(TIENPHAT, 0)\r\n\tFROM LUONG\r\n\tJOIN HDLD AS HD ON LUONG.MANV = HD.MANV\r\n\tWHERE HD.LOAIHD LIKE N'Hợp đồng thử việc' AND (HD.THOIHAN LIKE N'1 tháng' or HD.THOIHAN LIKE N'3 tháng')";
            ac.ExcuteNonQuery(sql);
            string sql1 = "select * from luong";
            dataGridView1.DataSource = ac.createTable(sql1);
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

            cl1.Value2 = "Mã lương";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã nhân viên";

            cl2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Họ và tên";
            cl3.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Số ngày công";

            cl4.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Số giờ tăng ca";

            cl5.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Tiền phụ cấp";

            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Tiền ứng lương";

            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Tiền thưởng";

            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Tiền phạt";

            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range c20 = oSheet.get_Range("J3", "J3");

            c20.Value2 = "Lương cơ bản";

            c20.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range c21 = oSheet.get_Range("K3", "K3");

            c21.Value2 = "Thực lĩnh";

            c21.ColumnWidth = 18;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "K3");

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
            DataColumn col11 = new DataColumn("PositionCode2");

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
            dataTable.Columns.Add(col11);

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
                dtrow[9] = dtgvRow.Cells[9].Value;
                dtrow[10] = dtgvRow.Cells[10].Value;

                dataTable.Rows.Add(dtrow);
            }
            DateTime now = DateTime.Now;
            int month = now.Month;
            ExportFile(dataTable, "Danh sach", "Danh sách bảng lương tháng " + month);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMALUONG.Text != "" && txtMANV.Text != "" )
            {
                string sql = "Insert into luong values ('" + txtMALUONG.Text + "','" + txtMANV.Text + "',null, null, null, null, null, null, null, null, null)";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sql1 = "select * from luong";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (txtMALUONG.Text == "")
                    errorProvider1.SetError(txtMALUONG, "Vui lòng nhập mã lương!");
                if (txtMANV.Text == "")
                    errorProvider1.SetError(txtMANV, "Vui lòng nhập mã nhân viên!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã lương này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "Delete from luong where MALUONG = '" + txtMALUONG.Text + "'";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sql1 = "select * from luong";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
        }
    }
}
