namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoTrinh")]
    public partial class LoTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoTrinh()
        {
            LoTrinhChiPhis = new HashSet<LoTrinhChiPhi>();
            LoTrinhChiTiets = new HashSet<LoTrinhChiTiet>();
        }

        [Key]
        public int LoTrinhKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoTrinhAlternateKey { get; set; }

        public int SapLichXeKey { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual SapLichXe SapLichXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinhChiPhi> LoTrinhChiPhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinhChiTiet> LoTrinhChiTiets { get; set; }
    }
}
