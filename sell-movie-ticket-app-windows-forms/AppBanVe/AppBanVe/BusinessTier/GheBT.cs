using AppBanVe.DataContext;
using AppBanVe.DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanVe.BusinessTier
{
    class GheBT
    {
        private readonly GheDT gheDT;
        public GheBT()
        {
            gheDT = new GheDT();
        }
        public double LayGiaGheTheoSoGhe(int soGhe)
        {
            return gheDT.LayGiaTienTheoSoGhe(soGhe);
        }

        internal Ghe LayGheTuSoGhe(int soGhe)
        {
            return gheDT.LayGheTheoSoGhe(soGhe);
        }
    }
}
