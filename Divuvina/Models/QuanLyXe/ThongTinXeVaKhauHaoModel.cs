﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Divuvina.Models.QuanLyXe
{
    public class ThongTinXeVaKhauHaoModel
    {
        [Required, Display(Name = "Xe key")]
        public int XeKey { get; set; }

        [Required, Display(Name = "Key tham chiếu bảng Hãng sản xuất xe")]
        public int HangSanXuatXeKey { get; set; }

        [Required, Display(Name = "Key tham chiếu bảng Loại xe")]
        public int LoaiXeKey { get; set; }

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
        public short SoThangKhauHao { get; set; }

        [Required, Display(Name = "Tổng tiền khấu hao xe")]
        public decimal TongTienKhauHao { get; set; }

        [Required, Display(Name = "Tiền khấu hao xe hàng tháng")]
        public decimal TienKhauHaoHangThang { get; set; }

        [Required, Display(Name = "Ngày bắt đầu khấu hao"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime NgayBatDauKhauHao { get; set; }

        [Required, Display(Name = "Ngày kết thúc khấu hao"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime NgayKetThucKhauHao { get; set; }

        [Required, Display(Name = "Ghi chú khấu hao xe"), MaxLength(250)]
        public string GhiChuKhauHaoXe { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect email")]
        //public string EmailTo;


    }//EndClass
}//EndNamespace