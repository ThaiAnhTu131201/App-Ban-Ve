using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanVe.DTO
{
    class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayMua { get; set; }
        public double TongTien { get; set; }

        public string  TenKhachHang { get; set; }
    }
}
