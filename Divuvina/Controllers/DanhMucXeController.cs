﻿using Divuvina.Public;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Divuvina.Controllers
{
    public class DanhMucXeController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        // GET: QuanLyXe
        public ActionResult Index()
        {
            return View();
        }

        #region HangSanXuatXe
        public ActionResult HangSanXuatXe()
        {
            return View();
        }

        public JsonResult GetDataHangSanXuatXe()
        {
            var listHangSanXuatXes = _db.HangSanXuatXes.Select(r => new { Key = r.HangSanXuatXeKey, r.Ten, GhiChu = ""/*, r.GhiChu*/});
            return Json(listHangSanXuatXes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteHangSanXuatXe(int Key)
        {
            try
            {
                var row = _db.HangSanXuatXes.FirstOrDefault(r => r.HangSanXuatXeKey == Key);
                if (row != null)
                {
                    _db.HangSanXuatXes.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveHangSanXuatXe(int Key, string ten, string ghiChu)
        {
            try
            {
                var row = _db.HangSanXuatXes.FirstOrDefault(r => r.HangSanXuatXeKey == Key);
                if (row == null)
                {
                    row = new Models.HangSanXuatXe();
                    _db.HangSanXuatXes.Add(row);
                }
                row.Ten = ten;
                //row.GhiChu = ghiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion HangSanXuatXe

        #region DanhMucLoaiXe
        public ActionResult DanhMucLoaiXe()
        {
            return View();
        }

        public JsonResult GetDataDanhMucLoaiXe()
        {
            var rs = _db.LoaiXes
                .Select(r => new { Key = r.LoaiXeKey, r.Ten, r.MoTa,
                    HangSanXuatXe = r.HangSanXuatXe.Ten, r.HangSanXuatXe.HangSanXuatXeKey,
                    r.Model, r.MayChayDau, r.MayChayXang, r.SoGhe,
                    LoaiGhe = r.LoaiGhe.Ten , r.LoaiGhe.LoaiGheKey,
                    r.GhiChu });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucLoaiXe(int Key)
        {
            try
            {
                var row = _db.LoaiXes.FirstOrDefault(r => r.LoaiXeKey == Key);
                if (row != null)
                {
                    _db.LoaiXes.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucLoaiXe(int Key, string ten, string moTa, short hangSanXuatXeKey, string model
            , bool mayChayDau
            , bool mayChayXang
            , short soGhe
            , short loaiGheKey
            , string ghiChu)
        {
            try
            {
                var row = _db.LoaiXes.FirstOrDefault(r => r.LoaiXeKey == Key);
                if (row == null)
                {
                    row = new Models.LoaiXe();
                    row.LoaiXeAlternateKey = Key.ToString();
                    _db.LoaiXes.Add(row);
                }
                row.Ten = ten;
                row.MoTa = moTa;
                row.HangSanXuatXeKey = hangSanXuatXeKey;
                row.Model = model;
                row.MayChayDau = mayChayDau;
                row.MayChayXang = mayChayXang;
                row.SoGhe = soGhe;
                row.LoaiGheKey = loaiGheKey;
                row.GhiChu = ghiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDanhMucLoaiGhe()
        {
            var listLoaiGhes = _db.LoaiGhes.Select(r => new { id = r.LoaiGheKey, text = r.Ten });
            return Json(listLoaiGhes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHangSanXuatXe()
        {
            var listHangSanXuatXes = _db.HangSanXuatXes.Select(r => new { id = r.HangSanXuatXeKey, text = r.Ten });
            return Json(listHangSanXuatXes, JsonRequestBehavior.AllowGet);
        }

        #endregion DanhMucLoaiXe

        #region DanhMucNoiSuaChuaXe
        public ActionResult DanhMucNoiSuaChuaXe()
        {
            return View();
        }

        public JsonResult GetDataDanhMucNoiSuaChuaXe()
        {
            var rs = _db.NoiSuaChuaXes.Select(r => new { Key = r.NoiSuaChuaXeKey, r.Ten, r.DiaChi, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucNoiSuaChuaXe(int Key)
        {
            try
            {
                var row = _db.NoiSuaChuaXes.FirstOrDefault(r => r.NoiSuaChuaXeKey == Key);
                if (row != null)
                {
                    _db.NoiSuaChuaXes.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = "Thông báo !", Message = "Thao tác dữ liệu thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = "Thông báo !", Message = "Thao tác dữ liệu không thành công !" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucNoiSuaChuaXe(int Key, string ten, string diaChi, string ghiChu)
        {
            try
            {
                var row = _db.NoiSuaChuaXes.FirstOrDefault(r => r.NoiSuaChuaXeKey == Key);
                if (row == null)
                {
                    row = new Models.NoiSuaChuaXe();
                    row.NoiSuaChuaXeAlternateKey = Key.ToString();
                    _db.NoiSuaChuaXes.Add(row);
                }
                row.Ten = ten;
                row.DiaChi = diaChi;
                row.GhiChu = ghiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion DanhMucNoiSuaChuaXe

        #region DanhMucThietBiLinhKien
        public ActionResult DanhMucThietBiLinhKien()
        {
            return View();
        }

        public JsonResult GetDataDanhMucThietBiLinhKien()
        {
            var rs = _db.ThietBiLinhKiens.Select(r => new { Key = r.ThietBiLinhKienKey, r.Ten, r.HangSanXuat, r.DienGiai, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucThietBiLinhKien(int Key)
        {
            try
            {
                var row = _db.ThietBiLinhKiens.FirstOrDefault(r => r.ThietBiLinhKienKey == Key);
                if (row != null)
                {
                    _db.ThietBiLinhKiens.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = "Thông báo !", Message = "Thao tác dữ liệu thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = "Thông báo !", Message = "Thao tác dữ liệu không thành công !" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucThietBiLinhKien(int Key, string ten, string hangSanXuat, string dienGiai, string ghiChu)
        {
            try
            {
                var row = _db.ThietBiLinhKiens.FirstOrDefault(r => r.ThietBiLinhKienKey == Key);
                if (row == null)
                {
                    row = new Models.ThietBiLinhKien();
                    row.ThietBiLinhKienAlternateKey = Key.ToString();
                    _db.ThietBiLinhKiens.Add(row);
                }
                row.Ten = ten;
                row.HangSanXuat = hangSanXuat;
                row.DienGiai = dienGiai;
                row.GhiChu = ghiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion DanhMucThietBiLinhKiend

    }//EndClass
}//EndNamespace