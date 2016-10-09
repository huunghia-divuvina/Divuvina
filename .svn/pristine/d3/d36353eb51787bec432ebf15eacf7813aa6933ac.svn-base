namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TroCapNhanVien")]
    public partial class TroCapNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TroCapNhanVien()
        {
            TroCapNhanVienChiTietHangThangs = new HashSet<TroCapNhanVienChiTietHangThang>();
        }

        [Key]
        public int TroCapNhanVienKey { get; set; }

        [Required]
        [StringLength(50)]
        public string TroCapNhanVienAlternateKey { get; set; }

        public int NhanVienKey { get; set; }

        public int LoaiTroCapKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        public virtual LoaiTroCap LoaiTroCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TroCapNhanVienChiTietHangThang> TroCapNhanVienChiTietHangThangs { get; set; }
    }
}
