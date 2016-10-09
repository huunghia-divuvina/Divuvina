namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucModule")]
    public partial class DanhMucModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucModule()
        {
            DanhMucChucNangs = new HashSet<DanhMucChucNang>();
        }

        [Key]
        public long DanhMucModuleKey { get; set; }

        [Required]
        [StringLength(50)]
        public string DanhMucModuleAlternateKey { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        [StringLength(500)]
        public string DienGiai { get; set; }

        public byte? TrangThai { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucChucNang> DanhMucChucNangs { get; set; }
    }
}
