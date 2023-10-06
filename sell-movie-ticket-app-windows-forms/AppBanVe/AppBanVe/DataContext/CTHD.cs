namespace AppBanVe.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }

        public int MaHoaDon { get; set; }

        public int MaGhe { get; set; }

        public virtual Ghe Ghe { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
