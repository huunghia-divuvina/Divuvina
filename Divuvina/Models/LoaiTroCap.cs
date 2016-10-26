namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTroCap")]
    public partial class LoaiTroCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTroCap()
        {
            TroCapNhanViens = new HashSet<TroCapNhanVien>();
        }

        [Key]
        public int LoaiTroCapKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiTroCapAlternateKey { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        [StringLength(400)]
        public string GhiChu { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TroCapNhanVien> TroCapNhanViens { get; set; }
    }
}
