namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nguoi")]
    public partial class Nguoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguoi()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        public int NguoiKey { get; set; }

        [Required]
        [StringLength(50)]
        public string Ho { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(200)]
        public string NoiSinh { get; set; }

        [Required]
        [StringLength(50)]
        public string DanToc { get; set; }

        [Required]
        [StringLength(50)]
        public string TonGiao { get; set; }

        [Required]
        [StringLength(50)]
        public string QuocTich { get; set; }

        [Required]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(15)]
        public string CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }

        [StringLength(200)]
        public string NoiCap { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
