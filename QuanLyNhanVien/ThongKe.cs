using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanVien
{
    public partial class ThongKe : Form
    {
        AccessData ac = new AccessData();
        public ThongKe()
        {
            InitializeComponent();
        }

        private string text1 = "Số lượng nhân viên của từng bộ phận"; 
        private string text4 = "Danh sách nhân viên theo tuổi";
        private string text5 = "Danh sách nhân viên theo tiền phụ cấp";
        private string text6 = "Tông tiền đã trả cho nhân viên trong từng bộ phận";
        private string text7 = "Lớn hơn";
        private string text8 = "Nhỏ hơn";
        private string text9 = "Bằng";
        private string text10 = "Số lượng nhân viên theo giới tính";
        private string text11 = "Số lượng nhân viên theo từng trình độ học vấn";
        private string text12 = "Số lượng nhân viên theo từng loại hợp đồng lao động";

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Vui lòng chọn yêu cầu thống kê");
            }
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
            if (comboBox1.SelectedItem.ToString() == text1)
            {
                chart1.Visible = true;
                label4.Visible = false;
                try
                {
                    string query = "select TENBP AS N'Tên bộ phận' , COUNT(*) AS N'Số lượng' from BOPHAN, NHANVIEN\r\nWHERE BOPHAN.MABP = NHANVIEN.MABP\r\nGROUP BY TENBP";
                    dataGVTK.DataSource = ac.createTable(query);
                    if (chart1.Series.Count > 0)
                    {
                        chart1.Series["Số lượng"].Points.Clear();
                        chart1.ChartAreas["ChartArea1"].AxisX.Title = text1;
                        chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                        chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 11);
                        chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 11);
                        chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                        chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;


                        for (int i = 0; i < dataGVTK.Rows.Count; i++)
                        {
                            DataGridViewRow row = dataGVTK.Rows[i];
                            string tenBP = row.Cells["Tên bộ phận"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                            chart1.Series["Số lượng"].Points.AddXY(tenBP, soLuong);
                        }
                    }
                }catch(Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else if(comboBox1.SelectedItem.ToString() == text4)
            {
                try
                {
                    string query = "";
                    if (checkBox1.Checked)
                    {
                        chart1.Visible = false; 
                        chart2.Visible = false;
                        chart3.Visible = false;
                        label4.Visible = true;
                        if (comboBox2.SelectedItem.ToString() == text7)
                        {
                            query = "\r\nSELECT nv.manv as N'Mã nhân viên', nv.tennv as N'Họ tên', YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi'\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) > " + textBox1.Text + "\r\nGROUP BY nv.manv, nv.tennv, YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        }
                        else if (comboBox2.SelectedItem.ToString() == text8)
                        {
                            query = "\r\nSELECT nv.manv as N'Mã nhân viên', nv.tennv as N'Họ tên', YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi'\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) < " + textBox1.Text + "\r\nGROUP BY nv.manv, nv.tennv, YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        }
                        else if (comboBox2.SelectedItem.ToString() == text9)
                        {
                            query = "\r\nSELECT nv.manv as N'Mã nhân viên', nv.tennv as N'Họ tên', YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi'\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) = " + textBox1.Text + "\r\nGROUP BY nv.manv, nv.tennv, YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        }
                        dataGVTK.DataSource = ac.createTable(query);
                        
                    }
                    else
                    {
                        chart3.Visible = true;
                        label4.Visible = false;
                        if (comboBox2.SelectedItem.ToString() == text7)
                        {
                            query = "\r\nSELECT YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi', COUNT(*) AS [Số lượng]\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) > " + textBox1.Text + "\r\nGROUP BY YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        }
                        else if (comboBox2.SelectedItem.ToString() == text8)
                        {
                            query = "\r\nSELECT YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi', COUNT(*) AS [Số lượng]\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) < " + textBox1.Text + "\r\nGROUP BY YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        }
                        else if (comboBox2.SelectedItem.ToString() == text9)
                        {
                            query = "\r\nSELECT YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi', COUNT(*) AS [Số lượng]\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) = " + textBox1.Text + "\r\nGROUP BY YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        }
                        dataGVTK.DataSource = ac.createTable(query);
                        if (chart3.Series.Count > 0)
                        {
                            chart3.Series["Số lượng"].Points.Clear();
                            chart3.ChartAreas["ChartArea1"].AxisX.Title = text4;
                            chart3.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                            chart3.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 11);
                            chart3.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 11);
                            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chart3.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;


                            for (int i = 0; i < dataGVTK.Rows.Count; i++)
                            {
                                DataGridViewRow row = dataGVTK.Rows[i];
                                string tenBP = row.Cells["Tuổi"].Value.ToString();
                                int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                                chart3.Series["Số lượng"].Points.AddXY(tenBP, soLuong);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else if(comboBox1.SelectedItem.ToString() == text5)
            {
                try
                {
                    string query = "";
                    if (checkBox1.Checked)
                    {
                        chart1.Visible = false;
                        chart2.Visible = false;
                        chart3.Visible = false;
                        chart4.Visible = false;
                        label4.Visible = true;
                        if (comboBox2.SelectedItem.ToString() == text7)
                        {
                            query = "SELECT nv.manv AS N'Mã nhân viên', nv.tennv AS N'Họ tên', bp.tenbp AS N'Bộ phận', pc.tienpc AS N'Tiền phụ cấp'\r\nFROM nhanvien nv\r\nJOIN luong lg ON nv.macv = lg.macv\r\nJOIN phucap pc ON lg.mapc = pc.mapc\r\nJOIN bophan bp ON nv.mabp = bp.mabp\r\nWHERE pc.tienpc > " + textBox1.Text;
                        }
                        else if (comboBox2.SelectedItem.ToString() == text8)
                        {
                            query = "SELECT nv.manv AS N'Mã nhân viên', nv.tennv AS N'Họ tên', bp.tenbp AS N'Bộ phận', pc.tienpc AS N'Tiền phụ cấp'\r\nFROM nhanvien nv\r\nJOIN luong lg ON nv.macv = lg.macv\r\nJOIN phucap pc ON lg.mapc = pc.mapc\r\nJOIN bophan bp ON nv.mabp = bp.mabp\r\nWHERE pc.tienpc < " + textBox1.Text;
                        }
                        else if (comboBox2.SelectedItem.ToString() == text9)
                        {
                            query = "SELECT nv.manv AS N'Mã nhân viên', nv.tennv AS N'Họ tên', bp.tenbp AS N'Bộ phận', pc.tienpc AS N'Tiền phụ cấp'\r\nFROM nhanvien nv\r\nJOIN luong lg ON nv.macv = lg.macv\r\nJOIN phucap pc ON lg.mapc = pc.mapc\r\nJOIN bophan bp ON nv.mabp = bp.mabp\r\nWHERE pc.tienpc = " + textBox1.Text;
                        }
                        //string query = "\r\nSELECT nv.manv as N'Mã nhân viên', nv.tennv as N'Họ tên', YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi', COUNT(*) AS [Số lượng]\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) > "+textBox1.Text +"\r\nGROUP BY nv.manv, nv.tennv, YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        dataGVTK.DataSource = ac.createTable(query);
                    }
                    else
                    {
                        chart4.Visible = true;
                        label4.Visible = false;
                        if (comboBox2.SelectedItem.ToString() == text7)
                        {
                            query = "SELECT TIENPC AS N'Tiền phụ cấp', COUNT(*) AS N'Số lượng' FROM PHUCAP\njoin luong on luong.mapc = phucap.mapc\njoin nhanvien on nhanvien.macv = luong.macv WHERE TIENPC > " + textBox1.Text + " GROUP BY TIENPC";
                        }
                        else if (comboBox2.SelectedItem.ToString() == text8)
                        {
                            query = "SELECT TIENPC AS N'Tiền phụ cấp', COUNT(*) AS N'Số lượng' FROM PHUCAP\njoin luong on luong.mapc = phucap.mapc\njoin nhanvien on nhanvien.macv = luong.macv WHERE TIENPC < " + textBox1.Text + " GROUP BY TIENPC";
                        }
                        else if (comboBox2.SelectedItem.ToString() == text9)
                        {
                            query = "SELECT TIENPC AS N'Tiền phụ cấp', COUNT(*) AS N'Số lượng' FROM PHUCAP\njoin luong on luong.mapc = phucap.mapc\njoin nhanvien on nhanvien.macv = luong.macv WHERE TIENPC = " + textBox1.Text + " GROUP BY TIENPC";
                        }
                        //string query = "\r\nSELECT nv.manv as N'Mã nhân viên', nv.tennv as N'Họ tên', YEAR(GETDATE()) - YEAR(nv.NGAYSINH) as N'Tuổi', COUNT(*) AS [Số lượng]\r\nFROM nhanvien AS nv\r\nWHERE YEAR(GETDATE()) - YEAR(nv.NGAYSINH) > "+textBox1.Text +"\r\nGROUP BY nv.manv, nv.tennv, YEAR(GETDATE()) - YEAR(nv.NGAYSINH)";
                        dataGVTK.DataSource = ac.createTable(query);
                        if (chart1.Series.Count > 0)
                        {
                            chart4.Series["Số lượng"].Points.Clear();
                            chart4.ChartAreas["ChartArea1"].AxisX.Title = text5;
                            chart4.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                            chart4.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 11);
                            chart4.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 11);
                            chart4.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                            chart4.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chart4.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;


                            for (int i = 0; i < dataGVTK.Rows.Count; i++)
                            {
                                DataGridViewRow row = dataGVTK.Rows[i];
                                string tenBP = row.Cells["Tiền phụ cấp"].Value.ToString();
                                int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                                chart4.Series["Số lượng"].Points.AddXY(tenBP, soLuong);
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else if (comboBox1.SelectedItem.ToString() == text6)
            {
                chart1.Visible = false;
                chart2.Visible = false;
                chart3.Visible = false;
                chart4.Visible = false;
                chart5.Visible = false;
                chart6.Visible = false;
                chart7.Visible = false;
                label4.Visible = true;
                try
                {
                    string query3 = @"select bp.tenbp as N'Bộ phận', luong.thuclinh as N'Tổng tiền' 
                                    from bophan as bp
                                    inner join nhanvien as nv on nv.mabp = bp.mabp 
                                    inner join luong on luong.manv = nv.manv";
                    dataGVTK.DataSource = ac.createTable(query3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if (comboBox1.SelectedItem.ToString() == text10)
            {
                chart1.Visible = false;
                chart2.Visible = false;
                chart3.Visible = false;
                chart4.Visible = false;
                chart5.Visible = true;
                chart6.Visible = false;
                chart7.Visible = false;
                label4.Visible = false;
                try
                {
                    string query = "SELECT GT AS N'Giới tính', COUNT(*) AS N'Số lượng'\r\nFROM NHANVIEN\r\nWHERE GT = N'nam' OR GT = N'nữ'\r\nGROUP BY GT";
                    dataGVTK.DataSource = ac.createTable(query);
                    if (chart5.Series.Count > 0)
                    {
                        chart5.Series["Số lượng"].Points.Clear();
                        chart5.ChartAreas["ChartArea1"].AxisX.Title = text10;
                        chart5.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                        chart5.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 11);
                        chart5.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 11);
                        chart5.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                        chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

                        for (int i = 0; i < dataGVTK.Rows.Count; i++)
                        {
                            DataGridViewRow row = dataGVTK.Rows[i];
                            string tenBP = row.Cells["Giới tính"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                            chart5.Series["Số lượng"].Points.AddXY(tenBP, soLuong);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else if (comboBox1.SelectedItem.ToString() == text11)
            {
                try
                {
                    chart1.Visible = false;
                    chart2.Visible = false;
                    chart3.Visible = false;
                    chart4.Visible = false;
                    chart5.Visible = false;
                    chart6.Visible = true;
                    chart7.Visible = false;
                    label4.Visible = false;
                    string query = "\r\nselect TDHV AS N'Trình độ học vấn', count(*) as N'Số lượng' from nhanvien\r\ngroup by TDHV";
                    dataGVTK.DataSource = ac.createTable(query);
                    if (chart6.Series.Count > 0)
                    {
                        chart6.Series["Số lượng"].Points.Clear();
                        chart6.ChartAreas["ChartArea1"].AxisX.Title = text11;
                        chart6.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                        chart6.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 11);
                        chart6.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 11);
                        chart6.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        chart6.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                        chart6.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

                        for (int i = 0; i < dataGVTK.Rows.Count; i++)
                        {
                            DataGridViewRow row = dataGVTK.Rows[i];
                            string tenBP = row.Cells["Trình độ học vấn"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                            chart6.Series["Số lượng"].Points.AddXY(tenBP, soLuong);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else if (comboBox1.SelectedItem.ToString() == text12)
            {
                chart1.Visible = false;
                chart2.Visible = false;
                chart3.Visible = false;
                chart4.Visible = false;
                chart5.Visible = false;
                chart6.Visible = false;
                chart7.Visible = true;
                label4.Visible = false;
                try
                {
                    string query = "\r\nselect loaihd as N'Loại hợp đồng', count(*) as N'Số lượng' from hdld\r\ngroup by loaihd";
                    dataGVTK.DataSource = ac.createTable(query);
                    if (chart7.Series.Count > 0)
                    {
                        chart7.Series["Số lượng"].Points.Clear();
                        chart7.ChartAreas["ChartArea1"].AxisX.Title = text12;
                        chart7.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                        chart7.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 11);
                        chart7.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 11);
                        chart7.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        chart7.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                        chart7.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

                        for (int i = 0; i < dataGVTK.Rows.Count; i++)
                        {
                            DataGridViewRow row = dataGVTK.Rows[i];
                            string tenBP = row.Cells["Loại hợp đồng"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                            chart7.Series["Số lượng"].Points.AddXY(tenBP, soLuong);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            label2.Visible= false;
            label3.Visible= false;
            checkBox1.Visible= false;
            textBox1.Visible= false;
            comboBox2.Visible= false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "text4" || comboBox1.SelectedIndex == 1)
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                checkBox1.Visible = true;
                comboBox2.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "text5" || comboBox1.SelectedIndex == 2)
            {
                label2.Visible = true;
                label2.Text = "Số tiền";
                label3.Visible = true;
                checkBox1.Visible = true;
                textBox1.Visible = true;
                comboBox2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                label3.Visible = false;
                checkBox1.Visible = false;
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void dataGVTK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGVTK.DefaultCellStyle.Font = new Font("Arial", 11);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
