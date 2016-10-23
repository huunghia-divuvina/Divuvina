﻿using Divuvina.Public;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Divuvina.Controllers
{
    public class QuanLyXeController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        // GET: QuanLyXe
        public ActionResult Index()
        {
            return View();
        }

        #region Bảo trì sửa chữa xe
        public ActionResult BaoTriSuaChuaXe()
        {
            return View();
        }

        public JsonResult GetDanhMucXe()
        {
            var rs = _db.Xes.Select(r => new { id = r.XeKey, text = r.BangSoXe });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLichBaoTri(string XeKey)
        {
            if (XeKey == null)
                XeKey = "-1";
            var rs = _db.LichBaoTriXes
                .Where(r => r.XeKey.ToString() == XeKey)
                .Select(r => new { Key = r.LichBaoTriXeKey, r.Xe.BangSoXe, r.Xe.SoSan, r.NgaySapLich });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLichBaoTriChiTiet(string LbtctKey)
        {
            if (LbtctKey == null)
                LbtctKey = "-1";

            var rs = _db.LichBaoTriXeChiTiets
                .Where(r => r.LichBaoTriXeKey.ToString() == LbtctKey)
                .Select(r => new { Key = r.LichBaoTriXeChiTietKey, r.ThietBiLinhKien.Ten, r.SoLuong, r.TongTien });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetThietBiLinhKien()
        {
            var rs = _db.ThietBiLinhKiens
                .Select(r => new { id = r.ThietBiLinhKienKey, text = r.Ten });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddLbtscct(string LscbtKey, string TblkKey, decimal SoLuong, decimal TongTien)
        {
            try
            {
                var row = new Models.LichBaoTriXeChiTiet();
                row.LichBaoTriXeKey = Convert.ToInt32(LscbtKey);
                row.ThietBiLinhKienKey = Convert.ToInt32(TblkKey);
                row.SoLuong = SoLuong;
                row.TongTien = TongTien;
                _db.LichBaoTriXeChiTiets.Add(row);

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }//EndClass
}//EndNamespace