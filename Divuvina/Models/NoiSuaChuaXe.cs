namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiSuaChuaXe")]
    public partial class NoiSuaChuaXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NoiSuaChuaXe()
        {
            LichBaoTriXes = new HashSet<LichBaoTriXe>();
        }

        [Key]
        public int NoiSuaChuaXeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NoiSuaChuaXeAlternateKey { get; set; }

        [Required]
        [StringLength(250)]
        public string Ten { get; set; }

        [Required]
        [StringLength(250)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTriXe> LichBaoTriXes { get; set; }
    }
}
