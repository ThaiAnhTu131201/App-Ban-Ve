using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBanVe.PresentationTier
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tssLoiChao.Text = " ";
            // Cai Dat menu chuong trinh
            // false: chua dang nhap
            // true: da dang nhap
            CaiDatMenuChuongTrinh(false);
            menuDangNhap.PerformClick();
        }

        private void CaiDatMenuChuongTrinh(bool status)
        {
            menuDangNhap.Enabled = !status;
            menuDangXuat.Enabled = status;
            menuQuanLy.Enabled = status;
            menuBanVe.Enabled = status;
            menuBaoCao.Enabled = status;

        }

        private void menuDangNhap_Click(object sender, EventArgs e)
        {
            // kiem tra frdn ton tai hay chua 
            Form frm = this.MdiChildren.OfType<FormDangNhap>().FirstOrDefault();
            if (frm == null)
            {
                FormDangNhap frdn = new FormDangNhap();
                // gán làm form con của form hien tai
                frdn.MdiParent = this;
                frdn.DangNhapThanhCongEvent += Frdn_DangNhapThanhCongEvent;
                frdn.StartPosition = FormStartPosition.CenterScreen;
                frdn.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void Frdn_DangNhapThanhCongEvent(string tenHienThi)
        {
            CaiDatMenuChuongTrinh(true);
            tssLoiChao.Text = tenHienThi;
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            // dong tat ca cac cua so
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            // cai dat menu false
            CaiDatMenuChuongTrinh(false);
            tssLoiChao.Text = " ";
            menuDangNhap.PerformClick();
        }

        private void menuBanVe_Click(object sender, EventArgs e)
        {
            // kiem tra frdn ton tai hay chua 
            Form frm = this.MdiChildren.OfType<FromBanVe>().FirstOrDefault();
            if (frm == null)
            {
                FromBanVe frbv = new FromBanVe();
                // gán làm form con của form hien tai
                frbv.MdiParent = this;
                frbv.StartPosition = FormStartPosition.CenterScreen;
                frbv.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        { 
            // kiem tra frdn ton tai hay chua 
            Form frm = this.MdiChildren.OfType<FormKhachHang>().FirstOrDefault();
            if (frm == null)
            {
                FormKhachHang frkh = new FormKhachHang();
                // gán làm form con của form hien tai
                frkh.MdiParent = this;
                frkh.capNhatKhachHangEvent += Frkh_capNhatKhachHangEvent;
                frkh.StartPosition = FormStartPosition.CenterScreen;
                frkh.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void Frkh_capNhatKhachHangEvent()
        {
            //kiem tra form ban ve mo dc hay ko ?
            //neu mo thi cap nhat combobox khach hang
            // neu ko mo thi ko lam gica
            FromBanVe frbv = this.MdiChildren.OfType<FromBanVe>().FirstOrDefault();
            if (frbv != null)
            {
                frbv.TaiDanhSachKhachHang();
            }
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.OfType<FormBaoCaoDoanhThu>().FirstOrDefault();
            if (frm == null)
            {
                FormBaoCaoDoanhThu frbcdt = new FormBaoCaoDoanhThu();
                // gán làm form con của form hien tai
                frbcdt.MdiParent = this;
                frbcdt.StartPosition = FormStartPosition.CenterScreen;
                frbcdt.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
