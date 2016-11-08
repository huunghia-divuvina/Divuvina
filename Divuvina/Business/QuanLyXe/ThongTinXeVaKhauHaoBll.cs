using Divuvina.Models.QuanLyXe;
using Divuvina.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Divuvina.Business.QuanLyXe
{
    public class ThongTinXeVaKhauHaoBll
    {
        Models.dbContext _db = new Models.dbContext();

        public List<ThongTinXeVaKhauHaoModel>LayThongTinXeVaKhauHao(int xeKey = 0)
        {
            if (xeKey > 0)
            {
                List<ThongTinXeVaKhauHaoModel> listThongTinXeVaKhauHaoModel = _db.KhauHaos.Where(k => k.XeKey == xeKey)
                    .Join(_db.Xes,
                        khauHao => khauHao.XeKey,
                        xe => xe.XeKey,
                        (khauHao, xe) => new { KhauHao = khauHao, Xe = xe })
                    //.Where(khauHaoXe => khauHaoXe.KhauHao.XeKey == xeKey)
                    .Select(khauHaoXe => new ThongTinXeVaKhauHaoModel
                    {
                        XeKey = khauHaoXe.Xe.XeKey,
                        HangSanXuatXeKey = khauHaoXe.Xe.LoaiXe.HangSanXuatXeKey,
                        HangSanXuatXe = khauHaoXe.Xe.LoaiXe.HangSanXuatXe.Ten,
                        LoaiXeKey = khauHaoXe.Xe.LoaiXeKey,
                        LoaiXe = khauHaoXe.Xe.LoaiXe.Ten,
                        BangSoXe = khauHaoXe.Xe.BangSoXe,
                        SoSan = khauHaoXe.Xe.SoSan,
                        NgayCapPhep = khauHaoXe.Xe.NgayCapPhep,
                        Mau = khauHaoXe.Xe.Mau,
                        GiaMua = khauHaoXe.Xe.GiaMua,
                        TongTienKhauHao = khauHaoXe.KhauHao.TongTienKhauHao,
                        SoThangKhauHao = khauHaoXe.KhauHao.SoThangKhauHao,
                        TienKhauHaoHangThang = khauHaoXe.KhauHao.TienKhauHaoHangThang,
                        NgayBatDauKhauHao = khauHaoXe.KhauHao.NgayBatDauKhauHao,
                        NgayKetThucKhauHao = khauHaoXe.KhauHao.NgayKetThucKhauHao,
                        CoWifi = khauHaoXe.Xe.CoWifi,
                        CoTivi = khauHaoXe.Xe.CoTivi,
                        CoCameraHanhTrinh = khauHaoXe.Xe.CoCameraHanhTrinh,
                        GhiChuThongTinXe = khauHaoXe.Xe.GhiChu,
                        GhiChuKhauHaoXe = khauHaoXe.KhauHao.GhiChu,
                    }).ToList();

                return listThongTinXeVaKhauHaoModel;
            }
            else
            {
                List<ThongTinXeVaKhauHaoModel> listThongTinXeVaKhauHaoModel = _db.KhauHaos
                    .Join(_db.Xes,
                        khauHao => khauHao.XeKey,
                        xe => xe.XeKey,
                        (khauHao, xe) => new { KhauHao = khauHao, Xe = xe })
                    .Select(khauHaoXe => new ThongTinXeVaKhauHaoModel
                    {
                        XeKey = khauHaoXe.Xe.XeKey,
                        HangSanXuatXeKey = khauHaoXe.Xe.LoaiXe.HangSanXuatXeKey,
                        HangSanXuatXe = khauHaoXe.Xe.LoaiXe.HangSanXuatXe.Ten,
                        LoaiXeKey = khauHaoXe.Xe.LoaiXeKey,
                        LoaiXe = khauHaoXe.Xe.LoaiXe.Ten,
                        BangSoXe = khauHaoXe.Xe.BangSoXe,
                        SoSan = khauHaoXe.Xe.SoSan,
                        NgayCapPhep = khauHaoXe.Xe.NgayCapPhep,
                        Mau = khauHaoXe.Xe.Mau,
                        GiaMua = khauHaoXe.Xe.GiaMua,
                        TongTienKhauHao = khauHaoXe.KhauHao.TongTienKhauHao,
                        SoThangKhauHao = khauHaoXe.KhauHao.SoThangKhauHao,
                        TienKhauHaoHangThang = khauHaoXe.KhauHao.TienKhauHaoHangThang,
                        NgayBatDauKhauHao = khauHaoXe.KhauHao.NgayBatDauKhauHao,
                        NgayKetThucKhauHao = khauHaoXe.KhauHao.NgayKetThucKhauHao,
                        CoWifi = khauHaoXe.Xe.CoWifi,
                        CoTivi = khauHaoXe.Xe.CoTivi,
                        CoCameraHanhTrinh = khauHaoXe.Xe.CoCameraHanhTrinh,
                        GhiChuThongTinXe = khauHaoXe.Xe.GhiChu,
                        GhiChuKhauHaoXe = khauHaoXe.KhauHao.GhiChu,
                    }).ToList();

                return listThongTinXeVaKhauHaoModel;
            }
        }//EndFunction
    }//EndClass
}//EndNamespace