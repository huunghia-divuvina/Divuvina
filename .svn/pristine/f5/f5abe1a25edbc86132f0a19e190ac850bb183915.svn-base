namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomNguoiDungChiTiet")]
    public partial class NhomNguoiDungChiTiet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomNguoiDungChiTiet()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        [Key]
        public long NhomNguoiDungChiTietKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NhomNguoiDungChiTietAlternateKey { get; set; }

        public long NhomNguoiDungKey { get; set; }

        public long NguoiDungKey { get; set; }

        [StringLength(500)]
        public string DienGiai { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NhomNguoiDung NhomNguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
