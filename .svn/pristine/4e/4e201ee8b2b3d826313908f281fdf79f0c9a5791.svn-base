namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTriNhanVien")]
    public partial class ViTriNhanVien
    {
        [Key]
        public int ViTriNhanVienKey { get; set; }

        [Required]
        [StringLength(50)]
        public string ViTriNhanVienAlternateKey { get; set; }

        public int NhanVienKey { get; set; }

        public int DanhMucViTriKey { get; set; }

        public int PhongBanKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        public virtual DanhMucViTri DanhMucViTri { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhongBan PhongBan { get; set; }
    }
}
