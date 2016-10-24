namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuocGia")]
    public partial class QuocGia
    {
        [Key]
        public int QuocGiaKey { get; set; }

        [Required]
        [StringLength(50)]
        public string QuocGiaAlternateKey { get; set; }

        [StringLength(100)]
        public string TenCoDau { get; set; }

        [StringLength(100)]
        public string TenKhongDau { get; set; }

        [StringLength(50)]
        public string CountryCode { get; set; }

        [MaxLength(50)]
        public byte[] Culture { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
