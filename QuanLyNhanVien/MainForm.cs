using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyNhanVien
{
    public partial class MainForm : Form
    {
        public bool isExit = true;

        //sử dụng hàm ủy thác
        public event EventHandler Logout;

        public MainForm()
        {
            InitializeComponent();
        }


        #region Event
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isExit)
                Application.Exit();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
            
        }

        #endregion
        #region Method
        void phanQuyen()
        {
            if(ConstVariable.loaiTaiKhoan == false)
            {
                tsmiQuanLyTK.Enabled = false;
            }
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            phanQuyen();
        }

        private void tsmiQuanLyTK_Click(object sender, EventArgs e)
        { 
            FormUsers fu = new FormUsers();
            fu.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNV ql = new QLNV();
            ql.ShowDialog();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChucVu cv = new ChucVu();
            cv.ShowDialog();
        }

        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoPhan bp = new BoPhan();
            bp.ShowDialog();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.ShowDialog();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            instructionHelp ins = new instructionHelp();
            ins.ShowDialog();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBan pb = new PhongBan();
            pb.ShowDialog();
        }

        private void khenThưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhenThuong kt = new KhenThuong();
            kt.ShowDialog();
        }

        private void kỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KyLuat kl = new KyLuat();
            kl.ShowDialog();
        }

        private void bảngPhụCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PhuCap pc = new PhuCap();
            pc.ShowDialog();
        }

        private void nhânViênPhụCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhuCapNhanVien pcnv = new PhuCapNhanVien();
            pcnv.ShowDialog();
        }

        private void bảoHiểmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BaoHiem bh = new BaoHiem();
            bh.ShowDialog();
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HDLD hd = new HDLD();
            hd.ShowDialog();
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LUONG lg = new LUONG();
            lg.ShowDialog();
        }

        private void ngàyCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BangCong bc = new BangCong();
            bc.ShowDialog();
        }

        private void ứngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UngLuong ul = new UngLuong();
            ul.ShowDialog();
        }

        private void tăngCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TangCa tc = new TangCa();
            tc.ShowDialog();
        }
    }
}
