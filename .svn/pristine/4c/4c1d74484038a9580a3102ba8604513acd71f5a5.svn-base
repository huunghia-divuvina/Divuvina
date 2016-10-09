namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoTriSuaChua")]
    public partial class BaoTriSuaChua
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaoTriSuaChua()
        {
            BaoTriSuaChuaChiTiets = new HashSet<BaoTriSuaChuaChiTiet>();
        }

        [Key]
        public int BaoTriSuaChuaKey { get; set; }

        [Required]
        [StringLength(50)]
        public string BaoTriSuaChuaAlternateKey { get; set; }

        public int? LichBaoTriXeKey { get; set; }

        public int? XeKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThucHien { get; set; }

        public int NhanVienThucHienKey { get; set; }

        [StringLength(200)]
        public string TenNoiSuaChua { get; set; }

        [StringLength(200)]
        public string DiaChiNoiSuaChua { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual LichBaoTriXe LichBaoTriXe { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Xe Xe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTriSuaChuaChiTiet> BaoTriSuaChuaChiTiets { get; set; }
    }
}
