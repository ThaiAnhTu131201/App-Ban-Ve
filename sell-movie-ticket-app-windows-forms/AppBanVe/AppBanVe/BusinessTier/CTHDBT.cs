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
    class CTHDBT
    {
        private readonly CTHDDT cTHDDT;
        public CTHDBT()
        {
            cTHDDT = new CTHDDT();
        }
        public bool LuuChiTietHoaDon(CTHD cTHD, out string error)
        {
            error = string.Empty;
            try
            {
                return cTHDDT.ThemChiTietHoaDon(cTHD, out error);
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        internal  List<CTHDDTO> LayDanhSachChiTietTheoMaHoaDon(int maHoaDon)
        {
            return cTHDDT.LayDanhSachChiTietTheoMaHoaDon(maHoaDon);
        }

        internal List<int> LayDanhSachSoGheDaMuaTheoNgay(DateTime ngay)
        {
            return cTHDDT.LayDanhSachSoGheDaMuaTheoNgay(ngay); 
        }
    }
}
