namespace CNWeb_BTL_BanLaNha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHOADONs = new HashSet<CTHOADON>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        public DateTime? NgayLapHD { get; set; }

        public int? TongTien { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(1)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public int? MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADON> CTHOADONs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
