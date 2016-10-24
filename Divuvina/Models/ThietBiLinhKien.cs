namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThietBiLinhKien")]
    public partial class ThietBiLinhKien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThietBiLinhKien()
        {
            BaoTriSuaChuaChiTiets = new HashSet<BaoTriSuaChuaChiTiet>();
            LichBaoTriXeChiTiets = new HashSet<LichBaoTriXeChiTiet>();
        }

        [Key]
        public int ThietBiLinhKienKey { get; set; }

        [Required]
        [StringLength(50)]
        public string ThietBiLinhKienAlternateKey { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        [StringLength(200)]
        public string HangSanXuat { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTriSuaChuaChiTiet> BaoTriSuaChuaChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTriXeChiTiet> LichBaoTriXeChiTiets { get; set; }
    }
}
