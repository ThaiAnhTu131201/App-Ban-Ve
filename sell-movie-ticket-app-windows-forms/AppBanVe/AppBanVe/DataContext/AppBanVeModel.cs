using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppBanVe.DataContext
{
    public partial class AppBanVeModel : DbContext
    {
        public AppBanVeModel()
            : base("name=AppBanVeModel")
        {
        }

        public virtual DbSet<CTHD> CTHD { get; set; }
        public virtual DbSet<Ghe> Ghe { get; set; }
        public virtual DbSet<HangGhe> HangGhe { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ghe>()
                .HasMany(e => e.CTHD)
                .WithRequired(e => e.Ghe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangGhe>()
                .Property(e => e.Ten)
                .IsFixedLength();

            modelBuilder.Entity<HangGhe>()
                .HasMany(e => e.Ghe)
                .WithRequired(e => e.HangGhe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHD)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDon)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);
        }
    }
}
