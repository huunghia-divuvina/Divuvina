namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucChiPhi")]
    public partial class DanhMucChiPhi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucChiPhi()
        {
            LoTrinhChiPhis = new HashSet<LoTrinhChiPhi>();
        }

        [Key]
        public int DanhMucChiPhiKey { get; set; }

        [Required]
        [StringLength(50)]
        public string DanhMucChiPhiAlternateKey { get; set; }

        [StringLength(400)]
        public string DienGiai { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinhChiPhi> LoTrinhChiPhis { get; set; }
    }
}
