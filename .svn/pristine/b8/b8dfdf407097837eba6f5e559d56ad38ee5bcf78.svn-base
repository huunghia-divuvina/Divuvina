namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgayNghiPhep")]
    public partial class NgayNghiPhep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NgayNghiPhep()
        {
            NgayNghiPhepChiTiets = new HashSet<NgayNghiPhepChiTiet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NgayNghiPhepKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NgayNghiPhepAlternateKey { get; set; }

        public int NhanVienKey { get; set; }

        public int? TongNgayNghi { get; set; }

        public int? NamApDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        public int? SoNgayDaDung { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NgayNghiPhepChiTiet> NgayNghiPhepChiTiets { get; set; }
    }
}
