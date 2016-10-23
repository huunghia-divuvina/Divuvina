namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucChucNang")]
    public partial class DanhMucChucNang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucChucNang()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        [Key]
        public long DanhMucChucNangKey { get; set; }

        [Required]
        [StringLength(50)]
        public string DanhMucChucNangAlternateKey { get; set; }

        public long DanhMucModuleKey { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        [StringLength(500)]
        public string DienGiai { get; set; }

        public byte? TrangThai { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual DanhMucModule DanhMucModule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
