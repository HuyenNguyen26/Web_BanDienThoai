namespace CNWeb_BTL_BanLaNha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("spMoi")]
    public partial class spMoi
    {
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

        [Column(TypeName = "date")]
        public DateTime? NgayPhatHanh { get; set; }

        public int? Expr1 { get; set; }

        [StringLength(50)]
        public string SuKien { get; set; }

        [StringLength(25)]
        public string PhanTramKM { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }
    }
}
