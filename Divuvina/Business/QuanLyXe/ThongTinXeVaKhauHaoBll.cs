using Divuvina.Models.QuanLyXe;
using Divuvina.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
                        NgayBatDauKhauHao = DbFunctions.TruncateTime(khauHaoXe.KhauHao.NgayBatDauKhauHao),
                        NgayKetThucKhauHao = DbFunctions.TruncateTime(khauHaoXe.KhauHao.NgayKetThucKhauHao),
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
                        //NgayCapPhep = khauHaoXe.Xe.NgayCapPhep == null? "" : khauHaoXe.Xe.NgayCapPhep.ToString("dd-MM-yyyy"),
                        Mau = khauHaoXe.Xe.Mau,
                        GiaMua = khauHaoXe.Xe.GiaMua,
                        TongTienKhauHao = khauHaoXe.KhauHao.TongTienKhauHao,
                        SoThangKhauHao = khauHaoXe.KhauHao.SoThangKhauHao,
                        TienKhauHaoHangThang = khauHaoXe.KhauHao.TienKhauHaoHangThang,
                        NgayBatDauKhauHao = DbFunctions.TruncateTime(khauHaoXe.KhauHao.NgayBatDauKhauHao),
                        NgayKetThucKhauHao = DbFunctions.TruncateTime(khauHaoXe.KhauHao.NgayKetThucKhauHao),
                        //NgayBatDauKhauHao = khauHaoXe.KhauHao.NgayBatDauKhauHao == null ? "" : ((DateTime)khauHaoXe.KhauHao.NgayBatDauKhauHao).ToString("dd-MM-yyyy"),
                        //NgayKetThucKhauHao = khauHaoXe.KhauHao.NgayKetThucKhauHao == null ? "" : ((DateTime)khauHaoXe.KhauHao.NgayKetThucKhauHao).ToString("dd-MM-yyyy"),
                        CoWifi = khauHaoXe.Xe.CoWifi,
                        CoTivi = khauHaoXe.Xe.CoTivi,
                        CoCameraHanhTrinh = khauHaoXe.Xe.CoCameraHanhTrinh,
                        GhiChuThongTinXe = khauHaoXe.Xe.GhiChu,
                        GhiChuKhauHaoXe = khauHaoXe.KhauHao.GhiChu,
                    }).ToList();

                return listThongTinXeVaKhauHaoModel;
            }
        }//EndFunction

        public bool LuuThongTinXeVaKhauHao(ThongTinXeVaKhauHaoModel thongTinXeVaKhauHaoModel)
        {
            //Kiểm tra thêm mới hay chỉnh sửa.
            var row = _db.Xes.FirstOrDefault(r => r.XeKey == thongTinXeVaKhauHaoModel.XeKey);
            if (row == null)
            {
                row = new Models.Xe();
                row.XeAlternateKey = thongTinXeVaKhauHaoModel.XeKey.ToString();
                _db.Xes.Add(row);
            }
            row.BangSoXe = thongTinXeVaKhauHaoModel.BangSoXe;
            row.CoCameraHanhTrinh = thongTinXeVaKhauHaoModel.CoCameraHanhTrinh;
            row.CoTivi = thongTinXeVaKhauHaoModel.CoTivi;
            row.CoWifi = thongTinXeVaKhauHaoModel.CoWifi;
            row.GhiChu = thongTinXeVaKhauHaoModel.GhiChuThongTinXe;
            row.GiaMua = thongTinXeVaKhauHaoModel.GiaMua;
            row.LoaiXeKey = thongTinXeVaKhauHaoModel.LoaiXeKey;
            row.Mau = thongTinXeVaKhauHaoModel.Mau;
            row.NgayCapPhep = thongTinXeVaKhauHaoModel.NgayCapPhep;
            row.SoSan = thongTinXeVaKhauHaoModel.SoSan;
            _db.SaveChanges();

            var dongMoiThem = _db.Xes.FirstOrDefault(r => r.BangSoXe == thongTinXeVaKhauHaoModel.BangSoXe && r.SoSan == thongTinXeVaKhauHaoModel.SoSan);
            if (dongMoiThem != null && dongMoiThem.XeKey > 0)
            {
                var dongKhauHao = _db.KhauHaos.FirstOrDefault(r => r.XeKey == dongMoiThem.XeKey);
                if (dongKhauHao == null)
                {
                    dongKhauHao = new Models.KhauHao();
                    dongKhauHao.KhauHaoAlternateKey = dongKhauHao.KhauHaoKey.ToString();
                    _db.KhauHaos.Add(dongKhauHao);
                }
                dongKhauHao.GhiChu = thongTinXeVaKhauHaoModel.GhiChuKhauHaoXe;
                dongKhauHao.NgayBatDauKhauHao = thongTinXeVaKhauHaoModel.NgayBatDauKhauHao;
                dongKhauHao.NgayKetThucKhauHao = thongTinXeVaKhauHaoModel.NgayKetThucKhauHao;
                dongKhauHao.SoThangKhauHao = thongTinXeVaKhauHaoModel.SoThangKhauHao;
                dongKhauHao.TienKhauHaoHangThang = thongTinXeVaKhauHaoModel.TienKhauHaoHangThang;
                dongKhauHao.TongTienKhauHao = thongTinXeVaKhauHaoModel.TongTienKhauHao;
                dongKhauHao.XeKey = dongMoiThem.XeKey;
                _db.SaveChanges();
            }
            return true;
        }//EndFunction

        public bool XoaThongTinXeVaKhauHao(int xeKey)
        {
            var thongTinXe = _db.Xes.FirstOrDefault(r => r.XeKey == xeKey);
            if (thongTinXe != null)
            {
                var khauHaoXe = _db.KhauHaos.FirstOrDefault(khauHao => khauHao.XeKey == xeKey);
                if (khauHaoXe != null)
                {
                    _db.KhauHaos.Remove(khauHaoXe);
                    _db.Xes.Remove(thongTinXe);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }//EndFunction
    }//EndClass
}//EndNamespace