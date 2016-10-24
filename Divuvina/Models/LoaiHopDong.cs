namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiHopDong")]
    public partial class LoaiHopDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiHopDong()
        {
            HopDongLaoDongs = new HashSet<HopDongLaoDong>();
        }

        [Key]
        public int LoaiHopDongKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiHopDongAlternateKey { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public byte? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongLaoDong> HopDongLaoDongs { get; set; }
    }
}
