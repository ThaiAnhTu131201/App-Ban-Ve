using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVe.DataContext;
using AppBanVe.BusinessTier;
namespace AppBanVe.PresentationTier
{
    public delegate void DangNhapThanhCong(string tenHienThi);
    public partial class FormDangNhap : Form
    {
        public event DangNhapThanhCong DangNhapThanhCongEvent;
        private TaiKhoanBT taiKhoanBT;
        public FormDangNhap()
        {
            InitializeComponent();
            taiKhoanBT = new TaiKhoanBT();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui Lòng nhập tên đăng nhập");
                return;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui Lòng nhập Mật Khẩu");
                return;
            }

            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            TaiKhoan taiKhoan = taiKhoanBT.LayTaiKhoan(tenDangNhap, matKhau);
            if (taiKhoan != null)
            {
                // dang nhap thanh cong
                MessageBox.Show("Dang nhap thanh cong");
                this.Close();
                DangNhapThanhCongEvent(taiKhoan.TenHienThi);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FormDangKy frdk = new FormDangKy();
            frdk.StartPosition = FormStartPosition.CenterScreen;
            frdk.ShowDialog();
        }
    }
}
