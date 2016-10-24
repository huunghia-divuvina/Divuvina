namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuongNhanVien")]
    public partial class LuongNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LuongNhanVien()
        {
            LuongNhanVienLichSus = new HashSet<LuongNhanVienLichSu>();
        }

        [Key]
        public int LuongNhanVienKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LuongNhanVienAlternateKey { get; set; }

        public int NhanVienKey { get; set; }

        public decimal? BacLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayApDung { get; set; }

        public decimal? TienLuongCoBan { get; set; }

        public decimal? HeSoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuongNhanVienLichSu> LuongNhanVienLichSus { get; set; }
    }
}
