namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichBaoTriXeChiTiet")]
    public partial class LichBaoTriXeChiTiet
    {
        [Key]
        public int LichBaoTriXeChiTietKey { get; set; }

        public int LichBaoTriXeKey { get; set; }

        public int ThietBiLinhKienKey { get; set; }

        public decimal? Thue { get; set; }

        public decimal? SoLuong { get; set; }

        public decimal? TongTien { get; set; }

        public virtual LichBaoTriXe LichBaoTriXe { get; set; }

        public virtual ThietBiLinhKien ThietBiLinhKien { get; set; }
    }
}
