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
    public partial class BangCong : Form
    {
        Modify modify;
        int index;

        AccessData ac = new AccessData();
        public BangCong()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtMANV.Text = "";
            txtNAM.Text = "";
            cbTHANG.Text = "";
            txtNGAY.Text = "";
            txtGV.Text = "";
            txtGR.Text = "";
            cbTT.Text = "";
        }


        private void BangCong_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from bangcong order by ngay";
                dataGridView1.DataSource = ac.createTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                string sql = "";
                if(txtMANV.Text != "" || txtNAM.Text != "" || cbTHANG.Text != "" || txtNGAY.Text != "" || txtGV.Text != "" || txtGR.Text != "" || cbTT.Text != ""){
                    if (txtMANV.Text != "")
                        sql = "SELECT * FROM bangcong WHERE MANV LIKE '%" + txtMANV.Text + "%' ORDER BY NGAY";
                    if(txtMANV.Text != "" && txtNGAY.Text != "")
                        sql = "SELECT * FROM bangcong WHERE MANV LIKE '%" + txtMANV.Text + "%' and NGAY = " + txtNGAY.Text + "ORDER BY NGAY";
                    if (txtMANV.Text != "" && txtNAM.Text != "")
                        sql = "SELECT * FROM BANGCONG WHERE MANV LIKE '%" + txtMANV.Text + "%' and NAM =" + txtNAM.Text + " ORDER BY NGAY";
                    if (txtMANV.Text != "" && txtGV.Text != "")
                        sql = "SELECT * FROM bangcong WHERE MANV LIKE '%" + txtMANV.Text + "%' and GIOVAO = " + txtGV.Text + "ORDER BY NGAY";
                    if (txtMANV.Text != "" && txtGR.Text != "")
                        sql = "SELECT * FROM bangcong WHERE MANV LIKE '%" + txtMANV.Text + "%' and GIORA = " + txtGR.Text + "ORDER BY NGAY";
                    if(txtMANV.Text != "" && cbTT.Text != "")
                        sql = "SELECT * FROM bangcong WHERE MANV LIKE '%" + txtMANV.Text + "%' and TRANGTHAI LIKE N'%" + txtNGAY.Text + "%' ORDER BY NGAY";
                    if (txtNAM.Text != "" && cbTHANG.Text != "")
                        sql = "SELECT * FROM BANGCONG WHERE MANV LIKE '%" + txtMANV.Text + "%' and NAM = " + txtNAM.Text + " and THANG = " + cbTHANG.Text + " order by NGAY";
                    if (txtNAM.Text != "" && cbTHANG.Text != "" && txtNGAY.Text != "")
                        sql = "SELECT * FROM BANGCONG WHERE MANV LIKE '%" + txtMANV.Text + "%' and NAM = " + txtNAM.Text + " and THANG =" + cbTHANG.Text + " and NGAY = " + txtNGAY.Text + "order by ngay";
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
                    //refresh();
                    MessageBox.Show("Không tìm thấy bộ phận này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string query = "select * from bangcong order by ngay";
                    dataGridView1.DataSource = ac.createTable(query);
                }
            }
            catch(Exception ex)
            {
                if (txtMANV.Text == "" && txtNAM.Text == "" && cbTHANG.Text == "" && txtNGAY.Text == "" && txtGV.Text == "" && txtGR.Text == "" && cbTT.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chấm công của nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "Delete from bangcong where MANV = '" + txtMANV.Text + "' and NGAY = " + txtNGAY.Text + " AND THANG = " + cbTHANG.Text + "";
                try
                {
                    ac.ExcuteNonQuery(sql);
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    string sql1 = "select * from bangcong order by ngay";
                    dataGridView1.DataSource = ac.createTable(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
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

            txtMANV.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtNAM.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            cbTHANG.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtNGAY.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtGV.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            txtGR.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            cbTT.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Thao tác này cho phép bạn thực hiện chấm công cho toàn bộ nhân viên. Bạn có chắc chắn muốn thực hiện thao tác này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if(result == DialogResult.Yes )
            {
                string sql = "INSERT INTO BANGCONG (MANV ,NAM ,THANG ,NGAY ,GIOVAO ,GIORA ,TRANGTHAI)\r\nSELECT MANV, NULL, NULL, NULL, 7, 17, N'Đã chấm công'\r\nFROM NHANVIEN";
                ac.ExcuteNonQuery( sql );
                refresh();
                DateTime now = DateTime.Now;
                int day = now.Day;
                string sql1 = "select * from bangcong where ngay = " + day + " order by ngay";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMANV.Text != "" && txtGV.Text != "" && txtGR.Text != "" && cbTT.Text != "")
            {
                string sql = "Insert into bangcong (manv, nam, thang, ngay, giovao, giora, trangthai) values ('" + txtMANV.Text + "'," + txtNAM.Text + ", " + cbTHANG.Text + ", " + txtNGAY.Text + "," + txtGV.Text + "," + txtGR.Text + ",N'" + cbTT.Text + "')";
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
                string sql1 = "select * from bangcong order by bangcong";
                dataGridView1.DataSource = ac.createTable(sql1);
            }
            else
            {
                if (txtMANV.Text == "")
                    errorProvider1.SetError(txtMANV, "Vui lòng nhập mã nhân viên!");
                if (txtGV.Text == "")
                    errorProvider1.SetError(txtGV, "Vui lòng nhập giờ vào!");
                if (txtGR.Text == "")
                    errorProvider1.SetError(txtGR, "Vui lòng nhập giờ ra!");
                if (cbTT.Text == "")
                    errorProvider1.SetError(txtGV, "Vui lòng nhập trạng thái!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            refresh();
            string sql = "select * from bangcong order by ngay";
            dataGridView1.DataSource = ac.createTable(sql);
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

            cl2.Value2 = "Năm";

            cl2.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tháng";

            cl3.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Ngày";
            cl4.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Giờ vào";
            cl5.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Giờ ra";
            cl6.ColumnWidth = 10;

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
            ExportFile(dataTable, "Danh sach", "Danh sách chấm công tháng " + month);
        }
    }
}
