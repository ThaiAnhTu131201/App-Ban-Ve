using AppBanVe.DataContext;
using AppBanVe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanVe.DataTier
{
    class HoaDonDT
    {
        public bool ThemHoaDon(HoaDon hoaDon, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new AppBanVeModel())
                {
                    dbcontext.HoaDon.Add(hoaDon);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch(Exception excepption)
            {
                error = excepption.Message;
                return false;
            }
        }

        internal List<HoaDonDTO> LayDanhSachHoaDon()
        {
            using (var dbcontexgt = new AppBanVeModel())
            {
                return (from hd in dbcontexgt.HoaDon
                        select new HoaDonDTO()
                        {
                            MaHoaDon = hd.MaHoaDon,
                            NgayMua = hd.NgayMua,
                            TongTien = hd.TongTien,
                            TenKhachHang = hd.KhachHang.TenKhachHang
                        }).ToList();
            }
        }

        internal List<HoaDonDTO> LayDanhSachHoaDonTheoKhachHang(int maKhachHang)
        {
            using (var dbcontexgt = new AppBanVeModel())
            {
                return (from hd in dbcontexgt.HoaDon
                        where hd.MaKhachHang == maKhachHang
                        select new HoaDonDTO()
                        {
                            MaHoaDon = hd.MaHoaDon,
                            NgayMua = hd.NgayMua,
                            TongTien = hd.TongTien,
                            TenKhachHang = hd.KhachHang.TenKhachHang
                        }).ToList();
            }
        }
    }
}
