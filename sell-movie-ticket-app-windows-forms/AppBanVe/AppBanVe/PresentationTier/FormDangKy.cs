using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVe.BusinessTier;
using AppBanVe.DataContext;
namespace AppBanVe.PresentationTier
{
    public partial class FormDangKy : Form
    {
        private TaiKhoanBT taiKhoanBT;
        public FormDangKy()
        {
            InitializeComponent();
            taiKhoanBT = new TaiKhoanBT();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(txtTenHienThi.Text))
            {
                MessageBox.Show("Vui Lòng nhập Tên hien thi");
                return;
            }

            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.TenDangNhap = txtTenDangNhap.Text;
            taiKhoan.MatKhau = txtMatKhau.Text;
            taiKhoan.TenHienThi = txtTenHienThi.Text;
            string error;
            if (taiKhoanBT.LuuTaiKhoan(taiKhoan,out error))
            {
                // dang nhap thanh cong
                MessageBox.Show("Tao tai khoan thanh cong");
                this.Close();
            }
            else
            {
                MessageBox.Show("lỗi"+error);
            }
        }
    }
}
