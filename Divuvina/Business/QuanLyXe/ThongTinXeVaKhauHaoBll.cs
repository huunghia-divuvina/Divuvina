using Divuvina.Models.QuanLyXe;
using Divuvina.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Divuvina.Models;

namespace Divuvina.Business.QuanLyXe
{
    public class ThongTinXeVaKhauHaoBll
    {
        Models.dbContext _db = new Models.dbContext();

        #region Thông tin xe và khấu hao
        public List<ThongTinXeVaKhauHaoModel>LayThongTinXeVaKhauHao(int xeKey = 0)
        {
            try
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
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }//EndFunction

        public bool LuuThongTinXeVaKhauHao(ThongTinXeVaKhauHaoModel thongTinXeVaKhauHaoModel)
        {
            using (var dbContextTransaction = _db.Database.BeginTransaction())
            {
                try
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
                    dbContextTransaction.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw (ex);
                }
            }
        }//EndFunction

        public bool XoaThongTinXeVaKhauHao(int xeKey)
        {
            try
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
                }
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }//EndFunction
        #endregion Thông tin xe và khấu hao

        #region Sắp lịch bảo trì xe
        public List<object> LayThongTinXe(string thongTinXe)
        {
            try
            {
                if (!String.IsNullOrEmpty(thongTinXe))
                {
                    //var listThongTinXe = _db.Xes
                    //    .Where(xe => xe.BangSoXe.Contains(thongTinXe) || xe.SoSan.Contains(thongTinXe)
                    //    || xe.Mau.Contains(thongTinXe) || xe.GhiChu.Contains(thongTinXe))
                    //    .Select(xe => new { xe.XeKey, xe.BangSoXe, xe.SoSan, xe.NgayCapPhep, xe.Mau, xe.GiaMua, xe.CoCameraHanhTrinh, xe.CoTivi, xe.CoWifi, xe.GhiChu });
                    //var listThongTinXe = _db.Database.s
                    //return listThongTinXe.ToList(Object);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }//EndFunction

        #endregion Sắp lịch bảo trì xe
    }//EndClass
}//EndNamespace