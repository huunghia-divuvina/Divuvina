namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TroCapNhanVienChiTietHangThang")]
    public partial class TroCapNhanVienChiTietHangThang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TroCapNhanVienChiTietHangThangKey { get; set; }

        [Required]
        [StringLength(50)]
        public string TroCapNhanVienChiTietHangThangAlternateKey { get; set; }

        public int TroCapNhanVienKey { get; set; }

        public int ThangKey { get; set; }

        public decimal? SoTien { get; set; }

        public virtual TroCapNhanVien TroCapNhanVien { get; set; }
    }
}
