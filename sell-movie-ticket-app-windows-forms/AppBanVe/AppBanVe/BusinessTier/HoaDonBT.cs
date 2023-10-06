using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVe.DataContext;
using AppBanVe.DataTier;
using AppBanVe.DTO;

namespace AppBanVe.BusinessTier
{
    class HoaDonBT
    {
        private readonly HoaDonDT hoaDonDT;
        public HoaDonBT()
        {
            hoaDonDT = new HoaDonDT();
        }
        public bool LuuHoaDon(HoaDon hoaDon, out string error)
        {
            error = string.Empty;
            try
            {
                return hoaDonDT.ThemHoaDon(hoaDon, out error);
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        internal List<HoaDonDTO> LayDanhSachHoaDon()
        {
            return hoaDonDT.LayDanhSachHoaDon();
        }

        internal List<HoaDonDTO> LayDanhSachHoaDonTheoKhachHang(int maKhachHang)
        {
            return hoaDonDT.LayDanhSachHoaDonTheoKhachHang(maKhachHang);
        }
    }
}
