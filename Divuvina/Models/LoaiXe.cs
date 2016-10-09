namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiXe")]
    public partial class LoaiXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiXe()
        {
            Xes = new HashSet<Xe>();
        }

        [Key]
        public int LoaiXeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiXeAlternateKey { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string HangSanXuat { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        public bool MayChayDau { get; set; }

        public bool MayChayXang { get; set; }

        public short? SoGhe { get; set; }

        public short? LoaiGheKey { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual LoaiGhe LoaiGhe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Xe> Xes { get; set; }
    }
}
