namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDongLaoDong")]
    public partial class HopDongLaoDong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HopDongLaoDongKey { get; set; }

        [Required]
        [StringLength(50)]
        public string HopDongLaoDongAlternateKey { get; set; }

        public int LoaiHopDongKey { get; set; }

        public int NhanVienKey { get; set; }

        [Required]
        [StringLength(250)]
        public string TenBenSuDungLaoDong { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVuBenSuDungLaoDong { get; set; }

        [Required]
        [StringLength(50)]
        public string QuocTichBenSuDungLaoDong { get; set; }

        [Required]
        [StringLength(15)]
        public string DienThoaiBenSuDungLaoDong { get; set; }

        [Required]
        [StringLength(250)]
        public string DiaChiBenSuDungLaoDong { get; set; }

        [Required]
        [StringLength(250)]
        public string DaiDienDien { get; set; }

        [StringLength(20)]
        public string SoLaoDong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapSoLaoDong { get; set; }

        [StringLength(300)]
        public string NoiCapSoLaoDong { get; set; }

        [Required]
        [StringLength(150)]
        public string TenNgheNghiep { get; set; }

        [Required]
        [StringLength(500)]
        public string CongViecPhaiLam { get; set; }

        [Required]
        [StringLength(15)]
        public string ThoiGianLamViec { get; set; }

        [StringLength(400)]
        public string DungCuLamViecDuocCap { get; set; }

        [Required]
        [StringLength(400)]
        public string DiaDiemLamViec { get; set; }

        [Required]
        [StringLength(100)]
        public string PhuongTienDiLaiLamViec { get; set; }

        public decimal TongLuong { get; set; }

        public decimal MucLuongCoBan { get; set; }

        public decimal PhuCap { get; set; }

        [StringLength(50)]
        public string HinhThucTraLuong { get; set; }

        [StringLength(50)]
        public string NgayTraLuong { get; set; }

        public byte[] BanSaoHopDongLaoDong { get; set; }

        public int TrangThaiKey { get; set; }

        public virtual LoaiHopDong LoaiHopDong { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
