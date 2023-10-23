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
    public partial class PhuCapNhanVien : Form
    {
        Modify modify;
        int index;
        AccessData ac = new AccessData();
        public PhuCapNhanVien()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtMANV.Text = "";
            cbMaPC.Text = "";
            txtSoTien.Text = "";
        }

        public void PhanQuyen()
        {
            if (ConstVariable.loaiTaiKhoan == false)
            {
                btnThem.Enabled = btnUpdate.Enabled = btnXoa.Enabled = false;
            }
        }

        private void PhuCapNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienDataSet7.PHUCAP' table. You can move, or remove it, as needed.
            this.pHUCAPTableAdapter.Fill(this.quanLyNhanVienDataSet7.PHUCAP);
            refresh();
            try
            {
                string query = "select manv as 'Mã nhân viên',mapc as 'Mã phụ cấp', tienpc as 'Tiền phụ cấp' from nhanvienpc";
                dataGVPCNV.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGVPCNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGVPCNV.DefaultCellStyle.Font = new Font("Arial", 11);
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

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã phụ cấp";

            cl2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tiền phụ cấp";
            cl3.ColumnWidth = 17;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "C3");

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

        private void dataGVPCNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMANV.Text = dataGVPCNV.Rows[index].Cells[0].Value.ToString();
            cbMaPC.Text = dataGVPCNV.Rows[index].Cells[1].Value.ToString();
            txtSoTien.Text = dataGVPCNV.Rows[index].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMANV.Text != "" && cbMaPC.Text != "" && txtSoTien.Text != "")
            {
                string sql = "Insert into nhanvienpc (manv, mapc, tienpc) values ('" + txtMANV.Text + "','" + cbMaPC.Text + "','" + txtSoTien.Text + "')";
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
                string sql1 = "select manv as 'Mã nhân viên',mapc as 'Mã phụ cấp', tienpc as 'Tiền phụ cấp' from nhanvienpc";
                dataGVPCNV.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (txtMANV.Text == "")
                    errorProvider1.SetError(txtMANV, "Vui lòng nhập mã nhân viên!");
                if (cbMaPC.Text == "")
                    errorProvider1.SetError(cbMaPC, "Vui lòng nhập mã phụ cấp!");
                if (txtSoTien.Text == "")
                    errorProvider1.SetError(txtSoTien, "Vui lòng nhập tiền phụ cấp!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "update nhanvienpc set MAPC = '" + cbMaPC.Text + "',TIENPC = '" + txtSoTien.Text + "' where MANV = '" + txtMANV.Text + "'";
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
            string sql1 = "select manv as 'Mã nhân viên',mapc as 'Mã phụ cấp', tienpc as 'Tiền phụ cấp' from nhanvienpc";
            dataGVPCNV.DataSource = ac.createTable(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phụ cấp của nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "Delete from nhanvienpc where MANV = '" + txtMANV.Text + "'";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    string sql1 = "select manv as 'Mã nhân viên',mapc as 'Mã phụ cấp', tienpc as 'Tiền phụ cấp' from nhanvienpc";
                    dataGVPCNV.DataSource = ac.createTable(sql1);
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
            string sql = "select manv as 'Mã nhân viên',mapc as 'Mã phụ cấp', tienpc as 'Tiền phụ cấp' from nhanvienpc";
            dataGVPCNV.DataSource = ac.createTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string sql = "";
            if (txtMANV.Text == "" && cbMaPC.Text == "" && txtSoTien.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (txtMANV.Text != "")
            {
                sql = "SELECT * FROM NHANVIENPC WHERE MANV LIKE '%" + txtMANV.Text + "%'";
            }
            else if (cbMaPC.Text != "")
            {
                sql = "SELECT * FROM NHANVIENPC WHERE MAPC LIKE '%" + cbMaPC.Text + "%'";
            }
            else if (txtSoTien.Text != "")
            {
                sql = "SELECT * FROM NHANVIENPC WHERE TIENPC LIKE '%" + txtSoTien.Text + "%'";
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
                dataGVPCNV.DataSource = dt;
                con.Close();
            }
            else
            {
                refresh();
                MessageBox.Show("Không tìm thấy phụ cấp của nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "select manv as 'Mã nhân viên',mapc as 'Mã phụ cấp', tienpc as 'Tiền phụ cấp' from nhanvienpc";
                dataGVPCNV.DataSource = ac.createTable(query);
            }
        }

        private void btnIn_Click_1(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("PCCODE");
            DataColumn col2 = new DataColumn("Name");
            DataColumn col3 = new DataColumn("money");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);

            foreach (DataGridViewRow dtgvRow in dataGVPCNV.Rows)
            {
                DataRow dtrow = dataTable.NewRow();

                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;

                dataTable.Rows.Add(dtrow);
            }

            ExportFile(dataTable, "Danh sach", "Phụ cấp cho nhân viên");
        }
    }
}
