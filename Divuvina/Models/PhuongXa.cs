namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongXa")]
    public partial class PhuongXa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhuongXa()
        {
            LoTrinhChiTiets = new HashSet<LoTrinhChiTiet>();
        }

        [Key]
        public int PhuongXaKey { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongXaAlternateKey { get; set; }

        [StringLength(100)]
        public string TenCoDau { get; set; }

        [StringLength(100)]
        public string TenKhongDau { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinhChiTiet> LoTrinhChiTiets { get; set; }
    }
}
