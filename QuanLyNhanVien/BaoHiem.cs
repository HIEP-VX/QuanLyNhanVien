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
    public partial class BaoHiem : Form
    {
        AccessData ac = new AccessData();
        int index;
        public BaoHiem()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtMaBH.Text = "";
            txtMaNV.Text = "";
            txtSOBH.Text = "";
            dateTimePicker1.Value= DateTime.Now;
            txtNC.Text = "";
        }

        public void PhanQuyen()
        {
            if (ConstVariable.loaiTaiKhoan == false)
            {
                btnThem.Enabled = btnCapNhat.Enabled = btnXoa.Enabled = false;
            }
        }

        private void BaoHiem_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            try
            {
                string query = "select * from baohiem";
                dataGridView1.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            txtMaBH.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtMaNV.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtSOBH.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            DateTime datetimeValue = (DateTime)dataGridView1.Rows[index].Cells[3].Value;
            dateTimePicker1.Value = datetimeValue.Date;
            txtNC.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaBH.Text != "" && txtMaNV.Text != "" && txtSOBH.Text != "" )
            {
                string sql = "Insert into baohiem values ('" + txtMaBH.Text + "','" + txtMaNV.Text + "','" + txtSOBH.Text + "','" + dateTimePicker1.Text + "','" + txtNC.Text + "')";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
                string sql1 = "select * from baohiem";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
            else
            {
                if(txtMaBH.Text == "")
                    errorProvider1.SetError(txtMaBH, "Vui lòng nhập mã bảo hiểm!");
                if(txtMaNV.Text == "")
                    errorProvider1.SetError(txtMaNV, "Vui lòng nhập mã nhân viên!");
                if(txtSOBH.Text != "")
                    errorProvider1.SetError(txtSOBH, "Vui lòng nhập số bảo hiểm!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sql = "update baohiem set manv = '" + txtMaNV.Text + ",sobh = '" + txtSOBH + "',ngaycap = '" + dateTimePicker1.Text + "', noicap = N'" + txtNC.Text + "' where MABH = '" + txtMaBH.Text + "'";
            try
            {
                ac.ExcuteNonQuery(sql);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
            string sql1 = "select * from baohiem";
            dataGridView1.DataSource = ac.createTable(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã bảo hiểm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "Delete from baohiem where MABH = '" + txtMaBH.Text + "'";
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
                string sql1 = "select * from baohiem";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select * from baohiem";
            dataGridView1.DataSource = ac.createTable(sql);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT COUNT(*) FROM BAOHIEM WHERE MABH = '" + txtMaBH.Text + "'";
            SqlConnection con = AccessData.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                dataGridView1.DataSource = ac.createTable("SELECT * FROM BAOHIEM WHERE MABH = '" + txtMaBH.Text + "'");
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy mã bảo hiểm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select * from baohiem";
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

            cl1.Value2 = "Mã bảo hiểm";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã nhân viên";

            cl2.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Số bảo hiểm";
            cl3.ColumnWidth = 19.5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Ngày cấp";

            cl4.ColumnWidth = 14.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Nới cấp";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");

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

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);

            foreach (DataGridViewRow dtgvRow in dataGridView1.Rows)
            {
                DataRow dtrow = dataTable.NewRow();

                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;

                dataTable.Rows.Add(dtrow);
            }

            ExportFile(dataTable, "Danh sach", "Danh sách bảo hiểm");
        }
    }
}
