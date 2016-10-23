namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoTriSuaChuaChiTiet")]
    public partial class BaoTriSuaChuaChiTiet
    {
        [Key]
        public int BaoTriSuaChuaChiTietKey { get; set; }

        [Required]
        [StringLength(50)]
        public string BaoTriSuaChuaChiTietAlternateKey { get; set; }

        public int BaoTriSuaChuaKey { get; set; }

        public int ThietBiLinhKienKey { get; set; }

        public decimal? Thue { get; set; }

        public decimal? SoLuong { get; set; }

        public decimal? TongTien { get; set; }

        public virtual BaoTriSuaChua BaoTriSuaChua { get; set; }

        public virtual ThietBiLinhKien ThietBiLinhKien { get; set; }
    }
}
