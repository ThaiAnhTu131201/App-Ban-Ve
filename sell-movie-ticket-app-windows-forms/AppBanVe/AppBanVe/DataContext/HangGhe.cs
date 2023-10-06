namespace AppBanVe.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangGhe")]
    public partial class HangGhe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangGhe()
        {
            Ghe = new HashSet<Ghe>();
        }

        [Key]
        public int MaHangGhe { get; set; }

        [Required]
        [StringLength(1)]
        public string Ten { get; set; }

        public double GiaTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ghe> Ghe { get; set; }
    }
}
