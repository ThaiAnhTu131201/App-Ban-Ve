using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVe.DataContext;
namespace AppBanVe.DataTier
{
    class GheDT
    {
        public double LayGiaTienTheoSoGhe(int soGhe)
        {
            using (var dbContext = new AppBanVeModel())
            {
                return dbContext.Ghe.Where(s => s.SoGhe == soGhe).FirstOrDefault().HangGhe.GiaTien;
            }
            //return giaTienGhe;
        }

        internal Ghe LayGheTheoSoGhe(int soGhe)
        {
            using (var dbconText = new AppBanVeModel())
            {
                return dbconText.Ghe.Include("HangGhe").Where(s => s.SoGhe == soGhe).FirstOrDefault();
            }
        }
    }
}
