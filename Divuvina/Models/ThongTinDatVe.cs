namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinDatVe")]
    public partial class ThongTinDatVe
    {
        [Key]
        public int ThongTinDatVeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string ThongTinDatVeAlternateKey { get; set; }

        public int VeXeKey { get; set; }

        [StringLength(100)]
        public string HoTenKhachHang { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string DiemDon { get; set; }

        public int? DiemDonQuocGiaKey { get; set; }

        public int? DiemDonTinhThanhKey { get; set; }

        public int? DiemDonQuanHuyenKey { get; set; }

        public int? DiemDonPhuongXaKey { get; set; }

        public int? DiemDonDuongKey { get; set; }

        [StringLength(20)]
        public string DiemDonSoNha { get; set; }

        public int NguoiBanKey { get; set; }

        public int DaiLyBanKey { get; set; }

        public int NguoiNhanTienKey { get; set; }

        public int DaiLyNhanTienKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianDatVe { get; set; }

        public bool DaGiaoVe { get; set; }

        public decimal GiaVe { get; set; }

        public decimal SoTienDaNhan { get; set; }

        public decimal SoTienConThieu { get; set; }

        public int TrangThaiKey { get; set; }

        public int NguoiNhapKey { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual VeXe VeXe { get; set; }
    }
}
