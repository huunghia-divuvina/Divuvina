namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoTrinhChiTiet")]
    public partial class LoTrinhChiTiet
    {
        [Key]
        public int LoTrinhChiTietKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LoTrinhChiTietAlternateKey { get; set; }

        public int LoTrinhKey { get; set; }

        public int TinhThanhKey { get; set; }

        public int QuanHuyenKey { get; set; }

        public int PhuongXaKey { get; set; }

        public int DuongKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDi { get; set; }

        public TimeSpan GioDi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDen { get; set; }

        public TimeSpan GioDen { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        [StringLength(500)]
        public string DungChan { get; set; }

        [StringLength(500)]
        public string NoiDen { get; set; }

        public int NguoiNhapKey { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual Duong Duong { get; set; }

        public virtual LoTrinh LoTrinh { get; set; }

        public virtual PhuongXa PhuongXa { get; set; }

        public virtual QuanHuyen QuanHuyen { get; set; }

        public virtual TinhThanh TinhThanh { get; set; }
    }
}
