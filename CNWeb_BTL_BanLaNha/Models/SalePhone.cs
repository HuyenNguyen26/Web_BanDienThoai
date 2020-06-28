namespace CNWeb_BTL_BanLaNha.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SalePhone : DbContext
    {
        public SalePhone()
            : base("name=SalePhone")
        {
        }

        public virtual DbSet<BAOHANH> BAOHANHs { get; set; }
        public virtual DbSet<CTHOADON> CTHOADONs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HOADON>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CTHOADONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUYENMAI>()
                .Property(e => e.PhanTramKM)
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.BoNho)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HDH)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.Pin)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.KichThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.Camera)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTHOADONs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.is_ADMIN)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
