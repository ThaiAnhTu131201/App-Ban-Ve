using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVe.DataContext;
namespace AppBanVe.DataTier
{
    class TaiKhoanDT
    {
        public TaiKhoan LayTaiKhoan(string tenDangNhap, string matKhau)
        {
            using (var dbContext = new AppBanVeModel())
            {
                return dbContext.TaiKhoan.Where(s => s.TenDangNhap == tenDangNhap && s.MatKhau == matKhau).FirstOrDefault();
            }
        }
        public bool LuuTaiKhoan(TaiKhoan taiKhoan, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new AppBanVeModel())
                {
                    dbcontext.TaiKhoan.Add(taiKhoan);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception excepption)
            {
                error = excepption.Message + "\n" + excepption.InnerException;
                return false;
            }
        }
    }
}
