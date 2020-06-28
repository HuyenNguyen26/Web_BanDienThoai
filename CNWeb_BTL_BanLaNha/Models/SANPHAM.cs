namespace CNWeb_BTL_BanLaNha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTHOADONs = new HashSet<CTHOADON>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuong { get; set; }

        public int? GiaSP { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string BoNho { get; set; }

        [StringLength(50)]
        public string HDH { get; set; }

        [StringLength(50)]
        public string MauSac { get; set; }

        [StringLength(50)]
        public string Pin { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        [StringLength(50)]
        public string Camera { get; set; }

        public int? MaBH { get; set; }

        public int? MaLoai { get; set; }

        public int? MaNSX { get; set; }

        public int? MaKM { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        public virtual BAOHANH BAOHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADON> CTHOADONs { get; set; }

        public virtual KHUYENMAI KHUYENMAI { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
