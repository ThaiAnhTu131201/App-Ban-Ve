using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVe.DataContext;
using AppBanVe.DTO;
namespace AppBanVe.DataTier
{
    class KhachHangDT
    {
        public List<KhachHangDTO> LayDanhSach()
        {
            using (var dbContext = new AppBanVeModel())
            {
                return (from kh in dbContext.KhachHang
                        select new KhachHangDTO() {
                            MaKhachHang = kh.MaKhachHang,
                            TenKhachHang = kh.TenKhachHang
                        }).ToList();
            }
        }
        public bool ThemKhachHang(KhachHang khachHang, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new AppBanVeModel())
                {
                    dbcontext.KhachHang.Add(khachHang);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;
            }
        }
        public bool SuaKhachHang(KhachHang khachHang, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new AppBanVeModel())
                {
                    var khachHangUpdate = dbcontext.KhachHang.SingleOrDefault(s => s.MaKhachHang == khachHang.MaKhachHang);
                    if (khachHangUpdate == null)
                    {
                        error = "KHACH HANG KO TON TAI!!!!";
                        return false;
                    }
                    khachHangUpdate.TenKhachHang = khachHang.TenKhachHang;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;
            }
        }
        public bool XoaKhachHang(int makhachHang, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new AppBanVeModel())
                {
                    if (dbcontext.HoaDon.Any(s=>s.MaKhachHang == makhachHang))
                    {
                        error = "KHACH HANG KO TON TAI HOA DON --------> KHONG THE XOA";
                        return false;
                    }
                    var khachHangDelete = dbcontext.KhachHang.SingleOrDefault(s => s.MaKhachHang == makhachHang);
                    if (khachHangDelete == null)
                    {
                        error = "KHACH HANG KO TON TAI!!!!";
                        return false;
                    }
                    dbcontext.KhachHang.Remove(khachHangDelete);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;
            }
        }
    }
}
