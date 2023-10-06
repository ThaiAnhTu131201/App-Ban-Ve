using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVe.DTO;
using AppBanVe.DataContext;
using AppBanVe.BusinessTier;
namespace AppBanVe.PresentationTier
{
    public delegate void CapNhapKhachHang();
    public partial class FormKhachHang : Form
    {
        public event CapNhapKhachHang capNhatKhachHangEvent;
        int maKhachHang;
        private KhachHangBT khachHangBT;
        public FormKhachHang()
        {
            InitializeComponent();
            khachHangBT = new KhachHangBT();
            this.Load += FormKhachHang_Load;
            maKhachHang = -1; // chua khach hang nao dc chon
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {   
            TaiDanhSachKhachHang();
            CaiDatChucNang(true);
        }

        private void CaiDatChucNang(bool status)
        {
            //status =true ---> mo chuc nang them , khoa chuc nang sua xoa huy va nguoc lai
            btnThem.Enabled = status;
            btnHuy.Enabled = !status;
            btnSua.Enabled = !status;
            btnXoa.Enabled = !status;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKhachHang.Text))
            {
                MessageBox.Show("Vui Long Nhap ten !!!!");
                return; 
            }
            string error;
            KhachHang khachHang = new KhachHang();
            khachHang.TenKhachHang = txtKhachHang.Text;
            if (khachHangBT.LuuKhachHang(khachHang, out error))
            {
                MessageBox.Show("Luu Thanh Cong!!!");
                txtKhachHang.Text = " ";
                TaiDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("LOI: " + error);
                return;
            }
        }

        private void TaiDanhSachKhachHang()
        {
            dgvDanhSachKhachHang.DataSource = khachHangBT.LayDanhSach();
        }

        private void dgvDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dongchon = e.RowIndex;
            maKhachHang = int.Parse(dgvDanhSachKhachHang.Rows[dongchon].Cells[0].Value.ToString());
            string tenKhachHang = dgvDanhSachKhachHang.Rows[dongchon].Cells[1].Value.ToString();
            txtKhachHang.Text = tenKhachHang;
            CaiDatChucNang(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maKhachHang == -1)
            {
                MessageBox.Show("Vui Long Chon khach hang !!!!");
                return;
            }
            if (string.IsNullOrEmpty(txtKhachHang.Text))
            {
                MessageBox.Show("Vui Long Nhap ten !!!!");
                return;
            }
            string error;
            KhachHang khachHang = new KhachHang();
            khachHang.TenKhachHang = txtKhachHang.Text;
            khachHang.MaKhachHang = maKhachHang;
            if (khachHangBT.LuuKhachHang(khachHang, out error))
            {
                MessageBox.Show("Sua Thanh Cong!!!");
                txtKhachHang.Text = " ";
                TaiDanhSachKhachHang();
                CaiDatChucNang(true);
            }
            else
            {
                MessageBox.Show("LOI: " + error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maKhachHang == -1)
            {
                MessageBox.Show("Vui Long Chon khach hang !!!!");
                return;
            }
            string error;
            if (khachHangBT.XoaKhachHang(maKhachHang, out error))
            {
                MessageBox.Show("Xoa Thanh Cong!!!");
                txtKhachHang.Text = " ";
                TaiDanhSachKhachHang();
                CaiDatChucNang(true);
            }
            else
            {
                MessageBox.Show("LOI: " + error);
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtKhachHang.Text = " ";
            CaiDatChucNang(true);
            maKhachHang = -1;
        }

        private void FormKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            capNhatKhachHangEvent();
        }
    }
}
