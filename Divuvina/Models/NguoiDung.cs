namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            NhomNguoiDungChiTiets = new HashSet<NhomNguoiDungChiTiet>();
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        [Key]
        public long NguoiDungKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NguoiDungAlternateKey { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        public long NhanVienKey { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public byte? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomNguoiDungChiTiet> NhomNguoiDungChiTiets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
