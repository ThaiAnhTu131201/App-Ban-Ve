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
using AppBanVe.DTO;
using Microsoft.Reporting.WinForms;

namespace AppBanVe.PresentationTier
    
{
    public partial class FormBaoCaoDoanhThu : Form
    {
        private HoaDonBT hoaDonBT;
        private KhachHangBT khachHangBT;
        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();
            hoaDonBT = new HoaDonBT();
            khachHangBT = new KhachHangBT();
            cbxKhachHang.DisplayMember = "TenKhachHang";
            cbxKhachHang.ValueMember = "MaKhachHang";
        }

        private void FormBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            cbxKhachHang.DataSource = khachHangBT.LayDanhSach();
            this.reportViewer1.RefreshReport();
        }

        private void cbxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lay ma khach hang
            int maKhachHang = int.Parse(cbxKhachHang.SelectedValue.ToString());

            List<HoaDonDTO> danhSachHoaDonTheoKhachHang = hoaDonBT.LayDanhSachHoaDonTheoKhachHang(maKhachHang);

            // cai dat hien thi len report viewer
            this.reportViewer1.LocalReport.ReportPath = "ReportBaoCaoDoanhThu.rdlc";
            var reportDataSource = new ReportDataSource("HoaDonDataSet", danhSachHoaDonTheoKhachHang);
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
