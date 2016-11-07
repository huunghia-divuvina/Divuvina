namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucViTri")]
    public partial class DanhMucViTri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucViTri()
        {
            ViTriNhanViens = new HashSet<ViTriNhanVien>();
        }

        [Key]
        public int DanhMucViTriKey { get; set; }

        [StringLength(50)]
        public string DanhMucViTriAlternateKey { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTriNhanVien> ViTriNhanViens { get; set; }
    }
}
