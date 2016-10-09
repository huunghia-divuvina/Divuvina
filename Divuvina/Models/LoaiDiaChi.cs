namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiDiaChi")]
    public partial class LoaiDiaChi
    {
        [Key]
        public int LoaiDiaChiKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiDiaChiAlternateKey { get; set; }

        [StringLength(100)]
        public string TenCoDau { get; set; }

        [StringLength(100)]
        public string TenKhongDau { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
