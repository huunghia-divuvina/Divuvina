namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoTrinhChiPhi")]
    public partial class LoTrinhChiPhi
    {
        [Key]
        public int LoTrinhChiPhiKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoTrinhChiPhiAlternateKey { get; set; }

        public int LoTrinhKey { get; set; }

        public int DanhMucChiPhiKey { get; set; }

        public decimal? TienChi { get; set; }

        public decimal? Thue { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        public int NguoiNhapKey { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual DanhMucChiPhi DanhMucChiPhi { get; set; }

        public virtual LoTrinh LoTrinh { get; set; }
    }
}
