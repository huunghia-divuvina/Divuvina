namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuongNhanVienLichSu")]
    public partial class LuongNhanVienLichSu
    {
        [Key]
        public int LuongNhanVienLichSuKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LuongNhanVienLichSuAlternateKey { get; set; }

        public int LuongNhanVienKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThucThucTe { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual LuongNhanVien LuongNhanVien { get; set; }
    }
}
