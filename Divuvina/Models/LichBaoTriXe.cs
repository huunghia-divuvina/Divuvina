namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichBaoTriXe")]
    public partial class LichBaoTriXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichBaoTriXe()
        {
            BaoTriSuaChuas = new HashSet<BaoTriSuaChua>();
            LichBaoTriXeChiTiets = new HashSet<LichBaoTriXeChiTiet>();
        }

        [Key]
        public int LichBaoTriXeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LichBaoTriXeAlternateKey { get; set; }

        public int XeKey { get; set; }

        public int? NoiSuaChuaXeKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySapLich { get; set; }

        public DateTime? NgaySapLichHeThong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThucHien { get; set; }

        public DateTime? NgayThucHienHeThong { get; set; }

        public int? NhanVienThucHienKey { get; set; }

        [StringLength(200)]
        public string TenNoiSuaChua { get; set; }

        [StringLength(200)]
        public string DiaChiNoiSuaChua { get; set; }

        public int? NhanVienSapLichKey { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTriSuaChua> BaoTriSuaChuas { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }

        public virtual NoiSuaChuaXe NoiSuaChuaXe { get; set; }

        public virtual Xe Xe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTriXeChiTiet> LichBaoTriXeChiTiets { get; set; }
    }
}
