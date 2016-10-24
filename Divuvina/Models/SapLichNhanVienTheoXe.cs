namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SapLichNhanVienTheoXe")]
    public partial class SapLichNhanVienTheoXe
    {
        [Key]
        public int SapLichNhanVienTheoXeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string SapLichNhanVienTheoXeAlternateKey { get; set; }

        public int SapLichXeKey { get; set; }

        public int NhanVienKey { get; set; }

        [StringLength(100)]
        public string ViTri { get; set; }

        public int NguoiNhapKey { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual SapLichXe SapLichXe { get; set; }
    }
}
