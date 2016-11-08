using Divuvina.Public;
using System;
using System.ComponentModel.DataAnnotations;

namespace Divuvina.Models.QuanLyXe
{
    public class ThongTinXeVaKhauHaoModel
    {
        [Required, Display(Name = "Xe key")]
        public int XeKey { get; set; }

        [Display(Name = "Key tham chiếu bảng Hãng sản xuất xe")]
        public short? HangSanXuatXeKey { get; set; }

        [Display(Name = "Hãng sản xuất xe")]
        public string HangSanXuatXe { get; set; }

        [Required, Display(Name = "Key tham chiếu bảng Loại xe")]
        public int LoaiXeKey { get; set; }

        [Display(Name = "Loại xe")]
        public string LoaiXe { get; set; }

        [Required, Display(Name = "Bảng số xe"), MaxLength(15)]
        public string BangSoXe { get; set; }

        [Required, Display(Name = "Số sàn"), MaxLength(20)]
        public string SoSan { get; set; }

        [Required, Display(Name = "Ngày cấp phép"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime NgayCapPhep { get; set; }

        [Required, Display(Name = "Màu"), MaxLength(50)]
        public string Mau { get; set; }

        [Required, Display(Name = "Tổng giá xe")]
        public decimal GiaMua { get; set; }

        [Required, Display(Name = "Có Wifi")]
        public bool CoWifi { get; set; }

        [Required, Display(Name = "Có Tivi")]
        public bool CoTivi { get; set; }

        [Required, Display(Name = "Có Camera hành trình")]
        public bool CoCameraHanhTrinh { get; set; }

        [Required, Display(Name = "Ghi chú"), MaxLength(500)]
        public string GhiChuThongTinXe { get; set; }

        [Required, Display(Name = "Số tháng khấu hao")]
        public decimal? SoThangKhauHao { get; set; }

        [Required, Display(Name = "Tổng tiền khấu hao xe")]
        public decimal? TongTienKhauHao { get; set; }

        [Required, Display(Name = "Tiền khấu hao xe hàng tháng")]
        public decimal? TienKhauHaoHangThang { get; set; }

        [Required, Display(Name = "Ngày bắt đầu khấu hao"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? NgayBatDauKhauHao { get; set; }

        [Required, Display(Name = "Ngày kết thúc khấu hao"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? NgayKetThucKhauHao { get; set; }

        [Required, Display(Name = "Ghi chú khấu hao xe"), MaxLength(250)]
        public string GhiChuKhauHaoXe { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect email")]
        //public string EmailTo;

        public ThongTinXeVaKhauHaoModel(int xeKey, short? hangSanXuatXeKey, string hangSanXuatXe, int loaiXeKey, string loaiXe
            , string bangSoXe, string soSan
            , DateTime ngayCapPhep, string mau, decimal giaMua, bool coWifi, bool coTivi, bool coCameraHanhTrinh, string ghiChuThongTinXe
            , decimal? soThangKhauHao, decimal? tongTienKhauHao, decimal? tienKhauHaoHangThang, DateTime? ngayBatDauKhauHao, DateTime? ngayKetThucKhauHao, string ghiChuKhauHaoXe)
        {
            XeKey = xeKey;
            HangSanXuatXeKey = hangSanXuatXeKey;
            LoaiXeKey = loaiXeKey;
            HangSanXuatXe = hangSanXuatXe;
            LoaiXe = loaiXe;
            BangSoXe = bangSoXe;
            SoSan = soSan;
            NgayCapPhep = ngayCapPhep;
            Mau = mau;
            GiaMua = giaMua;
            CoWifi = coWifi;
            CoTivi = coTivi;
            CoCameraHanhTrinh = coCameraHanhTrinh;
            GhiChuThongTinXe = ghiChuThongTinXe;
            SoThangKhauHao = soThangKhauHao; 
            TongTienKhauHao = tongTienKhauHao;
            TienKhauHaoHangThang = tienKhauHaoHangThang;
            NgayBatDauKhauHao = ngayBatDauKhauHao;
            NgayKetThucKhauHao = ngayKetThucKhauHao;
            GhiChuKhauHaoXe = ghiChuKhauHaoXe;
        }//EndFunction

        public ThongTinXeVaKhauHaoModel()
        {
            XeKey = 0;
            HangSanXuatXeKey = 0;
            LoaiXeKey = 0;
            HangSanXuatXe = string.Empty;
            LoaiXe = string.Empty;
            BangSoXe = string.Empty;
            SoSan = string.Empty;
            NgayCapPhep = DefaultValueWhenNull.DefaultDate;
            Mau = string.Empty;
            GiaMua = 0;
            CoWifi = true;
            CoTivi = true;
            CoCameraHanhTrinh = true;
            GhiChuThongTinXe = string.Empty;
            SoThangKhauHao = 0;
            TongTienKhauHao = 0;
            TienKhauHaoHangThang = 0;
            NgayBatDauKhauHao = DefaultValueWhenNull.DefaultDate;
            NgayKetThucKhauHao = DefaultValueWhenNull.DefaultDate;
            GhiChuKhauHaoXe = string.Empty;
        }//EndFunction
    }//EndClass
}//EndNamespace