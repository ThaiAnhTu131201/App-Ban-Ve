using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVe.DataContext;
using AppBanVe.DataTier;
using AppBanVe.Libs;

namespace AppBanVe.BusinessTier
{
    class TaiKhoanBT
    {
        private readonly TaiKhoanDT taiKhoanDT;
        public TaiKhoanBT()
        {
            taiKhoanDT = new TaiKhoanDT();
        }
        public TaiKhoan LayTaiKhoan(string tenDangNhap, string matKhau)
        {
            matKhau = Helpers.MaHoaMatKhauMD5(matKhau);
            return taiKhoanDT.LayTaiKhoan(tenDangNhap, matKhau);            
        }
        public bool LuuTaiKhoan(TaiKhoan taiKhoan, out string error)
        {
            try
            {
                taiKhoan.MatKhau = Helpers.MaHoaMatKhauMD5(taiKhoan.MatKhau);
                return taiKhoanDT.LuuTaiKhoan(taiKhoan, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }


    }
}
