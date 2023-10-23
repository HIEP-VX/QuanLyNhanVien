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
    public partial class UngLuong : Form
    {
        Modify modify;
        int index;
        AccessData ac = new AccessData();
        public UngLuong()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtMaul.Text = "";
            txtMANV.Text = "";
            txtNAM.Text = "";
            cbThang.Text = "";
            txtNGAY.Text = "";
            txtSOTIEN.Text = "";
            cbTrangThai.Text = "";
        }

        private void UngLuong_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from ungluong order by ngay";
                dataGridView1.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
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

            txtMaul.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtMANV.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtNAM.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            cbThang.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtNGAY.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            txtSOTIEN.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            cbTrangThai.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaul.Text != "" && txtMANV.Text != "" && txtSOTIEN.Text != "")
            {
                string sql = "Insert into ungluong (malu, manv, nam, thang, ngay, tienul, trangthai) values ('" + txtMaul.Text + "','" + txtMANV.Text + "', " + txtNAM.Text + ", " + cbThang.Text + "," + txtNGAY + "," + txtSOTIEN + ", N'" + cbTrangThai + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có mã ứng lương này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select * from ungluong order by ngay";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (txtMaul.Text == "")
                    errorProvider1.SetError(txtMaul, "Vui lòng nhập mã ứng lương!");
                if (txtMANV.Text == "")
                    errorProvider1.SetError(txtMANV, "Vui lòng nhập mã nhân viên!");
                if (txtSOTIEN.Text == "")
                    errorProvider1.SetError(txtSOTIEN, "Vui lòng nhập số tiền ứng lương!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sql = "update ungluong set MANV = '" + txtMANV.Text + "',NAM = " + txtNAM.Text + ",THANG = " + cbThang.Text + ",NGAY = " + txtNGAY.Text + ", TIENUL = " + txtSOTIEN.Text + ",TRANGTHAI = N'" + cbTrangThai.Text + "' where MAUL = '" + txtMaul.Text + "'";
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
            string sql1 = "select * from ungluong order by ngay";
            dataGridView1.DataSource = ac.createTable(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã ứng lương này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "Delete from ungluong where MAUL = '" + txtMaul.Text + "'";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    string sql1 = "select * from ungluong order by ngay";
                    dataGridView1.DataSource = ac.createTable(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select * from ungluong order by ngay";
            dataGridView1.DataSource = ac.createTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string sql = "";
            if (txtMaul.Text == "" && txtMANV.Text == "" && txtNAM.Text == "" && cbThang.Text == "" && txtNGAY.Text == "" && txtSOTIEN.Text == "" && cbTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (txtMaul.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE MAUL LIKE '%" + txtMaul.Text + "%'";
                if (txtMANV.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE MANV LIKE '%" + txtMANV.Text + "%'";
                if (txtNAM.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE NAM = " + txtNAM.Text + "";
                if (cbThang.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE THANG =" + cbThang.Text + "";
                if (txtNGAY.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE NGAY =" + txtNGAY.Text + "";
                if (txtSOTIEN.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE SOTIEN =" + txtSOTIEN.Text + "";
                if (cbTrangThai.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE TRANGTHAI LIKE '%" + cbTrangThai.Text + "%'";
                if (txtMaul.Text != "" && txtMANV.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE MAUL LIKE '%" + txtMaul.Text + "%' and MANV LIKE '%" + txtMANV.Text + "%'";
                if (txtMaul.Text != "" && txtMANV.Text != "" && cbThang.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE MAUL LIKE '%" + txtMaul.Text + "%' and MANV LIKE '%" + txtMANV.Text + "%' and THANG =" + cbThang.Text + "";
                if (txtMaul.Text != "" && txtMANV.Text != "" && cbThang.Text != "" && txtNGAY.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE MAUL LIKE '%" + txtMaul.Text + "%' and MANV LIKE '%" + txtMANV.Text + "%' and THANG =" + cbThang.Text + " and NGAY =" + txtNGAY.Text + "";
                if (txtMaul.Text != "" && txtMANV.Text != "" && cbThang.Text != "" && txtNGAY.Text != "" && txtSOTIEN.Text != "")
                    sql = "SELECT * FROM UNGLUONG WHERE MAUL LIKE '%" + txtMaul.Text + "%' and MANV LIKE '%" + txtMANV.Text + "%' and THANG =" + cbThang.Text + " and NGAY =" + txtNGAY.Text + " and SOTIEN =" + txtSOTIEN.Text + "";
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
                MessageBox.Show("Không tìm thấy mã ứng lương này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select * from ungluong order by ngay";
                dataGridView1.DataSource = ac.createTable(query);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11);
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

            cl1.Value2 = "Mã ứng lương";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã nhân viên";

            cl2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Năm";

            cl3.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Tháng";
            cl4.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Ngày";
            cl5.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Số tiền ";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Trạng thái";
            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");

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
            DataColumn col5 = new DataColumn("Code1");
            DataColumn col6 = new DataColumn("Code2");
            DataColumn col7 = new DataColumn("Code3");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);

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

                dataTable.Rows.Add(dtrow);
            }
            DateTime now = DateTime.Now;
            int month = now.Month;
            ExportFile(dataTable, "Danh sach", "Danh sách ứng lương tháng " + month);
        }
    }
}
