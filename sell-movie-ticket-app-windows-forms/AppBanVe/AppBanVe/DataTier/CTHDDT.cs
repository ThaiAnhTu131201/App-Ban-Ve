    using AppBanVe.DataContext;
using AppBanVe.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanVe.DataTier
{
    class CTHDDT
    {
        public bool ThemChiTietHoaDon(CTHD cTHD, out string error)
        {
            error = string.Empty;
            try
            { 
                using (var dbcontext = new AppBanVeModel())
                {
                    dbcontext.CTHD.Add(cTHD);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception excepption)
            {
                error = excepption.Message;
                return false;
            }
        }

        internal List<CTHDDTO> LayDanhSachChiTietTheoMaHoaDon(int maHoaDon)
        {
            using (var dbcontext = new AppBanVeModel())
            {
                return (from ct in dbcontext.CTHD
                        where ct.MaHoaDon == maHoaDon
                        select new CTHDDTO()
                        {
                            MaHoaDon = ct.MaHoaDon,
                            SoGhe = ct.Ghe.SoGhe,
                            GiaTien = ct.Ghe.HangGhe.GiaTien
                        }).ToList();
            }
        }

        internal List<int> LayDanhSachSoGheDaMuaTheoNgay(DateTime ngay)
        {
            using (var dbcontext = new AppBanVeModel())
            {
                return dbcontext.CTHD.Where(ct => EntityFunctions.TruncateTime(ct.HoaDon.NgayMua) == EntityFunctions.TruncateTime(ngay)).Select(ct => ct.Ghe.SoGhe).ToList();
            }
        }
    }
}
