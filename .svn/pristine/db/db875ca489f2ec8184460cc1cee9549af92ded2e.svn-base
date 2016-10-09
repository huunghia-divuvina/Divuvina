namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomNguoiDung")]
    public partial class NhomNguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomNguoiDung()
        {
            NhomNguoiDungChiTiets = new HashSet<NhomNguoiDungChiTiet>();
        }

        [Key]
        public long NhomNguoiDungKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NhomNguoiDungAlternateKey { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(500)]
        public string DienGiai { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomNguoiDungChiTiet> NhomNguoiDungChiTiets { get; set; }
    }
}
