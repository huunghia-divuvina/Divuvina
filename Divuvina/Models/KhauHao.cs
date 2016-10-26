namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhauHao")]
    public partial class KhauHao
    {
        [Key]
        public int KhauHaoKey { get; set; }

        [Required]
        [StringLength(50)]
        public string KhauHaoAlternateKey { get; set; }

        public int XeKey { get; set; }

        public decimal? SoThangKhauHao { get; set; }

        public decimal? TongTienKhauHoa { get; set; }

        public decimal? TienKhauHaoHangThang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDauKhauHao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThucKhauHao { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual Xe Xe { get; set; }
    }
}
